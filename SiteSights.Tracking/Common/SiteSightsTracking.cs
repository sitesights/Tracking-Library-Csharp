
using Newtonsoft.Json;

namespace SiteSights.Tracking.Common;

/// <summary>
/// The main class that handles all of the tracking calls.
/// It uses HttpClient with settings that allow you to keep objects of this class alive for the entirety of your programs/backends lifespan.
/// You should keep instances of this class alive for the entirety of your program.
/// </summary>
public sealed class SiteSightsTracking : IDisposable {

    private const string RELATIVE_PAGE_VIEW = "/api/page-view";

    private const string RELATIVE_EVENT = "/api/event-view";

    /// <summary>
    /// Default http handler to use, taking dns refresh into account
    /// </summary>
    private static SocketsHttpHandler DefaultHttpHandler => new() {
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
    /// Page view absolute url
    /// </summary>
    private string PageViewUrl { get; set; }

    /// <summary>
    /// Event absolute url
    /// </summary>
    private string EventUrl { get; set; }

    /// <summary>
    /// Instantiate tracking class, objects of this class should be alive for the entirety of your programs/backends lifespan, 
    /// because of the internal use of a HttpClient per instance.
    /// </summary>
    /// <param name="options">Required options</param>
    public SiteSightsTracking(SiteSightsTrackingOptions options) {

        Options = options;
        ValidateOptions();

        Client = new HttpClient(Options.HttpHandler);
        Options.Url = Options.Url.TrimEnd('/');

        PageViewUrl = Options.Url + RELATIVE_PAGE_VIEW;
        EventUrl = Options.Url + RELATIVE_EVENT;

    }

    /// <summary>
    /// Send page view to sitesights.io
    /// </summary>
    /// <param name="pageView">Information of the page view</param>
    /// <returns>Api Response</returns>
    public async Task<SiteSightsApiResponse> PageView(SiteSightsPageView pageView) {

        return await PostJson<SiteSightsPageView, SiteSightsApiResponse>(
            PageViewUrl, pageView);

    }

    /// <summary>
    /// Send event to sitesights.io
    /// </summary>
    /// <param name="evt">Information of the event</param>
    /// <returns>Api Response</returns>
    public async Task<SiteSightsApiResponse> Event(SiteSightsEvent evt) {

        return await PostJson<SiteSightsEvent, SiteSightsApiResponse>(
            EventUrl, evt);

    }

    private async Task<E> PostJson<T, E>(string url, T json) {

        string jsonRaw = JsonConvert.SerializeObject(json);

        using var request = new HttpRequestMessage(HttpMethod.Post, url);
        using var content = new StringContent(jsonRaw, Encoding.UTF8, "application/json");

        request.Content = content;
        request.Headers.TryAddWithoutValidation("Authorization", Options.ApiKey);

        var response = await Client.SendAsync(request);

        if(response.Content != null) {

            var respStr = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<E>(respStr);

        }

        return default;

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

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose() {
        
        Client?.Dispose();

    }

}
