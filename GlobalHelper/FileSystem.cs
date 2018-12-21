using System;
using System.IO;

namespace GlobalHelper
{
    public static class FileSystem
    {
        /// <summary>
        /// Checks if the file in the path can be opened now
        /// </summary>
        /// <param name="filePath">Path of the file to check</param>
        /// <returns>True if the file can be opened, else False</returns>
        public static bool IsFileReady(string filePath)
        {
            try
            {
                using (var inputStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return inputStream.Length > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
