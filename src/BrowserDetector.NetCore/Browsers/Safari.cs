namespace Shyjus.BrowserDetection
{
    using System;

    internal class Safari : Browser
    {
        private Safari(ReadOnlySpan<char> userAgent, string version)
            : base(userAgent, version)
        {
        }

        public override string Name => BrowserNames.Safari;

        /// <summary>
        /// Populates a Safari browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain a Safari object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        /// <exception cref="ArgumentNullException">Thrown when userAgent parameter value is null</exception>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out Safari result)
        {
            var chromeIndex = userAgent.IndexOf("Chrome/".AsSpan());
            var safariIndex = userAgent.IndexOf("Safari/".AsSpan());

            // Safari UA does not have the word "Chrome/"
            if (safariIndex > -1 && chromeIndex == -1)
            {
                var fireFoxVersion = GetVersionIfKeyPresent(userAgent, "Safari/");
                if (fireFoxVersion != null)
                {
                    result = new Safari(userAgent, fireFoxVersion);
                    return true;
                }
            }

            result = null;
            return false;
        }
    }
}
