using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Application.Features.Checklists.DTOs;

namespace TaskManagement.Application.Features.Checklists.Requests.Queries
{
    public class GetChecklistListQuery: IRequest<List<ChecklistDTO>>
    {
    }
}
