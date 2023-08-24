using Microsoft.AspNetCore.Mvc;
using SiteSights.Tracking.Common;
using SiteSights.TrackingWebTesting.Models;
using System.Diagnostics;

namespace SiteSights.TrackingWebTesting.Controllers {

    public class HomeController : Controller {

        private readonly ISiteSightsTracking _tracking;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISiteSightsTracking tracking) {
            _logger = logger;
            _tracking = tracking;
        }

        public async Task<IActionResult> Index() {

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