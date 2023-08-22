
namespace SiteSights.Tracking.Common;

/// <summary>
/// The main class that handles all of the tracking calls.
/// It uses HttpClient with settings that allow you to keep objects of this class alive for the entirety of your programs/backends lifespan.
/// </summary>
public sealed class SiteSightsTracking {

    /// <summary>
    /// Default http handler to use, taking dns refresh into account
    /// </summary>
    private static SocketsHttpHandler DefaultHttpHandler = new SocketsHttpHandler() {
        PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1),
        PooledConnectionLifetime = TimeSpan.FromMinutes(5) // dns refresh
    };

    /// <summary>
    /// Options used for tracking sending
    /// </summary>
    private SiteSightsTrackingOptions Options { get; set; }

    /// <summary>
    /// Http Client used to send the requests to sitesights.io
    /// </summary>
    private HttpClient Client { get; set; }

    /// <summary>
    /// Instantiate tracking class, objects of this class can be alive for the entirety of your programs/backends lifespan.
    /// </summary>
    /// <param name="options">Required options</param>
    public SiteSightsTracking(SiteSightsTrackingOptions options) {

        Options = options;
        ValidateOptions();

        Client = new HttpClient(Options.HttpHandler);

    }

    /// <summary>
    /// Send page view to sitesights.io
    /// </summary>
    /// <param name="pageView">Information of the page view</param>
    /// <returns>Api Response</returns>
    public async Task<SiteSightsApiResponse> PageView(SiteSightsPageView pageView) {

        return null;

    }

    /// <summary>
    /// Send event to sitesights.io
    /// </summary>
    /// <param name="evt">Information of the event</param>
    /// <returns>Api Response</returns>
    public async Task<SiteSightsApiResponse> Event(SiteSightsEvent evt) {

        return null;

    }

    /// <summary>
    /// Validate the tracking options
    /// </summary>
    private void ValidateOptions() {

        var opts = Options;
        Options = new SiteSightsTrackingOptions {
            HttpHandler = opts.HttpHandler ?? DefaultHttpHandler,
            ApiKey = opts.ApiKey,
            Url = opts.Url ?? SiteSightsTrackingOptions.DEFAULT_SITESIGHTS_URL
        };

        // check valid url
        if(!Uri.TryCreate(Options.Url, UriKind.Absolute, out var uri)
            || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)) {
            throw new ArgumentException($"SiteSights Options Url is not a valid Url: {Options.Url}");
        }

        if(Options.ApiKey == null) {
            throw new ArgumentException("SiteSights Options ApiKey is null.");
        }

    }

}
