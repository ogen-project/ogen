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

namespace OGen.lib.presentationlayer.winforms.Flowforms {
	public class frmProcessOutput : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListBox lbxOutput;
		private System.Windows.Forms.Button btnOK;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.lbxOutput = new System.Windows.Forms.ListBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbxOutput
			// 
			this.lbxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lbxOutput.Location = new System.Drawing.Point(8, 8);
			this.lbxOutput.Name = "lbxOutput";
			this.lbxOutput.Size = new System.Drawing.Size(332, 277);
			this.lbxOutput.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(136, 288);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// frmProcessOutput
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 317);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lbxOutput);
			this.Name = "frmProcessOutput";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "processo - mensagens...";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmProcessOutput(
			string formTitle_in
		) {
			#region Required for Windows Form Designer support...
			InitializeComponent();
			#endregion
			this.Text = formTitle_in;

			FormBorderStyle = FormBorderStyle.FixedDialog;
			ControlBox = false;
			MaximizeBox = false;
			MinimizeBox = false;
			ShowInTaskbar = false;
			AcceptButton = btnOK;
			CancelButton = btnOK;
		}

		public void DisplayMessage(string message_in, bool onANewLine_in) {
			if (onANewLine_in) {
				lbxOutput.Items.Add(message_in);
				lbxOutput.SelectedIndex = lbxOutput.Items.Count - 1;
			} else {
				lbxOutput.Items[lbxOutput.Items.Count - 1] += message_in;
				lbxOutput.SelectedIndex = lbxOutput.Items.Count - 1;
			}
			//this.MdiParent.Refresh();
			//this.Refresh();
		}
		public void DisplayMessage() {
			btnOK.Enabled = true;
			btnOK.Focus();
		}

		private void btnOK_Click(object sender, System.EventArgs e) {
			this.Close();
		}
	}
}