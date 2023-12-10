namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Xunit;

    public class FirefoxTests
    {
        [Fact]
        public void Firefox_Windows_Desktop()
        {
            var browser = new Firefox(UserAgents.FirefoxWindows);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }

        [Fact]
        public void Firefox_OSX_Desktop()
        {
            var browser = new Firefox(UserAgents.FirefoxOsx);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, browser.OS);
        }

        [Fact]
        public void Firefox_IOS_iPhone()
        {
            var browser = new Firefox(UserAgents.FirefoxIPhone);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }

        [Fact]
        public void Firefox_IOS_iPad()
        {
            var browser = new Firefox(UserAgents.FirefoxIPad);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Tablet, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }
        
        [Fact]
        public void Firefox_Android()
        {
            var isFireFox = Firefox.TryParse(UserAgents.FirefoxAndroid, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Mobile, firefox.DeviceType);
            Assert.Equal(OperatingSystems.Android, firefox.OS);
        }
    }
}
