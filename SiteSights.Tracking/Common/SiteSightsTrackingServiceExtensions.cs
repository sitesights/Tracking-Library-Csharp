
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SiteSights.Tracking.Common;

public static class SiteSightsTrackingServiceExtensions {

    public const string DEFAULT_SERVICE_NAME = "sitesights-default-service-name";

    public static IServiceCollection AddSiteSightsTracking(this IServiceCollection services, Action<SiteSightsTrackingOptions> configure) {

        return services.AddSiteSightsTracking(DEFAULT_SERVICE_NAME, configure);

    }

    public static IServiceCollection AddSiteSightsTracking(this IServiceCollection services, string name, Action<SiteSightsTrackingOptions> configure) {

        services.Configure(name, configure);
        services.TryAddSingleton<ISiteSightsProvider, SiteSightsProvider>();

        services.TryAddSingleton(c => c.GetRequiredService<ISiteSightsProvider>().Get());

        return services;

    }

}
