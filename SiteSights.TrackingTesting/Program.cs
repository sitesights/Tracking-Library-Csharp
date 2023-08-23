
using SiteSights.Tracking.Common;

var tracking = new SiteSightsTracking(new SiteSightsTrackingOptions() {
    ApiKey = "",
});

await tracking.PageView(new SiteSightsPageView() {
    Metrics = new ClientMetrics() {

    }
});