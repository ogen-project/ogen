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
	public class frmManage_Searches_Create_step020 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnBack;
		private OGen.NTier.presentationlayer.winforms._controls.ucPick_Fields_forCriteria Pick_Fields_forCriteria;
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
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.Pick_Fields_forCriteria = new OGen.NTier.presentationlayer.winforms._controls.ucPick_Fields_forCriteria();
			this.SuspendLayout();
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBack.Location = new System.Drawing.Point(16, 312);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(72, 23);
			this.btnBack.TabIndex = 5;
			this.btnBack.Text = "<< &Back";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(216, 312);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "&Next >>";
			// 
			// Pick_Fields_forCriteria
			// 
			this.Pick_Fields_forCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Pick_Fields_forCriteria.Location = new System.Drawing.Point(8, 0);
			this.Pick_Fields_forCriteria.Name = "Pick_Fields_forCriteria";
			this.Pick_Fields_forCriteria.Size = new System.Drawing.Size(288, 304);
			this.Pick_Fields_forCriteria.TabIndex = 6;
			// 
			// frmManage_Searches_Create_step020
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(304, 341);
			this.Controls.Add(this.Pick_Fields_forCriteria);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnNext);
			this.Name = "frmManage_Searches_Create_step020";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Searches - Create";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_Searches_Create_step020(frmManage_Searches_Create_step010 Parent_ref_) {
			#region Required for Windows Form Designer support...
			InitializeComponent();
			#endregion
			#region Event safeguard...
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Closed += new System.EventHandler(this.frmManage_Searches_Create_step020_Closed);
			#endregion
			this.Parent_ref = Parent_ref_;
		}

		//#region private Properties...
		private frmManage_Searches_Create_step030 create_step030;
		//#endregion
		//#region public Properties...
		public frmManage_Searches_Create_step010 Parent_ref;
		#region public string[, ] FieldsName { get; }
		public string[, ] FieldsName {
			get {
				return this.Pick_Fields_forCriteria.FieldsName;
			}
		}
		#endregion
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public void Bind_Fields();
		public void Bind_Fields() {
			this.Pick_Fields_forCriteria.Bind_Fields(-1);
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
				this.create_step030 = new frmManage_Searches_Create_step030(this);
				this.create_step030.MdiParent = this.Parent_ref.MdiParent;
			}
			this.Hide();
			this.create_step030.Show();
		}
		#endregion
		#region private void frmManage_Searches_Create_step020_Closed(...);
		private void frmManage_Searches_Create_step020_Closed(object sender, System.EventArgs e) {
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