using WorkoutTracker.Core.Entities;

namespace WorkoutTracker.Core.Intefaces
{
    public interface IUserRepository
    {
        Task<AppUser> GetByIdAsync(string id);
        Task<AppUser> GetByEmailAsync(string email);
        Task<bool> CreateAsync(AppUser user, string password);
    }
}
