using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GlobalHelper.ExtensionMethods
{
    public static class CryptographyExtensions
    {
        /// <summary>
        /// Generates a sequence of random characters with the specified max size
        /// </summary>
        /// <returns>A random string with the specified max size</returns>
        public static string GenerateRandomKey(int maxSize, HashSet<string> alreadyUsedKeys = null)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            var data = new byte[1];

            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }

            var result = new StringBuilder(maxSize);

            foreach (byte b in data)
            {
                result.Append(chars[b % chars.Length]);
            }

            if (alreadyUsedKeys == null || !alreadyUsedKeys.Any()) return result.ToString();
                
            return !alreadyUsedKeys.Add(result.ToString()) ? GenerateRandomKey(maxSize) : result.ToString();
        }
    }
}
