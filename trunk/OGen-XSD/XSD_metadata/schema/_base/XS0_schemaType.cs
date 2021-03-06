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
	public class XS0_schemaType {
	#else
	public partial class XS_schemaType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				this.simpletypecollection_.parent_ref = this;
				this.complextypecollection_.parent_ref = this;
				if (this.element__ != null) this.element__.parent_ref = this;
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
				this.simpletypecollection_.root_ref = value;
				this.complextypecollection_.root_ref = value;
				if (this.element__ != null) this.element__.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public string xs { get; set; }
		internal string xs_;

		[XmlAttribute("xs")]
		public string xs {
			get {
				return this.xs_;
			}
			set {
				this.xs_ = value;
			}
		}
		#endregion
		#region public string TargetNamespace { get; set; }
		internal string targetnamespace_;

		[XmlAttribute("targetNamespace")]
		public string TargetNamespace {
			get {
				return this.targetnamespace_;
			}
			set {
				this.targetnamespace_ = value;
			}
		}
		#endregion
		#region public string xmlNS { get; set; }
		internal string xmlns_;

		[XmlAttribute("xmlns")]
		public string xmlNS {
			get {
				return this.xmlns_;
			}
			set {
				this.xmlns_ = value;
			}
		}
		#endregion
		#region public string ElementFormDefault { get; set; }
		internal string elementformdefault_;

		[XmlAttribute("elementFormDefault")]
		public string ElementFormDefault {
			get {
				return this.elementformdefault_;
			}
			set {
				this.elementformdefault_ = value;
			}
		}
		#endregion
		#region public XS_simpleTypeTypeCollection SimpleTypeCollection { get; }
		internal XS_simpleTypeTypeCollection simpletypecollection_ 
			= new XS_simpleTypeTypeCollection();

		[XmlElement("simpleType")]
		public XS_simpleTypeType[] simpletypecollection__xml {
			get { return this.simpletypecollection_.cols__; }
			set { this.simpletypecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_simpleTypeTypeCollection SimpleTypeCollection {
			get { return this.simpletypecollection_; }
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
		#region public XS_elementType Element { get; set; }
		internal XS_elementType element__;
		internal object element__locker = new object();

		[XmlIgnore()]
		public XS_elementType Element {
			get {

				// check before lock
				if (this.element__ == null) {

					lock (this.element__locker) {

						// double check, thread safer!
						if (this.element__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.element__ = new XS_elementType();
						}
					}
				}

				return this.element__;
			}
			set {
				this.element__ = value;
			}
		}

		[XmlElement("element")]
		public XS_elementType element__xml {
			get { return this.element__; }
			set { this.element__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_schemaType schemaType_in) {
			int _index = -1;

			this.xs_ = schemaType_in.xs_;
			this.targetnamespace_ = schemaType_in.targetnamespace_;
			this.xmlns_ = schemaType_in.xmlns_;
			this.elementformdefault_ = schemaType_in.elementformdefault_;
			this.simpletypecollection_.Clear();
			for (int d = 0; d < schemaType_in.simpletypecollection_.Count; d++) {
				this.simpletypecollection_.Add(
					out _index,
					new XS_simpleTypeType()
				);
				this.simpletypecollection_[_index].CopyFrom(
					schemaType_in.simpletypecollection_[d]
				);
			}
			this.complextypecollection_.Clear();
			for (int d = 0; d < schemaType_in.complextypecollection_.Count; d++) {
				this.complextypecollection_.Add(
					out _index,
					new XS_complexTypeType()
				);
				this.complextypecollection_[_index].CopyFrom(
					schemaType_in.complextypecollection_[d]
				);
			}
			if (schemaType_in.element__ != null) this.element__.CopyFrom(schemaType_in.element__);
		}
		#endregion
	}
}