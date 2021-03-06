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
	public class XS0_tableDBType {
	#else
	public partial class XS_tableDBType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
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
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public string DBServerType { get; set; }
		internal string dbservertype_;

		[XmlAttribute("dbServerType")]
		public string DBServerType {
			get {
				return this.dbservertype_;
			}
			set {
				this.dbservertype_ = value;
			}
		}
		#endregion
		#region public string DBTableName { get; set; }
		internal string dbtablename_;

		[XmlAttribute("dbTableName")]
		public string DBTableName {
			get {
				return this.dbtablename_;
			}
			set {
				this.dbtablename_ = value;
			}
		}
		#endregion
		#region public string DBDescription { get; set; }
		internal string dbdescription_;

		[XmlAttribute("dbDescription")]
		public string DBDescription {
			get {
				return this.dbdescription_;
			}
			set {
				this.dbdescription_ = value;
			}
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableDBType tableDBType_in) {
			this.dbservertype_ = tableDBType_in.dbservertype_;
			this.dbtablename_ = tableDBType_in.dbtablename_;
			this.dbdescription_ = tableDBType_in.dbdescription_;
		}
		#endregion
	}
}