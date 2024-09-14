using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutTracker.Core.Entities.Common;

namespace WorkoutTracker.Core.Entities
{
    public class WorkoutProgress : AuditableBaseEntity
    {
        [Required]
        public Guid WorkoutPlanId { get; set; }

        [Required]
        public Guid ExerciseId { get; set; }

        [Required]
        [Range(1, 100)]
        public int SetsCompleted { get; set; }

        [Required]
        [Range(1, 100)]
        public int RepsCompleted { get; set; }

        [Range(0, 1000)]
        public float? WeightUsed { get; set; }

        [Required]
        public DateTime DateLogged { get; set; }

        // Foreign Key Relationship
        [ForeignKey("WorkoutPlanId")]
        public WorkoutPlan WorkoutPlan { get; set; }

        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }
    }
}
