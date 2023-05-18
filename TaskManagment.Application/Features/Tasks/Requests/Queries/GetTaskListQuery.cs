using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Application.Features.Tasks.DTO;

namespace TaskManagement.Application.Features.Tasks.Requests.Queries
{
    public class GetTaskListQuery: IRequest<List<TaskDTO>>
    {
    }
}
