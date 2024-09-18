using WorkoutTracker.Application.DTOs.WorkoutExercises;

namespace WorkoutTracker.Application.DTOs.WorkoutPlans
{
    public class WorkoutPlanDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public List<WorkoutExerciseDto> Exercises { get; set; }
    }
}
