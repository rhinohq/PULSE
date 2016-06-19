using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace AuthenticationLib
{
    public static class Authentication
    {
        // Hash password with salt using SHA512 hashing algorithm
        public static string HashCredentials(string Salt, string Password)
        {
            SHA512 Hash = SHA512.Create();

            string Salted = Password + Salt;
            string HashedCredentials = Convert.ToBase64String(Hash.ComputeHash(Encoding.UTF8.GetBytes(Salted)));

            return HashedCredentials;
        }

        public static class Cryptography
        {
            private const int DerivationIterations = 1000;
            private const int Keysize = 256;

            // Decrypts text using a passphrase
            public static string Decrypt(string CipheredText, string PassPhrase)
            {
                byte[] cipherTextBytesWithSaltAndIv = Convert.FromBase64String(CipheredText);
                byte[] saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
                byte[] ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
                byte[] CipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

                using (Rfc2898DeriveBytes Password = new Rfc2898DeriveBytes(PassPhrase, saltStringBytes, DerivationIterations))
                {
                    byte[] KeyBytes = Password.GetBytes(Keysize / 8);

                    using (RijndaelManaged SymmetricKey = new RijndaelManaged())
                    {
                        SymmetricKey.BlockSize = 256;
                        SymmetricKey.Mode = CipherMode.CBC;
                        SymmetricKey.Padding = PaddingMode.PKCS7;

                        using (var Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, ivStringBytes))
                        {
                            using (MemoryStream MemoryStream = new MemoryStream(CipherTextBytes))
                            {
                                using (CryptoStream CryptoStream = new CryptoStream(MemoryStream, Decryptor, CryptoStreamMode.Read))
                                {
                                    var PlainTextBytes = new byte[CipherTextBytes.Length];
                                    var DecryptedByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);

                                    MemoryStream.Close();
                                    CryptoStream.Close();

                                    return Encoding.UTF8.GetString(PlainTextBytes, 0, DecryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }

            // Encrypts text using a passphrase
            public static string Encrypt(string PlainText, string PassPhrase)
            {
                byte[] SaltStringBytes = Generate256BitsOfRandomEntropy();
                byte[] IVStringBytes = Generate256BitsOfRandomEntropy();
                byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);

                using (Rfc2898DeriveBytes Password = new Rfc2898DeriveBytes(PassPhrase, SaltStringBytes, DerivationIterations))
                {
                    byte[] KeyBytes = Password.GetBytes(Keysize / 8);

                    using (RijndaelManaged SymmetricKey = new RijndaelManaged())
                    {
                        SymmetricKey.BlockSize = 256;
                        SymmetricKey.Mode = CipherMode.CBC;
                        SymmetricKey.Padding = PaddingMode.PKCS7;

                        using (var Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, IVStringBytes))
                        {
                            using (MemoryStream MemoryStream = new MemoryStream())
                            {
                                using (CryptoStream CryptoStream = new CryptoStream(MemoryStream, Encryptor, CryptoStreamMode.Write))
                                {
                                    CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                                    CryptoStream.FlushFinalBlock();

                                    byte[] CipherTextBytes = SaltStringBytes;

                                    CipherTextBytes = CipherTextBytes.Concat(IVStringBytes).ToArray();
                                    CipherTextBytes = CipherTextBytes.Concat(MemoryStream.ToArray()).ToArray();

                                    MemoryStream.Close();
                                    CryptoStream.Close();

                                    return Convert.ToBase64String(CipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            private static byte[] Generate256BitsOfRandomEntropy()
            {
                byte[] RandomBytes = new byte[32];

                using (RNGCryptoServiceProvider RNGCSP = new RNGCryptoServiceProvider())
                    RNGCSP.GetBytes(RandomBytes);

                return RandomBytes;
            }
        }
    }
}
