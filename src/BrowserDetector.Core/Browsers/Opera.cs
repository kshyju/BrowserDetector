namespace Shyjus.BrowserDetector
{
    using System;

    /// <summary>
    /// Represents an instance of Opera Browser.
    /// </summary>
    internal class Opera : Browser
    {
        private protected Opera(ReadOnlySpan<char> userAgent, string version)
            : base(userAgent, version)
        {
        }

        public override string Name => BrowserNames.Opera;

        /// <summary>
        /// Tries to build an instance of Opera browser from the user agent passed in and
        /// returns a value that indicates whether the parsing succeeded.
        /// </summary>
        /// <param name="userAgent">The user agent value.</param>
        /// <param name="result">An instance of Opera browser.</param>
        /// <returns>A boolean value that indicates whether the parsing succeeded.</returns>
        internal static bool TryParse(ReadOnlySpan<char> userAgent, out Opera? result)
        {
            var operaVersion = GetVersionIfKeyPresent(userAgent, "OPR/");
            var operaTouchVersion = GetVersionIfKeyPresent(userAgent, " OPT/");

            if (operaVersion != null)
            {
                result = new Opera(userAgent, operaVersion);
                return true;
            }

            if (operaTouchVersion != null)
            {
                result = new Opera(userAgent, operaTouchVersion);
                return true;
            }

            result = null;
            return false;
        }
    }
}
