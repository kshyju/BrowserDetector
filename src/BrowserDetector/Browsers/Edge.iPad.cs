using System;

namespace Shyjus.BrowserDetector.Browsers
{
    public class EdgeIPad : Browser
    {
        public override BrowserType Type => BrowserType.EdgeIPad;

        /// <summary>
        /// Populates an Edge browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain an Edge object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out EdgeIPad result)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            var edgeIndex = userAgent.IndexOf("EdgiOS/".AsSpan());

            if (edgeIndex > -1)
            {
                var subStringWithVersion = userAgent.Slice(edgeIndex + 7);
                var endOfVersionIndex = subStringWithVersion.IndexOf(' ');

                if (endOfVersionIndex > -1)
                {
                    var version = subStringWithVersion.Slice(0, endOfVersionIndex).ToString();

                    result = new EdgeIPad
                    {
                        Version = Version.Parse(version)
                    };

                    return true;
                }
            }

            result = null;

            return false;
        }
    }
}
