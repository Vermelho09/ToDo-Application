using AutoMapper;
using Todo_API.Domain.Inputs;
using ToDo_API.Application.Repositories;
using ToDo_API.Domain;
using ToDo_API.Domain.DTO;

namespace ToDo_API.Application.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ToDoTaskDTO>> GetToDoTasksAsync(CancellationToken cancelationToken)
        {
            try
            {
                var data = await _repository.GetAllAsync(cancelationToken);
                return _mapper.Map<IEnumerable<ToDoTaskDTO>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CreateToDoTaskAsync(CreateToDoTaskInput input, CancellationToken cancelationToken)
        {
            try
            {
                var entity = _mapper.Map<ToDoTaskEntity>(input);
                var createdId = await _repository.CreateAsync(entity, cancelationToken);
                return createdId;
            }
            catch (Exception)
            {
                // Error handlers and logs
                throw;
            }
        }

        public async Task ConcludeToDoTaskAsync(int toDoTaskId, CancellationToken cancelationToken)
        {
            await _repository.ConcludeTaskAsync(toDoTaskId, cancelationToken);
        }

        public async Task DeleteToDoTaskAsync(int toDoTaskId, CancellationToken cancelationToken)
        {
            await _repository.DeleteAsync(toDoTaskId, cancelationToken);
        }
    }
}
