
namespace Shyjus.BrowserDetector
{
    using Shyjus.BrowserDetector;
    using System;

    /// <summary>
    /// Represents an instance of the chromium based Edge browser.
    /// </summary>
    internal class Edge : Browser
    {
        private Edge(ReadOnlySpan<char> userAgent, string version)
            : base(userAgent, version)
        {
        }

        /// <inheritdoc/>
        public override string Name => BrowserNames.EdgeChromium;

        /// <summary>
        /// Tries to build a EdgeChromium browser instance from the user agent passed in and
        /// returns a value that indicates whether the parsing succeeded.
        /// </summary>
        /// <param name="userAgent">The user agent value.</param>
        /// <param name="result">An EdgeChromium browser instance.</param>
        /// <returns>A boolean value that indicates whether the parsing succeeded.</returns>
        internal static bool TryParse(ReadOnlySpan<char> userAgent, out Edge? result)
        {
            var edgChromiumVersion = GetVersionIfKeyPresent(userAgent, "Edg/");

            if (edgChromiumVersion != null)
            {
                result = new Edge(userAgent, edgChromiumVersion);
                return true;
            }

            result = null;
            return false;
        }
    }
}
