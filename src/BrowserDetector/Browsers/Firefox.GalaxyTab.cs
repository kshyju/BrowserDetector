using System;

namespace Shyjus.BrowserDetector.Browsers
{
    public class FirefoxGalaxyTab : Browser
    {
        public override string Name => BrowserNames.Firefox;
        public override string DeviceType => DeviceTypes.Tablet;

        public static bool TryParse(ReadOnlySpan<char> userAgent, out FirefoxGalaxyTab result)
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

                    result = new FirefoxGalaxyTab()
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
