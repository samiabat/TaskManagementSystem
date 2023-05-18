using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagement.Application.Features.Users.Requests.Queries;
using TaskManagment.Application.Contracts.Persistence;

namespace TaskManagement.Application.Features.Users.Handlers.Queries
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<UserDTO> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
