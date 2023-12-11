using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BrowserDetector.Benchmarks")]

namespace Shyjus.BrowserDetection
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The browser detector.
    /// </summary>
    internal static class Detector
    {
        // Order is important, Go from most specific to generic
        // For example, The string "Chrome" is present in both Chrome and Edge,
        // So we will first check if it is Edge because Edge has something more specific we can check.
        private readonly static IList<Type> browserTypeList = new List<Type>()
            {
                typeof(Firefox),
                typeof(EdgeChromium),
                typeof(InternetExplorer),
                typeof(Opera),
                typeof(Edge),
                typeof(Chrome),
                typeof(Safari)
            };

        /// <summary>
        /// Gets an IBrowser instance from the user agent string passed in.
        /// </summary>
        /// <param name="userAgentString">The user agent string.</param>
        /// <returns>An instance of IBrowser.</returns>
        internal static IBrowser? GetBrowser(string userAgentString)
        {
            //span is not possible for activator
            //var span = userAgentString.AsSpan();

            foreach (var type in browserTypeList)
            {
                var browser = Activator.CreateInstance(type, userAgentString) as Browser;

                if (browser?.IsValid == true)
                    return browser;
            }

            return default;
        }
    }
}
