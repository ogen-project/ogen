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
	public class cManage_Views_PK_s020 : cFlowform {
		#region public cManage_Views_PK_s020(...);
		public cManage_Views_PK_s020(
			frm_Main Base_ref_, 
			dNotifyBase NotifyBase_, 
			PO_Manage_Views_PK MyProcess_
		) : base (
			NotifyBase_, 
			1
		) {
			Base_ref = Base_ref_;

			MyForm = new frmManage_Views_PK_s020(
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
					// ToDos: here!



					MyProcess.ViewPKs = MyForm.ViewPKs;
					MyProcess.Manage_Views_PK();
					NotifyBase(eFlowformEvents.Closed, this);



					break;
			}
		}

		#region private Properties...
		private frm_Main Base_ref;
		private PO_Manage_Views_PK MyProcess;
		private frmManage_Views_PK_s020 MyForm;
		protected override System.Windows.Forms.Form myform_ {
			get { return MyForm; }
		}
		#endregion
		#region public Properties...
		#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		public override void Show() {
			MyForm.Bind(
				frm_Main.ntierproject.Metadata.Tables.Search(
					MyProcess.ViewName
				)
			);
			base.Show();
		}
		//#endregion
	}
}