/*
 * Created by SharpDevelop.
 * User: zhangwh
 * Date: 2018/10/11
 * Time: 8:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;

namespace keyParser
{
	/// <summary>
	/// Description of Base64Helper.
	/// </summary>
	public class Base64Helper
	{
		public Base64Helper()
		{
		}
		/// <summary>
	    /// Base64加密，采用utf8编码方式加密
	    /// </summary>
	    /// <param name="source">待加密的明文</param>
	    /// <returns>加密后的字符串</returns>
	    public static string Base64Encode(string source)
	    {
	        return Base64Encode(source,Encoding.UTF8);
	    }
	 
	    /// <summary>
	    /// Base64加密
	    /// </summary>
	    /// <param name="source">待加密的明文</param>
	    /// <param name="encodeType">加密采用的编码方式</param>
	    /// <returns></returns>
	    public static string Base64Encode(string source,Encoding encodeType)
	    {
	        string encode = string.Empty;
	        byte[] bytes = encodeType.GetBytes(source);
	        try
	        {
	            encode = Convert.ToBase64String(bytes);
	        }
	        catch
	        {
	            encode = source;
	        }
	        return encode;
	    }
	 
	    /// <summary>
	    /// Base64解密，采用utf8编码方式解密
	    /// </summary>
	    /// <param name="result">待解密的密文</param>
	    /// <returns>解密后的字符串</returns>
	    public static string Base64Decode(string result)
	    {
	        return Base64Decode(result,Encoding.UTF8);
	    }
	 
	    /// <summary>
	    /// Base64解密
	    /// </summary>
	    /// <param name="result">待解密的密文</param>
	    /// <param name="encodeType">解密采用的编码方式，注意和加密时采用的方式一致</param>
	    /// <returns>解密后的字符串</returns>
	    public static string Base64Decode(string result,Encoding encodeType)
	    {
	        string decode = string.Empty;
	        byte[] bytes = Convert.FromBase64String(result);
	        try
	        {
	            decode = encodeType.GetString(bytes);
	        }
	        catch
	        {
	            decode = result;
	        }
	        return decode;
	    }
	}
}
