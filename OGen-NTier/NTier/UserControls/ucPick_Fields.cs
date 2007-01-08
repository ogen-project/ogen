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
	public class ucPick_Fields : System.Windows.Forms.UserControl {
		#region Required designer variable...
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListView lvwFields;
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
			this.lvwFields = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwFields
			// 
			this.lvwFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
			this.lvwFields.FullRowSelect = true;
			this.lvwFields.HideSelection = false;
			this.lvwFields.Location = new System.Drawing.Point(0, 0);
			this.lvwFields.Name = "lvwFields";
			this.lvwFields.Size = new System.Drawing.Size(320, 200);
			this.lvwFields.TabIndex = 0;
			this.lvwFields.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Fields";
			this.columnHeader1.Width = 400;
			// 
			// ucPick_Fields
			// 
			this.Controls.Add(this.lvwFields);
			this.Name = "ucPick_Fields";
			this.Size = new System.Drawing.Size(320, 184);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public ucPick_Fields() {
			#region This call is required by the Windows.Forms Form Designer...
			InitializeComponent();
			#endregion
		}

		#region public enum eType;
		public enum eType {
			OnlyIdentityKey = 0, 
			OnlyPrimaryKeys = 1, 
			NoKeys = 2, 
			All = 3,
			None = 4
		}
		#endregion
		#region public void Bind_Fields(...);
		public void Bind_Fields(eType FieldType_, bool MultipleSelection_, int SpecificTable_, eType SelectionType_) {
			bool _canAdd;
			lvwFields.Items.Clear();
			
			for ( // tweaked for-cycle!
				int t = (SpecificTable_ >= 0) ? SpecificTable_ : 0; 
				t < frm_Main.NTierProject.Metadata.Tables.Count; 
				t++
			) {
				for (int f = 0; f < frm_Main.NTierProject.Metadata.Tables[t].Fields.Count; f++) {
					_canAdd = false;

					switch (FieldType_) {
						case eType.OnlyIdentityKey:
							_canAdd = frm_Main.NTierProject.Metadata.Tables[t].Fields[f].isIdentity;
							break;
						case eType.OnlyPrimaryKeys:
							_canAdd = frm_Main.NTierProject.Metadata.Tables[t].Fields[f].isPK;
							break;
						case eType.NoKeys:
							_canAdd = !frm_Main.NTierProject.Metadata.Tables[t].Fields[f].isPK;
							break;
						case eType.All:
							_canAdd = true;
							break;
						case eType.None:
							_canAdd = false;
							break;
					}
					if (_canAdd) {
						lvwFields.Items.Add(
							//new ListViewItem(
								string.Format( 
									"{0}{1}", 
									(SpecificTable_ >= 0) ? "" : frm_Main.NTierProject.Metadata.Tables[t].Name + "\\", 
									frm_Main.NTierProject.Metadata.Tables[t].Fields[f].Name
								)
							//)
						);

						switch (SelectionType_) {
							case eType.OnlyIdentityKey:
								lvwFields.Items[lvwFields.Items.Count - 1].Selected = 
									frm_Main.NTierProject.Metadata.Tables[t].Fields[f].isIdentity;
								break;
							case eType.OnlyPrimaryKeys:
								lvwFields.Items[lvwFields.Items.Count - 1].Selected = 
									frm_Main.NTierProject.Metadata.Tables[t].Fields[f].isPK;
								break;
							case eType.NoKeys:
								lvwFields.Items[lvwFields.Items.Count - 1].Selected = 
									!frm_Main.NTierProject.Metadata.Tables[t].Fields[f].isPK;
								break;
							case eType.All:
								lvwFields.Items[lvwFields.Items.Count - 1].Selected = true;
								break;
							case eType.None:
								lvwFields.Items[lvwFields.Items.Count - 1].Selected = false;
								break;
						}
					}
				}

				// tweaked for-cycle!
				if (SpecificTable_ >= 0) break;
			}
			lvwFields.MultiSelect = MultipleSelection_;
		}
		#endregion
		#region public string[] SelectedFields(...);
		public string[] SelectedFields() {
			string[] SelectedFields_out = new string[lvwFields.SelectedItems.Count];

			for (int t = 0; t < lvwFields.SelectedItems.Count; t++) {
				SelectedFields_out[t] = lvwFields.SelectedItems[t].Text;
			}

			return SelectedFields_out;
		}
		#endregion
		#region //public void SelectThisFields(...);
		public void SelectThisFields(params int[] ThisFields_) {
			for (int f = 0; f < lvwFields.Items.Count; f++) {
				lvwFields.Items[f].Selected = false;
				for (int s = 0; s < ThisFields_.Length; s++) {
					if (ThisFields_[s] == f) {
						lvwFields.Items[f].Selected = true;
						break;
					}
				}
			}
		}
		#endregion
	}
}