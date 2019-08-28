using System;

namespace Shyjus.BrowserDetector.Browsers
{
    /// <summary>
    /// Represents an instance of Chrome Browser
    /// Sample user agent string: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36
    /// </summary>
    public class Chrome : Browser
    {
        public override BrowserType Type => BrowserType.Chrome;

        /// <summary>
        /// Populates a Chrome browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain a Chrome object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out Chrome result)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            var chromeIndex = userAgent.IndexOf("Chrome/".AsSpan());

            if (chromeIndex > -1)
            {
                var subStringWithVersion = userAgent.Slice(chromeIndex + 7);
                var endOfVersionIndex = subStringWithVersion.IndexOf(' ');

                if (endOfVersionIndex > -1)
                {
                    var version = subStringWithVersion.Slice(0, endOfVersionIndex);

                    result = new Chrome()
                    {
                        Version = Version.Parse(version.ToString())
                    };

                    return true;
                }
            }

            result = null;

            return false;
        }
    }
}
