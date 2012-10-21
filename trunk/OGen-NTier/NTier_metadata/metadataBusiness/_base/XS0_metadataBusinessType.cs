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
	public class XS0_metadataBusinessType {
	#else
	public partial class XS_metadataBusinessType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (classes__ != null) classes__.parent_ref = this;
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
				if (classes__ != null) classes__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string ApplicationName { get; set; }
		internal string applicationname_;

		[XmlAttribute("applicationName")]
		public string ApplicationName {
			get {
				return applicationname_;
			}
			set {
				applicationname_ = value;
			}
		}
		#endregion
		#region public XS_classesType Classes { get; set; }
		internal XS_classesType classes__;
		internal object classes__locker = new object();

		[XmlIgnore()]
		public XS_classesType Classes {
			get {

				// check before lock
				if (classes__ == null) {

					lock (classes__locker) {

						// double check, thread safer!
						if (classes__ == null) {

							classes__ = new XS_classesType();
						}
					}
				}

				return classes__;
			}
			set {
				classes__ = value;
			}
		}

		[XmlElement("classes")]
		public XS_classesType classes__xml {
			get { return classes__; }
			set { classes__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_metadataBusinessType metadataBusinessType_in) {
			int _index = -1;

			applicationname_ = metadataBusinessType_in.applicationname_;
			if (metadataBusinessType_in.classes__ != null) classes__.CopyFrom(metadataBusinessType_in.classes__);
		}
		#endregion
	}
}