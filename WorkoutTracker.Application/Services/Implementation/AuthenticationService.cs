
using Microsoft.AspNetCore.Identity;
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
        public async Task<string> LoginAsync(UserDto userDto)
        {

            var user = await _userManager.FindByEmailAsync(userDto.Email);
            if (user == null) { return null; }

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
