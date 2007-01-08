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

namespace OGen.NTier.presentationlayer.winforms.UserControls {
	public class ucPick_DBType : System.Windows.Forms.UserControl {
		#region Required designer variable...
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox cbxDBTypes;

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
			this.cbxDBTypes = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// cbxDBTypes
			// 
			this.cbxDBTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cbxDBTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxDBTypes.Location = new System.Drawing.Point(0, 0);
			this.cbxDBTypes.Name = "cbxDBTypes";
			this.cbxDBTypes.Size = new System.Drawing.Size(121, 21);
			this.cbxDBTypes.TabIndex = 0;
			// 
			// ucPick_DBType
			// 
			this.Controls.Add(this.cbxDBTypes);
			this.Name = "ucPick_DBType";
			this.Size = new System.Drawing.Size(120, 24);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public ucPick_DBType() {
			#region This call is required by the Windows.Forms Form Designer...
			InitializeComponent();
			#endregion

			string[] DBTypes = OGen.lib.datalayer.utils.DBServerTypes.Names_supportedForGeneration();
			cbxDBTypes.Items.Clear();
			for (int d = 0; d < DBTypes.Length; d++) {
				cbxDBTypes.Items.Add(DBTypes[d]);
			}
		}

		public OGen.lib.datalayer.eDBServerTypes DBServerType {
			get {
				return OGen.lib.datalayer.utils.DBServerTypes.convert.FromName(
					(string)cbxDBTypes.SelectedItem
				);
			}
			set {
				cbxDBTypes.SelectedItem = value.ToString();
			}
		}
	}
}