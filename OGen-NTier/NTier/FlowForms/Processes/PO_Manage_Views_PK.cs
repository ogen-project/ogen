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