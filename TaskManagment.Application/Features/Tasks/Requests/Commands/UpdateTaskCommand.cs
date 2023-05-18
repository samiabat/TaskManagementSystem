using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Tasks.DTO;

namespace TaskManagement.Application.Features.Tasks.Requests.Commands
{
    public class UpdateTaskCommand: IRequest<Unit>
    {
        public UpdateTaskDTO taskDTO { get; set; }
    }
}
