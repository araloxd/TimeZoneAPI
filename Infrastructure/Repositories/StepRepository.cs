using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class StepRepository : BaseRepository<Step>, IStepRepository
    {
        private readonly IGenericRepository<Step> _baseRepository;

        public StepRepository(IGenericRepository<Step> baseRepository, AppDbContext context) : base(context)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<Step>> GetAllStepsByIdAsync(Guid userId)
        {
            return await GetAllByIdAsync(userId);
        }
    }
}
