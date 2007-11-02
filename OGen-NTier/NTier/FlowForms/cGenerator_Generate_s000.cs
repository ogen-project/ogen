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
	public class cGenerator_Generate_s000 : cFlowform {
		#region public cGenerator_Generate_s000(...);
		public cGenerator_Generate_s000(
			frm_Main Base_ref_
		) : this (
			Base_ref_, 
			null
		) {}
		public cGenerator_Generate_s000(
			frm_Main Base_ref_, 
			dNotifyBase NotifyBase_
		) : base (
			NotifyBase_, 
			0
		) {
			Base_ref = Base_ref_;

			MyForm = new frmGenerator_Generate_s000(
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
		}
		#endregion

		private void MyForm_notifiedMe_aboutNext(eFlowformFormEvents SomeEvent_) {
			switch (SomeEvent_) {
				case eFlowformFormEvents.Next:
					MyForm.Hide();
					//---
					frmProcessOutput output = new frmProcessOutput("Output");
					output.MdiParent = Base_ref;
					output.Show();
					//---
					MyForm.Refresh(); MyForm.Hide();
					output.Refresh();
					Base_ref.Refresh();
					//---
					//output.DisplayMessage("generating...", true);
					frm_Main.NTierProject.Metadata.SQLScriptOption = MyForm.SQLscriptOptions;
					frm_Main.NTierProject.Metadata.PseudoReflectionable = MyForm.pReflection;
					frm_Main.NTierProject.Build(
						new OGen.lib.generator.cGenerator.dBuild(
							output.DisplayMessage
						)
					);
					//output.DisplayMessage("... finished!", true);
					output.DisplayMessage();
					//---
					NotifyBase(eFlowformEvents.Closed, this);
					break;
			}
		}

		//#region private Properties...
		private frm_Main Base_ref;
		private frmGenerator_Generate_s000 MyForm;
		private cManage_Views_PK_s010 Manage_Views_PK_s010;
		protected override System.Windows.Forms.Form myform_ {
			get { return MyForm; }
		}
		//#endregion
		#region public Properties...
		#endregion

		//#region private Methods...
		public void LetMeKnowWhen_NoMoreUndefinedViews(eFlowformEvents SomeEvent_, cFlowform Flowform_) {
			Manage_Views_PK_s010.Hide();
			Manage_Views_PK_s010.Dispose(); Manage_Views_PK_s010 = null;

			this.Show();
		}
		//#endregion
		//#region public Methods...
		public override void Show() {
			MyForm.pReflection = frm_Main.ntierproject.Metadata.PseudoReflectionable;
			if (frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.hasVirtualTable_withUndefinedKeys()) {
				switch (System.Windows.Forms.MessageBox.Show(
					"View's PK must be defined, prior to Generate", 
					"Warning", 
					System.Windows.Forms.MessageBoxButtons.OKCancel, 
					System.Windows.Forms.MessageBoxIcon.Warning
				)) {
					case System.Windows.Forms.DialogResult.OK:
						PO_Manage_Views_PK manage_views_pk = new PO_Manage_Views_PK(Base_ref);
						manage_views_pk.Undefined_orAll = true;

						Manage_Views_PK_s010 = new cManage_Views_PK_s010(
							Base_ref, 
							new cFlowform.dNotifyBase(LetMeKnowWhen_NoMoreUndefinedViews), 
							manage_views_pk
						);
						Manage_Views_PK_s010.Show();

						break;
					case System.Windows.Forms.DialogResult.Cancel:
						NotifyBase(eFlowformEvents.Closed, this);
						break;
				}
			} else {
				base.Show();
				switch (Base_ref.ProjectSave(true, true, false)) {
					case System.Windows.Forms.DialogResult.OK:
						break;
					case System.Windows.Forms.DialogResult.Cancel:
						NotifyBase(eFlowformEvents.Closed, this);
						break;
				}
			}
		}
		//#endregion
	}
}
