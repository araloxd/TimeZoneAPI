using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<Guid> RegisterUserAsync(string username, string password, string timeZone);
        Task<string?> AuthenticateUserAsync(string username, string password);
        Task UpdateTimeZoneAsync(Guid userId, string timeZone);
        Task<User?> GetUserAsyc(Guid userId);
        Task<User?> GetUserByUsername(string username);
    }
}
