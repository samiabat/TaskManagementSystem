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
    public class GetChecklistListQueryHandler : IRequestHandler<GetChecklistListQuery, List<ChecklistDTO>>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public GetChecklistListQueryHandler(IChecklistRepository checklistRepository, IMapper mapper)
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }

        public async Task<List<ChecklistDTO>> Handle(GetChecklistListQuery request, CancellationToken cancellationToken)
        {
            var checklists = await _checklistRepository.GetAll();
            return _mapper.Map<List<ChecklistDTO>>(checklists);
        }
    }
}
