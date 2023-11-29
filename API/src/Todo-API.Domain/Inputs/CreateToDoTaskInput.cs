using System.ComponentModel.DataAnnotations;
using Todo_API.Domain.Enums;

namespace Todo_API.Domain.Inputs
{
    public class CreateToDoTaskInput
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime? TargetDate { get; set; }
        [Required]
        public Priority PriorityId { get; set; }
    }
}
