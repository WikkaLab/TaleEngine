using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using TaleEngine.Data;
using TaleEngine.Infrastructure.Filters;

namespace TaleEngine.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMVC(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddNewtonsoftJson();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            },
                ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
            );

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
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

            return services;
        }

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<TaleEngineSettings>(configuration);

            return services;
        }
    }
}