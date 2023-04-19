using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.HELPER
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int Iterations = 10000;
        private const int KeySize = 32;

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, Iterations, KeySize);

            return $"{Convert.ToBase64String(salt)}.{Iterations}.{Convert.ToBase64String(hash)}";
        }

        public static bool VerifyPassword(string hashedPassword, string password)
        {
            var parts = hashedPassword.Split('.', 3);
            var iterations = Convert.ToInt32(parts[1]);
            var salt = Convert.FromBase64String(parts[0]);
            var hash = Convert.FromBase64String(parts[2]);

            var newHash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, iterations, KeySize);

            return newHash.SequenceEqual(hash);
        }
    }
}
