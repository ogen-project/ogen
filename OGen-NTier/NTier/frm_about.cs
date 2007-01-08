#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

*/
#endregion
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using OGen.lib.config;

namespace OGen.NTier.presentationlayer.winforms {
	public class frm_about : System.Windows.Forms.Form {
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.LinkLabel lklGPL;

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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.lklGPL = new System.Windows.Forms.LinkLabel();
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
			this.textBox1.Size = new System.Drawing.Size(512, 272);
			this.textBox1.TabIndex = 2;
			this.textBox1.TabStop = false;
			this.textBox1.Text = @"

	OGen
	Copyright (C) 2002 Francisco Monteiro

	This program is free software; you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation; either version 2 of the License, or
	at your option) any later version.

	This program is distributed in the hope that it will be useful, 
	but WITHOUT ANY WARRANTY; without even the implied warranty of 
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License 
	along with this program; if not, write to the Free Software 
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA ";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(440, 312);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lklGPL
			// 
			this.lklGPL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lklGPL.Location = new System.Drawing.Point(16, 288);
			this.lklGPL.Name = "lklGPL";
			this.lklGPL.Size = new System.Drawing.Size(504, 23);
			this.lklGPL.TabIndex = 1;
			this.lklGPL.TabStop = true;
			this.lklGPL.Text = "Read the GNU General Public License";
			this.lklGPL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lklGPL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklGPL_LinkClicked);
			// 
			// frm_about
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 341);
			this.Controls.Add(this.lklGPL);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.textBox1);
			this.MinimumSize = new System.Drawing.Size(536, 368);
			this.Name = "frm_about";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OGen - about";
			this.ResumeLayout(false);

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

		private void btnOK_Click(object sender, System.EventArgs e) {
			if (ConfigurationSettingsBinder.Read("license") == null) {
				ConfigurationSettingsBinder.Write("license", "I have read lincense");
				ConfigurationSettingsBinder.Save();
			}

			this.Close();
		}

		private void lklGPL_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			this.Hide();

			frm_GPL gpl = new frm_GPL();
			gpl.ShowDialog();

			this.Show();
		}
	}
}