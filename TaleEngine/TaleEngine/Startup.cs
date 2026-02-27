using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaleEngine.CQRS.Commands;
using TaleEngine.CQRS.Commands.Backoffice;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Queries;
using TaleEngine.CQRS.Queries.Backoffice;
using TaleEngine.Data;
using TaleEngine.Data.Contracts;
using TaleEngine.Extensions;
using TaleEngine.Services;
using TaleEngine.Services.Backoffice;
using TaleEngine.Services.Contracts;

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
                .AddCustomSwagger()
                .AddCustomConfiguration(Configuration);

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                //config.UseApiBehavior = false;
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
                services.AddTransient<IActivityQueries, ActivityQueries>();
                services.AddTransient<IActivityStatusQueries, ActivityStatusQueries>();
                services.AddTransient<IActivityTypeQueries, ActivityTypeQueries>();
                services.AddTransient<IEditionQueries, EditionQueries>();
                services.AddTransient<IEventQueries, EventQueries>();
                services.AddTransient<IRoleQueries, RoleQueries>();
                services.AddTransient<ITimeSlotQueries, TimeSlotQueries>();
                services.AddTransient<IUserCommands, UserCommands>();
                services.AddTransient<IUserQueries, UserQueries>();
                services.AddTransient<IUserStatusQueries, UserStatusQueries>();
                services.AddTransient<IPermissionQueries, PermissionQueries>();
                services.AddTransient<IPermissionCommands, PermissionCommands>();
                services.AddTransient<IPermissionValueQueries, PermissionValueQueries>();
                services.AddTransient<IPermissionValueCommands, PermissionValueCommands>();
                services.AddTransient<IAssignedPermissionQueries, AssignedPermissionQueries>();
                services.AddTransient<IAssignedPermissionCommands, AssignedPermissionCommands>();

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
                services.AddTransient<IPermissionService, PermissionService>();
                services.AddTransient<IPermissionValueService, PermissionValueService>();
                services.AddTransient<IAssignedPermissionService, AssignedPermissionService>();
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
                options.SwaggerEndpoint($"/swagger/backoffice/swagger.json", $"Backoffice");
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