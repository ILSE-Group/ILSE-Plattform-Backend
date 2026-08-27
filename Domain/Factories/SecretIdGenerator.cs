using System.Security.Cryptography;

namespace Domain.Factories
{
    public static class SecretIdGenerator
    {
        public static string Generate()
        {
            var bytes = RandomNumberGenerator.GetBytes(4);
            var number = BitConverter.ToUInt32(bytes, 0) % 1_000_000;
            return number.ToString("D6");
        }
    }
}