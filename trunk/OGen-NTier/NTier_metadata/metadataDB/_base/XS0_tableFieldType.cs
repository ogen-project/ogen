#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.Libraries.Metadata.MetadataDB {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_tableFieldType {
	#else
	public partial class XS_tableFieldType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				if (this.tablefielddbs__ != null) this.tablefielddbs__.parent_ref = this;
			}
			get { return this.parent_ref_; }
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		internal XS__RootMetadata root_ref_;

		[XmlIgnore()]
		public XS__RootMetadata root_ref {
			set {
				this.root_ref_ = value;
				if (this.tablefielddbs__ != null) this.tablefielddbs__.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public string Name { get; set; }
		internal string name_;

		[XmlAttribute("name")]
		public string Name {
			get {
				return this.name_;
			}
			set {
				this.name_ = value;
			}
		}
		#endregion
		#region public bool isPK { get; set; }
		internal bool ispk_;

		[XmlAttribute("isPK")]
		public bool isPK {
			get {
				return this.ispk_;
			}
			set {
				this.ispk_ = value;
			}
		}
		#endregion
		#region public bool isIdentity { get; set; }
		internal bool isidentity_;

		[XmlAttribute("isIdentity")]
		public bool isIdentity {
			get {
				return this.isidentity_;
			}
			set {
				this.isidentity_ = value;
			}
		}
		#endregion
		#region public string FKTableName { get; set; }
		internal string fktablename_;

		[XmlAttribute("fkTableName")]
		public string FKTableName {
			get {
				return this.fktablename_;
			}
			set {
				this.fktablename_ = value;
			}
		}
		#endregion
		#region public string FKFieldName { get; set; }
		internal string fkfieldname_;

		[XmlAttribute("fkFieldName")]
		public string FKFieldName {
			get {
				return this.fkfieldname_;
			}
			set {
				this.fkfieldname_ = value;
			}
		}
		#endregion
		#region public bool isNullable { get; set; }
		internal bool isnullable_;

		[XmlAttribute("isNullable")]
		public bool isNullable {
			get {
				return this.isnullable_;
			}
			set {
				this.isnullable_ = value;
			}
		}
		#endregion
		#region public int Size { get; set; }
		internal int size_;

		[XmlAttribute("size")]
		public int Size {
			get {
				return this.size_;
			}
			set {
				this.size_ = value;
			}
		}
		#endregion
		#region public int NumericPrecision { get; set; }
		internal int numericprecision_;

		[XmlAttribute("numericPrecision")]
		public int NumericPrecision {
			get {
				return this.numericprecision_;
			}
			set {
				this.numericprecision_ = value;
			}
		}
		#endregion
		#region public int NumericScale { get; set; }
		internal int numericscale_;

		[XmlAttribute("numericScale")]
		public int NumericScale {
			get {
				return this.numericscale_;
			}
			set {
				this.numericscale_ = value;
			}
		}
		#endregion
		#region public string Description { get; set; }
		internal string description_;

		[XmlAttribute("description")]
		public string Description {
			get {
				return this.description_;
			}
			set {
				this.description_ = value;
			}
		}
		#endregion
		#region public XS_tableFieldDBsType TableFieldDBs { get; set; }
		internal XS_tableFieldDBsType tablefielddbs__;
		internal object tablefielddbs__locker = new object();

		[XmlIgnore()]
		public XS_tableFieldDBsType TableFieldDBs {
			get {

				// check before lock
				if (this.tablefielddbs__ == null) {

					lock (this.tablefielddbs__locker) {

						// double check, thread safer!
						if (this.tablefielddbs__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.tablefielddbs__ = new XS_tableFieldDBsType();
						}
					}
				}

				return this.tablefielddbs__;
			}
			set {
				this.tablefielddbs__ = value;
			}
		}

		[XmlElement("tableFieldDBs")]
		public XS_tableFieldDBsType tablefielddbs__xml {
			get { return this.tablefielddbs__; }
			set { this.tablefielddbs__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableFieldType tableFieldType_in) {
			this.name_ = tableFieldType_in.name_;
			this.ispk_ = tableFieldType_in.ispk_;
			this.isidentity_ = tableFieldType_in.isidentity_;
			this.fktablename_ = tableFieldType_in.fktablename_;
			this.fkfieldname_ = tableFieldType_in.fkfieldname_;
			this.isnullable_ = tableFieldType_in.isnullable_;
			this.size_ = tableFieldType_in.size_;
			this.numericprecision_ = tableFieldType_in.numericprecision_;
			this.numericscale_ = tableFieldType_in.numericscale_;
			this.description_ = tableFieldType_in.description_;
			if (tableFieldType_in.tablefielddbs__ != null) this.tablefielddbs__.CopyFrom(tableFieldType_in.tablefielddbs__);
		}
		#endregion
	}
}