using Shyjus.BrowserDetection;
using Shyjus.BrowserDetection.Browsers;
using Shyjus.BrowserDetection.Tests;
using Xunit;

namespace BrowserDetector.Tests
{
    public class ChromeTests
    {
        [Fact]
        public void Chrome_IPad()
        {
            var isChrome = Chrome.TryParse(UserAgents.Chrome_IPad, out var browser);

            Assert.True(isChrome);
            Assert.Equal(BrowserNames.Chrome, browser.Name);
            Assert.Equal(DeviceTypes.Tablet, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }
        [Fact]
        public void Chrome_IPhone()
        {
            var isChrome = Chrome.TryParse(UserAgents.Chrome_IPhone, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceTypes.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }
        [Fact]
        public void Chrome_Windows_Desktop()
        {
            var isChrome = Chrome.TryParse(UserAgents.Chrome_Windows, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }

        [Fact]
        public void Chrome_OSX_Desktop()
        {
            var isChrome = Chrome.TryParse(UserAgents.Chrome_OSX, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, browser.OS);
        }

        [Fact]
        public void Chrome_Pixel3()
        {
            var isChrome = Chrome.TryParse(UserAgents.Chrome_Pixel3, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceTypes.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.Android, browser.OS);
        }
    }
}
