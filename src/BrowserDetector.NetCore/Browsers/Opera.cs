namespace Shyjus.BrowserDetection
{
    /// <summary>
    /// Represents an instance of Opera Browser.
    /// </summary>
    internal class Opera : Browser
    {
        /// <summary>
        /// Tries to build an instance of Opera browser from the user agent passed in and
        /// returns a value that indicates whether the parsing succeeded.
        /// </summary>
        /// <param name="userAgent">The user agent value.</param>
        public Opera(string userAgent)
            : base(userAgent)
        {
            Version = string.Empty;
            var operaVersion = GetVersionIfKeyIsPresent(userAgent, "OPR/");
            if (operaVersion != null)
            {
                Version = operaVersion;
                return;
            }

            var operaTouchVersion = GetVersionIfKeyIsPresent(userAgent, " OPT/");
            if (operaTouchVersion != null)
                Version = operaTouchVersion;
        }

        public override string Name => BrowserNames.Opera;

        public override string Version { get; }
    }
}
