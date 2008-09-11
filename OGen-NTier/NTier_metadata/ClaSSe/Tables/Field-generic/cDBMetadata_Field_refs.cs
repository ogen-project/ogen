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
	public class cDBMetadata_Field_refs : cClaSSe, iDBMetadata_Field_refs_SearchParameters, iDBMetadata_Field_refs_UpdateParameters {
		#region public cDBMetadata_Field_refs(...);
		public cDBMetadata_Field_refs(
			iClaSSe aggregateloopback_ref_in, 
			iDBMetadata_Tables parent_ref_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSS...
			field_refs_ = new ArrayList();
			//#endregion
		}
		#endregion

		#region Implementing - iClaSSe...
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "fieldRef":
					return new cDBMetadata_Field_ref(this, this.Parent_ref, -1, -1);
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

		#region Properties - ClaSS...
		public override string root4xml {
			get {
				return cDBMetadata.ROOT;
			}
		}
		#region private ArrayList field_refs_ { get; set; }
		private ArrayList field_refs_;

		[ClaSSPropertyAttribute("fieldRef", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList field_refs_reflection {
			get { return field_refs_; }
			set { field_refs_ = value; }
		}
		#endregion
		#endregion
		#region Properties...
		#region public iDBMetadata_Tables Parent_ref { get; }
		private iDBMetadata_Tables parent_ref_;
		public iDBMetadata_Tables Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		//---
		#region	public int Count { get; }
		public int Count {
			get { return field_refs_.Count; }
		}
		#endregion
		#region public cDBMetadata_Field_ref this[int index_in] { get; }
		public cDBMetadata_Field_ref this[int index_in] {
			get {
				return (cDBMetadata_Field_ref)field_refs_[index_in];
			}
		}
		#endregion
		#endregion

		//#region Methods...
		#region public void Clear();
		public void Clear() {
			field_refs_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(int tableIndex_in, int fieldIndex_in, bool verifyExistenz_in) {
			return Add(tableIndex_in, fieldIndex_in, verifyExistenz_in, string.Empty);
		}
		public int Add(int tableIndex_in, int fieldIndex_in, bool verifyExistenz_in, string paramName_in) {
			int _ti;

			if (verifyExistenz_in) {
				_ti = Search(tableIndex_in, fieldIndex_in, paramName_in);
				if (_ti != -1)
					return _ti;
			}

			_ti = field_refs_.Add(
				new cDBMetadata_Field_ref(
					this, 
					parent_ref_, 
					tableIndex_in, 
					fieldIndex_in, 
					paramName_in
				)
			);
			return _ti; // returns it's position
		}
		public int Add(string tableName_in, string fieldName_in, bool verifyExistenz_in) {
			return Add(tableName_in, fieldName_in, verifyExistenz_in, string.Empty);
		}
		public int Add(string tableName_in, string fieldName_in, bool verifyExistenz_in, string paramName_in) {
			int _ti;

			if (verifyExistenz_in) {
				_ti = Search(tableName_in, fieldName_in, paramName_in);
				if (_ti != -1)
					return _ti;
			}

			_ti = field_refs_.Add(
				new cDBMetadata_Field_ref(
					this, 
					parent_ref_, 
					tableName_in, 
					fieldName_in, 
					paramName_in
				)
			);
			return _ti; // returns it's position
		}
		#endregion
		#region public int Search(...);
		public int Search(int tableIndex_in, int fieldIndex_in) {
			return Search(tableIndex_in, fieldIndex_in, string.Empty);
		}
		public int Search(int tableIndex_in, int fieldIndex_in, string paramName_in) {
			for (int t = 0; t < field_refs_.Count; t++)
				if (
					// already exists!
					(((cDBMetadata_Field_ref)field_refs_[t]).TableName != "")
					&&
					(((cDBMetadata_Field_ref)field_refs_[t]).TableIndex() == tableIndex_in)
					&&
					(((cDBMetadata_Field_ref)field_refs_[t]).FieldName != "")
					&&
					(((cDBMetadata_Field_ref)field_refs_[t]).FieldIndex() == fieldIndex_in)

					&&
					(
						(paramName_in == string.Empty)
						||
						(((cDBMetadata_Field_ref)field_refs_[t]).ParamName == paramName_in)
					)
				)
					return t; // returns it's position

			return -1;
		}
		public int Search(string tableName_in, string fieldName_in) {
			return Search(tableName_in, fieldName_in, string.Empty);
		}
		public int Search(string tableName_in, string fieldName_in, string paramName_in) {
			for (int t = 0; t < field_refs_.Count; t++)
				if (
					// already exists!
					(((cDBMetadata_Field_ref)field_refs_[t]).TableName == tableName_in)
					&&
					(((cDBMetadata_Field_ref)field_refs_[t]).FieldName == fieldName_in)

					&&
					(
						(paramName_in == string.Empty)
						||
						(((cDBMetadata_Field_ref)field_refs_[t]).ParamName == paramName_in)
					)
				)
					return t; // returns it's position

			return -1;
		}
		#endregion
		//#endregion
	}
}
