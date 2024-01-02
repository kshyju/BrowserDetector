namespace Shyjus.BrowserDetector
{
    /// <summary>
    /// A type representing the browser information.
    /// </summary>
    public interface IBrowser
    {
        /// <summary>
        /// Gets the device type.
        /// </summary>
        DeviceType DeviceType { get; }

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
        /// Gets a string representation of the IBrowser instance.
        /// </summary>
        /// <returns></returns>
        string? ToString();
    }
}
