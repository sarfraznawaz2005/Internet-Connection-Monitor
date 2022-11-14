/*
 * Created by SharpDevelop.
 * User: Sarfraz
 * Date: Mon, 14-Nov-2022
 * Time: 12:23 pm
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace InternetConnectionMonitor
{
	public partial class Options : Form
	{
		public Options()
		{
			InitializeComponent();
		}
		
		void TxtIntervalKeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
			    (e.KeyChar != '.')) {
				e.Handled = true;
			}

			// only allow one decimal point
			if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
				e.Handled = true;
			}
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InternetConnectionMonitor");
			
			key.SetValue("url", txtURL.Text.Length > 4 ? txtURL.Text : "google.com");
			key.SetValue("interval", txtInterval.Text.Length > 0 ? txtInterval.Text : "5");
			key.Close();
			
			Close();
		}
		
		void OptionsLoad(object sender, EventArgs e)
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InternetConnectionMonitor");
			
			if (key != null) {
				txtURL.Text = key.GetValue("url") != null ? key.GetValue("url").ToString() : "google.com";
				txtInterval.Text = key.GetValue("interval") != null ? key.GetValue("interval").ToString() : "5";

				key.Close();
			}
		}
	}
}
