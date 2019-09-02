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
            Assert.Equal(OperatingSystems.Win64, actual.OS);
        }

        [Fact]
        public void Macintosh()
        {
            var userAgentSpan = UserAgents.Chrome_OSX.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);

            Assert.Equal(Platforms.Macintosh, actual.Platform);
        }

        [Fact]
        public void IPhone()
        {
            var userAgentSpan = UserAgents.Chrome_IPhone.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);

            Assert.Equal(Platforms.iPhone, actual.Platform);
        }
        [Fact]
        public void iPad()
        {
            var userAgentSpan = UserAgents.Chrome_IPad.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);
            Assert.Equal(Platforms.iPad, actual.Platform);
        }

        [Fact]
        public void Linux_Android()
        {
            var userAgentSpan = UserAgents.Chrome_Pixel3.AsSpan();
            var actual = PlatformDetector.GetPlatformAndOS(userAgentSpan);
            Assert.Equal(Platforms.Linux, actual.Platform);
        }
    }
}
