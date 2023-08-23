
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

namespace SiteSights.Tracking.Common;

public sealed class SiteSightsProvider : ISiteSightsProvider {

    private ConcurrentDictionary<string, ISiteSightsTracking> Trackings { get; set; }

    private IOptionsMonitor<SiteSightsTrackingOptions> OptionsMonitor { get; set; }

    public SiteSightsProvider(IOptionsMonitor<SiteSightsTrackingOptions> optionsMonitor) {

        OptionsMonitor = optionsMonitor;
        Trackings = new ConcurrentDictionary<string, ISiteSightsTracking>();

    }

    public ISiteSightsTracking Get() {

        return Get(SiteSightsTrackingServiceExtensions.DEFAULT_SERVICE_NAME);

    }

    public ISiteSightsTracking Get(string key) {

        return Trackings.GetOrAdd(key, (name) => {

            return new SiteSightsTracking(OptionsMonitor.Get(name));

        });

    }

}
