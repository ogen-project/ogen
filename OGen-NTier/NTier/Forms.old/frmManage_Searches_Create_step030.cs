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
	public class frmManage_Searches_Create_step030 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.TextBox txtSearchName;
		private System.Windows.Forms.CheckBox cbxIsRange;
		private System.Windows.Forms.CheckBox cbxIsExplicitUniqueIndex;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtTableName;
		private System.Windows.Forms.ListBox lbxFields;
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
			this.txtSearchName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbxIsRange = new System.Windows.Forms.CheckBox();
			this.cbxIsExplicitUniqueIndex = new System.Windows.Forms.CheckBox();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTableName = new System.Windows.Forms.TextBox();
			this.lbxFields = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtSearchName
			// 
			this.txtSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchName.Location = new System.Drawing.Point(96, 160);
			this.txtSearchName.Name = "txtSearchName";
			this.txtSearchName.Size = new System.Drawing.Size(192, 20);
			this.txtSearchName.TabIndex = 0;
			this.txtSearchName.Text = "";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(8, 160);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Search Name: ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxIsRange
			// 
			this.cbxIsRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cbxIsRange.Location = new System.Drawing.Point(96, 184);
			this.cbxIsRange.Name = "cbxIsRange";
			this.cbxIsRange.Size = new System.Drawing.Size(192, 24);
			this.cbxIsRange.TabIndex = 2;
			this.cbxIsRange.Text = "is Range";
			// 
			// cbxIsExplicitUniqueIndex
			// 
			this.cbxIsExplicitUniqueIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cbxIsExplicitUniqueIndex.Location = new System.Drawing.Point(96, 208);
			this.cbxIsExplicitUniqueIndex.Name = "cbxIsExplicitUniqueIndex";
			this.cbxIsExplicitUniqueIndex.Size = new System.Drawing.Size(192, 24);
			this.cbxIsExplicitUniqueIndex.TabIndex = 4;
			this.cbxIsExplicitUniqueIndex.Text = "is Explicit Unique Index";
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBack.Location = new System.Drawing.Point(16, 232);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(72, 23);
			this.btnBack.TabIndex = 7;
			this.btnBack.Text = "<< &Back";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(208, 232);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 6;
			this.btnNext.Text = "&Create!";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Table: ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTableName
			// 
			this.txtTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTableName.Location = new System.Drawing.Point(96, 16);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.ReadOnly = true;
			this.txtTableName.Size = new System.Drawing.Size(176, 20);
			this.txtTableName.TabIndex = 8;
			this.txtTableName.Text = "";
			// 
			// lbxFields
			// 
			this.lbxFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lbxFields.Enabled = false;
			this.lbxFields.Location = new System.Drawing.Point(96, 40);
			this.lbxFields.Name = "lbxFields";
			this.lbxFields.Size = new System.Drawing.Size(176, 95);
			this.lbxFields.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 11;
			this.label3.Text = "Criteria Fields: ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.lbxFields);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtTableName);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 144);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Search based on: ";
			// 
			// frmManage_Searches_Create_step030
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 261);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.cbxIsExplicitUniqueIndex);
			this.Controls.Add(this.cbxIsRange);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSearchName);
			this.Name = "frmManage_Searches_Create_step030";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Searches - Create";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_Searches_Create_step030(frmManage_Searches_Create_step020 Parent_ref_) {
			#region Required for Windows Form Designer support
			InitializeComponent();
			#endregion
			#region Event safeguard...
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Closed += new System.EventHandler(this.frmManage_Searches_Create_step030_Closed);
			#endregion
			this.Parent_ref = Parent_ref_;
		}

		//#region private Properties...
		//#endregion
		//#region public Properties...
		public frmManage_Searches_Create_step020 Parent_ref;
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public new void Show();
		public new void Show() {
			txtTableName.Text = Parent_ref.Parent_ref.TableName;
			lbxFields.Items.Clear();
			for (int f = 0; f < Parent_ref.FieldsName.GetLength(0); f++) {
				lbxFields.Items.Add(
					//new ListViewItem(
					//	new string[] {
							Parent_ref.FieldsName[f, 0]
					//		, Parent_ref.FieldsName[f, 1]
					//	}
					//)
				);
			}

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
			string[]	_param_tablefield;

			int t = frm_Main.NTierProject.Metadata.Tables.Search(txtTableName.Text);
			if (frm_Main.NTierProject.Metadata.Tables[t].Searches.Search(txtSearchName.Text) != -1) {
				MessageBox.Show("Search already exists, choose a diferent name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			} else {
				int s = frm_Main.NTierProject.Metadata.Tables[t].Searches.Add(txtSearchName.Text, true);

				frm_Main.NTierProject.Metadata.Tables[t].Searches[s].isRange = cbxIsRange.Checked;
				frm_Main.NTierProject.Metadata.Tables[t].Searches[s].isExplicitUniqueIndex = cbxIsExplicitUniqueIndex.Checked;

				for (int f = 0; f < Parent_ref.FieldsName.GetLength(0); f++) {
					_param_tablefield = Parent_ref.FieldsName[f, 1].ToString().Split(new char[] { '\\' });
					
					frm_Main.NTierProject.Metadata.Tables[t].Searches[s].SearchParameters.Add(
						_param_tablefield[0], 
						_param_tablefield[1], 
						true, 
						Parent_ref.FieldsName[f, 0]
					);
				}
				frm_Main.NTierProject.hasChanges = true;

				this.Parent_ref.Parent_ref.Parent_ref.Parent_ref.Form_Refresh();
				this.Close();
			}
		}
		#endregion
		#region private void frmManage_Searches_Create_step030_Closed(...);
		private void frmManage_Searches_Create_step030_Closed(object sender, System.EventArgs e) {
			this.Parent_ref.Close();
		}
		#endregion
		//#endregion
	}
}