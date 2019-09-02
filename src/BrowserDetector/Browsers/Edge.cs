using System;

namespace Shyjus.BrowserDetector.Browsers
{
    public class Edge : Browser
    {
        public override string DeviceType => DeviceTypes.Desktop;

        public override string Name => BrowserNames.Edge;

        /// <summary>
        /// Populates an Edge browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain an Edge object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out Edge result)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            var edgeIndex = userAgent.IndexOf("Edge/".AsSpan());

            if (edgeIndex > -1)
            {
                var version = userAgent.Slice(edgeIndex + 5).ToString();

                result = new Edge
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
