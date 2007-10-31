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
using OGen.lib.datalayer;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_DB_Connections : cClaSSe {
		#region public cDBMetadata_DB_Connections(...);
		public cDBMetadata_DB_Connections(
			iClaSSe aggregateloopback_ref_in
		) : base(
			aggregateloopback_ref_in
		) {
			//#region ClaSSe...
			connections_ = new ArrayList();
			//#endregion
		}
		#endregion

		#region Implementing - iClaSSe...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "connection":
					return new cDBMetadata_DB_Connection(this, false, string.Empty);
				default:
					throw new Exception(string.Format(
						"{0}.{1}.Property_new(): - invalid Name: {2}",
						this.GetType().Namespace,
						this.GetType().Name,
						name_in
					));
			}
		}
		#endregion
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
		public override string root4xml {
			get {
				return cDBMetadata.ROOT;
			}
		}
		#region private ArrayList connections_ { get; set; }
		private ArrayList connections_;

		[ClaSSPropertyAttribute("connection", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList connections_reflection {
			get { return connections_; }
			set { connections_ = value; }
		}
		#endregion
		#endregion
		#region Properties...
		//#region public cDBMetadata Root_ref;
		//private cDBMetadata root_ref_;
		//public cDBMetadata Root_ref {
		//    get { return root_ref_; }
		//}
		//#endregion
		//---
		#region public int Count { get; }
		public int Count {
			get { return connections_.Count; }
		}
		#endregion
		#region public new cDBMetadata_DB_Connection this[...];
		public cDBMetadata_DB_Connection this[int index_in] {
			get {
				return (cDBMetadata_DB_Connection)connections_[index_in];
			}
		}
		public cDBMetadata_DB_Connection this[string configMode_in] {
			get {
				int _ti = Search(configMode_in);
				return (_ti >= 0) ?
					(cDBMetadata_DB_Connection)connections_[_ti] :
					null;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void Clear(...);
		public void Clear() {
			connections_.Clear();
		}
		#endregion
		#region public int Add(...)
		public int Add(bool generateSQL_in, string configMode_in, bool verifyExistenz_in) {
			int _ti;

			if (verifyExistenz_in) {
				_ti = Search(configMode_in);
				if (_ti != -1)
					return _ti;
			}

			_ti = connections_.Add(
				new cDBMetadata_DB_Connection(
					this, 
					generateSQL_in, 
					configMode_in
				)
			);
			return _ti; // returns it's position
		}
		#endregion
		#region public int Search(...)
		public int Search(string configMode_in) {
			for (int t = 0; t < connections_.Count; t++)
				if (((cDBMetadata_DB_Connection)connections_[t]).ConfigMode == configMode_in) // already exists!
					return t; // returns it's position

			return -1;
		}
		#endregion
		#region public void CopyFrom(cDBMetadata_DB_Connections dbMetadata_DB_Connections_in);
		public void CopyFrom(cDBMetadata_DB_Connections dbMetadata_DB_Connections_in) {
			Clear();

			int _justadded;
			for (int c = 0; c < dbMetadata_DB_Connections_in.Count; c++) {
				_justadded = Add(
					dbMetadata_DB_Connections_in[c].GenerateSQL,
					dbMetadata_DB_Connections_in[c].ConfigMode,
					true
				);
				this[_justadded].CopyFrom(dbMetadata_DB_Connections_in[c]);
			}
		}
		#endregion
		#endregion
	}
}
