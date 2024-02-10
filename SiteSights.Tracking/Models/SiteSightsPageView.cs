
namespace SiteSights.Tracking.Models;

/// <summary>
/// Data object to represent page view request body
/// </summary>
public sealed record SiteSightsPageView {

    /// <summary>
    /// Metrics of visitor
    /// </summary>
    public required ClientMetrics Metrics { get; set; }

}
