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
using System.Collections;
using System.Reflection;
using OGen.lib.collections;

namespace OGen.Doc.lib.metadata {
	public class DocMetadata : cClaSSe {
		public DocMetadata(
		) : base (
			null
		) {
			//#region ClaSSe...
			documentationname_ = string.Empty;
			projecturl_ = string.Empty;
			copyrighttext_ = string.Empty;
			feedbackemailaddress_ = string.Empty;
			version_ = string.Empty;
			date_ = string.Empty;
			//---
			configs_ = new Configs(this/*, this*/);
			subjects_ = new Subjects(this/*, this*/);
			authors_ = new Authors(this/*, this*/);
			links_ = new Links(this/*, this*/);
			faqsubjects_ = new FAQSubjects(this/*, this*/);
			codesamples_ = new CodeSamples(this/*, this*/);
			//#endregion
		}

		#region Implementing - iClaSSe...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				default:
					throw new Exception(string.Format(
						"invalid Name: {0}", 
						name_in
					));
			}
		}
		#endregion
		#region public PropertyInfo[] Properties { get; }
		private static PropertyInfo[] properties__ = null;
		public override PropertyInfo[] Properties {
			get {
				if (properties__ == null) {
					InitializeStaticFields(
						ref properties__, 
						ref attributes__
					);
				}
				return properties__;
			}
		}
		#endregion
		#region public ClaSSPropertyAttribute[] Attributes { get; }
		private static ClaSSPropertyAttribute[] attributes__ = null;
		public override ClaSSPropertyAttribute[] Attributes {
			get {
				if (attributes__ == null) {
					InitializeStaticFields(
						ref properties__, 
						ref attributes__
					);
				}
				return attributes__;
			}
		}
		#endregion
		#endregion

		#region public Properties - ClaSSe...
		#region public string DocumentationName { get; set; }
		private string documentationname_;

		[ClaSSPropertyAttribute("documentationName", ClaSSPropertyAttribute.eType.standard, true)]
		public string DocumentationName {
			get { return documentationname_; }
			set { documentationname_ = value; }
		}
		#endregion
		#region public string ProjectURL { get; set; }
		private string projecturl_;

		[ClaSSPropertyAttribute("projectURL", ClaSSPropertyAttribute.eType.standard, true)]
		public string ProjectURL {
			get { return projecturl_; }
			set { projecturl_ = value; }
		}
		#endregion
		#region public string CopyrightText { get; set; }
		private string copyrighttext_;

		[ClaSSPropertyAttribute("copyrightText", ClaSSPropertyAttribute.eType.standard, true)]
		public string CopyrightText {
			get { return copyrighttext_; }
			set { copyrighttext_ = value; }
		}
		#endregion
		#region public string FeedbackEmailAddress { get; set; }
		private string feedbackemailaddress_;

		[ClaSSPropertyAttribute("feedbackEmailAddress", ClaSSPropertyAttribute.eType.standard, true)]
		public string FeedbackEmailAddress {
			get { return feedbackemailaddress_; }
			set { feedbackemailaddress_ = value; }
		}
		#endregion
		#region public string Version { get; set; }
		private string version_;

		[ClaSSPropertyAttribute("version", ClaSSPropertyAttribute.eType.standard, true)]
		public string Version {
			get { return version_; }
			set { version_ = value; }
		}
		#endregion
		#region public string Date { get; set; }
		private string date_;
		[ClaSSPropertyAttribute("date", ClaSSPropertyAttribute.eType.standard, true)]
		public string Date {
			get { return date_; }
			set { date_ = value; }
		}

		//private string Date__reflection {
		//	get { return date_.ToString("yyyy-MM-dd HH:mm:ss"); }
		//	set {
		//		// System.IFormatProvider
		//		// System.Globalization.DateTimeStyles
		//		date_ = DateTime.Parse(value);
		//	}
		//}
		#endregion
		//---
		#region public Configs Configs { get; set; }
		private Configs configs_;

		[ClaSSPropertyAttribute("configs", ClaSSPropertyAttribute.eType.aggregate, true)]
		public Configs Configs {
			get { return configs_; }
		}
		#endregion
		#region public Subjects Subjects { get; set; }
		private Subjects subjects_;

		[ClaSSPropertyAttribute("subjects", ClaSSPropertyAttribute.eType.aggregate, true)]
		public Subjects Subjects {
			get { return subjects_; }
		}
		#endregion
		#region public Authors Authors { get; set; }
		private Authors authors_;

		[ClaSSPropertyAttribute("authors", ClaSSPropertyAttribute.eType.aggregate, true)]
		public Authors Authors {
			get { return authors_; }
		}
		#endregion
		#region public Links Links { get; set; }
		private Links links_;

		[ClaSSPropertyAttribute("links", ClaSSPropertyAttribute.eType.aggregate, true)]
		public Links Links {
			get { return links_; }
		}
		#endregion
		#region public FAQSubjects FAQSubjects { get; set; }
		private FAQSubjects faqsubjects_;

		[ClaSSPropertyAttribute("faqSubjects", ClaSSPropertyAttribute.eType.aggregate, true)]
		public FAQSubjects FAQSubjects {
			get { return faqsubjects_; }
		}
		#endregion
		#region public CodeSamples CodeSamples { get; set; }
		private CodeSamples codesamples_;

		[ClaSSPropertyAttribute("codeSamples", ClaSSPropertyAttribute.eType.aggregate, true)]
		public CodeSamples CodeSamples {
			get { return codesamples_; }
		}
		#endregion
		#endregion
		#region public Properties...
		public const string ROOT = "documentation";
		public override string root4xml {
			get {
				return DocMetadata.ROOT;
			}
		}
		#endregion

		#region public Methods...
		#region public void LoadState_fromFile(string fileName_in);
		public void LoadState_fromFile(string fileName_in) {
			base.LoadState_fromFile(
				fileName_in, 
				root4xml
			);
		}
		#endregion
		#region public void SaveState_toFile(string fileName_in);
		public void SaveState_toFile(string fileName_in) {
			base.SaveState_toFile(
				fileName_in, 
				root4xml
			);
		}
		#endregion
		#endregion
	}
}
