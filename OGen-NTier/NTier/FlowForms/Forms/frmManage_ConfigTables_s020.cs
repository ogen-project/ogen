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
using OGen.lib.presentationlayer.winforms.Flowforms;

namespace OGen.NTier.presentationlayer.winforms {
	public class frmManage_ConfigTables_CreateOrChange_s020 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxName;
		private System.Windows.Forms.ComboBox cbxConfig;
		private System.Windows.Forms.ComboBox cbxDatatype;
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxName = new System.Windows.Forms.ComboBox();
			this.cbxConfig = new System.Windows.Forms.ComboBox();
			this.cbxDatatype = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBack.Location = new System.Drawing.Point(16, 80);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(72, 23);
			this.btnBack.TabIndex = 5;
			this.btnBack.Text = "<< &Back";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(248, 80);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "&Next >>";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.Location = new System.Drawing.Point(8, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "&Name Field:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.Location = new System.Drawing.Point(8, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "&Config Field:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.Location = new System.Drawing.Point(8, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 11;
			this.label3.Text = "&Datatype Field:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxName
			// 
			this.cbxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cbxName.Location = new System.Drawing.Point(104, 4);
			this.cbxName.Name = "cbxName";
			this.cbxName.Size = new System.Drawing.Size(224, 21);
			this.cbxName.TabIndex = 12;
			// 
			// cbxConfig
			// 
			this.cbxConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxConfig.Location = new System.Drawing.Point(104, 28);
			this.cbxConfig.Name = "cbxConfig";
			this.cbxConfig.Size = new System.Drawing.Size(224, 21);
			this.cbxConfig.TabIndex = 13;
			// 
			// cbxDatatype
			// 
			this.cbxDatatype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxDatatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxDatatype.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cbxDatatype.Location = new System.Drawing.Point(104, 52);
			this.cbxDatatype.Name = "cbxDatatype";
			this.cbxDatatype.Size = new System.Drawing.Size(224, 21);
			this.cbxDatatype.TabIndex = 14;
			// 
			// frmManage_ConfigTables_CreateOrChange_s020
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 109);
			this.Controls.Add(this.cbxDatatype);
			this.Controls.Add(this.cbxConfig);
			this.Controls.Add(this.cbxName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnNext);
			this.MinimumSize = new System.Drawing.Size(192, 136);
			this.Name = "frmManage_ConfigTables_CreateOrChange_s020";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Config Tables";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_ConfigTables_CreateOrChange_s020(
			cFlowformForm.dNotifyBase NotifyBase_, 
			cFlowformForm.dNotifyBase NotifyBase_aboutNext_
		) {
			#region Required for Windows Form Designer support...
			InitializeComponent();
			#endregion
			FlowformForm = new cFlowformForm(
				NotifyBase_, 
				NotifyBase_aboutNext_
			);
			#region Event safeguard...
			this.btnBack.Click += new System.EventHandler(FlowformForm.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(FlowformForm.btnNext_Click);
			this.Closed += new System.EventHandler(FlowformForm.FlowformForm_Closed);
			#endregion
		}

		#region private Properties...
		private cFlowformForm FlowformForm;
		#endregion
		//#region public Properties...
		public string ConfigField {
			get { return cbxConfig.Items[cbxConfig.SelectedIndex].ToString(); }
		}
		public string DatatypeField {
			get { return cbxDatatype.Items[cbxDatatype.SelectedIndex].ToString(); }
		}
		public string NameField {
			get { return cbxName.Items[cbxName.SelectedIndex].ToString(); }
		}
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public void Bind(...);
		private string tablename = "";
		private eInsUpdDel choice;
		public void Bind(string TableName_, eInsUpdDel Choice_) {
			if (TableName_ == tablename) return;

			tablename = TableName_;
			choice = Choice_;

			cbxName.Items.Clear();
			cbxConfig.Items.Clear();
			cbxDatatype.Items.Clear();
			//for (int f = frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName_].TableFields.TableFieldCollection.Count - 1; f >= 0; f--) {
			for (int f = 0; f < frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName_].TableFields.TableFieldCollection.Count; f++) {
				if (
//frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
//	TableName_
//].TableFields.TableFieldCollection[f].canBeConfig_Type
frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection[
	TableName_
].TableFields.TableFieldCollection[
	frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
		TableName_
	].TableFields.TableFieldCollection[f].Name
].canBeConfig_Type
				) {
					cbxDatatype.Items.Add(
						frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName_].TableFields.TableFieldCollection[f].Name
					);
					cbxDatatype.SelectedIndex
						= cbxDatatype.Items.Count - 1;
				} else if (
//frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
//	TableName_
//].TableFields.TableFieldCollection[f].canBeConfig_Name
frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection[
	TableName_
].TableFields.TableFieldCollection[
	frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
		TableName_
	].TableFields.TableFieldCollection[
		f
	].Name
].canBeConfig_Name
				) {
					cbxName.Items.Add(
						frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName_].TableFields.TableFieldCollection[f].Name
					);
					if (
(
//	frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
//		TableName_
//	].TableFields.TableFieldCollection[f].isConfig_Name

	frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
		TableName_
	].ConfigName
	==
	frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
		TableName_
	].TableFields.TableFieldCollection[f].Name
)
						||
						(
							(Choice_ == eInsUpdDel.Insert)
							&&
							(frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName_].TableFields.TableFieldCollection[f].Name.ToLower().IndexOf("name") >= 0)
						)
					)
						cbxName.SelectedIndex
							= cbxName.Items.Count - 1;
				} else if (
//frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
//	TableName_
//].TableFields.TableFieldCollection[
//	f
//].canBeConfig_Config
frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection[
	TableName_
].TableFields.TableFieldCollection[
	frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
		TableName_
	].TableFields.TableFieldCollection[
		f
	].Name
].canBeConfig_Config
				) {
					cbxConfig.Items.Add(
						frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName_].TableFields.TableFieldCollection[f].Name
					);
					if (
(
//	frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
//		TableName_
//	].TableFields.TableFieldCollection[f].isConfig_Config

	frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
		TableName_
	].ConfigConfig
	==
	frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
		TableName_
	].TableFields.TableFieldCollection[f].Name
)
						||
						(
							(Choice_ == eInsUpdDel.Insert)
							&&
							(frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName_].TableFields.TableFieldCollection[f].Name.ToLower().IndexOf("config") >= 0)
						)
					)
						cbxConfig.SelectedIndex
							= cbxConfig.Items.Count - 1;
				}
			}
			switch (Choice_) {
				case eInsUpdDel.Insert:
					btnNext.Text = "Create!";
					break;
				case eInsUpdDel.Update:
					btnNext.Text = "Change!";
					break;
			}
		}
		#endregion
		//#endregion

		#region Events...
		#endregion
	}
}
