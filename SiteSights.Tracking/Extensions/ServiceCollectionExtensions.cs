using Microsoft.Extensions.DependencyInjection;
using SiteSights.Tracking.Contracts;

namespace SiteSights.Tracking.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the SiteSightsTracking service with the specified <see cref="ServiceLifetime"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register the services in.</param>
    /// <param name="serviceLifetime">The <see cref="ServiceLifetime"/> to use for the <see cref="SiteSightsTracking"/> instance.</param>
    /// <returns>The <see cref="IServiceCollection"/> configured with the <see cref="SiteSightsTracking"/> service.</returns>
    public static IServiceCollection AddSiteSightsTracking(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        services.AddHttpClient<ISiteSightsTracking, SiteSightsTracking>()
            .UseSocketsHttpHandler();
        
        switch (serviceLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton<ISiteSightsTracking, SiteSightsTracking>();
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped<ISiteSightsTracking, SiteSightsTracking>();
                break;
            case ServiceLifetime.Transient:
                services.AddTransient<ISiteSightsTracking, SiteSightsTracking>();
                break;
        }
        
        return services;
    }
}