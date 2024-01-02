namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Shyjus.BrowserDetector;
    using Xunit;

    public class EdgeChromiumTests
    {
        [Fact]
        public void EdgeChromium_OSX()
        {
            var isEdgeChromium = Edge.TryParse(UserAgents.EdgeChromiumOsx, out var edgeChromium);

            Assert.True(isEdgeChromium);
            Assert.Equal(DeviceType.Desktop, edgeChromium.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, edgeChromium.OS);
        }

        [Fact]
        public void EdgeChromium_Windows()
        {
            var isEdgeChromium = Edge.TryParse(UserAgents.EdgeChromeWindows, out var edgeChromium);

            Assert.True(isEdgeChromium);
            Assert.Equal(DeviceType.Desktop, edgeChromium.DeviceType);
            Assert.Equal(OperatingSystems.Windows, edgeChromium.OS);
        }
    }
}
