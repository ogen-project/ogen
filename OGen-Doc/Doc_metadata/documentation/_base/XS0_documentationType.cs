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
	public class XS0_documentationType
#if !NET_1_1
		: OGenRootrefCollectionInterface<XS__RootMetadata> 
#endif
	{
		public XS0_documentationType (
		) {
		}

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (configs__ != null) configs__.parent_ref = this;
				if (subjects__ != null) subjects__.parent_ref = this;
				if (authors__ != null) authors__.parent_ref = this;
				if (codesamples__ != null) codesamples__.parent_ref = this;
				if (links__ != null) links__.parent_ref = this;
				if (faqsubjects__ != null) faqsubjects__.parent_ref = this;
			}
			get { return parent_ref_; }
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		private XS__RootMetadata root_ref_;

		[XmlIgnore()]
		public XS__RootMetadata root_ref {
			set {
				root_ref_ = value;
				if (configs__ != null) configs__.root_ref = value;
				if (subjects__ != null) subjects__.root_ref = value;
				if (authors__ != null) authors__.root_ref = value;
				if (codesamples__ != null) codesamples__.root_ref = value;
				if (links__ != null) links__.root_ref = value;
				if (faqsubjects__ != null) faqsubjects__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string DocumentationName { get; set; }
		private string documentationname_;

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
		#region public string ProjectURL { get; set; }
		private string projecturl_;

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
		private string copyrighttext_;

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
		private string feedbackemailaddress_;

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
		private string version_;

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
		private string date_;

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
		#region public XS_configsType Configs { get; set; }
		private XS_configsType configs__;

		[XmlIgnore()]
		public XS_configsType Configs {
			get {
				if (configs__ == null) {
					configs__ = new XS_configsType();
				}
				return configs__;
			}
			set {
				configs__ = value;
			}
		}

		[XmlElement("configs")]
		public XS_configsType configs__xml {
			get { return configs__; }
			set { configs__ = value; }
		}
		#endregion
		#region public XS_subjectsType Subjects { get; set; }
		private XS_subjectsType subjects__;

		[XmlIgnore()]
		public XS_subjectsType Subjects {
			get {
				if (subjects__ == null) {
					subjects__ = new XS_subjectsType();
				}
				return subjects__;
			}
			set {
				subjects__ = value;
			}
		}

		[XmlElement("subjects")]
		public XS_subjectsType subjects__xml {
			get { return subjects__; }
			set { subjects__ = value; }
		}
		#endregion
		#region public XS_authorsType Authors { get; set; }
		private XS_authorsType authors__;

		[XmlIgnore()]
		public XS_authorsType Authors {
			get {
				if (authors__ == null) {
					authors__ = new XS_authorsType();
				}
				return authors__;
			}
			set {
				authors__ = value;
			}
		}

		[XmlElement("authors")]
		public XS_authorsType authors__xml {
			get { return authors__; }
			set { authors__ = value; }
		}
		#endregion
		#region public XS_codeSamplesType CodeSamples { get; set; }
		private XS_codeSamplesType codesamples__;

		[XmlIgnore()]
		public XS_codeSamplesType CodeSamples {
			get {
				if (codesamples__ == null) {
					codesamples__ = new XS_codeSamplesType();
				}
				return codesamples__;
			}
			set {
				codesamples__ = value;
			}
		}

		[XmlElement("codeSamples")]
		public XS_codeSamplesType codesamples__xml {
			get { return codesamples__; }
			set { codesamples__ = value; }
		}
		#endregion
		#region public XS_linksType Links { get; set; }
		private XS_linksType links__;

		[XmlIgnore()]
		public XS_linksType Links {
			get {
				if (links__ == null) {
					links__ = new XS_linksType();
				}
				return links__;
			}
			set {
				links__ = value;
			}
		}

		[XmlElement("links")]
		public XS_linksType links__xml {
			get { return links__; }
			set { links__ = value; }
		}
		#endregion
		#region public XS_faqSubjectsType FAQSubjects { get; set; }
		private XS_faqSubjectsType faqsubjects__;

		[XmlIgnore()]
		public XS_faqSubjectsType FAQSubjects {
			get {
				if (faqsubjects__ == null) {
					faqsubjects__ = new XS_faqSubjectsType();
				}
				return faqsubjects__;
			}
			set {
				faqsubjects__ = value;
			}
		}

		[XmlElement("faqSubjects")]
		public XS_faqSubjectsType faqsubjects__xml {
			get { return faqsubjects__; }
			set { faqsubjects__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_documentationType documentationType_in) {
			int _index = -1;

			documentationname_ = documentationType_in.documentationname_;
			projecturl_ = documentationType_in.projecturl_;
			copyrighttext_ = documentationType_in.copyrighttext_;
			feedbackemailaddress_ = documentationType_in.feedbackemailaddress_;
			version_ = documentationType_in.version_;
			date_ = documentationType_in.date_;
			if (documentationType_in.configs__ != null) configs__.CopyFrom(documentationType_in.configs__);
			if (documentationType_in.subjects__ != null) subjects__.CopyFrom(documentationType_in.subjects__);
			if (documentationType_in.authors__ != null) authors__.CopyFrom(documentationType_in.authors__);
			if (documentationType_in.codesamples__ != null) codesamples__.CopyFrom(documentationType_in.codesamples__);
			if (documentationType_in.links__ != null) links__.CopyFrom(documentationType_in.links__);
			if (documentationType_in.faqsubjects__ != null) faqsubjects__.CopyFrom(documentationType_in.faqsubjects__);
		}
		#endregion
	}
}