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
	public class frmManage_Updates_Create_step020 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Label label1;
		private OGen.NTier.presentationlayer.winforms.ucPick_Searches Pick_Searches;

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
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.Pick_Searches = new OGen.NTier.presentationlayer.winforms.ucPick_Searches();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBack.Location = new System.Drawing.Point(16, 248);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(72, 23);
			this.btnBack.TabIndex = 9;
			this.btnBack.Text = "<< &Back";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(208, 248);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 8;
			this.btnNext.Text = "&Next >>";
			// 
			// Pick_Searches
			// 
			this.Pick_Searches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Pick_Searches.Location = new System.Drawing.Point(8, 24);
			this.Pick_Searches.Name = "Pick_Searches";
			this.Pick_Searches.Size = new System.Drawing.Size(280, 216);
			this.Pick_Searches.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Choose Search:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// frmManage_Updates_Create_step020
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 277);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Pick_Searches);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnNext);
			this.Name = "frmManage_Updates_Create_step020";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Updates - Create";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_Updates_Create_step020(frmManage_Updates_Create_step010 Parent_ref_) {
			#region	Required for Windows Form Designer support...
			InitializeComponent();
			#endregion
			#region Event safeguard...
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Closed += new System.EventHandler(this.frmManage_Updates_Create_step020_Closed);
			#endregion
			this.Parent_ref = Parent_ref_;
		}

		//#region private Properties...
		private frmManage_Updates_Create_step030 create_step030;
		//#endregion
		//#region public Properties...
		public frmManage_Updates_Create_step010 Parent_ref;
		#region public string SearchName { get; }
		public string SearchName {
			get {
				string[] _SelectedSearches = this.Pick_Searches.SelectedSearches();
				return (_SelectedSearches.Length == 0) ? 
					"" : 
					this.Pick_Searches.SelectedSearches()[0];
			}
		}
		#endregion
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public void Bind_Updates();
		public void Bind_Searches() {
			this.Pick_Searches.Bind_Searches(
				frm_Main.NTierProject.Metadata.Tables.Search(Parent_ref.TableName), 
				false
			);
		}
		#endregion
		//#endregion

		//#region Events...
		#region private void btnBack_Click(...);
		private void btnBack_Click(object sender, System.EventArgs e) {
			this.Hide();
			this.Parent_ref.Show();
		}
		#endregion
		#region private void btnNext_Click(...);
		private void btnNext_Click(object sender, System.EventArgs e) {
			if (this.create_step030 == null) {
				this.create_step030 = new frmManage_Updates_Create_step030(this);
				this.create_step030.MdiParent = this.Parent_ref.MdiParent;
			}
			this.Hide();
			this.create_step030.Show();
		}
		#endregion
		#region private void frmManage_Updates_Create_step020_Closed(...);
		private void frmManage_Updates_Create_step020_Closed(object sender, System.EventArgs e) {
			if (this.create_step030 != null) {
				this.create_step030.Dispose();
				this.create_step030 = null;
			}

			this.Parent_ref.Close();
		}
		#endregion
		//#endregion
	}
}