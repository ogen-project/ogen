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
	public class frmManage_Views_PK_s000 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbtUndefined;
		private System.Windows.Forms.RadioButton rbtAll;
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
			this.rbtUndefined = new System.Windows.Forms.RadioButton();
			this.rbtAll = new System.Windows.Forms.RadioButton();
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
			this.groupBox1.Controls.Add(this.rbtUndefined);
			this.groupBox1.Controls.Add(this.rbtAll);
			this.groupBox1.Location = new System.Drawing.Point(56, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(192, 72);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Views: ";
			// 
			// rbtUndefined
			// 
			this.rbtUndefined.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtUndefined.Checked = true;
			this.rbtUndefined.Location = new System.Drawing.Point(16, 16);
			this.rbtUndefined.Name = "rbtUndefined";
			this.rbtUndefined.Size = new System.Drawing.Size(168, 24);
			this.rbtUndefined.TabIndex = 3;
			this.rbtUndefined.TabStop = true;
			this.rbtUndefined.Text = "with &Undefinied PKs";
			// 
			// rbtAll
			// 
			this.rbtAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtAll.Location = new System.Drawing.Point(16, 40);
			this.rbtAll.Name = "rbtAll";
			this.rbtAll.Size = new System.Drawing.Size(168, 24);
			this.rbtAll.TabIndex = 0;
			this.rbtAll.Text = "&All other";
			// 
			// frmManage_Views_PK_s000
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(304, 213);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnNext);
			this.MinimumSize = new System.Drawing.Size(208, 136);
			this.Name = "frmManage_Views_PK_s000";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage Views PK";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_Views_PK_s000(
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
		#region public bool Undefined_orAll { get; }
		public bool Undefined_orAll {
			get {
				return rbtUndefined.Checked;
			}
		}
		#endregion
		#region public bool hasVirtualTable_withUndefinedKeys { set; }
		public bool hasVirtualTable_withUndefinedKeys {
			set {
				rbtUndefined.Enabled = value;
				rbtUndefined.Checked = value;
				rbtAll.Checked = !value;
			}
		}
		#endregion
		//#endregion

		#region private Methods...
		#endregion
		#region public Methods...
		#endregion

		#region Events...
		#endregion
	}
}