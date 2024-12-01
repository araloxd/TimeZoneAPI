using Core.Entities;

namespace Core.Interfaces
{
    public interface IXTaskRepository 
    {
        public Task AddAsync(XTask task);
        public Task DeleteAsync(XTask task);
        public Task<IEnumerable<XTask>> GetAllTasksByIdAsync(Guid userId);
        public Task<XTask?> GetByIdAsync(Guid id);
        public Task UpdateAsync(XTask existingTask);
    }
}
