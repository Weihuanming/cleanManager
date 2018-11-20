using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DES3Util
    {

        private static byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] key = Encoding.UTF8.GetBytes("QXo8NKD143zFbCx2ESDzFbA5");

        ///
        /// DES3 ECB模式加密
        ///
        /// 密钥
        /// IV(当模式为ECB时，IV无用)
        /// 明文的byte数组
        /// 密文的byte数组
        public static string Des3EncodeECB(string encryptString)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(encryptString);
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;
                // Create a CryptoStream using the MemoryStream
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the
                // MemoryStream that holds the
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return Convert.ToBase64String(ret.ToArray()); 
            }
            catch (Exception)
            {
                return encryptString;
            }

        }

        ///
        /// DES3 ECB模式解密
        ///
        /// 密钥
        /// IV(当模式为ECB时，IV无用)
        /// 密文的byte数组
        /// 明文的byte数组
        public static string Des3DecodeECB(string decryptString)
        {
            try
            {
                
                byte[] data = Convert.FromBase64String(decryptString);
                // Create a new MemoryStream using the passed
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return Encoding.UTF8.GetString(fromEncrypt.ToArray()); 
            }
            catch (Exception)
            {
                return decryptString;
            }
        }
    }
}