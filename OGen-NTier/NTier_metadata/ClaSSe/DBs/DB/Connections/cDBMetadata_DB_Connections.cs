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