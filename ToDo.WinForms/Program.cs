using ToDo.WinForms.Forms;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ToDo.WinForms.StartUp;

namespace ToDo.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true).Build();

            IServiceProvider services = new ServiceCollection()
               .AddApplication(configuration)
               .BuildApplication();

            

            
            System.Windows.Forms.Application.Run(services.GetRequiredService<TaskForm>());
        }
    }
}