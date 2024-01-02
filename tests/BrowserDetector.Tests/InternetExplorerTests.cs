namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Shyjus.BrowserDetector;
    using Xunit;

    /// <summary>
    /// Tests for IE.
    /// </summary>
    public class InternetExplorerTests
    {
        [Fact]
        public void IE11()
        {
            var isInternetExplorer = InternetExplorer.TryParse(UserAgents.Ie11Windows, out var internetExplorer);

            Assert.True(isInternetExplorer);
            Assert.Equal(BrowserNames.InternetExplorer, internetExplorer.Name);
            Assert.Equal(DeviceType.Desktop, internetExplorer.DeviceType);
            Assert.Equal(OperatingSystems.Windows, internetExplorer.OS);
        }
    }
}
