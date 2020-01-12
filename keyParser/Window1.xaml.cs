/*
 * Created by SharpDevelop.
 * User: zhangwh
 * Date: 2018/10/9
 * Time: 12:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows;

namespace keyParser
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public const string KEY_8 = "heroesXX";
		
		public Window1()
		{
			InitializeComponent();
		}
		void encBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = this.beforeTb.Text;
//			string ret = Base64Helper.Base64Encode(beforeStr);
//			string ret = DesUtils.EncodeDES(beforeStr,KEY_8);
			string ret = DesUtilsEx.encrypt(beforeStr,KEY_8);
			this.afterTb.Text = ret;
		}
		void decBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = this.beforeTb.Text;
//			string ret = Base64Helper.Base64Decode(beforeStr);
//			string ret = DesUtils.DecodeDES(beforeStr,KEY_8);
			string ret = DesUtilsEx.decrypt(beforeStr,KEY_8);
			this.afterTb.Text = ret;
		}

		
		void urlDecBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = this.beforeTb.Text;
			string ret = StrUtils.urlDec(beforeStr);
			this.afterTb.Text = ret;
		}
		
		void urlEncBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = this.beforeTb.Text;
			string ret = StrUtils.urlEnc(beforeStr);
			this.afterTb.Text = ret;
		}
		
		void upperBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = this.beforeTb.Text;
			string ret = StrUtils.upper(beforeStr);
			this.afterTb.Text = ret;
		}
		
		void lowerBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = this.beforeTb.Text;
			string ret = StrUtils.lower(beforeStr);
			this.afterTb.Text = ret;
		}
	}
}