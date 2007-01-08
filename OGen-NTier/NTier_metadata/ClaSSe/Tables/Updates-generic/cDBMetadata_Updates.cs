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
	public class cDBMetadata_Updates : cClaSSe {
		#region public cDBMetadata_Updates(...);
		public cDBMetadata_Updates(
			iClaSSe aggregateloopback_ref_in, 
			iDBMetadata_Tables parent_ref_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			updates_ = new ArrayList();
			//#endregion
		}
		#endregion

		#region Implementing - iClaSSe...
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "update":
					return new cDBMetadata_Update(
						this, 
						this, 
						string.Empty
					); // use any arguments you need
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
		#region private ArrayList updates_;
		private ArrayList updates_;

		[ClaSSPropertyAttribute("update", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList updates_reflection {
			get { return updates_; }
			set { updates_ = value; }
		}
		#endregion
		#endregion
		#region Properties...
		#region public iDBMetadata_Tables Parent_ref { get; }
		private iDBMetadata_Tables parent_ref_;
		public iDBMetadata_Tables Parent_ref {
			get { return this.parent_ref_; }
		}
		#endregion
		//---
		#region public int Count { get; }
		public int Count {
			get { return updates_.Count; }
		}
		#endregion
		#region public cDBMetadata_Update this[...] { get; }
		public cDBMetadata_Update this[int index_in] {
			get {
				return (cDBMetadata_Update)updates_[index_in];
			}
		}
		public cDBMetadata_Update this[string name_in] {
			get {
				int _ti = Search(name_in);
				return (_ti >= 0) ? 
					(cDBMetadata_Update)updates_[_ti] : 
					null;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void CopyFrom(...);
		public void CopyFrom(cDBMetadata_Updates updates_in) {
			int _table;
			int _field;
			int _updateparameter;

			for (int u = 0; u < updates_in.Count; u++) {
				int _update = this.Add(
					updates_in[u].Name,
					false
				);
				for (int f = 0; f < updates_in[u].UpdateParameters.Count; f++) {
					_table = parent_ref_.Search(
						updates_in[u].UpdateParameters[f].TableName
					);
					if (_table == -1) throw new Exception(); // ToDos: here!

					_field = parent_ref_[_table].Fields.Search(
						updates_in[u].UpdateParameters[f].FieldName
					);
					if (_field == -1) throw new Exception(); // ToDos: here!

					_updateparameter 
						= this[_update].UpdateParameters.Add(
							_table,
							_field,
							true
						);

					this[_update].UpdateParameters[_updateparameter].ParamName 
						= updates_in[u].UpdateParameters[f].ParamName;
				}
			}
		}
		#endregion
		#region public void Clear(...);
		public void Clear() {
			updates_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(string name_in, bool verifyExistenz_in) {
			int _ti;

			if (verifyExistenz_in) {
				_ti = Search(name_in);
				if (_ti != -1)
					return _ti;
			}

			_ti = updates_.Add(
				new cDBMetadata_Update(
					this, 
					this, 
					name_in
				)
			);
			return _ti; // returns it's position
		}
		#endregion
		#region public int Search(...);
		public int Search(string name_in) {
			for (int t = 0; t < updates_.Count; t++)
				if (((cDBMetadata_Update)updates_[t]).Name == name_in) // already exists!
					return t; // returns it's position

			return -1;
		}
		#endregion
		#endregion
	}
}