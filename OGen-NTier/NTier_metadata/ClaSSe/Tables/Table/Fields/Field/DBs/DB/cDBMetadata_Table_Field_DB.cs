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
using System.Reflection;
using System.Data;
using NpgsqlTypes;
using MySql.Data.MySqlClient;

using OGen.lib.datalayer;
using OGen.lib.collections;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Table_Field_DB : cClaSSe {
		#region public cDBMetadata_Table_Field_DB(...);
		public cDBMetadata_Table_Field_DB(
			iClaSSe aggregateloopback_ref_in, 
			cDBMetadata_Table_Field_DBs parent_ref_in, 
			eDBServerTypes dbServerType_in
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
		#region public eDBServerTypes DBServerType { get; set; }
		private eDBServerTypes dbservertype_;
		public eDBServerTypes DBServerType {
			get { return dbservertype_; }
			set { dbservertype_ = value; }
		}

		[ClaSSPropertyAttribute("dbServerType", ClaSSPropertyAttribute.eType.standard, true)]
		private string dbservertype_reflection {
			get { return dbservertype_.ToString(); }
			set { dbservertype_ = OGen.lib.datalayer.utils.DBServerTypes.convert.FromName(value); }
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
				switch (dbservertype_) {
					case eDBServerTypes.SQLServer:
						DBType_generic_out.Value = OGen.lib.datalayer.utils.convert.SqlDbType2DbType((SqlDbType)DBType_inDB);
						break;
					case eDBServerTypes.PostgreSQL:
						DBType_generic_out.Value = OGen.lib.datalayer.utils.convert.PgsqlDbType2DbType((NpgsqlDbType)DBType_inDB);
						break;
					case eDBServerTypes.MySQL:
						DBType_generic_out.Value = OGen.lib.datalayer.utils.convert.MySqlDbType2DbType((MySqlDbType)DBType_inDB);
						break;
					default:
						throw new Exception(
							string.Format(
								"{0}.{1}.DBType_generic.get(): - unsoported db server: {2}", 
								this.GetType().Namespace, 
								this.GetType().Name,
								dbservertype_
							)
						);
				}

				return DBType_generic_out;
			}
		}
		#endregion
		#region public int DBType_inDB { get; set; }
		public int DBType_inDB {
			get {
				//return int.Parse(base.Property_standard["type"));

				switch (dbservertype_) {
					case eDBServerTypes.SQLServer:
						return (int)OGen.lib.datalayer.utils.convert.SqlDbType_Parse(
							//base.Property_standard["type"], 
							DBType_inDB_name, 
							false
						);
					case eDBServerTypes.PostgreSQL:
						return (int)OGen.lib.datalayer.utils.convert.PgsqlDbType_Parse(
							//base.Property_standard["type"], 
							DBType_inDB_name
						);
					case eDBServerTypes.MySQL:
						return (int)OGen.lib.datalayer.utils.convert.MySqlDbType_Parse(
							//base.Property_standard["type"], 
							DBType_inDB_name
						);
					default:
						throw new Exception(
							string.Format(
								"{0}.{1}.DBType_inDB.get(): - unsoported db server: {2}", 
								this.GetType().Namespace, 
								this.GetType().Name,
								dbservertype_
							)
						);
				}
			}
		}
		#endregion
		#region public bool isBool { get; }
		public bool isBool {
			get {
				return OGen.lib.datalayer.utils.isBool(DBType_generic.Value);
			}
		}
		#endregion
		#region public bool isDateTime { get; }
		public bool isDateTime {
			get {
				return OGen.lib.datalayer.utils.isDateTime(DBType_generic.Value);
			}
		}
		#endregion
		#region public bool isInt { get; }
		public bool isInt {
			get {
				return OGen.lib.datalayer.utils.isInt(DBType_generic.Value);
			}
		}
		#endregion
		#region public bool isDecimal { get; }
		public bool isDecimal {
			get {
				return OGen.lib.datalayer.utils.isDecimal(DBType_generic.Value);
			}
		}
		#endregion
		#region public bool isText { get; }
		public bool isText {
			get {
				return OGen.lib.datalayer.utils.isText(DBType_generic.Value);
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public string DBType_generic_DBEmptyValue();
		public string DBType_generic_DBEmptyValue() {
			return OGen.lib.datalayer.utils.convert.DBType2DBEmptyValue(DBType_generic.Value, dbservertype_);
		}
		#endregion
		#endregion
	}
}