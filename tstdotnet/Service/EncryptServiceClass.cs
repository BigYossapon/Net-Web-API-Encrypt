using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace tstdotnet.Service
{
    public class EncryptServiceClass
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); // Ensure your key is 16, 24, or 32 bytes
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("zU7XBVHwmp/rjC++8KguOQ=="); // Ensure your IV is 16 bytes

        public static string EncryptString(string plainText, string iv)
        {
            using (var aes = Aes.Create())
            {

                aes.Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); ;
                aes.IV = Encoding.UTF8.GetBytes(iv);

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string DecryptString(string cipherText, string iv)
        {

            var buffer = Convert.FromBase64String(cipherText);

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
                aes.IV = Encoding.UTF8.GetBytes(iv);

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(buffer))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}