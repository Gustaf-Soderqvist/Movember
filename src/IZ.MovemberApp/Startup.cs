using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Data.Entity;
using IZ.MovemberApp.Models;
using IZ.MovemberApp.Models.SampleData;
using IZ.MovemberApp.Repository;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Logging;

namespace IZ.MovemberApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.
            var builder = new ConfigurationBuilder()
               .SetBasePath(appEnv.ApplicationBasePath)
               .AddJsonFile("config.json")
               .AddEnvironmentVariables()
               .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["Data:DefaultConnection:ConnectionString"];
            services.AddMvc();
            services.AddScoped<IPostRebo, PostRebo>();
            services.AddScoped<IUserRepo, UserRepo>();
            // Register Entity Framework
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<IzMovemberContext>(options =>
                {
                    options.UseSqlServer(connection);
                });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            // Add the console logger.
            loggerfactory.AddConsole(minLevel: LogLevel.Warning);

            app.UseIISPlatformHandler();
            //app.UseIdentity();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseExceptionHandler("/Home/Error");
            app.UseMvc();

            //Add sample Data
            SampleData.Initialize(app.ApplicationServices);
        }
    }
}
