namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Shyjus.BrowserDetector;
    using Xunit;

    /// <summary>
    /// Tests for <see cref="Opera"/>.
    /// </summary>
    public class OperaTests
    {
        [Fact]
        public void Opera_OSX()
        {
            var isOpera = Opera.TryParse(UserAgents.OperaOsx, out var opera);

            Assert.True(isOpera);
            Assert.Equal(DeviceType.Desktop, opera.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, opera.OS);
        }

        [Fact]
        public void Opera_Windows()
        {
            var isOpera = Opera.TryParse(UserAgents.OperaWindows, out var operea);

            Assert.True(isOpera);
            Assert.Equal(DeviceType.Desktop, operea.DeviceType);
            Assert.Equal(OperatingSystems.Windows, operea.OS);
        }

        [Fact]
        public void Opera_IPhone()
        {
            var isOpera = Opera.TryParse(UserAgents.OperaTouchIPhone, out var opera);

            Assert.True(isOpera);
            Assert.Equal(DeviceType.Mobile, opera.DeviceType);
            Assert.Equal(OperatingSystems.IOS, opera.OS);
        }
    }
}
