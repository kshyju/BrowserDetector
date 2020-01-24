using Shyjus.BrowserDetection;
using Shyjus.BrowserDetection.Browsers;
using Shyjus.BrowserDetection.Tests;
using Xunit;

namespace BrowserDetector.Tests
{
    public class EdgeTests
    {
        [Fact]
        public void Edge18_Windows()
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

        [Fact]
        public void Edge_IPhone()
        {
            var isEdge = Edge.TryParse(UserAgents.Edge_IPhone, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.Edge, edge.Name);
            Assert.Equal(DeviceTypes.Mobile, edge.DeviceType);
            Assert.Equal(OperatingSystems.IOS, edge.OS);
        }


        //[Fact]
        //public void Edge_SamsungGalaxy7()
        //{
        //    var isEdge = Edge.TryParse(UserAgents.EdgeChromium_Android8_SamsungGalaxyS7, out var edge);

        //    Assert.True(isEdge);
        //    Assert.Equal(BrowserNames.Edge, edge.Name);
        //    Assert.Equal(DeviceTypes.Mobile, edge.DeviceType);
        //    Assert.Equal(OperatingSystems.Android, edge.OS);
        //}
        //[Fact]
        //public void Edge_SamsungGalaxyS9()
        //{
        //    var isEdge = Edge.TryParse(UserAgents.EdgeChromium_Android9_SamsungGalaxyS9, out var edge);

        //    Assert.True(isEdge);
        //    Assert.Equal(BrowserNames.Edge, edge.Name);
        //    Assert.Equal(DeviceTypes.Mobile, edge.DeviceType);
        //    Assert.Equal(OperatingSystems.Android, edge.OS);
        //}
    }
}
