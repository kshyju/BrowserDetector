namespace Shyjus.BrowserDetector
{
    using Shyjus.BrowserDetector;
    using System;

    /// <summary>
    /// Represents an instance of EdgeLegacy Browser
    /// </summary>
    internal class InternetExplorer : Browser
    {
        private protected InternetExplorer(ReadOnlySpan<char> userAgent, string version)
            : base(userAgent, version)
        {
        }

        public override string Name => BrowserNames.InternetExplorer;

        /// <summary>
        /// Tries to build an instance of InternetExplorer browser from the user agent passed in and
        /// returns a value that indicates whether the parsing succeeded.
        /// </summary>
        /// <param name="userAgent">The user agent value.</param>
        /// <param name="result">An instance of EdgeChromium browser.</param>
        /// <returns>A boolean value that indicates whether the parsing succeeded.</returns>
        internal static bool TryParse(ReadOnlySpan<char> userAgent, out InternetExplorer? result)
        {
            var tridentVersion = GetVersionIfKeyPresent(userAgent, "Trident/");

            if (tridentVersion != null)
            {
                result = new InternetExplorer(userAgent, tridentVersion);
                return true;
            }

            result = null;
            return false;
        }
    }
}
