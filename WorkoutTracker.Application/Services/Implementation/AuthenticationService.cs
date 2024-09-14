
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkoutTracker.Application.DTOs.User;
using WorkoutTracker.Application.Services.Interfaces;
using WorkoutTracker.Core.Entities;
using WorkoutTracker.Core.Intefaces;

namespace WorkoutTracker.Application.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthenticationService(IUserRepository userRepository, IConfiguration configuration, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> ActivateUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.IsActive = true;
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public async Task<bool> DeactivateUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.IsActive = false;
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public async Task<List<UserListDto>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            return await _userManager.Users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .Select(user => new UserListDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    IsActive = user.IsActive
                }).ToListAsync();

        }

        public async Task<string> LoginAsync(UserDto userDto)
        {

            var user = await _userManager.FindByEmailAsync(userDto.Email);
            if (user == null || !user.IsActive)
                return "User account is inactive";

            var result = await _signInManager.PasswordSignInAsync(user, userDto.Password, false, false);

            if (result.Succeeded)
            {
                return "Login successful.";
            }
            return "Invalid login attempt.";
        }

        public async Task<bool> RegisterUserAsync(UserDto userDto)
        {
            var user = new AppUser { UserName = userDto.Email, Email = userDto.Email };
            return await _userRepository.CreateAsync(user, userDto.Password);
        }



    }
}
