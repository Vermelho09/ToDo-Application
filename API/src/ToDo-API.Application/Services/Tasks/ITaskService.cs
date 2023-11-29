using Todo_API.Domain.Inputs;
using ToDo_API.Domain.DTO;

namespace ToDo_API.Application.Services.Tasks
{
    public interface ITaskService
    {
        Task<IEnumerable<ToDoTaskDTO>> GetToDoTasksAsync(CancellationToken cancelationToken);
        Task<int> CreateToDoTaskAsync(CreateToDoTaskInput toDoTask, CancellationToken cancelationToken);
        Task ConcludeToDoTaskAsync(int toDoTaskId, CancellationToken cancelationToken);
        Task DeleteToDoTaskAsync(int toDoTaskId, CancellationToken cancelationToken);
    }
}
