/*
 * Created by SharpDevelop.
 * User: kfzx-zhangwh04
 * Date: 03/25/2020
 * Time: 12:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using io.rdk.frs;

namespace keyParser
{
	/// <summary>
	/// Description of ConfigTools.
	/// </summary>
	public class ConfigTools
	{
		public ConfigTools()
		{
		}
		
		public static string encrypt(string srcStr)
		{
			return KeyGenerator.encrypt(srcStr);
		}
		
	}
}
