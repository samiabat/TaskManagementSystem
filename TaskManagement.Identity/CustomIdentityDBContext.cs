﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Identity.Configurations;
using TaskManagement.Identity.Models;
using TaskManagemnt.Domain;

namespace TaskManagement.Identity
{
    public class CustomIdentityDBContext : IdentityDbContext<AuthUser>
    {
        public CustomIdentityDBContext(DbContextOptions<CustomIdentityDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
        

    }
}
