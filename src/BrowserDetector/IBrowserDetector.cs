using Shyjus.BrowserDetector.Browsers;

namespace Shyjus.BrowserDetector
{
    public interface IBrowserDetector
    {
        /// <summary>
        /// Gets the browser for the current HTTP request.
        /// </summary>
        Browser Browser { get; }
    }
}
