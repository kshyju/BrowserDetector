using System;

namespace Shyjus.BrowserDetector.Browsers
{
    public class FirefoxIOS : Browser
    {
        public override string Name => BrowserNames.Firefox;

        public override string DeviceType => DeviceTypes.Mobile;

        /// <summary>
        /// Populates a Firefox browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain a Firefox object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out FirefoxIOS result)
        {
            var firefoxIndex = userAgent.IndexOf("FxiOS/".AsSpan());

            if (firefoxIndex > -1)
            {
                var sliceWithVersion = userAgent.Slice(firefoxIndex + 6);
                var versionEndIndex = sliceWithVersion.IndexOf(' ');
                var version = sliceWithVersion.Slice(0, versionEndIndex + 1).ToString();

                result = new FirefoxIPhone()
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
