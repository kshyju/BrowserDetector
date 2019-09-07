using Shyjus.BrowserDetector;
using Shyjus.BrowserDetector.Browsers;
using Shyjus.BrowserDetector.Tests;
using Xunit;

namespace BrowserDetector.Tests
{
    public class InternetExplorerTests
    {
        [Fact]
        public void IE11_OSX()
        {
            var isEdge = InternetExplorer.TryParse(UserAgents.IE11_Windows, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.InternetExplorer, edge.Name);
            Assert.Equal(DeviceTypes.Desktop, edge.DeviceType);
            Assert.Equal(OperatingSystems.Windows, edge.OS);
        }
    }
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
