using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutTracker.Core.Entities.Common;

namespace WorkoutTracker.Core.Entities
{
    public class WorkoutExercise : AuditableBaseEntity
    {

        [Required]
        public Guid WorkoutPlanId { get; set; }

        [Required]
        public Guid ExerciseId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Sets { get; set; }

        [Required]
        [Range(1, 100)]
        public int Reps { get; set; }

        [Range(0, 1000)]
        public float? Weight { get; set; }

        [MaxLength(500)]
        public string? Comments { get; set; }

        // Foreign Key Relationship
        [ForeignKey("WorkoutPlanId")]
        public WorkoutPlan WorkoutPlan { get; set; }

        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }
    }
}
