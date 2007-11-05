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

namespace OGen.NTier.lib.metadata.metadataExtended {
	public 
		#if !NET_1_1
			partial
		#endif
		class 
		#if NET_1_1
			XS0_dbsType
		#else
			XS_dbsType
		#endif
	{

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				dbcollection_.parent_ref = this;
			}
			get { return parent_ref_; }
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		internal XS__RootMetadata root_ref_;

		[XmlIgnore()]
		public XS__RootMetadata root_ref {
			set {
				root_ref_ = value;
				dbcollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string NameCase_defaultProvider { get; set; }
		internal string namecase_defaultprovider_;

		[XmlAttribute("nameCase_defaultProvider")]
		public string NameCase_defaultProvider {
			get {
				return namecase_defaultprovider_;
			}
			set {
				namecase_defaultprovider_ = value;
			}
		}
		#endregion
		#region public string Description_defaultProvider { get; set; }
		internal string description_defaultprovider_;

		[XmlAttribute("description_defaultProvider")]
		public string Description_defaultProvider {
			get {
				return description_defaultprovider_;
			}
			set {
				description_defaultprovider_ = value;
			}
		}
		#endregion
		#region public XS_dbTypeCollection DBCollection { get; }
		internal XS_dbTypeCollection dbcollection_;

		[XmlElement("db")]
		public XS_dbType[] dbcollection__xml {
			get { return dbcollection_.cols__; }
			set { dbcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_dbTypeCollection DBCollection {
			get { return dbcollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_dbsType dbsType_in) {
			int _index = -1;

			namecase_defaultprovider_ = dbsType_in.namecase_defaultprovider_;
			description_defaultprovider_ = dbsType_in.description_defaultprovider_;
			dbcollection_.Clear();
			for (int d = 0; d < dbsType_in.dbcollection_.Count; d++) {
				dbcollection_.Add(
					out _index,
					new XS_dbType()
				);
				dbcollection_[_index].CopyFrom(
					dbsType_in.dbcollection_[d]
				);
			}
		}
		#endregion
	}
}