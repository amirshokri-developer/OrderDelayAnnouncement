using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using OrderDelayAnnouncement.Domain.Settings;

namespace OrderDelayAnnouncement.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureAPI(this IServiceCollection services , 
            IConfiguration configuration)
        {
            services.Configure<AppSetting>(configuration.GetSection("AppSetting"));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddEndpointsApiExplorer();
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });


            services.AddSwaggerGen(configs =>
            {
                configs.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Delay Announcement", Version = "v1" });
            });

            return services;
        }

    }
}
