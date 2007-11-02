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
using OGen.lib.presentationlayer.winforms.Flowforms;

namespace OGen.NTier.presentationlayer.winforms {
	public class cManage_ConfigTables : cFlowform {
		#region public cManage_ConfigTables(...);
		public cManage_ConfigTables(
			frm_Main Base_ref_
		) : this (
			Base_ref_, 
			null
		) {}
		public cManage_ConfigTables(
			frm_Main Base_ref_, 
			dNotifyBase NotifyBase_
		) : base (
			NotifyBase_, 
			1
		) {
			Base_ref = Base_ref_;

			MyForm = new frmManage_ConfigTables(
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

			//MyProcess = MyProcess_;
			MyProcess = new PO_ConfigTables(Base_ref);
		}
		~cManage_ConfigTables() {
			cleanUp();
		}
		public override void Dispose() {
			System.GC.SuppressFinalize(this);
			cleanUp();

			base.Dispose();
		}
		public void cleanUp() {
			MyProcess.Dispose();
		}
		#endregion

		private void MyForm_notifiedMe_aboutNext(eFlowformFormEvents SomeEvent_) {
			switch (SomeEvent_) {
				case eFlowformFormEvents.Next:
					// ToDos: here!



					MyProcess.Choice = MyForm.Choice;
					#region ((cManage_ConfigTables_CreateOrChange_s010)MyFlowforms[0]).Show();
					if (MyFlowforms[0] == null) {
						MyFlowforms[0] = new cManage_ConfigTables_CreateOrChange_s010(
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

		#region private Properties...
		private frm_Main Base_ref;
		private PO_ConfigTables MyProcess;
		private frmManage_ConfigTables MyForm;
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
			MyForm.hasConfigTable
				= frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.hasConfigTable();

			base.Show();
		}
		//#endregion
	}
}
