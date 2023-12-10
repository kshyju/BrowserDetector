using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BrowserDetector.Benchmarks")]

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
        internal static IBrowser? GetBrowser(ReadOnlySpan<char> userAgentString)
        {
            // Order is important, Go from most specific to generic
            // For example, The string "Chrome" is present in both Chrome and Edge,
            // So we will first check if it is Edge because Edge has something more specific we can check.

            //TODO: neue Eigenschaft "OrderNumber" im Browser (Go from most specific to generic)
            //alle implemntierungen von Browser per reflaction holen und nach ordernumber sortieren
            //danach die liste durchlaufen und abbrechen, sobald eines valid ist

            var firefox = new Firefox(userAgentString);
            if (firefox.IsValid)
                return firefox;

            var edgeChromium = new EdgeChromium(userAgentString);
            if (edgeChromium.IsValid)
                return edgeChromium;

            var internetexplorer = new InternetExplorer(userAgentString);
            if (internetexplorer.IsValid)
                return internetexplorer;

            var opera = new Opera(userAgentString);
            if (opera.IsValid)
                return opera;

            var edge = new Edge(userAgentString);
            if (edge.IsValid)
                return edge;

            var chrome = new Chrome(userAgentString);
            if (chrome.IsValid)
                return chrome;

            var safari = new Safari(userAgentString);
            if (safari.IsValid)
                return safari;

            return default;
        }
    }
}
