using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User entity)
        {
            await base.AddAsync(entity);
        }

        public Task<string?> AuthenticateUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(user => user.Id == id);
        }

        public Task<User?> GetUserAsyc(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            User user = await base._dbSet.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }

        public Task<Guid> RegisterUserAsync(string username, string password, string timeZone)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTimeZoneAsync(Guid userId, string timeZone)
        {
            throw new NotImplementedException();
        }
    }
}
