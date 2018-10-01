using System;
using System.Collections.Generic;
using System.Text;

namespace API.Services.Contracts.Encryption
{
    public interface IEncryptPBKDF2
    {
        string Encrypt(string value, string salt);
        string Decrypt(byte[] encryptedValue, string salt);
        bool Validate(string valueToMatch, string salt, string hash);
    }
}
