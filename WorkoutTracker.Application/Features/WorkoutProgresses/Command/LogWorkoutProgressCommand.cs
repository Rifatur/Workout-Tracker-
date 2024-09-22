using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.DTOs.WorkoutProgresses;
using WorkoutTracker.Core.Entities;
using WorkoutTracker.Infrastructure.Context;

namespace WorkoutTracker.Application.Features.WorkoutProgresses.Command
{
    public class LogWorkoutProgressCommand : IRequest<Unit>
    {
        public Guid WorkoutPlanId { get; set; }
        public List<WorkoutProgressDto> ProgressEntries { get; set; }
    }


    public class LogWorkoutProgressCommandHandler : IRequestHandler<LogWorkoutProgressCommand, Unit>
    {
        private readonly WorkoutApiDB _context;
        private readonly IMapper _mapper;

        public LogWorkoutProgressCommandHandler(WorkoutApiDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Unit> Handle(LogWorkoutProgressCommand request, CancellationToken cancellationToken)
        {

            var workoutPlan = await _context.WorkoutPlans
                .Include(wp => wp.WorkoutExercises)
                .FirstOrDefaultAsync(wp => wp.Id == request.WorkoutPlanId);

            if (workoutPlan == null)
            {
                throw new KeyNotFoundException($"Workout plan with ID {request.WorkoutPlanId} not found.");
            }

            var progressEntries = request.ProgressEntries.Select(entry => new WorkoutProgress
            {
                Id = Guid.NewGuid(),
                WorkoutPlanId = request.WorkoutPlanId,
                ExerciseId = entry.ExerciseId,
                SetsCompleted = entry.SetsCompleted,
                RepsCompleted = entry.RepsCompleted,
                WeightUsed = entry.WeightUsed,
                DateLogged = DateTime.UtcNow,

            }).ToList();

            _context.WorkoutProgress.AddRange(progressEntries);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
