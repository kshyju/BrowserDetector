using Shyjus.BrowserDetector;
using Shyjus.BrowserDetector.Browsers;
using Shyjus.BrowserDetector.Tests;
using Xunit;

namespace BrowserDetector.Tests
{
    public class ChromeTests
    {
        [Fact]
        public void Chrome_IPad()
        {
            var isFireFox = Chrome.TryParse(UserAgents.Chrome_IPad, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Tablet, firefox.DeviceType);
            Assert.Equal(OperatingSystems.IOS, firefox.OS);
        }
        [Fact]
        public void Chrome_IPhone()
        {
            var isFireFox = Chrome.TryParse(UserAgents.Chrome_IPhone, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Mobile, firefox.DeviceType);
            Assert.Equal(OperatingSystems.IOS, firefox.OS);
        }
        [Fact]
        public void Chrome_Windows_Desktop()
        {
            var isFireFox = Chrome.TryParse(UserAgents.Chrome_Windows, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Desktop, firefox.DeviceType);
            Assert.Equal(OperatingSystems.Windows, firefox.OS);
        }

        [Fact]
        public void Chrome_OSX_Desktop()
        {
            var isFireFox = Chrome.TryParse(UserAgents.Chrome_OSX, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Desktop, firefox.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, firefox.OS);
        }

        [Fact]
        public void Chrome_Pixel3()
        {
            var isFireFox = Chrome.TryParse(UserAgents.Chrome_Pixel3, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Mobile, firefox.DeviceType);
            Assert.Equal(OperatingSystems.Android, firefox.OS);
        }
    }
}
