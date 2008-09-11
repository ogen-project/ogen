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

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Table_Fields : cClaSSe, iDBMetadata_Table_Fields {
		#region public cDBMetadata_Table_Fields(...);
		public cDBMetadata_Table_Fields(
			iClaSSe aggregateloopback_ref_in, 
			cDBMetadata_Table parent_ref_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			field_ = new ArrayList();	// base.Property_aggregate_collection["field", new ArrayList());
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
				case "field":
					return new cDBMetadata_Table_Field(
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
		#region private ArrayList field_ { get; set; }
		private ArrayList field_;

		[ClaSSPropertyAttribute("field", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList field_reflection {
			get { return field_; }
			set { field_ = value; }
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
			get { return field_.Count; }
		}
		#endregion
		#region public cDBMetadata_Table_Field this[int index_in] { get; }
		public cDBMetadata_Table_Field this[int index_in] {
			get {
				return (cDBMetadata_Table_Field)field_[index_in];
			}
		}
		#endregion
		#region public cDBMetadata_Table_Field this[string name_in] { get; }
		public cDBMetadata_Table_Field this[string name_in] {
			get {
				int _fi = Search(name_in);
				return (_fi >= 0) ? 
					(cDBMetadata_Table_Field)field_[_fi] : 
					null;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void Clear(...);
		public void Clear() {
			field_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(string name_in, bool verifyExistenz_in) {
			int _fi;

			if (verifyExistenz_in) {
				_fi = Search(name_in);
				if (_fi != -1)
					return _fi;
			}

			_fi = field_.Add(
				new cDBMetadata_Table_Field(
					this, 
					this, 
					name_in
				)
			);
			return _fi; // returns it's position
		}
		#endregion
		#region public int Search(...)
		public int Search(string name_in) {
			for (int f = 0; f < field_.Count; f++)
				if (((cDBMetadata_Table_Field)field_[f]).Name == name_in) // already exists!
					return f; // returns it's position

			return -1;
		}
		#endregion
		#region public int Count_onlyPK();
		public int Count_onlyPK() {
			int Count_onlyPK_out = 0;

			for (int i = 0; i < Count; i++) {
				if (this[i].isPK) Count_onlyPK_out++;
			}

			return Count_onlyPK_out;
		}
		#endregion
		#endregion
	}
}
