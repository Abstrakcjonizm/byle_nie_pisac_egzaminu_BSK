using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace byle_nie_pisac_egzaminu_BSK
{
    internal class Security
    {
        public static byte[] Encrypt(Aes aes, ECDiffieHellmanCng diffieHellman, byte[] publicKey, string secretMessage)
        {
            if (String.IsNullOrEmpty(secretMessage))
                return new byte[0];

            byte[] encryptedMessage;
            var key = CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob);
            var derivedKey = diffieHellman.DeriveKeyMaterial(key);

            aes.Key = derivedKey;

            using (var cipherText = new MemoryStream())
            {
                using (var encryptor = aes.CreateEncryptor())
                {
                    using (var cryptoStream = new CryptoStream(cipherText, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] ciphertextMessage = Encoding.UTF8.GetBytes(secretMessage);
                        cryptoStream.Write(ciphertextMessage, 0, ciphertextMessage.Length);
                    }
                }

                encryptedMessage = cipherText.ToArray();
            }

            return encryptedMessage;
        }

        public static string Decrypt(Aes aes, ECDiffieHellmanCng diffieHellman, byte[] publicKey, byte[] encryptedMessage, byte[] iv)
        {
            string decryptedMessage;
            var key = CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob);
            var derivedKey = diffieHellman.DeriveKeyMaterial(key);

            aes.Key = derivedKey;
            aes.IV = iv;

            using (var plainText = new MemoryStream())
            {
                using (var decryptor = aes.CreateDecryptor())
                {
                    using (var cryptoStream = new CryptoStream(plainText, decryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedMessage, 0, encryptedMessage.Length);
                    }
                }

                decryptedMessage = Encoding.UTF8.GetString(plainText.ToArray());
            }

            return decryptedMessage;
        }
    }
}
