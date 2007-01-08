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
using OGen.lib.presentationlayer.winforms.Flowforms;

namespace OGen.NTier.presentationlayer.winforms {
	public class cTweak_Project_s000 : cFlowform {
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
			Base_ref = base_ref_in;
			mode_ = mode_in;

			MyForm = new frmTweak_Project_s000(
				new cFlowformForm.dNotifyBase(
					MyForm_notifiedMe
				),
				new cFlowformForm.dNotifyBase(
					MyForm_notifiedMe_aboutNext
				), 
				mode_in
			);
			MyForm.MdiParent = Base_ref;
			//MyForm.MaximizeBox = false;

//			MyProcess = new PO_Tweak_Project(Base_ref);
		}
		~cTweak_Project_s000() {
			cleanUp();
		}
		public override void Dispose() {
			System.GC.SuppressFinalize(this);
			cleanUp();

			base.Dispose();
		}
		public void cleanUp() {
//			MyProcess.Dispose();
		}
		#endregion

		#region enums...
		public enum eMode {
			New = 0, 
			Update = 1
		}
		#endregion

		private void MyForm_notifiedMe_aboutNext(eFlowformFormEvents SomeEvent_) {
			switch (SomeEvent_) {
				case eFlowformFormEvents.Next:
					#region Checking...
					if (
						(mode_ == eMode.New) 
						&& 
						(MyForm.ApplicationPath.Trim() == string.Empty)
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
						(mode_ == eMode.New) 
						&& 
						(
							(System.IO.Directory.GetDirectories(MyForm.ApplicationPath).Length != 0)
							||
							(System.IO.Directory.GetFiles(MyForm.ApplicationPath).Length != 0)
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
					if (MyForm.ApplicationName.Trim() == string.Empty) {
						System.Windows.Forms.MessageBox.Show(
							"must provide a valid Application Name",
							"Warning",
							System.Windows.Forms.MessageBoxButtons.OK,
							System.Windows.Forms.MessageBoxIcon.Warning
						);
						return;
					}
					if (MyForm.Namespace.Trim() == string.Empty) {
						System.Windows.Forms.MessageBox.Show(
							"must provide a valid Application Namespace",
							"Warning",
							System.Windows.Forms.MessageBoxButtons.OK,
							System.Windows.Forms.MessageBoxIcon.Warning
						);
						return;
					}
					#endregion
					OGen.NTier.lib.metadata.cDBMetadata_DB[] _dbs 
						= MyForm.UnBind_DBConnections();
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
					if (mode_ == eMode.Update) {
						#region Updating...
						frm_Main.ntierproject.Metadata.DBs.Clear();
						for (int d = 0; d < _dbs.Length; d++) {
							int _justadded = frm_Main.ntierproject.Metadata.DBs.Add(
								_dbs[d].DBServerType, 
								false
							);
							frm_Main.ntierproject.Metadata.DBs[_justadded].CopyFrom(
								_dbs[d]
							);
							//if (d == 0) {
							//    // ToDos: here! document this behaviour and describe it throught unit testing
							//    // first item in the array, represents default db connection
							//    frm_Main.ntierproject.Metadata.Default_DBServerType = frm_Main.ntierproject.Metadata.DBs[_justadded].DBServerType;
							//    frm_Main.ntierproject.Metadata.Default_ConfigMode = frm_Main.ntierproject.Metadata.DBs[_justadded].Connections[0].ConfigMode;
							//}
						}

						frm_Main.ntierproject.Metadata.ApplicationName 
							= MyForm.ApplicationName;
						frm_Main.ntierproject.Metadata.Namespace 
							= MyForm.Namespace;
						#endregion
						frm_Main.NTierProject.hasChanges = true;
					} else {
						#region Creating...
						MyForm.Hide();

						frmProcessOutput output = new frmProcessOutput("Output");
						output.MdiParent = Base_ref;
						output.Show();

						frm_Main.ntierproject.New(
							MyForm.ApplicationPath, 
							MyForm.ApplicationName, 
							MyForm.Namespace, 
							_dbs, 
							new OGen.NTier.lib.metadata.cDBMetadata.dLoadState_fromDB(
								output.DisplayMessage
							)
						);

						output.DisplayMessage();
						#endregion
					}
					Base_ref.Form_Refresh();

					MyForm.Hide();
					NotifyBase(eFlowformEvents.Closed, this);
					break;
			}
		}

		#region private Properties...
		private frm_Main Base_ref;
//		private PO_Tweak_Project MyProcess;
		private frmTweak_Project_s000 MyForm;
		protected override System.Windows.Forms.Form myform_ {
			get { return MyForm; }
		}
		private eMode mode_;
		#endregion
		#region public Properties...
		#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		public override void Show() {
			if (mode_ == eMode.Update) {
				#region MyForm. ... = frm_Main.ntierproject. ...;
				MyForm.ApplicationName 
					= frm_Main.ntierproject.Metadata.ApplicationName;
				MyForm.Namespace 
					= frm_Main.ntierproject.Metadata.Namespace;
				MyForm.ApplicationPath 
					= System.IO.Path.GetDirectoryName(
						frm_Main.ntierproject.Filename
					);
				#endregion
				#region cDBMetadata_DB[] _dbmetadata_dbs = frm_Main.ntierproject.Metadata.DBs;
				OGen.NTier.lib.metadata.cDBMetadata_DB[] _dbmetadata_dbs 
					= new OGen.NTier.lib.metadata.cDBMetadata_DB[
						frm_Main.ntierproject.Metadata.DBs.Count
					];
				for (int d = 0; d < frm_Main.ntierproject.Metadata.DBs.Count; d++) {
					_dbmetadata_dbs[d] = frm_Main.ntierproject.Metadata.DBs[d];
				}
				#endregion
				MyForm.Bind_DBConnections(
					_dbmetadata_dbs
					//, frm_Main.ntierproject.Metadata.Default_DBServerType, 
					//frm_Main.ntierproject.Metadata.Default_ConfigMode
				);
			} else {
				MyForm.ApplicationName = string.Empty;
				MyForm.Namespace  = string.Empty;
				MyForm.ApplicationPath  = string.Empty;
				MyForm.Bind_DBConnections();
			}

			base.Show();
		}
		//#endregion
	}
}