using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Users.DTOs;
using TaskManagment.Application.Features.Checklists.DTOs;

namespace TaskManagement.Application.Features.Checklists.DTOs
{
    public class UpdateChecklistDTO: CommenDTO, IChecklistDTO
    {
        public int Id { get; set; }
    }
}
