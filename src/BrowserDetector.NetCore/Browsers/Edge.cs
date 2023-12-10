namespace Shyjus.BrowserDetection
{
    /// <summary>
    /// Represents an instance of Edge Browser.
    /// </summary>
    internal class Edge : Browser
    {
        /// <summary>
        /// Tries to create an Edge browser object from the user agent passed in.
        /// </summary>
        /// <param name="userAgent">The user agent.</param>
        /// <param name="result">An instance of Edge browser, if parsing was successful.</param>
        /// <returns>A boolean value indicating whether the parsing was successful.</returns>
        public Edge(string userAgent)
            : base(userAgent)
        {
            var edgeVersion = GetVersionIfKeyIsPresent(userAgent, "Edge/");
            var edgeIosVersion = GetVersionIfKeyIsPresent(userAgent, "EdgiOS/");
            var edgeAndroidVersion = GetVersionIfKeyIsPresent(userAgent, "EdgA/");

            Version = edgeVersion ?? edgeIosVersion ?? edgeAndroidVersion ?? string.Empty;
        }

        /// <inheritdoc/>
        public override string Name => BrowserNames.Edge;
        public override string Version { get; }
    }
}
