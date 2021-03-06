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

	public class cManage_ConfigTables : Flowform {
		#region public cManage_ConfigTables(...);
		public cManage_ConfigTables(
			frm_Main Base_ref_
		) : this (
			Base_ref_, 
			null
		) {}
		public cManage_ConfigTables(
			frm_Main Base_ref_, 
			OGen.Libraries.PresentationLayer.WinForms.FlowForms.FlowformNotifyBase NotifyBase_
		) : base (
			NotifyBase_, 
			1
		) {
			this.Base_ref = Base_ref_;

			this.MyForm = new frmManage_ConfigTables(
				this.MyForm_notifiedMe,
				this.MyForm_notifiedMe_aboutNext
			);
			this.MyForm.MdiParent = this.Base_ref;
			//this.MyForm.MaximizeBox = false;
			//this.MyForm_ref = MyForm;

			//this.MyProcess = MyProcess_;
			this.MyProcess = new PO_ConfigTables(this.Base_ref);
		}

		protected override void Dispose(bool disposing_in) {
			this.MyProcess.Dispose();

			base.Dispose(disposing_in);
		}
		#endregion

		private void MyForm_notifiedMe_aboutNext(FlowformFormEvents SomeEvent_) {
			switch (SomeEvent_) {
				case FlowformFormEvents.Next:
					// ToDos: here!



					this.MyProcess.Choice = this.MyForm.Choice;
					#region ((cManage_ConfigTables_CreateOrChange_s010)MyFlowforms[0]).Show();
					if (this.MyFlowforms[0] == null) {
						this.MyFlowforms[0] = new cManage_ConfigTables_CreateOrChange_s010(
							this.Base_ref,
							this.MyFlowforms_notifiedMe,
							this.MyProcess
						);
					}
					this.MyForm.Hide();
					this.MyFlowforms[0].Show();
					#endregion



					break;
			}
		}

		#region private Properties...
		private frm_Main Base_ref;
		private PO_ConfigTables MyProcess;
		private frmManage_ConfigTables MyForm;
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
			this.MyForm.hasConfigTable
				= frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.hasConfigTable;

			base.Show();
		}
		//#endregion
	}
}
