using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderDelayAnnouncement.Domain.Contracts;
using OrderDelayAnnouncement.Infrastructure.Persistance;
using OrderDelayAnnouncement.Infrastructure.Persistance.Repositories;
using OrderDelayAnnouncement.Infrastructure.ThirdParty;
using Polly;
using Polly.Extensions.Http;

namespace OrderDelayAnnouncement.Infrastructure
{
    public static class DependencyResolver
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services,
               IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDelayReportRepository, DelayReportRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITripEstimateService, TripEstimateService>();

            services.AddHttpClient("estimateService", client =>
            {
                client.BaseAddress = new Uri(configuration["EstimateUrl"]);
            })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());

            services.AddDbContext<OMSContext>(opts =>
                   opts.UseSqlServer(configuration.GetConnectionString("OMS")));

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                
                .HandleTransientHttpError()                
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)                
                .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                ;
        }

    }


}