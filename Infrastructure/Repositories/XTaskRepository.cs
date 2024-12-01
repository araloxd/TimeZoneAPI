using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class XTaskRepository : BaseRepository<XTask>, IXTaskRepository
    {
        private readonly IGenericRepository<XTask> _baseRepository;

        public XTaskRepository(IGenericRepository<XTask> baseRepository, AppDbContext context) : base(context)
        {
            _baseRepository = baseRepository;
        }

        public Task DeleteAsync(XTask task)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<XTask>> GetAllTasksByIdAsync(Guid userId)
        {
            return await _dbSet.Where(task => task.UserId == userId).ToListAsync();
        }

        public async Task UpdateAsync(XTask existingTask)
        {
            await base.UpdateAsync(existingTask);
        }
    }
}
