namespace SiteSights.Tracking.Exceptions;

public class SiteSightsUrlInvalidException(string? url)
    : Exception($"The URL {url} is invalid. Please provide a valid URL.");