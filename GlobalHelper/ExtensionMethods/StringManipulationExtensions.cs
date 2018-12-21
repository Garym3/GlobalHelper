using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalHelper.ExtensionMethods
{
    public static class StringManipulationExtensions
    {
        /// <summary>
        /// Joins each element of an IEnumerable into a string with the specified separator
        /// </summary>
        /// <typeparam name="T">The Type contained in the IEnumerable</typeparam>
        /// <param name="self">The IEnumerable to join</param>
        /// <param name="separator">The delimiter separating each element in the returned string</param>
        /// <returns>A string with each element delimited by the specified separator</returns>
        public static string Join<T>(this IEnumerable<T> self, string separator)
        {
            return string.Join(separator, self.Select(e => e.ToString()).ToArray());
        }

        /// <summary>
        /// Joins each element of an Array into a string with the specified separator
        /// </summary>
        /// <param name="array">The Array to join</param>
        /// <param name="separator">The delimiter separating each element in the returned string</param>
        /// <returns>A string with each element delimited by the specified separator</returns>
        public static string Join(this Array array, string separator)
        {
            return string.Join(separator, array);
        }

        /// <summary>
        /// Converts non-ASCII characters to their ASCII equivalent
        /// Example : "é" -> "e"
        /// </summary>
        /// <param name="input">String to convert</param>
        /// <returns>Converted string</returns>
        public static string LatinToAscii(string input) =>
            !string.IsNullOrEmpty(input) ? new StringBuilder().Append(input.Normalize(NormalizationForm.FormKD).Where(x => x < 128).ToArray()).ToString() : string.Empty;
    }
}
