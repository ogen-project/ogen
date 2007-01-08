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
			if (frm_Main.ntierproject.Metadata.Tables.hasVirtualTable_withUndefinedKeys()) {
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