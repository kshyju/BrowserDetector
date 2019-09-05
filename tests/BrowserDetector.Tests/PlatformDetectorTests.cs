using Xunit;
using System;

namespace Shyjus.BrowserDetector.Tests
{
    public class PlatformDetectorTests
    {
        [Fact]
        public void Windows10_Win64()
        {
            var userAgentSpan = UserAgents.Chrome76_Windows.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);

            Assert.Equal(Platforms.Windows10, actual.Platform);
            Assert.Equal(OperatingSystems.Windows, actual.OS);
        }

        [Fact]
        public void Macintosh()
        {
            var userAgentSpan = UserAgents.Chrome_OSX.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);

            Assert.Equal(Platforms.Macintosh, actual.Platform);
            Assert.Equal(OperatingSystems.MacOSX, actual.OS);

        }

        [Fact]
        public void IPhone()
        {
            var userAgentSpan = UserAgents.Chrome_IPhone.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);

            Assert.Equal(Platforms.iPhone, actual.Platform);
            Assert.Equal(OperatingSystems.IOS, actual.OS);

        }
        [Fact]
        public void iPad()
        {
            var userAgentSpan = UserAgents.Chrome_IPad.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);
            Assert.Equal(Platforms.iPad, actual.Platform);
            Assert.Equal(OperatingSystems.IOS, actual.OS);

        }

        [Fact]
        public void Linux_Pixel3()
        {
            var userAgentSpan = UserAgents.Chrome_Pixel3.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);
            Assert.Equal(Platforms.Pixel3, actual.Platform);
            Assert.Equal(OperatingSystems.Android, actual.OS);
        }

        [Fact]
        public void Android_GalaxyTab()
        {
            var userAgentSpan = UserAgents.Chrome_GalaxyTabS4.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);
            Assert.Equal(Platforms.Pixel3, actual.Platform);
            Assert.Equal(OperatingSystems.Android, actual.OS);
        }
    }
}
