using Shyjus.BrowserDetector;
using Shyjus.BrowserDetector.Browsers;
using Shyjus.BrowserDetector.Tests;
using Xunit;

namespace BrowserDetector.Tests
{
    public class SafariTests
    {
        [Fact]
        public void Safari_IPad()
        {
            var isFireFox = Safari.TryParse(UserAgents.Safari_IPad, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Tablet, firefox.DeviceType);
            Assert.Equal(OperatingSystems.IOS, firefox.OS);
        }

        [Fact]
        public void Safari_IPhone()
        {
            var isFireFox = Safari.TryParse(UserAgents.Safari_IPhone, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Mobile, firefox.DeviceType);
            Assert.Equal(OperatingSystems.IOS, firefox.OS);
        }

        [Fact]
        public void Safari_OSX()
        {
            var isFireFox = Safari.TryParse(UserAgents.Safari12_OSX, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Desktop, firefox.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, firefox.OS);
        }
        [Fact]
        public void Safari_Windows()
        {
            var isFireFox = Safari.TryParse(UserAgents.Safari12_Windows, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Desktop, firefox.DeviceType);
            Assert.Equal(OperatingSystems.Windows, firefox.OS);
        }
    }
}
