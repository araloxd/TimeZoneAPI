using Core.DTOs;

namespace Application.Services
{
    public interface IStepService
    {
        Task<Guid> CreateStepAsync(CreateStepDTO stepDto);
        Task UpdateStepAsync(UpdateStepDTO stepDto);
        Task<List<StepDTO>> GetStepsAsync(Guid id);
        Task CompleteStepAsync(Guid id);
        Task DeleteStepAsync(Guid id);
    }

}
