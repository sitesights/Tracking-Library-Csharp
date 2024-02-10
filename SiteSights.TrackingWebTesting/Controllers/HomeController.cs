using Microsoft.AspNetCore.Mvc;
using SiteSights.TrackingWebTesting.Models;
using System.Diagnostics;
using SiteSights.Tracking.Contracts;
using SiteSights.Tracking.Models;

namespace SiteSights.TrackingWebTesting.Controllers {

    public class HomeController : Controller {

        private readonly ISiteSightsTracking _tracking;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISiteSightsTracking tracking) {

            _logger = logger;
            _tracking = tracking;

        }

        public async Task<IActionResult> Index()
        {
            await _tracking.PageView(new SiteSightsPageView()
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
            });
            
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}