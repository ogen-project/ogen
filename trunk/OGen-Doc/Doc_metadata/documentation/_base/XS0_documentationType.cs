#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.Doc.Libraries.Metadata.Documentation {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_documentationType {
	#else
	public partial class XS_documentationType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				if (this.chapters__ != null) this.chapters__.parent_ref = this;
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
				if (this.chapters__ != null) this.chapters__.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public string DocumentationName { get; set; }
		internal string documentationname_;

		[XmlAttribute("documentationName")]
		public string DocumentationName {
			get {
				return this.documentationname_;
			}
			set {
				this.documentationname_ = value;
			}
		}
		#endregion
		#region public string DocumentationTitle { get; set; }
		internal string documentationtitle_;

		[XmlAttribute("documentationTitle")]
		public string DocumentationTitle {
			get {
				return this.documentationtitle_;
			}
			set {
				this.documentationtitle_ = value;
			}
		}
		#endregion
		#region public string ProjectURL { get; set; }
		internal string projecturl_;

		[XmlAttribute("projectURL")]
		public string ProjectURL {
			get {
				return this.projecturl_;
			}
			set {
				this.projecturl_ = value;
			}
		}
		#endregion
		#region public string CopyrightText { get; set; }
		internal string copyrighttext_;

		[XmlAttribute("copyrightText")]
		public string CopyrightText {
			get {
				return this.copyrighttext_;
			}
			set {
				this.copyrighttext_ = value;
			}
		}
		#endregion
		#region public string FeedbackEmailAddress { get; set; }
		internal string feedbackemailaddress_;

		[XmlAttribute("feedbackEmailAddress")]
		public string FeedbackEmailAddress {
			get {
				return this.feedbackemailaddress_;
			}
			set {
				this.feedbackemailaddress_ = value;
			}
		}
		#endregion
		#region public string Version { get; set; }
		internal string version_;

		[XmlAttribute("version")]
		public string Version {
			get {
				return this.version_;
			}
			set {
				this.version_ = value;
			}
		}
		#endregion
		#region public string Date { get; set; }
		internal string date_;

		[XmlAttribute("date")]
		public string Date {
			get {
				return this.date_;
			}
			set {
				this.date_ = value;
			}
		}
		#endregion
		#region public XS_chaptersType Chapters { get; set; }
		internal XS_chaptersType chapters__;
		internal object chapters__locker = new object();

		[XmlIgnore()]
		public XS_chaptersType Chapters {
			get {

				// check before lock
				if (this.chapters__ == null) {

					lock (this.chapters__locker) {

						// double check, thread safer!
						if (this.chapters__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.chapters__ = new XS_chaptersType();
						}
					}
				}

				return this.chapters__;
			}
			set {
				this.chapters__ = value;
			}
		}

		[XmlElement("chapters")]
		public XS_chaptersType chapters__xml {
			get { return this.chapters__; }
			set { this.chapters__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_documentationType documentationType_in) {
			this.documentationname_ = documentationType_in.documentationname_;
			this.documentationtitle_ = documentationType_in.documentationtitle_;
			this.projecturl_ = documentationType_in.projecturl_;
			this.copyrighttext_ = documentationType_in.copyrighttext_;
			this.feedbackemailaddress_ = documentationType_in.feedbackemailaddress_;
			this.version_ = documentationType_in.version_;
			this.date_ = documentationType_in.date_;
			if (documentationType_in.chapters__ != null) this.chapters__.CopyFrom(documentationType_in.chapters__);
		}
		#endregion
	}
}