using Core.DTOs;

namespace Application.Services
{
    public interface IXTaskService
    {
        Task<Guid> CreateTaskAsync(CreateTaskDTO stepDto);
        Task UpdateTaskAsync(UpdateTaskDTO stepDto);
        Task<XTaskDTO> GetTaskAsync(Guid id);
        Task<List<XTaskDTO>> GetAllUserTaskById(Guid id);
        Task CompleteTaskAsync(Guid id);
        Task DeleteTaskAsync(Guid id);
    }
}
