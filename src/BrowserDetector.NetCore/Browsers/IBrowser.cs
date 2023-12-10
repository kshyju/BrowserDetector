namespace Shyjus.BrowserDetection
{
    /// <summary>
    /// A type representing the browser information.
    /// </summary>
    public interface IBrowser
    {
        /// <summary>
        /// Gets the device type.
        /// Possible values are
        /// 1. Desktop
        /// 2. Tablet
        /// 3. Mobile
        /// </summary>
        string DeviceType { get; }

        /// <summary>
        /// Gets the browser name.
        /// Ex:"Chrome"
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the operating system.
        /// Ex:"Windows"
        /// </summary>
        string OS { get; }

        /// <summary>
        /// Gets the browser version.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Check for valid parsing of user-agent-string.
        /// </summary>
        public bool IsValid { get; }
    }
}