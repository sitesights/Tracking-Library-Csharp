using System.Text.Json.Serialization;
using SiteSights.Tracking.Models;

namespace SiteSights.Tracking.Serialization;

[JsonSourceGenerationOptions(WriteIndented = true, GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(SiteSightsEvent))]
[JsonSerializable(typeof(SiteSightsPageView))]
internal partial class SiteSightsRequestJsonSerializerContext : JsonSerializerContext;

[JsonSourceGenerationOptions(WriteIndented = true, GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(SiteSightsApiResponse))]
internal partial class SiteSightsResponseJsonSerializerContext : JsonSerializerContext;