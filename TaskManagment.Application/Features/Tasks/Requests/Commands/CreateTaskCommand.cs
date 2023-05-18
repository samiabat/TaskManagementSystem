using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Tasks.DTO;

namespace TaskManagement.Application.Features.Tasks.Requests.Commands
{
    public class CreateTaskCommand: IRequest<Unit>
    {
        public CreateTaskDTO taskDTO { get; set; }
    }
}
