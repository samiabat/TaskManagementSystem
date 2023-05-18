using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Checklists.DTOs;

namespace TaskManagement.Application.Features.Checklists.Requests.Commands
{
    public class UpdateChecklistCommand: IRequest<Unit>
    {
        public UpdateChecklistDTO checklistDTO { get; set; }
    }
}
