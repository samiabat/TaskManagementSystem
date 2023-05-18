using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Persistence
{
    public class TaskManagementDBContextFactory: IDesignTimeDbContextFactory<TaskManagementDBContext>
    {

        public TaskManagementDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TaskManagementDBContext>();
            var connectionString = configurationRoot.GetConnectionString("TaskManagementConnectionString");
            builder.UseSqlServer(connectionString);

            return new TaskManagementDBContext(builder.Options);
        }
    }
}
