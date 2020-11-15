using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Katya.Security
{
    public class Authenticator
    {
        public const int Pbkdf2SaltSize = 32;
        public const int Pbkdf2HashSize = 32;
        public const int Pbkdf2Iterations = 10000;
        public static bool AuthenticatePbkdf2(string password, string actualPasswordSalt, string actualPasswordHash)
        {
            byte[] salt = Convert.FromBase64String(actualPasswordSalt);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, Pbkdf2Iterations);
            byte[] hash = pbkdf2.GetBytes(Pbkdf2HashSize);

            string submittedPasswordHash = Convert.ToBase64String(hash);
            if (submittedPasswordHash == actualPasswordHash)
            {
                return true;
            }

            return false;
        }

        public static void EncryptWithPbkdf2(string password, out string passwordSalt, out string passwordHash)
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[Pbkdf2SaltSize];
            rngCryptoServiceProvider.GetBytes(salt);

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, Pbkdf2Iterations);
            byte[] hash = pbkdf2.GetBytes(Pbkdf2HashSize);

            passwordHash = Convert.ToBase64String(hash);
            passwordSalt = Convert.ToBase64String(salt);
        }
    }
}
