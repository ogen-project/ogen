#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.XSD.Libraries.Metadata.Schema {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_complexTypeType {
	#else
	public partial class XS_complexTypeType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				this.attributecollection_.parent_ref = this;
				if (this.sequence__ != null) this.sequence__.parent_ref = this;
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
				if (this.sequence__ != null) this.sequence__.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public string Name { get; set; }
		internal string name_;

		[XmlAttribute("name")]
		public string Name {
			get {
				return this.name_;
			}
			set {
				this.name_ = value;
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
		#region public XS_sequenceType Sequence { get; set; }
		internal XS_sequenceType sequence__;
		internal object sequence__locker = new object();

		[XmlIgnore()]
		public XS_sequenceType Sequence {
			get {

				// check before lock
				if (this.sequence__ == null) {

					lock (this.sequence__locker) {

						// double check, thread safer!
						if (this.sequence__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.sequence__ = new XS_sequenceType();
						}
					}
				}

				return this.sequence__;
			}
			set {
				this.sequence__ = value;
			}
		}

		[XmlElement("sequence")]
		public XS_sequenceType sequence__xml {
			get { return this.sequence__; }
			set { this.sequence__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_complexTypeType complexTypeType_in) {
			int _index = -1;

			this.name_ = complexTypeType_in.name_;
			this.attributecollection_.Clear();
			for (int d = 0; d < complexTypeType_in.attributecollection_.Count; d++) {
				this.attributecollection_.Add(
					out _index,
					new XS_attributeType()
				);
				this.attributecollection_[_index].CopyFrom(
					complexTypeType_in.attributecollection_[d]
				);
			}
			if (complexTypeType_in.sequence__ != null) this.sequence__.CopyFrom(complexTypeType_in.sequence__);
		}
		#endregion
	}
}