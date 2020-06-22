namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Xunit;

    /// <summary>
    /// Tests for Instagram.
    /// </summary>
    public class InstagramTests
    {
        [Fact]
        public void Instagram_IPad()
        {
            var isInstagram = Instagram.TryParse(UserAgents.Instagram_IPad, out var browser);

            Assert.True(isInstagram);
            Assert.Equal(BrowserNames.Instagram, browser.Name);
            Assert.Equal(DeviceTypes.Tablet, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }

        [Fact]
        public void Instagram_IPhone()
        {
            var isChrome = Instagram.TryParse(UserAgents.Instagram_IPhone, out var browser);

            Assert.True(isChrome);
            Assert.Equal(DeviceTypes.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }
    }
}
