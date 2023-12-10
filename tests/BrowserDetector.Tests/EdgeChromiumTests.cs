namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Xunit;

    public class EdgeChromiumTests
    {
        [Fact]
        public void EdgeChromium_OSX()
        {
            var browser = new EdgeChromium(UserAgents.EdgeChromiumOsx);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, browser.OS);
        }

        [Fact]
        public void EdgeChromium_Windows()
        {
            var browser = new EdgeChromium(UserAgents.EdgeChromeWindows);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }
    }
}
