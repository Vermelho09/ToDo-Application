using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Todo_API.Domain.Inputs;
using ToDo_API.Application.Services.Tasks;
using ToDo_API.Domain;

namespace ToDo_API.Web.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        /// <summary>
        /// Dependency of Application layer could be changed by using MediatR pattern (CQRS) and using Input & Output classes as parameters
        /// </summary>
        private readonly ITaskService _service;
        private readonly AbstractValidator<CreateToDoTaskInput> _validationRules;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public TaskController(ITaskService service, AbstractValidator<CreateToDoTaskInput> validationRules)
        {
            _service = service;
            _validationRules = validationRules;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ToDoTaskEntity>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            //could log the request to any observability service (e.g. Datadog, Dynatrace, Splunk)

            var result = await _service.GetToDoTasksAsync(cancellationToken);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateToDoTaskAsync([FromBody] CreateToDoTaskInput input, CancellationToken cancellationToken)
        {
            //could log request to any observability service (e.g. Datadog, Dynatrace, Splunk)

            var validationResult = await _validationRules.ValidateAsync(input, cancellationToken);

            if (validationResult.IsValid)
            {
                var result = await _service.CreateToDoTaskAsync(input, cancellationToken);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }
        }

        [HttpPut("{taskId}/conclude")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConcludeTasks(int taskId, CancellationToken cancellationToken)
        {
            //could log request to any observability service (e.g. Datadog, Dynatrace, Splunk)

            if (taskId <= 0)
            {
                return BadRequest("Task Id not valid.");
            }
            await _service.ConcludeToDoTaskAsync(taskId, cancellationToken);
            return Ok();
        }

        [HttpDelete("{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteToDoTask(int taskId, CancellationToken cancellationToken)
        {
            //could log request to any observability service (e.g. Datadog, Dynatrace, Splunk)

            if (taskId <= 0)
            {
                return BadRequest("Task Id not valid.");
            }
            await _service.DeleteToDoTaskAsync(taskId, cancellationToken);
            return Ok();
        }
    }
}
