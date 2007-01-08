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
	public class cDBMetadata_Table_Searches : cClaSSe, iDBMetadata_Table_Searches {
		#region public cDBMetadata_Table_Searches(...);
		public cDBMetadata_Table_Searches(
			iClaSSe aggregateloopback_ref_in, 
			cDBMetadata_Table parent_ref_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			search_ = new ArrayList();	// base.Property_aggregate_collection["search", new ArrayList());
			//#endregion
		}
		#endregion

		#region Implementing - iClaSSe...
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "search":
					return new cDBMetadata_Table_Search(
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

//		#region Properties - ClaSSe...
		#region private ArrayList search_ { get; set; }
		private ArrayList search_;

		[ClaSSPropertyAttribute("search", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList search_reflection {
			get { return search_; }
			set { search_ = value; }
		}
		#endregion
//		#region private string hasexplicituniqueindex__ { get; }
		[ClaSSPropertyAttribute("hasExplicitUniqueIndex", ClaSSPropertyAttribute.eType.standard, false)]
		private string hasexplicituniqueindex__ {
			get { return hasExplicitUniqueIndex().ToString(); }
		}
//		#endregion
//		#endregion
		#region Properties...
		#region public cDBMetadata_Table Parent_ref;
		private cDBMetadata_Table parent_ref_;
		public cDBMetadata_Table Parent_ref {
			get { return this.parent_ref_; }
		}
		#endregion
		//---
		#region public int Count { get; }
		public int Count {
			get { return search_.Count; }
		}
		#endregion
		#region public cDBMetadata_Table_Search this[int index_in] { get; }
		public cDBMetadata_Table_Search this[int index_in] {
			get { return (cDBMetadata_Table_Search)search_[index_in]; }
		}
		#endregion
		#region public cDBMetadata_Table_Search this[string name_in] { get; }
		public cDBMetadata_Table_Search this[string name_in] {
			get {
				int _ti = Search(name_in);
				return (_ti >= 0) ? 
					(cDBMetadata_Table_Search)search_[_ti] :
					null;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void Clear();
		public void Clear() {
			search_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(string name_in, bool verifyExistenz_in) {
			int _ti;

			if (verifyExistenz_in) {
				_ti = Search(name_in);
				if (_ti != -1) {
					return _ti;
				}
			}

			_ti = search_.Add(
				new cDBMetadata_Table_Search(
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
			for (int t = 0; t < search_.Count; t++) {
				if (((cDBMetadata_Table_Search)search_[t]).Name == name_in) { // already exists!
					return t; // returns it's position
				}
			}

			return -1;
		}
		#endregion
		//---
		#region public void RemoveAt(...);
		public void RemoveAt(int index_in) {
			search_.RemoveAt(index_in);
		}
		public void RemoveAt(string name_in) {
			int _s = Search(name_in);
			if (_s != -1) RemoveAt(_s);
		}
		#endregion
		#region public void CopyFrom(...);
		public void CopyFrom(iDBMetadata_Table_Searches searches_in) {
			int _table;
			int _field;

			Clear();
			for (int s2 = 0; s2 < searches_in.Count; s2++) {
				#region this[n].Name = ...;
				int _search = this.Add(
					searches_in[s2].Name,
					false
				);
				#endregion
				#region this[n].isRange = ...;
				this[_search].isRange = searches_in[s2].isRange;
				#endregion
				#region this[n].isExplicitUniqueIndex = ...;
				this[_search].isExplicitUniqueIndex = searches_in[s2].isExplicitUniqueIndex;
				#endregion
				#region this[n].SearchParameters = ...;
				for (int f = 0; f < searches_in[s2].SearchParameters.Count; f++) {
					_table = parent_ref_.Parent_ref.Search(
						searches_in[s2].SearchParameters[f].TableName
					);
					if (_table == -1) throw new Exception();

					_field = parent_ref_.Parent_ref[_table].Fields.Search(
						searches_in[s2].SearchParameters[f].FieldName
					);
					if (_field == -1) throw new Exception(); // ToDos: here!

					this[_search].SearchParameters.Add(
						_table,
						_field,
						true, 
						searches_in[s2].SearchParameters[f].ParamName
					);
				}
				#endregion
				#region this[n].Updates = ...;
				this[_search].Updates.CopyFrom(searches_in[s2].Updates);
				#endregion
			}
		}
		#endregion
		#region public bool hasExplicitUniqueIndex();
		public bool hasExplicitUniqueIndex() {
			for (int s = 0; s < search_.Count; s++) {
				if (((cDBMetadata_Table_Search)search_[s]).isExplicitUniqueIndex) {
					return true;
				}
			}
			return false;
		}
		#endregion
		#endregion
	}
}