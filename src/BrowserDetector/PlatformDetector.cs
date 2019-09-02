using System;
using System.Collections.Generic;
using System.Text;

namespace Shyjus.BrowserDetector
{
    public static class DeviceDetector
    {
        public static bool IsDesktop(ReadOnlySpan<char> userAgent)
        {
            return userAgent.IndexOf("Mobi".AsSpan()) == -1;
        }

        public static string GetDeviceType(ReadOnlySpan<char> userAgent)
        {
            var isDesktop = IsDesktop(userAgent);

            if (isDesktop)
            {
                return DeviceTypes.Desktop;
            }

            // check tablet or mobile



            return string.Empty;
        }
    }
    public static class PlatformDetector
    {
        public static (string Platform, string OS) GetPlatformAndOS(ReadOnlySpan<char> userAgentString)
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

            // Get the platform part slice
            var platformSlice = platformSubstring.Slice(0, platFormPartEndIndex);

            // OS part is between two ";" after platform slice
            // Get the sub slice which is after platform
            var osSubString = platformSubstring.Slice(platFormPartEndIndex + 2); // ';' length +' ' length

            // Find the end index of platform end character from the os sub slice
            var osPartEndIndex = osSubString.IndexOf(';');

            // some Macintosh UA does not have an end ";" so look for ") "
            if (osPartEndIndex == -1)
            {
                osPartEndIndex = osSubString.IndexOf(") ".AsSpan());

            }
            // Get the OS part slice
            var operatingSystemSlice = osSubString.Slice(0, osPartEndIndex);


            return (Platform: platformSlice.ToString(), OS: operatingSystemSlice.ToString());
        }
    }
}
