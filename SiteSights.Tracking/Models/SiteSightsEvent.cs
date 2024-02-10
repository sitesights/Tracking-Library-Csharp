
namespace SiteSights.Tracking.Models;

/// <summary>
/// Data object to represent event request body
/// </summary>
public sealed record SiteSightsEvent {

    /// <summary>
    /// Name/Category of the event
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Parameters - Max length: 12
    /// </summary>
    public List<EventParameter> Parameters { get; set; } = [];

    /// <summary>
    /// Metrics of visitor
    /// </summary>
    public required ClientMetrics Metrics { get; set; }

}

/// <summary>
/// Event parameter
/// </summary>
public sealed record EventParameter {

    /// <summary>
    /// Max length: 200
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Max length: 2000
    /// </summary>
    public required string Value { get; set; }

}