#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.PresentationLayer.WinForms {
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;
	using OGen.Libraries.PresentationLayer.WinForms.FlowForms;

	public class frmManage_ConfigTables_CreateOrChange_s010 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Label label1;
		private OGen.NTier.PresentationLayer.WinForms.ucPick_Tables Pick_Tables;
		private System.Windows.Forms.Button btnNext;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (this.components != null) {
					this.components.Dispose();
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
			this.Pick_Tables = new OGen.NTier.PresentationLayer.WinForms.ucPick_Tables();
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
			this.btnNext.Text = "&Next >>";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "Choose Table:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// Pick_Tables
			// 
			this.Pick_Tables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Pick_Tables.Location = new System.Drawing.Point(8, 24);
			this.Pick_Tables.Name = "Pick_Tables";
			this.Pick_Tables.Size = new System.Drawing.Size(280, 216);
			this.Pick_Tables.TabIndex = 6;
			// 
			// frmManage_ConfigTables_CreateOrChange_s010
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 277);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Pick_Tables);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnNext);
			this.MinimumSize = new System.Drawing.Size(192, 144);
			this.Name = "frmManage_ConfigTables_CreateOrChange_s010";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Config Tables";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmManage_ConfigTables_CreateOrChange_s010(
			FlowformForm.dNotifyBase NotifyBase_, 
			FlowformForm.dNotifyBase NotifyBase_aboutNext_
		) {
			#region Required for Windows Form Designer support...
			this.InitializeComponent();
			#endregion
			this.flowformform_ = new FlowformForm(
				NotifyBase_, 
				NotifyBase_aboutNext_
			);
			#region Event safeguard...
			this.btnBack.Click += new System.EventHandler(this.flowformform_.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.flowformform_.btnNext_Click);
			this.Closed += new System.EventHandler(this.flowformform_.FlowformForm_Closed);
			#endregion
		}

		#region private Properties...
		private FlowformForm flowformform_;
		#endregion
		//#region public Properties...
		#region public string TableName { get; }
		public string TableName {
			get {
				string[] _SelectedTables = this.Pick_Tables.SelectedTables();
				if (_SelectedTables.Length != 0) {
					return _SelectedTables[0];
				}
				return "";
			}
		}
		#endregion
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		public void Bind(eInsUpdDel Choice_) {
			switch (Choice_) {
				case eInsUpdDel.Delete:
					this.Pick_Tables.Bind_Tables(
						ucPick_Tables.eTypeSelection.OnlyConfigTables, 
						false
					);
					this.btnNext.Text = "Delete!";
					break;
				case eInsUpdDel.Update:
					this.Pick_Tables.Bind_Tables(
						ucPick_Tables.eTypeSelection.OnlyConfigTables, 
						false
					);
					break;
				case eInsUpdDel.Insert:
					this.Pick_Tables.Bind_Tables(
						ucPick_Tables.eTypeSelection.NoConfigTables, 
						false
					);
					break;
			}
		}
		//#endregion

		#region Events...
		#endregion
	}
}