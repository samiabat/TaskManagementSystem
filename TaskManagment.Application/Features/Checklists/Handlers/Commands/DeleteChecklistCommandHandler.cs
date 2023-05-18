using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Checklists.Requests.Commands;
using TaskManagment.Application.Contracts.Persistence;

namespace TaskManagement.Application.Features.Checklists.Handlers.Commands
{
    public class DeleteChecklistCommandHandler : IRequestHandler<DeleteChecklistCommand, Unit>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public DeleteChecklistCommandHandler(IChecklistRepository checklistRepository, IMapper mapper)
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteChecklistCommand request, CancellationToken cancellationToken)
        {
            var checklist = await _checklistRepository.Get(request.Id);
            if (checklist == null)
            {
                throw new Exception("Not found");
            }
            await _checklistRepository.Delete(checklist);
            return Unit.Value;
        }
    }
}
