#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.PresentationLayer.WinForms {
	using System;
	using OGen.Libraries.PresentationLayer.WinForms.FlowForms;

	public class cTweak_Project_s000 : Flowform {
		#region public cTweak_Project_s000(...);
		public cTweak_Project_s000(
			frm_Main base_ref_in, 
			cTweak_Project_s000.eMode mode_in
		) : this (
			base_ref_in, 
			mode_in, 
			null
		) {}
		public cTweak_Project_s000(
			frm_Main base_ref_in, 
			cTweak_Project_s000.eMode mode_in, 
			dNotifyBase notifyBase_in
		) : base (
			notifyBase_in, 
			1
		) {
			this.Base_ref = base_ref_in;
			this.mode_ = mode_in;

			this.MyForm = new frmTweak_Project_s000(
				new FlowformForm.dNotifyBase(
					this.MyForm_notifiedMe
				),
				new FlowformForm.dNotifyBase(
					this.MyForm_notifiedMe_aboutNext
				), 
				mode_in
			);
			this.MyForm.MdiParent = this.Base_ref;
			//this.MyForm.MaximizeBox = false;

//			this.MyProcess = new PO_Tweak_Project(Base_ref);
		}

		protected override void Dispose(bool disposing_in) {
//			this.MyProcess.Dispose();

			base.Dispose(disposing_in);
		}
		#endregion

		#region enums...
		public enum eMode : int {
			New = 0, 
			Update = 1
		}
		#endregion

		private void MyForm_notifiedMe_aboutNext(FlowformFormEvents SomeEvent_) {
			switch (SomeEvent_) {
				case FlowformFormEvents.Next:
					#region Checking...
					if (
						(this.mode_ == eMode.New) 
						&&
						(string.IsNullOrEmpty(this.MyForm.ApplicationPath))
					) {
						System.Windows.Forms.MessageBox.Show(
							"must provide a valid Application Path",
							"Warning",
							System.Windows.Forms.MessageBoxButtons.OK,
							System.Windows.Forms.MessageBoxIcon.Warning
						);
						return;
					}
					if (
						(this.mode_ == eMode.New) 
						&& 
						(
							(System.IO.Directory.GetDirectories(this.MyForm.ApplicationPath).Length != 0)
							||
							(System.IO.Directory.GetFiles(this.MyForm.ApplicationPath).Length != 0)
						)
					) {
						switch(System.Windows.Forms.MessageBox.Show(
							"provided Application Path is not empty,\nfile overwrite may occur,\ncontinue?",
							"Warning",
							System.Windows.Forms.MessageBoxButtons.OKCancel,
							System.Windows.Forms.MessageBoxIcon.Warning
						)) {
							case System.Windows.Forms.DialogResult.OK: {
								break;
							}
							case System.Windows.Forms.DialogResult.Cancel: {
								return;
							}
						}
					}
					if (string.IsNullOrEmpty(this.MyForm.ApplicationName)) {
						System.Windows.Forms.MessageBox.Show(
							"must provide a valid Application Name",
							"Warning",
							System.Windows.Forms.MessageBoxButtons.OK,
							System.Windows.Forms.MessageBoxIcon.Warning
						);
						return;
					}
					if (string.IsNullOrEmpty(this.MyForm.Namespace)) {
						System.Windows.Forms.MessageBox.Show(
							"must provide a valid Application Namespace",
							"Warning",
							System.Windows.Forms.MessageBoxButtons.OK,
							System.Windows.Forms.MessageBoxIcon.Warning
						);
						return;
					}
					#endregion
					OGen.NTier.Libraries.Metadata.MetadataExtended.XS_dbType[]
						_dbs = this.MyForm.UnBind_DBConnections();
					#region More Checking...
					if (_dbs.Length == 0) {
						System.Windows.Forms.MessageBox.Show(
							"must provide at least one valid DB Connection",
							"Warning",
							System.Windows.Forms.MessageBoxButtons.OK,
							System.Windows.Forms.MessageBoxIcon.Warning
						);
						return;
					}
					#endregion
					if (this.mode_ == eMode.Update) {
						#region Updating...
						frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].DBs.DBCollection.Clear();
						int _justadded = -1;
						for (int d = 0; d < _dbs.Length; d++) {
							frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].DBs.DBCollection.Add(
								out _justadded,
								false, 
								new OGen.NTier.Libraries.Metadata.MetadataExtended.XS_dbType(
									_dbs[d].DBServerType.ToString()
								)
							);
							frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].DBs.DBCollection[
								_justadded
							].CopyFrom(
								_dbs[d]
							);
							//if (d == 0) {
							//    // ToDos: here! document this behaviour and describe it throught unit testing
							//    // first item in the array, represents default db connection
							//    frm_Main.ntierproject.Metadata.Default_DBServerType = frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].DBs.DBCollection[_justadded].DBServerType;
							//    frm_Main.ntierproject.Metadata.Default_ConfigMode = frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].DBs.DBCollection[_justadded].Connections[0].ConfigMode;
							//}
						}

						frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].ApplicationName
							= this.MyForm.ApplicationName;
						frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].ApplicationNamespace
							= this.MyForm.Namespace;
						#endregion
						frm_Main.NTierProject.hasChanges = true;
					} else {
						#region Creating...
						this.MyForm.Hide();

						frmProcessOutput _output = new frmProcessOutput("Output");
						_output.MdiParent = this.Base_ref;
						_output.Show();

						frm_Main.ntierproject.New(
							this.MyForm.ApplicationPath,
							this.MyForm.ApplicationName,
							this.MyForm.Namespace, 
							_dbs,
							new OGen.NTier.Libraries.Generator.NTierGenerator.dNotifyBack(
								_output.DisplayMessage
							)
						);

						_output.DisplayMessage();
						#endregion
					}
					this.Base_ref.Form_Refresh();

					this.MyForm.Hide();
					this.NotifyBase(FlowformEvents.Closed, this);
					break;
			}
		}

		#region private Properties...
		private frm_Main Base_ref;
//		private PO_Tweak_Project MyProcess;
		private frmTweak_Project_s000 MyForm;
		protected override System.Windows.Forms.Form myform_ {
			get { return this.MyForm; }
		}
		private eMode mode_;
		#endregion
		#region public Properties...
		#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		public override void Show() {
			if (this.mode_ == eMode.Update) {
				#region MyForm. ... = frm_Main.ntierproject. ...;
				this.MyForm.ApplicationName 
					= frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].ApplicationName;
				this.MyForm.Namespace 
					= frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].ApplicationNamespace;
				this.MyForm.ApplicationPath 
					= System.IO.Path.GetDirectoryName(
						frm_Main.ntierproject.Filename
					);
				#endregion
				#region XS_dbType[] _dbmetadata_dbs = frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].DBs.DBCollection;
				OGen.NTier.Libraries.Metadata.MetadataExtended.XS_dbType[] _dbmetadata_dbs 
					= new OGen.NTier.Libraries.Metadata.MetadataExtended.XS_dbType[
						frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].DBs.DBCollection.Count
					];
				for (int d = 0; d < frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].DBs.DBCollection.Count; d++) {
					_dbmetadata_dbs[d] 
						= frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].DBs.DBCollection[d];
				}
				#endregion
				this.MyForm.Bind_DBConnections(
					_dbmetadata_dbs
					//, frm_Main.ntierproject.Metadata.Default_DBServerType, 
					//frm_Main.ntierproject.Metadata.Default_ConfigMode
				);
			} else {
				this.MyForm.ApplicationName = string.Empty;
				this.MyForm.Namespace = string.Empty;
				this.MyForm.ApplicationPath = string.Empty;
				this.MyForm.Bind_DBConnections();
			}

			base.Show();
		}
		//#endregion
	}
}
