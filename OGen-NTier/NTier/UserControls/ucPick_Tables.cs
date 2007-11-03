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
			for (int t = 0; t < frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection.Count; t++) {
				_canAdd = false;

				switch (TypeSelection_) {
					case eTypeSelection.OnlyTables:
						_canAdd = !frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection[
							t
						].isVirtualTable;
						break;
					case eTypeSelection.OnlyViews:
						_canAdd = frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection[
							t
						].isVirtualTable;
						break;
					case eTypeSelection.OnlyViews_withNoKeys:
						_canAdd = (
							frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection[
								t
							].isVirtualTable
							&&
							(frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection[
								t
							].TableFields_onlyPK.TableFieldCollection.Count == 0)
						);
						break;
					case eTypeSelection.OnlyConfigTables:
						_canAdd = frm_Main.NTierProject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[
							frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection[
								t
							].Name
						].isConfig;
						break;
					case eTypeSelection.NoConfigTables:
						_canAdd = frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection[
							t
						].canBeConfig;
						break;
					case eTypeSelection.All:
						_canAdd = true;
						break;
				}
				if (_canAdd) {
					lvwTables.Items.Add(
						//new ListViewItem(
							frm_Main.NTierProject.Metadata.MetadataDBCollection[0].Tables.TableCollection[
								t
							].Name
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
