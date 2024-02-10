
using SiteSights.Tracking.Models;

namespace SiteSights.Tracking.Contracts;

/// <summary>
/// Used for dependency injection
/// </summary>
public interface ISiteSightsTracking {

    /// <summary>
    /// Send page view to sitesights.io.
    /// </summary>
    /// <param name="pageView">Information of the page view.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/>.</param>
    /// <returns>Api Response</returns>
    public Task<SiteSightsApiResponse?> PageView(SiteSightsPageView pageView, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send event to sitesights.io.
    /// </summary>
    /// <param name="event">Information of the event.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/>.</param>
    /// <returns>Api Response</returns>
    public Task<SiteSightsApiResponse?> Event(SiteSightsEvent @event, CancellationToken cancellationToken = default);

}
