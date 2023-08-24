
using SiteSights.Tracking.Common;

var tracking = new SiteSightsTracking(new SiteSightsTrackingOptions() {
    ApiKey = "[API_KEY]",
});

var resp = await tracking.PageView(new SiteSightsPageView() {
    Metrics = new ClientMetrics() {
        Browser = new BrowserMetric() {
            IP = "91.48.119.123",
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/116.0",
        },
        Identify = new SessionMetric() {
            ClientId = "b",
        },
        Language = new LanguageMetric() {
            Code = "en",
        },
        Page = new PageMetric() {
            Absolute = "https://app.sitesights.io/analytics",
        },
        Referrer = new ReferrerMetric() {
            Absolute = "https://app.sitesights.io",
        },
        Screen = new ScreenMetric() {
            Height = 200,
            Width = 200
        },
        Location = new LocationMetric() {
            ContinentCode = "AF",
            CountryCode = "AF",
            City = "test",
            PostalCode = "33100",
            Region = "test",
            RegionCode = "te",
            Timezone = "timezone",
        }
    }
});

Console.WriteLine(resp.Message);

resp = await tracking.Event(new SiteSightsEvent() {
    Name = "test",
    Parameters = new List<EventParameter>() {
        new EventParameter() {
            Name = "param1",
            Value = "value2"
        }
    },
    Metrics = new ClientMetrics() {
        Browser = new BrowserMetric() {
            IP = "91.48.119.123",
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/116.0",
        },
        Identify = new SessionMetric() {
            ClientId = null,
        },
        Language = new LanguageMetric() {
            Code = "en",
        },
        Page = new PageMetric() {
            Absolute = "https://app.sitesights.io/analytics",
        },
        Referrer = new ReferrerMetric() {
            Absolute = null,
        },
        Screen = new ScreenMetric() {
            Height = 200,
            Width = 200
        },
        Location = new LocationMetric() {
            ContinentCode = "AF",
            CountryCode = "AF",
            City = "test",
            PostalCode = "33100",
            Region = null,
            RegionCode = null,
            Timezone = null,
        }
    }
});

Console.WriteLine(resp.Message);


Console.ReadLine();