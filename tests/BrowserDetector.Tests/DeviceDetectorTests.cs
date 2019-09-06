using Xunit;
using System;

namespace Shyjus.BrowserDetector.Tests
{
    public class DeviceDetectorTests
    {
        [Fact]
        public void IsDesktop_iPad()
        {
            var userAgentSpan = UserAgents.Chrome_IPad.AsSpan();
            var actual = DeviceDetector.IsDesktop(userAgentSpan);

            Assert.False(actual);
        }

        [Fact]
        public void IsDesktop_iPhone()
        {
            var userAgentSpan = UserAgents.Chrome_IPhone.AsSpan();
            var actual = DeviceDetector.IsDesktop(userAgentSpan);

            Assert.False(actual);
        }
        [Fact]
        public void IsDesktop_OSX()
        {
            var userAgentSpan = UserAgents.Chrome_OSX.AsSpan();
            var actual = DeviceDetector.IsDesktop(userAgentSpan);

            Assert.True(actual);
        }

        [Fact]
        public void IsDesktop_Windows10()
        {
            var userAgentSpan = UserAgents.Chrome_Windows.AsSpan();
            var actual = DeviceDetector.IsDesktop(userAgentSpan);

            Assert.True(actual);
        }
    }
}
