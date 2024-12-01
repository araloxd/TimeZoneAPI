using Core.DTOs;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;

namespace Application.Services
{
    public class XTaskService : IXTaskService
    {
        private readonly IXTaskRepository _taskRepository;

        public XTaskService(IXTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task CompleteTaskAsync(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }

            task.IsCompleted = true;
            await _taskRepository.UpdateAsync(task);
        }

        public async Task<Guid> CreateTaskAsync(CreateTaskDTO taskDto)
        {
            if (!Enum.TryParse<StepPriorities>(taskDto.Priority, true, out var priority))
            {
                throw new ArgumentException($"Invalid priority value: {taskDto.Priority}");
            }

            var task = new XTask
            {
                Id = Guid.NewGuid(),
                Title = taskDto.Title,
                Description = taskDto.Description,
                Priority = priority,
                DueDate = taskDto.DueDate,
                IsCompleted = false,
                UserId = taskDto.UserId
            };

            await _taskRepository.AddAsync(task);
            return task.Id;
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }

            await _taskRepository.DeleteAsync(task);
        }

        public async Task<XTaskDTO> GetTaskAsync(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }

            return new XTaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority.ToString(),
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted
            };
        }

        public async Task UpdateTaskAsync(UpdateTaskDTO taskDto)
        {
            var task = await _taskRepository.GetByIdAsync(taskDto.Id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {taskDto.Id} not found.");
            }

            if (!Enum.TryParse<StepPriorities>(taskDto.Priority, true, out var priority))
            {
                throw new ArgumentException($"Invalid priority value: {taskDto.Priority}");
            }

            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.Priority = priority;
            task.DueDate = taskDto.DueDate;
            task.IsCompleted = taskDto.IsCompleted;

            await _taskRepository.UpdateAsync(task);
        }

        public async Task<List<XTaskDTO>> GetAllUserTaskById(Guid id)
        {
            var tasks = await _taskRepository.GetAllTasksByIdAsync(id);

            return tasks.Select(task => new XTaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority.ToString(),
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted
            }).ToList();
        }
    }
}