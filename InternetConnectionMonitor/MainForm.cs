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

namespace InternetConnectionMonitor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		bool isClosing = false;
		
		[DllImport("wininet.dll")]
		private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
		
		public MainForm()
		{
			InitializeComponent();
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
			int Desc;
			
			bool connected;

			connected = InternetGetConnectedState(out Desc, 0);
			
			if (connected) {
				lblStatus.Text = "Connected";
				lblStatus.ForeColor = System.Drawing.Color.Green;
				notifyConnected.Visible = true;
				notifyDisconnected.Visible = false;
			} else {
				lblStatus.Text = "Disconnected";
				lblStatus.ForeColor = System.Drawing.Color.Red;
				notifyDisconnected.Visible = true;
				notifyConnected.Visible = false;
			}
		}
		
		void MainFormResize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized) {  
				Hide();
				ShowInTaskbar = false;
			}  
		}
		
		void NotifyConnectedMouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
			ShowInTaskbar = true;
		}
		
		void NotifyDisconnectedMouseDoubleClick(object sender, MouseEventArgs e)
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
		
		
	}
}
