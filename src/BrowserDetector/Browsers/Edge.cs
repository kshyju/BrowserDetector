namespace Shyjus.BrowserDetection.Browsers
{
    using System;

    /// <summary>
    /// Represents an instance of Edge Browser.
    /// </summary>
    internal class Edge : Browser
    {
        public Edge(ReadOnlySpan<char> userAgent, string version)
            : base(userAgent, version)
        {
        }

        public override string Name => BrowserNames.Edge;

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
