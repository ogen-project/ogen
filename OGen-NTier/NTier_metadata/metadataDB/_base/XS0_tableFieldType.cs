#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Xml.Serialization;
using System.Collections;

using OGen.lib.collections;

namespace OGen.NTier.lib.metadata.metadataDB {
	public class XS0_tableFieldType
#if !NET_1_1
		: OGenRootrefCollectionInterface<XS__RootMetadata> , OGenCollectionInterface<string>
#endif
	{
		public XS0_tableFieldType (
		) {
		}
		public XS0_tableFieldType (
			string name_in
		) : this (
		) {
			name_ = name_in;
		}

#if !NET_1_1
		#region public string CollectionName { get; }
		[XmlIgnore()]
		public string CollectionName {
			get {
				return Name;
			}
		}
		#endregion
#endif

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (tablefielddbs__ != null) tablefielddbs__.parent_ref = this;
			}
			get { return parent_ref_; }
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		private XS__RootMetadata root_ref_;

		[XmlIgnore()]
		public XS__RootMetadata root_ref {
			set {
				root_ref_ = value;
				if (tablefielddbs__ != null) tablefielddbs__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string Name { get; set; }
		private string name_;

		[XmlAttribute("name")]
		public string Name {
			get {
				return name_;
			}
			set {
				name_ = value;
			}
		}
		#endregion
		#region public bool isPK { get; set; }
		private bool ispk_;

		[XmlAttribute("isPK")]
		public bool isPK {
			get {
				return ispk_;
			}
			set {
				ispk_ = value;
			}
		}
		#endregion
		#region public bool isIdentity { get; set; }
		private bool isidentity_;

		[XmlAttribute("isIdentity")]
		public bool isIdentity {
			get {
				return isidentity_;
			}
			set {
				isidentity_ = value;
			}
		}
		#endregion
		#region public string FKTableName { get; set; }
		private string fktablename_;

		[XmlAttribute("fkTableName")]
		public string FKTableName {
			get {
				return fktablename_;
			}
			set {
				fktablename_ = value;
			}
		}
		#endregion
		#region public string FKFieldName { get; set; }
		private string fkfieldname_;

		[XmlAttribute("fkFieldName")]
		public string FKFieldName {
			get {
				return fkfieldname_;
			}
			set {
				fkfieldname_ = value;
			}
		}
		#endregion
		#region public bool isNullable { get; set; }
		private bool isnullable_;

		[XmlAttribute("isNullable")]
		public bool isNullable {
			get {
				return isnullable_;
			}
			set {
				isnullable_ = value;
			}
		}
		#endregion
		#region public int Size { get; set; }
		private int size_;

		[XmlAttribute("size")]
		public int Size {
			get {
				return size_;
			}
			set {
				size_ = value;
			}
		}
		#endregion
		#region public int NumericPrecision { get; set; }
		private int numericprecision_;

		[XmlAttribute("numericPrecision")]
		public int NumericPrecision {
			get {
				return numericprecision_;
			}
			set {
				numericprecision_ = value;
			}
		}
		#endregion
		#region public int NumericScale { get; set; }
		private int numericscale_;

		[XmlAttribute("numericScale")]
		public int NumericScale {
			get {
				return numericscale_;
			}
			set {
				numericscale_ = value;
			}
		}
		#endregion
		#region public XS_tableFieldDBsType TableFieldDBs { get; set; }
		private XS_tableFieldDBsType tablefielddbs__;

		[XmlIgnore()]
		public XS_tableFieldDBsType TableFieldDBs {
			get {
				if (tablefielddbs__ == null) {
					tablefielddbs__ = new XS_tableFieldDBsType();
				}
				return tablefielddbs__;
			}
			set {
				tablefielddbs__ = value;
			}
		}

		[XmlElement("tableFieldDBs")]
		public XS_tableFieldDBsType tablefielddbs__xml {
			get { return tablefielddbs__; }
			set { tablefielddbs__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableFieldType tableFieldType_in) {
			int _index = -1;

			name_ = tableFieldType_in.name_;
			ispk_ = tableFieldType_in.ispk_;
			isidentity_ = tableFieldType_in.isidentity_;
			fktablename_ = tableFieldType_in.fktablename_;
			fkfieldname_ = tableFieldType_in.fkfieldname_;
			isnullable_ = tableFieldType_in.isnullable_;
			size_ = tableFieldType_in.size_;
			numericprecision_ = tableFieldType_in.numericprecision_;
			numericscale_ = tableFieldType_in.numericscale_;
			if (tableFieldType_in.tablefielddbs__ != null) tablefielddbs__.CopyFrom(tableFieldType_in.tablefielddbs__);
		}
		#endregion
	}
}