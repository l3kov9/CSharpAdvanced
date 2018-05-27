using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DAISPizza.Utilities
{
    public static class PasswordUtilities
    {
        public const int DefaultSaltLength = 10;

        private const string SaltCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static RandomNumberGenerator random = new RNGCryptoServiceProvider();

        public static string GeneratePasswordSalt(int length = DefaultSaltLength)
        {
            return new string(
                Enumerable.Repeat(SaltCharacters, length)
                  .Select(s => s[GetRandomIntegerBetween(0, s.Length)])
                  .ToArray());
        }

        public static string GeneratePasswordHash(string password, string salt)
        {
            var hashingAlgorithm = new SHA256Managed();
            var passwordHashBytes = hashingAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            var passwordHash = string.Join(string.Empty, passwordHashBytes.Select(b => b.ToString("x2")));
            return passwordHash;
        }

        private static int GetRandomIntegerBetween(int min, int max)
        {
            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                byte[] fourBytes = new byte[4];
                random.GetBytes(fourBytes);

                scale = BitConverter.ToUInt32(fourBytes, 0);
            }

            return (int)((min + (max - min)) * (scale / (double)uint.MaxValue));
        }
    }
}
