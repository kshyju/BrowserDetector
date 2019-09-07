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
            return GetDesktopBrowser(userAgentString);

        }

   

        private static IBrowser GetDesktopBrowser(ReadOnlySpan<char> userAgentString)
        {
            // Order is important, Go from most specific to generic
            // For example, The string "Chrome" is present in both Chrome and Edge,
            // So we will first check if it is Edge because Edge has something more specific we can check.
            if (Firefox.TryParse(userAgentString, out var firefox))
            {
                return firefox;
            }

            if (EdgeChromium.TryParse(userAgentString, out var edgeChromium))
            {
                return edgeChromium;
            }

            if (InternetExplorer.TryParse(userAgentString, out var ie))
            {
                return ie;
            }

            if (Opera.TryParse(userAgentString, out var opera))
            {
                return opera;
            }

            if (Edge.TryParse(userAgentString, out var edge))
            {
                return edge;
            }

            if (Chrome.TryParse(userAgentString, out var chrome))
            {
                return chrome;
            }

            if (Safari.TryParse(userAgentString, out var safari))
            {
                return safari;
            }

            return null;
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
