using Shyjus.BrowserDetector.Core;

namespace Shyjus.BrowserDetector
{
    using System;

    internal abstract class Browser : IBrowser
    {
        private readonly string _platform;

        protected Browser(ReadOnlySpan<char> userAgent, string version)
        {
            this.Version = version;

            var platform = PlatformDetector.GetPlatformAndOS(userAgent);
            this._platform = platform.Platform;
            this.OS = platform.OS;

            // Get the device type from platform info.
            this.DeviceType = this.GetDeviceType(platform);
        }

        /// <inheritdoc/>
        public abstract string Name { get; }

        /// <inheritdoc/>
        public DeviceType DeviceType { get; }

        /// <inheritdoc/>
        public string Version { get; }

        /// <inheritdoc/>
        public string OS { get; }


        public override string? ToString()
        {
            return $"{this.Name} {this.Version} on {this.OS} ({this.DeviceType})";
        }

        /// <summary>
        /// Gets the version segment from user agent for the key passed in.
        /// </summary>
        /// <param name="userAgent">The user agent value.</param>
        /// <param name="key">The key to use for looking up the version segment.</param>
        /// <returns>The version segment.</returns>
        protected static string? GetVersionIfKeyPresent(ReadOnlySpan<char> userAgent, string key)
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
                return sliceWithVersionPart.Slice(0, endIndex).ToString();
            }

            return sliceWithVersionPart.ToString();
        }

        /// <summary>
        /// Gets the device type from the platform information.
        /// </summary>
        /// <param name="platform">The platform information.</param>
        /// <returns>The device type value.</returns>
        private DeviceType GetDeviceType((string Platform, string OS, bool MobileDetected) platform)
        {
            if (this._platform == Platforms.iPhone)
            {
                return DeviceType.Mobile;
            }
            else if (this._platform == Platforms.iPad || this._platform == "GalaxyTabS4")
            {
                return DeviceType.Tablet;
            }

            // IPad also has Mobile in it. So make sure to check that first
            if (platform.MobileDetected)
            {
                return DeviceType.Mobile;
            }
            else if (this._platform == Platforms.Macintosh || this._platform.StartsWith("Windows NT"))
            {
                return DeviceType.Desktop;
            }

            // Samsung Chrome_GalaxyTabS4 does not have "Mobile", but it has Linux and Android.
            if (this._platform == "Linux" && platform.OS == "Android" && platform.MobileDetected == false)
            {
                return DeviceType.Tablet;
            }

            return DeviceType.Unknown;
        }
    }
}
