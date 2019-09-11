using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shyjus.BrowserDetection;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrowserDetector browserDetector;
        public HomeController(IBrowserDetector browserDetector, IHttpContextAccessor a)
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
