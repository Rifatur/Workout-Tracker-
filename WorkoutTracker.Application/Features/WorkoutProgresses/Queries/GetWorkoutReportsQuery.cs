using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.DTOs.WorkoutProgresses;
using WorkoutTracker.Infrastructure.Context;

namespace WorkoutTracker.Application.Features.WorkoutProgresses.Queries
{
    public class GetWorkoutReportsQuery : IRequest<List<WorkoutReportDto>>
    {

    }

    //HANDLER

    public class GetWorkoutReportsQueryHandler : IRequestHandler<GetWorkoutReportsQuery, List<WorkoutReportDto>>
    {
        private readonly WorkoutApiDB _context;
        private readonly IMapper _mapper;
        public GetWorkoutReportsQueryHandler(WorkoutApiDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<WorkoutReportDto>> Handle(GetWorkoutReportsQuery request, CancellationToken cancellationToken)
        {
            string userID = "4c85a5db-3792-45ad-8294-504327afcfda";

            var reports = await _context.WorkoutProgress
            .Include(wp => wp.WorkoutPlan)
                .ThenInclude(wp => wp.WorkoutExercises)
                    .ThenInclude(wp => wp.Exercise)
            .Where(wp => wp.WorkoutPlan.AppUserId == userID)
            .Select(wp => new WorkoutReportDto
            {
                WorkoutPlanId = wp.WorkoutPlanId,
                WorkoutName = wp.WorkoutPlan.Name,
                DateLogged = wp.DateLogged,
                ExerciseName = wp.WorkoutPlan.WorkoutExercises
                                .Where(we => we.ExerciseId == wp.ExerciseId)
                                .Select(we => we.Exercise.Name)
                                .FirstOrDefault(),
                SetsCompleted = wp.SetsCompleted,
                RepsCompleted = wp.RepsCompleted,
                WeightUsed = wp.WeightUsed
            })
            .ToListAsync(cancellationToken);

            return _mapper.Map<List<WorkoutReportDto>>(reports);
        }
    }
}
