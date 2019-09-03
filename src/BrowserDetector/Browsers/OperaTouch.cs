using System;

namespace Shyjus.BrowserDetector.Browsers
{
    public class OperaTouch : Browser
    {
        public override string DeviceType => DeviceTypes.Mobile;

        public override string Name => BrowserNames.OperaTouch;

        public static bool TryParse(ReadOnlySpan<char> userAgent, out OperaTouch result)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            var operaIndex = userAgent.IndexOf("OPT/".AsSpan());

            if (operaIndex > -1)
            {
                var postOptSlice = userAgent.Slice(operaIndex + 4);
                var versionEndIndex = postOptSlice.IndexOf(' ');
                var version = postOptSlice.Slice(0, versionEndIndex).ToString();

                result = new OperaTouch
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
