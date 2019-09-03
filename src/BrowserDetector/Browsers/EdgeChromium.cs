using System;

namespace Shyjus.BrowserDetector.Browsers
{
    /// <summary>
    /// Represents an instance of Edge chromium Browser
    /// Sample user agent string: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3803.0 Safari/537.36 Edg/76.0.176.0
    /// </summary>
    public class EdgeChromium : Browser
    {  
        public override string Name => BrowserNames.EdgeChromium;
        public override string DeviceType => DeviceTypes.Desktop;

        /// <summary>
        /// Populates a Chrome browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain a EdgeChromium object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out EdgeChromium result)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            var edgIndex = userAgent.IndexOf("Edg/".AsSpan());

            if (edgIndex > -1)
            {
                var subStringWithVersion = userAgent.Slice(edgIndex + 4);


                var version = subStringWithVersion;

                result = new EdgeChromium()
                {
                    Version = Version.Parse(version.ToString())
                };

                return true;

            }

            result = null;

            return false;
        }
    }
}
