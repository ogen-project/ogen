#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

using System;
using System.Xml.Serialization;
using System.Collections;

using OGen.lib.collections;

namespace OGen.XSD.lib.metadata {
	public class XS_ComplexType
#if !NET_1_1
		: OGenCollectionInterface<string>, OGenRootrefCollectionInterface<RootMetadata>
#endif
	{
		public XS_ComplexType(
		) {
		}
		public XS_ComplexType(
			string name_in
		) : this (
		) {
			name_ = name_in;
		}

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;

				if (sequence__ != null) sequence__.parent_ref = this;
				attributecollection_.parent_ref = this;
			}
			get { return parent_ref_; }
		}
		#endregion
		#region public RootMetadata root_ref { get; }
		private RootMetadata root_ref_;

		[XmlIgnore()]
		public RootMetadata root_ref {
			set {
				root_ref_ = value;

				if (sequence__ != null) sequence__.root_ref = value;
				attributecollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
#if !NET_1_1
		#region public string CollectionName { get; }
		[XmlIgnore()]
		public string CollectionName {
			get { return Name; }
		}
		#endregion
#endif

		#region public string Name { get; set; }
		private string name_;

		//[XmlElement("name")]
		[XmlAttribute("name")]
		public string Name {
			get {
				return name_;
			}
			set {
				name_ = value;
			}
		}
		#endregion

		#region public ... Attribute { get; }
#if !NET_1_1
		private OGenRootrefCollection<XS_Attribute, RootMetadata, string> attributecollection_
			= new OGenRootrefCollection<XS_Attribute, RootMetadata, string>();
#else
		private XS_AttributeCollection attributecollection_
			= new XS_AttributeCollection();
#endif

		[XmlElement("attribute")]
		//[XmlArray("attribute")]
		//[XmlArrayItem(typeof(XS_Attribute))]
		public XS_Attribute[] attribute__xml {
			get { return attributecollection_.cols__; }
			set { attributecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public
#if !NET_1_1
			OGenRootrefCollection<XS_Attribute, RootMetadata, string>
#else
			XS_AttributeCollection
#endif
		Attribute {
			get { return attributecollection_; }
		}
		#endregion

		#region public XS_Sequence Sequence { get; set; }
		private XS_Sequence sequence__;

		[XmlIgnore()]
		public XS_Sequence Sequence {
			get {
				if (sequence__ == null) {
					sequence__ = new XS_Sequence();
				}
				return sequence__;
			}
			set {
				sequence__ = value;
			}
		}

		[XmlElement("sequence")]
		public XS_Sequence sequence__xml {
			get { return sequence__; }
			set { sequence__ = value; }
		}
		#endregion

		#region public bool mustImplementCollection(...);
		public bool mustImplementCollection(
			string schemaName_in, 

			out string keys_ntype_out, 
			out string keys_name_out
		) {
			keys_ntype_out = string.Empty;
			keys_name_out = string.Empty;

			XS_Schema _schema = root_ref_.SchemaCollection[schemaName_in];
			for (int c = 0; c < _schema.ComplexType.Count; c++) {
				for (int e = 0; e < _schema.ComplexType[c].Sequence.Element.Count; e++) {
					if (
						// if there's an Element pointing this ComplexType
						(_schema.ComplexType[c].Sequence.Element[e].Type == Name)
						&&
						// and if this Element occurance is unbounded
						(_schema.ComplexType[c].Sequence.Element[e].MaxOccurs
							== XS_Element.MaxOccursEnum.unbounded)
					) {
						// then this ComplexType must implement a Collection

						ExtendedMetadata_complexTypeKeys _complextypekeys
							= root_ref_.ExtendedMetadata.ComplexTypeKeys[
								Name
							];

						if (_complextypekeys != null) {
							for (int a = 0; a < Attribute.Count; a++) {
								if (Attribute[a].Name == _complextypekeys.Keys) {
									keys_name_out = Attribute[a].Name;
									keys_ntype_out = Attribute[a].NType;
								}
							}
						}

						return true;
					}
				}
			}
			return false;
		}
		#endregion
	}
}
