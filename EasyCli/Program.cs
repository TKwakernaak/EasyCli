using System;
using System.Threading.Tasks;
using EasyCli.Menu;
using EasyCli.Menu.Actions;
using EasyCli.SampleData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyCli
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting application in CLI mode");
                Console.WriteLine($"Running in environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");

                var host = CreateHostBuilder(args).Build();

                //Display a menu with choice
                await host.Services.GetService<CliMenu>()
                                   .ShowMenu()
                                   .RunAsync();

                Console.WriteLine("Process finished. Press any key to exit");
                Console.ReadKey();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Console.WriteLine("press any key to exit");
                Console.ReadKey();

                return -1;
            }
        }

        /// <summary>
        /// host builder, using, where applicable, the same registrations as the webapp project through the use of <see cref="Startup"/>
        /// </summary>
        /// <param name="args"></param>
        /// <param name="configuration"></param>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
             .ConfigureServices((_, sc) => ConfigureCliServices(sc));
             //.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>()) //reference existing startup to share di if convenient

        /// <summary>
        /// Register services that are only neccessary for the cli. Classes that implement an interface
        /// in the CLI can be registered registered automatically through assembly scanning (obviously only when running the CLI,
        /// or can be added manually
        /// </summary>
        /// <param name="services"></param>
        private static IServiceCollection ConfigureCliServices(IServiceCollection services)
        {
            services.AddTransient(typeof(CliMenu));
            services.AddTransient<ITestCommandHandler, TestCommandHandlerImpl>();
            services.AddTransient<ICliAction, SampleAction>();
            //add more here

            return services;
        }
    }
}

