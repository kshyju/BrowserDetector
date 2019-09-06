using System;
using System.Linq;

namespace Shyjus.BrowserDetector.Browsers
{
    public class BaseBrowser
    {
        private string platform;

        public string DeviceType { get; }
        public Version Version { get; }

        public string BrowserVersion { get;  }
        public string OS { get; }
        public BaseBrowser(ReadOnlySpan<char> userAgent, string version)
        {
            var platform = PlatformDetector.GetPlatformAndOS(userAgent);

            this.platform = platform.Platform;
            this.OS = platform.OS;

            this.DeviceType = GetDeviceType();

            this.BrowserVersion = version;
        }

        private string GetDeviceType()
        {
            // to do  : Check a dictionary and see allocations difference

            if (this.platform == Platforms.iPhone)
            {
                return DeviceTypes.Mobile;
            }
            else if (this.platform == Platforms.iPad || this.platform == "GalaxyTabS4")
            {
                return DeviceTypes.Tablet;
            }
            else if (this.platform == Platforms.Macintosh || this.platform == Platforms.Windows10)
            {
                return DeviceTypes.Desktop;
            }
            return string.Empty;
        }

        protected static string GetVersionIfKeyPresent(ReadOnlySpan<char> userAgent, string key)
        {
            var keyStartIndex = userAgent.IndexOf(key.AsSpan());

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

    }
}
