using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Checklists.Requests.Commands;
using TaskManagemnt.Domain;
using TaskManagment.Application.Contracts.Persistence;

namespace TaskManagement.Application.Features.Checklists.Handlers.Commands
{
    public class CreateChecklistCommandHandler: IRequestHandler<CreateCheckListCommand, Unit>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public CreateChecklistCommandHandler(IChecklistRepository checklistRepository, IMapper mapper)
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCheckListCommand request, CancellationToken cancellationToken)
        {
            var checklist = _mapper.Map<Checklist>(request.checklistDTO);
            await _checklistRepository.Add(checklist);
            return Unit.Value;
        }
    }
}
