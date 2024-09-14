using WorkoutTracker.Core.Entities.Common;

namespace WorkoutTracker.Core.Entities
{
    public class WorkoutPlan : AuditableBaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ScheduledDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }

        public AppUser AppUser { get; set; }

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }


    }
}
