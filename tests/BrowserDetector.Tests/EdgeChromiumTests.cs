using Shyjus.BrowserDetection;
using Shyjus.BrowserDetection.Browsers;
using Shyjus.BrowserDetection.Tests;
using Xunit;

namespace BrowserDetector.Tests
{
    public class EdgeChromiumTests
    {
        [Fact]
        public void EdgeChromium_OSX()
        {
            var isFireFox = EdgeChromium.TryParse(UserAgents.EdgeChromium_OSX, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Desktop, firefox.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, firefox.OS);
        }

        [Fact]
        public void EdgeChromium_Windows()
        {
            var isFireFox = EdgeChromium.TryParse(UserAgents.EdgeChrome_Windows, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Desktop, firefox.DeviceType);
            Assert.Equal(OperatingSystems.Windows, firefox.OS);
        }
    }
}
