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

	public class PO_ConfigTables : IDisposable {
		#region public PO_ConfigTables(...);
		public PO_ConfigTables(frm_Main MainForm_) {
			this.MainForm = MainForm_;
		}
		~PO_ConfigTables() {
			this.Dispose(false);
		}
		public void Dispose() {
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}
		private void Dispose(bool disposing_in) {
			// ...
		}
		#endregion
		private frm_Main MainForm;

		#region public eInsUpdDel Choice { get; set; }
		private eInsUpdDel choice;
		public eInsUpdDel Choice {
			get { return this.choice; }
			set { this.choice = value; }
		}
		#endregion
		#region public string TableName { get; set; }
		private string tablename;
		public string TableName {
			get { return this.tablename; }
			set { this.tablename = value; }
		}
		#endregion
		#region public string ConfigField { get; set; }
		private string configfield;
		public string ConfigField {
			get { return this.configfield; }
			set { this.configfield = value; }
		}
		#endregion
		#region public string NameField { get; set; }
		private string namefield;
		public string NameField {
			get { return this.namefield; }
			set { this.namefield = value; }
		}
		#endregion
		#region public string DatatypeField { get; set; }
		private string datatypefield;
		public string DatatypeField {
			get { return this.datatypefield; }
			set { this.datatypefield = value; }
		}
		#endregion

		public void ConfigTables() {
			frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].ConfigName = string.Empty;
			frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].ConfigConfig = string.Empty;
			frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].ConfigDatatype = string.Empty;

			switch (this.Choice) {
				case eInsUpdDel.Delete:
					frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].IsConfig = false;
					break;
				case eInsUpdDel.Update:
				case eInsUpdDel.Insert:
					frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].IsConfig = true;

					frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].ConfigName = this.NameField;
					frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].ConfigConfig = this.ConfigField;
					frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].ConfigDatatype = this.DatatypeField;

					//int s = frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].Searches.Add("byName", true);
					//frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].Searches[s].IsExplicitUniqueIndex = true;
					//frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].Searches[s].IsRange = false;
					//frm_Main.ntierproject.Metadata.MetadataExtendedCollection[0].Tables.TableCollection[this.TableName].Searches[s].SearchParameters.Add(
					//	this.TableName, 
					//	this.NameField, 
					//	true, 
					//	this.NameField
					//);
					break;
			}
			frm_Main.NTierProject.hasChanges = true;
			this.MainForm.Form_Refresh();
		}
	}
}
