using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagment.Application.Features.Tasks.DTO;

namespace TaskManagement.Application.Features.Tasks.DTO
{
    public class DeleteTaskDTO: ITaskDTO
    {
        public int Id { get; set; }
    }
}
