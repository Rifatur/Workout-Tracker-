namespace WorkoutTracker.Application.DTOs.WorkoutProgresses
{
    public class WorkoutReportDto
    {
        public Guid WorkoutPlanId { get; set; }
        public string WorkoutName { get; set; }
        public DateTime DateLogged { get; set; }
        public string ExerciseName { get; set; }
        public int SetsCompleted { get; set; }
        public int RepsCompleted { get; set; }
        public float? WeightUsed { get; set; }
    }
}
