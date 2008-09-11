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
	public class cDBMetadata_Table_Field_DB : cClaSSe {
		#region public cDBMetadata_Table_Field_DB(...);
		public cDBMetadata_Table_Field_DB(
			iClaSSe aggregateloopback_ref_in, 
			cDBMetadata_Table_Field_DBs parent_ref_in, 
			DBServerTypes dbServerType_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			DBServerType = dbServerType_in;
//			Size = 0;
			DBType_inDB_name = string.Empty;
			DBDescription = string.Empty;
			DBDefaultValue = string.Empty;
			DBCollationName = string.Empty;
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

		#region Properties - ClaSSe...
		#region public DBServerTypes DBServerType { get; set; }
		private DBServerTypes dbservertype_;
		public DBServerTypes DBServerType {
			get { return dbservertype_; }
			set { dbservertype_ = value; }
		}

		[ClaSSPropertyAttribute("dbServerType", ClaSSPropertyAttribute.eType.standard, true)]
		private string dbservertype_reflection {
			get { return dbservertype_.ToString(); }
			set { dbservertype_ = (DBServerTypes)Enum.Parse(typeof(DBServerTypes),value); }
		}
		#endregion
		//#region public int Size { get; set; }
		//private int size_;
		//public int Size {
		//    get { return size_; }
		//    set { size_ = value; }
		//}

		//[ClaSSPropertyAttribute("size", ClaSSPropertyAttribute.eType.standard, true)]
		//private string size_reflection {
		//    get { return size_.ToString(); }
		//    set { size_ = int.Parse(value); }
		//}
		//#endregion
		#region public string DBType_inDB_name { get; }
		private string DBType_indb_name_;

		[ClaSSPropertyAttribute("dbType", ClaSSPropertyAttribute.eType.standard, true)]
		public string DBType_inDB_name {
			set { DBType_indb_name_ = value; }
			get { return DBType_indb_name_; }
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
		#region public string DBDefaultValue { get; set; }
		private string dbdefaultvalue_;

		[ClaSSPropertyAttribute("dbDefaultValue", ClaSSPropertyAttribute.eType.standard, true)]
		public string DBDefaultValue {
			get { return dbdefaultvalue_; }
			set { dbdefaultvalue_ = value; }
		}
		#endregion
		#region public string DBCollationName { get; set; }
		private string dbcollationname_;

		[ClaSSPropertyAttribute("dbCollationName", ClaSSPropertyAttribute.eType.standard, true)]
		public string DBCollationName {
			get { return dbcollationname_; }
			set { dbcollationname_ = value; }
		}
		#endregion
		#endregion
		#region Properties...
		#region public cDBMetadata_Table_Field_DBs Parent_ref { get; }
		private cDBMetadata_Table_Field_DBs parent_ref_;
		public cDBMetadata_Table_Field_DBs Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		#region public cDBType DBType_generic { get; }
		public cDBType DBType_generic {
			get {
				cDBType DBType_generic_out = new cDBType(
//					dbservertype_
				);
				DBType_generic_out.Value =  DBUtilssupport.GetInstance(dbservertype_).Convert.XDbType2DbType(DBType_inDB);

				return DBType_generic_out;
			}
		}
		#endregion
		#region public int DBType_inDB { get; set; }
		public int DBType_inDB {
			get {
				//return int.Parse(base.Property_standard["type"));

				return DBUtilssupport.GetInstance(dbservertype_).Convert.XDbType_Parse(
					DBType_inDB_name, 
					false
				);
			}
		}
		#endregion
		#region public bool isBool { get; }
		public bool isBool {
			get {
				return DBUtils.isBool(DBType_generic.Value);
			}
		}
		#endregion
		#region public bool isDateTime { get; }
		public bool isDateTime {
			get {
				return DBUtils.isDateTime(DBType_generic.Value);
			}
		}
		#endregion
		#region public bool isInt { get; }
		public bool isInt {
			get {
				return DBUtils.isInt(DBType_generic.Value);
			}
		}
		#endregion
		#region public bool isDecimal { get; }
		public bool isDecimal {
			get {
				return DBUtils.isDecimal(DBType_generic.Value);
			}
		}
		#endregion
		#region public bool isText { get; }
		public bool isText {
			get {
				return DBUtils.isText(DBType_generic.Value);
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public string DBType_generic_DBEmptyValue();
		public string DBType_generic_DBEmptyValue() {
			return DBUtilssupport.GetInstance(dbservertype_).Convert.DBType2DBEmptyValue(
				DBType_generic.Value
			);
		}
		#endregion
		#endregion
	}
}
