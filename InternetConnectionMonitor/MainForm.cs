/*
 * Created by SharpDevelop.
 * User: Sarfraz
 * Date: Sun, 13-Nov-2022
 * Time: 1:55 am
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace InternetConnectionMonitor
{
	public partial class MainForm : Form
	{
		bool isClosing = false;
		string host = "google.com";
		
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		
		//[DllImport("wininet.dll")]
		//private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
		
		public MainForm()
		{
			InitializeComponent();
			
			notify.Icon = ((Icon)(resources.GetObject("disconnected")));
			
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InternetConnectionMonitor");
			
			if (key != null) {
				timer1.Interval = key.GetValue("interval") != null ? int.Parse(key.GetValue("interval").ToString()) * 1000 : 5000;
				
				host = key.GetValue("url") != null ? key.GetValue("url").ToString() : "google.com";
					
				key.Close();
			}
		}
		
		void MainForm_Load(object sender, EventArgs e)
		{
			checkInternet();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			checkInternet();
		}
		
		void checkInternet()
		{
			//int Desc;
			//bool connected;
			//connected = InternetGetConnectedState(out Desc, 0);
			
			if (isConnected()) {
				lblStatus.Text = "Connected";
				lblStatus.ForeColor = Color.Green;
				notify.Icon = ((Icon)(resources.GetObject("connected")));
				notify.Text = "Connected";
			} else {
				lblStatus.Text = "Disconnected";
				lblStatus.ForeColor = Color.Red;
				notify.Icon = ((Icon)(resources.GetObject("disconnected")));
				notify.Text = "Disconnected";
			}
		}
		
		void MainFormResize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized) {  
				Hide();
				ShowInTaskbar = false;
			}  
		}
		
		void NotifyMouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
			ShowInTaskbar = true;
		}
		
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!isClosing) {
				e.Cancel = true;
				Hide();
				ShowInTaskbar = false;
			}
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			isClosing = true;
			
			Application.Exit();
		}
		
		bool isConnected()
		{
			try { 
				Ping myPing = new Ping();
				
				byte[] buffer = new byte[32];
				int timeout = 5000;
				
				PingOptions pingOptions = new PingOptions();
				PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
				
				return (reply.Status == IPStatus.Success);
			} catch (Exception) {
				return false;
			}			
		}
		
		void SettingsToolStripMenuItemClick(object sender, EventArgs e)
		{
			Options optionsForm = new Options();
			
			optionsForm.Show();
		}
		
	}
}
