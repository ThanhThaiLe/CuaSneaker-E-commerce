using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace software.common.Common
{
    public static class CMAESCrypto
    {
        static string key = "123xxczxcxxzzMCbsJs4LRzjBHUFM";
        static byte[] IVAES = new byte[] { };
        static byte[] KEYAES = new byte[] { };
        public static string EncryptText(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, key);

            string result = Convert.ToBase64String(bytesEncrypted);
            return result;
        }
        public static string DecryptText(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            byte[] bytesToBeEncrypted = Convert.FromBase64String(input);

            byte[] bytesEncrypted = AES_Decrypt(bytesToBeEncrypted, key);
            string result = Encoding.UTF8.GetString(bytesEncrypted);
            return result;
        }
        public static byte[] GetMD5Hash2(byte[] bytes)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] encoded = md5.ComputeHash(bytes);
            return encoded;
        }
        public static void deriveKeyAndIV(String passphrase, byte[] salt)
        {
            var password = Encoding.UTF8.GetBytes(passphrase);

            List<byte> concatenatedHashes = new List<byte>();
            List<byte> curentHash = new List<byte>();
            bool enoughBytesForkey = false;

            List<byte> preHash = new List<byte>();
            System.Security.Cryptography.MD5CryptoServiceProvider md5provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            while (!enoughBytesForkey)
            {
                if (curentHash.Count > 0)
                {
                    preHash = curentHash;
                    preHash.AddRange(password);
                    preHash.AddRange(salt);
                }
                else
                {
                    preHash = password.ToList();
                    preHash.AddRange(salt);
                }
                curentHash = GetMD5Hash2(preHash.ToArray()).ToList();
                concatenatedHashes.AddRange(curentHash);
                if (concatenatedHashes.Count >= 48) enoughBytesForkey = true;
            }
            KEYAES = concatenatedHashes.Take(32).ToArray();
            IVAES = concatenatedHashes.Skip(32).Take(16).ToArray();
        }

        /// <summary>
        /// oke
        /// </summary>
        /// <param name="bytesToBeEncrypted"></param>
        /// <param name="passwordBytes"></param>
        /// <returns></returns>
        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, string passwordBytes)
        {
            byte[] decryptBytes = null;

            byte[] saltBytes = { 1, 5, 4, 2, 3, 2, 1, 5 };
            deriveKeyAndIV(passwordBytes, saltBytes);
            using (MemoryStream ms = new MemoryStream())
            {
                using (System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = KEYAES;
                    AES.IV = IVAES;

                    AES.Mode = System.Security.Cryptography.CipherMode.CBC;
                    AES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();

                    }
                    decryptBytes = ms.ToArray();
                }
            }
            return decryptBytes;
        }

        /// <summary>
        /// oke
        /// </summary>
        /// <param name="bytesToBeEncrypted"></param>
        /// <param name="passwordBytes"></param>
        /// <returns></returns>
        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, string passwordBytes)
        {
            byte[] encryptBytes = null;

            byte[] saltBytes = { 1, 5, 4, 2, 3, 2, 1, 5 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    deriveKeyAndIV(passwordBytes, saltBytes);
                    AES.Key = KEYAES;
                    AES.IV = IVAES;
                    AES.Mode = System.Security.Cryptography.CipherMode.CBC;
                    AES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();

                    }
                    encryptBytes = ms.ToArray();
                }
            }
            return encryptBytes;
        }
    }
}
