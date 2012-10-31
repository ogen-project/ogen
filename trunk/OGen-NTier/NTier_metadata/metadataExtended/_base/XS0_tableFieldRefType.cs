#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.lib.metadata.metadataExtended {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_tableFieldRefType {
	#else
	public partial class XS_tableFieldRefType {
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
		#region public string TableName { get; set; }
		internal string tablename_;

		[XmlAttribute("tableName")]
		public string TableName {
			get {
				return this.tablename_;
			}
			set {
				this.tablename_ = value;
			}
		}
		#endregion
		#region public string TableFieldName { get; set; }
		internal string tablefieldname_;

		[XmlAttribute("tableFieldName")]
		public string TableFieldName {
			get {
				return this.tablefieldname_;
			}
			set {
				this.tablefieldname_ = value;
			}
		}
		#endregion
		#region public string ParamName { get; set; }
		internal string paramname_;

		[XmlAttribute("paramName")]
		public string ParamName {
			get {
				return this.paramname_;
			}
			set {
				this.paramname_ = value;
			}
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableFieldRefType tableFieldRefType_in) {
			this.tablename_ = tableFieldRefType_in.tablename_;
			this.tablefieldname_ = tableFieldRefType_in.tablefieldname_;
			this.paramname_ = tableFieldRefType_in.paramname_;
		}
		#endregion
	}
}