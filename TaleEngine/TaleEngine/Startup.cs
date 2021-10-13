using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Services;
using TaleEngine.Application.Services.Backoffice;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Bussiness.DomainServices.Backoffice;
using TaleEngine.Data;
using TaleEngine.Data.Contracts;
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
                services.AddTransient<IEventService, EventServiceMock>();
                services.AddTransient<ITimeSlotService, TimeSlotServiceMock>();
            }
            else
            {
                services.AddTransient<IEventService, EventService>();
                services.AddTransient<IEventDomainService, EventDomainService>();
                services.AddTransient<IActivityService, ActivityService>();
                services.AddTransient<IActivityTypeService, ActivityTypeService>();
                services.AddTransient<IActivityTypeDomainService, ActivityTypeDomainService>();
                services.AddTransient<IActivityDomainService, ActivityDomainService>();
                services.AddTransient<ITimeSlotService, TimeSlotService>();
                services.AddTransient<ITimeSlotDomainService, TimeSlotDomainService>();
                services.AddTransient<IEditionService, EditionService>();
                services.AddTransient<IEditionDomainService, EditionDomainService>();
                services.AddTransient<IActivityStatusService, ActivityStatusService>();
                services.AddTransient<IActivityStatusDomainService, ActivityStatusDomainService>();
                services.AddTransient<IRoleService, RoleService>();
                services.AddTransient<IRoleDomainService, RoleDomainService>();
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<IUserDomainService, UserDomainService>();
                services.AddTransient<IUserStatusDomainService, UserStatusDomainService>();
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