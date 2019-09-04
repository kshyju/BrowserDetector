using System;

namespace Shyjus.BrowserDetector.Browsers
{
    public class Firefox
    {
        private string userAgent;

        public string Name { get; }

        public Version Version { get; }

        public string Platform { get; }

        public string DeviceType { get; }

        public string OS { get; }

        private Firefox(ReadOnlySpan<char> userAgent)
        {
            var platform = PlatformDetector.GetPlatformAndOS(userAgent);

            this.Platform = platform.Platform;
            this.OS = platform.OS;

            this.DeviceType = GetDeviceType().Value;

        }

        public Lazy<string> GetDeviceType()
        {
            return new Lazy<string>(() =>
            {
                // to do  : Check a dictionary and see allocations difference

                if (this.Platform == Platforms.iPhone)
                {
                    return DeviceTypes.Mobile;
                }
                else if (this.Platform == Platforms.iPad)
                {
                    return DeviceTypes.Mobile;
                }
                else if (this.Platform == Platforms.Macintosh || this.Platform == Platforms.Windows10)
                {
                    return DeviceTypes.Desktop;
                }

                return string.Empty;
            });
        }

        private static string GetVersionIfKeyPresent(ReadOnlySpan<char> userAgent, ReadOnlySpan<char> key)
        {
            var keyStartIndex = userAgent.IndexOf(key);

            if (keyStartIndex == -1)
            {
                return null;
            }

            var sliceWithVersionPart = userAgent.Slice(keyStartIndex + key.Length);

            var endIndex = sliceWithVersionPart.IndexOf(' ');
            if (endIndex > -1)
            {
                return sliceWithVersionPart.Slice(0, endIndex).ToString(); ;
            }

            return sliceWithVersionPart.ToString();

        }

        public static bool TryParse(ReadOnlySpan<char> userAgent, out Firefox result)
        {
            // Windows, Mac
            var fireFoxVersion = GetVersionIfKeyPresent(userAgent, "Firefox/".AsSpan());
            if (fireFoxVersion != null)
            {
                result = new Firefox(userAgent);
                return true;
            }

            // IOS
            var fxiosVersion = GetVersionIfKeyPresent(userAgent, "FxiOS/".AsSpan());
            if (fxiosVersion != null)
            {
                result = new Firefox(userAgent);
                return true;
            }

            result = null;
            return false;
        }
    }
}
