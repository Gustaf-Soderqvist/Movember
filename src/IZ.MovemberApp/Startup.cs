using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Data.Entity;
using IZ.MovemberApp.Models;
using IZ.MovemberApp.Repository;
using Microsoft.Dnx.Runtime;

namespace IZ.MovemberApp
{
    public class Startup
    {
        public Startup(IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.
            var builder = new ConfigurationBuilder()
               .SetBasePath(appEnv.ApplicationBasePath)
               .AddJsonFile("config.json")
               .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["Data:DefaultConnection:ConnectionString"];
            services.AddMvc();
            services.AddScoped<IPostRebo, PostRebo>();
            // Register Entity Framework
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<IzMovemberContext>(options =>
                {
                    options.UseSqlServer(connection);
                });

        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseIISPlatformHandler();
            //app.UseIdentity();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseExceptionHandler("/Home/Error");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //Add sample Data
            SampleData.Initialize(app.ApplicationServices);
        }
    }
}
