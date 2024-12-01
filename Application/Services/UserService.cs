using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> RegisterUserAsync(string username, string password, string timeZone)
        {
            var existingUser = await _userRepository.GetUserByUsername(username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username is already taken.");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = HashPassword(password),
                TimeZone = timeZone
            };

            await _userRepository.AddAsync(user);
            return user.Id;
        }

        public async Task<string?> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            return "JWT_TOKEN";
        }

        public async Task UpdateTimeZoneAsync(Guid userId, string timeZone)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            user.TimeZone = timeZone;
            await _userRepository.UpdateAsync(user);
        }

        public async Task<UserDTO?> GetUserProfileAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return null;

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                TimeZone = user.TimeZone
            };
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }
    }
}
