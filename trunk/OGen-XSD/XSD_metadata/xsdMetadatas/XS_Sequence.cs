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

using OGen.lib.collections;

namespace OGen.XSD.lib.metadata {
	public class XS_Sequence {
		public XS_Sequence(
		) {
		}

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;

				elementcollection_.parent_ref = this;
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

				elementcollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion

		#region public ... Element { get; }
		private XS_ElementCollection elementcollection_
			= new XS_ElementCollection();

		[XmlElement("element")]
		//[XmlArray("element")]
		//[XmlArrayItem(typeof(XS_Element))]
		public XS_Element[] element__xml {
			get { return elementcollection_.cols__; }
			set { elementcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_ElementCollection Element {
			get { return elementcollection_; }
		}
		#endregion
	}
}
