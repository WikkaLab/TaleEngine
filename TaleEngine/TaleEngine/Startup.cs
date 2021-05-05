using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data;
using TaleEngine.Data.Contracts;
using TaleEngine.Extensions;
using TaleEngine.Helpers;

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
            services.AddCustomMVC(Configuration);

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.UseApiBehavior = false;
            });

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TaleEngine API v1",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Elena G",
                        Email = "elena.guzbla@gmail.com",
                        Url = new Uri("https://beelzenef.github.io")
                    }
                });
                config.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "TaleEngine API v2",
                    Version = "v2",
                    Contact = new OpenApiContact
                    {
                        Name = "Elena G",
                        Email = "elena.guzbla@gmail.com",
                        Url = new Uri("https://beelzenef.github.io")
                    }
                });
            });

            services.AddDbContext<DatabaseContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<IDatabaseContext, DatabaseContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IEventDomainService, EventDomainService>();
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IActivityTypeService, ActivityTypeService>();
            services.AddTransient<IActivityTypeDomainService, ActivityTypeDomainService>();
            services.AddTransient<IActivityDomainService, ActivityDomainService>();

            if (Configuration.GetValue<bool>("UseMockData"))
            {
                services.AddTransient<ITimeSlotService, TimeSlotServiceMock>();
            }
            else
            {
                services.AddTransient<ITimeSlotService, TimeSlotService>();
            }

            services.AddTransient<ITimeSlotDomainService, TimeSlotDomainService>();
            services.AddTransient<IEditionService, EditionService>();
            services.AddTransient<IEditionDomainService, EditionDomainService>();
            services.AddTransient<IActivityStatusService, ActivityStatusService>();
            services.AddTransient<IActivityStatusDomainService, ActivityStatusDomainService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IRoleDomainService, RoleDomainService>();

            services.AddControllers(options =>
            {
                options.Conventions.Add(new GroupingByNamespaceConvention());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}