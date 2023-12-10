namespace Shyjus.BrowserDetection
{
    using System;

    /// <summary>
    /// Represents an instance of Edge Browser.
    /// </summary>
    internal class Edge : Browser
    {
        private Edge(ReadOnlySpan<char> userAgent, string version)
            : base(userAgent, version)
        {
        }

        /// <inheritdoc/>
        public override string Name => BrowserNames.Edge;

        /// <summary>
        /// Tries to create an Edge browser object from the user agent passed in.
        /// </summary>
        /// <param name="userAgent">The user agent.</param>
        /// <param name="result">An instance of Edge browser, if parsing was successful.</param>
        /// <returns>A boolean value indicating whether the parsing was successful.</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out Browser result)
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

            result = new Edge(userAgent, version);
            return true;
        }
    }
}
