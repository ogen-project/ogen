#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.lib.metadata.metadataBusiness {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

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
				this.parent_ref_ = value;
				if (this.classes__ != null) this.classes__.parent_ref = this;
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
				if (this.classes__ != null) this.classes__.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public string ApplicationName { get; set; }
		internal string applicationname_;

		[XmlAttribute("applicationName")]
		public string ApplicationName {
			get {
				return this.applicationname_;
			}
			set {
				this.applicationname_ = value;
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
				if (this.classes__ == null) {

					lock (this.classes__locker) {

						// double check, thread safer!
						if (this.classes__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.classes__ = new XS_classesType();
						}
					}
				}

				return this.classes__;
			}
			set {
				this.classes__ = value;
			}
		}

		[XmlElement("classes")]
		public XS_classesType classes__xml {
			get { return this.classes__; }
			set { this.classes__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_metadataBusinessType metadataBusinessType_in) {
			this.applicationname_ = metadataBusinessType_in.applicationname_;
			if (metadataBusinessType_in.classes__ != null) this.classes__.CopyFrom(metadataBusinessType_in.classes__);
		}
		#endregion
	}
}