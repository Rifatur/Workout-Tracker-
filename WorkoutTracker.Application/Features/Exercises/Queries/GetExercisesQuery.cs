using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.DTOs.Exercises;
using WorkoutTracker.Infrastructure.Context;

namespace WorkoutTracker.Application.Features.Exercises.Queries
{
    public record GetExercisesQuery() : IRequest<List<ExerciseDto>>;


    //Handler..

    public class GetExercisesQueryHandler : IRequestHandler<GetExercisesQuery, List<ExerciseDto>>
    {
        private readonly WorkoutApiDB _context;
        private readonly IMapper _mapper;

        public GetExercisesQueryHandler(WorkoutApiDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ExerciseDto>> Handle(GetExercisesQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _context.Exercises.ToListAsync(cancellationToken);
            if (exercises == null || exercises.Any())
            {

            }

            return _mapper.Map<List<ExerciseDto>>(exercises);
        }
    }


}


