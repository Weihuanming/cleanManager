using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Md5Util
    {
        public static long getMD5Long(string pkg)
        {
            byte[] hash;

            MD5 md = new MD5CryptoServiceProvider();

            try
            {
                hash = md.ComputeHash(UnicodeEncoding.UTF8.GetBytes(pkg));
                return byte2Long(hash);
            }
            catch (Exception)
            {
            }
            return -1;
        }

        public static string getMD5String(string pkg)
        {
            byte[] hash;

            MD5 md = new MD5CryptoServiceProvider();

            try
            {
                hash = md.ComputeHash(UnicodeEncoding.UTF8.GetBytes(pkg));
                return byte2Long(hash).ToString();
            }
            catch (Exception)
            {
            }
            return "-1";
        }

        /**
         * 转换为long
         * @param bytes
         * @return
         */
        private static long byte2Long(byte[] bytes)
        {
            long result = 0L;
            int index = 0;
            if ((bytes == null) || (bytes.Length != 16))
            {
                return -1;
            }
            while (true)
            {
                if (index >= 8)
                    return result;
                int j = 0xFF & bytes[index];
                result = result << 8 | j;
                index++;
            }
        }
    }
}
