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

namespace OGen.NTier.presentationlayer.winforms {
	public class PO_ConfigTables {
		#region public PO_ConfigTables(...);
		public PO_ConfigTables(frm_Main MainForm_) {
			MainForm = MainForm_;
		}
		~PO_ConfigTables() {
			cleanUp();
		}
		public void Dispose() {
			System.GC.SuppressFinalize(this);
			cleanUp();
		}
		public void cleanUp() {
			// ...
		}
		#endregion
		private frm_Main MainForm;

		#region public eInsUpdDel Choice { get; set; }
		private eInsUpdDel choice;
		public eInsUpdDel Choice {
			get { return choice; }
			set { choice = value; }
		}
		#endregion
		#region public string TableName { get; set; }
		private string tablename;
		public string TableName {
			get { return tablename; }
			set { tablename = value; }
		}
		#endregion
		#region public string ConfigField { get; set; }
		private string configfield;
		public string ConfigField {
			get { return configfield; }
			set { configfield = value; }
		}
		#endregion
		#region public string NameField { get; set; }
		private string namefield;
		public string NameField {
			get { return namefield; }
			set { namefield = value; }
		}
		#endregion
		#region public string DatatypeField { get; set; }
		private string datatypefield;
		public string DatatypeField {
			get { return datatypefield; }
			set { datatypefield = value; }
		}
		#endregion

		public void ConfigTables() {
			for (int f = 0; f < frm_Main.ntierproject.Metadata.Tables[TableName].Fields.Count; f++) {
				frm_Main.ntierproject.Metadata.Tables[TableName].Fields[f].isConfig_Name = false;
				frm_Main.ntierproject.Metadata.Tables[TableName].Fields[f].isConfig_Config = false;
				frm_Main.ntierproject.Metadata.Tables[TableName].Fields[f].isConfig_Datatype = false;
				//frm_Main.ntierproject.Metadata.Tables[TableName].Searches.RemoveAt("byName");
			}

			switch (Choice) {
				case eInsUpdDel.Delete:
					frm_Main.ntierproject.Metadata.Tables[TableName].isConfig = false;
					break;
				case eInsUpdDel.Update:
				case eInsUpdDel.Insert:
					frm_Main.ntierproject.Metadata.Tables[TableName].isConfig = true;

					frm_Main.ntierproject.Metadata.Tables[TableName].Fields[NameField].isConfig_Name = true;
					frm_Main.ntierproject.Metadata.Tables[TableName].Fields[ConfigField].isConfig_Config = true;
					frm_Main.ntierproject.Metadata.Tables[TableName].Fields[DatatypeField].isConfig_Datatype = true;

					//int s = frm_Main.ntierproject.Metadata.Tables[TableName].Searches.Add("byName", true);
					//frm_Main.ntierproject.Metadata.Tables[TableName].Searches[s].isExplicitUniqueIndex = true;
					//frm_Main.ntierproject.Metadata.Tables[TableName].Searches[s].isRange = false;
					//frm_Main.ntierproject.Metadata.Tables[TableName].Searches[s].SearchParameters.Add(
					//	TableName, 
					//	NameField, 
					//	true, 
					//	NameField
					//);
					break;
			}
			frm_Main.NTierProject.hasChanges = true;
			MainForm.Form_Refresh();
		}
	}
}