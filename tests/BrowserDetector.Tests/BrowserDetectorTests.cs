using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Shyjus.BrowserDetector.Tests
{
    public partial class BrowserDetectorTests
    {
        /// <summary>
        /// Verify Chrome browser detection. 
        /// </summary>
        [Fact]
        public void Verify_Chrome_Detection()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Chrome76 }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            Browser actual = detector.Browser;

            Assert.Equal(BrowserType.Chrome, actual.Type);
        }
        /// <summary>
        /// Verify Edge browser detection. 
        /// </summary>
        [Fact]
        public void Verify_Edge_Detection()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Edge18 }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            Browser actual = detector.Browser;

            Assert.Equal(BrowserType.Edge, actual.Type);
        }

        /// <summary>
        /// Verify Edge chromium browser detection. 
        /// </summary>
        [Fact]
        public void Verify_EdgeChromium_Detection()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.EdgeChromium }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            Browser actual = detector.Browser;

            Assert.Equal(BrowserType.EdgeChromium, actual.Type);
        }

        /// <summary>
        /// Verify safari browser detection. 
        /// </summary>
        [Fact]
        public void Verify_Safari_Detection()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Safari12 }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            Browser actual = detector.Browser;

            Assert.Equal(BrowserType.Safari, actual.Type);
        }

        /// <summary>
        /// Verify Opera browser detection. 
        /// </summary>
        [Fact]
        public void Verify_Opera_Detection()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Opera }
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
