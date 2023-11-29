using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using ToDo_API.Application.Repositories;
using ToDo_API.Domain;

namespace ToDo_API.Infrastructure.SqlServer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public TaskRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnectionString");
        }

        public async Task<IEnumerable<ToDoTaskEntity>> GetAllAsync(CancellationToken cancelationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<ToDoTaskEntity>(Queries.Queries.GetAllActiveTasks, cancelationToken);
            }
        }

        public async Task<int> CreateAsync(ToDoTaskEntity item, CancellationToken cancelationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(Queries.Queries.CreateTask, item);
            }
        }

        public async Task ConcludeTaskAsync(int taskId, CancellationToken cancelationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(Queries.Queries.ConcludeTask, new { ToDoTaskId = taskId });
            }
        }


        public async Task DeleteAsync(int taskId, CancellationToken cancelationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(Queries.Queries.DeleteTask, new { ToDoTaskId = taskId });
            }
        }
    }
}
