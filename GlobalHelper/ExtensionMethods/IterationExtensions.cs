using System;
using System.Collections.Generic;

namespace GlobalHelper.ExtensionMethods
{
    public static class IterationExtensions
    {
        /// <summary>
        /// Iterates through a strongly-typed list
        /// </summary>
        /// <typeparam name="T">Generic type to specify</typeparam>
        /// <param name="list">The list</param>
        /// <param name="action">Action lambda to execute on each item</param>
        /// <returns>The modified list</returns>
        public static IEnumerable<T> ForEach<T>(this IList<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }

            return list;
        }
    }
}
