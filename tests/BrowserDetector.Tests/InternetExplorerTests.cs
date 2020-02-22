namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Xunit;

    /// <summary>
    /// Tests for IE.
    /// </summary>
    public class InternetExplorerTests
    {
        [Fact]
        public void IE11()
        {
            var isInternetExplorer = InternetExplorer.TryParse(UserAgents.IE11_Windows, out var internetExplorer);

            Assert.True(isInternetExplorer);
            Assert.Equal(BrowserNames.InternetExplorer, internetExplorer.Name);
            Assert.Equal(DeviceTypes.Desktop, internetExplorer.DeviceType);
            Assert.Equal(OperatingSystems.Windows, internetExplorer.OS);
        }
    }
}
