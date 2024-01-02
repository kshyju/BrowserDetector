namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Shyjus.BrowserDetector;
    using Xunit;

    /// <summary>
    /// Tests for Chrome.
    /// </summary>
    public class ChromeTests
    {
        [Fact]
        public void Chrome_IPad()
        {
            var isChrome = Chrome.TryParse(UserAgents.ChromeIPad, out var browser);

            Assert.True(isChrome);
            Assert.Equal(BrowserNames.Chrome, browser.Name);
            Assert.Equal(DeviceType.Tablet, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }

        [Fact]
        public void Chrome_IPhone()
        {
            var isChrome = Chrome.TryParse(UserAgents.ChromeIPhone, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceType.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }

        [Fact]
        public void Chrome_Windows_Desktop()
        {
            var isChrome = Chrome.TryParse(UserAgents.ChromeWindows, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceType.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }

        [Fact]
        public void Chrome_Windows_Desktop_32Bit()
        {
            var isChrome = Chrome.TryParse(UserAgents.ChromeWindows32, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceType.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }

        [Fact]
        public void Chrome_OSX_Desktop()
        {
            var isChrome = Chrome.TryParse(UserAgents.ChromeOsx, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceType.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, browser.OS);
        }

        [Fact]
        public void Chrome_Pixel3()
        {
            var isChrome = Chrome.TryParse(UserAgents.ChromePixel3, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceType.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.Android, browser.OS);
        }

        [Fact]
        public void Chrome_Galaxy_Note8_Mobile()
        {
            var isChrome = Chrome.TryParse(UserAgents.ChromeGalaxyNote8Mobile, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceType.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.Android, browser.OS);
        }

        [Fact]
        public void Chrome_GalaxyTabS4()
        {
            var isChrome = Chrome.TryParse(UserAgents.ChromeGalaxyTabS4, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceType.Tablet, browser.DeviceType);
            Assert.Equal(OperatingSystems.Android, browser.OS);
        }
    }
}
