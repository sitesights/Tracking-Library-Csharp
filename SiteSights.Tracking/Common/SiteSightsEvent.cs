
namespace SiteSights.Tracking.Common;

/// <summary>
/// Data object to represent event request body
/// </summary>
public sealed class SiteSightsEvent {

    /// <summary>
    /// Name/Category of the event
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Parameters - Max length: 12
    /// </summary>
    public List<EventParameter> Parameters { get; set; }

    /// <summary>
    /// Metrics of visitor
    /// </summary>
    public ClientMetrics Metrics { get; set; }

}

/// <summary>
/// Event parameter
/// </summary>
public sealed class EventParameter {

    /// <summary>
    /// Max length: 200
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Max length: 2000
    /// </summary>
    public string Value { get; set; }

}