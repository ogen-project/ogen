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

namespace OGen.XSD.lib.metadata.schema {
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
				parent_ref_ = value;
				simpletypecollection_.parent_ref = this;
				complextypecollection_.parent_ref = this;
				if (element__ != null) element__.parent_ref = this;
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
				simpletypecollection_.root_ref = value;
				complextypecollection_.root_ref = value;
				if (element__ != null) element__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string xs { get; set; }
		internal string xs_;

		[XmlAttribute("xs")]
		public string xs {
			get {
				return xs_;
			}
			set {
				xs_ = value;
			}
		}
		#endregion
		#region public string TargetNamespace { get; set; }
		internal string targetnamespace_;

		[XmlAttribute("targetNamespace")]
		public string TargetNamespace {
			get {
				return targetnamespace_;
			}
			set {
				targetnamespace_ = value;
			}
		}
		#endregion
		#region public string xmlNS { get; set; }
		internal string xmlns_;

		[XmlAttribute("xmlns")]
		public string xmlNS {
			get {
				return xmlns_;
			}
			set {
				xmlns_ = value;
			}
		}
		#endregion
		#region public string ElementFormDefault { get; set; }
		internal string elementformdefault_;

		[XmlAttribute("elementFormDefault")]
		public string ElementFormDefault {
			get {
				return elementformdefault_;
			}
			set {
				elementformdefault_ = value;
			}
		}
		#endregion
		#region public XS_simpleTypeTypeCollection SimpleTypeCollection { get; }
		internal XS_simpleTypeTypeCollection simpletypecollection_ 
			= new XS_simpleTypeTypeCollection();

		[XmlElement("simpleType")]
		public XS_simpleTypeType[] simpletypecollection__xml {
			get { return simpletypecollection_.cols__; }
			set { simpletypecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_simpleTypeTypeCollection SimpleTypeCollection {
			get { return simpletypecollection_; }
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
		#region public XS_elementType Element { get; set; }
		internal XS_elementType element__;

		[XmlIgnore()]
		public XS_elementType Element {
			get {
				if (element__ == null) {
					element__ = new XS_elementType();
				}
				return element__;
			}
			set {
				element__ = value;
			}
		}

		[XmlElement("element")]
		public XS_elementType element__xml {
			get { return element__; }
			set { element__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_schemaType schemaType_in) {
			int _index = -1;

			xs_ = schemaType_in.xs_;
			targetnamespace_ = schemaType_in.targetnamespace_;
			xmlns_ = schemaType_in.xmlns_;
			elementformdefault_ = schemaType_in.elementformdefault_;
			simpletypecollection_.Clear();
			for (int d = 0; d < schemaType_in.simpletypecollection_.Count; d++) {
				simpletypecollection_.Add(
					out _index,
					new XS_simpleTypeType()
				);
				simpletypecollection_[_index].CopyFrom(
					schemaType_in.simpletypecollection_[d]
				);
			}
			complextypecollection_.Clear();
			for (int d = 0; d < schemaType_in.complextypecollection_.Count; d++) {
				complextypecollection_.Add(
					out _index,
					new XS_complexTypeType()
				);
				complextypecollection_[_index].CopyFrom(
					schemaType_in.complextypecollection_[d]
				);
			}
			if (schemaType_in.element__ != null) element__.CopyFrom(schemaType_in.element__);
		}
		#endregion
	}
}