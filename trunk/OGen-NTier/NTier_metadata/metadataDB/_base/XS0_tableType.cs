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
	public class XS0_tableType {
	#else
	public partial class XS_tableType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				if (this.tabledbs__ != null) this.tabledbs__.parent_ref = this;
				if (this.tablefields__ != null) this.tablefields__.parent_ref = this;
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
				if (this.tabledbs__ != null) this.tabledbs__.root_ref = value;
				if (this.tablefields__ != null) this.tablefields__.root_ref = value;
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
		#region public bool IsVirtualTable { get; set; }
		internal bool isvirtualtable_;

		[XmlAttribute("isVirtualTable")]
		public bool IsVirtualTable {
			get {
				return this.isvirtualtable_;
			}
			set {
				this.isvirtualtable_ = value;
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
		#region public XS_tableDBsType TableDBs { get; set; }
		internal XS_tableDBsType tabledbs__;
		internal object tabledbs__locker = new object();

		[XmlIgnore()]
		public XS_tableDBsType TableDBs {
			get {

				// check before lock
				if (this.tabledbs__ == null) {

					lock (this.tabledbs__locker) {

						// double check, thread safer!
						if (this.tabledbs__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.tabledbs__ = new XS_tableDBsType();
						}
					}
				}

				return this.tabledbs__;
			}
			set {
				this.tabledbs__ = value;
			}
		}

		[XmlElement("tableDBs")]
		public XS_tableDBsType tabledbs__xml {
			get { return this.tabledbs__; }
			set { this.tabledbs__ = value; }
		}
		#endregion
		#region public XS_tableFieldsType TableFields { get; set; }
		internal XS_tableFieldsType tablefields__;
		internal object tablefields__locker = new object();

		[XmlIgnore()]
		public XS_tableFieldsType TableFields {
			get {

				// check before lock
				if (this.tablefields__ == null) {

					lock (this.tablefields__locker) {

						// double check, thread safer!
						if (this.tablefields__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.tablefields__ = new XS_tableFieldsType();
						}
					}
				}

				return this.tablefields__;
			}
			set {
				this.tablefields__ = value;
			}
		}

		[XmlElement("tableFields")]
		public XS_tableFieldsType tablefields__xml {
			get { return this.tablefields__; }
			set { this.tablefields__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableType tableType_in) {
			this.name_ = tableType_in.name_;
			this.isvirtualtable_ = tableType_in.isvirtualtable_;
			this.description_ = tableType_in.description_;
			if (tableType_in.tabledbs__ != null) this.tabledbs__.CopyFrom(tableType_in.tabledbs__);
			if (tableType_in.tablefields__ != null) this.tablefields__.CopyFrom(tableType_in.tablefields__);
		}
		#endregion
	}
}