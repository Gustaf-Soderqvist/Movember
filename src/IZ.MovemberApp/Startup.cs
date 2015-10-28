using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Data.Entity;
using IZ.MovemberApp.Models;

namespace IZ.MovemberApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            //rabarber
            services.AddMvc();
            // Register Entity Framework
            // Register Entity Framework
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<IzMovemberContext>(
                    options => { options.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString")); });
        }

        public void Configure(IApplicationBuilder app)
        {
           //app.UseIdentity();
          
            app.UseMvc();

            //Add sample Data
            SampleData.Initialize(app.ApplicationServices);
        }
    }
}
