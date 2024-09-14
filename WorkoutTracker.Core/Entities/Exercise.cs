using System.ComponentModel.DataAnnotations;
using WorkoutTracker.Core.Entities.Common;

namespace WorkoutTracker.Core.Entities
{
    public class Exercise : AuditableBaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Category { get; set; } // e.g., cardio, strength

        [MaxLength(50)]
        public string MuscleGroup { get; set; } // e.g., chest, legs, back
    }
}
