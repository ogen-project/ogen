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
	public class cDBMetadata_Table_DB : cClaSSe {
		#region public cDBMetadata_Table_DB(...);
		public cDBMetadata_Table_DB(
			iClaSSe aggregateloopback_ref_in, 
			cDBMetadata_Table_DBs parent_ref_in, 
			eDBServerTypes dbServerType_in, 
			string tableName_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			DBServerType = dbServerType_in;
			TableName = tableName_in;
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
		#region public string TableName { get; }
		private string tablename_;

		[ClaSSPropertyAttribute("tableName", ClaSSPropertyAttribute.eType.standard, true)]
		public string TableName {
			set { tablename_ = value; }
			get { return tablename_; }
		}
		#endregion
		#endregion
		#region Properties...
		#region public cDBMetadata_Table_DBs Parent_ref { get; }
		private cDBMetadata_Table_DBs parent_ref_;
		public cDBMetadata_Table_DBs Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		#endregion

		#region Methods...
		#endregion
	}
}