namespace WorkoutTracker.Application.DTOs.Exercises
{
    public record ExerciseDto(
             Guid? Id,
             string Name,
             string Description,
             string Category,
             string MuscleGroup
         );
}
