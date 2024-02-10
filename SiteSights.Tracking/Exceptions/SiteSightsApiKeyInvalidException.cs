namespace SiteSights.Tracking.Exceptions;

public class SiteSightsApiKeyInvalidException(string apiKey)
    : Exception($"The API key {apiKey} is null or empty. Please provide a valid API key.");