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
using System.Data;
#if PostgreSQL
using NpgsqlTypes;
#endif
#if MySQL
using MySql.Data.MySqlClient;
#endif

using OGen.lib.datalayer;
using OGen.lib.collections;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Table_Field : cClaSSe {
		#region public cDBMetadata_Table_Field(...);
		public cDBMetadata_Table_Field(
			iClaSSe aggregateloopback_ref_in, 
			iDBMetadata_Table_Fields parent_ref_in, 
			string name_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			Name = name_in;
			isPK = false;
			isIdentity = false;
			FriendlyName = string.Empty;
			ExtendedDescription = string.Empty;
			AditionalInfo = string.Empty;
			DefaultValue = string.Empty;
			isListItemValue = false;
			isListItemText = false;
			isConfig_Name = false;
			isConfig_Config = false;
			isConfig_Datatype = false;
			FK_TableName = string.Empty;
			FK_FieldName = string.Empty;
			isNullable = false;
			Size = 0;
			Numeric_Precision = 0;
			Numeric_Scale = 0;
//			DBType_inDB_name = string.Empty;
			//---
			dbs_ = new cDBMetadata_Table_Field_DBs(this, this);
			//#endregion
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

		//#region Properties - ClaSSe...
		#region public string Name { get; set; }
		private string name_;

		[ClaSSPropertyAttribute("name", ClaSSPropertyAttribute.eType.standard, true)]
		public string Name {
			get { return name_; }
			set { name_ = value; }
		}
		#endregion
		#region public bool isPK { get; set; }
		private bool ispk_;
		public bool isPK {
			get { return ispk_; }
			set { ispk_ = value; }
		}

		[ClaSSPropertyAttribute("isPK", ClaSSPropertyAttribute.eType.standard, true)]
		private string ispk_reflection {
			get { return ispk_.ToString(); }
			set { ispk_ = bool.Parse(value); }
		}
		#endregion
//		#region public bool isIdentity { get; set; }
		private bool isidentity_;
		public bool isIdentity {
			get { 
				return isidentity_;
			}
			set { isidentity_ = value; }
		}

		[ClaSSPropertyAttribute("isIdentity", ClaSSPropertyAttribute.eType.standard, true)]
		private string isIdentity_reflection {
			get { return isidentity_.ToString(); }
			set { isidentity_ = bool.Parse(value); }
		}
//		#endregion
		#region public string DefaultValue { get; set; }
		private string defaultvalue_;

		[ClaSSPropertyAttribute("defaultValue", ClaSSPropertyAttribute.eType.standard, true)]
		public string DefaultValue {
			get { return defaultvalue_; }
			set { defaultvalue_ = value; }
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
		#region public string ExtendedDescription { get; set; }
		private string extendeddescription_;

		[ClaSSPropertyAttribute("extendedDescription", ClaSSPropertyAttribute.eType.standard, true)]
		public string ExtendedDescription {
			get { return extendeddescription_; }
			set { extendeddescription_ = value; }
		}
		#endregion
		#region public bool isListItemValue { get; set; }
		private bool islistitemvalue_;
		public bool isListItemValue {
			get { return islistitemvalue_; }
			set { islistitemvalue_ = value; }
		}

		[ClaSSPropertyAttribute("isListItemValue", ClaSSPropertyAttribute.eType.standard, true)]
		private string islistitemvalue_reflection {
			get { return islistitemvalue_.ToString(); }
			set { islistitemvalue_ = bool.Parse(value); }
		}
		#endregion
		#region public bool isListItemText { get; set; }
		private bool islistitemtext_;
		public bool isListItemText {
			get { return islistitemtext_; }
			set { islistitemtext_ = value; }
		}

		[ClaSSPropertyAttribute("isListItemText", ClaSSPropertyAttribute.eType.standard, true)]
		private string isListItemText_reflection {
			get { return islistitemtext_.ToString(); }
			set { islistitemtext_ = bool.Parse(value); }
		}
		#endregion
		#region public bool isConfig_Name { get; set; }
		private bool isconfig_name__;
		public bool isConfig_Name {
			get { return isconfig_name__; }
			set {
				if (value && !canBeConfig_Name)
					throw new Exception(string.Format("{0}.{1}.isConfig_Name(): - field can't be Config-Name", this.GetType().Namespace, this.GetType().Name));

				isconfig_name__ = value;
			}
		}

		[ClaSSPropertyAttribute("isConfig_Name", ClaSSPropertyAttribute.eType.standard, true)]
		private string isconfig_name_reflection {
			get { return isconfig_name__.ToString(); }
			set { isconfig_name__ = bool.Parse(value); }
		}
		#endregion
		#region public bool isConfig_Config { get; set; }
		private bool isconfig_config__;
		public bool isConfig_Config {
			get { return isconfig_config__; }
			set {
				if (value && !canBeConfig_Config)
					throw new Exception(string.Format("{0}.{1}.isConfig_Config(): - field can't be Config-Config", this.GetType().Namespace, this.GetType().Name));

				isconfig_config__ = value;
			}
		}

		[ClaSSPropertyAttribute("isConfig_Config", ClaSSPropertyAttribute.eType.standard, true)]
		private string isconfig_config_reflection {
			get { return isconfig_config__.ToString(); }
			set { isconfig_config__ = bool.Parse(value); }
		}
		#endregion
		#region public bool isConfig_Datatype { get; set; }
		private bool isconfig_datatype__;
		public bool isConfig_Datatype {
			get { return isconfig_datatype__; }
			set {
				if (value && !canBeConfig_Type)
					throw new Exception(string.Format("{0}.{1}.isConfig_Type(): - field can't be Config-Type", this.GetType().Namespace, this.GetType().Name));

				isconfig_datatype__ = value;
			}
		}

		[ClaSSPropertyAttribute("isConfig_Datatype", ClaSSPropertyAttribute.eType.standard, true)]
		private string isconfig_datatype_reflection {
			get { return isconfig_datatype__.ToString(); }
			set { isconfig_datatype__ = bool.Parse(value); }
		}
		#endregion
		#region public string FK_TableName { get; }
		private string fk_tablename_;

		[ClaSSPropertyAttribute("fkTableName", ClaSSPropertyAttribute.eType.standard, true)]
		public string FK_TableName {
			get { return fk_tablename_; }
			set { fk_tablename_ = value; }
		}
		#endregion
		#region public string FK_FieldName { get; }
		private string fk_fieldname_;

		[ClaSSPropertyAttribute("fkFieldName", ClaSSPropertyAttribute.eType.standard, true)]
		public string FK_FieldName {
			get { return fk_fieldname_; }
			set { fk_fieldname_ = value; }
		}
		#endregion
		#region public bool isNullable { get; set; }
		private bool isnullable_;
		public bool isNullable {
			get { return isnullable_; }
			set { isnullable_ = value; }
		}

		[ClaSSPropertyAttribute("isNullable", ClaSSPropertyAttribute.eType.standard, true)]
		private string isnullable_reflection {
			get { return isnullable_.ToString(); }
			set { isnullable_ = bool.Parse(value); }
		}
		#endregion
		#region public int Size { get; set; }
		private int size_;
		public int Size {
			get { return size_; }
			set { size_ = value; }
		}

		[ClaSSPropertyAttribute("size", ClaSSPropertyAttribute.eType.standard, true)]
		private string size_reflection {
			get { return size_.ToString(); }
			set { size_ = int.Parse(value); }
		}
		#endregion
		#region public string AditionalInfo { get; set; }
		private string aditionalinfo_;

		[ClaSSPropertyAttribute("aditionalInfo", ClaSSPropertyAttribute.eType.standard, true)]
		public string AditionalInfo {
			get { return aditionalinfo_; }
			set { aditionalinfo_ = value; }
		}
		#endregion
		#region public int Numeric_Precision { get; set; }
		private int numeric_precision_;
		public int Numeric_Precision {
			get { return numeric_precision_; }
			set { numeric_precision_ = value; }
		}

		[ClaSSPropertyAttribute("numericPrecision", ClaSSPropertyAttribute.eType.standard, true)]
		private string numeric_precision_reflection {
			get { return numeric_precision_.ToString(); }
			set { numeric_precision_ = int.Parse(value); }
		}
		#endregion
		#region public int Numeric_Scale { get; set; }
		private int numeric_scale_;
		public int Numeric_Scale {
			get { return numeric_scale_; }
			set { numeric_scale_ = value; }
		}

		[ClaSSPropertyAttribute("numericScale", ClaSSPropertyAttribute.eType.standard, true)]
		private string numeric_scale_reflection {
			get { return numeric_scale_.ToString(); }
			set { numeric_scale_ = int.Parse(value); }
		}
		#endregion
//		#region public string DBType_inDB_name { get; }
//		private string dbtype_indb_name_;
//
//		[ClaSSPropertyAttribute("type", ClaSSPropertyAttribute.eType.standard, true)]
//		public string DBType_inDB_name {
//			set { dbtype_indb_name_ = value; }
//			get { return dbtype_indb_name_; }
//		}
//		#endregion
		//---
		#region private cDBMetadata_Table_Field_DBs dbs_ { get; set; }
		private cDBMetadata_Table_Field_DBs dbs_;

		[ClaSSPropertyAttribute("dbs", ClaSSPropertyAttribute.eType.aggregate, true)]
		private cDBMetadata_Table_Field_DBs dbs_reflection {
			get { return dbs_; }
			//set { fields_ = value; }
		}
		#endregion
		//#endregion
//		#region Properties...
		#region public iDBMetadata_Table_Fields Parent_ref { get; }
		private iDBMetadata_Table_Fields parent_ref_;
		public iDBMetadata_Table_Fields Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		//---
		#region public cDBMetadata_Table_Field_DBs DBs { get; }
		public cDBMetadata_Table_Field_DBs DBs {
			get { return dbs_; }
		}
		#endregion
		//---
		#region public cDBType DBType_generic { get; }
		public cDBType DBType_generic {
			get {
				return DBs[0].DBType_generic;
				#region //oldstuff...
//				cDBType dbtype_generic_out = new cDBType(parent_ref_.Parent_ref.Parent_ref.Parent_ref.default_dbservertype_);
//				switch (parent_ref_.Parent_ref.Parent_ref.Parent_ref.default_dbservertype_) {
//					case DBServerTypes.SQLServer:
//						dbtype_generic_out.Value = OGen.lib.datalayer.utils.convert.SqlDbType2DbType((SqlDbType)DBType_inDB);
//						break;
//					case DBServerTypes.PostgreSQL:
//						dbtype_generic_out.Value = OGen.lib.datalayer.utils.convert.PgsqlDbType2DbType((NpgsqlDbType)DBType_inDB);
//						break;
//					case DBServerTypes.MySQL:
//						dbtype_generic_out.Value = OGen.lib.datalayer.utils.convert.MySqlDbType2DbType((MySqlDbType)DBType_inDB);
//						break;
//					default:
//						throw new Exception(
//							string.Format(
//								"{0}.{1}.DBType_generic.get(): - unsoported db server: {2}", 
//								this.GetType().Namespace, 
//								this.GetType().Name,
//								parent_ref_.Parent_ref.Parent_ref.Parent_ref.default_dbservertype_
//							)
//						);
//				}
//
//				return dbtype_generic_out;
				#endregion
			}
		}
		#endregion
//		#region public int DBType_inDB { get; set; }
//		public int DBType_inDB {
//			get {
//				//return int.Parse(base.Property_standard["type"));
//
//				switch (parent_ref_.Parent_ref.Parent_ref.Parent_ref.default_dbservertype_) {
//					case DBServerTypes.SQLServer:
//						return (int)OGen.lib.datalayer.utils.convert.SqlDbType_Parse(
//							//base.Property_standard["type"], 
//							DBType_inDB_name, 
//							false
//						);
//					case DBServerTypes.PostgreSQL:
//						return (int)OGen.lib.datalayer.utils.convert.PgsqlDbType_Parse(
//							//base.Property_standard["type"], 
//							DBType_inDB_name
//						);
//					case DBServerTypes.MySQL:
//						return (int)OGen.lib.datalayer.utils.convert.MySqlDbType_Parse(
//							//base.Property_standard["type"], 
//							DBType_inDB_name
//						);
//					default:
//						throw new Exception(
//							string.Format(
//								"{0}.{1}.DBType_inDB.get(): - unsoported db server: {2}", 
//								this.GetType().Namespace, 
//								this.GetType().Name,
//								parent_ref_.Parent_ref.Parent_ref.Parent_ref.default_dbservertype_
//							)
//						);
//				}
//			}
//		}
//		#endregion
		#region public bool isBool { get; }
		public bool isBool {
			get {
//				return OGen.lib.datalayer.utils.isBool(DBType_generic.Value);
				return DBs[0].isBool;
			}
		}
		#endregion
		#region public bool isDateTime { get; }
		public bool isDateTime {
			get {
//				return OGen.lib.datalayer.utils.isDateTime(DBType_generic.Value);
				return DBs[0].isDateTime;
			}
		}
		#endregion
		#region public bool isInt { get; }
		public bool isInt {
			get {
//				return OGen.lib.datalayer.utils.isInt(DBType_generic.Value);
				return DBs[0].isInt;
			}
		}
		#endregion
		#region public bool isDecimal { get; }
		public bool isDecimal {
			get {
//				return OGen.lib.datalayer.utils.isDecimal(DBType_generic.Value);
				return DBs[0].isDecimal;
			}
		}
		#endregion
		#region public bool isText { get; }
		public bool isText {
			get {
//				return OGen.lib.datalayer.utils.isText(DBType_generic.Value);
				return DBs[0].isText;
			}
		}
		#endregion
		#region public cDBMetadata_Field_ref FK { get; }
		public cDBMetadata_Field_ref FK {
			get {
				int _t = parent_ref_.Parent_ref.Parent_ref.Parent_ref.Tables.Search(FK_TableName);
				if (_t != -1) {
					int _f = Parent_ref.Parent_ref.Parent_ref.Parent_ref.Tables[_t].Fields.Search(FK_FieldName);
					if (_f != -1) {
						return new cDBMetadata_Field_ref(
// ToDos: here! check this...
parent_ref_.Parent_ref.Parent_ref, 
							parent_ref_.Parent_ref.Parent_ref, 
							_t, 
							_f
						);
					}
				}
				return new cDBMetadata_Field_ref(
// ToDos: here! check this...
parent_ref_.Parent_ref.Parent_ref, 
					parent_ref_.Parent_ref.Parent_ref, 
					-1, 
					-1
				);
			}
		}
		#endregion
		#region public bool canBeConfig_... { get; }
		public bool canBeConfig_Name {
			get { return isText && isPK; }
		}
		public bool canBeConfig_Config {
			get { return isText && !isPK; }
		}
		public bool canBeConfig_Type {
			get { return isInt && !isPK; }
		}
		#endregion
//		#endregion

		#region Methods...
		#region public string DBType_generic_DBEmptyValue(DBServerTypes dbServerType_in);
		public string DBType_generic_DBEmptyValue(DBServerTypes dbServerType_in) {
			return DBUtilssupport.GetInstance(dbServerType_in).Convert.DBType2DBEmptyValue(DBs[0].DBType_generic.Value);
		}
		#endregion
		#region public override string ToString();
		public override string ToString() {
			return Name;
		}
		#endregion
		#endregion
	}
}
