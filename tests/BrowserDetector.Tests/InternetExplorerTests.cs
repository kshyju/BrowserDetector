using Shyjus.BrowserDetection;
using Shyjus.BrowserDetection.Browsers;
using Shyjus.BrowserDetection.Tests;
using Xunit;

namespace BrowserDetector.Tests
{
    public class InternetExplorerTests
    {
        [Fact]
        public void IE11()
        {
            var isEdge = InternetExplorer.TryParse(UserAgents.IE11_Windows, out var edge);

            Assert.True(isEdge);
            Assert.Equal(BrowserNames.InternetExplorer, edge.Name);
            Assert.Equal(DeviceTypes.Desktop, edge.DeviceType);
            Assert.Equal(OperatingSystems.Windows, edge.OS);
        }

        
    }
}
