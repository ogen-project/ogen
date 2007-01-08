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

namespace OGen.NTier.presentationlayer.winforms {
	public class frmManage_Searches : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbtDelete;
		private System.Windows.Forms.RadioButton rbtChange;
		private System.Windows.Forms.RadioButton rbtCreate;
		private System.Windows.Forms.Button btnNext;

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
			this.btnNext = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbtDelete = new System.Windows.Forms.RadioButton();
			this.rbtChange = new System.Windows.Forms.RadioButton();
			this.rbtCreate = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(216, 184);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 0;
			this.btnNext.Text = "&Next >>";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.Controls.Add(this.rbtDelete);
			this.groupBox1.Controls.Add(this.rbtChange);
			this.groupBox1.Controls.Add(this.rbtCreate);
			this.groupBox1.Location = new System.Drawing.Point(64, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 96);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Search: ";
			// 
			// rbtDelete
			// 
			this.rbtDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtDelete.Enabled = false;
			this.rbtDelete.Location = new System.Drawing.Point(16, 64);
			this.rbtDelete.Name = "rbtDelete";
			this.rbtDelete.Size = new System.Drawing.Size(152, 24);
			this.rbtDelete.TabIndex = 2;
			this.rbtDelete.Text = "&Delete";
			// 
			// rbtChange
			// 
			this.rbtChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtChange.Enabled = false;
			this.rbtChange.Location = new System.Drawing.Point(16, 40);
			this.rbtChange.Name = "rbtChange";
			this.rbtChange.Size = new System.Drawing.Size(152, 24);
			this.rbtChange.TabIndex = 1;
			this.rbtChange.Text = "Chan&ge";
			// 
			// rbtCreate
			// 
			this.rbtCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtCreate.Checked = true;
			this.rbtCreate.Location = new System.Drawing.Point(16, 16);
			this.rbtCreate.Name = "rbtCreate";
			this.rbtCreate.Size = new System.Drawing.Size(152, 24);
			this.rbtCreate.TabIndex = 0;
			this.rbtCreate.TabStop = true;
			this.rbtCreate.Text = "&Create";
			// 
			// frmManage_Searches
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(304, 213);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnNext);
			this.Name = "frmManage_Searches";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Searches";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_Searches(frm_Main Parent_ref_) {
			#region Required for Windows Form Designer support...
			InitializeComponent();
			#endregion
			#region Event safeguard...
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Closed += new System.EventHandler(this.frmManage_Searches_Closed);
			#endregion

			this.Parent_ref = Parent_ref_;
		}

		//#region private Properties...
		private frmManage_Searches_Create_step010 create_step010;
		//private frmManage_Searches_Change_step010 change_step010;
		//private frmManage_Searches_Delete_step010 delete_step010;
		//#endregion
		//#region public Properties...
		public frm_Main Parent_ref;
		//#endregion

		#region private Methods...
		#endregion
		#region public Methods...
		#endregion

		//#region Events...
		#region private void btnNext_Click(...);
		private void btnNext_Click(object sender, System.EventArgs e) {
			if (this.rbtCreate.Checked) {
				if (this.create_step010 == null) {
					this.create_step010 = new frmManage_Searches_Create_step010(this);
					this.create_step010.MdiParent = this.Parent_ref;//.MdiParent;
				}
				this.Hide();
				this.create_step010.Show();
				return;
			}
			//if (this.rbtChange.Checked) {
			//}
			//if (this.rbtDelete.Checked) {
			//}
		}
		#endregion
		#region private void frmManage_Searches_Closed(...);
		private void frmManage_Searches_Closed(object sender, System.EventArgs e) {
			if (this.create_step010 != null) {
				this.create_step010.Dispose();
				this.create_step010 = null;
			}
			//if (this.change_step010 != null) {
			//	this.change_step010.Dispose();
			//	this.change_step010 = null;
			//}
			//if (this.delete_step010 != null) {
			//	this.delete_step010.Dispose();
			//	this.delete_step010 = null;
			//}

			//this.Close();//already closed! we're at the Closed event, so...
			this.Dispose();
		}
		#endregion
		//#endregion
	}
}