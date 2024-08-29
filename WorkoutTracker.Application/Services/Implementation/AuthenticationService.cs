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
        public AuthenticationService(IUserRepository userRepository, IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _userManager = userManager;
        }
        public Task<string> LoginAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUserAsync(UserDto userDto)
        {
            var user = new AppUser { UserName = userDto.Email, Email = userDto.Email };
            return await _userRepository.CreateAsync(user, userDto.Password);
        }
    }
}
