using CA.Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            SeedDb(host);
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration(SetupConfiguration)
             .UseStartup<Startup>()
             .Build();

        private static void SeedDb(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<DataSeeder>();
                seeder.SeedAsync().Wait();
            }
        }

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            // Removing the default configuration options
            builder.Sources.Clear();

            builder.AddJsonFile("appsettings.json", false, true)
                   .AddEnvironmentVariables();
        }
    }
}
