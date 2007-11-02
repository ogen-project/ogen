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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using OGen.lib.presentationlayer.winforms.Flowforms;

namespace OGen.NTier.presentationlayer.winforms {
	public class frmGenerator_Generate_s000 : System.Windows.Forms.Form {
		#region Required designer variable...
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbtSeparateScriptFiles;
		private System.Windows.Forms.RadioButton rbtOneScriptFile;
		private System.Windows.Forms.RadioButton rbtRunImmediately;
		private System.Windows.Forms.CheckBox chkPReflection;
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
			this.rbtSeparateScriptFiles = new System.Windows.Forms.RadioButton();
			this.rbtOneScriptFile = new System.Windows.Forms.RadioButton();
			this.rbtRunImmediately = new System.Windows.Forms.RadioButton();
			this.chkPReflection = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(248, 200);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "&Generate!";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.Controls.Add(this.rbtSeparateScriptFiles);
			this.groupBox1.Controls.Add(this.rbtOneScriptFile);
			this.groupBox1.Controls.Add(this.rbtRunImmediately);
			this.groupBox1.Location = new System.Drawing.Point(64, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(208, 96);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " DB Script Options: ";
			// 
			// rbtSeparateScriptFiles
			// 
			this.rbtSeparateScriptFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtSeparateScriptFiles.Enabled = false;
			this.rbtSeparateScriptFiles.Location = new System.Drawing.Point(16, 64);
			this.rbtSeparateScriptFiles.Name = "rbtSeparateScriptFiles";
			this.rbtSeparateScriptFiles.Size = new System.Drawing.Size(184, 24);
			this.rbtSeparateScriptFiles.TabIndex = 2;
			this.rbtSeparateScriptFiles.Text = "&Separate Script Files";
			// 
			// rbtOneScriptFile
			// 
			this.rbtOneScriptFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtOneScriptFile.Enabled = false;
			this.rbtOneScriptFile.Location = new System.Drawing.Point(16, 40);
			this.rbtOneScriptFile.Name = "rbtOneScriptFile";
			this.rbtOneScriptFile.Size = new System.Drawing.Size(184, 24);
			this.rbtOneScriptFile.TabIndex = 1;
			this.rbtOneScriptFile.Text = "&One Script File";
			// 
			// rbtRunImmediately
			// 
			this.rbtRunImmediately.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbtRunImmediately.Checked = true;
			this.rbtRunImmediately.Location = new System.Drawing.Point(16, 16);
			this.rbtRunImmediately.Name = "rbtRunImmediately";
			this.rbtRunImmediately.Size = new System.Drawing.Size(184, 24);
			this.rbtRunImmediately.TabIndex = 0;
			this.rbtRunImmediately.TabStop = true;
			this.rbtRunImmediately.Text = "Run &Immediately";
			// 
			// chkPReflection
			// 
			this.chkPReflection.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkPReflection.Location = new System.Drawing.Point(80, 136);
			this.chkPReflection.Name = "chkPReflection";
			this.chkPReflection.Size = new System.Drawing.Size(200, 24);
			this.chkPReflection.TabIndex = 7;
			this.chkPReflection.Text = "pReflection (pseudo reflectionable)";
			// 
			// frmGenerator_Generate_s000
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 229);
			this.Controls.Add(this.chkPReflection);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnNext);
			this.MinimumSize = new System.Drawing.Size(224, 192);
			this.Name = "frmGenerator_Generate_s000";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generator";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		public frmGenerator_Generate_s000(
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
		public OGen.NTier.lib.metadata.metadataExtended.XS_SQLScriptOptionEnumeration SQLscriptOptions {
			get {
				if (rbtOneScriptFile.Checked)
					return OGen.NTier.lib.metadata.metadataExtended.XS_SQLScriptOptionEnumeration.OneScriptFile;
				if (rbtSeparateScriptFiles.Checked)
					return OGen.NTier.lib.metadata.metadataExtended.XS_SQLScriptOptionEnumeration.SeparateScriptFiles;

				// make it default:
				//if (rbtRunImmediately.Checked)
					return OGen.NTier.lib.metadata.metadataExtended.XS_SQLScriptOptionEnumeration.RunImmediately;
			}
		}
		public bool pReflection {
			get { return chkPReflection.Checked; }
			set { chkPReflection.Checked = value; }
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