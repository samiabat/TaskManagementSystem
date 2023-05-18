using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Users.DTOs
{
    public class UpdateUserDTO: CommenDTO, IUserDto
    {
        public int Id { get; set; }

    }
}
