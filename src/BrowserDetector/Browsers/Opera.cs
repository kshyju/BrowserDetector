using System;

namespace Shyjus.BrowserDetector.Browsers
{
    public class Opera : Browser
    {
        public override BrowserType Type => BrowserType.Opera;

        public static bool TryParse(ReadOnlySpan<char> userAgent, out Opera result)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            var operaIndex = userAgent.IndexOf("Opera/".AsSpan());

            if (operaIndex > -1)
            {
                var versionIndex = userAgent.IndexOf("Version/".AsSpan());
                var subStringWithVersion = userAgent.Slice(versionIndex + 8);

                result = new Opera
                {
                    Version = Version.Parse(subStringWithVersion.ToString())
                };

                return true;
            }

            result = null;

            return false;
        }
    }
}
