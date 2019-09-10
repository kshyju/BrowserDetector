using Microsoft.AspNetCore.Http;
using Shyjus.BrowserDetector.Browsers;
using System;

namespace Shyjus.BrowserDetector
{

    public class BrowserDetector : IBrowserDetector
    {
        private readonly Lazy<IBrowser> browser;

        private readonly IHttpContextAccessor httpContextAccessor;
        public BrowserDetector(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.browser = this.GetBrowserLazy();
        }

        private Lazy<IBrowser> GetBrowserLazy()
        {
            return new Lazy<IBrowser>(() =>
            {
                return GetBrowser();
            });
        }


        /// Populates a browser object from the userAgentString value
        /// </summary>
        /// <returns>A browser object or null</returns>
        private IBrowser GetBrowser()
        {
            var userAgentString = this.httpContextAccessor.HttpContext.Request.Headers["User-Agent"][0].AsSpan();


            // tablet or desktop
            return Detector.GetBrowser(userAgentString);

        }

        public IBrowser Browser
        {
            get
            {
                return this.browser.Value;
            }
        }
    }
}
