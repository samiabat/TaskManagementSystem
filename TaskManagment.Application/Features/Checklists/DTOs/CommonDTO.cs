using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagemnt.Domain;

namespace TaskManagment.Application.Features.Checklists.DTOs
{
    public class CommonDTO
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
