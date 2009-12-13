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

namespace OGen.Dia.lib.metadata.diagram {
	#if NET_1_1
	public class XS0_objectType {
	#else
	public partial class XS_objectType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				attributecollection_.parent_ref = this;
				if (connections__ != null) connections__.parent_ref = this;
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
				attributecollection_.root_ref = value;
				if (connections__ != null) connections__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string Type { get; set; }
		internal string type_;

		[XmlAttribute("type")]
		public string Type {
			get {
				return type_;
			}
			set {
				type_ = value;
			}
		}
		#endregion
		#region public string Version { get; set; }
		internal string version_;

		[XmlAttribute("version")]
		public string Version {
			get {
				return version_;
			}
			set {
				version_ = value;
			}
		}
		#endregion
		#region public string Id { get; set; }
		internal string id_;

		[XmlAttribute("id")]
		public string Id {
			get {
				return id_;
			}
			set {
				id_ = value;
			}
		}
		#endregion
		#region public XS_attributeTypeCollection AttributeCollection { get; }
		internal XS_attributeTypeCollection attributecollection_ 
			= new XS_attributeTypeCollection();

		[XmlElement("attribute")]
		public XS_attributeType[] attributecollection__xml {
			get { return attributecollection_.cols__; }
			set { attributecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_attributeTypeCollection AttributeCollection {
			get { return attributecollection_; }
		}
		#endregion
		#region public XS_connectionsType Connections { get; set; }
		internal XS_connectionsType connections__;

		[XmlIgnore()]
		public XS_connectionsType Connections {
			get {
				if (connections__ == null) {
					connections__ = new XS_connectionsType();
				}
				return connections__;
			}
			set {
				connections__ = value;
			}
		}

		[XmlElement("connections")]
		public XS_connectionsType connections__xml {
			get { return connections__; }
			set { connections__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_objectType objectType_in) {
			int _index = -1;

			type_ = objectType_in.type_;
			version_ = objectType_in.version_;
			id_ = objectType_in.id_;
			attributecollection_.Clear();
			for (int d = 0; d < objectType_in.attributecollection_.Count; d++) {
				attributecollection_.Add(
					out _index,
					new XS_attributeType()
				);
				attributecollection_[_index].CopyFrom(
					objectType_in.attributecollection_[d]
				);
			}
			if (objectType_in.connections__ != null) connections__.CopyFrom(objectType_in.connections__);
		}
		#endregion
	}
}