using Microsoft.AspNetCore.Mvc;
using Shyjus.BrowserDetection;

namespace BrowserDetector.WebApi.Controllers
{
    [ApiController]   
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrowserDetector _browserDetector;
        public HomeController(IBrowserDetector browserDetector, ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _browserDetector = browserDetector ?? throw new ArgumentNullException(nameof(browserDetector));
        }

        [HttpGet]
        [Route("")]
        public string Get()
        {
            this._logger.LogInformation("Inside GET action method");

            var browser = _browserDetector.Browser;

            _logger.LogInformation($"Browser:{browser?.Name},OS: {browser?.OS}");

            return $".NET APP. Browser:{browser?.Name}, Version: {browser?.Version},Device type: {browser?.DeviceType}, OS: {browser?.OS}";
        }
    }
}
