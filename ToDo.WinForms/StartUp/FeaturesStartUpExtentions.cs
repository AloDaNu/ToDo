using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Abstractions.Services;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Features;
using ToDo.Application.Services;

namespace ToDo.WinForms.StartUp
{
    internal static class FeaturesStartUpExtentions
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.AddScoped<ITaskCompleteFeature, TaskCompleteFeature>()
                .AddScoped<ITaskCreateFeature, TaskCreateFeature>()
                .AddScoped<ITaskDeleteFeature, TaskDeleteFeature>()
                .AddScoped<ITaskGetFeature, TaskGetFeature>()
                .AddScoped<ITaskUpdateFeature, TaskUpdateFeature>();
        }
    }
}
