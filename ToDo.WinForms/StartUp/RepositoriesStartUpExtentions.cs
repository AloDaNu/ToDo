using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Abstractions.Repositories;

using ToDo.Application.Features;
using ToDo.Persistence.Contexts;
using ToDo.Persistence.Repositories;

namespace ToDo.WinForms.StartUp
{
    internal static class RepositoriesStartUpExtentions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.AddScoped<ITaskRepository, TaskRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
                (configuration.GetConnectionString(nameof(ApplicationDbContext))));
        }
    }
}
