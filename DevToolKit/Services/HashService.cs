using System.Security.Cryptography;
using System.Text;

namespace DevToolKit.Services
{
    public static class HashService
    {
        public static string ComputeHash(string input, string algorithm)
        {
            using HashAlgorithm? hashAlg = algorithm.ToUpperInvariant() switch
            {
                "MD5" => MD5.Create(),
                "SHA1" => SHA1.Create(),
                _ => SHA256.Create(),
            };
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = hashAlg.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
        }
    }
} 