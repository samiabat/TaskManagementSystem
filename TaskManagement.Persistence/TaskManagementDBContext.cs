using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagemnt.Domain;
using TaskManagemnt.Domain.Common;

namespace TaskManagement.Persistence
{
    public class TaskManagementDBContext: DbContext
    {
        public TaskManagementDBContext(DbContextOptions<TaskManagementDBContext> options): base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagementDBContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<_Task>())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.StartDate = DateTime.Now;
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<_Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Checklist> Checklists { get; set; }

    }
}
