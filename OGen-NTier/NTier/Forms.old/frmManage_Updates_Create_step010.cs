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
	public class frmManage_Updates_Create_step010 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnNext;
		private OGen.NTier.presentationlayer.winforms.ucPick_Tables Pick_Tables;

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
			this.label1 = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.Pick_Tables = new OGen.NTier.presentationlayer.winforms.ucPick_Tables();
			this.SuspendLayout();
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBack.Location = new System.Drawing.Point(16, 248);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(72, 23);
			this.btnBack.TabIndex = 7;
			this.btnBack.Text = "<< &Back";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Choose Table:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(208, 248);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 5;
			this.btnNext.Text = "&Next >>";
			// 
			// Pick_Tables
			// 
			this.Pick_Tables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Pick_Tables.Location = new System.Drawing.Point(8, 24);
			this.Pick_Tables.Name = "Pick_Tables";
			this.Pick_Tables.Size = new System.Drawing.Size(280, 216);
			this.Pick_Tables.TabIndex = 4;
			// 
			// frmManage_Updates_Create_step010
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 277);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.Pick_Tables);
			this.Name = "frmManage_Updates_Create_step010";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Updates - Create";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_Updates_Create_step010(frmManage_Updates Parent_ref_) {
			#region Required for Windows Form Designer support...
			InitializeComponent();
			#endregion
			#region Event safeguard...
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Closed += new System.EventHandler(this.frmManage_Updates_Create_step010_Closed);
			#endregion
			this.Parent_ref = Parent_ref_;
		}

		//#region private Properties...
		private frmManage_Updates_Create_step020 create_step020;
		//#endregion
		//#region public Properties...
		public frmManage_Updates Parent_ref;
		#region public string TableName { get; }
		public string TableName {
			get {
				string[] _SelectedTables = this.Pick_Tables.SelectedTables();
				return (_SelectedTables.Length == 0) ? 
					"" : 
					this.Pick_Tables.SelectedTables()[0];
			}
		}
		#endregion
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public void Bind_Tables();
		public void Bind_Tables() {
			this.Pick_Tables.Bind_Tables(ucPick_Tables.eTypeSelection.All, false);
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
			if (this.create_step020 == null) {
				this.create_step020 = new frmManage_Updates_Create_step020(this);
				this.create_step020.MdiParent = this.Parent_ref.MdiParent;
			}
			this.create_step020.Bind_Searches();

			this.Hide();
			this.create_step020.Show();
		}
		#endregion
		#region private void frmManage_Updates_Create_step010_Closed(...);
		private void frmManage_Updates_Create_step010_Closed(object sender, System.EventArgs e) {
			if (this.create_step020 != null) {
				this.create_step020.Dispose();
				this.create_step020 = null;
			}

			this.Parent_ref.Close();
		}
		#endregion
		//#endregion
	}
}