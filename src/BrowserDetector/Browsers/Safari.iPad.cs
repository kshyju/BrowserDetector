using System;

namespace Shyjus.BrowserDetector.Browsers
{
    public class SafariIPad : Browser
    {
        public override string Name => BrowserNames.Safari;
        public override string DeviceType => DeviceTypes.Tablet;

        /// <summary>
        /// Populates a Safari browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain a Safari object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        /// <exception cref="ArgumentNullException">Thrown when userAgent parameter value is null</exception>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out SafariIPad result)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            var iPadIndex = userAgent.IndexOf("iPad;".AsSpan());

            if (iPadIndex > -1)
            {
                var versionIndex = userAgent.IndexOf("Version/".AsSpan());
                var subStringWithVersion = userAgent.Slice(versionIndex + 8);
                var endOfVersionIndex = subStringWithVersion.IndexOf(' ');

                if (endOfVersionIndex > -1)
                {
                    var version = subStringWithVersion.Slice(0, endOfVersionIndex).ToString();

                    result = new SafariIPad
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
