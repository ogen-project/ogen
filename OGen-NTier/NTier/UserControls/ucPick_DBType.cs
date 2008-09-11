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

using OGen.lib.datalayer;

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

			string[] DBTypes = Enum.GetNames(typeof(DBServerTypes));
			cbxDBTypes.Items.Clear();
			for (int d = 0; d < 
				// skipping invalid, hence -1
				DBTypes.Length - 1; 
			d++) {
				cbxDBTypes.Items.Add(DBTypes[d]);
			}
		}

		public DBServerTypes DBServerType {
			get {
				return (DBServerTypes)Enum.Parse(
					typeof(DBServerTypes),
					(string)cbxDBTypes.SelectedItem
				);
			}
			set {
				cbxDBTypes.SelectedItem = value.ToString();
			}
		}
	}
}
