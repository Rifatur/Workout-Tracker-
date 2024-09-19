namespace WorkoutTracker.Application.DTOs.WorkoutProgresses
{
    public class WorkoutProgressDto
    {
        public Guid ExerciseId { get; set; }
        public int SetsCompleted { get; set; }
        public int RepsCompleted { get; set; }
        public float? WeightUsed { get; set; }
    }
}
