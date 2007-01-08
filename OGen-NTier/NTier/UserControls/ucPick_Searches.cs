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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace OGen.NTier.presentationlayer.winforms {
	public class ucPick_Searches : System.Windows.Forms.UserControl {
		#region Required designer variable...
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListView lvwSearches;
		private System.Windows.Forms.ColumnHeader columnHeader1;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.lvwSearches = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwSearches
			// 
			this.lvwSearches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwSearches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader1});
			this.lvwSearches.FullRowSelect = true;
			this.lvwSearches.HideSelection = false;
			this.lvwSearches.Location = new System.Drawing.Point(0, 0);
			this.lvwSearches.Name = "lvwSearches";
			this.lvwSearches.Size = new System.Drawing.Size(216, 184);
			this.lvwSearches.TabIndex = 0;
			this.lvwSearches.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Searches";
			this.columnHeader1.Width = 400;
			// 
			// ucPick_Searches
			// 
			this.Controls.Add(this.lvwSearches);
			this.Name = "ucPick_Searches";
			this.Size = new System.Drawing.Size(216, 168);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public ucPick_Searches() {
			#region This call is required by the Windows.Forms Form Designer...
			InitializeComponent();
			#endregion
		}

		#region public void Bind_Searches(...);
		public void Bind_Searches(int Table_, bool MultipleSelection_) {
			lvwSearches.Items.Clear();
			for (int s = 0; s < frm_Main.NTierProject.Metadata.Tables[Table_].Searches.Count; s++) {
				lvwSearches.Items.Add(
					frm_Main.NTierProject.Metadata.Tables[Table_].Searches[s].Name
				);
			}
			lvwSearches.MultiSelect = MultipleSelection_;
		}
		#endregion
		#region public string[] SelectedSearches();
		public string[] SelectedSearches() {
			string[] SelectedSearches_out = new string[lvwSearches.SelectedItems.Count];

			for (int t = 0; t < lvwSearches.SelectedItems.Count; t++) {
				SelectedSearches_out[t] = lvwSearches.SelectedItems[t].Text;
			}

			return SelectedSearches_out;
		}
		#endregion
	}
}