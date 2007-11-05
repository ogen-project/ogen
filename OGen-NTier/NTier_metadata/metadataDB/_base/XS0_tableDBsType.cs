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
	public 
		#if !NET_1_1
			partial
		#endif
		class 
		#if NET_1_1
			XS0_tableDBsType
		#else
			XS_tableDBsType
		#endif
	{

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				tabledbcollection_.parent_ref = this;
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
				tabledbcollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public XS_tableDBTypeCollection TableDBCollection { get; }
		internal XS_tableDBTypeCollection tabledbcollection_;

		[XmlElement("tableDB")]
		public XS_tableDBType[] tabledbcollection__xml {
			get { return tabledbcollection_.cols__; }
			set { tabledbcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_tableDBTypeCollection TableDBCollection {
			get { return tabledbcollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableDBsType tableDBsType_in) {
			int _index = -1;

			tabledbcollection_.Clear();
			for (int d = 0; d < tableDBsType_in.tabledbcollection_.Count; d++) {
				tabledbcollection_.Add(
					out _index,
					new XS_tableDBType()
				);
				tabledbcollection_[_index].CopyFrom(
					tableDBsType_in.tabledbcollection_[d]
				);
			}
		}
		#endregion
	}
}