using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Users.DTOs;

namespace TaskManagement.Application.Features.Users.Requests.Queries
{

    public class GetUserDetailQuery: IRequest<UserDTO>
    {
        public int Id  { get; set; }
    }
}
