namespace Shyjus.BrowserDetection
{
    using System;

    /// <summary>
    /// Represents an instance of Instagram Browser
    /// Sample user agent string: Mozilla/5.0 (iPhone; CPU iPhone OS 12_4_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 Instagram 147.0.0.30.121 (iPhone9,3; iOS 12_4_1; tr_TR; tr-TR; scale=2.00; 750x1334; 224680684)
    /// </summary>
    internal class Instagram : Browser
    {
        public Instagram(ReadOnlySpan<char> userAgent, string version)
            : base(userAgent, version)
        {
        }

        /// <inheritdoc/>
        public override string Name => BrowserNames.Instagram;

        /// <summary>
        /// Populates a Instagram browser object from the userAgent value passed in. A return value indicates the parsing and populating the browser instance succeeded.
        /// </summary>
        /// <param name="userAgent">User agent value.</param>
        /// <param name="result">When this method returns True, the result will contain a Instagram object populated.</param>
        /// <returns>True if parsing succeeded, else False.</returns>
        public static bool TryParse(ReadOnlySpan<char> userAgent, out Instagram result)
        {
            var instagramIndex = userAgent.IndexOf("Instagram ".AsSpan());

            // Instagram should have "Instagram" words in it.
            if (instagramIndex > -1)
            {
                var instagramVersion = GetVersionIfKeyPresent(userAgent, "Instagram ");
                if (instagramVersion != null)
                {
                    result = new Instagram(userAgent, instagramVersion);
                    return true;
                }
            }

            result = null;
            return false;
        }
    }
}
