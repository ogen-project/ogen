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

using OGen.lib.datalayer;

namespace OGen.NTier.presentationlayer.winforms {
	public class frmConnectionstring : System.Windows.Forms.Form {
		#region Required designer variable.
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtConnectionString;
		private System.Windows.Forms.RadioButton rbtConnectionstring;
		private System.Windows.Forms.RadioButton rbtTweak;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblConnectionstring;
		private System.Windows.Forms.Label lblDatabase;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblServer;
		private OGen.NTier.presentationlayer.winforms.UserControls.ucPick_DBType Pick_DBType;
		private System.Windows.Forms.TextBox txtMode;

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
			this.label7 = new System.Windows.Forms.Label();
			this.lblConnectionstring = new System.Windows.Forms.Label();
			this.txtConnectionString = new System.Windows.Forms.TextBox();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.lblDatabase = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblUserName = new System.Windows.Forms.Label();
			this.lblServer = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.rbtConnectionstring = new System.Windows.Forms.RadioButton();
			this.rbtTweak = new System.Windows.Forms.RadioButton();
			this.label8 = new System.Windows.Forms.Label();
			this.txtMode = new System.Windows.Forms.TextBox();
			this.Pick_DBType = new OGen.NTier.presentationlayer.winforms.UserControls.ucPick_DBType();
			this.SuspendLayout();
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label7.Location = new System.Drawing.Point(8, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 23);
			this.label7.TabIndex = 2;
			this.label7.Text = "DB Type: ";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblConnectionstring
			// 
			this.lblConnectionstring.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblConnectionstring.Location = new System.Drawing.Point(8, 72);
			this.lblConnectionstring.Name = "lblConnectionstring";
			this.lblConnectionstring.Size = new System.Drawing.Size(96, 23);
			this.lblConnectionstring.TabIndex = 6;
			this.lblConnectionstring.Text = "Connectionstring: ";
			this.lblConnectionstring.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtConnectionString
			// 
			this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConnectionString.Location = new System.Drawing.Point(104, 72);
			this.txtConnectionString.Name = "txtConnectionString";
			this.txtConnectionString.Size = new System.Drawing.Size(256, 20);
			this.txtConnectionString.TabIndex = 7;
			this.txtConnectionString.Text = "";
			// 
			// txtDatabase
			// 
			this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDatabase.Enabled = false;
			this.txtDatabase.Location = new System.Drawing.Point(104, 208);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(256, 20);
			this.txtDatabase.TabIndex = 16;
			this.txtDatabase.Text = "";
			// 
			// lblDatabase
			// 
			this.lblDatabase.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblDatabase.Enabled = false;
			this.lblDatabase.Location = new System.Drawing.Point(8, 208);
			this.lblDatabase.Name = "lblDatabase";
			this.lblDatabase.Size = new System.Drawing.Size(96, 23);
			this.lblDatabase.TabIndex = 15;
			this.lblDatabase.Text = "Database: ";
			this.lblDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.Enabled = false;
			this.txtPassword.Location = new System.Drawing.Point(104, 184);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(256, 20);
			this.txtPassword.TabIndex = 14;
			this.txtPassword.Text = "";
			// 
			// txtUserName
			// 
			this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUserName.Enabled = false;
			this.txtUserName.Location = new System.Drawing.Point(104, 160);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(256, 20);
			this.txtUserName.TabIndex = 12;
			this.txtUserName.Text = "";
			// 
			// txtServer
			// 
			this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtServer.Enabled = false;
			this.txtServer.Location = new System.Drawing.Point(104, 136);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(256, 20);
			this.txtServer.TabIndex = 10;
			this.txtServer.Text = "";
			// 
			// lblPassword
			// 
			this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblPassword.Enabled = false;
			this.lblPassword.Location = new System.Drawing.Point(8, 184);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(96, 23);
			this.lblPassword.TabIndex = 13;
			this.lblPassword.Text = "Password: ";
			this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblUserName
			// 
			this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblUserName.Enabled = false;
			this.lblUserName.Location = new System.Drawing.Point(8, 160);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(96, 23);
			this.lblUserName.TabIndex = 11;
			this.lblUserName.Text = "User Name: ";
			this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblServer
			// 
			this.lblServer.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblServer.Enabled = false;
			this.lblServer.Location = new System.Drawing.Point(8, 136);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(96, 23);
			this.lblServer.TabIndex = 9;
			this.lblServer.Text = "Server: ";
			this.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(280, 272);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(200, 272);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 18;
			this.btnOK.Text = "&OK";
			// 
			// rbtConnectionstring
			// 
			this.rbtConnectionstring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtConnectionstring.Checked = true;
			this.rbtConnectionstring.Location = new System.Drawing.Point(8, 96);
			this.rbtConnectionstring.Name = "rbtConnectionstring";
			this.rbtConnectionstring.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.rbtConnectionstring.Size = new System.Drawing.Size(352, 24);
			this.rbtConnectionstring.TabIndex = 8;
			this.rbtConnectionstring.TabStop = true;
			this.rbtConnectionstring.Text = "Connectionstring";
			// 
			// rbtTweak
			// 
			this.rbtTweak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtTweak.Location = new System.Drawing.Point(8, 232);
			this.rbtTweak.Name = "rbtTweak";
			this.rbtTweak.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.rbtTweak.Size = new System.Drawing.Size(352, 24);
			this.rbtTweak.TabIndex = 17;
			this.rbtTweak.Text = "Tweak";
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label8.Location = new System.Drawing.Point(8, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 23);
			this.label8.TabIndex = 4;
			this.label8.Text = "Mode: ";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtMode
			// 
			this.txtMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMode.Location = new System.Drawing.Point(104, 32);
			this.txtMode.Name = "txtMode";
			this.txtMode.Size = new System.Drawing.Size(256, 20);
			this.txtMode.TabIndex = 5;
			this.txtMode.Text = "";
			// 
			// Pick_DBType
			// 
			this.Pick_DBType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.Pick_DBType.DBServerType = OGen.lib.datalayer.eDBServerTypes.invalid;
			this.Pick_DBType.Location = new System.Drawing.Point(104, 8);
			this.Pick_DBType.Name = "Pick_DBType";
			this.Pick_DBType.Size = new System.Drawing.Size(256, 24);
			this.Pick_DBType.TabIndex = 3;
			// 
			// frmConnectionstring
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 301);
			this.Controls.Add(this.Pick_DBType);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtMode);
			this.Controls.Add(this.txtDatabase);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.txtServer);
			this.Controls.Add(this.txtConnectionString);
			this.Controls.Add(this.rbtTweak);
			this.Controls.Add(this.rbtConnectionstring);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblDatabase);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblUserName);
			this.Controls.Add(this.lblServer);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.lblConnectionstring);
			this.MinimumSize = new System.Drawing.Size(240, 328);
			this.Name = "frmConnectionstring";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DBConnection";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmConnectionstring() {
			#region Required for Windows Form Designer support
			InitializeComponent();
			#endregion
			#region Event safeguard...
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

			this.rbtTweak.CheckedChanged += new System.EventHandler(this.rbtTweak_CheckedChanged);
			this.rbtConnectionstring.CheckedChanged += new System.EventHandler(this.rbtConnectionstring_CheckedChanged);
			#endregion

			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.ControlBox = false;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.AcceptButton = btnOK;
			this.CancelButton = btnCancel;
		}

		//#region Properties...
		#region public OGen.lib.datalayer.eDBServerTypes DBServerType { get; set; }
		public OGen.lib.datalayer.eDBServerTypes DBServerType {
			get { return Pick_DBType.DBServerType; }
			set { Pick_DBType.DBServerType = value; }
		}
		#endregion
		#region public string DBMode { get; set; }
		public string DBMode {
			get { return txtMode.Text; }
			set { txtMode.Text = value; }
		}
		#endregion
		#region public string DBConnectionstring { get; set; }
		public string DBConnectionstring {
			get {
				return rbtConnectionstring.Checked 
					? txtConnectionString.Text 
					: OGen.lib.datalayer.utils.Connectionstring.Buildwith.Parameters(
						txtServer.Text, 
						txtUserName.Text, 
						txtPassword.Text, 
						txtDatabase.Text, 
						DBServerType
					);
			}
			set {
				bind_ConnectionstringFields(false);
				txtConnectionString.Text = value;
			}
		}
		#endregion
		//#endregion

		//#region Methods...
		#region private void bind_ConnectionstringFields(bool useTweak_in);
		private void bind_ConnectionstringFields(bool useTweak_in) {
			txtConnectionString.Enabled = !useTweak_in;	lblConnectionstring.Enabled = !useTweak_in;
			//---
			txtServer.Enabled = useTweak_in;			lblServer.Enabled = useTweak_in;
			txtUserName.Enabled = useTweak_in;			lblUserName.Enabled = useTweak_in;
			txtPassword.Enabled = useTweak_in;			lblPassword.Enabled = useTweak_in;
			txtDatabase.Enabled = useTweak_in;			lblDatabase.Enabled = useTweak_in;
		}
		#endregion
		//#endregion

		//#region Events...
		#region private void rbtTweak_CheckedChanged(object sender, System.EventArgs e);
		private void rbtTweak_CheckedChanged(object sender, System.EventArgs e) {
			bind_ConnectionstringFields(true);
		}
		#endregion
		#region private void rbtConnectionstring_CheckedChanged(object sender, System.EventArgs e);
		private void rbtConnectionstring_CheckedChanged(object sender, System.EventArgs e) {
			bind_ConnectionstringFields(false);
		}
		#endregion
		#region private void btnOK_Click(object sender, System.EventArgs e);
		private void btnOK_Click(object sender, System.EventArgs e) {
			if (DBServerType == OGen.lib.datalayer.eDBServerTypes.invalid) {
				System.Windows.Forms.MessageBox.Show(
					"a valid 'DB Type' must be provided",
					"Warning",
					System.Windows.Forms.MessageBoxButtons.OK,
					System.Windows.Forms.MessageBoxIcon.Warning
				);
				Pick_DBType.Focus();
				return;
			}
			if (DBMode.Trim() == string.Empty) {
				System.Windows.Forms.MessageBox.Show(
					"a valid 'Mode' must be provided",
					"Warning",
					System.Windows.Forms.MessageBoxButtons.OK,
					System.Windows.Forms.MessageBoxIcon.Warning
				);
				txtMode.Focus();
				return;
			}
			if (rbtConnectionstring.Checked) {
				if (txtConnectionString.Text.Trim() == string.Empty) {
					System.Windows.Forms.MessageBox.Show(
						"a valid 'Connectionstring' must be provided",
						"Warning",
						System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxIcon.Warning
					);
					txtConnectionString.Focus();
					return;
				}
			} else {
				if (txtServer.Text.Trim() == string.Empty) {
					System.Windows.Forms.MessageBox.Show(
						"a valid 'Server' must be provided",
						"Warning",
						System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxIcon.Warning
					);
					txtServer.Focus();
					return;
				}
				if (txtUserName.Text.Trim() == string.Empty) {
					System.Windows.Forms.MessageBox.Show(
						"a valid 'User Name' must be provided",
						"Warning",
						System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxIcon.Warning
					);
					txtUserName.Focus();
					return;
				}
				if (txtDatabase.Text.Trim() == string.Empty) {
					System.Windows.Forms.MessageBox.Show(
						"a valid 'Database' must be provided",
						"Warning",
						System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxIcon.Warning
					);
					txtDatabase.Focus();
					return;
				}
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		#endregion
		#region private void btnCancel_Click(object sender, System.EventArgs e);
		private void btnCancel_Click(object sender, System.EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		#endregion
		//#endregion
	}
}