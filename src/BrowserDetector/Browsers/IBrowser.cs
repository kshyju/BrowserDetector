namespace Shyjus.BrowserDetection.Browsers
{
    /// <summary>
    /// A type representing the browser information.
    /// </summary>
    public interface IBrowser
    {
        /// <summary>
        /// The device type.
        /// Possible values are
        /// 1. Desktop
        /// 2. Tablet
        /// 3. Mobile
        /// </summary>
        string DeviceType { get; }

        /// <summary>
        /// The browser name.
        /// Ex:"Chrome"
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The operating system.
        /// Ex:"Windows"
        /// </summary>
        string OS { get; }

        /// <summary>
        /// The browser version.
        /// </summary>
        string Version { get; }
    }
}