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
	public class frmManage_Updates_Create_step040 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lbxFields;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTableName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtSearchName;
		private System.Windows.Forms.TextBox txtUpdateName;

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
			this.label1 = new System.Windows.Forms.Label();
			this.txtUpdateName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSearchName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lbxFields = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTableName = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBack.Location = new System.Drawing.Point(16, 216);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(72, 23);
			this.btnBack.TabIndex = 11;
			this.btnBack.Text = "<< &Back";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(208, 216);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 10;
			this.btnNext.Text = "&Create!";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(8, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 13;
			this.label1.Text = "Update Name: ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtUpdateName
			// 
			this.txtUpdateName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtUpdateName.Location = new System.Drawing.Point(96, 184);
			this.txtUpdateName.Name = "txtUpdateName";
			this.txtUpdateName.Size = new System.Drawing.Size(184, 20);
			this.txtUpdateName.TabIndex = 12;
			this.txtUpdateName.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtSearchName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.lbxFields);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtTableName);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 168);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Update based on: ";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 17;
			this.label4.Text = "Search: ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSearchName
			// 
			this.txtSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchName.Location = new System.Drawing.Point(96, 40);
			this.txtSearchName.Name = "txtSearchName";
			this.txtSearchName.ReadOnly = true;
			this.txtSearchName.Size = new System.Drawing.Size(176, 20);
			this.txtSearchName.TabIndex = 16;
			this.txtSearchName.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 13;
			this.label2.Text = "Table: ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbxFields
			// 
			this.lbxFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lbxFields.Enabled = false;
			this.lbxFields.Location = new System.Drawing.Point(96, 64);
			this.lbxFields.Name = "lbxFields";
			this.lbxFields.Size = new System.Drawing.Size(176, 95);
			this.lbxFields.TabIndex = 14;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 15;
			this.label3.Text = "Update Fields: ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTableName
			// 
			this.txtTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTableName.Location = new System.Drawing.Point(96, 16);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.ReadOnly = true;
			this.txtTableName.Size = new System.Drawing.Size(176, 20);
			this.txtTableName.TabIndex = 12;
			this.txtTableName.Text = "";
			// 
			// frmManage_Updates_Create_step040
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 245);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtUpdateName);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnNext);
			this.Name = "frmManage_Updates_Create_step040";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Updates - Create";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_Updates_Create_step040(frmManage_Updates_Create_step030 Parent_ref_) {
			#region Required for Windows Form Designer support
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
		//#endregion
		//#region public Properties...
		public frmManage_Updates_Create_step030 Parent_ref;
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public new void Show();
		public new void Show() {
			txtTableName.Text = Parent_ref.Parent_ref.Parent_ref.TableName;
			txtSearchName.Text = Parent_ref.Parent_ref.SearchName;
			lbxFields.Items.Clear();
			string[] _fieldsname = Parent_ref.FieldsName;
			for (int f = 0; f < _fieldsname.Length; f++) {
				lbxFields.Items.Add(_fieldsname[f]);
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
			int _index = -1;
			//string[] _fieldparam;
			int t = frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection.Search(txtTableName.Text);
			int s = frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[t].TableSearches.TableSearchCollection.Search(txtSearchName.Text);
			if (frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[t].TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection.Search(txtUpdateName.Text) != -1) {
				MessageBox.Show("Update already exists, choose a diferent name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			} else {
				int u;
				frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
					t
				].TableSearches.TableSearchCollection[
					s
				].TableSearchUpdates.TableSearchUpdateCollection.Add(
					out u, 
					true, 
					new OGen.NTier.lib.metadata.metadataExtended.XS_tableSearchUpdateType(
						txtUpdateName.Text
					)
				);

				for (int f = 0; f < lbxFields.Items.Count; f++) {
					//_fieldparam = lbxFields.Items[f].ToString().Split(new char[] { '\\' });
					
					frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
						t
					].TableSearches.TableSearchCollection[
						s
					].TableSearchUpdates.TableSearchUpdateCollection[
						u
].TableUpdateParametersCollection.Add(
	true, 
	new OGen.NTier.lib.metadata.metadataExtended.XS_tableSearchUpdateParametersType()
);

frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
	t
].TableSearches.TableSearchCollection[
	s
].TableSearchUpdates.TableSearchUpdateCollection[
	u
].TableUpdateParametersCollection[
	_index
].TableName = txtTableName.Text;

frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
	t
].TableSearches.TableSearchCollection[
	s
].TableSearchUpdates.TableSearchUpdateCollection[
	u
].TableUpdateParametersCollection[
	_index
].TableFieldName = lbxFields.Items[f].ToString();

				}
				frm_Main.NTierProject.hasChanges = true;

				this.Parent_ref.Parent_ref.Parent_ref.Parent_ref.Parent_ref.Form_Refresh();
				this.Close();
			}
		}
		#endregion
		#region private void frmManage_Updates_Create_step030_Closed(...);
		private void frmManage_Updates_Create_step030_Closed(object sender, System.EventArgs e) {
			this.Parent_ref.Close();
		}
		#endregion
		//#endregion
	}
}
