#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.XSD.Libraries.Metadata.Metadata {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

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
				this.parent_ref_ = value;
				this.specificcasecollection_.parent_ref = this;
				this.complextypecollection_.parent_ref = this;
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
				this.specificcasecollection_.root_ref = value;
				this.complextypecollection_.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public string Metadata { get; set; }
		internal string metadata_;

		[XmlAttribute("metadata")]
		public string Metadata {
			get {
				return this.metadata_;
			}
			set {
				this.metadata_ = value;
			}
		}
		#endregion
		#region public string Index { get; set; }
		internal string index_;

		[XmlAttribute("index")]
		public string Index {
			get {
				return this.index_;
			}
			set {
				this.index_ = value;
			}
		}
		#endregion
		#region public XS_specificCaseTypeCollection SpecificCaseCollection { get; }
		internal XS_specificCaseTypeCollection specificcasecollection_ 
			= new XS_specificCaseTypeCollection();

		[XmlElement("specificCase")]
		public XS_specificCaseType[] specificcasecollection__xml {
			get { return this.specificcasecollection_.cols__; }
			set { this.specificcasecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_specificCaseTypeCollection SpecificCaseCollection {
			get { return this.specificcasecollection_; }
		}
		#endregion
		#region public XS_complexTypeTypeCollection ComplexTypeCollection { get; }
		internal XS_complexTypeTypeCollection complextypecollection_ 
			= new XS_complexTypeTypeCollection();

		[XmlElement("complexType")]
		public XS_complexTypeType[] complextypecollection__xml {
			get { return this.complextypecollection_.cols__; }
			set { this.complextypecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_complexTypeTypeCollection ComplexTypeCollection {
			get { return this.complextypecollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_metadataIndexType metadataIndexType_in) {
			int _index = -1;

			this.metadata_ = metadataIndexType_in.metadata_;
			this.index_ = metadataIndexType_in.index_;
			this.specificcasecollection_.Clear();
			for (int d = 0; d < metadataIndexType_in.specificcasecollection_.Count; d++) {
				this.specificcasecollection_.Add(
					out _index,
					new XS_specificCaseType()
				);
				this.specificcasecollection_[_index].CopyFrom(
					metadataIndexType_in.specificcasecollection_[d]
				);
			}
			this.complextypecollection_.Clear();
			for (int d = 0; d < metadataIndexType_in.complextypecollection_.Count; d++) {
				this.complextypecollection_.Add(
					out _index,
					new XS_complexTypeType()
				);
				this.complextypecollection_[_index].CopyFrom(
					metadataIndexType_in.complextypecollection_[d]
				);
			}
		}
		#endregion
	}
}