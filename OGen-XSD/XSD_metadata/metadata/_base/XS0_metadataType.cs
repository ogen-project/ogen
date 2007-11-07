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

namespace OGen.XSD.lib.metadata.metadata {
	#if NET_1_1
	public class XS0_metadataType {
	#else
	public partial class XS_metadataType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				metadataindexcollection_.parent_ref = this;
				specificcasecollection_.parent_ref = this;
				complextypecollection_.parent_ref = this;
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
				metadataindexcollection_.root_ref = value;
				specificcasecollection_.root_ref = value;
				complextypecollection_.root_ref = value;
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
		#region public XS_CaseTypeEnumeration CaseType { get; set; }
		internal XS_CaseTypeEnumeration casetype_;

		[XmlAttribute("caseType")]
		public XS_CaseTypeEnumeration CaseType {
			get {
				return casetype_;
			}
			set {
				casetype_ = value;
			}
		}
		#endregion
		#region public bool AllowSettersOnObjects { get; set; }
		internal bool allowsettersonobjects_;

		[XmlAttribute("allowSettersOnObjects")]
		public bool AllowSettersOnObjects {
			get {
				return allowsettersonobjects_;
			}
			set {
				allowsettersonobjects_ = value;
			}
		}
		#endregion
		#region public bool isSimple { get; set; }
		internal bool issimple_;

		[XmlAttribute("isSimple")]
		public bool isSimple {
			get {
				return issimple_;
			}
			set {
				issimple_ = value;
			}
		}
		#endregion
		#region public string Prefix { get; set; }
		internal string prefix_;

		[XmlAttribute("prefix")]
		public string Prefix {
			get {
				return prefix_;
			}
			set {
				prefix_ = value;
			}
		}
		#endregion
		#region public string PrefixGenerated { get; set; }
		internal string prefixgenerated_;

		[XmlAttribute("prefixGenerated")]
		public string PrefixGenerated {
			get {
				return prefixgenerated_;
			}
			set {
				prefixgenerated_ = value;
			}
		}
		#endregion
		#region public string PrefixBase { get; set; }
		internal string prefixbase_;

		[XmlAttribute("prefixBase")]
		public string PrefixBase {
			get {
				return prefixbase_;
			}
			set {
				prefixbase_ = value;
			}
		}
		#endregion
		#region public string PrefixBaseGenerated { get; set; }
		internal string prefixbasegenerated_;

		[XmlAttribute("prefixBaseGenerated")]
		public string PrefixBaseGenerated {
			get {
				return prefixbasegenerated_;
			}
			set {
				prefixbasegenerated_ = value;
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
		#region public string CopyrightTextLong { get; set; }
		internal string copyrighttextlong_;

		[XmlElement("copyrightTextLong")]
		public string CopyrightTextLong {
			get { return copyrighttextlong_; }
			set { copyrighttextlong_ = value; }
		}
		#endregion
		#region public XS_metadataIndexTypeCollection MetadataIndexCollection { get; }
		internal XS_metadataIndexTypeCollection metadataindexcollection_ 
			= new XS_metadataIndexTypeCollection();

		[XmlElement("metadataIndex")]
		public XS_metadataIndexType[] metadataindexcollection__xml {
			get { return metadataindexcollection_.cols__; }
			set { metadataindexcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_metadataIndexTypeCollection MetadataIndexCollection {
			get { return metadataindexcollection_; }
		}
		#endregion
		#region public XS_specificCaseTypeCollection SpecificCaseCollection { get; }
		internal XS_specificCaseTypeCollection specificcasecollection_ 
			= new XS_specificCaseTypeCollection();

		[XmlElement("specificCase")]
		public XS_specificCaseType[] specificcasecollection__xml {
			get { return specificcasecollection_.cols__; }
			set { specificcasecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_specificCaseTypeCollection SpecificCaseCollection {
			get { return specificcasecollection_; }
		}
		#endregion
		#region public XS_complexTypeTypeCollection ComplexTypeCollection { get; }
		internal XS_complexTypeTypeCollection complextypecollection_ 
			= new XS_complexTypeTypeCollection();

		[XmlElement("complexType")]
		public XS_complexTypeType[] complextypecollection__xml {
			get { return complextypecollection_.cols__; }
			set { complextypecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_complexTypeTypeCollection ComplexTypeCollection {
			get { return complextypecollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_metadataType metadataType_in) {
			int _index = -1;

			applicationname_ = metadataType_in.applicationname_;
			namespace_ = metadataType_in.namespace_;
			casetype_ = metadataType_in.casetype_;
			allowsettersonobjects_ = metadataType_in.allowsettersonobjects_;
			issimple_ = metadataType_in.issimple_;
			prefix_ = metadataType_in.prefix_;
			prefixgenerated_ = metadataType_in.prefixgenerated_;
			prefixbase_ = metadataType_in.prefixbase_;
			prefixbasegenerated_ = metadataType_in.prefixbasegenerated_;
			copyrighttext_ = metadataType_in.copyrighttext_;copyrighttextlong_ = metadataType_in.copyrighttextlong_;
			metadataindexcollection_.Clear();
			for (int d = 0; d < metadataType_in.metadataindexcollection_.Count; d++) {
				metadataindexcollection_.Add(
					out _index,
					new XS_metadataIndexType()
				);
				metadataindexcollection_[_index].CopyFrom(
					metadataType_in.metadataindexcollection_[d]
				);
			}
			specificcasecollection_.Clear();
			for (int d = 0; d < metadataType_in.specificcasecollection_.Count; d++) {
				specificcasecollection_.Add(
					out _index,
					new XS_specificCaseType()
				);
				specificcasecollection_[_index].CopyFrom(
					metadataType_in.specificcasecollection_[d]
				);
			}
			complextypecollection_.Clear();
			for (int d = 0; d < metadataType_in.complextypecollection_.Count; d++) {
				complextypecollection_.Add(
					out _index,
					new XS_complexTypeType()
				);
				complextypecollection_[_index].CopyFrom(
					metadataType_in.complextypecollection_[d]
				);
			}
		}
		#endregion
	}
}