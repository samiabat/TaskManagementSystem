using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagemnt.Domain;
using TaskManagment.Application.Features.Tasks.DTO;

namespace TaskManagement.Application.Features.Tasks.DTO
{
    public class CreateTaskDTO: CommenDTO, ITaskDTO
    {
        public int Id { get; set; }
        public User Owner { get; set; }
    }
}
