﻿namespace BrowserDetector.Tests
{
    using Shyjus.BrowserDetection;
    using Shyjus.BrowserDetection.Tests;
    using Shyjus.BrowserDetector;
    using Xunit;

    public class FirefoxTests
    {
        [Fact]
        public void Firefox_Windows_Desktop()
        {
            var isFireFox = Firefox.TryParse(UserAgents.FirefoxWindows, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceType.Desktop, firefox.DeviceType);
            Assert.Equal(OperatingSystems.Windows, firefox.OS);
        }

        [Fact]
        public void Firefox_OSX_Desktop()
        {
            var isFireFox = Firefox.TryParse(UserAgents.FirefoxOsx, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceType.Desktop, firefox.DeviceType);
            Assert.Equal(OperatingSystems.MacOSX, firefox.OS);
        }

        [Fact]
        public void Firefox_IOS_iPhone()
        {
            var isFireFox = Firefox.TryParse(UserAgents.FirefoxIPhone, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceType.Mobile, firefox.DeviceType);
            Assert.Equal(OperatingSystems.IOS, firefox.OS);
        }

        [Fact]
        public void Firefox_IOS_iPad()
        {
            var isFireFox = Firefox.TryParse(UserAgents.FirefoxIPad, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceType.Tablet, firefox.DeviceType);
            Assert.Equal(OperatingSystems.IOS, firefox.OS);
        }
        
        [Fact]
        public void Firefox_Android()
        {
            var isFireFox = Firefox.TryParse(UserAgents.FirefoxAndroid, out var firefox);

            Assert.True(isFireFox);
            Assert.Equal(DeviceType.Mobile, firefox.DeviceType);
            Assert.Equal(OperatingSystems.Android, firefox.OS);
        }
    }
}
