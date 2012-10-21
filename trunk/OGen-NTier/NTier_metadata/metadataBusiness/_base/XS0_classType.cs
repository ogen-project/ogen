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

namespace OGen.NTier.lib.metadata.metadataBusiness {
	#if NET_1_1
	public class XS0_classType {
	#else
	public partial class XS_classType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (methods__ != null) methods__.parent_ref = this;
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
				if (methods__ != null) methods__.root_ref = value;
			}
			get { return root_ref_; }
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
		#region public XS_BoEnumeration Type { get; set; }
		internal XS_BoEnumeration type_;

		[XmlAttribute("type")]
		public XS_BoEnumeration Type {
			get {
				return type_;
			}
			set {
				type_ = value;
			}
		}
		#endregion
		#region public string Namespace { get; set; }
		internal string namespace_;

		[XmlAttribute("namespace")]
		public string Namespace {
			get {
				return namespace_;
			}
			set {
				namespace_ = value;
			}
		}
		#endregion
		#region public XS_methodsType Methods { get; set; }
		internal XS_methodsType methods__;
		internal object methods__locker = new object();

		[XmlIgnore()]
		public XS_methodsType Methods {
			get {

				// check before lock
				if (methods__ == null) {

					lock (methods__locker) {

						// double check, thread safer!
						if (methods__ == null) {

							methods__ = new XS_methodsType();
						}
					}
				}

				return methods__;
			}
			set {
				methods__ = value;
			}
		}

		[XmlElement("methods")]
		public XS_methodsType methods__xml {
			get { return methods__; }
			set { methods__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_classType classType_in) {
			int _index = -1;

			name_ = classType_in.name_;
			type_ = classType_in.type_;
			namespace_ = classType_in.namespace_;
			if (classType_in.methods__ != null) methods__.CopyFrom(classType_in.methods__);
		}
		#endregion
	}
}