namespace Shyjus.BrowserDetection
{
    using System;

    /// <summary>
    /// A helper to detect the platform.
    /// </summary>
    internal static class PlatformDetector
    {
        internal static (string Platform, string OS, bool MobileDetected) GetPlatformAndOS(ReadOnlySpan<char> userAgentString)
        {
            // Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.

            // Platform starts with a "(". So get it's index
            var platformSearhKeyStartIndex = " (".AsSpan();

            // The index of substring where platform part starts
            var platformSubstringStartIndex = userAgentString.IndexOf(platformSearhKeyStartIndex) + platformSearhKeyStartIndex.Length;

            // Get substring which starts with platform part (Trim out anything before platform)
            var platformSubstring = userAgentString.Slice(platformSubstringStartIndex);

            // Find end index of end character of platform part.
            var platFormPartEndIndex = platformSubstring.IndexOf(';');

            // For 32 bit, no ";" present, so get the closing ")";
            if (platFormPartEndIndex == -1)
            {
                platFormPartEndIndex = platformSubstring.IndexOf(')');
            }

            // Get the platform part slice
            var platformSlice = platformSubstring.Slice(0, platFormPartEndIndex);

            // OS part is between two ";" after platform slice
            // Get the sub slice which is after platform
            var osSubString = platformSubstring.Slice(platFormPartEndIndex + 2); // ';' length +' ' length

            // Find the end index of platform end character from the os sub slice
            var osPartEndIndex = osSubString.IndexOf(')');

            // Get the OS part slice
            var operatingSystemSlice = osSubString.Slice(0, osPartEndIndex);

            // If OS part starts with "Linux", check for next segment to get android veersion //Linux; Android 9; Pixel 3
            // Linux; Android 8.1.0; SM-T835
            var platform = platformSlice.ToString();

            var isMobileSlicePresent = userAgentString.IndexOf("Mobile".AsSpan()) > -1;

            var os = GetReadableOSName(platform, operatingSystemSlice.ToString());

            return (Platform: platform, OS: os, MobileDetected: isMobileSlicePresent);
        }

        /// <summary>
        /// Gets a readable OS name from the platform & operatingSystem info.
        /// For some cases, the "operatingSystem" param value is not enought and we rely on the platform param value.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="operatingSystem"></param>
        /// <returns>The OS name.</returns>
        private static string GetReadableOSName(string platform, string operatingSystem)
        {
            if (platform == Platforms.iPhone ||platform == Platforms.iPad)
            {
                return OperatingSystems.IOS;
            }

            // If platform starts with "Android" (Firefox galaxy tab4)
            if (platform == "Android")
            {
                return OperatingSystems.Android;
            }

            if (platform == "Macintosh")
            {
                return OperatingSystems.MacOSX;
            }

            if (platform.StartsWith("Windows NT"))
            {
                return OperatingSystems.Windows;
            }

            if (platform == "Pixel 3")
            {
                return OperatingSystems.Android;
            }

            // Pixel 3
            if (platform == "Linux" && operatingSystem.IndexOf("Android", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return OperatingSystems.Android;
            }

            return operatingSystem;
        }
    }
}
