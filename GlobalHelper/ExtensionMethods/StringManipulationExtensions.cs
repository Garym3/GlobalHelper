using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalHelper.ExtensionMethods
{
    public static class StringManipulationExtensions
    {
        /// <summary>
        /// Joins two 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> self, string separator)
        {
            return string.Join(separator, self.Select(e => e.ToString()).ToArray());
        }

        public static string Join(this Array array, string separator)
        {
            return string.Join(separator, array);
        }
    }
}
