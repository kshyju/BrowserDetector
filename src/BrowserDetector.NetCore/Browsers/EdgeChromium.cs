using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BrowserDetector.Tests")]

namespace Shyjus.BrowserDetection
{
    using System;

    /// <summary>
    /// Represents an instance of EdgeChromium Browser.
    /// </summary>
    internal class EdgeChromium : Browser
    {
        private EdgeChromium(ReadOnlySpan<char> userAgent, string version)
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
        public static bool TryParse(ReadOnlySpan<char> userAgent, out EdgeChromium result)
        {
            var edgChromiumVersion = GetVersionIfKeyPresent(userAgent, "Edg/");

            if (edgChromiumVersion != null)
            {
                result = new EdgeChromium(userAgent, edgChromiumVersion);
                return true;
            }

            result = null;
            return false;
        }
    }
}
