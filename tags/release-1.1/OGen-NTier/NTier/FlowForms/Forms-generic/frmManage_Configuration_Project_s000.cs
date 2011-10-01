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
using OGen.lib.datalayer;

namespace OGen.NTier.presentationlayer.winforms {
	public class frmTweak_Project_s000 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox Application;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDefault;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView lvwConnections;
		private System.Windows.Forms.ColumnHeader colMode;
		private System.Windows.Forms.ColumnHeader colConnectionstring;
		private System.Windows.Forms.ColumnHeader colDBServertype;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.ColumnHeader colDefault;
		private System.Windows.Forms.TextBox txtNamespace;
		private System.Windows.Forms.TextBox txtApplicationName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnPath;
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
			this.txtNamespace = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtApplicationName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Application = new System.Windows.Forms.GroupBox();
			this.btnPath = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnNew = new System.Windows.Forms.Button();
			this.lvwConnections = new System.Windows.Forms.ListView();
			this.colDefault = new System.Windows.Forms.ColumnHeader();
			this.colDBServertype = new System.Windows.Forms.ColumnHeader();
			this.colMode = new System.Windows.Forms.ColumnHeader();
			this.colConnectionstring = new System.Windows.Forms.ColumnHeader();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDefault = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.Application.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(376, 248);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 7;
			this.btnNext.Text = "&Update!";
			// 
			// txtNamespace
			// 
			this.txtNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNamespace.Location = new System.Drawing.Point(112, 64);
			this.txtNamespace.Name = "txtNamespace";
			this.txtNamespace.Size = new System.Drawing.Size(328, 20);
			this.txtNamespace.TabIndex = 6;
			this.txtNamespace.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Namespace: ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtApplicationName
			// 
			this.txtApplicationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtApplicationName.Location = new System.Drawing.Point(112, 40);
			this.txtApplicationName.Name = "txtApplicationName";
			this.txtApplicationName.Size = new System.Drawing.Size(328, 20);
			this.txtApplicationName.TabIndex = 4;
			this.txtApplicationName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Name: ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Application
			// 
			this.Application.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Application.Controls.Add(this.btnPath);
			this.Application.Controls.Add(this.label2);
			this.Application.Controls.Add(this.txtPath);
			this.Application.Controls.Add(this.txtNamespace);
			this.Application.Controls.Add(this.label4);
			this.Application.Controls.Add(this.label3);
			this.Application.Controls.Add(this.txtApplicationName);
			this.Application.Location = new System.Drawing.Point(8, 4);
			this.Application.Name = "Application";
			this.Application.Size = new System.Drawing.Size(448, 92);
			this.Application.TabIndex = 0;
			this.Application.TabStop = false;
			this.Application.Text = " Application: ";
			// 
			// btnPath
			// 
			this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPath.Location = new System.Drawing.Point(416, 16);
			this.btnPath.Name = "btnPath";
			this.btnPath.Size = new System.Drawing.Size(24, 23);
			this.btnPath.TabIndex = 2;
			this.btnPath.Text = "...";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Path: ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.Location = new System.Drawing.Point(112, 16);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(304, 20);
			this.txtPath.TabIndex = 1;
			this.txtPath.Text = "";
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Location = new System.Drawing.Point(368, 104);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(88, 23);
			this.btnNew.TabIndex = 3;
			this.btnNew.Text = "New";
			// 
			// lvwConnections
			// 
			this.lvwConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.colDefault,
																							 this.colDBServertype,
																							 this.colMode,
																							 this.colConnectionstring});
			this.lvwConnections.FullRowSelect = true;
			this.lvwConnections.HideSelection = false;
			this.lvwConnections.Location = new System.Drawing.Point(104, 104);
			this.lvwConnections.MultiSelect = false;
			this.lvwConnections.Name = "lvwConnections";
			this.lvwConnections.Size = new System.Drawing.Size(264, 136);
			this.lvwConnections.TabIndex = 2;
			this.lvwConnections.View = System.Windows.Forms.View.Details;
			// 
			// colDefault
			// 
			this.colDefault.Text = "";
			this.colDefault.Width = 15;
			// 
			// colDBServertype
			// 
			this.colDBServertype.Text = "Server Type";
			this.colDBServertype.Width = 70;
			// 
			// colMode
			// 
			this.colMode.Text = "Mode";
			// 
			// colConnectionstring
			// 
			this.colConnectionstring.Text = "Connectionstring";
			this.colConnectionstring.Width = 115;
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Location = new System.Drawing.Point(368, 128);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(88, 23);
			this.btnEdit.TabIndex = 4;
			this.btnEdit.Text = "Edit";
			// 
			// btnDefault
			// 
			this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDefault.Location = new System.Drawing.Point(368, 176);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.Size = new System.Drawing.Size(88, 23);
			this.btnDefault.TabIndex = 6;
			this.btnDefault.Text = "Make Default";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "DB Connections: ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.Location = new System.Drawing.Point(368, 152);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(88, 23);
			this.btnRemove.TabIndex = 5;
			this.btnRemove.Text = "Remove";
			// 
			// frmTweak_Project_s000
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 277);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnDefault);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.lvwConnections);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.Application);
			this.Controls.Add(this.btnNext);
			this.MinimumSize = new System.Drawing.Size(472, 264);
			this.Name = "frmTweak_Project_s000";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Project - Configuration";
			this.Application.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmTweak_Project_s000(
			cFlowformForm.dNotifyBase notifyBase_in, 
			cFlowformForm.dNotifyBase notifyBase_aboutNext_in, 
			cTweak_Project_s000.eMode mode_in
		) {
			#region Required for Windows Form Designer support...
			InitializeComponent();
			#endregion
			FlowformForm = new cFlowformForm(
				notifyBase_in, 
				notifyBase_aboutNext_in
			);
			#region Event safeguard...
			this.btnNext.Click += new System.EventHandler(FlowformForm.btnNext_Click);
			this.Closed += new System.EventHandler(FlowformForm.FlowformForm_Closed);

			this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
			#endregion

			Mode = mode_in;
		}

		#region enums...
		private enum eConnectionColumns {
			Default = 0,
			DBServerType = 1,
			DBMode = 2,
			DBConnectionstring = 3
		}
		#endregion

		#region private Properties...
		private cFlowformForm FlowformForm;
		#region private eMode Mode { get; set; }
		private cTweak_Project_s000.eMode mode__;
		private cTweak_Project_s000.eMode Mode {
			get { return mode__; }
			set {
				mode__ = value;
				switch (mode__) {
					case cTweak_Project_s000.eMode.New: {
						Text = "Project - Configuration - New";
						btnNext.Text = "&New!";
						txtPath.ReadOnly = false;
						btnPath.Enabled = true;
						break;
					}
					case cTweak_Project_s000.eMode.Update: {
						Text = "Project - Configuration - Updating";
						btnNext.Text = "&Update!";
						txtPath.ReadOnly = true;
						btnPath.Enabled = false;
						break;
					}
				}
			}
		}
		#endregion
		#endregion
		//#region public Properties...
		#region public string ApplicationPath { get; set; }
		public string ApplicationPath {
			get { return txtPath.Text; }
			set { txtPath.Text = value; }
		}
		#endregion
		#region public string ApplicationName { get; set; }
		public string ApplicationName {
			get { return txtApplicationName.Text; }
			set { txtApplicationName.Text = value; }
		}
		#endregion
		#region public string Namespace { get; set; }
		public string Namespace {
			get { return txtNamespace.Text; }
			set { txtNamespace.Text = value; }
		}
		#endregion
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public cDBMetadata_DB[] DBConnections();
		/// <summary>
		/// first item in the array, represents default db connection
		/// </summary>
		/// <returns></returns>
		public OGen.NTier.lib.metadata.metadataExtended.XS_dbType[] UnBind_DBConnections() {
			OGen.NTier.lib.metadata.metadataExtended.XS_dbType[] DBConnections_out;
			ArrayList _dbservertypes;
			DBServerTypes _dbservertype;
			int _dbindex;
			int _justadded = -1;

			_dbservertypes = new ArrayList();
			for (int i = 0; i < lvwConnections.Items.Count; i++) {
				if ( // if Default
					lvwConnections.Items[i].SubItems[(int)eConnectionColumns.Default].Text
					!=
					string.Empty
				) {
					_dbservertype = (DBServerTypes)Enum.Parse(
						typeof(DBServerTypes),
						lvwConnections.Items[i].SubItems[
							(int)eConnectionColumns.DBServerType
						].Text
					);

					//if (!_dbservertypes.Contains(_dbservertype)) // no need to check!
						_dbservertypes.Add(_dbservertype);

					break; // default was found
				}
			}
			for (int i = 0; i < lvwConnections.Items.Count; i++) {
				if ( // if !Default
					lvwConnections.Items[i].SubItems[(int)eConnectionColumns.Default].Text
					==
					string.Empty
				) {
					_dbservertype = (DBServerTypes)Enum.Parse(
						typeof(DBServerTypes),
						lvwConnections.Items[i].SubItems[
							(int)eConnectionColumns.DBServerType
						].Text
					);

					if (!_dbservertypes.Contains(_dbservertype))
						_dbservertypes.Add(_dbservertype);
				}
			}
			//---
			DBConnections_out 
				= new OGen.NTier.lib.metadata.metadataExtended.XS_dbType[
					_dbservertypes.Count
				];
			//---
			for (int i = 0; i < _dbservertypes.Count; i++) {
				DBConnections_out[i] = new OGen.NTier.lib.metadata.metadataExtended.XS_dbType(
					((DBServerTypes)_dbservertypes[i]).ToString()
				);
			}


			for (int i = 0; i < lvwConnections.Items.Count; i++) {
				_dbservertype 
					= (DBServerTypes)Enum.Parse(
						typeof(DBServerTypes),
						lvwConnections.Items[i].SubItems[
							(int)eConnectionColumns.DBServerType
						].Text
					);
				_dbindex = _dbservertypes.IndexOf(_dbservertype);
				DBConnections_out[_dbindex].DBConnections.DBConnectionCollection.Add(
					out _justadded, 
					true, 
					new OGen.NTier.lib.metadata.metadataExtended.XS_dbConnectionType(
						lvwConnections.Items[i].SubItems[
							(int)eConnectionColumns.DBMode
						].Text
					)
				);

// ToDos: here!
DBConnections_out[_dbindex].DBConnections.DBConnectionCollection[_justadded].generateSQL = true;

				DBConnections_out[_dbindex].DBConnections.DBConnectionCollection[_justadded].Connectionstring
					= lvwConnections.Items[i].SubItems[
						(int)eConnectionColumns.DBConnectionstring
					].Text;

				DBConnections_out[_dbindex].DBConnections.DBConnectionCollection[_justadded].isDefault = (
					lvwConnections.Items[i].SubItems[(int)eConnectionColumns.Default].Text
					!=
					string.Empty
				);
			}

			return DBConnections_out;
		}
		#endregion
		#region public void Bind_DBConnections(...);
		public void Bind_DBConnections() {
			lvwConnections.Items.Clear();
		}
		public void Bind_DBConnections(
			OGen.NTier.lib.metadata.metadataExtended.XS_dbType[] dbMetadata_DB_in
			//, OGen.lib.datalayer.DBServerTypes default_DBServerType_in,
			//string default_Mode_in
		) {
			lvwConnections.Items.Clear();
			for (int _db = 0; _db < dbMetadata_DB_in.Length; _db++) {
				for (int _con = 0; _con < dbMetadata_DB_in[_db].DBConnections.DBConnectionCollection.Count; _con++) {
					lvwConnections.Items.Add(
						new ListViewItem(
							new string[] {
								//(
								//    (default_DBServerType_in == dbMetadata_DB_in[_db].DBServerType)
								//    &&
								//    (default_Mode_in == dbMetadata_DB_in[_db].Connections[_con].ConfigMode)
								//) ? "*" : string.Empty, 
								string.Empty, 
								dbMetadata_DB_in[_db].DBServerType.ToString(), 
								dbMetadata_DB_in[_db].DBConnections.DBConnectionCollection[_con].ConfigMode,
								dbMetadata_DB_in[_db].DBConnections.DBConnectionCollection[_con].Connectionstring
							}
						)
					);
				}
			}
		}
		#endregion
		//#endregion

		//#region Events...
		#region private void btnNew_Click(object sender, System.EventArgs e);
		private void btnNew_Click(object sender, System.EventArgs e) {
			frmConnectionstring connection = new frmConnectionstring();
			connection.DBMode = "DEBUG";
			switch (connection.ShowDialog()) {
				case DialogResult.OK: {
					bool _thecombinationexists = false;
					for (int i = 0; i < lvwConnections.Items.Count; i++) {
						if (
							(lvwConnections.Items[i].SubItems[(int)eConnectionColumns.DBServerType].Text == connection.DBServerType.ToString())
							&&
							(lvwConnections.Items[i].SubItems[(int)eConnectionColumns.DBMode].Text == connection.DBMode)
						) {
							if (
								System.Windows.Forms.MessageBox.Show(
									"such combination exists, overwrite it?",
									"combination exists",
									System.Windows.Forms.MessageBoxButtons.OKCancel,
									System.Windows.Forms.MessageBoxIcon.Warning
								) != System.Windows.Forms.DialogResult.Cancel
							) {
								lvwConnections.Items[i].SubItems[(int)eConnectionColumns.Default].Text = string.Empty;
								lvwConnections.Items[i].SubItems[(int)eConnectionColumns.DBServerType].Text = connection.DBServerType.ToString();
								lvwConnections.Items[i].SubItems[(int)eConnectionColumns.DBMode].Text = connection.DBMode;
								lvwConnections.Items[i].SubItems[(int)eConnectionColumns.DBConnectionstring].Text = connection.DBConnectionstring;
							}
							_thecombinationexists = true;
							break; // no need to keep searching, combination has been found...
						}
					}
					if (!_thecombinationexists) {
						lvwConnections.Items.Add(
							new ListViewItem(
								new string[] {
									(lvwConnections.Items.Count == 0) ? "*" : string.Empty, 
									connection.DBServerType.ToString(), 
									connection.DBMode,
									connection.DBConnectionstring
								}
							)
						);
					}
					break;
				}
				case DialogResult.Cancel: {
					break;
				}
			}
		}
		#endregion
		#region private void btnEdit_Click(object sender, System.EventArgs e);
		private void btnEdit_Click(object sender, System.EventArgs e) {
			if (lvwConnections.SelectedItems.Count == 1) {
				frmConnectionstring connection = new frmConnectionstring();
				connection.DBServerType = (DBServerTypes)Enum.Parse(
					typeof(DBServerTypes),
					lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.DBServerType].Text
				);
				connection.DBMode = lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.DBMode].Text;
				connection.DBConnectionstring = lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.DBConnectionstring].Text;
				switch (connection.ShowDialog()) {
					case DialogResult.OK: {
						bool _samecombinationalreadyexists = false;
						for (int i = 0; i < lvwConnections.Items.Count; i++) {
							if (
								(lvwConnections.Items[i].SubItems[(int)eConnectionColumns.DBServerType].Text == connection.DBServerType.ToString())
								&&
								(lvwConnections.Items[i].SubItems[(int)eConnectionColumns.DBMode].Text == connection.DBMode)

								&&
								(i != lvwConnections.SelectedItems[0].Index)
							) {
								if (
									System.Windows.Forms.MessageBox.Show(
										"such combination exists, overwrite it?",
										"combination exists",
										System.Windows.Forms.MessageBoxButtons.OKCancel,
										System.Windows.Forms.MessageBoxIcon.Warning
									) != System.Windows.Forms.DialogResult.Cancel
								) {
									// leave it as it is:
									lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.Default].Text 
										= lvwConnections.Items[i].SubItems[(int)eConnectionColumns.Default].Text ;

									// update other properties:
									lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.DBServerType].Text = connection.DBServerType.ToString();
									lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.DBMode].Text = connection.DBMode;
									lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.DBConnectionstring].Text = connection.DBConnectionstring;

									lvwConnections.Items.RemoveAt(i);
								}
								_samecombinationalreadyexists = true;
								break; // no need to keep searching, combination has been found...
							}
						}
						if (!_samecombinationalreadyexists) {
							// leave it as it is:
							//lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.Default].Text = string.Empty;

							// update other properties:
							lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.DBServerType].Text = connection.DBServerType.ToString();
							lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.DBMode].Text = connection.DBMode;
							lvwConnections.SelectedItems[0].SubItems[(int)eConnectionColumns.DBConnectionstring].Text = connection.DBConnectionstring;
						}
						break;
					}
					case DialogResult.Cancel: {
						break;
					}
				}
			}
		}
		#endregion
		#region private void btnDefault_Click(object sender, System.EventArgs e);
		private void btnDefault_Click(object sender, System.EventArgs e) {
			if (lvwConnections.SelectedItems.Count == 1) {
				for (int i = 0; i < lvwConnections.Items.Count; i++) {
					lvwConnections.Items[i].SubItems[(int)eConnectionColumns.Default].Text 
						= (lvwConnections.SelectedItems[0].Index == i) 
						? "*" 
						: string.Empty;
				}
			}
		}
		#endregion
		#region private void btnRemove_Click(object sender, System.EventArgs e);
		private void btnRemove_Click(object sender, System.EventArgs e) {
			if (lvwConnections.SelectedItems.Count == 1) {
				lvwConnections.Items.RemoveAt(
					lvwConnections.SelectedItems[0].Index
				);
			}
		}
		#endregion
		#region private void btnPath_Click(object sender, System.EventArgs e);
		private void btnPath_Click(object sender, System.EventArgs e) {
			FolderBrowserDialog folderbrowser = new FolderBrowserDialog();
			folderbrowser.ShowNewFolderButton = true;
			switch (folderbrowser.ShowDialog()) {
				case DialogResult.OK: {
					ApplicationPath = folderbrowser.SelectedPath;
					break;
				}
			}
		}
		#endregion
		//#endregion
	}
}
