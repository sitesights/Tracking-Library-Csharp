using RichardSzalay.MockHttp;
using SiteSights.Tracking.Common;
using SiteSights.Tracking.Constants;
using SiteSights.Tracking.Exceptions;
using SiteSights.Tracking.Options;

namespace SiteSights.Tracking.Tests;

public class ApiTests
{
    [Fact]
    public async Task SiteSightTracking_PageView_ShouldReturnSuccess()
    {
        // Arrange
        var testUrl = SiteSightsConstants.DefaultSiteSightsUrl + "/*";
        var testApiKey = Guid.NewGuid().ToString("N"); 
        var mockHttp = new MockHttpMessageHandler();
        
        mockHttp.When(testUrl)
            .Respond("application/json", TestData.ApiResponseJson);
        
        var httpClient = mockHttp.ToHttpClient();
        
        var options = new SiteSightsTrackingOptions
        {
            ApiKey = testApiKey
        };
        
        var iOptions = Microsoft.Extensions.Options.Options.Create(options);
        
        // Act
        var siteSightsTracking = new SiteSightsTracking(iOptions, httpClient);
        
        var response = await siteSightsTracking.PageView(TestData.PageViewTestData);
        
        // Assert
        Assert.NotNull(response);
        Assert.Equal(TestData.ApiResponseExpected, response);
        
    }
    
    [Fact]
    public async Task SiteSightTracking_Event_ShouldReturnSuccess()
    {
        // Arrange
        const string testUrl = SiteSightsConstants.DefaultSiteSightsUrl + "/*";
        var testApiKey = Guid.NewGuid().ToString("N"); 
        var mockHttp = new MockHttpMessageHandler();
        
        mockHttp.When(testUrl)
            .Respond("application/json", TestData.ApiResponseJson);
        
        var httpClient = mockHttp.ToHttpClient();
        
        var options = new SiteSightsTrackingOptions
        {
            ApiKey = testApiKey
        };
        
        var iOptions = Microsoft.Extensions.Options.Options.Create(options);
        
        // Act
        var siteSightsTracking = new SiteSightsTracking(iOptions, httpClient);
        
        var response = await siteSightsTracking.Event(TestData.EventTestData);
        
        // Assert
        Assert.NotNull(response);
        Assert.Equal(TestData.ApiResponseExpected, response);
    }
    
    [Fact]
    public void SiteSightsTracking_Constructor_ApiKeyValidation_ShouldThrowException()
    {
        // Arrange
        var testApiKey = string.Empty; 
        var mockHttp = new MockHttpMessageHandler();
        
        var httpClient = mockHttp.ToHttpClient();
        
        var options = new SiteSightsTrackingOptions
        {
            ApiKey = testApiKey
        };
        
        var iOptions = Microsoft.Extensions.Options.Options.Create(options);
        
        // Act & Assert
        Assert.Throws<SiteSightsApiKeyInvalidException>(() => new SiteSightsTracking(iOptions, httpClient));
    }
    
    [Fact]
    public void SiteSightsTracking_Constructor_UrlEmptyValidation_ShouldThrowException()
    {
        // Arrange
        var testApiKey = Guid.NewGuid().ToString("N");
        var testUrl = string.Empty;
        var mockHttp = new MockHttpMessageHandler();
        
        var httpClient = mockHttp.ToHttpClient();
        
        var options = new SiteSightsTrackingOptions
        {
            ApiKey = testApiKey,
            Url = testUrl
        };
        
        var iOptions = Microsoft.Extensions.Options.Options.Create(options);
        
        // Act & Assert
        Assert.Throws<SiteSightsUrlInvalidException>(() => new SiteSightsTracking(iOptions, httpClient));
    }
    
    [Fact]
    public void SiteSightsTracking_Constructor_UrlInvalidValidation_ShouldThrowException()
    {
        // Arrange
        var testApiKey = Guid.NewGuid().ToString("N");
        const string testUrl = "hxxp:///example.com";
        var mockHttp = new MockHttpMessageHandler();
        
        var httpClient = mockHttp.ToHttpClient();
        
        var options = new SiteSightsTrackingOptions
        {
            ApiKey = testApiKey,
            Url = testUrl
        };
        
        var iOptions = Microsoft.Extensions.Options.Options.Create(options);
        
        // Act & Assert
        Assert.Throws<SiteSightsUrlInvalidException>(() => new SiteSightsTracking(iOptions, httpClient));
    }
}