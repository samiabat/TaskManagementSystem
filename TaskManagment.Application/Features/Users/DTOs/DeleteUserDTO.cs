﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Users.DTOs
{
    public class DeleteUserDTO: IUserDto
    {
        public int Id { get; set; }
    }
}
