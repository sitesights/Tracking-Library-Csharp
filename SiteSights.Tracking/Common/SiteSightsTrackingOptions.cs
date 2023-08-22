
namespace SiteSights.Tracking.Common;

/// <summary>
/// Representing instantiate options for SiteSightsTracking class.
/// </summary>
public sealed class SiteSightsTrackingOptions {

    /// <summary>
    /// Default base url to make the REST API calls to
    /// </summary>
    public const string DEFAULT_SITESIGHTS_URL = "https://app.sitesights.io";

    /// <summary>
    /// Will be found on your sitesights.io dashboard under websites > edit website, do not share this anywhere in the frontend.
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Currently not needed, due to only sitesights.io being available
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Overwrite default http handler if needed
    /// </summary>
    public SocketsHttpHandler HttpHandler { get; set; }

}
