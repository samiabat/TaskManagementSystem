using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Tasks.Requests.Queries;
using TaskManagment.Application.Contracts.Persistence;
using TaskManagment.Application.Features.Tasks.DTO;

namespace TaskManagement.Application.Features.Tasks.Handlers.Queries
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, List<TaskDTO>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(IMapper mapper, ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }
        public async Task<List<TaskDTO>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAll();
            return _mapper.Map<List<TaskDTO>>(tasks);
        }
    }
}
