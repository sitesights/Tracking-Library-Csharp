using SiteSights.Tracking.Models;

namespace SiteSights.Tracking.Tests;

public class TestData
{
    public static readonly SiteSightsPageView PageViewTestData = new()
    {
        Metrics = new ClientMetrics
        {
            Browser = new BrowserMetric
            {
                IP = "91.48.119.123",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/116.0",
            },
            Identify = new SessionMetric
            {
                ClientId = null,
            },
            Language = new LanguageMetric
            {
                Code = "en",
            },
            Page = new PageMetric
            {
                Absolute = "https://app.sitesights.io/analytics",
            },
            Referrer = new ReferrerMetric
            {
                Absolute = "https://app.sitesights.io",
            },
            Screen = new ScreenMetric
            {
                Height = 200,
                Width = 200
            },
            Location = new LocationMetric
            {
                ContinentCode = "AF",
                CountryCode = "AF",
                City = "test",
                PostalCode = "33100",
                Region = "test",
                RegionCode = "te",
                Timezone = "timezone",
            }
        }
    };

    public const string PageViewJsonExpected = """
                                                {
                                                  "Metrics": {
                                                    "Browser": {
                                                      "IP": "91.48.119.123",
                                                      "UserAgent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/116.0"
                                                    },
                                                    "Identify": {
                                                      "ClientId": null
                                                    },
                                                    "Language": {
                                                      "Code": "en"
                                                    },
                                                    "Location": {
                                                      "CountryCode": "AF",
                                                      "ContinentCode": "AF",
                                                      "City": "test",
                                                      "Region": "test",
                                                      "RegionCode": "te",
                                                      "PostalCode": "33100",
                                                      "Timezone": "timezone"
                                                    },
                                                    "Page": {
                                                      "Absolute": "https://app.sitesights.io/analytics"
                                                    },
                                                    "Referrer": {
                                                      "Absolute": "https://app.sitesights.io"
                                                    },
                                                    "Screen": {
                                                      "Width": 200,
                                                      "Height": 200
                                                    }
                                                  }
                                                }
                                                """;

    public static readonly SiteSightsEvent EventTestData = new()
    {
        Name = "test",
        Parameters = new List<EventParameter>
        {
            new()
            {
                Name = "param1",
                Value = "value2"
            }
        },
        Metrics = new ClientMetrics
        {
            Browser = new BrowserMetric
            {
                IP = "91.48.119.123",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/116.0",
            },
            Identify = new SessionMetric
            {
                ClientId = null,
            },
            Language = new LanguageMetric
            {
                Code = "en",
            },
            Page = new PageMetric
            {
                Absolute = "https://app.sitesights.io/analytics",
            },
            Referrer = new ReferrerMetric
            {
                Absolute = null,
            },
            Screen = new ScreenMetric
            {
                Height = 200,
                Width = 200
            },
            Location = new LocationMetric
            {
                ContinentCode = "AF",
                CountryCode = "AF",
                City = "test",
                PostalCode = "33100",
                Region = null,
                RegionCode = null,
                Timezone = null,
            }
        }
    };

    public const string EventJsonExpected = """
                                             {
                                               "Name": "test",
                                               "Parameters": [
                                                 {
                                                   "Name": "param1",
                                                   "Value": "value2"
                                                 }
                                               ],
                                               "Metrics": {
                                                 "Browser": {
                                                   "IP": "91.48.119.123",
                                                   "UserAgent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/116.0"
                                                 },
                                                 "Identify": {
                                                   "ClientId": null
                                                 },
                                                 "Language": {
                                                   "Code": "en"
                                                 },
                                                 "Location": {
                                                   "CountryCode": "AF",
                                                   "ContinentCode": "AF",
                                                   "City": "test",
                                                   "Region": null,
                                                   "RegionCode": null,
                                                   "PostalCode": "33100",
                                                   "Timezone": null
                                                 },
                                                 "Page": {
                                                   "Absolute": "https://app.sitesights.io/analytics"
                                                 },
                                                 "Referrer": {
                                                   "Absolute": null
                                                 },
                                                 "Screen": {
                                                   "Width": 200,
                                                   "Height": 200
                                                 }
                                               }
                                             }
                                             """;
    
    public const string ApiResponseJson = """
                                           {
                                             "Code": 200,
                                             "Message": "Success"
                                           }
                                           """;
    
    public static readonly SiteSightsApiResponse ApiResponseExpected = new()
    {
        Code = 200,
        Message = "Success"
    };
}