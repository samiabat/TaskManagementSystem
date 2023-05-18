using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Application.Features.Checklists.DTOs;

namespace TaskManagement.Application.Features.Checklists.DTOs
{
    public class DeleteChecklistDto: IChecklistDTO
    {
        public int Id { get; set; }
    }
}
