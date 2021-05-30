namespace Shyjus.BrowserDetection.Tests
{
    using System.Collections.Generic;
    using Microsoft.Extensions.Primitives;
    using Xunit;

    public partial class BrowserDetectorTests
    {
        /// <summary>
        /// Verify Chrome in iPad browser detection.
        /// </summary>
        [Fact]
        public void Chrome_In_IPad()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.ChromeIPad },
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            var actual = detector.Browser;

            Assert.Equal(BrowserNames.Chrome, actual.Name);
        }

        /// <summary>
        /// Verify Chrome in iPad browser detection.
        /// </summary>
        [Fact]
        public void Safari_In_IPad()
        {
            var headers = new Dictionary<string, StringValues>();
            headers.Add(Headers.UserAgent, UserAgents.SafariIPad);

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            var actual = detector.Browser;

            Assert.Equal(BrowserNames.Safari, actual.Name);
        }

        /// <summary>
        /// Verify Chrome in iPad browser detection.
        /// </summary>
        [Fact]
        public void Edge_In_IPad()
        {
            var headers = new Dictionary<string, StringValues>
            {
                { Headers.UserAgent, UserAgents.EdgeIPad },
            };

            var httpContextAccessor = this.GetMockedHttpContextAccessor(headers);
            var detector = new BrowserDetector(httpContextAccessor);

            var actual = detector.Browser;

            Assert.Equal(BrowserNames.Edge, actual.Name);
        }
    }
}
