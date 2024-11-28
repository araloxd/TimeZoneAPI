using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoTaskController : ControllerBase
    {
        [HttpGet]
        public Task<List<ToDoTask>> GetSteps(int id)
        {
            var steps = new List<ToDoTask>() {
           new ToDoTask
           {
               Id = Guid.NewGuid(),
               Title = "Clean Bathroom",
               Description = "I need to clean my bathroom.",
               DueDate = DateTime.UtcNow.AddDays(2),
               IsCompleted = false,
               Priority = Priorities.Low
           },
            new ToDoTask
           {
               Id = Guid.NewGuid(),
               Title = "Walk the Dog",
               Description = "Tomorrow I need to walk my dog.",
               DueDate = DateTime.UtcNow.AddDays(1),
               IsCompleted = false,
               Priority = Priorities.Medium
           }
          };

            return Task.FromResult(steps);
        }
    }
}
