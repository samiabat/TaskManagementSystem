using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Checklists.Requests.Commands;
using TaskManagement.Application.Features.Checklists.Requests.Queries;
using TaskManagment.Application.Features.Checklists.DTOs;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChecklistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChecklistDTO>>> Get()
        {
            var checklists = await _mediator.Send(new GetChecklistListQuery());
            return Ok(checklists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChecklistDTO>> Get(int id)
        {
            var task = await _mediator.Send(new GetChecklistDetailQuery { Id = id });
            return Ok(task);
        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateCheckListCommand checklist)
        {
            var response = await _mediator.Send(checklist);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateChecklistCommand checklist)
        {
            await _mediator.Send(checklist);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteChecklistCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
