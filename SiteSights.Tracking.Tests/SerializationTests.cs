using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using SiteSights.Tracking.Models;

namespace SiteSights.Tracking.Tests;

public class SerializationTests
{
    private readonly Assembly _assembly = typeof(SiteSightsPageView).Assembly;

    [Fact]
    public void SiteSightsPageView_Serialize_Success()
    {
        var type = _assembly.GetType("SiteSights.Tracking.Serialization.SiteSightsRequestJsonSerializerContext");

        Assert.NotNull(type);

        var instance = Activator.CreateInstance(type);

        var value = type.GetProperty("Default")?.GetValue(instance);

        Assert.NotNull(value);

        Assert.IsAssignableFrom<JsonSerializerContext>(value);

        var jsonSerializerContext = (JsonSerializerContext)value;


        var json = JsonSerializer.Serialize(TestData.PageViewTestData, jsonSerializerContext.Options);

        Assert.Equal(TestData.PageViewJsonExpected, json);
    }
    
    [Fact]
    public void SiteSightsEvent_Serialize_Success()
    {
        var type = _assembly.GetType("SiteSights.Tracking.Serialization.SiteSightsRequestJsonSerializerContext");

        Assert.NotNull(type);

        var instance = Activator.CreateInstance(type);

        var value = type.GetProperty("Default")?.GetValue(instance);

        Assert.NotNull(value);

        Assert.IsAssignableFrom<JsonSerializerContext>(value);

        var jsonSerializerContext = (JsonSerializerContext)value;


        var json = JsonSerializer.Serialize(TestData.EventTestData, jsonSerializerContext.Options);

        Assert.Equal(TestData.EventJsonExpected, json);
    }
    
    [Fact]
    public void SiteSightsApiResponse_Deserialize_Success()
    {
        var type = _assembly.GetType("SiteSights.Tracking.Serialization.SiteSightsResponseJsonSerializerContext");

        Assert.NotNull(type);

        var instance = Activator.CreateInstance(type);

        var value = type.GetProperty("Default")?.GetValue(instance);

        Assert.NotNull(value);

        Assert.IsAssignableFrom<JsonSerializerContext>(value);

        var jsonSerializerContext = (JsonSerializerContext)value;


        var response = JsonSerializer.Deserialize<SiteSightsApiResponse>(TestData.ApiResponseJson, jsonSerializerContext.Options);

        Assert.NotNull(response);
        Assert.Equal(TestData.ApiResponseExpected, response);
    }
}