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
	using System.Data;
	using System.Drawing;
	using System.IO;
	using System.Windows.Forms;
	using OGen.Libraries.PresentationLayer.WinForms.FlowForms;
	using OGen.NTier.Libraries.Generator;

	public class frm_Main : System.Windows.Forms.Form {
		private IContainer components;
		#region Required designer variable

		private System.Windows.Forms.MenuItem MenuItemHelp;
		private System.Windows.Forms.MenuItem MenuItemHelp_About;
		private System.Windows.Forms.MenuItem MenuItemProject_Exit;
		private System.Windows.Forms.MenuItem MenuItemProject;
		private System.Windows.Forms.MenuItem MenuItemProject_New;
		private System.Windows.Forms.MenuItem MenuItemProject_Open;
		private System.Windows.Forms.MenuItem MenuItemProject_Save;
		private System.Windows.Forms.MenuItem MenuItemProject_Close;
		private System.Windows.Forms.MenuItem MenuItemGenerator;
		private System.Windows.Forms.MenuItem MenuItemGenerator_Generate;
		private System.Windows.Forms.MenuItem MenuItem1;
		private System.Windows.Forms.MenuItem MenuItem2;
		private System.Windows.Forms.MenuItem MenuItemWindow;
		private System.Windows.Forms.MenuItem MenuItemWindow_DataLayer;
		private System.Windows.Forms.MenuItem MenuItemWindow_BusinessLayer;
		private System.Windows.Forms.MenuItem MenuItemWindow_Templates;
		private System.Windows.Forms.MenuItem MenuItem4;
		private System.Windows.Forms.MenuItem MenuItem3;
		private System.Windows.Forms.MenuItem MenuItem5;
		private System.Windows.Forms.MenuItem MenuItem6;
		private System.Windows.Forms.MenuItem MenuItem7;
		private System.Windows.Forms.MenuItem MenuItemManage;
		private System.Windows.Forms.MenuItem MenuItemManage_DL;
		private System.Windows.Forms.MenuItem MenuItemManage_DL_Search;
		private System.Windows.Forms.MenuItem MenuItemManage_DL_Update;
		private System.Windows.Forms.MenuItem MenuItemManage_DL_ViewsPK;
		private System.Windows.Forms.MenuItem MenuItemManage_DL_TablesListItems;
		private System.Windows.Forms.MenuItem MenuItemManage_DL_ConfigTable;
		private System.Windows.Forms.MenuItem MenuItemManage_BL;
		private System.Windows.Forms.MenuItem MenuItem8;
		private System.Windows.Forms.MenuItem MenuItemManage_Configuration;
		private System.Windows.Forms.MenuItem MenuItemManage_Configuration_Project;
		private System.Windows.Forms.MenuItem MenuItemManage_Configuration_Generator;
		private System.Windows.Forms.MenuItem MenuItemManage_DL_Search_Search;
		private System.Windows.Forms.MenuItem MenuItemManage_DL_Search_Update;
		private System.Windows.Forms.MainMenu MainMenu_Main;

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
			this.components = new System.ComponentModel.Container();
			this.MainMenu_Main = new System.Windows.Forms.MainMenu(this.components);
			this.MenuItemProject = new System.Windows.Forms.MenuItem();
			this.MenuItemProject_New = new System.Windows.Forms.MenuItem();
			this.MenuItemProject_Open = new System.Windows.Forms.MenuItem();
			this.MenuItemProject_Close = new System.Windows.Forms.MenuItem();
			this.MenuItem1 = new System.Windows.Forms.MenuItem();
			this.MenuItem8 = new System.Windows.Forms.MenuItem();
			this.MenuItemProject_Save = new System.Windows.Forms.MenuItem();
			this.MenuItem2 = new System.Windows.Forms.MenuItem();
			this.MenuItem6 = new System.Windows.Forms.MenuItem();
			this.MenuItem7 = new System.Windows.Forms.MenuItem();
			this.MenuItemProject_Exit = new System.Windows.Forms.MenuItem();
			this.MenuItemManage = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_DL = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_DL_Search = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_DL_Search_Search = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_DL_Search_Update = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_DL_Update = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_DL_ViewsPK = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_DL_TablesListItems = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_DL_ConfigTable = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_BL = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_Configuration = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_Configuration_Project = new System.Windows.Forms.MenuItem();
			this.MenuItemManage_Configuration_Generator = new System.Windows.Forms.MenuItem();
			this.MenuItemGenerator = new System.Windows.Forms.MenuItem();
			this.MenuItemGenerator_Generate = new System.Windows.Forms.MenuItem();
			this.MenuItemWindow = new System.Windows.Forms.MenuItem();
			this.MenuItem5 = new System.Windows.Forms.MenuItem();
			this.MenuItemWindow_DataLayer = new System.Windows.Forms.MenuItem();
			this.MenuItemWindow_BusinessLayer = new System.Windows.Forms.MenuItem();
			this.MenuItem4 = new System.Windows.Forms.MenuItem();
			this.MenuItemWindow_Templates = new System.Windows.Forms.MenuItem();
			this.MenuItem3 = new System.Windows.Forms.MenuItem();
			this.MenuItemHelp = new System.Windows.Forms.MenuItem();
			this.MenuItemHelp_About = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// mm_Main
			// 
			this.MainMenu_Main.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemProject,
            this.MenuItemManage,
            this.MenuItemGenerator,
            this.MenuItemWindow,
            this.MenuItemHelp});
			// 
			// miProject
			// 
			this.MenuItemProject.Index = 0;
			this.MenuItemProject.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemProject_New,
            this.MenuItemProject_Open,
            this.MenuItemProject_Close,
            this.MenuItem1,
            this.MenuItem8,
            this.MenuItemProject_Save,
            this.MenuItem2,
            this.MenuItem6,
            this.MenuItem7,
            this.MenuItemProject_Exit});
			this.MenuItemProject.Text = "&Project";
			// 
			// miProject_New
			// 
			this.MenuItemProject_New.Index = 0;
			this.MenuItemProject_New.Text = "&New";
			this.MenuItemProject_New.Click += new System.EventHandler(this.miProject_New_Click);
			// 
			// miProject_Open
			// 
			this.MenuItemProject_Open.Index = 1;
			this.MenuItemProject_Open.Text = "&Open";
			this.MenuItemProject_Open.Click += new System.EventHandler(this.miProject_Open_Click);
			// 
			// miProject_Close
			// 
			this.MenuItemProject_Close.Index = 2;
			this.MenuItemProject_Close.Text = "&Close";
			this.MenuItemProject_Close.Click += new System.EventHandler(this.miProject_Close_Click);
			// 
			// menuItem1
			// 
			this.MenuItem1.Index = 3;
			this.MenuItem1.Text = "-";
			// 
			// menuItem8
			// 
			this.MenuItem8.Index = 4;
			this.MenuItem8.Text = "&Edit";
			this.MenuItem8.Visible = false;
			// 
			// miProject_Save
			// 
			this.MenuItemProject_Save.Index = 5;
			this.MenuItemProject_Save.Text = "&Save";
			this.MenuItemProject_Save.Click += new System.EventHandler(this.miProject_Save_Click);
			// 
			// menuItem2
			// 
			this.MenuItem2.Index = 6;
			this.MenuItem2.Text = "-";
			// 
			// menuItem6
			// 
			this.MenuItem6.Index = 7;
			this.MenuItem6.Text = "&Recent Projects";
			this.MenuItem6.Visible = false;
			// 
			// menuItem7
			// 
			this.MenuItem7.Index = 8;
			this.MenuItem7.Text = "-";
			this.MenuItem7.Visible = false;
			// 
			// miProject_Exit
			// 
			this.MenuItemProject_Exit.Index = 9;
			this.MenuItemProject_Exit.Text = "E&xit";
			this.MenuItemProject_Exit.Click += new System.EventHandler(this.miProject_Exit_Click);
			// 
			// miManage
			// 
			this.MenuItemManage.Index = 1;
			this.MenuItemManage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemManage_DL,
            this.MenuItemManage_BL,
            this.MenuItemManage_Configuration});
			this.MenuItemManage.Text = "&NextStep";
			// 
			// miManage_DL
			// 
			this.MenuItemManage_DL.Index = 0;
			this.MenuItemManage_DL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemManage_DL_Search,
            this.MenuItemManage_DL_Update,
            this.MenuItemManage_DL_ViewsPK,
            this.MenuItemManage_DL_TablesListItems,
            this.MenuItemManage_DL_ConfigTable});
			this.MenuItemManage_DL.Text = "on &DataLayer";
			// 
			// miManage_DL_Search
			// 
			this.MenuItemManage_DL_Search.Index = 0;
			this.MenuItemManage_DL_Search.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemManage_DL_Search_Search,
            this.MenuItemManage_DL_Search_Update});
			this.MenuItemManage_DL_Search.Text = "&Searches";
			this.MenuItemManage_DL_Search.Click += new System.EventHandler(this.miManage_DL_Search_Click);
			// 
			// miManage_DL_Search_Search
			// 
			this.MenuItemManage_DL_Search_Search.Index = 0;
			this.MenuItemManage_DL_Search_Search.Text = "Searches";
			this.MenuItemManage_DL_Search_Search.Click += new System.EventHandler(this.miManage_DL_Search_Search_Click);
			// 
			// miManage_DL_Search_Update
			// 
			this.MenuItemManage_DL_Search_Update.Index = 1;
			this.MenuItemManage_DL_Search_Update.Text = "Updates";
			this.MenuItemManage_DL_Search_Update.Click += new System.EventHandler(this.miManage_DL_Search_Update_Click);
			// 
			// miManage_DL_Update
			// 
			this.MenuItemManage_DL_Update.Index = 1;
			this.MenuItemManage_DL_Update.Text = "&Updates";
			this.MenuItemManage_DL_Update.Click += new System.EventHandler(this.miManage_DL_Update_Click);
			// 
			// miManage_DL_ViewsPK
			// 
			this.MenuItemManage_DL_ViewsPK.Index = 2;
			this.MenuItemManage_DL_ViewsPK.Text = "View\'s P&K";
			this.MenuItemManage_DL_ViewsPK.Click += new System.EventHandler(this.miManage_DL_ViewsPK_Click);
			// 
			// miManage_DL_TablesListItems
			// 
			this.MenuItemManage_DL_TablesListItems.Index = 3;
			this.MenuItemManage_DL_TablesListItems.Text = "Table\'s &ListItems";
			// 
			// miManage_DL_ConfigTable
			// 
			this.MenuItemManage_DL_ConfigTable.Index = 4;
			this.MenuItemManage_DL_ConfigTable.Text = "&Config Tables";
			this.MenuItemManage_DL_ConfigTable.Click += new System.EventHandler(this.miManage_DL_ConfigTable_Click);
			// 
			// miManage_BL
			// 
			this.MenuItemManage_BL.Index = 1;
			this.MenuItemManage_BL.Text = "on &BusinessLayer";
			this.MenuItemManage_BL.Visible = false;
			// 
			// miManage_Configuration
			// 
			this.MenuItemManage_Configuration.Index = 2;
			this.MenuItemManage_Configuration.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemManage_Configuration_Project,
            this.MenuItemManage_Configuration_Generator});
			this.MenuItemManage_Configuration.Text = "&Configurations";
			// 
			// miManage_Configuration_Project
			// 
			this.MenuItemManage_Configuration_Project.Index = 0;
			this.MenuItemManage_Configuration_Project.Text = "Current &Project";
			this.MenuItemManage_Configuration_Project.Click += new System.EventHandler(this.miManage_Configuration_Project_Click);
			// 
			// miManage_Configuration_Generator
			// 
			this.MenuItemManage_Configuration_Generator.Index = 1;
			this.MenuItemManage_Configuration_Generator.Text = "&Generator";
			this.MenuItemManage_Configuration_Generator.Visible = false;
			this.MenuItemManage_Configuration_Generator.Click += new System.EventHandler(this.miManage_Configuration_Generator_Click);
			// 
			// miGenerator
			// 
			this.MenuItemGenerator.Index = 2;
			this.MenuItemGenerator.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemGenerator_Generate});
			this.MenuItemGenerator.Text = "&Generator";
			// 
			// miGenerator_Generate
			// 
			this.MenuItemGenerator_Generate.Index = 0;
			this.MenuItemGenerator_Generate.Text = "&Generate";
			this.MenuItemGenerator_Generate.Click += new System.EventHandler(this.miGenerator_Generate_Click);
			// 
			// miWindow
			// 
			this.MenuItemWindow.Index = 3;
			this.MenuItemWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem5,
            this.MenuItemWindow_DataLayer,
            this.MenuItemWindow_BusinessLayer,
            this.MenuItem4,
            this.MenuItemWindow_Templates,
            this.MenuItem3});
			this.MenuItemWindow.Text = "&Window";
			this.MenuItemWindow.Visible = false;
			// 
			// menuItem5
			// 
			this.MenuItem5.Index = 0;
			this.MenuItem5.Text = "-";
			// 
			// miWindow_DataLayer
			// 
			this.MenuItemWindow_DataLayer.Index = 1;
			this.MenuItemWindow_DataLayer.Text = "&Data Layer";
			// 
			// miWindow_BusinessLayer
			// 
			this.MenuItemWindow_BusinessLayer.Index = 2;
			this.MenuItemWindow_BusinessLayer.Text = "&Business Layer";
			// 
			// menuItem4
			// 
			this.MenuItem4.Index = 3;
			this.MenuItem4.Text = "-";
			// 
			// miWindow_Templates
			// 
			this.MenuItemWindow_Templates.Index = 4;
			this.MenuItemWindow_Templates.Text = "&Templates";
			// 
			// menuItem3
			// 
			this.MenuItem3.Index = 5;
			this.MenuItem3.Text = "-";
			// 
			// miHelp
			// 
			this.MenuItemHelp.Index = 4;
			this.MenuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemHelp_About});
			this.MenuItemHelp.Text = "&Help";
			// 
			// miHelp_About
			// 
			this.MenuItemHelp_About.Index = 0;
			this.MenuItemHelp_About.Text = "&About";
			this.MenuItemHelp_About.Click += new System.EventHandler(this.miHelp_About_Click);
			// 
			// frm_Main
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(581, 429);
			this.IsMdiContainer = true;
			this.Menu = this.MainMenu_Main;
			this.Name = "frm_Main";
			this.Text = "OGen";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		#region [STAThread]
		[STAThread]
		public static void Main() {
			Application.Run(new frm_Main());
		}
		#endregion
		public frm_Main() {
			#region Required for Windows Form Designer support
			this.InitializeComponent();
			#endregion
			#region Event safeguard...
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Main_Closing);
			#endregion
			ntierproject = new NTierGenerator();
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
		public static NTierGenerator ntierproject;
		public static NTierGenerator NTierProject {
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

			switch (this.ProjectSave(false, true, true)) {
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
								output.DisplayMessage
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

			if (frm_Main.NTierProject.IsOpened) {
				if (frm_Main.NTierProject.HasChanges) {
					if (AskForConfirmation_) {
						switch (MessageBox.Show(
							string.Format(
								System.Globalization.CultureInfo.CurrentCulture,
								"Save Changes to \"{0}\"?", 
								Path.GetFileName(
									NTierProject.FileName
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
			if (this.ProjectClose(true)) {
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
			if (frm_Main.NTierProject.IsOpened) {
				if (frm_Main.NTierProject.HasChanges) {
					this.Text = string.Format(
						System.Globalization.CultureInfo.CurrentCulture, 
						"OGen: - {0}*", 
						Path.GetFileName(NTierProject.FileName)
					);
					this.MenuItemProject_Save.Enabled = true;
				} else {
					this.Text = string.Format(
						System.Globalization.CultureInfo.CurrentCulture, 
						"OGen: - {0}", 
						Path.GetFileName(NTierProject.FileName)
					);
					this.MenuItemProject_Save.Enabled = false;
				}
				this.MenuItemProject_Close.Enabled = true;
				//this.miManage.Enabled = true;
				this.MenuItemManage_BL.Enabled = true;
				this.MenuItemManage_DL.Enabled = true;
				this.MenuItemManage_Configuration_Project.Enabled = true;
				this.MenuItemGenerator.Enabled = true;
				this.MenuItemWindow.Enabled = true;
			} else {
				this.Text = "OGen";
				this.MenuItemProject_Close.Enabled = false;
				this.MenuItemProject_Save.Enabled = false;
				//this.miManage.Enabled = false;
				this.MenuItemManage_BL.Enabled = false;
				this.MenuItemManage_DL.Enabled = false;
				this.MenuItemManage_Configuration_Project.Enabled = false;
				this.MenuItemGenerator.Enabled = false;
				this.MenuItemWindow.Enabled = false;
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
