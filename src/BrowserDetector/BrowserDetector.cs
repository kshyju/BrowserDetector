using Microsoft.AspNetCore.Http;
using Shyjus.BrowserDetector.Browsers;
using System;

namespace Shyjus.BrowserDetector
{
    public class BrowserDetector : IBrowserDetector
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public BrowserDetector(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        private void PopulateBrowser()
        {

        }

        /// Populates a browser object from the userAgentString value
        /// </summary>
        /// <returns>A browser object or null</returns>
        internal Browser GetBrowser()
        {
            var userAgentString = this.httpContextAccessor.HttpContext.Request.Headers["User-Agent"][0].AsSpan();

            // Order is important, Go from most specific to generic
            // For example, The string "Chrome" is present in both Chrome and Edge,
            // So we will first check if it is Edge because Edge has something more specific we can check.

            if (Safari.TryParse(userAgentString, out var safari))
            {
                return safari;
            }

            if (Edge.TryParse(userAgentString, out var edge))
            {
                return edge;
            }

            if (Chrome.TryParse(userAgentString, out var chrome))
            {
                return chrome;
            }

            if (Firefox.TryParse(userAgentString, out var firefox))
            {
                return firefox;
            }

            if (InternetExplorer.TryParse(userAgentString, out var ie))
            {
                return ie;
            }

            return null;
        }

        public Browser Browser
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
