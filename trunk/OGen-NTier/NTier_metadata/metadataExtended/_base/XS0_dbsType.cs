#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.Libraries.Metadata.MetadataExtended {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_dbsType {
	#else
	public partial class XS_dbsType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				this.dbcollection_.parent_ref = this;
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
				this.dbcollection_.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public string NameCase_defaultProvider { get; set; }
		internal string namecase_defaultprovider_;

		[XmlAttribute("nameCase_defaultProvider")]
		public string NameCase_defaultProvider {
			get {
				return this.namecase_defaultprovider_;
			}
			set {
				this.namecase_defaultprovider_ = value;
			}
		}
		#endregion
		#region public string Description_defaultProvider { get; set; }
		internal string description_defaultprovider_;

		[XmlAttribute("description_defaultProvider")]
		public string Description_defaultProvider {
			get {
				return this.description_defaultprovider_;
			}
			set {
				this.description_defaultprovider_ = value;
			}
		}
		#endregion
		#region public XS_dbTypeCollection DBCollection { get; }
		internal XS_dbTypeCollection dbcollection_ 
			= new XS_dbTypeCollection();

		[XmlElement("db")]
		public XS_dbType[] dbcollection__xml {
			get { return this.dbcollection_.cols__; }
			set { this.dbcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_dbTypeCollection DBCollection {
			get { return this.dbcollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_dbsType dbsType_in) {
			int _index = -1;

			this.namecase_defaultprovider_ = dbsType_in.namecase_defaultprovider_;
			this.description_defaultprovider_ = dbsType_in.description_defaultprovider_;
			this.dbcollection_.Clear();
			for (int d = 0; d < dbsType_in.dbcollection_.Count; d++) {
				this.dbcollection_.Add(
					out _index,
					new XS_dbType()
				);
				this.dbcollection_[_index].CopyFrom(
					dbsType_in.dbcollection_[d]
				);
			}
		}
		#endregion
	}
}