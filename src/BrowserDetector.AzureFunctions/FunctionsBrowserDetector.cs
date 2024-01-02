using System;

namespace Shyjus.BrowserDetector
{
    internal class FunctionsBrowserDetector : IBrowserDetector
    {
        private string? _userAgent = null;
        private readonly Lazy<IBrowser?> _browser;

        public FunctionsBrowserDetector()
        {
            _browser = this.GetBrowserLazy();
        }

        internal void Init(string userAgent)
        {
            _userAgent = userAgent;
        }
        public IBrowser? Browser
        {
            get
            {
                return _browser.Value;
            }
        }

        private Lazy<IBrowser?> GetBrowserLazy()
        {
            return new Lazy<IBrowser?>(GetBrowser);
        }

        private IBrowser? GetBrowser()
        {
            if (_userAgent != null)
            {
                return Detector.GetBrowser(_userAgent.AsSpan());
            }

            return default;
        }
    }
}
