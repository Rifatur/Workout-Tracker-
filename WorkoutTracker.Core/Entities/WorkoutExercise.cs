using WorkoutTracker.Core.Entities.Common;

namespace WorkoutTracker.Core.Entities
{
    public class WorkoutExercise : AuditableBaseEntity
    {

        public Guid WorkoutPlanId { get; set; }
        public Guid ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float? Weight { get; set; }
        public string Comments { get; set; }

        public WorkoutPlan WorkoutPlan { get; set; }
        public Exercise Exercise { get; set; }
    }
}
