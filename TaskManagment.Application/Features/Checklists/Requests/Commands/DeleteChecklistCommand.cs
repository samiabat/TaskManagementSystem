using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Checklists.Requests.Commands
{
    public class DeleteChecklistCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
