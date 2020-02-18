namespace Shyjus.BrowserDetection
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Shyjus.BrowserDetection.Browsers;

    public sealed class BrowserDetector : IBrowserDetector
    {
        private readonly Lazy<IBrowser> browser;

        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserDetector"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The IHttpContextAccessor instnace.</param>
        public BrowserDetector(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.browser = this.GetBrowserLazy();
        }

        /// <summary>
        /// Gets the browser information.
        /// </summary>
        public IBrowser Browser => this.browser.Value;

        private Lazy<IBrowser> GetBrowserLazy()
        {
            return new Lazy<IBrowser>(() =>
            {
                return this.GetBrowser();
            });
        }

        /// <summary>
        /// Gets the IBrowser instance.
        /// </summary>
        /// <returns>The IBrowser instance.</returns>
        private IBrowser GetBrowser()
        {
            var userAgentStringSpan = this.httpContextAccessor.HttpContext.Request.Headers["User-Agent"][0].AsSpan();
            return Detector.GetBrowser(userAgentStringSpan);
        }
    }
}
