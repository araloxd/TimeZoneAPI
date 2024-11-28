using Core.Enums;

namespace Core.Entities
{
    public class ToDoTask
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public Priorities Priority { get; set; } = Priorities.Medium;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
