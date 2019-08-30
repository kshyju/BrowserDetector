using System;

namespace Shyjus.BrowserDetector.Browsers
{
    /// <summary>
    /// Represents an instance of Chrome Browser
    /// Sample user agent string: Mozilla/5.0 (iPad; CPU OS 10_3_3 like Mac OS X) AppleWebKit/603.1.30 (KHTML, like Gecko) CriOS/71.0.3578.89 Mobile/14G60 Safari/602.1
    /// </summary>
    public class ChromeIPad : Browser
    {
        public override BrowserType Type => BrowserType.ChromeIPad;

        /// <summary>
        /// Populates a Chrome browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain a Chrome object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out ChromeIPad result)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            var crisOsIndex = userAgent.IndexOf("CriOS/".AsSpan());

            if (crisOsIndex > -1)
            {
                var subStringWithVersion = userAgent.Slice(crisOsIndex + 6);
                var endOfVersionIndex = subStringWithVersion.IndexOf(' ');

                if (endOfVersionIndex > -1)
                {
                    var version = subStringWithVersion.Slice(0, endOfVersionIndex);

                    result = new ChromeIPad()
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
