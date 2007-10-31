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

using OGen.lib.datalayer;
using OGen.lib.collections;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Table_Field_DBs : cClaSSe {
		#region public cDBMetadata_Table_Field_DBs(...);
		public cDBMetadata_Table_Field_DBs(
			iClaSSe aggregateloopback_ref_in, 
			cDBMetadata_Table_Field parent_ref_in
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
		public override string root4xml {
			get {
				return cDBMetadata.ROOT;
			}
		}
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "db":
					return new cDBMetadata_Table_Field_DB(
						this, 
						this, 
						DBServerTypes.invalid
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
		#region public cDBMetadata_Table_Field Parent_ref;
		private cDBMetadata_Table_Field parent_ref_;
		public cDBMetadata_Table_Field Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return db_.Count; }
		}
		#endregion
		#region public cDBMetadata_Table_Field_DB this[int index_in] { get; }
		public cDBMetadata_Table_Field_DB this[int index_in] {
			get {
				return (cDBMetadata_Table_Field_DB)db_[index_in];
			}
		}
		#endregion
		#region public cDBMetadata_Table_Field_DB this[DBServerTypes dbServerType_in] { get; }
		public cDBMetadata_Table_Field_DB this[DBServerTypes dbServerType_in] {
			get {
				int _fi = Search(dbServerType_in);
				return (_fi >= 0) ? 
					(cDBMetadata_Table_Field_DB)db_[_fi] : 
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
		public int Add(DBServerTypes dbServerType_in, bool verifyExistenz_in) {
			int _fi;

			if (verifyExistenz_in) {
				_fi = Search(dbServerType_in);
				if (_fi != -1)
					return _fi;
			}

			_fi = db_.Add(
				new cDBMetadata_Table_Field_DB(
					this, 
					this, 
					dbServerType_in
				)
			);
			return _fi; // returns it's position
		}
		#endregion
		#region public int Search(...)
		public int Search(DBServerTypes dbServerType_in) {
			for (int f = 0; f < db_.Count; f++)
				if (((cDBMetadata_Table_Field_DB)db_[f]).DBServerType == dbServerType_in) // already exists!
					return f; // returns it's position

			return -1;
		}
		#endregion
		#endregion
	}
}
