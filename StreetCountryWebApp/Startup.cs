using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StreetCountryWebApp.Models;
using StreetCountryWebApp.Repo;
using StreetCountryWebApp.Services;

namespace StreetCountryWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<DBContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IStreetRepository, StreetRepository>();
            services.AddScoped<IStreetService, StreetService>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();            

            app.UseDefaultFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Streets}/{action=Search}/{id?}");
            });
        }
    }
}
