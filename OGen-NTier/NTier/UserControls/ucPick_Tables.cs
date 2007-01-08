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
	public class ucPick_Tables : System.Windows.Forms.UserControl {
		#region Required designer variable
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView lvwTables;

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
			this.lvwTables = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwTables
			// 
			this.lvwTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
			this.lvwTables.FullRowSelect = true;
			this.lvwTables.HideSelection = false;
			this.lvwTables.Location = new System.Drawing.Point(0, 0);
			this.lvwTables.Name = "lvwTables";
			this.lvwTables.Size = new System.Drawing.Size(200, 160);
			this.lvwTables.TabIndex = 0;
			this.lvwTables.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Tables";
			this.columnHeader1.Width = 400;
			// 
			// ucPick_Tables
			// 
			this.Controls.Add(this.lvwTables);
			this.Name = "ucPick_Tables";
			this.Size = new System.Drawing.Size(200, 144);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public ucPick_Tables() {
			#region This call is required by the Windows.Forms Form Designer...
			InitializeComponent();
			#endregion
		}

		#region public enum eTypeSelection;
		public enum eTypeSelection {
			OnlyTables = 0, 
			OnlyViews = 1, 
			All = 2, 
			OnlyViews_withNoKeys = 3, 
			OnlyConfigTables = 4, 
			NoConfigTables = 5
		}
		#endregion
		#region public void Bind_Tables(...);
		public void Bind_Tables(eTypeSelection TypeSelection_, bool MultipleSelection_) {
			bool _canAdd;
			lvwTables.Items.Clear();
			for (int t = 0; t < frm_Main.NTierProject.Metadata.Tables.Count; t++) {
				_canAdd = false;

				switch (TypeSelection_) {
					case eTypeSelection.OnlyTables:
						_canAdd = !frm_Main.NTierProject.Metadata.Tables[t].isVirtualTable;
						break;
					case eTypeSelection.OnlyViews:
						_canAdd = frm_Main.NTierProject.Metadata.Tables[t].isVirtualTable;
						break;
					case eTypeSelection.OnlyViews_withNoKeys:
						_canAdd = (
							frm_Main.NTierProject.Metadata.Tables[t].isVirtualTable
							&&
							(frm_Main.NTierProject.Metadata.Tables[t].Fields_onlyPK.Count == 0)
						);
						break;
					case eTypeSelection.OnlyConfigTables:
						_canAdd = frm_Main.NTierProject.Metadata.Tables[t].isConfig;
						break;
					case eTypeSelection.NoConfigTables:
						_canAdd = frm_Main.NTierProject.Metadata.Tables[t].canBeConfig();
						break;
					case eTypeSelection.All:
						_canAdd = true;
						break;
				}
				if (_canAdd) {
					lvwTables.Items.Add(
						//new ListViewItem(
							frm_Main.NTierProject.Metadata.Tables[t].Name
						//)
					);
				}
			}
			lvwTables.MultiSelect = MultipleSelection_;
		}
		#endregion
		#region public string[] SelectedTables();
		public string[] SelectedTables() {
			string[] SelectedTables_out = new string[lvwTables.SelectedItems.Count];

			for (int t = 0; t < lvwTables.SelectedItems.Count; t++) {
				SelectedTables_out[t] = lvwTables.SelectedItems[t].Text;
			}

			return SelectedTables_out;
		}
		#endregion
	}
}