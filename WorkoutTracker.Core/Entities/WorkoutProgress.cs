using WorkoutTracker.Core.Entities.Common;

namespace WorkoutTracker.Core.Entities
{
    public class WorkoutProgress : AuditableBaseEntity
    {
        public Guid WorkoutPlanId { get; set; }
        public Guid ExerciseId { get; set; }
        public int SetsCompleted { get; set; }
        public int RepsCompleted { get; set; }
        public float? WeightUsed { get; set; }
        public DateTime DateLogged { get; set; }

        public WorkoutPlan WorkoutPlan { get; set; }
        public Exercise Exercise { get; set; }
    }
}
