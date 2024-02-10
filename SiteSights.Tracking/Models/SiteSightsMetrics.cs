
namespace SiteSights.Tracking.Models;

/// <summary>
/// Client Information
/// </summary>
public sealed record ClientMetrics {

    public required BrowserMetric Browser { get; set; }

    public required SessionMetric Identify { get; set; }

    public required LanguageMetric Language { get; set; }

    public required LocationMetric Location { get; set; }

    public required PageMetric Page { get; set; }

    public required ReferrerMetric Referrer { get; set; }

    public required ScreenMetric Screen { get; set; }

}

/// <summary>
/// Location Information
/// </summary>
public sealed record LocationMetric {

    /// <summary>
    /// Optional ISO 3166-1 Alpha-2 code
    /// </summary>
    public string? CountryCode { get; set; }

    /// <summary>
    /// Optional AF, NA, OC, AN, AS, EU, SA
    /// </summary>
    public string? ContinentCode { get; set; }

    /// <summary>
    /// Optional City Name
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Optional Region Name
    /// </summary>
    public string? Region { get; set; }

    /// <summary>
    /// Optional Region Code
    /// </summary>
    public string? RegionCode { get; set; }

    /// <summary>
    /// Optional Postal Code
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// Optional Timezone
    /// </summary>
    public string? Timezone { get; set; }

}

/// <summary>
/// Browser Information
/// </summary>
public sealed record BrowserMetric {

    /// <summary>
    /// IP Address
    /// </summary>
    public required string IP { get; set; }

    /// <summary>
    /// UserAgent from the visitor's browser
    /// </summary>
    public string UserAgent { get; set; } = string.Empty;

}

/// <summary>
/// Session Information
/// </summary>
public sealed record SessionMetric {

    /// <summary>
    /// Optional ClientId - see https://docs.sitesights.io/info/client-id
    /// </summary>
    public string? ClientId { get; set; }

}

/// <summary>
/// Language Information
/// </summary>
public sealed record LanguageMetric {

    /// <summary>
    /// ISO 639-1 codes
    /// </summary>
    public required string Code { get; set; }

}

/// <summary>
/// Page information
/// </summary>
public sealed record PageMetric {

    /// <summary>
    /// Absolute url - ex: https://app.sitesights.io/websites
    /// </summary>
    public required string Absolute { get; set; }

}

/// <summary>
/// Referrer information
/// </summary>
public sealed record ReferrerMetric {

    /// <summary>
    /// Absolute url - ex: https://app.sitesights.io/websites
    /// </summary>
    public required string Absolute { get; set; }

}

/// <summary>
/// Screen information
/// </summary>
public sealed record ScreenMetric {

    /// <summary>
    /// In pixels
    /// </summary>
    public required double Width { get; set; }

    /// <summary>
    /// In pixels
    /// </summary>
    public required double Height { get; set; }

}