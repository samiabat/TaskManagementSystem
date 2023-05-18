using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Tasks.DTO;
using TaskManagement.Application.Features.Tasks.Requests.Commands;
using TaskManagment.Application.Contracts.Persistence;

namespace TaskManagement.Application.Features.Tasks.Handlers.Commands
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.Get(request.taskDTO.Id);
            _mapper.Map(request.taskDTO, task);
            await _taskRepository.Update(task);
            return Unit.Value;
        }
    }
}
