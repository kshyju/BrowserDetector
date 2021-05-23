﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shyjus.BrowserDetection;

namespace DemoApp.NET5.Controllers
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
            IBrowser browser = this.browserDetector.Browser;
            
            return $"Browser:{browser.Name}, Version: {browser.Version},Device type: {browser.DeviceType}, OS: {browser.OS}";
        }
    }
    
}