using System;

namespace Shyjus.BrowserDetection.Browsers
{
    /// <summary>
    /// Represents an instance of Edge Browser
    /// </summary>
    internal class InternetExplorer : Browser

    {
        public override string Name => BrowserNames.InternetExplorer;

        public InternetExplorer(ReadOnlySpan<char> userAgent, string version) : base(userAgent, version)
        {
        }

        public static bool TryParse(ReadOnlySpan<char> userAgent, out InternetExplorer result)
        {
            var tridentVersion = GetVersionIfKeyPresent(userAgent, "Trident/");

            if (tridentVersion != null)
            {
                result = new InternetExplorer(userAgent, tridentVersion);
                return true;
            }

            result = null;
            return false;
        }
    }
}
