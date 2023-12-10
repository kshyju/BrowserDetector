namespace Shyjus.BrowserDetection
{
    using System;

    /// <summary>
    /// Represents an instance of Edge Browser
    /// </summary>
    internal class InternetExplorer : Browser
    {
        /// <summary>
        /// Tries to build an instance of InternetExplorer browser from the user agent passed in and
        /// returns a value that indicates whether the parsing succeeded.
        /// </summary>
        /// <param name="userAgent">The user agent value.</param>
        /// <param name="result">An instance of EdgeChromium browser.</param>
        /// <returns>A boolean value that indicates whether the parsing succeeded.</returns>
        public InternetExplorer(ReadOnlySpan<char> userAgent)
            : base(userAgent)
        {
            Version = GetVersionIfKeyIsPresent(userAgent, "Trident/") ?? string.Empty;
        }

        public override string Name => BrowserNames.InternetExplorer;
        public override string Version { get; }
    }
}
