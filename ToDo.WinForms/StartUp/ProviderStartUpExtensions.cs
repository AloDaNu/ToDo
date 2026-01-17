using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeProvider = ToDo.Application.Providers.TimeProvider;

using ToDo.Application.Abstractions.Providers;

namespace ToDo.WinForms.StartUp
{
    internal static class ProviderStartUpExtensions
    {
        public static IServiceCollection AddProviders(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.AddSingleton<ITimeProvider, TimeProvider>();
        }
    }
}
