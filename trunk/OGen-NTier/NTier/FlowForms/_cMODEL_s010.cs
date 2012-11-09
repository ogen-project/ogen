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

	public class cMODEL_s010 : Flowform {
		#region public cMODEL_s010(...);
		public cMODEL_s010(
			frm_Main Base_ref_, 
			dNotifyBase NotifyBase_, 
			PO_MODEL MyProcess_
		) : base (
			NotifyBase_, 
			1
		) {
			Base_ref = Base_ref_;

			MyForm = new frmMODEL(
				new FlowformForm.dNotifyBase(
					MyForm_notifiedMe
				),
				new FlowformForm.dNotifyBase(
					MyForm_notifiedMe_aboutNext
				)
			);
			MyForm.MdiParent = Base_ref;
			//MyForm.MaximizeBox = false;
			//MyForm_ref = MyForm;

			MyProcess = MyProcess_;
		}

		protected override void Dispose(bool disposing_in) {
			MyForm.Dispose();

			base.Dispose(disposing_in);
		}
		#endregion

		private void MyForm_notifiedMe_aboutNext(FlowformFormEvents SomeEvent_) {
			switch (SomeEvent_) {
				case FlowformFormEvents.Next:
					// ToDos: here!



					#region ((cMODEL_s020)MyFlowforms[0]).Show();
					if (MyFlowforms[0] == null) {
						//MyFlowforms[0] = new cMODEL_s020(
						//	Base_ref, 
						//	new Flowform.dNotifyBase(MyFlowforms_notifiedMe), 
						//	MyProcess
						//);
					}
					MyForm.Hide();
					MyFlowforms[0].Show();
					#endregion
					// IF LAST FORM:
					//NotifyBase(FlowformEvents.Closed, this);



					break;
			}
		}

		#region private Properties...
		private frm_Main Base_ref;
		private PO_MODEL MyProcess;
		private frmMODEL MyForm;
		protected override System.Windows.Forms.Form myform_ {
			get { return MyForm; }
		}
		#endregion
		#region public Properties...
		#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		//public override void Show() {
		//	// do whatever...
		//	base.Show();
		//}
		//#endregion
	}
}