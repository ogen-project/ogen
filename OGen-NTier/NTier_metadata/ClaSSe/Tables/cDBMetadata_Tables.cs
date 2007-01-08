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

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Tables : cClaSSe, iDBMetadata_Tables {
		#region public cDBMetadata_Tables(...);
		public cDBMetadata_Tables(
			iClaSSe aggregateloopback_ref_in, 
			cDBMetadata parent_ref_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			tables_ = new ArrayList();
			//#endregion
		}
		#endregion

		#region Implementing - iClaSSe...
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "table":
					return new cDBMetadata_Table(this, this, "");
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
		#region private ArrayList tables_;
		private ArrayList tables_;

		[ClaSSPropertyAttribute("table", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList tables_reflection {
			get { return tables_; }
			set { tables_ = value; }
		}
		#endregion
		#endregion
		#region Properties...
		#region public cDBMetadata Parent_ref;
		private cDBMetadata parent_ref_;
		public cDBMetadata Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		//---
		#region public int Count { get; }
		public int Count {
			get { return tables_.Count; }
		}
		#endregion
		#region public new cDBMetadata_Table this[int index_in];
		public cDBMetadata_Table this[int index_in] {
			get {
				return (cDBMetadata_Table)tables_[index_in];
			}
		}
		#endregion
		#region public cDBMetadata_Table this[string name_in];
		public cDBMetadata_Table this[string name_in] {
			get {
				int _ti = Search(name_in);
				return (_ti >= 0) ?
					(cDBMetadata_Table)tables_[_ti] :
					null;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void Clear();
		public void Clear() {
			tables_.Clear();
		}
		#endregion
		#region public int Add(string name_in, bool verifyExistenz_in)
		public int Add(string name_in, bool verifyExistenz_in) {
			int _ti;

			if (verifyExistenz_in) {
				_ti = Search(name_in);
				if (_ti != -1)
					return _ti;
			}

			_ti = tables_.Add(new cDBMetadata_Table(this, this, name_in));
			//((cDBMetadata_Table)tables[_ti]).Name = Name_;
			return _ti; // returns it's position
		}
		#endregion
		#region public int Search(string name_in)
		public int Search(string name_in) {
			for (int t = 0; t < tables_.Count; t++)
				if (((cDBMetadata_Table)tables_[t]).Name == name_in) // already exists!
					return t; // returns it's position

			return -1;
		}
		#endregion
		#region public bool hasVirtualTable_withUndefinedKeys();
		public bool hasVirtualTable_withUndefinedKeys() {
			bool hasUndefinedKeys_out = false;
			for (int t = 0; t < tables_.Count; t++) {
				if (((cDBMetadata_Table)tables_[t]).isVirtualTable) {
					if (((cDBMetadata_Table)tables_[t]).Fields_onlyPK.Count == 0) {
						hasUndefinedKeys_out = true;
						break;
					}
				}
			}
			return hasUndefinedKeys_out;
		}
		#endregion
		#region public bool hasConfigTable();
		public bool hasConfigTable() {
			bool hasConfigTable_out = false;
			for (int t = 0; t < tables_.Count; t++) {
				if (((cDBMetadata_Table)tables_[t]).isConfig) {
					hasConfigTable_out = true;
					break;
				}
			}
			return hasConfigTable_out;
		}
		#endregion
		#endregion
	}
}