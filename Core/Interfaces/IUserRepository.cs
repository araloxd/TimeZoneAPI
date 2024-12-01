﻿using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<Guid> RegisterUserAsync(string username, string password, string timeZone);
        Task<string?> AuthenticateUserAsync(string username, string password);
        Task UpdateTimeZoneAsync(Guid userId, string timeZone);
        Task<UserDTO?> GetUserAsyc(Guid userId);
        Task<UserDTO?> GetUserByUsername(string username);
    }
}
