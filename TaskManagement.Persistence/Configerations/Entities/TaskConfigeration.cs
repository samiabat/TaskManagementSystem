using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagemnt.Domain;

namespace TaskManagement.Persistence.Configerations.Entities
{
    public class TaskConfigeration : IEntityTypeConfiguration<_Task>
    {
        public void Configure(EntityTypeBuilder<_Task> builder)
        {
            //
        }
    }
}
