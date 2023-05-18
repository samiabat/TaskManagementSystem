using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Persistence.Repositories;
using TaskManagment.Application.Contracts.Persistence;

namespace TaskManagement.Persistence
{
    public static class PersistenceServiceRegisteration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementDBContext>(options => options.UseNpgsql(
                configuration.GetConnectionString("TaskManagementConnectionString")
                ));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositiory<>));
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChecklistRepository, ChecklistRepository>();
            return services;
        }
    }
}
