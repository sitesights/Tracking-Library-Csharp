
namespace SiteSights.Tracking.Models;

/// <summary>
/// Data object to represent api response
/// </summary>
public sealed record SiteSightsApiResponse {

    /// <summary>
    /// 200 - Success, all other codes are failures, see https://docs.sitesights.io/server/endpoints for more
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Short description of success or why it failed.
    /// </summary>
    public required string Message { get; set; }

}
