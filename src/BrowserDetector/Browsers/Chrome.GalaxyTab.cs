using System;

namespace Shyjus.BrowserDetector.Browsers
{
    public class ChromeGalaxyTab : Browser
    {
        public override string Name => BrowserNames.Chrome;
        public override string DeviceType => DeviceTypes.Tablet;

        /// <summary>
        /// Populates a Chrome browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain a Chrome object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out ChromeGalaxyTab result)
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

                    result = new ChromeGalaxyTab()
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
