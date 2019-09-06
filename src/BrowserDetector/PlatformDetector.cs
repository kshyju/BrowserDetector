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
            var osPartEndIndex = osSubString.IndexOf(')');

           
            // Get the OS part slice
            var operatingSystemSlice = osSubString.Slice(0, osPartEndIndex);

            // If OS part starts with "Linux", check for next segment to get android veersion //Linux; Android 9; Pixel 3
            // Linux; Android 8.1.0; SM-T835

            var p = platformSlice.ToString();



            //if (p == "Linux")
            //{
            //    var indexOfLastSeperator = operatingSystemSlice.LastIndexOf(';');
            //    var device = operatingSystemSlice.Slice(indexOfLastSeperator + 2); // 2 chars(; and space)
            //    // Set device as platform
            //    p = device.ToString();
            //}

            var os = GetReadableOSName(p, operatingSystemSlice.ToString());

            //// Android 8.1.0; Tablet; rv:65.0
            //if (p.StartsWith("Android") && userAgentString.IndexOf("; Tablet;".AsSpan()) > -1)
            //{
            //    os = OperatingSystems.Android;
            //    p = "GalaxyTabS4";
            //}

            return (Platform: p, OS: os);
        }

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
            if (platform == "Windows NT 10.0")
            {
                return OperatingSystems.Windows;
            }
            if (platform == "Pixel 3")
            {
                return OperatingSystems.Android;
            }
            //if (platform == "SM-T835")
            //{
            //    return OperatingSystems.Android;
            //}

            return operatingSystem;
        }
    }
}
