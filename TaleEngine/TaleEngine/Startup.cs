using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Impl;
using TaleEngine.CQRS.Impl.Backoffice;
using TaleEngine.Data;
using TaleEngine.Data.Contracts;
using TaleEngine.DbServices.Contracts.Services;
//using TaleEngine.DbServices.Mocks;
using TaleEngine.DbServices.Services;
using TaleEngine.DbServices.Services.Backoffice;
using TaleEngine.Extensions;

namespace TaleEngine
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMVC()
                .AddCustomDbContext(Configuration)
                .AddSwaggerGen()
                .AddCustomConfiguration(Configuration);

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.UseApiBehavior = false;
            });

            services.AddDbContext<IDatabaseContext, DatabaseContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            if (Configuration.GetValue<bool>("UseCustomizationData"))
            {
                //services.AddTransient<IEventService, EventServiceMock>();
                //services.AddTransient<ITimeSlotService, TimeSlotServiceMock>();
            }
            else
            {
                // CQRS
                services.AddTransient<IActivityCommands, ActivityCommands>();
                services.AddTransient<IActivityStatusCommands, ActivityStatusCommands>();
                services.AddTransient<IActivityTypeCommands, ActivityTypeCommands>();
                services.AddTransient<IEditionCommands, EditionCommands>();
                services.AddTransient<IEventCommands, EventCommands>();
                services.AddTransient<IRoleCommands, RoleCommands>();
                services.AddTransient<ITimeSlotCommands, TimeSlotCommands>();
                services.AddTransient<IUserCommands, UserCommands>();
                services.AddTransient<IUserStatusCommands, UserStatusCommands>();

                // Services
                services.AddTransient<IActivityService, ActivityService>();
                services.AddTransient<IActivityStatusService, ActivityStatusService>();
                services.AddTransient<IActivityTypeService, ActivityTypeService>();
                services.AddTransient<IEditionService, EditionService>();
                services.AddTransient<IEventService, EventService>();
                services.AddTransient<IRoleService, RoleService>();
                services.AddTransient<ITimeSlotService, TimeSlotService>();
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<IUserStatusService, UserStatusService>();
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json");
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "TaleEngine Docs";
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
                options.SwaggerEndpoint($"/swagger/v2/swagger.json", $"v2");
            });

            app.Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
            });
        }
    }
}