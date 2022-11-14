/*
 * Created by SharpDevelop.
 * User: Sarfraz
 * Date: Mon, 14-Nov-2022
 * Time: 12:23 pm
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace InternetConnectionMonitor
{
	partial class Options
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.TextBox txtInterval;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.txtInterval = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ping URL";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Interval (Seconds)";
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(125, 5);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(236, 20);
			this.txtURL.TabIndex = 1;
			this.txtURL.Text = "google.com";
			// 
			// txtInterval
			// 
			this.txtInterval.Location = new System.Drawing.Point(125, 38);
			this.txtInterval.Name = "txtInterval";
			this.txtInterval.Size = new System.Drawing.Size(50, 20);
			this.txtInterval.TabIndex = 2;
			this.txtInterval.Text = "5";
			this.txtInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIntervalKeyPress);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(111, 89);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(192, 89);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// Options
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 121);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.txtInterval);
			this.Controls.Add(this.txtURL);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Options";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.OptionsLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
