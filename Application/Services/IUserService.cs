using Core.DTOs;

namespace Application.Services
{
    public interface IUserService
    {
        Task<Guid> RegisterUserAsync(string username, string password, string timeZone);
        Task<string?> AuthenticateUserAsync(string username, string password);
        Task UpdateTimeZoneAsync(Guid userId, string timeZone);
        Task<UserDTO> GetUserById(Guid userId);
    }
}
