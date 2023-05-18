using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagement.Application.Features.Users.Requests.Commands;
using TaskManagemnt.Domain;
using TaskManagment.Application.Contracts.Persistence;

namespace TaskManagement.Application.Features.Users.Handlers.Commands
{
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.userDTO);
            user = await _userRepository.Add(user);
            return Unit.Value;
        }
    }
}
