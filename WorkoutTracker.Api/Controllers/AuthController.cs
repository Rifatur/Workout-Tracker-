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
        [HttpGet("Users")]
        public async Task<IActionResult> Users(int pageNumber = 1, int pageSize = 10)
        {
            var pagedUsers = await _authService.GetAllUsersAsync(pageNumber, pageSize);
            return Ok(pagedUsers);
        }

        [HttpPost("ActivateUser")]
        public async Task<IActionResult> ActivateUser([FromBody] ActivateUserDto model)
        {
            var result = await _authService.ActivateUserAsync(model.UserId);
            if (!result)
            {
                return NotFound("User not found or activation failed.");
            }

            return Ok("User activated successfully.");
        }
        [HttpPost("DeactivateUser")]
        public async Task<IActionResult> DeactivateUser([FromBody] ActivateUserDto model)
        {
            var result = await _authService.DeactivateUserAsync(model.UserId);
            if (!result)
            {
                return NotFound("User not found or deactivation failed.");
            }

            return Ok("User deactivated successfully.");
        }




    }
}
