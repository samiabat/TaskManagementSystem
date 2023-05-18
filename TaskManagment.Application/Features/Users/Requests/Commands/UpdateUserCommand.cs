using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Users.DTOs;

namespace TaskManagement.Application.Features.Users.Requests.Commands
{
    public class UpdateUserCommand: IRequest<Unit>
    {
        public UpdateUserDTO userDTO  { get; set; }
    }
}
