using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.EF.Repositories;
using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF
{
    public static class PersistenceEFregistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<TaskManagerContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TaskManagerConnectionString")
                    ));

            services.AddScoped<ITaskRepository, TaskRepository>();
            return services;
        }
    }

}