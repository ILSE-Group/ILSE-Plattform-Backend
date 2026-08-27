using System.Security.Cryptography;
using System.Text;

namespace Domain.Utility
{
    public static class OtpHasher
    {
        public static string Hash(string plainValue)
        {
            var normalized = plainValue.Trim().ToUpperInvariant();
            var bytes = Encoding.UTF8.GetBytes(normalized);
            var hash = SHA256.HashData(bytes);
            return Convert.ToHexString(hash);
        }
    }
}