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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace OGen.NTier.presentationlayer.winforms._controls {
	public class ucPick_Fields_forCriteria : System.Windows.Forms.UserControl {
		#region Required designer variable...
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListView lvwFields;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnMove_Down;
		private System.Windows.Forms.Button btnMove_Up;
		private System.Windows.Forms.Button btnAdd;
		private OGen.NTier.presentationlayer.winforms.ucPick_Fields Pick_Fields;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.CheckBox chkTables;
		private System.Windows.Forms.ColumnHeader colParamName;
		private System.Windows.Forms.ColumnHeader colFieldName;
		private System.Windows.Forms.Label lblTitle;

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.lvwFields = new System.Windows.Forms.ListView();
			this.colParamName = new System.Windows.Forms.ColumnHeader();
			this.colFieldName = new System.Windows.Forms.ColumnHeader();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnMove_Down = new System.Windows.Forms.Button();
			this.btnMove_Up = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.Pick_Fields = new OGen.NTier.presentationlayer.winforms.ucPick_Fields();
			this.lblTitle = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEdit = new System.Windows.Forms.Button();
			this.chkTables = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// lvwFields
			// 
			this.lvwFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.colParamName,
																						this.colFieldName});
			this.lvwFields.FullRowSelect = true;
			this.lvwFields.HideSelection = false;
			this.lvwFields.LabelEdit = true;
			this.lvwFields.Location = new System.Drawing.Point(0, 176);
			this.lvwFields.Name = "lvwFields";
			this.lvwFields.Size = new System.Drawing.Size(224, 144);
			this.lvwFields.TabIndex = 20;
			this.lvwFields.View = System.Windows.Forms.View.Details;
			// 
			// colParamName
			// 
			this.colParamName.Text = "Parameter Name";
			this.colParamName.Width = 100;
			// 
			// colFieldName
			// 
			this.colFieldName.Text = "Field Name";
			this.colFieldName.Width = 100;
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.Location = new System.Drawing.Point(232, 224);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(72, 23);
			this.btnRemove.TabIndex = 19;
			this.btnRemove.Text = "&Remove";
			// 
			// btnMove_Down
			// 
			this.btnMove_Down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMove_Down.Enabled = false;
			this.btnMove_Down.Location = new System.Drawing.Point(232, 200);
			this.btnMove_Down.Name = "btnMove_Down";
			this.btnMove_Down.Size = new System.Drawing.Size(72, 23);
			this.btnMove_Down.TabIndex = 18;
			this.btnMove_Down.Text = "Move &Down";
			// 
			// btnMove_Up
			// 
			this.btnMove_Up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMove_Up.Enabled = false;
			this.btnMove_Up.Location = new System.Drawing.Point(232, 176);
			this.btnMove_Up.Name = "btnMove_Up";
			this.btnMove_Up.Size = new System.Drawing.Size(72, 23);
			this.btnMove_Up.TabIndex = 17;
			this.btnMove_Up.Text = "Move &Up";
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(232, 24);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(72, 23);
			this.btnAdd.TabIndex = 16;
			this.btnAdd.Text = "&Add";
			// 
			// Pick_Fields
			// 
			this.Pick_Fields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Pick_Fields.Location = new System.Drawing.Point(0, 24);
			this.Pick_Fields.Name = "Pick_Fields";
			this.Pick_Fields.Size = new System.Drawing.Size(224, 128);
			this.Pick_Fields.TabIndex = 15;
			// 
			// lblTitle
			// 
			this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblTitle.Location = new System.Drawing.Point(0, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(296, 23);
			this.lblTitle.TabIndex = 14;
			this.lblTitle.Text = "Choose Fields:";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(0, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(296, 23);
			this.label1.TabIndex = 21;
			this.label1.Text = "Search Parameters (editable Parameter Name):";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Location = new System.Drawing.Point(232, 248);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(72, 23);
			this.btnEdit.TabIndex = 22;
			this.btnEdit.Text = "&Edit";
			this.btnEdit.Visible = false;
			// 
			// chkTables
			// 
			this.chkTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkTables.Location = new System.Drawing.Point(224, 128);
			this.chkTables.Name = "chkTables";
			this.chkTables.Size = new System.Drawing.Size(80, 24);
			this.chkTables.TabIndex = 23;
			this.chkTables.Text = "All Tables";
			this.chkTables.Visible = false;
			// 
			// ucPick_Fields_forCriteria
			// 
			this.Controls.Add(this.chkTables);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lvwFields);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnMove_Down);
			this.Controls.Add(this.btnMove_Up);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.Pick_Fields);
			this.Controls.Add(this.lblTitle);
			this.Name = "ucPick_Fields_forCriteria";
			this.Size = new System.Drawing.Size(304, 320);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public ucPick_Fields_forCriteria() {
			#region This call is required by the Windows.Forms Form Designer...
			InitializeComponent();
			#endregion
			#region Event safeguard...
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnMove_Up.Click += new System.EventHandler(this.btnMove_Up_Click);
			this.btnMove_Down.Click += new System.EventHandler(this.btnMove_Down_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			#endregion
		}

		#region private Properties...
		#endregion
		//#region public Properties...
		#region public string[] FieldsName { get; }
		public string[, ] FieldsName {
			get {
				string[, ] FieldsName_out = new string[lvwFields.Items.Count, 2];
				for (int f = 0; f < lvwFields.Items.Count; f++) {
					FieldsName_out[f, 0] = lvwFields.Items[f].SubItems[0].Text;
					FieldsName_out[f, 1] = lvwFields.Items[f].SubItems[1].Text;
				}
				return FieldsName_out;
			}
		}
		#endregion
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public void Bind_Fields();
		public void Bind_Fields(int Table_) {
			this.Pick_Fields.Bind_Fields(
				ucPick_Fields.eType.All, 
				true, 
				Table_, 
				ucPick_Fields.eType.None
			);
		}
		#endregion
		//#endregion

		//#region Events...
		#region private void btnAdd_Click(...);
		private void btnAdd_Click(object sender, System.EventArgs e) {
			string[] _SelectedFields = this.Pick_Fields.SelectedFields();
			for (int f = 0; f < _SelectedFields.Length; f++) {
				if (_SelectedFields[f].IndexOf("\\") >= 0) {
					lvwFields.Items.Add(
						new ListViewItem(
							new string[] {
								_SelectedFields[f].Split(new char[] { '\\' })[1], 
								_SelectedFields[f]
							}
						)
					);
				} else {
					lvwFields.Items.Add(
						new ListViewItem(
							new string[] {
								_SelectedFields[f], 
								_SelectedFields[f]
							}
						)
					);
				}
			}
			this.Pick_Fields.SelectThisFields();
		}
		#endregion
		//#region private void btnMove_Up_Click(...);
		private void btnMove_Up_Click(object sender, System.EventArgs e) {
			// ToDos: here!
		}
		//#endregion
		//#region private void btnMove_Down_Click(...);
		private void btnMove_Down_Click(object sender, System.EventArgs e) {
			// ToDos: here!
		}
		//#endregion
		#region private void btnRemove_Click(...);
		private void btnRemove_Click(object sender, System.EventArgs e) {
			for (int f = 0; f < lvwFields.Items.Count; f++) {
				if (lvwFields.Items[f].Selected) {
					lvwFields.Items.RemoveAt(f);
				}
			}
		}
		#endregion
		//#endregion
	}
}