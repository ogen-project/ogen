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

namespace OGen.XSD.lib.metadata.metadata {
	#if NET_1_1
	public class XS0_metadataIndexType {
	#else
	public partial class XS_metadataIndexType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				specificcasecollection_.parent_ref = this;
				complextypecollection_.parent_ref = this;
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
				specificcasecollection_.root_ref = value;
				complextypecollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string Metadata { get; set; }
		internal string metadata_;

		[XmlAttribute("metadata")]
		public string Metadata {
			get {
				return metadata_;
			}
			set {
				metadata_ = value;
			}
		}
		#endregion
		#region public string Index { get; set; }
		internal string index_;

		[XmlAttribute("index")]
		public string Index {
			get {
				return index_;
			}
			set {
				index_ = value;
			}
		}
		#endregion
		#region public XS_specificCaseTypeCollection SpecificCaseCollection { get; }
		internal XS_specificCaseTypeCollection specificcasecollection_ 
			= new XS_specificCaseTypeCollection();

		[XmlElement("specificCase")]
		public XS_specificCaseType[] specificcasecollection__xml {
			get { return specificcasecollection_.cols__; }
			set { specificcasecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_specificCaseTypeCollection SpecificCaseCollection {
			get { return specificcasecollection_; }
		}
		#endregion
		#region public XS_complexTypeTypeCollection ComplexTypeCollection { get; }
		internal XS_complexTypeTypeCollection complextypecollection_ 
			= new XS_complexTypeTypeCollection();

		[XmlElement("complexType")]
		public XS_complexTypeType[] complextypecollection__xml {
			get { return complextypecollection_.cols__; }
			set { complextypecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_complexTypeTypeCollection ComplexTypeCollection {
			get { return complextypecollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_metadataIndexType metadataIndexType_in) {
			int _index = -1;

			metadata_ = metadataIndexType_in.metadata_;
			index_ = metadataIndexType_in.index_;
			specificcasecollection_.Clear();
			for (int d = 0; d < metadataIndexType_in.specificcasecollection_.Count; d++) {
				specificcasecollection_.Add(
					out _index,
					new XS_specificCaseType()
				);
				specificcasecollection_[_index].CopyFrom(
					metadataIndexType_in.specificcasecollection_[d]
				);
			}
			complextypecollection_.Clear();
			for (int d = 0; d < metadataIndexType_in.complextypecollection_.Count; d++) {
				complextypecollection_.Add(
					out _index,
					new XS_complexTypeType()
				);
				complextypecollection_[_index].CopyFrom(
					metadataIndexType_in.complextypecollection_[d]
				);
			}
		}
		#endregion
	}
}