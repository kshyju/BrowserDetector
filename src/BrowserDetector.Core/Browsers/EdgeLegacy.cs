namespace Shyjus.BrowserDetector
{
    using System;

    /// <summary>
    /// Represents an instance of EdgeLegacy Browser.
    /// </summary>
    internal class EdgeLegacy : Browser
    {
        private EdgeLegacy(ReadOnlySpan<char> userAgent, string version)
            : base(userAgent, version)
        {
        }

        /// <inheritdoc/>
        public override string Name => BrowserNames.EdgeLegacy;

        /// <summary>
        /// Tries to create an EdgeLegacy browser object from the user agent passed in.
        /// </summary>
        /// <param name="userAgent">The user agent.</param>
        /// <param name="result">An instance of EdgeLegacy browser, if parsing was successful.</param>
        /// <returns>A boolean value indicating whether the parsing was successful.</returns>
        internal static bool TryParse(ReadOnlySpan<char> userAgent, out Browser? result)
        {
            var edgeVersion = GetVersionIfKeyPresent(userAgent, "Edge/");
            var edgeIosVersion = GetVersionIfKeyPresent(userAgent, "EdgiOS/");
            var edgeAndroidVersion = GetVersionIfKeyPresent(userAgent, "EdgA/");

            var version = edgeVersion ?? edgeIosVersion ?? edgeAndroidVersion;

            if (version == null)
            {
                result = null;
                return false;
            }

            result = new EdgeLegacy(userAgent, version);
            return true;
        }
    }
}
