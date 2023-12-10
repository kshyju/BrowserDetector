#nullable enable
namespace Shyjus.BrowserDetection
{
    using System;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// A class to get browser and platform information.
    /// </summary>
    public sealed class BrowserDetector : IBrowserDetector
    {
        private readonly Lazy<IBrowser?> _browser;

        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserDetector"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The IHttpContextAccessor instance.</param>
        public BrowserDetector(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _browser = this.GetBrowserLazy();
        }

        /// <summary>
        /// Gets the browser information.
        /// </summary>
        public IBrowser? Browser => _browser.Value;

        private Lazy<IBrowser?> GetBrowserLazy()
        {
            return new Lazy<IBrowser?>(GetBrowser);
        }

        /// <summary>
        /// Gets the IBrowser instance.
        /// </summary>
        /// <returns>The IBrowser instance.</returns>
        private IBrowser? GetBrowser()
        {
            if (_httpContextAccessor.HttpContext?.Request?.Headers?.TryGetValue(Headers.UserAgent, out var uaHeader) == true)
            {
                return Detector.GetBrowser(uaHeader[0].AsSpan());
            }

            return default;
        }
    }
}
