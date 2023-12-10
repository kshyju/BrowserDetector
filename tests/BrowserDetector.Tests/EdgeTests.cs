namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Xunit;

    /// <summary>
    /// Tests for Edge browser.
    /// </summary>
    public sealed class EdgeTests
    {
        /// <summary>
        /// Verifies Edge 18 in desktop.
        /// </summary>
        [Fact]
        public void Edge18_Windows()
        {
            var browser = new Edge(UserAgents.Edge18Windows);

            Assert.True(browser.IsValid);
            Assert.Equal(BrowserNames.Edge, browser.Name);
            Assert.Equal(DeviceTypes.Desktop, browser.DeviceType);
            Assert.Equal(OperatingSystems.Windows, browser.OS);
        }

        /// <summary>
        /// Verifies Edge in iPad.
        /// </summary>
        [Fact]
        public void Edge_IPad()
        {
            var browser = new Edge(UserAgents.EdgeIPad);

            Assert.True(browser.IsValid);
            Assert.Equal(BrowserNames.Edge, browser.Name);
            Assert.Equal(DeviceTypes.Tablet, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }

        /// <summary>
        /// Verifies Edge in iPhone.
        /// </summary>
        [Fact]
        public void Edge_IPhone()
        {
            var browser = new Edge(UserAgents.EdgeIPhone);

            Assert.True(browser.IsValid);
            Assert.Equal(BrowserNames.Edge, browser.Name);
            Assert.Equal(DeviceTypes.Mobile, browser.DeviceType);
            Assert.Equal(OperatingSystems.IOS, browser.OS);
        }
    }
}
