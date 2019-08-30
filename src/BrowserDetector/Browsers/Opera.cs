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

            var operaIndex = userAgent.IndexOf("OPR/".AsSpan());

            if (operaIndex > -1)
            {
                var version = userAgent.Slice(operaIndex + 4).ToString();

                result = new Opera
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
