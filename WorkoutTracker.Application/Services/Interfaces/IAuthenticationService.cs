using WorkoutTracker.Application.DTOs.User;

namespace WorkoutTracker.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterUserAsync(UserDto userDto);
        Task<string> LoginAsync(UserDto userDto);
        Task<List<UserListDto>> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<bool> ActivateUserAsync(string userId);
        Task<bool> DeactivateUserAsync(string userId);
    }
}
