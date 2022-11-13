/*
 * Created by SharpDevelop.
 * User: Sarfraz
 * Date: Sun, 13-Nov-2022
 * Time: 1:55 am
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using System.Net.NetworkInformation;  

namespace InternetConnectionMonitor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		bool isClosing = false;
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		
		//[DllImport("wininet.dll")]
		//private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
		
		public MainForm()
		{
			InitializeComponent();
			
			notify.Icon = ((Icon)(resources.GetObject("connected")));
		}
		
		private void MainForm_Load(object sender, EventArgs e)
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
				notify.BalloonTipIcon = ToolTipIcon.Info;
			} else {
				lblStatus.Text = "Disconnected";
				lblStatus.ForeColor = Color.Red;
				notify.Icon = ((Icon)(resources.GetObject("disconnected")));
				notify.BalloonTipIcon = ToolTipIcon.Error;
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
				
				String host = "google.com";
				
				byte[] buffer = new byte[32];
				int timeout = 5000;
				
				PingOptions pingOptions = new PingOptions();
				PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
				
				return (reply.Status == IPStatus.Success);
			} catch (Exception) {
				return false;
			}			
		}
		
	}
}
