using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shyjus.BrowserDetection;
using System;

namespace DemoApp.NET3._1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrowserDetector browserDetector;
        public HomeController(IBrowserDetector browserDetector, ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.browserDetector = browserDetector ?? throw new ArgumentNullException(nameof(browserDetector));
        }

        [HttpGet]
        public string Get()
        {
            this._logger.LogInformation("Inside GET action method");

            IBrowser browser = this.browserDetector.Browser;

            return $".NET CORE 3.1 APP. Browser:{browser.Name}, Version: {browser.Version},Device type: {browser.DeviceType}, OS: {browser.OS}";
        }
    }
}
