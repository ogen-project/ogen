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
	public class cManage_ConfigTables_CreateOrChange_s010 : cFlowform {
		#region public cManage_ConfigTables_CreateOrChange_s010(...);
		public cManage_ConfigTables_CreateOrChange_s010(
			frm_Main Base_ref_, 
			dNotifyBase NotifyBase_, 
			PO_ConfigTables MyProcess_
		) : base (
			NotifyBase_, 
			1
		) {
			Base_ref = Base_ref_;

			MyForm = new frmManage_ConfigTables_CreateOrChange_s010(
				new cFlowformForm.dNotifyBase(
					MyForm_notifiedMe
				),
				new cFlowformForm.dNotifyBase(
					MyForm_notifiedMe_aboutNext
				)
			);
			MyForm.MdiParent = Base_ref;
			//MyForm.MaximizeBox = false;
			//MyForm_ref = MyForm;

			MyProcess = MyProcess_;
		}
		#endregion

		private void MyForm_notifiedMe_aboutNext(eFlowformFormEvents SomeEvent_) {
			switch (SomeEvent_) {
				case eFlowformFormEvents.Next:



					if (MyForm.TableName == "") {
						System.Windows.Forms.MessageBox.Show(
							"must choose one table",
							"Warning",
							System.Windows.Forms.MessageBoxButtons.OK,
							System.Windows.Forms.MessageBoxIcon.Warning
						);
					} else {
						MyProcess.TableName = MyForm.TableName;
						switch (MyProcess.Choice) {
							case eInsUpdDel.Delete:
								MyProcess.ConfigTables();
								NotifyBase(eFlowformEvents.Closed, this);
								break;
							case eInsUpdDel.Insert:
							case eInsUpdDel.Update:
								#region ((cManage_ConfigTables_CreateOrChange_s020)MyFlowforms[0]).Show();
								if (MyFlowforms[0] == null) {
									MyFlowforms[0] = new cManage_ConfigTables_CreateOrChange_s020(
										Base_ref, 
										new cFlowform.dNotifyBase(MyFlowforms_notifiedMe), 
										MyProcess
									);
								}
								MyForm.Hide();
								MyFlowforms[0].Show();
								#endregion
								break;
						}
					}



					break;
			}
		}

		#region private Properties...
		private frm_Main Base_ref;
		private PO_ConfigTables MyProcess;
		private frmManage_ConfigTables_CreateOrChange_s010 MyForm;
		protected override System.Windows.Forms.Form myform_ {
			get { return MyForm; }
		}
		#endregion
		#region public Properties...
		#endregion

		//#region private Methods...
		public override void Show() {
			MyForm.Bind(MyProcess.Choice);

			base.Show();
		}
		//#endregion
		#region public Methods...
		#endregion
	}
}