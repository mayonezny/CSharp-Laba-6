using System;
using System.Security.Cryptography;
using System.Text;

namespace DOTNET_TITSHARP_LABO_六.Crypto
{
    public static class EncryptionManager
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("Your32CharSecretKeyHere!");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("Your16CharIVHere");

        public static string Encrypt(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] encrypted;
                using (var ms = new System.IO.MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new System.IO.StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        encrypted = ms.ToArray();
                    }
                }
                return Convert.ToBase64String(encrypted);
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                string plainText;
                using (var ms = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new System.IO.StreamReader(cs))
                        {
                            plainText = sr.ReadToEnd();
                        }
                    }
                }
                return plainText;
            }
        }
    }

}
