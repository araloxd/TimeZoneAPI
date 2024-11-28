using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByUsernameAsync(string username);
        System.Threading.Tasks.Task CreateUserAsync(User user);
    }
}
