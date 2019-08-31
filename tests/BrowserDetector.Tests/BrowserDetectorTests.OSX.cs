using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Shyjus.BrowserDetector.Tests
{
    /// <summary>
    /// OSX Tests
    /// </summary>
    public partial class BrowserDetectorTests
    {
        [Fact]
        public void Opera_OSX()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Opera_OSX }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            Browser actual = detector.Browser;

            Assert.Equal(BrowserType.Opera, actual.Type);
        }

        [Fact]
        public void Chrome_OSX()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Chrome_OSX }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            Browser actual = detector.Browser;

            Assert.Equal(BrowserType.Chrome, actual.Type);
        }

        [Fact]
        public void Safari_OSX()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Safari12_OSX }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            Browser actual = detector.Browser;

            Assert.Equal(BrowserType.Safari, actual.Type);
        }

        [Fact]
        public void Firefox_OSX()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.Firefox_OSX }
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            Browser actual = detector.Browser;

            Assert.Equal(BrowserType.Firefox, actual.Type);
        }
    }
}
