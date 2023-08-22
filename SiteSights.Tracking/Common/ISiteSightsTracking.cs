
namespace SiteSights.Tracking.Common;

/// <summary>
/// Used for dependency injection
/// </summary>
public interface ISiteSightsTracking {

    /// <summary>
    /// Send page view to sitesights.io
    /// </summary>
    /// <param name="pageView">Information of the page view</param>
    /// <returns>Api Response</returns>
    public Task<SiteSightsApiResponse> PageView(SiteSightsPageView pageView);

    /// <summary>
    /// Send event to sitesights.io
    /// </summary>
    /// <param name="evt">Information of the event</param>
    /// <returns>Api Response</returns>
    public Task<SiteSightsApiResponse> Event(SiteSightsEvent evt);

}
