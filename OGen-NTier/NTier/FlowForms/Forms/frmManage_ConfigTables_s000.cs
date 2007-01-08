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
	public class frmManage_ConfigTables : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbtDelete;
		private System.Windows.Forms.RadioButton rbtCreate;
		private System.Windows.Forms.RadioButton rbtChange;
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
			this.btnNext = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbtChange = new System.Windows.Forms.RadioButton();
			this.rbtDelete = new System.Windows.Forms.RadioButton();
			this.rbtCreate = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(216, 184);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "&Next >>";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.Controls.Add(this.rbtChange);
			this.groupBox1.Controls.Add(this.rbtDelete);
			this.groupBox1.Controls.Add(this.rbtCreate);
			this.groupBox1.Location = new System.Drawing.Point(64, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 96);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Config Tables: ";
			// 
			// rbtChange
			// 
			this.rbtChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtChange.Location = new System.Drawing.Point(16, 40);
			this.rbtChange.Name = "rbtChange";
			this.rbtChange.Size = new System.Drawing.Size(152, 24);
			this.rbtChange.TabIndex = 3;
			this.rbtChange.Text = "&Change";
			// 
			// rbtDelete
			// 
			this.rbtDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtDelete.Location = new System.Drawing.Point(16, 64);
			this.rbtDelete.Name = "rbtDelete";
			this.rbtDelete.Size = new System.Drawing.Size(152, 24);
			this.rbtDelete.TabIndex = 2;
			this.rbtDelete.Text = "&Delete";
			// 
			// rbtCreate
			// 
			this.rbtCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtCreate.Checked = true;
			this.rbtCreate.Location = new System.Drawing.Point(16, 16);
			this.rbtCreate.Name = "rbtCreate";
			this.rbtCreate.Size = new System.Drawing.Size(152, 24);
			this.rbtCreate.TabIndex = 0;
			this.rbtCreate.TabStop = true;
			this.rbtCreate.Text = "&Create";
			// 
			// frmManage_ConfigTables
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(304, 213);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnNext);
			this.MinimumSize = new System.Drawing.Size(192, 168);
			this.Name = "frmManage_ConfigTables";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Config Tables";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_ConfigTables(
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
			this.btnNext.Click += new System.EventHandler(FlowformForm.btnNext_Click);
			this.Closed += new System.EventHandler(FlowformForm.FlowformForm_Closed);
			#endregion
		}

		#region private Properties...
		private cFlowformForm FlowformForm;
		#endregion
		//#region public Properties...
		#region public eInsUpdDel Choice { get; }
		public eInsUpdDel Choice {
			get {
				if (rbtCreate.Checked) return eInsUpdDel.Insert;
				if (rbtDelete.Checked) return eInsUpdDel.Delete;
				if (rbtChange.Checked) return eInsUpdDel.Update;

				return eInsUpdDel.Insert;
			}
		}
		#endregion
		public bool hasConfigTable {
			set {
				rbtChange.Enabled = value;
				rbtDelete.Enabled = value;
			}
		}
		//#endregion

		#region private Methods...
		#endregion
		#region public Methods...
		#endregion

		#region Events...
		#endregion
	}
}