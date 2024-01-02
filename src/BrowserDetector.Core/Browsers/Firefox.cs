namespace Shyjus.BrowserDetector
{
    using Shyjus.BrowserDetector;
    using System;

    /// <summary>
    /// A type representing the FireFox browser instance.
    /// </summary>
    internal class Firefox : Browser
    {
        private Firefox(ReadOnlySpan<char> userAgent, string version)
    : base(userAgent, version)
        {
        }

        public string? Platform { get; }

        /// <inheritdoc/>
        public override string Name => BrowserNames.Firefox;

        /// <summary>
        /// Tries to build a Firefox browser instance from the user agent passed in and
        /// returns a value that indicates whether the parsing succeeded.
        /// </summary>
        /// <param name="userAgent">The user agent value.</param>
        /// <param name="result">A Firefox browser instance.</param>
        /// <returns>A boolean value that indicates whether the parsing succeeded.</returns>
        internal static bool TryParse(ReadOnlySpan<char> userAgent, out Firefox? result)
        {
            // Desktop version of Firefox.
            var fireFoxVersion = GetVersionIfKeyPresent(userAgent, "Firefox/");
            if (fireFoxVersion != null)
            {
                result = new Firefox(userAgent, fireFoxVersion);
                return true;
            }

            // IOS version of Firefox.
            var fxiosVersion = GetVersionIfKeyPresent(userAgent, "FxiOS/");
            if (fxiosVersion != null)
            {
                result = new Firefox(userAgent, fxiosVersion);
                return true;
            }

            result = null;
            return false;
        }
    }
}
