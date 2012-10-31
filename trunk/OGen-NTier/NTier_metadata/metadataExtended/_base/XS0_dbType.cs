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
	public class XS0_dbType {
	#else
	public partial class XS_dbType {
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
		#region public bool GenerateSQL { get; set; }
		internal bool generatesql_;

		[XmlAttribute("generateSQL")]
		public bool GenerateSQL {
			get {
				return this.generatesql_;
			}
			set {
				this.generatesql_ = value;
			}
		}
		#endregion
		#region public string ConnectionString { get; set; }
		internal string connectionstring_;

		[XmlAttribute("connectionString")]
		public string ConnectionString {
			get {
				return this.connectionstring_;
			}
			set {
				this.connectionstring_ = value;
			}
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_dbType dbType_in) {
			this.dbservertype_ = dbType_in.dbservertype_;
			this.generatesql_ = dbType_in.generatesql_;
			this.connectionstring_ = dbType_in.connectionstring_;
		}
		#endregion
	}
}