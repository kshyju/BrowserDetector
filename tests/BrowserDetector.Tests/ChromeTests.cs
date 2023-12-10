namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Xunit;

    /// <summary>
    /// Tests for Chrome.
    /// </summary>
    public class ChromeTests
    {
        [Fact]
        public void Chrome_IPad()
        {
            var browser = new Chrome(UserAgents.ChromeIPad);

            Assert.True(browser.IsValid);
            Assert.Equal(BrowserNames.Chrome, browser.Name);
            Assert.Equal(DeviceTypes.Tablet, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }

        [Fact]
        public void Chrome_IPhone()
        {
            var browser = new Chrome(UserAgents.ChromeIPhone);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }

        [Fact]
        public void Chrome_Windows_Desktop()
        {
            var browser = new Chrome(UserAgents.ChromeWindows);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }

        [Fact]
        public void Chrome_Windows_Desktop_32Bit()
        {
            var browser = new Chrome(UserAgents.ChromeWindows32);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }

        [Fact]
        public void Chrome_OSX_Desktop()
        {
            var browser = new Chrome(UserAgents.ChromeOsx);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, browser.OS);
        }

        [Fact]
        public void Chrome_Pixel3()
        {
            var browser = new Chrome(UserAgents.ChromePixel3);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.Android, browser.OS);
        }

        [Fact]
        public void Chrome_Galaxy_Note8_Mobile()
        {
            var browser = new Chrome(UserAgents.ChromeGalaxyNote8Mobile);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.Android, browser.OS);
        }

        [Fact]
        public void Chrome_GalaxyTabS4()
        {
            var browser = new Chrome(UserAgents.ChromeGalaxyTabS4);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Tablet, browser.DeviceType);
            Assert.Equal(OperatingSystems.Android, browser.OS);
        }
    }
}
