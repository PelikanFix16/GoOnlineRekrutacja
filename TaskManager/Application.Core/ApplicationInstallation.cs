using Microsoft.Extensions.DependencyInjection;
using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddTaskApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ITaskService,TaskService>();
            return services;

        }
    }
}
