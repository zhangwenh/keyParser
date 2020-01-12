using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;


namespace keyParser
{
    public class TDESUtils
    {
        private static Type type = MethodBase.GetCurrentMethod().DeclaringType;

        /// <summary>
        /// 3DES解密
        /// </summary>
        /// <param name="strString">加密后的字符串</param>
        /// <param name="strKey">解密key</param>
        /// <returns>返回明文密码</returns>
        public static string Decrypt3DES(string strString, string strKey)
        {
            var provider1 = new TripleDESCryptoServiceProvider();
            var provider2 = new MD5CryptoServiceProvider();
            provider1.Key = provider2.ComputeHash(Encoding.ASCII.GetBytes(strKey));
            provider1.Mode = CipherMode.ECB;
            ICryptoTransform transform1 = provider1.CreateDecryptor();
            string text1 = "";
            try
            {
                byte[] buffer1 = Convert.FromBase64String(strString);
                text1 = Encoding.ASCII.GetString(transform1.TransformFinalBlock(buffer1, 0, buffer1.Length));
            }
            finally{}
            return text1;
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="a_strString">加密字符串</param>
        /// <param name="a_strKey">密匙</param>
        /// <returns>返回加密后字符串</returns>
        public static string Encrypt3DES(string a_strString, string a_strKey)
        {
            var DES = new TripleDESCryptoServiceProvider();
            var provider2 = new MD5CryptoServiceProvider();
            DES.Key = provider2.ComputeHash(Encoding.ASCII.GetBytes(a_strKey));
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(a_strString);
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

    }
}
