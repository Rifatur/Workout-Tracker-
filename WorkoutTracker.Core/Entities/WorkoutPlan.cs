using System.ComponentModel.DataAnnotations;
using WorkoutTracker.Core.Entities.Common;

namespace WorkoutTracker.Core.Entities
{
    public class WorkoutPlan : AuditableBaseEntity
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedDate { get; set; }

        // Foreign Key Relationship

        public AppUser AppUser { get; set; }

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();


    }
}
