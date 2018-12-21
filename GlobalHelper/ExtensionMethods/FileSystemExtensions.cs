using System.Threading.Tasks;

namespace GlobalHelper.ExtensionMethods
{
    public static class FileSystemExtensions
    {
        /// <summary>
        /// Sequential deletion of all files and subdirectories in a directory
        /// </summary>
        /// <param name="directory">The parent directory</param>
        public static void ClearAll(this System.IO.DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles()) file.Delete();
            foreach (var subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }

        /// <summary>
        /// Parallel deletion of all files and subdirectories in a directory
        /// </summary>
        /// <param name="directory">The parent directory</param>
        public static void ParallelClearAll(this System.IO.DirectoryInfo directory)
        {
            Parallel.ForEach(directory.GetFiles(), file =>
            {
                file.Delete();
            });
            Parallel.ForEach(directory.GetDirectories(), subDirectory =>
            {
                subDirectory.Delete(true);
            });
        }
    }
}
