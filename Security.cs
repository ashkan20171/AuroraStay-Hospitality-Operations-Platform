using System;
using System.Security.Cryptography;

namespace AshkanHotelManager
{
    public static class Security
    {
        public static string HashPassword(string password, string saltBase64, int iterations = 120000)
        {
            var salt = Convert.FromBase64String(saltBase64);
            using (var derive = new Rfc2898DeriveBytes(password ?? String.Empty, salt, iterations, HashAlgorithmName.SHA256))
                return Convert.ToBase64String(derive.GetBytes(32));
        }

        public static string NewSalt()
        {
            var bytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public static bool FixedTimeEquals(string a, string b)
        {
            if (a == null || b == null) return false;
            var x = Convert.FromBase64String(a); var y = Convert.FromBase64String(b);
            if (x.Length != y.Length) return false;
            int diff = 0; for (int i = 0; i < x.Length; i++) diff |= x[i] ^ y[i];
            return diff == 0;
        }
    }
}
