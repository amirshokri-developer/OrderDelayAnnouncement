using Microsoft.Extensions.DependencyInjection;
using OrderDelayAnnouncement.Application.Handlers;
using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application
{
    public static class DependencyResolver
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddSingleton<IQueueManager, QueueManager>();
            services.AddScoped<IEstimateStrategyFactory , EstimateStrategyFactory>();
            services.AddScoped<NotAssignedTripStrategy>();
            services.AddScoped<AssignedTripStrategy>();
            
            services.AddScoped<Func<TripAssignedStatus, IEstimateStrategy>>(provider => key =>
            {
                return key switch
                {
                    TripAssignedStatus.ASSIGNED => provider.GetService<AssignedTripStrategy>(),
                    TripAssignedStatus.NOT_ASSIGNED => provider.GetService<NotAssignedTripStrategy>(),                    
                    _ => null,
                };
            });


            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ReportDelayCommandHandler).Assembly);                                
            });




            return services;
        }
          
    }
}
