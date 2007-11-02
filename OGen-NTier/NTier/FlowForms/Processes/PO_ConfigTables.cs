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
			frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].ConfigName = string.Empty;
			frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].ConfigConfig = string.Empty;
			frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].ConfigDatatype = string.Empty;

			switch (Choice) {
				case eInsUpdDel.Delete:
					frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].isConfig = false;
					break;
				case eInsUpdDel.Update:
				case eInsUpdDel.Insert:
					frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].isConfig = true;

					frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].ConfigName = NameField;
					frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].ConfigConfig = ConfigField;
					frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].ConfigDatatype = DatatypeField;

					//int s = frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].Searches.Add("byName", true);
					//frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].Searches[s].isExplicitUniqueIndex = true;
					//frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].Searches[s].isRange = false;
					//frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[TableName].Searches[s].SearchParameters.Add(
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
