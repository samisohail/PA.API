using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Text;

namespace API.Services.Contracts.Encryption
{
    public class EncryptPBKDF2 : IEncryptPBKDF2
    {
        public string Encrypt(string value, string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                                password: value,
                                salt: Encoding.UTF8.GetBytes(salt),
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        public string Decrypt(byte[] encryptedValue, string salt)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string value, string salt, string hash)
            => Encrypt(value, salt) == hash;        
    }
}
