using System;

namespace Shyjus.BrowserDetection.Browsers
{
    /// <summary>
    /// Represents an instance of Chrome Browser
    /// has both "Safari" and "Chrome" in UA
    /// Sample user agent string: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36
    /// </summary>
    internal class Chrome : Browser

    {
        public Chrome(ReadOnlySpan<char> userAgent, string version) : base(userAgent, version)
        {
        }

        public override string Name => BrowserNames.Chrome;

        /// <summary>
        /// Populates a Chrome browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain a Chrome object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out Chrome result)
        {
            var chromeIndex = userAgent.IndexOf("Chrome/".AsSpan());
            var safariIndex = userAgent.IndexOf("Safari/".AsSpan());
            var crIOS = userAgent.IndexOf("CriOS/".AsSpan());

            // Chrome should have both "Safari" and "Chrome" words in it.
            if (safariIndex >-1 && chromeIndex > -1 || safariIndex> -1 && crIOS> -1)
            {
                var fireFoxVersion = GetVersionIfKeyPresent(userAgent, "Chrome/");
                if (fireFoxVersion != null)
                {
                    result = new Chrome(userAgent, fireFoxVersion);
                    return true;
                }

                var chromeIosVersion = GetVersionIfKeyPresent(userAgent, "CriOS/");
                if (chromeIosVersion != null)
                {
                    result = new Chrome(userAgent, chromeIosVersion);
                    return true;
                }
            }
            result = null;
            return false;
        }
    }
}
