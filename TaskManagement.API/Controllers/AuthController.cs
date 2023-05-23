using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagement.Application.Features.Users.Requests.Commands;
using TaskManagment.Application.Contracts.Identity;
using TaskManagment.Application.Features.Users.DTOs;
using TaskManagment.Application.Models.Identity;
using TaskManagment.Application.Responses;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMediator mediator, IMapper mapper)
        {
            _authService = authService;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginModel request)
        {
            var response = await _authService.Login(request);
            return HandleResult(response);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Result<RegistrationResponse>>> Register([FromBody] RegisterDTO registerDTO)
        {
            var response = await _authService.Register(_mapper.Map<RegisterModel>(registerDTO));
            var command = new CreateUserCommand { userDTO = _mapper.Map<CreateUserDTO>(registerDTO) };
            if (!response.Success || response.Value == null)
                return HandleResult(response);

            command.userDTO.AccountId = response.Value.UserId;
            try
            {
                var userResponse = await _mediator.Send(command);
                return HandleResult(response);
            }
            catch (Exception e)
            {
                await _authService.DeleteUser(registerDTO.Email);
                response.Success = false;
                response.Errors.Add(e.Message);
                return HandleResult(response);
            }

        }

        [HttpGet]
        [Route("ResendConfirmLink")]
        public async Task<ActionResult<Result<string>>> ResendConfirmEmailLink(string email)
        {
            var response = await _authService.sendConfirmEmailLink(email);
            return HandleResult(response);
        }

        [HttpGet]
        [Route("Confirm")]
        public async Task<ActionResult<Result<string>>> ConfirmEmail(string email, string token)
        {
            var response = await _authService.ConfirmEmail(token, email);
            return HandleResult(response);

        }

        [HttpGet]
        [Route("ForgotPassword")]
        public async Task<ActionResult<Result<string>>> ForgotPassword(string email)
        {
            var response = await _authService.ForgotPassword(email);
            return HandleResult(response);

        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<ActionResult<Result<string>>> ResetPassword([FromBody] ResetPasswordModel resetPasswordModel)
        {
            var response = await _authService.ResetPassword(resetPasswordModel);
            return HandleResult(response);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<bool>> Delete(string email)
        {
            var response = await _authService.DeleteUser(email);
            return Ok(response);
        }
    }
}