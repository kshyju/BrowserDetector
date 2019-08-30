using Microsoft.AspNetCore.Mvc;
using Shyjus.BrowserDetector;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrowserDetector browserDetector;
        public HomeController(IBrowserDetector browserDetector)
        {
            this.browserDetector = browserDetector;
        }
        public IActionResult Index()
        {
            var browser = this.browserDetector.Browser;
            // Use browser object as needed.

            return View();
        }

        [Route("headers")]
        public IActionResult Headers()
        {
            return View();
        }
    }
}
