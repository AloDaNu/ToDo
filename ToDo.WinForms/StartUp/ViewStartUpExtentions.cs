using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WinForms.Forms;

namespace ToDo.WinForms.StartUp
{
    internal static class ViewStartUpExtentions
    {
        public static IServiceCollection AddViews(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddScoped<AddForm>()
                .AddTransient<EditForm>()
                .AddTransient<TaskForm>();
        }
    }
}
