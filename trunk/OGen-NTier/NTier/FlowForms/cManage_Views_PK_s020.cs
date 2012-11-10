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

	public class cManage_Views_PK_s020 : Flowform {
		#region public cManage_Views_PK_s020(...);
		public cManage_Views_PK_s020(
			frm_Main Base_ref_, 
			dNotifyBase NotifyBase_, 
			PO_Manage_Views_PK MyProcess_
		) : base (
			NotifyBase_, 
			1
		) {
			this.Base_ref = Base_ref_;

			this.MyForm = new frmManage_Views_PK_s020(
				new FlowformForm.dNotifyBase(
					this.MyForm_notifiedMe
				),
				new FlowformForm.dNotifyBase(
					this.MyForm_notifiedMe_aboutNext
				)
			);
			this.MyForm.MdiParent = this.Base_ref;
			//this.MyForm.MaximizeBox = false;
			//this.MyForm_ref = MyForm;

			this.MyProcess = MyProcess_;
		}

		protected override void Dispose(bool disposing_in) {
			this.MyForm.Dispose();

			base.Dispose(disposing_in);
		}
		#endregion

		private void MyForm_notifiedMe_aboutNext(FlowformFormEvents SomeEvent_) {
			switch (SomeEvent_) {
				case FlowformFormEvents.Next:
					// ToDos: here!



					this.MyProcess.ViewPKs = this.MyForm.ViewPKs;
					this.MyProcess.Manage_Views_PK();
					this.NotifyBase(FlowformEvents.Closed, this);



					break;
			}
		}

		#region private Properties...
		private frm_Main Base_ref;
		private PO_Manage_Views_PK MyProcess;
		private frmManage_Views_PK_s020 MyForm;
		protected override System.Windows.Forms.Form myform_ {
			get { return this.MyForm; }
		}
		#endregion
		#region public Properties...
		#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		public override void Show() {
			this.MyForm.Bind(
				frm_Main.ntierproject.Metadata.MetadataDBCollection[0].Tables.TableCollection.Search(
					this.MyProcess.ViewName
				)
			);
			base.Show();
		}
		//#endregion
	}
}
