using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Application.DTOs.WorkoutProgresses;
using WorkoutTracker.Application.Features.WorkoutProgresses.Command;
using WorkoutTracker.Application.Features.WorkoutProgresses.Queries;

namespace WorkoutTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutProgressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WorkoutProgressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> LogProgress(Guid WorkoutPlanId, LogWorkoutProgressCommand command)
        {
            if (WorkoutPlanId != command.WorkoutPlanId)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }


        [HttpGet]
        public async Task<ActionResult<List<WorkoutReportDto>>> GetReports()
        {
            var reports = await _mediator.Send(new GetWorkoutReportsQuery());
            return Ok(reports);
        }

    }
}
