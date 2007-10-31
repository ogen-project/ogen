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
using System.Reflection;
using System.Collections;

using OGen.lib.collections;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Table : cClaSSe {
		#region public cDBMetadata_Table(...);
		public cDBMetadata_Table(
			iClaSSe aggregateloopback_ref_in, 
			iDBMetadata_Tables parent_ref_in, 
			string name_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			Name = name_in;
			FriendlyName = string.Empty;
			DBDescription = string.Empty;
			ExtendedDescription = string.Empty;
			isVirtualTable = false;
			isConfig = false;
			//---
			dbs_ = new cDBMetadata_Table_DBs(this, this);
			fields_ = new cDBMetadata_Table_Fields(this, this);
			searches_ = new cDBMetadata_Table_Searches(this, this);
			updates_ = new cDBMetadata_Updates(this, this.Parent_ref);
			//#endregion

			fields_onlypk_ = new cDBMetadata_Table_Fields_PK(this, true);
			fields_nopk_ = new cDBMetadata_Table_Fields_PK(this, false);
			fields_onlyfk_ = new cDBMetadata_Table_Fields_FK(this, true);
			fields_nofk_ = new cDBMetadata_Table_Fields_FK(this, false);
		}
		#endregion

		#region Implementing - iClaSSe...
		public override string root4xml {
			get {
				return cDBMetadata.ROOT;
			}
		}
		public override object Property_new(string name_in) {
			switch (name_in) {
				default:
					throw new Exception(string.Format(
						"{0}.{1}.Property_new(): - invalid Name: {2}", 
						this.GetType().Namespace,
						this.GetType().Name,
						name_in
					));
			}
		}
		#region public PropertyInfo[] Properties { get; }
		private static PropertyInfo[] properties__ = null;
		public override PropertyInfo[] Properties {
			get {
				if (properties__ == null) {
					InitializeStaticFields(
						ref properties__, 
						ref attributes__
					);
				}
				return properties__;
			}
		}
		#endregion
		#region public ClaSSPropertyAttribute[] Attributes { get; }
		private static ClaSSPropertyAttribute[] attributes__ = null;
		public override ClaSSPropertyAttribute[] Attributes {
			get {
				if (attributes__ == null) {
					InitializeStaticFields(
						ref properties__, 
						ref attributes__
					);
				}
				return attributes__;
			}
		}
		#endregion
		#endregion

		#region Properties - ClaSSe...
		#region public string Name { get; set; }
		private string name_;

		[ClaSSPropertyAttribute("name", ClaSSPropertyAttribute.eType.standard, true)]
		public string Name {
			get { return name_; }
			set { name_ = value; }
		}
		#endregion
		#region public string FriendlyName { get; set; }
		private string friendlyname_;

		[ClaSSPropertyAttribute("friendlyName", ClaSSPropertyAttribute.eType.standard, true)]
		public string FriendlyName {
			get { return friendlyname_; }
			set { friendlyname_ = value; }
		}
		#endregion
		#region public string DBDescription { get; set; }
		private string dbdescription_;

		[ClaSSPropertyAttribute("dbDescription", ClaSSPropertyAttribute.eType.standard, true)]
		public string DBDescription {
			get { return dbdescription_; }
			set { dbdescription_ = value; }
		}
		#endregion
		#region public string ExtendedDescription { get; set; }
		private string extendeddescription_;

		[ClaSSPropertyAttribute("extendedDescription", ClaSSPropertyAttribute.eType.standard, true)]
		public string ExtendedDescription {
			get { return extendeddescription_; }
			set { extendeddescription_ = value; }
		}
		#endregion
		#region public bool isVirtualTable { get; set; }
		private bool isvirtualtable_;
		public bool isVirtualTable {
			get { return isvirtualtable_; }
			set { isvirtualtable_ = value; }
		}

		[ClaSSPropertyAttribute("isVirtualTable", ClaSSPropertyAttribute.eType.standard, true)]
		private string isvirtualtable_reflection {
			get { return isvirtualtable_.ToString(); }
			set { isvirtualtable_ = bool.Parse(value); }
		}
		#endregion
		#region public bool isConfig { get; set; }
		private bool isconfig_;
		public bool isConfig {
			get { return isconfig_; }
			set { isconfig_ = value; }
		}

		[ClaSSPropertyAttribute("isConfig", ClaSSPropertyAttribute.eType.standard, true)]
		private string isconfig_reflection {
			get { return isconfig_.ToString(); }
			set { isconfig_ = bool.Parse(value); }
		}
		#endregion
		//---
		#region private cDBMetadata_Table_DBs dbs_ { get; set; }
		private cDBMetadata_Table_DBs dbs_;

		[ClaSSPropertyAttribute("dbs", ClaSSPropertyAttribute.eType.aggregate, true)]
		private cDBMetadata_Table_DBs dbs_reflection {
			get { return dbs_; }
			//set { dbs_ = value; }
		}
		#endregion
		#region private iDBMetadata_Table_Fields fields_ { get; set; }
		private iDBMetadata_Table_Fields fields_;

		[ClaSSPropertyAttribute("fields", ClaSSPropertyAttribute.eType.aggregate, true)]
		private iDBMetadata_Table_Fields fields_reflection {
			get { return fields_; }
			//set { fields_ = value; }
		}
		#endregion
		#region private iDBMetadata_Table_Searches searches_ { get; set; }
		private iDBMetadata_Table_Searches searches_;

		[ClaSSPropertyAttribute("searches", ClaSSPropertyAttribute.eType.aggregate, true)]
		private iDBMetadata_Table_Searches searches_reflection {
			get { return searches_; }
			//set { searches_ = value; }
		}
		#endregion
		#region private cDBMetadata_Updates updates_ { get; set; }
		private cDBMetadata_Updates updates_;

		[ClaSSPropertyAttribute("updates", ClaSSPropertyAttribute.eType.aggregate, true)]
		private cDBMetadata_Updates updates_reflection {
			get { return updates_; }
			//set { updates_ = value; }
		}
		#endregion
//		#region private string hasidentitykey__ { get; }
		[ClaSSPropertyAttribute("hasIdentityKey", ClaSSPropertyAttribute.eType.standard, false)]
		private string hasidentitykey__ {
			get { return (hasIdentityKey() != -1).ToString(); }
		}
//		#endregion
		#endregion
		#region Properties...
		#region public iDBMetadata_Tables Parent_ref;
		private iDBMetadata_Tables parent_ref_;
		public iDBMetadata_Tables Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		//---
		#region public cDBMetadata_Table_DBs DBs { get; }
		public cDBMetadata_Table_DBs DBs {
			get { return dbs_; }
		}
		#endregion
		#region public iDBMetadata_Table_Fields Fields { get; }
		public iDBMetadata_Table_Fields Fields {
			get { return fields_; }
		}
		#endregion
		#region public iDBMetadata_Table_Searches Searches { get; }
		public iDBMetadata_Table_Searches Searches {
			get { return searches_; }
		}
		#endregion
		#region public cDBMetadata_Updates Updates { get; }
		public cDBMetadata_Updates Updates {
			get { return updates_; }
		}
		#endregion
		//---
		#region public cDBMetadata_Table_Fields_PK Fields_onlyPK;
		private cDBMetadata_Table_Fields_PK fields_onlypk_;
		public cDBMetadata_Table_Fields_PK Fields_onlyPK {
			get { return fields_onlypk_; }
		}
		#endregion
		#region public cDBMetadata_Table_Fields_PK Fields_noPK;
		private cDBMetadata_Table_Fields_PK fields_nopk_;
		public cDBMetadata_Table_Fields_PK Fields_noPK {
			get { return fields_nopk_; }
		}
		#endregion
		#region public cDBMetadata_Table_Fields_FK Fields_onlyFK;
		private cDBMetadata_Table_Fields_FK fields_onlyfk_;
		public cDBMetadata_Table_Fields_FK Fields_onlyFK {
			get { return fields_onlyfk_; }
		}
		#endregion
		#region public cDBMetadata_Table_Fields_FK Fields_noFK;
		private cDBMetadata_Table_Fields_FK fields_nofk_;
		public cDBMetadata_Table_Fields_FK Fields_noFK {
			get { return fields_nofk_; }
		}
		#endregion
		#endregion

		#region Methods...
		#region public override string ToString();
		public override string ToString() {
			return Name;
		}
		#endregion
		#region public int hasIdentityKey();
		public int hasIdentityKey() {
			for (int f = 0; f < fields_.Count; f++)
				if (fields_[f].isIdentity)
					return f;

			return -1;
		}
		#endregion
		#region public bool canBeConfig();
		public bool canBeConfig() {
			bool canBeConfig_out = (
				!isConfig
				&&
				(hasIdentityKey() == -1)
				&&
				(fields_onlypk_.Count == 1)
				&&
				(fields_.Count >= 3)
			);
			if (canBeConfig_out) {
				int _numFields_thatCanBeName = 0;
				int _numFields_thatCanBeConfig = 0;
				int _numFields_thatCanBeType = 0;
				for (int f = 0; f < fields_.Count; f++) {
					if (fields_[f].canBeConfig_Name) _numFields_thatCanBeName++;
					if (fields_[f].canBeConfig_Config) _numFields_thatCanBeConfig++;
					if (fields_[f].canBeConfig_Type) _numFields_thatCanBeType++;
				}
				canBeConfig_out = (
					(_numFields_thatCanBeName == 1)
					&&
					(_numFields_thatCanBeConfig >= 1)
					&&
					(_numFields_thatCanBeType >= 1)
				);
			}
			return canBeConfig_out;
		}
		#endregion
		#region public int firstKey();
		public int firstKey() {
			for (int f = 0; f < fields_.Count; f++) {
				if (
					(fields_[f].isPK)
					// ||
					// (fields_[f].isIdentity)
				)
					return f;
			}

			return -1;
		}
		#endregion
		#region public bool isListItem(...);
		public bool isListItem() {
			for (int f = 0; f < fields_.Count; f++) {
				if (
					(fields_[f].isListItemText)
					||
					(fields_[f].isListItemValue)
				) {
					return true;
				}
			}
			return false;
		}
		#endregion
		#region public cDBMetadata_Table_Field ListItemValue { get; }
		public cDBMetadata_Table_Field ListItemValue {
			get {
				for (int f = 0; f < fields_.Count; f++) {
					if (fields_[f].isListItemValue) {
						return fields_[f];
					}
				}
				return null;
			}
		}
		#endregion
		#region public cDBMetadata_Table_Field ListItemText { get; }
		public cDBMetadata_Table_Field ListItemText {
			get {
				for (int f = 0; f < fields_.Count; f++) {
					if (fields_[f].isListItemText) {
						return fields_[f];
					}
				}
				return null;
			}
		}
		#endregion
		#endregion
	}
}
