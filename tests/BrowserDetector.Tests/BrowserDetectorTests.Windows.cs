namespace Shyjus.BrowserDetection.Tests
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using Moq;
    using Shyjus.BrowserDetection;
    using Xunit;

    /// <summary>
    /// Desktop browsers in Windows.
    /// </summary>
    public partial class BrowserDetectorTests
    {
        [Fact]
        public void Chrome76_Windows()
        {
            // Arrange
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.ChromeWindows },
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            // Act
            var actual = detector.Browser;

            // Assert
            Assert.Equal(BrowserNames.Chrome, actual.Name);
            Assert.Equal(DeviceTypes.Desktop, actual.DeviceType);
        }

        [Fact]
        public void IE11_Windows()
        {
            // Arrange
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Ie11Windows },
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            // Act
            var actual = detector.Browser;

            // Assert
            Assert.Equal(BrowserNames.InternetExplorer, actual.Name);
            Assert.Equal(DeviceTypes.Desktop, actual.DeviceType);
            Assert.Equal(OperatingSystems.Windows, actual.OS);
        }

        [Fact]
        public void Edge18_Windows()
        {
            // Arrange
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Edge18Windows },
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            // Act
            var actual = detector.Browser;

            // Assert
            Assert.Equal(BrowserNames.Edge, actual.Name);
            Assert.Equal(DeviceTypes.Desktop, actual.DeviceType);
        }

        [Fact]
        public void EdgeChromium_Windows()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.EdgeChromeWindows },
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            var actual = detector.Browser;

            Assert.Equal(BrowserNames.EdgeChromium, actual.Name);
            Assert.Equal(DeviceTypes.Desktop, actual.DeviceType);
        }

        [Fact]
        public void Opera_Windows()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.OperaWindows }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            var actual = detector.Browser;

            Assert.Equal(BrowserNames.Opera, actual.Name);
            Assert.Equal(DeviceTypes.Desktop, actual.DeviceType);
        }

        [Fact]
        public void Handles_Gracefully_When_UserAgent_Header_Missing()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { "UA-Header-Missing", UserAgents.OperaWindows }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            var actual = detector.Browser;

            Assert.Null(actual);
        }

        private IHttpContextAccessor GetMockedHttpContextAccessor(Dictionary<string, StringValues> headers)
        {
            var headerDictionary = new HeaderDictionary(headers);

            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            var context = new Mock<HttpContext>();
            var request = new Mock<HttpRequest>();
            request.Setup(a => a.Headers).Returns(headerDictionary);

            context.Setup(a=>a.Request).Returns(request.Object);
            httpContextAccessor.Setup(a => a.HttpContext).Returns(context.Object);

            return httpContextAccessor.Object;
        }
    }
}
