using System;
namespace Shyjus.BrowserDetector.Browsers
{
    public class InternetExplorer : Browser
    {
        public override BrowserType Type => throw new System.NotImplementedException();

        /// <summary>
        /// Populates an IE browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeeded.
        /// </summary>
        /// <param name="userAgent">User agent value</param>
        /// <param name="result">When this method returns True, the result will contain an IE object populated</param>
        /// <returns>True if parsing succeeded, else False</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out InternetExplorer result)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            var tridentIndex = userAgent.IndexOf("Trident/".AsSpan());

            if (tridentIndex > -1)
            {
                var rvIndex = userAgent.IndexOf("rv:".AsSpan());
                var subStringWithVersion = userAgent.Slice(rvIndex + 3);
                var endOfVersionIndex = subStringWithVersion.IndexOf(')');

                if (endOfVersionIndex > -1)
                {
                    var version = subStringWithVersion.Slice(0, endOfVersionIndex).ToString();

                    result = new InternetExplorer
                    {
                        Version = Version.Parse(version)
                    };

                    return true;
                }
            }

            result = null;

            return false;
        }

    }
}
