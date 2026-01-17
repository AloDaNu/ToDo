using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Abstractions.Providers;
using ToDo.Application.Abstractions.Services;
using ToDo.Application.Services;

namespace ToDo.WinForms.StartUp
{
    internal static class ServicesStartUpExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.AddScoped<ITaskCompletionService, TaskCompletionService>()
                .AddScoped<ITaskCreationService, TaskCreationService>()
                .AddScoped<ITaskQueryService, TaskQueryService>()
                .AddScoped<ITaskDeletionService, TaskDeletionService>()
                .AddScoped<ITaskUpdateService, TaskUpdateService>();
        }
    }
}
