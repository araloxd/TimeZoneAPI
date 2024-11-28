namespace Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<Task?> GetTaskByIdAsync(Guid id);
        Task<List<Task>> GetTasksByUserIdAsync(Guid userId);
        Task CreateTaskAsync(Task task);
        Task UpdateTaskAsync(Task task);
        Task DeleteTaskAsync(Guid id);
    }
}
