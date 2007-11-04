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
	public class XS0_tableFieldsType {
		public XS0_tableFieldsType (
		) {
			tablefieldcollection_ = new XS_tableFieldTypeCollection();
		}

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				tablefieldcollection_.parent_ref = this;
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
				tablefieldcollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public XS_tableFieldTypeCollection TableFieldCollection { get; }
		private XS_tableFieldTypeCollection tablefieldcollection_;

		[XmlElement("tableField")]
		public XS_tableFieldType[] tablefieldcollection__xml {
			get { return tablefieldcollection_.cols__; }
			set { tablefieldcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_tableFieldTypeCollection TableFieldCollection {
			get { return tablefieldcollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableFieldsType tableFieldsType_in) {
			int _index = -1;

			tablefieldcollection_.Clear();
			for (int d = 0; d < tableFieldsType_in.tablefieldcollection_.Count; d++) {
				tablefieldcollection_.Add(
					out _index,
					new XS_tableFieldType()
				);
				tablefieldcollection_[_index].CopyFrom(
					tableFieldsType_in.tablefieldcollection_[d]
				);
			}
		}
		#endregion
	}
}