namespace Shyjus.BrowserDetection
{
    /// <summary>
    /// An abstraction to get browser information.
    /// </summary>
    public interface IBrowserDetector
    {
        /// <summary>
        /// Gets the browser for the current HTTP request.
        /// </summary>
        IBrowser Browser { get; }
    }
}
