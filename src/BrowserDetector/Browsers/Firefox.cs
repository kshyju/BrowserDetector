using System;

namespace Shyjus.BrowserDetector.Browsers
{
    public class Firefox : Browser
    {
        public override BrowserType Type => BrowserType.Firefox;

        /// <summary>
        /// Populates a Firefox browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain a Firefox object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out Firefox result)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            var firefoxIndex = userAgent.IndexOf("Firefox/".AsSpan());

            if (firefoxIndex > -1)
            {
                var version = userAgent.Slice(firefoxIndex + 8).ToString();

                result = new Firefox()
                {
                    Version = Version.Parse(version)
                };

                return true;
            }

            result = null;

            return false;
        }
    }
}
