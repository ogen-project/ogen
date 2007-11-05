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

namespace OGen.Doc.lib.metadata.documentation {
	#if NET_1_1
	public class XS0_subjectType {
	#else
	public partial class XS_subjectType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (documents__ != null) documents__.parent_ref = this;
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
				if (documents__ != null) documents__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string IDSubject { get; set; }
		internal string idsubject_;

		[XmlAttribute("idSubject")]
		public string IDSubject {
			get {
				return idsubject_;
			}
			set {
				idsubject_ = value;
			}
		}
		#endregion
		#region public string IDSubject_parent { get; set; }
		internal string idsubject_parent_;

		[XmlAttribute("idSubject_parent")]
		public string IDSubject_parent {
			get {
				return idsubject_parent_;
			}
			set {
				idsubject_parent_ = value;
			}
		}
		#endregion
		#region public string Name { get; set; }
		internal string name_;

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
		#region public string Description { get; set; }
		internal string description_;

		[XmlElement("description")]
		public string Description {
			get { return description_; }
			set { description_ = value; }
		}
		#endregion
		#region public XS_documentsType Documents { get; set; }
		internal XS_documentsType documents__;

		[XmlIgnore()]
		public XS_documentsType Documents {
			get {
				if (documents__ == null) {
					documents__ = new XS_documentsType();
				}
				return documents__;
			}
			set {
				documents__ = value;
			}
		}

		[XmlElement("documents")]
		public XS_documentsType documents__xml {
			get { return documents__; }
			set { documents__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_subjectType subjectType_in) {
			int _index = -1;

			idsubject_ = subjectType_in.idsubject_;
			idsubject_parent_ = subjectType_in.idsubject_parent_;
			name_ = subjectType_in.name_;description_ = subjectType_in.description_;
			if (subjectType_in.documents__ != null) documents__.CopyFrom(subjectType_in.documents__);
		}
		#endregion
	}
}