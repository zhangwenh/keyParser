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
using System.Windows.Documents;
using System.Windows.Controls;

namespace keyParser
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public const string KEY_8 = "heroesXX";
//		public const string KEY_DRUID = "MFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAKHGwq7q2RmwuRgKxBypQHw0mYu4BQZ3eMsTrdK8E6igRcxsobUC7uT0SoxIjl1WveWniCASejoQtn/BY6hVKWsCAwEAAQ==";
		
		public Window1()
		{
			InitializeComponent();
		}
		string getRTBValue(RichTextBox rtb)
		{
			TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
			return textRange.Text.TrimEnd("\r\n".ToCharArray());
		}
		void setRTBValue(RichTextBox rtb, string value)
		{
			TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
			textRange.Text = value;
		}
		void clearRTB(RichTextBox rtb)
		{
			setRTBValue(rtb, "");
		}
		void encBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = DesUtilsEx.encrypt(beforeStr,KEY_8);
			setRTBValue(afterTb,ret);
		}
		void decBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = DesUtilsEx.decrypt(beforeStr,KEY_8);
			setRTBValue(afterTb,ret);
		}

		
		void urlDecBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = StrUtils.urlDec(beforeStr,false);
			setRTBValue(afterTb,ret);
		}
		
		void urlEncBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = StrUtils.urlEnc(beforeStr,false);
			ret = ret.Replace("%0d%0a","%0a");
			setRTBValue(afterTb,ret);
		}
		
		void upperBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = StrUtils.upper(beforeStr);
			setRTBValue(afterTb,ret);
		}
		
		void lowerBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = StrUtils.lower(beforeStr);
			setRTBValue(afterTb,ret);
		}
		
		void drdEncBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = ConfigTools.encrypt(beforeStr);
			setRTBValue(afterTb,ret);
		}
		void TDEBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string cipherStr = this.cipherTb.Text;
			string ret = TDESUtils.Encrypt3DES(beforeStr,cipherStr);
			setRTBValue(afterTb,ret);
		}
		void TDDBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string cipherStr = this.cipherTb.Text;
			string ret = TDESUtils.Decrypt3DES(beforeStr,cipherStr);
			setRTBValue(afterTb,ret);
		}
		void encXBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = StrUtils.urlEnc(Base64Helper.Base64Encode(beforeStr),false);
			setRTBValue(afterTb,ret);
		}
		void decXBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = Base64Helper.Base64Decode(StrUtils.urlDec(beforeStr,false));
			setRTBValue(afterTb,ret);
		}
		void b64EncBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = Base64Helper.Base64Encode(beforeStr);
			setRTBValue(afterTb,ret);
		}
		void b64DecBtn_Click(object sender, RoutedEventArgs e)
		{
			clearRTB(afterTb);
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = Base64Helper.Base64Decode(beforeStr);
			setRTBValue(afterTb,ret);
		}
	}
}