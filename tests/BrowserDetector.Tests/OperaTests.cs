namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Xunit;

    /// <summary>
    /// Tests for <see cref="Opera"/>.
    /// </summary>
    public class OperaTests
    {
        [Fact]
        public void Opera_OSX()
        {
            var browser = new Opera(UserAgents.OperaOsx);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, browser.OS);
        }

        [Fact]
        public void Opera_Windows()
        {
            var browser = new Opera(UserAgents.OperaWindows);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }

        [Fact]
        public void Opera_IPhone()
        {
            var browser = new Opera(UserAgents.OperaTouchIPhone);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }
    }
}
