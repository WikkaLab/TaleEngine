using Autofac;
using Autofac.Extensions.DependencyInjection;
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
using TaleEngine.AutofacModules;
using TaleEngine.Bussiness.Contracts;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data;
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

        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAll", options =>
                    options.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

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

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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

            services.AddControllers(options =>
            {
                options.Conventions.Add(new GroupingByNamespaceConvention());
            });

            //configure autofac

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule());

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json");
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "TaleEngine Docs";
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
                options.SwaggerEndpoint($"/swagger/v2/swagger.json", $"v2");
            });
            app.UseEndpoints(endpoints => endpoints.MapControllers());

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

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}