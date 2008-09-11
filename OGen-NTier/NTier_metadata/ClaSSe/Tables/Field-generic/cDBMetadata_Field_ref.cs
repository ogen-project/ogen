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

using OGen.lib.collections;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Field_ref : cClaSSe {
		#region public cDBMetadata_Field_ref(...);
		public cDBMetadata_Field_ref(
			iClaSSe aggregateloopback_ref_in, 
			iDBMetadata_Tables parent_ref_in, 
			int tableIndex_in, 
			int fieldIndex_in
		) : this (
			aggregateloopback_ref_in, 
			parent_ref_in, 
			tableIndex_in, 
			fieldIndex_in, 
			string.Empty
		) {}
		public cDBMetadata_Field_ref(
			iClaSSe aggregateloopback_ref_in, 
			iDBMetadata_Tables parent_ref_in, 
			int tableIndex_in, 
			int fieldIndex_in, 
			string paramName_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			TableName = (tableIndex_in != -1) ? Parent_ref[tableIndex_in].Name : string.Empty;
			FieldName = ((tableIndex_in != -1) && (fieldIndex_in != -1)) ? Parent_ref[tableIndex_in].Fields[fieldIndex_in].Name : string.Empty;
			ParamName = paramName_in;
			//#endregion
		}
		public cDBMetadata_Field_ref(
			iClaSSe aggregateloopback_ref_in, 
			iDBMetadata_Tables parent_ref_in, 
			string tableName_in, 
			string fieldName_in
		) : this (
			aggregateloopback_ref_in, 
			parent_ref_in, 
			tableName_in, 
			fieldName_in, 
			string.Empty
		) {}
		public cDBMetadata_Field_ref(
			iClaSSe aggregateloopback_ref_in, 
			iDBMetadata_Tables parent_ref_in, 
			string tableName_in, 
			string fieldName_in, 
			string paramName_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			TableName = tableName_in;
			FieldName = fieldName_in;
			ParamName = paramName_in;
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
		#region public string TableName { get; set; }
		private string tablename_;

		[ClaSSPropertyAttribute("tableName", ClaSSPropertyAttribute.eType.standard, true)]
		public string TableName {
			get { return tablename_; }
			set { tablename_ = value; }
		}
		#endregion
		#region public string FieldName { get; set; }
		private string fieldname_;

		[ClaSSPropertyAttribute("fieldName", ClaSSPropertyAttribute.eType.standard, true)]
		public string FieldName {
			get { return fieldname_; }
			set { fieldname_ = value; }
		}
		#endregion
		#region public string ParamName { get; set; }
		private string paramname__;

		public string ParamName {
			get {
				return (paramname__.Trim() == string.Empty) ?
					FieldName : 
					paramname__;
			}
			set { paramname__ = value; }
		}

		[ClaSSPropertyAttribute("paramName", ClaSSPropertyAttribute.eType.standard, true)]
		private string ParamName_reflection {
			get { return paramname__; }
			set { paramname__ = value; }
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
		#region public bool Table_hasRef { get; }
		public bool Table_hasRef {
			get { return (TableName != ""); }
		}
		#endregion
		#region public bool Field_hasRef { get; }
		public bool Field_hasRef {
			get { return ((TableName != "") && (FieldName != "")); }
		}
		#endregion
		#region public cDBMetadata_Table Table { get; }
		public cDBMetadata_Table Table {
			get {
				return (Table_hasRef) ? parent_ref_[TableName] : null;
			}
		}
		#endregion
		#region public cDBMetadata_Table_Field Field { get; }
		public cDBMetadata_Table_Field Field {
			get {
				return (Field_hasRef) ? parent_ref_[TableName].Fields[FieldName] : null;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public int TableIndex();
		public int TableIndex() {
			#region Checking...
			if (TableName == "")
				throw new Exception(string.Format("{0}.{1}.TableIndex(): - no ref present", this.GetType().Namespace, this.GetType().Name));
			#endregion

			return parent_ref_.Search(TableName);
		}
		#endregion
		#region public int FieldIndex();
		public int FieldIndex() {
			#region Checking...
			if ((TableName == "") || (FieldName == ""))
				throw new Exception(string.Format("{0}.{1}.FieldIndex(): - no ref present", this.GetType().Namespace, this.GetType().Name));
			#endregion

			return parent_ref_[TableName].Fields.Search(FieldName);
		}
		#endregion
		#endregion
	}
}
