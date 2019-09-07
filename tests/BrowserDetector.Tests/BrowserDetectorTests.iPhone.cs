using Xunit;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Shyjus.BrowserDetector.Browsers;

namespace Shyjus.BrowserDetector.Tests
{
    /// <summary>
    /// iPhone tests
    /// </summary>
    public partial class BrowserDetectorTests
    {
        [Fact]
        public void OperaTouch_iPhone()
        {
            // Arrange
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.OperaTouch_IPhone }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            // Act
            Browser actual = detector.Browser;

            // Assert
            Assert.Equal(BrowserNames.Opera, actual.Name);
            Assert.Equal(DeviceTypes.Mobile, actual.DeviceType);
        }
    }
}
