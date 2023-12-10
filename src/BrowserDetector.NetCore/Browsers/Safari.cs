namespace Shyjus.BrowserDetection
{
    using System;

    internal class Safari : Browser
    {
        /// <summary>
        /// Populates a Safari browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain a Safari object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        /// <exception cref="ArgumentNullException">Thrown when userAgent parameter value is null</exception>
        public Safari(ReadOnlySpan<char> userAgent)
            : base(userAgent)
        {
            Version = string.Empty;

            var chromeIndex = userAgent.IndexOf("Chrome/".AsSpan());
            var safariIndex = userAgent.IndexOf("Safari/".AsSpan());

            // Safari UA does not have the word "Chrome/"
            if (safariIndex <= -1 || chromeIndex > -1)
                return;

            Version = GetVersionIfKeyIsPresent(userAgent, "Safari/") ?? string.Empty;
        }

        public override string Name => BrowserNames.Safari;
        public override string Version { get; }
    }
}
