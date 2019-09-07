//using System;

//namespace Shyjus.BrowserDetector
//{
//    /// <summary>
//    /// Represents the base version of a Browser instance
//    /// </summary>
//    public abstract class Browser
//    {
//        private string userAgent;
//        /// <summary>
//        /// Browser type
//        /// Ex: Chrome/Edge
//        /// </summary>
//        public abstract string Name { get; }

//        /// <summary>
//        /// Version information of the browser instance
//        /// </summary>
//        public Version Version { protected set; get; }

//        /// <summary>
//        /// The device type.
//        /// Possible values are:
//        ///     1. Mobile
//        ///     2. Tablet
//        ///     3. Desktop
//        /// </summary>
//        public abstract string DeviceType { get; }


//        //protected string GetDeviceType(ReadOnlySpan<char> userAgent)
//        //{
//        //    var platform = PlatformDetector.GetPlatformAndOS(userAgent);

//        //    if (platform.Platform == Platforms.iPad)
//        //    {
//        //        return DeviceTypes.Tablet;
//        //    }
//        //    if (platform.Platform == Platforms.iPhone)
//        //    {
//        //        return DeviceTypes.Mobile;
//        //    }
//        //}
//    }
//}
