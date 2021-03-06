#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.Libraries.Metadata.MetadataBusiness {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

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
				this.parent_ref_ = value;
				if (this.methods__ != null) this.methods__.parent_ref = this;
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
				if (this.methods__ != null) this.methods__.root_ref = value;
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
		#region public XS_BoEnumeration Type { get; set; }
		internal XS_BoEnumeration type_;

		[XmlAttribute("type")]
		public XS_BoEnumeration Type {
			get {
				return this.type_;
			}
			set {
				this.type_ = value;
			}
		}
		#endregion
		#region public string Namespace { get; set; }
		internal string namespace_;

		[XmlAttribute("namespace")]
		public string Namespace {
			get {
				return this.namespace_;
			}
			set {
				this.namespace_ = value;
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
				if (this.methods__ == null) {

					lock (this.methods__locker) {

						// double check, thread safer!
						if (this.methods__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.methods__ = new XS_methodsType();
						}
					}
				}

				return this.methods__;
			}
			set {
				this.methods__ = value;
			}
		}

		[XmlElement("methods")]
		public XS_methodsType methods__xml {
			get { return this.methods__; }
			set { this.methods__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_classType classType_in) {
			this.name_ = classType_in.name_;
			this.type_ = classType_in.type_;
			this.namespace_ = classType_in.namespace_;
			if (classType_in.methods__ != null) this.methods__.CopyFrom(classType_in.methods__);
		}
		#endregion
	}
}