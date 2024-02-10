using System.Net.Mime;
using System.Text.Json;
using Microsoft.Extensions.Options;
using SiteSights.Tracking.Constants;
using SiteSights.Tracking.Contracts;
using SiteSights.Tracking.Exceptions;
using SiteSights.Tracking.Models;
using SiteSights.Tracking.Options;
using SiteSights.Tracking.Serialization;

namespace SiteSights.Tracking.Common;

/// <summary>
/// The main class that handles all of the tracking calls.
/// It uses HttpClient with settings that allow you to keep objects of this class alive for the entirety of your programs/backends lifespan.
/// You should keep instances of this class alive for the entirety of your program.
/// </summary>
public sealed class SiteSightsTracking : IDisposable, ISiteSightsTracking
{
    /// <summary>
    /// Injected HttpClient instance. Will usually be provided by the HttpClientFactory.
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Options used for tracking sending
    /// </summary>
    private readonly SiteSightsTrackingOptions _options;

    /// <summary>
    /// Page view absolute url
    /// </summary>
    private readonly string _pageViewUrl;

    /// <summary>
    /// Event absolute url
    /// </summary>
    private readonly string _eventUrl;

    /// <summary>
    /// Instantiate tracking class, objects of this class should be alive for the entirety of your programs/backends lifespan, 
    /// because of the internal use of a HttpClient per instance.
    /// </summary>
    /// <param name="options">Required options</param>
    /// <param name="httpClient">The</param>
    public SiteSightsTracking(IOptions<SiteSightsTrackingOptions> options, HttpClient httpClient)
    {
        _options = options.Value;
        _httpClient = httpClient;
        
        _options.Url = _options.Url?.TrimEnd('/') ?? SiteSightsConstants.DefaultSiteSightsUrl;
        
        ValidateOptions();
        
        _pageViewUrl = _options.Url + SiteSightsConstants.RelativePageViewPath;
        _eventUrl = _options.Url + SiteSightsConstants.RelativeEventPath;
    }

    /// <summary>
    /// Send page view to sitesights.io
    /// </summary>
    /// <param name="pageView">Information of the page view</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/>.</param>
    /// <returns>Api Response</returns>
    public async Task<SiteSightsApiResponse?> PageView(SiteSightsPageView pageView, CancellationToken cancellationToken = default)
    {
        return await PostJson<SiteSightsPageView, SiteSightsApiResponse>(
            _pageViewUrl, pageView, cancellationToken);
    }

    /// <summary>
    /// Send event to sitesights.io
    /// </summary>
    /// <param name="event">Information of the event.</param>
    /// /// <param name="cancellationToken">An optional <see cref="CancellationToken"/>.</param>
    /// <returns>Api Response</returns>
    public async Task<SiteSightsApiResponse?> Event(SiteSightsEvent @event, CancellationToken cancellationToken = default)
    {
        return await PostJson<SiteSightsEvent, SiteSightsApiResponse>(
            _eventUrl, @event, cancellationToken);
    }

    private async Task<TResponse?> PostJson<TRequest, TResponse>(string url, TRequest json, CancellationToken cancellationToken)
    {
        var jsonRaw = JsonSerializer.Serialize(json, SiteSightsRequestJsonSerializerContext.Default.Options);

        using var request = new HttpRequestMessage(HttpMethod.Post, url);

        using var content = new StringContent(jsonRaw, Encoding.UTF8, MediaTypeNames.Application.Json);

        request.Content = content;
        request.Headers.TryAddWithoutValidation("Authorization", _options.ApiKey);

        var response = await _httpClient.SendAsync(request, cancellationToken);

        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(responseContent)) return default;
        var responseEntity = JsonSerializer.Deserialize<TResponse>(responseContent,
            SiteSightsResponseJsonSerializerContext.Default.Options);

        return responseEntity;
    }

    /// <summary>
    /// Validate the tracking options
    /// </summary>
    private void ValidateOptions()
    {
        // Check for validity of URL
        if (!Uri.TryCreate(_options.Url, UriKind.Absolute, out var uri)
            || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            throw new SiteSightsUrlInvalidException(_options.Url);
        }

        if (string.IsNullOrWhiteSpace(_options.ApiKey))
        {
            throw new SiteSightsApiKeyInvalidException(_options.ApiKey);
        }
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}