namespace WorkoutTracker.Application.DTOs.WorkoutExercises
{
    public class WorkoutExerciseDto
    {
        public Guid ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float? Weight { get; set; }
    }
}
