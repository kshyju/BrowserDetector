namespace Shyjus.BrowserDetection
{
    using System;

    /// <summary>
    /// Represents an instance of Chrome Browser
    /// has both "Safari" and "Chrome" in UA
    /// Sample user agent string: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36
    /// </summary>
    internal class Chrome : Browser
    {
        /// <summary>
        /// Populates a Chrome browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        public Chrome(string userAgent)
            : base(userAgent)
        {
            Version = string.Empty;

            var chromeIndex = userAgent.AsSpan().IndexOf("Chrome/".AsSpan());
            var safariIndex = userAgent.AsSpan().IndexOf("Safari/".AsSpan());
            var crIOS = userAgent.AsSpan().IndexOf("CriOS/".AsSpan());

            // Chrome should have both "Safari" and "Chrome" words in it.
            if ((safariIndex > -1 && chromeIndex > -1) || (safariIndex > -1 && crIOS > -1))
            {
                var fireFoxVersion = GetVersionIfKeyIsPresent(userAgent, "Chrome/");
                if (fireFoxVersion != null)
                {
                    Version = fireFoxVersion;
                    return;
                }
                    

                var chromeIosVersion = GetVersionIfKeyIsPresent(userAgent, "CriOS/");
                if (chromeIosVersion != null)
                    Version = chromeIosVersion;
            }
        }

        /// <inheritdoc/>
        public override string Name => BrowserNames.Chrome;
        public override string Version { get; }
    }
}
