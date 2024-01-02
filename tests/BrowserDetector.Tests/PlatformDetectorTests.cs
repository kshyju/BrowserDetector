namespace Shyjus.BrowserDetection.Tests
{
    using Shyjus.BrowserDetector;
    using Shyjus.BrowserDetector.Core;
    using System;
    using Xunit;

    /// <summary>
    /// Tests for PlatformDetector.
    /// </summary>
    public class PlatformDetectorTests
    {
        [Fact]
        public void Windows10_Win64()
        {
            var userAgentSpan = UserAgents.ChromeWindows.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);

            Assert.Equal(Platforms.Windows10, actual.Platform);
            Assert.Equal(OperatingSystems.Windows, actual.OS);
        }

        [Fact]
        public void Macintosh()
        {
            var userAgentSpan = UserAgents.ChromeOsx.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);

            Assert.Equal(Platforms.Macintosh, actual.Platform);
            Assert.Equal(OperatingSystems.MacOSX, actual.OS);
        }

        [Fact]
        public void IPhone()
        {
            var userAgentSpan = UserAgents.ChromeIPhone.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);

            Assert.Equal(Platforms.iPhone, actual.Platform);
            Assert.Equal(OperatingSystems.IOS, actual.OS);
        }

        [Fact]
        public void iPad()
        {
            var userAgentSpan = UserAgents.ChromeIPad.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);
            Assert.Equal(Platforms.iPad, actual.Platform);
            Assert.Equal(OperatingSystems.IOS, actual.OS);

        }

        [Fact]
        public void Linux_Pixel3()
        {
            var userAgentSpan = UserAgents.ChromePixel3.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);
            //Assert.Equal(Platforms.Pixel3, actual.Platform);
            Assert.Equal(OperatingSystems.Android, actual.OS);
        }

        [Fact]
        public void Android_GalaxyTab()
        {
            var userAgentSpan = UserAgents.ChromeGalaxyTabS4.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);
            Assert.Equal(OperatingSystems.Android, actual.OS);
        }
    }
}
