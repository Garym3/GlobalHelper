using System;
using System.Net;

namespace GlobalHelper.ExtensionMethods
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Checks for a valid IP address in the parameter
        /// </summary>
        /// <param name="text">The string representing the IP address</param>
        /// <returns>True if the string represents a valid IP address, else returns False</returns>
        public static bool IsValidIp(this string text)
        {
            IPAddress ip;
            return IPAddress.TryParse(text, out ip);
        }

        /// <summary>
        /// Checks for a valid URI address in the parameter
        /// </summary>
        /// <param name="text">The string representing the URI address</param>
        /// <returns>True if the string represents a valid URI address, else False</returns>
        public static bool IsValidUrl(this string text)
        {
            Uri uri;
            return Uri.TryCreate(text, UriKind.Absolute, out uri);
        }
    }
}
