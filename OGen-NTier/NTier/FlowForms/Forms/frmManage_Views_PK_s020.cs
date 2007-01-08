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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using OGen.lib.presentationlayer.winforms.Flowforms;

namespace OGen.NTier.presentationlayer.winforms {
	public class frmManage_Views_PK_s020 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Label label1;
		private OGen.NTier.presentationlayer.winforms.ucPick_Fields Pick_Fields;
		private System.Windows.Forms.Button btnNext;

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.Pick_Fields = new OGen.NTier.presentationlayer.winforms.ucPick_Fields();
			this.SuspendLayout();
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBack.Location = new System.Drawing.Point(16, 248);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(72, 23);
			this.btnBack.TabIndex = 5;
			this.btnBack.Text = "<< &Back";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(208, 248);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "&Define!";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Choose PKs:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// Pick_Fields
			// 
			this.Pick_Fields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Pick_Fields.Location = new System.Drawing.Point(8, 24);
			this.Pick_Fields.Name = "Pick_Fields";
			this.Pick_Fields.Size = new System.Drawing.Size(280, 216);
			this.Pick_Fields.TabIndex = 8;
			// 
			// frmManage_Views_PK_s020
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 277);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Pick_Fields);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnNext);
			this.MinimumSize = new System.Drawing.Size(192, 144);
			this.Name = "frmManage_Views_PK_s020";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage Views PK";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_Views_PK_s020(
			cFlowformForm.dNotifyBase NotifyBase_, 
			cFlowformForm.dNotifyBase NotifyBase_aboutNext_
		) {
			#region Required for Windows Form Designer support...
			InitializeComponent();
			#endregion
			FlowformForm = new cFlowformForm(
				NotifyBase_, 
				NotifyBase_aboutNext_
			);
			#region Event safeguard...
			this.btnBack.Click += new System.EventHandler(FlowformForm.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(FlowformForm.btnNext_Click);
			this.Closed += new System.EventHandler(FlowformForm.FlowformForm_Closed);
			#endregion
		}

		#region private Properties...
		private cFlowformForm FlowformForm;
		#endregion
		//#region public Properties...
		#region public string[] ViewPKs { get; }
		public string[] ViewPKs {
			get { return Pick_Fields.SelectedFields(); }
		}
		#endregion
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public void Bind(...);
		public void Bind(int SpecificTable_) {
			this.Pick_Fields.Bind_Fields(
				ucPick_Fields.eType.All, 
				true, 
				SpecificTable_, 
				ucPick_Fields.eType.OnlyIdentityKey
			);
		}
		#endregion
		//#endregion

		#region Events...
		#endregion
	}
}