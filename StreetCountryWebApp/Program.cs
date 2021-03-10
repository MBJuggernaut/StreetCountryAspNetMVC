using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StreetCountryWebApp.Models;

namespace StreetCountryWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {                
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<DBContext>();
                    Seeder seeder = new Seeder(context);
                    seeder.Seed();
                }
                catch
                {
                    //log it
                    throw;
                }                
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
