using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Features.Checklists.DTOs
{
    public class ChecklistDTO: CommonDTO, IChecklistDTO
    {
        public int Id { get; set; }
    }
}
