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
		
		public Window1()
		{
			InitializeComponent();
		}
		string getRTBValue(RichTextBox rtb)
		{
			TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
			return textRange.Text.TrimEnd("\r\n".ToCharArray());
		}
		void encBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = DesUtilsEx.encrypt(beforeStr,KEY_8);
			this.afterTb.Text = ret;
		}
		void decBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = DesUtilsEx.decrypt(beforeStr,KEY_8);
			this.afterTb.Text = ret;
		}

		
		void urlDecBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = StrUtils.urlDec(beforeStr);
			this.afterTb.Text = ret;
		}
		
		void urlEncBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = StrUtils.urlEnc(beforeStr);
			this.afterTb.Text = ret;
		}
		
		void upperBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = StrUtils.upper(beforeStr);
			this.afterTb.Text = ret;
		}
		
		void lowerBtn_Click(object sender, RoutedEventArgs e)
		{
			string beforeStr = getRTBValue(this.beforeTb);
			string ret = StrUtils.lower(beforeStr);
			this.afterTb.Text = ret;
		}
	}
}