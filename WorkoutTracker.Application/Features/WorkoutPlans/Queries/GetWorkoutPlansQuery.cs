using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.DTOs.WorkoutPlans;
using WorkoutTracker.Infrastructure.Context;

namespace WorkoutTracker.Application.Features.WorkoutPlans.Queries
{
    public class GetWorkoutPlansQuery : IRequest<List<WorkoutPlanDto>>
    {
    }

    public class GetWorkoutPlansQueryHandler : IRequestHandler<GetWorkoutPlansQuery, List<WorkoutPlanDto>>
    {
        private readonly WorkoutApiDB _context;
        private readonly IMapper _mapper;

        public GetWorkoutPlansQueryHandler(WorkoutApiDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<WorkoutPlanDto>> Handle(GetWorkoutPlansQuery request, CancellationToken cancellationToken)
        {
            string userID = "4c85a5db-3792-45ad-8294-504327afcfda";
            var workoutplan = await _context.WorkoutPlans
                .Where(wp => wp.AppUserId == userID)
                .Select(wp => new WorkoutPlanDto
                {
                    Id = wp.Id,
                    Name = wp.Name,
                    ScheduledDate = wp.ScheduledDate
                })
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<WorkoutPlanDto>>(workoutplan);
        }
    }
}
