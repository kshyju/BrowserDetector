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
            var browser = new Safari(UserAgents.SafariIPad);

            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Tablet, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }

        [Fact]
        public void Safari_IPhone()
        {
            var browser = new Safari(UserAgents.SafariIPhone);


            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }

        [Fact]
        public void Safari_OSX()
        {
            var browser = new Safari(UserAgents.Safari12Osx);


            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, browser.OS);
        }

        [Fact]
        public void Safari_Windows()
        {
            var browser = new Safari(UserAgents.Safari12Windows);


            Assert.True(browser.IsValid);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }
    }
}
