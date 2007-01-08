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
using System.Collections;

using OGen.lib.datalayer;
using OGen.lib.collections;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Table_DBs : cClaSSe {
		#region public cDBMetadata_Table_DBs(...);
		public cDBMetadata_Table_DBs(
			iClaSSe aggregateloopback_ref_in, 
			cDBMetadata_Table parent_ref_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			db_ = new ArrayList();
			//#endregion
		}
		#endregion

		#region Implementing - iClaSSe...
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "db":
					return new cDBMetadata_Table_DB(
						this, 
						this, 
						eDBServerTypes.invalid, 
						string.Empty
					);
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
		#region private ArrayList db_ { get; set; }
		private ArrayList db_;

		[ClaSSPropertyAttribute("db", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList db_reflection {
			get { return db_; }
			set { db_ = value; }
		}
		#endregion
		#endregion
		#region Properties...
		#region public cDBMetadata_Table Parent_ref;
		private cDBMetadata_Table parent_ref_;
		public cDBMetadata_Table Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return db_.Count; }
		}
		#endregion
		#region public cDBMetadata_Table_DB this[int index_in] { get; }
		public cDBMetadata_Table_DB this[int index_in] {
			get {
				return (cDBMetadata_Table_DB)db_[index_in];
			}
		}
		#endregion
		#region public cDBMetadata_Table_DB this[eDBServerTypes dbServerType_in] { get; }
		public cDBMetadata_Table_DB this[eDBServerTypes dbServerType_in] {
			get {
				int _fi = Search(dbServerType_in);
				return (_fi >= 0) ? 
					(cDBMetadata_Table_DB)db_[_fi] : 
					null;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void Clear(...);
		public void Clear() {
			db_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(eDBServerTypes dbServerType_in, string tableName_in, bool verifyExistenz_in) {
			int _fi;

			if (verifyExistenz_in) {
				_fi = Search(dbServerType_in);
				if (_fi != -1)
					return _fi;
			}

			_fi = db_.Add(
				new cDBMetadata_Table_DB(
					this, 
					this, 
					dbServerType_in, 
					tableName_in
				)
			);
			return _fi; // returns it's position
		}
		#endregion
		#region public int Search(...)
		public int Search(eDBServerTypes dbServerType_in) {
			for (int f = 0; f < db_.Count; f++)
				if (((cDBMetadata_Table_DB)db_[f]).DBServerType == dbServerType_in) // already exists!
					return f; // returns it's position

			return -1;
		}
		#endregion
		#endregion
	}
}