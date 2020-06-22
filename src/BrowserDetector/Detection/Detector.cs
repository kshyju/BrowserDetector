namespace Shyjus.BrowserDetection
{
    using System;

    /// <summary>
    /// The browser detector.
    /// </summary>
    internal static class Detector
    {
        /// <summary>
        /// Gets an IBrowser instance from the user agent string passed in.
        /// </summary>
        /// <param name="userAgentString">The user agent string.</param>
        /// <returns>An instance of IBrowser.</returns>
        internal static IBrowser GetBrowser(ReadOnlySpan<char> userAgentString)
        {
            // Order is important, Go from most specific to generic
            // For example, The string "Chrome" is present in both Chrome and Edge,
            // So we will first check if it is Edge because Edge has something more specific we can check.
            if (Firefox.TryParse(userAgentString, out var firefox))
            {
                return firefox;
            }

            if (EdgeChromium.TryParse(userAgentString, out var edgeChromium))
            {
                return edgeChromium;
            }

            if (InternetExplorer.TryParse(userAgentString, out var ie))
            {
                return ie;
            }

            if (Opera.TryParse(userAgentString, out var opera))
            {
                return opera;
            }

            if (Edge.TryParse(userAgentString, out var edge))
            {
                return edge;
            }

            if (Chrome.TryParse(userAgentString, out var chrome))
            {
                return chrome;
            }

            if (Safari.TryParse(userAgentString, out var safari))
            {
                return safari;
            }

            if (Instagram.TryParse(userAgentString, out var instagram))
            {
                return instagram;
            }

            return default;
        }
    }
}
