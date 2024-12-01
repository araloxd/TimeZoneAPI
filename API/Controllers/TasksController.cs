using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IXTaskRepository _taskRepository;
        private readonly IXTaskService _taskService;

        public TasksController(IXTaskRepository stepRepository, IXTaskService taskSerive)
        {
            _taskRepository = stepRepository;
            _taskService = taskSerive;
        }

        [HttpGet]
        public async Task<IEnumerable<XTask>> GetSteps(Guid userId)
        {
            var steps = await _taskRepository.GetAllTasksByIdAsync(userId);
            return steps;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] XTask task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _taskRepository.AddAsync(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
                return NotFound($"Task with ID {id} not found.");

            return Ok(task);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] XTask task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTask = await _taskRepository.GetByIdAsync(id);
            if (existingTask == null)
                return NotFound($"Task with ID {id} not found.");

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Priority = task.Priority;
            existingTask.DueDate = task.DueDate;
            existingTask.IsCompleted = task.IsCompleted;

            await _taskRepository.UpdateAsync(existingTask);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
                return NotFound($"Task with ID {id} not found.");

            await _taskRepository.DeleteAsync(task);
            return NoContent();
        }

        // Mark a task as completed
        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> MarkTaskAsComplete(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
                return NotFound($"Task with ID {id} not found.");

            task.IsCompleted = true;
            await _taskRepository.UpdateAsync(task);

            return Ok(task);
        }
    }
}
