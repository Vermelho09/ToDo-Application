namespace ToDo_API.Infrastructure.SqlServer.Repositories.Queries
{
    public class Queries
    {
        public const string GetAllActiveTasks = "SELECT * FROM ToDoTasks where CompletedDate is null";

        public const string CreateTask = @"INSERT INTO ToDoTasks (Title, Description, TargetDate, PriorityId, CreatedDate, CompletedDate)
                                        VALUES (@Title, @Description, @TargetDate, @PriorityId, GETDATE(), NULL);
                                        SELECT SCOPE_IDENTITY() AS ToDoItemId;"
        ;

        public const string ConcludeTask = @"UPDATE ToDoTasks
                                        SET 
                                            CompletedDate = GETDATE()
                                        WHERE ToDoTaskId = @ToDoTaskId";

        public const string DeleteTask = "DELETE FROM ToDoTasks WHERE ToDoTaskId = @ToDoTaskId";
    }
}
