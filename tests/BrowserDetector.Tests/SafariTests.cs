namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Xunit;

    public class SafariTests
    {
        [Fact]
        public void Safari_IPad()
        {
            var isSafari = Safari.TryParse(UserAgents.Safari_IPad, out var safari);

            Assert.True(isSafari);
            Assert.Equal(DeviceTypes.Tablet, safari.DeviceType);
            Assert.Equal(OperatingSystems.IOS, safari.OS);
        }

        [Fact]
        public void Safari_IPhone()
        {
            var isSafari = Safari.TryParse(UserAgents.Safari_IPhone, out var safari);

            Assert.True(isSafari);
            Assert.Equal(DeviceTypes.Mobile, safari.DeviceType);
            Assert.Equal(OperatingSystems.IOS, safari.OS);
        }

        [Fact]
        public void Safari_OSX()
        {
            var isSafari = Safari.TryParse(UserAgents.Safari12_OSX, out var safari);

            Assert.True(isSafari);
            Assert.Equal(DeviceTypes.Desktop, safari.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, safari.OS);
        }

        [Fact]
        public void Safari_Windows()
        {
            var isSafari = Safari.TryParse(UserAgents.Safari12_Windows, out var safari);

            Assert.True(isSafari);
            Assert.Equal(DeviceTypes.Desktop, safari.DeviceType);
            Assert.Equal(OperatingSystems.Windows, safari.OS);
        }
    }
}
