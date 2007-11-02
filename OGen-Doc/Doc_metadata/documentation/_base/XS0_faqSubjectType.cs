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
	public class XS0_faqSubjectType
#if !NET_1_1
		: OGenRootrefCollectionInterface<XS__RootMetadata> , OGenCollectionInterface<string>
#endif
	{
		public XS0_faqSubjectType (
		) {
			faqcollection_ = new 
#if !NET_1_1
				OGenRootrefCollection<XS_faqType, XS__RootMetadata>()
#else
				XS_faqTypeCollection()
#endif
			;
		}
		public XS0_faqSubjectType (
			string idFAQSubject_in
		) : this (
		) {
			idfaqsubject_ = idFAQSubject_in;
		}

#if !NET_1_1
		#region public string CollectionName { get; }
		[XmlIgnore()]
		public string CollectionName {
			get {
				return IDFAQSubject;
			}
		}
		#endregion
#endif

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				faqcollection_.parent_ref = this;
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
				faqcollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string IDFAQSubject { get; set; }
		private string idfaqsubject_;

		[XmlAttribute("idFAQSubject")]
		public string IDFAQSubject {
			get {
				return idfaqsubject_;
			}
			set {
				idfaqsubject_ = value;
			}
		}
		#endregion
		#region public string IDFAQSubject_parent { get; set; }
		private string idfaqsubject_parent_;

		[XmlAttribute("idFAQSubject_parent")]
		public string IDFAQSubject_parent {
			get {
				return idfaqsubject_parent_;
			}
			set {
				idfaqsubject_parent_ = value;
			}
		}
		#endregion
		#region public string Name { get; set; }
		private string name_;

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
		private string description_;

		[XmlAttribute("description")]
		public string Description {
			get {
				return description_;
			}
			set {
				description_ = value;
			}
		}
		#endregion
		#region public ... FAQCollection { get; }
		private 
#if !NET_1_1
			OGenRootrefCollection<XS_faqType, XS__RootMetadata>
#else
			XS_faqTypeCollection
#endif
			faqcollection_;

		[XmlElement("faq")]
		public XS_faqType[] faqcollection__xml {
			get { return faqcollection_.cols__; }
			set { faqcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public
#if !NET_1_1
			OGenRootrefCollection<XS_faqType, XS__RootMetadata>
#else
			XS_faqTypeCollection
#endif
		FAQCollection
		{
			get { return faqcollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_faqSubjectType faqSubjectType_in) {
			int _index = -1;

			idfaqsubject_ = faqSubjectType_in.idfaqsubject_;
			idfaqsubject_parent_ = faqSubjectType_in.idfaqsubject_parent_;
			name_ = faqSubjectType_in.name_;
			description_ = faqSubjectType_in.description_;
			faqcollection_.Clear();
			for (int d = 0; d < faqSubjectType_in.faqcollection_.Count; d++) {
				faqcollection_.Add(
					out _index,
					new XS_faqType()
				);
				faqcollection_[_index].CopyFrom(
					faqSubjectType_in.faqcollection_[d]
				);
			}
		}
		#endregion
	}
}