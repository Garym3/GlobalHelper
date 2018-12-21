using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
