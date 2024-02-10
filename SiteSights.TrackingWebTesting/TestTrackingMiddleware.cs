using SiteSights.Tracking.Contracts;

namespace SiteSights.TrackingWebTesting;

public sealed class TestTrackingMiddleware {

    private readonly RequestDelegate _requestDelegate;

    private readonly ISiteSightsTracking _tracking;

    public TestTrackingMiddleware(RequestDelegate next, ISiteSightsTracking tracking) {

        _requestDelegate = next;
        _tracking = tracking;

    }

}
