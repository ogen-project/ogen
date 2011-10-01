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
using System.Data;
using System.IO;
using OGen.lib.presentationlayer.winforms.Flowforms;
using OGen.NTier.lib.generator;

namespace OGen.NTier.presentationlayer.winforms {
	public class frm_Main : System.Windows.Forms.Form {
		#region Required designer variable
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MenuItem miHelp;
		private System.Windows.Forms.MenuItem miHelp_About;
		private System.Windows.Forms.MenuItem miProject_Exit;
		private System.Windows.Forms.MenuItem miProject;
		private System.Windows.Forms.MenuItem miProject_New;
		private System.Windows.Forms.MenuItem miProject_Open;
		private System.Windows.Forms.MenuItem miProject_Save;
		private System.Windows.Forms.MenuItem miProject_Close;
		private System.Windows.Forms.MenuItem miGenerator;
		private System.Windows.Forms.MenuItem miGenerator_Generate;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem miWindow;
		private System.Windows.Forms.MenuItem miWindow_DataLayer;
		private System.Windows.Forms.MenuItem miWindow_BusinessLayer;
		private System.Windows.Forms.MenuItem miWindow_Templates;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem miManage;
		private System.Windows.Forms.MenuItem miManage_DL;
		private System.Windows.Forms.MenuItem miManage_DL_Search;
		private System.Windows.Forms.MenuItem miManage_DL_Update;
		private System.Windows.Forms.MenuItem miManage_DL_ViewsPK;
		private System.Windows.Forms.MenuItem miManage_DL_TablesListItems;
		private System.Windows.Forms.MenuItem miManage_DL_ConfigTable;
		private System.Windows.Forms.MenuItem miManage_BL;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem miManage_Configuration;
		private System.Windows.Forms.MenuItem miManage_Configuration_Project;
		private System.Windows.Forms.MenuItem miManage_Configuration_Generator;
		private System.Windows.Forms.MenuItem miManage_DL_Search_Search;
		private System.Windows.Forms.MenuItem miManage_DL_Search_Update;
		private System.Windows.Forms.MainMenu mm_Main;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
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
			this.mm_Main = new System.Windows.Forms.MainMenu();
			this.miProject = new System.Windows.Forms.MenuItem();
			this.miProject_New = new System.Windows.Forms.MenuItem();
			this.miProject_Open = new System.Windows.Forms.MenuItem();
			this.miProject_Close = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.miProject_Save = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.miProject_Exit = new System.Windows.Forms.MenuItem();
			this.miManage = new System.Windows.Forms.MenuItem();
			this.miManage_DL = new System.Windows.Forms.MenuItem();
			this.miManage_DL_Search = new System.Windows.Forms.MenuItem();
			this.miManage_DL_Update = new System.Windows.Forms.MenuItem();
			this.miManage_DL_ViewsPK = new System.Windows.Forms.MenuItem();
			this.miManage_DL_TablesListItems = new System.Windows.Forms.MenuItem();
			this.miManage_DL_ConfigTable = new System.Windows.Forms.MenuItem();
			this.miManage_BL = new System.Windows.Forms.MenuItem();
			this.miManage_Configuration = new System.Windows.Forms.MenuItem();
			this.miManage_Configuration_Project = new System.Windows.Forms.MenuItem();
			this.miManage_Configuration_Generator = new System.Windows.Forms.MenuItem();
			this.miGenerator = new System.Windows.Forms.MenuItem();
			this.miGenerator_Generate = new System.Windows.Forms.MenuItem();
			this.miWindow = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.miWindow_DataLayer = new System.Windows.Forms.MenuItem();
			this.miWindow_BusinessLayer = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.miWindow_Templates = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.miHelp = new System.Windows.Forms.MenuItem();
			this.miHelp_About = new System.Windows.Forms.MenuItem();
			this.miManage_DL_Search_Search = new System.Windows.Forms.MenuItem();
			this.miManage_DL_Search_Update = new System.Windows.Forms.MenuItem();
			// 
			// mm_Main
			// 
			this.mm_Main.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miProject,
																					this.miManage,
																					this.miGenerator,
																					this.miWindow,
																					this.miHelp});
			// 
			// miProject
			// 
			this.miProject.Index = 0;
			this.miProject.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miProject_New,
																					  this.miProject_Open,
																					  this.miProject_Close,
																					  this.menuItem1,
																					  this.menuItem8,
																					  this.miProject_Save,
																					  this.menuItem2,
																					  this.menuItem6,
																					  this.menuItem7,
																					  this.miProject_Exit});
			this.miProject.Text = "&Project";
			// 
			// miProject_New
			// 
			this.miProject_New.Index = 0;
			this.miProject_New.Text = "&New";
			this.miProject_New.Click += new System.EventHandler(this.miProject_New_Click);
			// 
			// miProject_Open
			// 
			this.miProject_Open.Index = 1;
			this.miProject_Open.Text = "&Open";
			this.miProject_Open.Click += new System.EventHandler(this.miProject_Open_Click);
			// 
			// miProject_Close
			// 
			this.miProject_Close.Index = 2;
			this.miProject_Close.Text = "&Close";
			this.miProject_Close.Click += new System.EventHandler(this.miProject_Close_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 3;
			this.menuItem1.Text = "-";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 4;
			this.menuItem8.Text = "&Edit";
			// 
			// miProject_Save
			// 
			this.miProject_Save.Index = 5;
			this.miProject_Save.Text = "&Save";
			this.miProject_Save.Click += new System.EventHandler(this.miProject_Save_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 6;
			this.menuItem2.Text = "-";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 7;
			this.menuItem6.Text = "&Recent Projects";
			this.menuItem6.Visible = false;
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 8;
			this.menuItem7.Text = "-";
			this.menuItem7.Visible = false;
			// 
			// miProject_Exit
			// 
			this.miProject_Exit.Index = 9;
			this.miProject_Exit.Text = "E&xit";
			this.miProject_Exit.Click += new System.EventHandler(this.miProject_Exit_Click);
			// 
			// miManage
			// 
			this.miManage.Index = 1;
			this.miManage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miManage_DL,
																					 this.miManage_BL,
																					 this.miManage_Configuration});
			this.miManage.Text = "&NextStep";
			// 
			// miManage_DL
			// 
			this.miManage_DL.Index = 0;
			this.miManage_DL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.miManage_DL_Search,
																						this.miManage_DL_Update,
																						this.miManage_DL_ViewsPK,
																						this.miManage_DL_TablesListItems,
																						this.miManage_DL_ConfigTable});
			this.miManage_DL.Text = "on &DataLayer";
			// 
			// miManage_DL_Search
			// 
			this.miManage_DL_Search.Index = 0;
			this.miManage_DL_Search.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							   this.miManage_DL_Search_Search,
																							   this.miManage_DL_Search_Update});
			this.miManage_DL_Search.Text = "&Searches";
			this.miManage_DL_Search.Click += new System.EventHandler(this.miManage_DL_Search_Click);
			// 
			// miManage_DL_Update
			// 
			this.miManage_DL_Update.Index = 1;
			this.miManage_DL_Update.Text = "&Updates";
			this.miManage_DL_Update.Click += new System.EventHandler(this.miManage_DL_Update_Click);
			// 
			// miManage_DL_ViewsPK
			// 
			this.miManage_DL_ViewsPK.Index = 2;
			this.miManage_DL_ViewsPK.Text = "View\'s P&K";
			this.miManage_DL_ViewsPK.Click += new System.EventHandler(this.miManage_DL_ViewsPK_Click);
			// 
			// miManage_DL_TablesListItems
			// 
			this.miManage_DL_TablesListItems.Index = 3;
			this.miManage_DL_TablesListItems.Text = "Table\'s &ListItems";
			// 
			// miManage_DL_ConfigTable
			// 
			this.miManage_DL_ConfigTable.Index = 4;
			this.miManage_DL_ConfigTable.Text = "&Config Tables";
			this.miManage_DL_ConfigTable.Click += new System.EventHandler(this.miManage_DL_ConfigTable_Click);
			// 
			// miManage_BL
			// 
			this.miManage_BL.Index = 1;
			this.miManage_BL.Text = "on &BusinessLayer";
			this.miManage_BL.Visible = false;
			// 
			// miManage_Configuration
			// 
			this.miManage_Configuration.Index = 2;
			this.miManage_Configuration.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								   this.miManage_Configuration_Project,
																								   this.miManage_Configuration_Generator});
			this.miManage_Configuration.Text = "&Configurations";
			// 
			// miManage_Configuration_Project
			// 
			this.miManage_Configuration_Project.Index = 0;
			this.miManage_Configuration_Project.Text = "Current &Project";
			this.miManage_Configuration_Project.Click += new System.EventHandler(this.miManage_Configuration_Project_Click);
			// 
			// miManage_Configuration_Generator
			// 
			this.miManage_Configuration_Generator.Index = 1;
			this.miManage_Configuration_Generator.Text = "&Generator";
			this.miManage_Configuration_Generator.Visible = false;
			this.miManage_Configuration_Generator.Click += new System.EventHandler(this.miManage_Configuration_Generator_Click);
			// 
			// miGenerator
			// 
			this.miGenerator.Index = 2;
			this.miGenerator.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.miGenerator_Generate});
			this.miGenerator.Text = "&Generator";
			// 
			// miGenerator_Generate
			// 
			this.miGenerator_Generate.Index = 0;
			this.miGenerator_Generate.Text = "&Generate";
			this.miGenerator_Generate.Click += new System.EventHandler(this.miGenerator_Generate_Click);
			// 
			// miWindow
			// 
			this.miWindow.Index = 3;
			this.miWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem5,
																					 this.miWindow_DataLayer,
																					 this.miWindow_BusinessLayer,
																					 this.menuItem4,
																					 this.miWindow_Templates,
																					 this.menuItem3});
			this.miWindow.Text = "&Window";
			this.miWindow.Visible = false;
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Text = "-";
			// 
			// miWindow_DataLayer
			// 
			this.miWindow_DataLayer.Index = 1;
			this.miWindow_DataLayer.Text = "&Data Layer";
			// 
			// miWindow_BusinessLayer
			// 
			this.miWindow_BusinessLayer.Index = 2;
			this.miWindow_BusinessLayer.Text = "&Business Layer";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "-";
			// 
			// miWindow_Templates
			// 
			this.miWindow_Templates.Index = 4;
			this.miWindow_Templates.Text = "&Templates";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 5;
			this.menuItem3.Text = "-";
			// 
			// miHelp
			// 
			this.miHelp.Index = 4;
			this.miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miHelp_About});
			this.miHelp.Text = "&Help";
			// 
			// miHelp_About
			// 
			this.miHelp_About.Index = 0;
			this.miHelp_About.Text = "&About";
			this.miHelp_About.Click += new System.EventHandler(this.miHelp_About_Click);
			// 
			// miManage_DL_Search_Search
			// 
			this.miManage_DL_Search_Search.Index = 0;
			this.miManage_DL_Search_Search.Text = "Searches";
			this.miManage_DL_Search_Search.Click += new System.EventHandler(this.miManage_DL_Search_Search_Click);
			// 
			// miManage_DL_Search_Update
			// 
			this.miManage_DL_Search_Update.Index = 1;
			this.miManage_DL_Search_Update.Text = "Updates";
			this.miManage_DL_Search_Update.Click += new System.EventHandler(this.miManage_DL_Search_Update_Click);
			// 
			// frm_Main
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(581, 429);
			this.IsMdiContainer = true;
			this.Menu = this.mm_Main;
			this.Name = "frm_Main";
			this.Text = "OGen";

		}
		#endregion
		#endregion

		#region [STAThread]
		[STAThread]
		static void Main() {
			Application.Run(new frm_Main());
		}
		#endregion
		public frm_Main() {
			#region Required for Windows Form Designer support
			InitializeComponent();
			#endregion
			#region Event safeguard...
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Main_Closing);
			#endregion
			ntierproject = new cFGenerator();
			this.Form_Refresh();

			if (
				#if !NET_1_1
				System.Configuration.ConfigurationManager.AppSettings
				#else
				System.Configuration.ConfigurationSettings.AppSettings
				#endif
					[frm_about.APPSETTINGS_LICENSE] != frm_about.APPSETTINGS_LICENSE_IHAVEREADLINCENSE
			) {
				frm_about about = new frm_about();
				about.ShowDialog();
			}
		}

		#region private Properties...
		#endregion
		//#region public Properties...
		#region public static cNTierProject NTierProject { get; }
		public static cFGenerator ntierproject;
		public static cFGenerator NTierProject {
			get { return ntierproject; }
		}
		#endregion
		//#endregion

		#region private Methods...
		#endregion
		//#region public Methods...
		#region public bool ProjectClose(...);
		public bool ProjectClose(bool Refresh_) {
			bool ProjectClosed_out = false;

			switch (ProjectSave(false, true, true)) {
				case DialogResult.Yes:
				case DialogResult.No:
					frm_Main.NTierProject.Close(true);
					if (Refresh_) this.Form_Refresh();
					ProjectClosed_out = true;
					break;
				case DialogResult.Cancel:
					ProjectClosed_out = false;
					break;
			}

			return ProjectClosed_out;
		}
		#endregion
		#region public bool ProjectOpen(...);
		public bool ProjectOpen(bool Refresh_) {
			bool ProjectOpened = false;

			switch (this.ProjectSave(false, true, true)) {
				case DialogResult.Yes:
				case DialogResult.No:
					#region OpenFileDialog.ShowDialog(); ProjectOpened = ...; this.Form_Refresh();
					OpenFileDialog openfile = new OpenFileDialog();
					openfile.Filter = "Project's Metadata File (*.xml)|*.xml";
					openfile.Multiselect = false;
					switch (openfile.ShowDialog()) {
						case DialogResult.OK:
							this.ProjectClose(false);

							frmProcessOutput output = new frmProcessOutput("Output");
							output.MdiParent = this;
							output.Show();
							output.Refresh();
							this.Refresh();
							//output.DisplayMessage("opening...", true);

							frm_Main.NTierProject.Open(
								openfile.FileName, 
								false,
								new OGen.NTier.lib.generator.cFGenerator.dNotifyBack(
									output.DisplayMessage
								)
							);

							//output.DisplayMessage("... finished!", true);
							output.DisplayMessage();
							#region //frmDataLayer.Show();
							//frmDataLayer datalayer = new frmDataLayer();
							//datalayer.MdiParent = this;
							////datalayer.WindowState = FormWindowState.Maximized;
							//datalayer.Show();
							#endregion

							ProjectOpened = true;
							break;
						case DialogResult.Cancel:
							ProjectOpened = false;
							break;
					}

					// even if project was not opened
					// refresh is needed for save state could
					// have been changed, hence:
					if (Refresh_) this.Form_Refresh();
					#endregion
					break;
				case DialogResult.Cancel:
					ProjectOpened = false;
					break;
			}

			return ProjectOpened;
		}
		#endregion
		#region public DialogResult ProjectSave(...);
		public DialogResult ProjectSave(bool Refresh_, bool AskForConfirmation_, bool truefor_YesNoCancel_falsefor_OKCancel) {
			DialogResult Result_out = DialogResult.Cancel;

			if (frm_Main.NTierProject.isOpened) {
				if (frm_Main.NTierProject.hasChanges) {
					if (AskForConfirmation_) {
						switch (MessageBox.Show(
							string.Format(
								"Save Changes to \"{0}\"?", 
								Path.GetFileName(
									NTierProject.Filename
								)
							), 
							"Confirm", 
							(truefor_YesNoCancel_falsefor_OKCancel) ? MessageBoxButtons.YesNoCancel : MessageBoxButtons.OKCancel, 
							MessageBoxIcon.Question
						)) {
							case DialogResult.Yes:
							case DialogResult.OK:
								frm_Main.NTierProject.Save();
								Result_out = DialogResult.Yes;
								break;
							case DialogResult.No:
								Result_out = DialogResult.No;
								break;
							case DialogResult.Cancel:
								Result_out = DialogResult.Cancel;
								break;
						}
					} else {
						frm_Main.NTierProject.Save();
						Result_out = DialogResult.Yes;
					}
				} else {
					Result_out = DialogResult.Yes;
				}
			} else {
				Result_out = DialogResult.Yes;
			}

			if (Refresh_) this.Form_Refresh();
			return Result_out;
		}
		#endregion
		#region public void ProjectNew();
		public void ProjectNew(bool Refresh_) {
			if (ProjectClose(true)) {
				new cTweak_Project_s000(
					this, 
					cTweak_Project_s000.eMode.New
				).Show();
			}
			if (Refresh_) this.Form_Refresh();
		}
		#endregion
		//--
		#region public void Form_Refresh();
		public void Form_Refresh() {
			if (frm_Main.NTierProject.isOpened) {
				if (frm_Main.NTierProject.hasChanges) {
					this.Text = string.Format("OGen: - {0}*", Path.GetFileName(NTierProject.Filename));
					this.miProject_Save.Enabled = true;
				} else {
					this.Text = string.Format("OGen: - {0}", Path.GetFileName(NTierProject.Filename));
					this.miProject_Save.Enabled = false;
				}
				this.miProject_Close.Enabled = true;
				//this.miManage.Enabled = true;
				this.miManage_BL.Enabled = true;
				this.miManage_DL.Enabled = true;
				this.miManage_Configuration_Project.Enabled = true;
				this.miGenerator.Enabled = true;
				this.miWindow.Enabled = true;
			} else {
				this.Text = "OGen";
				this.miProject_Close.Enabled = false;
				this.miProject_Save.Enabled = false;
				//this.miManage.Enabled = false;
				this.miManage_BL.Enabled = false;
				this.miManage_DL.Enabled = false;
				this.miManage_Configuration_Project.Enabled = false;
				this.miGenerator.Enabled = false;
				this.miWindow.Enabled = false;
			}
		}
		#endregion
		//#endregion

		#region Events...
		private void miHelp_About_Click(object sender, System.EventArgs e) {
			frm_about about = new frm_about();
			about.ShowDialog();
		}
		private void miProject_New_Click(object sender, System.EventArgs e) {
			this.ProjectNew(true);
		}
		private void miProject_Open_Click(object sender, System.EventArgs e) {
			this.ProjectOpen(true);
		}
		private void miProject_Save_Click(object sender, System.EventArgs e) {
			this.ProjectSave(true, false, true);
		}
		private void miProject_Close_Click(object sender, System.EventArgs e) {
			this.ProjectClose(true);
		}
		private void miManage_DL_Search_Click(object sender, System.EventArgs e) {
		}
		private void miManage_DL_Update_Click(object sender, System.EventArgs e) {
		}
		private void miManage_DL_Search_Search_Click(object sender, System.EventArgs e) {
			frmManage_Searches Manage_Searches = new frmManage_Searches(this);
			Manage_Searches.MdiParent = this;
			Manage_Searches.Show();
		}
		private void miManage_DL_Search_Update_Click(object sender, System.EventArgs e) {
			frmManage_Updates Manage_Updates = new frmManage_Updates(this);
			Manage_Updates.MdiParent = this;
			Manage_Updates.Show();
		}
		private void miManage_DL_ViewsPK_Click(object sender, System.EventArgs e) {
			new cManage_Views_PK_s000(this).Show();
		}
		private void miManage_DL_ConfigTable_Click(object sender, System.EventArgs e) {
			new cManage_ConfigTables(this).Show();
		}
		private void miGenerator_Generate_Click(object sender, System.EventArgs e) {
			new cGenerator_Generate_s000(this).Show();
		}
		private void miManage_Configuration_Project_Click(object sender, System.EventArgs e) {
			new cTweak_Project_s000(this, cTweak_Project_s000.eMode.Update).Show();
		}
		private void miManage_Configuration_Generator_Click(object sender, System.EventArgs e) {
		}
		private void miProject_Exit_Click(object sender, System.EventArgs e) {
			if (this.ProjectClose(true)) {
				Application.Exit();
			}
		}
		private void frm_Main_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			e.Cancel = !this.ProjectClose(true);
		}
		#endregion
	}
}
