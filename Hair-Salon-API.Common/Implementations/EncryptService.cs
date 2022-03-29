using Hair_Salon_API.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Common.Implementations
{
    public class EncryptService:IEncryptService
    {
        public string Encrypt(string encryptText)
        {
            SHA256 sha256 = SHA256Managed.Create();
            StringBuilder hashValue = new StringBuilder();
            UTF8Encoding objUtf8 = new UTF8Encoding();

            byte[] crypto = sha256.ComputeHash(objUtf8.GetBytes(encryptText));

            foreach (byte b in crypto)
            {
                hashValue.Append(b.ToString("x2"));
            }

            return hashValue.ToString();
        }

        public string GetSalt()
        {
            var random = new RNGCryptoServiceProvider();

            // Maximum length of salt
            int max_length = 32;

            // Empty salt array
            byte[] salt = new byte[max_length];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }
    }
}
