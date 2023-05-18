using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagemnt.Domain;

namespace TaskManagment.Application.Features.Tasks.DTO
{
    public class TaskDTO: CommonDTO, ITaskDTO
    {
        public int Id { get; set; }
        public User Owner { get; set; }
    }
}
