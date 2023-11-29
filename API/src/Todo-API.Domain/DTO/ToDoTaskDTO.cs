using Todo_API.Domain.Enums;

namespace ToDo_API.Domain.DTO
{
    public class ToDoTaskDTO
    {
        public int ToDoTaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public Priority PriorityId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool Completed => CompletedDate is not null;
    }
}
