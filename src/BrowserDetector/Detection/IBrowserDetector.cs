using Shyjus.BrowserDetection.Browsers;

namespace Shyjus.BrowserDetection
{
    public interface IBrowserDetector
    {
        /// <summary>
        /// Gets the browser for the current HTTP request.
        /// </summary>
        IBrowser Browser { get; }
    }
}
