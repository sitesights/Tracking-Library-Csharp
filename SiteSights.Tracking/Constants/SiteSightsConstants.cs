namespace SiteSights.Tracking.Constants;

/// <summary>
/// This class contains the constants for the SiteSightsTracking library.
/// </summary>
public static class SiteSightsConstants
{
    /// <summary>
    /// Default base url to make the REST API calls to SiteSights.
    /// </summary>
    public const string DefaultSiteSightsUrl = "https://app.sitesights.de";
    
    /// <summary>
    /// The relative path to the page view endpoint.
    /// </summary>
    internal const string RelativePageViewPath = "/api/page-view";

    /// <summary>
    /// The relative path to the event endpoint.
    /// </summary>
    internal const string RelativeEventPath = "/api/event-view";
}