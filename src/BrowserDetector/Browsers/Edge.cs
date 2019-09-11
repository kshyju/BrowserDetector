using System;

namespace Shyjus.BrowserDetection.Browsers
{
    /// <summary>
    /// Represents an instance of Edge Browser
    /// </summary>
    internal class Edge : Browser

    {
        public override string Name => BrowserNames.Edge;

        public Edge(ReadOnlySpan<char> userAgent, string version) : base(userAgent, version)
        {
        }

        public static bool TryParse(ReadOnlySpan<char> userAgent, out Browser result)
        {
            var edgeVersion = GetVersionIfKeyPresent(userAgent, "Edge/");
            var edgeIosVersion = GetVersionIfKeyPresent(userAgent, "EdgiOS/");

            if (edgeVersion != null || edgeIosVersion != null)
            {
                result = new Edge(userAgent, edgeVersion);
                return true;
            }

            result = null;
            return false;
        }
    }
}
