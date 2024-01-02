namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Shyjus.BrowserDetector;
    using Xunit;

    /// <summary>
    /// Tests for Edge legacy browser.
    /// </summary>
    public sealed class EdgeLegacyTests
    {
        /// <summary>
        /// Verifies EdgeLegacy 18 in desktop.
        /// </summary>
        [Fact]
        public void Edge18_Windows()
        {
            var isEdge = EdgeLegacy.TryParse(UserAgents.Edge18Windows, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.EdgeLegacy, edge.Name);
            Assert.Equal(DeviceType.Desktop, edge.DeviceType);
            Assert.Equal(OperatingSystems.Windows, edge.OS);
        }

        /// <summary>
        /// Verifies EdgeLegacy in iPad.
        /// </summary>
        [Fact]
        public void Edge_IPad()
        {
            var isEdge = EdgeLegacy.TryParse(UserAgents.EdgeIPad, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.EdgeLegacy, edge.Name);
            Assert.Equal(DeviceType.Tablet, edge.DeviceType);
            Assert.Equal(OperatingSystems.IOS, edge.OS);
        }

        /// <summary>
        /// Verifies EdgeLegacy in iPhone.
        /// </summary>
        [Fact]
        public void Edge_IPhone()
        {
            var isEdge = EdgeLegacy.TryParse(UserAgents.EdgeIPhone, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.EdgeLegacy, edge.Name);
            Assert.Equal(DeviceType.Mobile, edge.DeviceType);
            Assert.Equal(OperatingSystems.IOS, edge.OS);
        }
    }
}
