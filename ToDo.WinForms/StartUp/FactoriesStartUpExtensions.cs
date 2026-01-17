using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Abstractions.Providers;
using TaskFactory = ToDo.Application.Factories.TaskFactory;

using ToDo.Application.Abstractions.Factories;

namespace ToDo.WinForms.StartUp
{
    internal static class FactoriesStartUpExtensions
    {
        public static IServiceCollection AddFactory(this IServiceCollection services, 
            IConfiguration configuration)
        {
            return services.AddSingleton<ITaskFactory, TaskFactory>();
        }
    }
}
