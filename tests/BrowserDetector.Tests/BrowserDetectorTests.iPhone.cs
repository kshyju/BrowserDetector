namespace Shyjus.BrowserDetection.Tests
{
    using System.Collections.Generic;
    using Microsoft.Extensions.Primitives;
    using Shyjus.BrowserDetection;
    using Xunit;

    /// <summary>
    /// BrowserDetector tests.
    /// </summary>
    public partial class BrowserDetectorTests
    {
        [Fact]
        public void OperaTouch_iPhone()
        {
            // Arrange
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.OperaTouchIPhone },
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            // Act
            IBrowser actual = detector.Browser;

            // Assert
            Assert.Equal(BrowserNames.Opera, actual.Name);
            Assert.Equal(DeviceTypes.Mobile, actual.DeviceType);
        }
    }
}
