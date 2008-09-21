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

namespace OGen.Doc.lib.metadata.documentation {
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
				parent_ref_ = value;
				if (chapters__ != null) chapters__.parent_ref = this;
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
				if (chapters__ != null) chapters__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string DocumentationName { get; set; }
		internal string documentationname_;

		[XmlAttribute("documentationName")]
		public string DocumentationName {
			get {
				return documentationname_;
			}
			set {
				documentationname_ = value;
			}
		}
		#endregion
		#region public string DocumentationTitle { get; set; }
		internal string documentationtitle_;

		[XmlAttribute("documentationTitle")]
		public string DocumentationTitle {
			get {
				return documentationtitle_;
			}
			set {
				documentationtitle_ = value;
			}
		}
		#endregion
		#region public string ProjectURL { get; set; }
		internal string projecturl_;

		[XmlAttribute("projectURL")]
		public string ProjectURL {
			get {
				return projecturl_;
			}
			set {
				projecturl_ = value;
			}
		}
		#endregion
		#region public string CopyrightText { get; set; }
		internal string copyrighttext_;

		[XmlAttribute("copyrightText")]
		public string CopyrightText {
			get {
				return copyrighttext_;
			}
			set {
				copyrighttext_ = value;
			}
		}
		#endregion
		#region public string FeedbackEmailAddress { get; set; }
		internal string feedbackemailaddress_;

		[XmlAttribute("feedbackEmailAddress")]
		public string FeedbackEmailAddress {
			get {
				return feedbackemailaddress_;
			}
			set {
				feedbackemailaddress_ = value;
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
		#region public string Date { get; set; }
		internal string date_;

		[XmlAttribute("date")]
		public string Date {
			get {
				return date_;
			}
			set {
				date_ = value;
			}
		}
		#endregion
		#region public XS_chaptersType Chapters { get; set; }
		internal XS_chaptersType chapters__;

		[XmlIgnore()]
		public XS_chaptersType Chapters {
			get {
				if (chapters__ == null) {
					chapters__ = new XS_chaptersType();
				}
				return chapters__;
			}
			set {
				chapters__ = value;
			}
		}

		[XmlElement("chapters")]
		public XS_chaptersType chapters__xml {
			get { return chapters__; }
			set { chapters__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_documentationType documentationType_in) {
			int _index = -1;

			documentationname_ = documentationType_in.documentationname_;
			documentationtitle_ = documentationType_in.documentationtitle_;
			projecturl_ = documentationType_in.projecturl_;
			copyrighttext_ = documentationType_in.copyrighttext_;
			feedbackemailaddress_ = documentationType_in.feedbackemailaddress_;
			version_ = documentationType_in.version_;
			date_ = documentationType_in.date_;
			if (documentationType_in.chapters__ != null) chapters__.CopyFrom(documentationType_in.chapters__);
		}
		#endregion
	}
}