using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace dotnetcore
{
    /// <summary>
    /// Program Class
    /// </summary>
    class Program
    {
        private static IConfiguration configuration;
        public static IConfiguration GetConfiguration()
        {
            return configuration;
        }

        public static void SetConfiguration(IConfiguration value)
        {
            configuration = value;
        }
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">arguments</param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            //Setup DI
            string environment = "";
            var builder = new HostBuilder()
                .UseEnvironment(environment)
                .ConfigureAppConfiguration
                ((hostBuilderContext, config) =>
                {
                    SetConfiguration(new ConfigurationBuilder()
                   .SetBasePath(hostBuilderContext.HostingEnvironment.ContentRootPath)
                   .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables()
                   .Build());
                    config.AddConfiguration(GetConfiguration());
                })
                .ConfigureServices((builderContext, serviceCollection) =>
                {
                    serviceCollection.AddScoped<AppInsight, AppInsight>();
                })
                .UseConsoleLifetime();

            //Setup DI
            //var serviceProvider = (new ServiceCollection())
            //    .BuildServiceProvider();
            //ApplicationInsight Sample
            Console.WriteLine("Welcome to App Insights.");
            var host = builder.Build();

            using (host)
            {
                await host.RunAsync();
            }
            var appInsight = new AppInsight(configuration);
            await appInsight.Run();
            Console.ReadLine();
        }
    }
}
