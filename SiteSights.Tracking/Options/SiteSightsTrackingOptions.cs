namespace SiteSights.Tracking.Options;

/// <summary>
/// Representing instantiate options for SiteSightsTracking class.
/// </summary>
public sealed record SiteSightsTrackingOptions
{
    /// <summary>
    /// Will be found on your sitesights.io dashboard under websites > edit website, do not share this anywhere in the frontend.
    /// </summary>
    public required string ApiKey { get; set; }

    /// <summary>
    /// Currently not needed, due to only sitesights.io being available
    /// </summary>
    public string? Url { get; set; }
}