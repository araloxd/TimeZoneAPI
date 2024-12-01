using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class CreateTaskDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

        [EnumDataType(typeof(StepPriorities))]
        public string Priority { get; set; }
        public Guid UserId { get; set; }
    }
}
