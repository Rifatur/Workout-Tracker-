using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Application.DTOs.User;
using WorkoutTracker.Application.Services.Interfaces;

namespace WorkoutTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var result = await _authService.RegisterUserAsync(userDto);
            if (result)
                return Ok("User registered successfully");
            return BadRequest("User registration failed");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto model)
        {
            var result = await _authService.LoginAsync(model);
            if (result == "Login successful.")
            {
                return Ok(new { message = result });
            }

            return Unauthorized(new { message = result });

        }

    }
}
