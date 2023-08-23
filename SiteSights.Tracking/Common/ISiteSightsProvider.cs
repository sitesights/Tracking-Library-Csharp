
namespace SiteSights.Tracking.Common;

/// <summary>
/// Sitesights Provider
/// </summary>
public interface ISiteSightsProvider {

    /// <summary>
    /// Gets the default sitesights tracking.
    /// </summary>
    /// <returns>
    /// The default sitesights tracking.
    /// </returns>
    ISiteSightsTracking Get();

    /// <summary>
    /// Gets the sitesights tracking with the given name.
    /// </summary>
    /// <param name="name">The client name.</param>
    /// <returns>
    /// The sitesights tracking with the given name.
    /// </returns>
    ISiteSightsTracking Get(string name);

}
