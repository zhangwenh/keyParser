/*
 * Created by SharpDevelop.
 * User: zhangwh
 * Date: 01/12/2020
 * Time: 13:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Web;
using System;

namespace keyParser
{
	/// <summary>
	/// Description of StrUtils.
	/// </summary>
	public class StrUtils
	{
		public StrUtils()
		{
		}
		
		/// <summary>  
        /// URLEncode
        /// </summary>  
        /// <param name="str">待encode的字符串</param>  
        /// <param name="upperFlag">大写标志</param>  
        /// <returns>返回encode后的字符串，失败返回源串</returns>  
        public static string urlEnc(string str, Boolean upperFlag)  
        {  
            try  
            {
            	string ret = HttpUtility.UrlEncode(str,System.Text.Encoding.UTF8);
            	if(upperFlag){
            		ret = upper(ret);
            	}
            	return ret;//.Replace("+", "%20")
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
        public static string urlDec(string str, Boolean upperFlag)  
        {  
            try  
            {
            	string ret = HttpUtility.UrlDecode(str,System.Text.Encoding.UTF8);
            	if(upperFlag){
            		ret = upper(ret);
            	}
            	return ret;
            }
            catch
            {
                return str;  
            }
        }
        
        public static string upper(string str)  
        {  
            try  
            {
            	return str.ToUpper();
            }
            catch
            {
                return str;  
            }
        }
        
        public static string lower(string str)  
        {  
            try  
            {
            	return str.ToLower();
            }
            catch
            {
                return str;  
            }
        }
	}
}
