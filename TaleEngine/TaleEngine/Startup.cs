using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Services;
using TaleEngine.Bussiness.Contracts;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Repositories;

namespace TaleEngine
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DatabaseContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IDatabaseContext, DatabaseContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IEventDomainService, EventDomainService>();
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IActivityDomainService, ActivityDomainService>();

            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddTransient<IActivityStatusRepository, ActivityStatusRepository>();
            services.AddTransient<IActivityTypeRepository, ActivityTypeRepository>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();

            builder.Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
