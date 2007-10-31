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

namespace OGen.NTier.presentationlayer.winforms {
	public class PO_Manage_Views_PK {
		#region public PO_Manage_Views_PK(...);
		public PO_Manage_Views_PK(frm_Main MainForm_) {
			MainForm = MainForm_;
		}
		~PO_Manage_Views_PK() {
			cleanUp();
		}
		public void Dispose() {
			System.GC.SuppressFinalize(this);
			cleanUp();
		}
		public void cleanUp() {
			// ...
		}
		#endregion
		private frm_Main MainForm;

		#region public bool Undefined_orAll { get; set; }
		private bool undefined_orall;
		public bool Undefined_orAll {
			get { return undefined_orall; }
			set { undefined_orall = value; }
		}
		#endregion
		#region public string ViewName { get; set; }
		private string viewname;
		public string ViewName {
			get { return viewname; }
			set { viewname = value; }
		}
		#endregion
		#region public string[] ViewPKs { get; set; }
		private string[] viewpks;
		public string[] ViewPKs {
			get { return viewpks; }
			set { viewpks = value; }
		}
		#endregion

		public void Manage_Views_PK() {
			int t = frm_Main.NTierProject.Metadata.Tables.Search(ViewName);

			// Clean Keys:
			for (int f = 0; f < frm_Main.NTierProject.Metadata.Tables[t].Fields.Count; f++) {
				frm_Main.NTierProject.Metadata.Tables[t].Fields[f].isIdentity = false;
				frm_Main.NTierProject.Metadata.Tables[t].Fields[f].isPK = false;
			}

			// Reset Keys:
			for (int k = 0; k < ViewPKs.Length; k++) {
				frm_Main.NTierProject.Metadata.Tables[t].Fields[
					frm_Main.NTierProject.Metadata.Tables[t].Fields.Search(
						ViewPKs[k]
					)
				].isPK = true;
			}

			frm_Main.NTierProject.hasChanges = true;
			MainForm.Form_Refresh();
		}
	}
}