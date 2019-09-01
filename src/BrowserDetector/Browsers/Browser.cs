using System;

namespace Shyjus.BrowserDetector
{
    /// <summary>
    /// Represents the base version of a Browser instance
    /// </summary>
    public abstract class Browser
    {
        /// <summary>
        /// Browser type
        /// Ex: Chrome/Edge
        /// </summary>
        public abstract BrowserType Type { get; }

        /// <summary>
        /// Version information of the browser instance
        /// </summary>
        public Version Version { protected set; get; }

        /// <summary>
        /// The device type.
        /// Possible values are:
        ///     1. Mobile
        ///     2. Tablet
        ///     3. Desktop
        /// </summary>
        public DeviceType DeviceType { internal set; get; }
    }
}
