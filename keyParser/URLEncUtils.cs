/*
 * Created by SharpDevelop.
 * User: zhangwh
 * Date: 01/12/2020
 * Time: 13:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Web;
using System.IO;
using System.Text;
using System;

namespace keyParser
{
	/// <summary>
	/// Description of EncodeUtils.
	/// </summary>
	public class URLEncUtils
	{
		public URLEncUtils()
		{
		}
		
		/// <summary>  
        /// URLEncode
        /// </summary>  
        /// <param name="str">待encode的字符串</param>  
        /// <returns>返回encode后的字符串，失败返回源串</returns>  
        public static string urlEnc(string str)  
        {  
            try  
            {
            	return HttpUtility.UrlEncode(str);
            }
            catch
            {
                return str;  
            }
        }
        
        /// <summary>  
        /// URLDecode
        /// </summary>  
        /// <param name="str">待decode的字符串</param>  
        /// <returns>返回decode后的字符串，失败返回源串</returns>  
        public static string urlDec(string str)  
        {  
            try  
            {
            	return HttpUtility.UrlDecode(str);
            }
            catch
            {
                return str;  
            }
        }  
	}
}
