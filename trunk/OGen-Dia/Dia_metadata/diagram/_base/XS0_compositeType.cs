#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.Dia.Libraries.Metadata.Diagram {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_compositeType {
	#else
	public partial class XS_compositeType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				this.attributecollection_.parent_ref = this;
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
				this.attributecollection_.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public string Type { get; set; }
		internal string type_;

		[XmlAttribute("type")]
		public string Type {
			get {
				return this.type_;
			}
			set {
				this.type_ = value;
			}
		}
		#endregion
		#region public XS_attributeTypeCollection AttributeCollection { get; }
		internal XS_attributeTypeCollection attributecollection_ 
			= new XS_attributeTypeCollection();

		[XmlElement("attribute")]
		public XS_attributeType[] attributecollection__xml {
			get { return this.attributecollection_.cols__; }
			set { this.attributecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_attributeTypeCollection AttributeCollection {
			get { return this.attributecollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_compositeType compositeType_in) {
			int _index = -1;

			this.type_ = compositeType_in.type_;
			this.attributecollection_.Clear();
			for (int d = 0; d < compositeType_in.attributecollection_.Count; d++) {
				this.attributecollection_.Add(
					out _index,
					new XS_attributeType()
				);
				this.attributecollection_[_index].CopyFrom(
					compositeType_in.attributecollection_[d]
				);
			}
		}
		#endregion
	}
}