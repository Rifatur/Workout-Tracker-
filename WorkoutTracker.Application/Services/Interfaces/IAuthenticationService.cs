using WorkoutTracker.Application.DTOs.User;

namespace WorkoutTracker.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterUserAsync(UserDto userDto);
        Task<string> LoginAsync(UserDto userDto);
    }
}
