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
            var userID = new Guid("b279f27d-2469-4612-9139-760bd42e2a66");
            var workoutplan = await _context.WorkoutPlans
                .Where(wp => wp.UserId == userID)
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
