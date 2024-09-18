using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Application.DTOs.Exercises;
using WorkoutTracker.Application.Features.Exercises.Queries;

namespace WorkoutTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExercisesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<ExerciseDto>>> GetExercises()
        {
            var exercises = await _mediator.Send(new GetExercisesQuery());
            return Ok(exercises);

        }



    }
}
