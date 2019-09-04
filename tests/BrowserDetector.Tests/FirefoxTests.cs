using Shyjus.BrowserDetector;
using Shyjus.BrowserDetector.Browsers;
using Shyjus.BrowserDetector.Tests;
using Xunit;
using Xunit.Sdk;

namespace BrowserDetector.Tests
{
    public class FirefoxTests
    {

        [Fact]
        public void Firefox_Windows_Desktop()
        {
            var isFireFox = Firefox.TryParse(UserAgents.Firefox_Windows, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Desktop, firefox.DeviceType);
            Assert.Equal(OperatingSystems.Win64, firefox.OS);
        }

        [Fact]
        public void Firefox_Windows_Desktop()
        {
            var isFireFox = Firefox.TryParse(UserAgents.Firefox_Windows, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceTypes.Desktop, firefox.DeviceType);
            Assert.Equal(OperatingSystems.Win64, firefox.OS);
        }
    }
}
