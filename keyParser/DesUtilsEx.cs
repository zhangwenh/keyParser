/*
 * Created by SharpDevelop.
 * User: zhangwh
 * Date: 2018/10/11
 * Time: 9:00
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Security.Cryptography;
using System.Text;
using System;

namespace keyParser
{
	/// <summary>
	/// Description of DesUtilsEx.
	/// </summary>
	public class DesUtilsEx
	{
		public DesUtilsEx()
		{
		}
		
		public static string encrypt(string pToEncrypt, string sKey)
		{
			using (DESCryptoServiceProvider des = new DESCryptoServiceProvider()) {
				byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
				des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
				des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
				System.IO.MemoryStream ms = new System.IO.MemoryStream();
				using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write)) {
					cs.Write(inputByteArray, 0, inputByteArray.Length);
					cs.FlushFinalBlock();
					cs.Close();
				}
				string str = Convert.ToBase64String(ms.ToArray());
				ms.Close();
				return str;
			}
		}
		
		//解密方法
		public static string decrypt(string pToDecrypt, string sKey)
		{
			string ret = pToDecrypt;
			if (pToDecrypt != null && pToDecrypt.Trim().Length != 0) {
				byte[] inputByteArray = null;
				try {
					inputByteArray = Convert.FromBase64String(pToDecrypt);
				} catch (Exception) {
				
				} finally {
				}
				if (inputByteArray != null) {
					using (DESCryptoServiceProvider des = new DESCryptoServiceProvider()) {
						des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
						des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
						des.Padding = PaddingMode.PKCS7;
						des.Mode = CipherMode.CBC;//.ECB
						System.IO.MemoryStream ms = new System.IO.MemoryStream();
						using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write)) {
							cs.Write(inputByteArray, 0, inputByteArray.Length);
							cs.FlushFinalBlock();
							cs.Close();
						}
						string str = Convert.ToBase64String(ms.ToArray());
						str = Base64Helper.Base64Decode(str);
						ms.Close();
						ret = str;
					}
				}
			}
			return ret;
		}
	}
}
