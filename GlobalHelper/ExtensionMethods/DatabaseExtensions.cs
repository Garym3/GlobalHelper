using System;

namespace GlobalHelper.ExtensionMethods
{
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Checks for a DBNull object 
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>True if the object is null or DBNull, else False</returns>
        public static bool IsNullOrDbNull(this object obj)
        {
            return obj == null || obj is DBNull;
        }
    }
}
