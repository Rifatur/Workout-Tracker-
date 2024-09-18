using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Application.Features.WorkoutPlans.Command;
using WorkoutTracker.Application.Features.WorkoutPlans.Queries;
using WorkoutTracker.Infrastructure.Context;

namespace WorkoutTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlansController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly WorkoutApiDB _context;
        public WorkoutPlansController(IMediator mediator, WorkoutApiDB context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateWorkoutPlanCommand command)
        {
            var id = await _mediator.Send(command);
            var workoutplan = await _context.WorkoutPlans.FindAsync(id);

            if (workoutplan == null)
            {
                return NotFound("WorkPlan Not found after Creation.");
            }

            return CreatedAtAction(nameof(GetById), new { WorkoutPlanId = workoutplan.Id }, workoutplan);

        }

        [HttpGet("{WorkoutPlanId}")]
        public async Task<IActionResult> GetById(Guid WorkoutPlanId)
        {
            var workoutPlan = await _mediator.Send(new GetWorkoutPlanByIdQuery { Id = WorkoutPlanId });
            return Ok(workoutPlan);
        }


    }
}
