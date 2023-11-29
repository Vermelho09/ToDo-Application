namespace ToDo_API.Domain
{
    public class ToDoTaskEntity
    {
        public int ToDoTaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public int PriorityId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}