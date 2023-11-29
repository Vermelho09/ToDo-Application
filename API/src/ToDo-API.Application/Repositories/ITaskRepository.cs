using ToDo_API.Domain;

namespace ToDo_API.Application.Repositories
{
    public interface ITaskRepository
    {
        //Task<T> GetAsync<T>(string id);

        Task<IEnumerable<ToDoTaskEntity>> GetAllAsync(CancellationToken cancelationToken);
        Task<int> CreateAsync(ToDoTaskEntity item, CancellationToken cancelationToken);
        Task ConcludeTaskAsync(int taskId, CancellationToken cancelationToken);
        Task DeleteAsync(int taskId, CancellationToken cancelationToken);
    }
}
