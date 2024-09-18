namespace WorkoutTracker.Application.DTOs.WorkoutPlans
{
    public class WorkoutPlanDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
