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
    public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, TaskDTO>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskDetailQueryHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDTO> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.Get(request.Id);
            return _mapper.Map<TaskDTO>(task);
        }
    }
}
