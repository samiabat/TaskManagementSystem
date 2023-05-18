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
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository; // repo;

        public GetUserListQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<UserDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
