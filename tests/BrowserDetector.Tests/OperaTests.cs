using Shyjus.BrowserDetector;
using Shyjus.BrowserDetector.Browsers;
using Shyjus.BrowserDetector.Tests;
using Xunit;

namespace BrowserDetector.Tests
{
    public class OperaTests
    {
        [Fact]
        public void Opera_OSX()
        {
            var isOpera = Opera.TryParse(UserAgents.Opera_OSX, out var opera);

            Assert.True(isOpera);
            Assert.Equal(DeviceTypes.Desktop, opera.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, opera.OS);
        }

        [Fact]
        public void Opera_Windows()
        {
            var isOpera = Opera.TryParse(UserAgents.Opera_Windows, out var operea);

            Assert.True(isOpera);
            Assert.Equal(DeviceTypes.Desktop, operea.DeviceType);
            Assert.Equal(OperatingSystems.Windows, operea.OS);
        }

        [Fact]
        public void Opera_IPhone()
        {
            var isOpera = Opera.TryParse(UserAgents.OperaTouch_IPhone, out var opera);

            Assert.True(isOpera);
            Assert.Equal(DeviceTypes.Mobile, opera.DeviceType);
            Assert.Equal(OperatingSystems.IOS, opera.OS);
        }
    }
}
