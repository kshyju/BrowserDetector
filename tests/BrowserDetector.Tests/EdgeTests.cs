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
            var isEdge = Edge.TryParse(UserAgents.Edge18Windows, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.Edge, edge.Name);
            Assert.Equal(DeviceTypes.Desktop, edge.DeviceType);
            Assert.Equal(OperatingSystems.Windows, edge.OS);
        }

        /// <summary>
        /// Verifies Edge in iPad.
        /// </summary>
        [Fact]
        public void Edge_IPad()
        {
            var isEdge = Edge.TryParse(UserAgents.EdgeIPad, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.Edge, edge.Name);
            Assert.Equal(DeviceTypes.Tablet, edge.DeviceType);
            Assert.Equal(OperatingSystems.IOS, edge.OS);
        }

        /// <summary>
        /// Verifies Edge in iPhone.
        /// </summary>
        [Fact]
        public void Edge_IPhone()
        {
            var isEdge = Edge.TryParse(UserAgents.EdgeIPhone, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.Edge, edge.Name);
            Assert.Equal(DeviceTypes.Mobile, edge.DeviceType);
            Assert.Equal(OperatingSystems.IOS, edge.OS);
        }
    }
}
