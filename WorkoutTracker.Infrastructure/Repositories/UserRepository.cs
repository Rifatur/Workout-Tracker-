using Microsoft.AspNetCore.Identity;
using WorkoutTracker.Core.Entities;
using WorkoutTracker.Core.Intefaces;

namespace WorkoutTracker.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> CreateAsync(AppUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<AppUser> GetByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}
