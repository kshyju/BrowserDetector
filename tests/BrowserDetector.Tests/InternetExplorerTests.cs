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
            var browser = new InternetExplorer(UserAgents.Ie11Windows);

            Assert.True(browser.IsValid);
            Assert.Equal(BrowserNames.InternetExplorer, browser.Name);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }
    }
}
