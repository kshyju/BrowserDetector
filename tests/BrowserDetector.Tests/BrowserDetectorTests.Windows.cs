using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Shyjus.BrowserDetector.Tests
{
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
                { Headers.UserAgent, UserAgents.Chrome76_Windows }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            // Act
            Browser actual = detector.Browser;

            // Assert
            Assert.Equal(BrowserType.Chrome, actual.Type);
        }

        [Fact]
        public void Edge18_Windows()
        {
            // Arrange
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Edge18_Windows }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            // Act
            Browser actual = detector.Browser;

            // Assert
            Assert.Equal(BrowserType.Edge, actual.Type);
        }


        [Fact]
        public void EdgeChromium_Windows()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.EdgeChrome_Windows }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            Browser actual = detector.Browser;

            Assert.Equal(BrowserType.EdgeChromium, actual.Type);
        }

        [Fact]
        public void Opera_Windows()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Opera_Windows }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            Browser actual = detector.Browser;

            Assert.Equal(BrowserType.Opera, actual.Type);
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
