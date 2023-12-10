namespace Shyjus.BrowserDetection
{
    using System;

    /// <summary>
    /// Represents an instance of EdgeChromium Browser.
    /// </summary>
    internal class EdgeChromium : Browser
    {
        /// <summary>
        /// Tries to build a EdgeChromium browser instance from the user agent passed in and
        /// returns a value that indicates whether the parsing succeeded.
        /// </summary>
        /// <param name="userAgent">The user agent value.</param>
        /// <param name="result">An EdgeChromium browser instance.</param>
        /// <returns>A boolean value that indicates whether the parsing succeeded.</returns>
        public EdgeChromium(ReadOnlySpan<char> userAgent)
            : base(userAgent)
        {
            Version = GetVersionIfKeyIsPresent(userAgent, "Edg/") ?? string.Empty;
        }

        /// <inheritdoc/>
        public override string Name => BrowserNames.EdgeChromium;

        public override string Version { get; }
    }
}
