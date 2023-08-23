
namespace SiteSights.Tracking.Common;

/// <summary>
/// Client Information
/// </summary>
public sealed class ClientMetrics {

    public BrowserMetric Browser { get; set; }

    public SessionMetric Identify { get; set; }

    public LanguageMetric Language { get; set; }

    public LocationMetric Location { get; set; }

    public PageMetric Page { get; set; }

    public ReferrerMetric Referrer { get; set; }

    public ScreenMetric Screen { get; set; }

}

/// <summary>
/// Location Information
/// </summary>
public sealed class LocationMetric {

    /// <summary>
    /// Optional ISO 3166-1 Alpha-2 code
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// Optional AF, NA, OC, AN, AS, EU, SA
    /// </summary>
    public string ContinentCode { get; set; }

    /// <summary>
    /// Optional City Name
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Optional Region Name
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Optional Region Code
    /// </summary>
    public string RegionCode { get; set; }

    /// <summary>
    /// Optional Postal Code
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// Optional Timezone
    /// </summary>
    public string Timezone { get; set; }

}

/// <summary>
/// Browser Information
/// </summary>
public sealed class BrowserMetric {

    /// <summary>
    /// IP Address
    /// </summary>
    public string IP { get; set; }

    /// <summary>
    /// UserAgent from the visitor's browser
    /// </summary>
    public string UserAgent { get; set; }

}

/// <summary>
/// Session Information
/// </summary>
public sealed class SessionMetric {

    /// <summary>
    /// Optional ClientId - see https://docs.sitesights.io/info/client-id
    /// </summary>
    public string ClientId { get; set; }

}

/// <summary>
/// Language Information
/// </summary>
public sealed class LanguageMetric {

    /// <summary>
    /// ISO 639-1 codes
    /// </summary>
    public string Code { get; set; }

}

/// <summary>
/// Page information
/// </summary>
public sealed class PageMetric {

    /// <summary>
    /// Absolute url - ex: https://app.sitesights.io/websites
    /// </summary>
    public string Absolute { get; set; }

}

/// <summary>
/// Referrer information
/// </summary>
public sealed class ReferrerMetric {

    /// <summary>
    /// Absolute url - ex: https://app.sitesights.io/websites
    /// </summary>
    public string Absolute { get; set; }

}

/// <summary>
/// Screen information
/// </summary>
public sealed class ScreenMetric {

    /// <summary>
    /// In pixels
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// In pixels
    /// </summary>
    public double Height { get; set; }

}