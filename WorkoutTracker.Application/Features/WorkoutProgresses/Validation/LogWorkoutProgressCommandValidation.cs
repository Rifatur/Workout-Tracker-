using FluentValidation;
using WorkoutTracker.Application.DTOs.WorkoutProgresses;
using WorkoutTracker.Application.Features.WorkoutProgresses.Command;

namespace WorkoutTracker.Application.Features.WorkoutProgresses.Validation
{
    public class LogWorkoutProgressCommandValidation : AbstractValidator<LogWorkoutProgressCommand>
    {
        public LogWorkoutProgressCommandValidation()
        {
            RuleFor(x => x.WorkoutPlanId).NotEmpty().WithMessage("WorkoutPlanId is required.");
            RuleFor(x => x.ProgressEntries).NotEmpty().WithMessage("ProgressEntries cannot be empty.");
            RuleForEach(x => x.ProgressEntries).SetValidator(new WorkoutProgressDtoValidator());
        }
    }

    public class WorkoutProgressDtoValidator : AbstractValidator<WorkoutProgressDto>
    {
        public WorkoutProgressDtoValidator()
        {
            RuleFor(x => x.ExerciseId).NotEmpty().WithMessage("ExerciseId is required.");
            RuleFor(x => x.SetsCompleted).GreaterThan(0).WithMessage("SetsCompleted must be greater than 0.");
            RuleFor(x => x.RepsCompleted).GreaterThan(0).WithMessage("RepsCompleted must be greater than 0.");
            RuleFor(x => x.WeightUsed).GreaterThanOrEqualTo(0).WithMessage("WeightUsed must be non-negative.");
        }
    }


}
