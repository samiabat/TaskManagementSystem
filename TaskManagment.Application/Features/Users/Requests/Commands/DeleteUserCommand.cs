using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Users.Requests.Commands
{
    public class DeleteUserCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
