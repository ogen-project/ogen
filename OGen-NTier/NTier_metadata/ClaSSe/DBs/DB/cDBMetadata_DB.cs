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
	public class cDBMetadata_DB : cClaSSe {
		#region public cDBMetadata_DB(...);
		public cDBMetadata_DB(
			iClaSSe aggregateloopback_ref_in, 
			DBServerTypes dbServerType_in
		) : base (
			aggregateloopback_ref_in
		) {
			//#region ClaSSe...
			DBServerType = dbServerType_in;
			//---
			connections_ = new cDBMetadata_DB_Connections(this);
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
		public override string root4xml {
			get {
				return cDBMetadata.ROOT;
			}
		}
		#region public DBServerTypes DBServerType { get; set; }
		private DBServerTypes dbservertype_;
		public DBServerTypes DBServerType {
			get { return dbservertype_; }
			set { dbservertype_ = value; }
		}

		[ClaSSPropertyAttribute("dbServerType", ClaSSPropertyAttribute.eType.standard, true)]
		private string dbservertype_reflection {
			get { return dbservertype_.ToString(); }
			set { dbservertype_ = (DBServerTypes)Enum.Parse(typeof(DBServerTypes), value); }
		}
		#endregion
		//---
		#region private cDBMetadata_DB_Connections connections_ { get; set; }
		private cDBMetadata_DB_Connections connections_;

		[ClaSSPropertyAttribute("connections", ClaSSPropertyAttribute.eType.aggregate, true)]
		public cDBMetadata_DB_Connections Connections {
			get { return connections_; }
		}
		#endregion
		#endregion
		#region Properties...
		#endregion

		#region Methods...
		public void CopyFrom(cDBMetadata_DB dbMetadata_DB_in) {
			dbservertype_ = dbMetadata_DB_in.dbservertype_;
			connections_.CopyFrom(dbMetadata_DB_in.connections_);
		}
		#region public override string ToString();
		public override string ToString() {
			throw new Exception("//ToDos: here!");
		}
		#endregion
		#endregion
	}
}
