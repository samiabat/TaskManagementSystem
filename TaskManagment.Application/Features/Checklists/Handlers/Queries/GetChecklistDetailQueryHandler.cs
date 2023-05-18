using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Checklists.Requests.Queries;
using TaskManagment.Application.Contracts.Persistence;
using TaskManagment.Application.Features.Checklists.DTOs;

namespace TaskManagement.Application.Features.Checklists.Handlers.Queries
{
    public class GetChecklistDetailQueryHandler : IRequestHandler<GetChecklistDetailQuery, ChecklistDTO>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public GetChecklistDetailQueryHandler(IChecklistRepository checklistRepository, IMapper mapper)
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }
        public async Task<ChecklistDTO> Handle(GetChecklistDetailQuery request, CancellationToken cancellationToken)
        {
            var checklist = await _checklistRepository.Get(request.Id);
            if (checklist == null)
            {
                throw new Exception("Checklist not found!");
            }
            return _mapper.Map<ChecklistDTO>(checklist);
        }
    }
}
