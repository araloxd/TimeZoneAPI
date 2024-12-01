using Core.Enums;

namespace Core.DTOs
{
    public class XTaskDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } = StepPriorities.Medium.ToString();
        public bool IsCompleted { get; set; } = false;
    }
}
