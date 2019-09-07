using System;

namespace Shyjus.BrowserDetector.Browsers
{
    /// <summary>
    /// Represents an instance of Opera Browser
    /// </summary>
    public class Opera : Browser

    {
        public override string Name => BrowserNames.Opera;

        public Opera(ReadOnlySpan<char> userAgent, string version) : base(userAgent, version)
        {
        }

        public static bool TryParse(ReadOnlySpan<char> userAgent, out Opera result)
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
                result = new Opera(userAgent, operaVersion);
                return true;
            }

            result = null;
            return false;
        }
    }
}
