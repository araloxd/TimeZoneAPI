using Core.Entities;

namespace Core.Interfaces
{
    public interface IStepRepository 
    {
        public Task<IEnumerable<Step>> GetAllStepsByIdAsync(Guid userId);
    }
}
