using AutoMapper;
using MediatR;
using WorkoutTracker.Application.DTOs.WorkoutExercises;
using WorkoutTracker.Core.Entities;
using WorkoutTracker.Infrastructure.Context;

namespace WorkoutTracker.Application.Features.WorkoutPlans.Command
{
    public class CreateWorkoutPlanCommand : IRequest<Guid>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public List<WorkoutExerciseDto> Exercises { get; set; }
    }

    //Handler .. 

    public class CreateWorkoutPlanCommandHandler : IRequestHandler<CreateWorkoutPlanCommand, Guid>
    {
        private readonly WorkoutApiDB _context;
        private readonly IMapper _mapper;

        public CreateWorkoutPlanCommandHandler(WorkoutApiDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateWorkoutPlanCommand request, CancellationToken cancellationToken)
        {
            var userID = new Guid("b279f27d-2469-4612-9139-760bd42e2a66");

            var workoutPlan = new WorkoutPlan
            {

                UserId = new Guid("b279f27d-2469-4612-9139-760bd42e2a66"),
                Name = request.Name,
                Description = request.Description,
                CreatedDate = DateTime.UtcNow,
                ScheduledDate = request.ScheduledDate,
                //AppUserId = userID,
                IsCompleted = false,

                WorkoutExercises = request.Exercises.Select(x => new WorkoutExercise
                {
                    ExerciseId = x.ExerciseId,
                    Sets = x.Sets,
                    Reps = x.Reps,
                    Weight = x.Weight
                }).ToList()
            };
            _context.WorkoutPlans.Add(workoutPlan);
            await _context.SaveChangesAsync();
            return workoutPlan.Id;

        }
    }





}
