#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OGen.NTier.presentationlayer.winforms {
	public class frm_about : System.Windows.Forms.Form {
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnOK;

		#region generated code...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_about));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(8, 8);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(512, 298);
			this.textBox1.TabIndex = 2;
			this.textBox1.TabStop = false;
			this.textBox1.Text = resources.GetString("textBox1.Text");
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(440, 312);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// frm_about
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 341);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.textBox1);
			this.MinimumSize = new System.Drawing.Size(536, 368);
			this.Name = "frm_about";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OGen - about";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
		#endregion

		public frm_about() {
			#region Required for Windows Form Designer support...
			InitializeComponent();
			#endregion

			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.ControlBox = true;
			this.MaximizeBox = true;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
		}

		public const string APPSETTINGS_LICENSE_IHAVEREADLINCENSE = "I have read lincense";
		public const string APPSETTINGS_LICENSE = "license";
		private void btnOK_Click(object sender, System.EventArgs e) {
			#if !NET_1_1
			if (
				System.Configuration.ConfigurationManager.AppSettings["license"] != APPSETTINGS_LICENSE_IHAVEREADLINCENSE
			) {
				System.Configuration.Configuration _config 
					= System.Configuration.ConfigurationManager.OpenExeConfiguration(
						System.Configuration.ConfigurationUserLevel.None
					);
				try {
					_config.AppSettings.Settings.Remove(APPSETTINGS_LICENSE);
				} catch {
				}
				_config.AppSettings.Settings.Add(APPSETTINGS_LICENSE, APPSETTINGS_LICENSE_IHAVEREADLINCENSE);
				_config.Save();
				
				System.Configuration.ConfigurationManager.RefreshSection("appSettings");
			}
			#endif

			this.Close();
		}

		//private void lklGPL_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
		//    this.Hide();
		//
		//    frm_GPL gpl = new frm_GPL();
		//    gpl.ShowDialog();
		//
		//    this.Show();
		//}
	}
}
