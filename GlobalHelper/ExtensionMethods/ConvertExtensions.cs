using System.Globalization;

namespace GlobalHelper.ExtensionMethods
{
    public static class ConvertExtensions
    {
        /// <summary>
        /// Converts a string into an int if possible
        /// </summary>
        /// <param name="input">the string to convert</param>
        /// <returns>The int if the string can be converted, else returns 0</returns>
        public static int ToInt(this string input)
        {
            int result;

            if (!int.TryParse(input, out result)) result = 0;

            return result;
        }

        /// <summary>
        /// Parses a string and returns the string as a double if it can be converted to a double.
        /// </summary>
        /// <param name="str">The string to parse</param>
        /// <param name="doubleToReturn">The double if found in the string</param>
        /// <returns>The double if found in the string</returns>
        public static bool ParseDouble(string str, out double? doubleToReturn)
        {
            double doubleValue;
            bool isDouble = double.TryParse(str.Replace(",", "."), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out doubleValue);

            if (isDouble) doubleToReturn = doubleValue;
            else doubleToReturn = null;

            return isDouble;
        }
    }
}
