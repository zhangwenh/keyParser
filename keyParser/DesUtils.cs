/*
 * Created by SharpDevelop.
 * User: zhangwh
 * Date: 10/10/2018
 * Time: 08:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Security.Cryptography;  
using System.IO;  
using System.Text;  
using System;  

namespace keyParser
{
	/// <summary>
	/// Description of DesUtils.
	/// </summary>
	public class DesUtils
	{
		public DesUtils()
		{
		}
        //默认密钥向量  
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };  
  
        /// <summary>  
        /// DES加密字符串  
        /// </summary>  
        /// <param name="encryptString">待加密的字符串</param>  
        /// <param name="encryptKey">加密密钥,要求为8位</param>  
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>  
        public static string EncryptDES(string encryptString, string encryptKey)  
        {  
            try  
            {  
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));  
                byte[] rgbIV = Keys;  
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);  
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();  
                MemoryStream mStream = new MemoryStream();  
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);  
                cStream.Write(inputByteArray, 0, inputByteArray.Length);  
                cStream.FlushFinalBlock();  
                return Convert.ToBase64String(mStream.ToArray());  
            }  
            catch  
            {  
                return encryptString;  
            }  
        }  
  
        /// <summary>  
        /// DES解密字符串  
        /// </summary>  
        /// <param name="decryptString">待解密的字符串</param>  
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>  
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>  
        public static string DecryptDES(string decryptString, string decryptKey)  
        {  
            try  
            {  
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);  
                byte[] rgbIV = Keys;  
                byte[] inputByteArray = Convert.FromBase64String(decryptString);  
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();  
                MemoryStream mStream = new MemoryStream();  
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);  
                cStream.Write(inputByteArray, 0, inputByteArray.Length);  
                cStream.FlushFinalBlock();  
                return Encoding.UTF8.GetString(mStream.ToArray());  
            }  
            catch  
            {  
                return decryptString;  
            }  
        }  
 
        #region 加密方法 图片加密  
        /// <summary>  
        /// 图片加密  
        /// </summary>  
        /// <param name="filePath">源文件</param>  
        /// <param name="savePath">保存为文件名称</param>  
        /// <param name="keyStr">密钥，要求为8位</param>  
        public static void EncryptFile(string filePath, string savePath, string keyStr)  
        {  
            //通过des加密  
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();  
            //通过流打开文件  
            FileStream fs = File.OpenRead(filePath);  
            //获取文件二进制字符  
            byte[] inputByteArray = new byte[fs.Length];  
            //读流文件  
            fs.Read(inputByteArray, 0, (int)fs.Length);  
            //关闭流  
            fs.Close();  
            //获得加密字符串二进制字符  
            byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);  
  
            ////计算指定字节组指定区域哈希值  
            //SHA1 ha = new SHA1Managed();  
            //byte[] hb = ha.ComputeHash(keyByteArray);  
            ////加密密钥数组  
            //byte[] sKey = new byte[8];  
            ////加密变量  
            //byte[] sIV = new byte[8];  
            //for (int i = 0; i < 8; i++)  
            //    sKey[i] = hb[i];  
            //for (int i = 8; i < 16; i++)  
            //    sIV[i - 8] = hb[i];  
            byte[] sKey = keyByteArray;  
            byte[] sIV = keyByteArray;  
            //获取加密密钥      
            des.Key = sKey;  
            //设置加密初始化向量  
            des.IV = sIV;  
            MemoryStream ms = new MemoryStream();  
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);  
            cs.Write(inputByteArray, 0, inputByteArray.Length);  
            cs.FlushFinalBlock();  
            fs = File.OpenWrite(savePath);  
            foreach (byte b in ms.ToArray())  
            {  
                fs.WriteByte(b);  
  
            }  
            fs.Close();  
            cs.Close();  
            ms.Close();  
        }  
        #endregion  
 
        #region 解密方法 图片解密  
        /// <summary>  
        /// 图片解密  
        /// </summary>  
        /// <param name="filePath">源文件</param>  
        /// <param name="savePath">保存文件</param>  
        /// <param name="keyStr">密钥，要求为8位</param>  
        public static void DecryptFile(string filePath, string savePath, string keyStr)  
        {  
            //通过des解密  
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();  
  
            //通过流读取文件  
            FileStream fs = File.OpenRead(filePath);  
            //获取文件二进制字符  
            byte[] inputByteArray = new byte[fs.Length];  
            //读取流文件  
            fs.Read(inputByteArray, 0, (int)fs.Length);  
            //关闭流  
            fs.Close();  
            //密钥数组  
            byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);  
            ////定义哈希变量  
            //SHA1 ha = new SHA1Managed();  
            ////计算指定字节组指定区域哈希值  
            //byte[] hb = ha.ComputeHash(keyByteArray);  
            ////加密密钥数组  
            //byte[] sKey = new byte[8];  
            ////加密变量  
            //byte[] sIV = new byte[8];  
            //for (int i = 0; i < 8; i++)  
            //    sKey[i] = hb[i];  
            //for (int i = 8; i < 16; i++)  
            //    sIV[i - 8] = hb[i];  

            byte[] sKey = keyByteArray;  
            byte[] sIV = keyByteArray;  

            //获取加密密钥  
            des.Key = sKey;  
            //加密变量  
            des.IV = sIV;  
            MemoryStream ms = new MemoryStream();  
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);  
            cs.Write(inputByteArray, 0, inputByteArray.Length);  
            cs.FlushFinalBlock();  
            fs = File.OpenWrite(savePath);  
            foreach (byte b in ms.ToArray())  
            {  
                fs.WriteByte(b);  
            }  
            fs.Close();  
            cs.Close();  
            ms.Close();  
        }  
        #endregion  
 
        #region 加密方法 图片加密  
        /// <summary>  
        /// 图片加密  
        /// </summary>  
        /// <param name="filePath">加密文件字节数组</param>  
        /// <param name="savePath">保存为文件名称</param>  
        /// <param name="keyStr">密钥，要求为8位</param>  
        public static void EncryptFile(byte[] inputByteArray, string savePath, string keyStr)  
        {  
            try  
            {  
                //通过des加密  
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();  
                //获得加密字符串二进制字符  
                byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);  
  
                //计算指定字节组指定区域哈希值  
                SHA1 ha = new SHA1Managed();  
                byte[] hb = ha.ComputeHash(keyByteArray);  
                //加密密钥数组  
                byte[] sKey = new byte[8];  
                //加密变量  
                byte[] sIV = new byte[8];  
                for (int i = 0; i < 8; i++)  
                    sKey[i] = hb[i];  
                for (int i = 8; i < 16; i++)  
                    sIV[i - 8] = hb[i];  
                //获取加密密钥  
  
                des.Key = sKey;  
                //设置加密初始化向量  
                des.IV = sIV;  
                MemoryStream ms = new MemoryStream();  
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);  
                cs.Write(inputByteArray, 0, inputByteArray.Length);  
                cs.FlushFinalBlock();  
                FileStream fs = File.OpenWrite(savePath);  
                foreach (byte b in ms.ToArray())  
                {  
                    fs.WriteByte(b);  
  
                }  
                fs.Close();  
                cs.Close();  
                ms.Close();  
            }  
            catch (Exception ex)  
            {  
                System.Diagnostics.Trace.Write(ex.Message);  
            }  
        }  
        #endregion  
 
        #region 解密方法 图片解密  
        /// <summary>  
        /// 图片解密  
        /// </summary>  
        /// <param name="filePath">源文件</param>  
        /// <param name="savePath">保存文件</param>  
        /// <param name="keyStr">密钥，要求为8位</param>  
        /// <returns>返回解密后的文件字节数组</returns>  
        public static byte[] DecryptFile(string filePath, string keyStr)  
        {  
            try  
            {  
                //通过des解密  
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();  
  
                //通过流读取文件  
                FileStream fs = File.OpenRead(filePath);  
                //获取文件二进制字符  
                byte[] inputByteArray = new byte[fs.Length];  
                //读取流文件  
                fs.Read(inputByteArray, 0, (int)fs.Length);  
                //关闭流  
                fs.Close();  
                //密钥数组  
                byte[] keyByteArray = Encoding.Default.GetBytes(keyStr);  
                //定义哈希变量  
                SHA1 ha = new SHA1Managed();  
                //计算指定字节组指定区域哈希值  
                byte[] hb = ha.ComputeHash(keyByteArray);  
                //加密密钥数组  
                byte[] sKey = new byte[8];  
                //加密变量  
                byte[] sIV = new byte[8];  
                for (int i = 0; i < 8; i++)  
                    sKey[i] = hb[i];  
                for (int i = 8; i < 16; i++)  
                    sIV[i - 8] = hb[i];  
                //获取加密密钥  
                des.Key = sKey;  
                //加密变量  
                des.IV = sIV;  
                MemoryStream ms = new MemoryStream();  
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);  
                cs.Write(inputByteArray, 0, inputByteArray.Length);  
                cs.FlushFinalBlock();  
                byte[] b = ms.ToArray();  
                cs.Close();  
                ms.Close();  
                return b;  
            }  
            catch (Exception ex)  
            {  
                System.Diagnostics.Trace.Write(ex.Message);  
                return null;  
            }  
        }  
        #endregion  
		
                ///<summary><![CDATA[字符串DES加密函数]]></summary>  
        ///<param name="str"><![CDATA[被加密字符串 ]]></param>  
        ///<param name="key"><![CDATA[密钥 ]]></param>   
        ///<returns><![CDATA[加密后字符串]]></returns>     
        public static string EncodeDES(string str, string key)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(str);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                StringBuilder builder = new StringBuilder();
                foreach (byte num in stream.ToArray())
                {
                    builder.AppendFormat("{0:X2}", num);
                }
                stream.Close();
                return builder.ToString();
            }
            catch (Exception) { return "xxxx"; }
        }
        ///<summary><![CDATA[字符串DES解密函数]]></summary>  
        ///<param name="str"><![CDATA[被解密字符串 ]]></param>  
        ///<param name="key"><![CDATA[密钥 ]]></param>   
        ///<returns><![CDATA[解密后字符串]]></returns>     
        public static string DecodeDES(string str, string key)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                byte[] buffer = new byte[str.Length / 2];
                for (int i = 0; i < (str.Length / 2); i++)
                {
                    int num2 = Convert.ToInt32(str.Substring(i * 2, 2), 0x10);
                    buffer[i] = (byte)num2;
                }
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                stream.Close();
                return Encoding.GetEncoding("UTF-8").GetString(stream.ToArray());
            }
            catch (Exception) { return ""; }
        }

        
	}
}
