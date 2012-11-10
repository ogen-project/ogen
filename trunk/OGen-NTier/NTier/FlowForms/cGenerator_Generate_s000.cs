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

	public class cGenerator_Generate_s000 : Flowform {
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
			this.Base_ref = Base_ref_;

			this.MyForm = new frmGenerator_Generate_s000(
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
		}

		protected override void Dispose(bool disposing_in) {
			this.MyForm.Dispose();
			if (this.Manage_Views_PK_s010 != null) {
				this.Manage_Views_PK_s010.Dispose();
				this.Manage_Views_PK_s010 = null;
			}

			base.Dispose(disposing_in);
		}
		#endregion

		private void MyForm_notifiedMe_aboutNext(FlowformFormEvents SomeEvent_) {
			switch (SomeEvent_) {
				case FlowformFormEvents.Next:
					this.MyForm.Hide();
					//---
					frmProcessOutput output = new frmProcessOutput("Output");
					output.MdiParent = this.Base_ref;
					output.Show();
					//---
					this.MyForm.Refresh(); this.MyForm.Hide();
					output.Refresh();
					this.Base_ref.Refresh();
					//---
					//output.DisplayMessage("generating...", true);
					frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].SQLScriptOption = this.MyForm.SQLscriptOptions;
//					frm_Main.NTierProject.Metadata.PseudoReflectionable = this.MyForm.pReflection;
					frm_Main.NTierProject.Build(
						new OGen.Libraries.Generator.OGenGenerator.dBuild(
							output.DisplayMessage
						)
					);
					//output.DisplayMessage("... finished!", true);
					output.DisplayMessage();
					//---
					this.NotifyBase(FlowformEvents.Closed, this);
					break;
			}
		}

		//#region private Properties...
		private frm_Main Base_ref;
		private frmGenerator_Generate_s000 MyForm;
		private cManage_Views_PK_s010 Manage_Views_PK_s010;
		protected override System.Windows.Forms.Form myform_ {
			get { return this.MyForm; }
		}
		//#endregion
		#region public Properties...
		#endregion

		//#region private Methods...
		public void LetMeKnowWhen_NoMoreUndefinedViews(FlowformEvents SomeEvent_, Flowform Flowform_) {
			this.Manage_Views_PK_s010.Hide();
			this.Manage_Views_PK_s010.Dispose();
			this.Manage_Views_PK_s010 = null;

			this.Show();
		}
		//#endregion
		//#region public Methods...
		public override void Show() {
//			MyForm.pReflection = frm_Main.ntierproject.Metadata.PseudoReflectionable;
			if (frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.hasVirtualTable_withUndefinedKeys) {
				switch (System.Windows.Forms.MessageBox.Show(
					"View's PK must be defined, prior to Generate", 
					"Warning", 
					System.Windows.Forms.MessageBoxButtons.OKCancel, 
					System.Windows.Forms.MessageBoxIcon.Warning
				)) {
					case System.Windows.Forms.DialogResult.OK:
						PO_Manage_Views_PK manage_views_pk = new PO_Manage_Views_PK(this.Base_ref);
						manage_views_pk.Undefined_orAll = true;

						this.Manage_Views_PK_s010 = new cManage_Views_PK_s010(
							this.Base_ref,
							new Flowform.dNotifyBase(this.LetMeKnowWhen_NoMoreUndefinedViews), 
							manage_views_pk
						);
						this.Manage_Views_PK_s010.Show();

						break;
					case System.Windows.Forms.DialogResult.Cancel:
						this.NotifyBase(FlowformEvents.Closed, this);
						break;
				}
			} else {
				base.Show();
				switch (this.Base_ref.ProjectSave(true, true, false)) {
					case System.Windows.Forms.DialogResult.OK:
						break;
					case System.Windows.Forms.DialogResult.Cancel:
						this.NotifyBase(FlowformEvents.Closed, this);
						break;
				}
			}
		}
		//#endregion
	}
}
