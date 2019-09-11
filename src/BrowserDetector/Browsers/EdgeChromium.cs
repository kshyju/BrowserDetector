using System;

namespace Shyjus.BrowserDetection.Browsers
{
    /// <summary>
    /// Represents an instance of EdgeChromium Browser
    /// </summary>
    internal class EdgeChromium : Browser

    {
        public override string Name => BrowserNames.EdgeChromium;

        public EdgeChromium(ReadOnlySpan<char> userAgent, string version) : base(userAgent, version)
        {
        }

        public static bool TryParse(ReadOnlySpan<char> userAgent, out EdgeChromium result)
        {
            var edgChromiumVersion = GetVersionIfKeyPresent(userAgent, "Edg/");

            if (edgChromiumVersion != null)
            {
                result = new EdgeChromium(userAgent, edgChromiumVersion);
                return true;
            }

            result = null;
            return false;
        }
    }
}
