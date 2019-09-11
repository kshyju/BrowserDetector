using Shyjus.BrowserDetection;
using Shyjus.BrowserDetection.Browsers;
using Shyjus.BrowserDetection.Tests;
using Xunit;

namespace BrowserDetector.Tests
{
    public class EdgeTests
    {
        [Fact]
        public void Edge_OSX()
        {
            var isEdge = Edge.TryParse(UserAgents.Edge18_Windows, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.Edge, edge.Name);
            Assert.Equal(DeviceTypes.Desktop, edge.DeviceType);
            Assert.Equal(OperatingSystems.Windows, edge.OS);
        }

        [Fact]
        public void Edge_IPad()
        {
            var isEdge = Edge.TryParse(UserAgents.Edge_IPad, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.Edge, edge.Name);
            Assert.Equal(DeviceTypes.Tablet, edge.DeviceType);
            Assert.Equal(OperatingSystems.IOS, edge.OS);
        }
    }
}
