namespace Shyjus.BrowserDetection
{
    /// <summary>
    /// A type representing the FireFox browser instance.
    /// </summary>
    internal class Firefox : Browser
    {
        /// <summary>
        /// Tries to build a Firefox browser instance from the user agent passed in and
        /// returns a value that indicates whether the parsing succeeded.
        /// </summary>
        /// <param name="userAgent">The user agent value.</param>
        /// <param name="result">A Firefox browser instance.</param>
        /// <returns>A boolean value that indicates whether the parsing succeeded.</returns>
        public Firefox(string userAgent)
    : base(userAgent)
        {
            Version = string.Empty;

            // Desktop version of Firefox.
            var fireFoxVersion = GetVersionIfKeyIsPresent(userAgent, "Firefox/");
            if (fireFoxVersion != null)
            {
                Version = fireFoxVersion;
                return;
            }

            // IOS version of Firefox.
            var fxiosVersion = GetVersionIfKeyIsPresent(userAgent, "FxiOS/");
            if (fxiosVersion != null)
                Version = fxiosVersion;
            
        }

        /// <inheritdoc/>
        public override string Name => BrowserNames.Firefox;

        public override string Version { get; }
    }
}
