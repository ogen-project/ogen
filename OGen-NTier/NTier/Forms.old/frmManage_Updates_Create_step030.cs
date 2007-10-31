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
	public class frmManage_Updates_Create_step030 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnNext;
		private OGen.NTier.presentationlayer.winforms._controls.ucPick_Fields_forCriteria Pick_Fields_forCriteria;

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
			this.btnBack.TabIndex = 9;
			this.btnBack.Text = "<< &Back";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(216, 312);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 8;
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
			this.Pick_Fields_forCriteria.TabIndex = 10;
			// 
			// frmManage_Updates_Create_step030
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(304, 341);
			this.Controls.Add(this.Pick_Fields_forCriteria);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnNext);
			this.Name = "frmManage_Updates_Create_step030";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Updates - Create";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_Updates_Create_step030(frmManage_Updates_Create_step020 Parent_ref_) {
			#region Required for Windows Form Designer support...
			InitializeComponent();
			#endregion
			#region Event safeguard...
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Closed += new System.EventHandler(this.frmManage_Updates_Create_step030_Closed);
			#endregion
			this.Parent_ref = Parent_ref_;
		}

		//#region private Properties...
		private frmManage_Updates_Create_step040 create_step040;
		//#endregion
		//#region public Properties...
		public frmManage_Updates_Create_step020 Parent_ref;
//		#region public string[] FieldsName { get; }
		public string[] FieldsName {
			get {
//				return this.Pick_Fields_forCriteria.FieldsName;
				string [] _temp = new string[
					this.Pick_Fields_forCriteria.FieldsName.GetUpperBound(0)
					- this.Pick_Fields_forCriteria.FieldsName.GetLowerBound(0)
					+ 1
				];
				int c = 0;
				for (
					int i = this.Pick_Fields_forCriteria.FieldsName.GetLowerBound(0); 
					i < this.Pick_Fields_forCriteria.FieldsName.GetUpperBound(0) + 1; 
					i++
				) {
					_temp[c++] = this.Pick_Fields_forCriteria.FieldsName[i, 0];
				}
				return _temp;
			}
		}
//		#endregion
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public void Bind_Fields();
		public void Bind_Fields() {
			this.Pick_Fields_forCriteria.Bind_Fields(
				frm_Main.NTierProject.Metadata.Tables.Search(
					Parent_ref.Parent_ref.TableName
				)
			);
		}
		#endregion
		#region public new void Show();
		public new void Show() {
			this.Bind_Fields();

			base.Show();
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
			if (this.create_step040 == null) {
				this.create_step040 = new frmManage_Updates_Create_step040(this);
				this.create_step040.MdiParent = this.Parent_ref.MdiParent;
			}
			this.Hide();
			this.create_step040.Show();
		}
		#endregion
		#region private void frmManage_Updates_Create_step030_Closed(...);
		private void frmManage_Updates_Create_step030_Closed(object sender, System.EventArgs e) {
			if (this.create_step040 != null) {
				this.create_step040.Dispose();
				this.create_step040 = null;
			}

			this.Parent_ref.Close();
		}
		#endregion
		//#endregion
	}
}