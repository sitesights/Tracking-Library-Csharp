
namespace SiteSights.Tracking.Common;

/// <summary>
/// Data object to represent page view request body
/// </summary>
public sealed class SiteSightsPageView {

    /// <summary>
    /// Metrics of visitor
    /// </summary>
    public ClientMetrics Metrics { get; set; }

}
