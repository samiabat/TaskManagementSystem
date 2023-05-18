using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Checklists.DTOs;
using TaskManagement.Application.Features.Checklists.Requests.Commands;
using TaskManagment.Application.Contracts.Persistence;

namespace TaskManagement.Application.Features.Checklists.Handlers.Commands
{
    public class UpdateChecklistCommandHandler : IRequestHandler<UpdateChecklistCommand, Unit>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public UpdateChecklistCommandHandler(IChecklistRepository checklistRepository, IMapper mapper)
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateChecklistCommand request, CancellationToken cancellationToken)
        {
            var checklist = await _checklistRepository.Get(request.checklistDTO.Id);
            if (checklist == null)
            {
                throw new Exception("checklist not found!");
            }
            _mapper.Map(request.checklistDTO, checklist);
            await _checklistRepository.Update(checklist);
            return Unit.Value;
        }
    }
}
