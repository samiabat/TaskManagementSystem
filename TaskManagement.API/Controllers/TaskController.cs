using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Tasks.Requests.Commands;
using TaskManagement.Application.Features.Tasks.Requests.Queries;
using TaskManagment.Application.Features.Tasks.DTO;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDTO>>> Get()
        {
            var tasks = await _mediator.Send(new GetTaskListQuery());
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> Get(int id)
        {
            var task = await _mediator.Send(new GetTaskDetailQuery { Id = id });
            return Ok(task);
        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateTaskCommand task)
        {
            var response = await _mediator.Send(task);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateTaskCommand task)
        {
            await _mediator.Send(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTaskCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
