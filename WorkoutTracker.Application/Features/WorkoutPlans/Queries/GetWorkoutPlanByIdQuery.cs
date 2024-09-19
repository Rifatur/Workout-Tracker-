using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.DTOs.WorkoutExercises;
using WorkoutTracker.Application.DTOs.WorkoutPlans;
using WorkoutTracker.Infrastructure.Context;

namespace WorkoutTracker.Application.Features.WorkoutPlans.Queries
{
    public class GetWorkoutPlanByIdQuery : IRequest<WorkoutPlanDetailDto>
    {
        public Guid Id { get; set; }
    }

    public class GetWorkoutPlanByIdQueryHandler : IRequestHandler<GetWorkoutPlanByIdQuery, WorkoutPlanDetailDto>
    {

        private readonly WorkoutApiDB _context;
        private readonly IMapper _mapper;

        public GetWorkoutPlanByIdQueryHandler(WorkoutApiDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkoutPlanDetailDto> Handle(GetWorkoutPlanByIdQuery request, CancellationToken cancellationToken)
        {
            string userID = "4c85a5db-3792-45ad-8294-504327afcfda";

            var workoutplan = await _context.WorkoutPlans
                .Include(wp => wp.WorkoutExercises)
                .Where(wp => wp.Id == request.Id && wp.AppUserId == userID)
            .FirstAsync(cancellationToken);

            if (workoutplan == null)
            {

            }
            var workoutplanDetails = new WorkoutPlanDetailDto
            {
                Id = workoutplan.Id,
                Name = workoutplan.Name,
                Description = workoutplan.Description,
                ScheduledDate = workoutplan.ScheduledDate,
                Exercises = workoutplan.WorkoutExercises.Select(e => new WorkoutExerciseDto
                {
                    ExerciseId = e.ExerciseId,
                    Sets = e.Sets,
                    Reps = e.Reps,
                    Weight = e.Weight
                }).ToList()

            };
            return _mapper.Map<WorkoutPlanDetailDto>(workoutplanDetails);

        }
    }
}
