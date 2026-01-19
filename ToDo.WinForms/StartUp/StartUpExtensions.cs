using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WinForms.StartUp
{
    internal static class StartUpExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddFactory(configuration)
                .AddProviders(configuration)
                .AddFeatures(configuration)
                .AddRepository(configuration)
                .AddServices(configuration)
                .AddViews(configuration);
        }

        public static IServiceProvider BuildApplication(this IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }
    }
}
