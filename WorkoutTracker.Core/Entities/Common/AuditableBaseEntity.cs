using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Core.Entities.Common
{
    public abstract class AuditableBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
