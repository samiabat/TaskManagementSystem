using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagement.Application.Features.Users.Requests.Commands;
using TaskManagement.Application.Features.Users.Requests.Queries;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var users = await _mediator.Send(new GetUserListQuery());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await _mediator.Send(new GetUserDetailQuery { Id = id });
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult> Post(CreateUserCommand user)
        {
            var response = await _mediator.Send(user);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateUserCommand user)
        {
            await _mediator.Send(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
