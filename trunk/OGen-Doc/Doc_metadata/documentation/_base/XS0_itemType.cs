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
	public class XS0_itemType {
	#else
	public partial class XS_itemType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (attachments__ != null) attachments__.parent_ref = this;
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
				if (attachments__ != null) attachments__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string Title { get; set; }
		internal string title_;

		[XmlAttribute("title")]
		public string Title {
			get {
				return title_;
			}
			set {
				title_ = value;
			}
		}
		#endregion
		#region public string SubTitle { get; set; }
		internal string subtitle_;

		[XmlAttribute("subTitle")]
		public string SubTitle {
			get {
				return subtitle_;
			}
			set {
				subtitle_ = value;
			}
		}
		#endregion
		#region public bool IsIntroduction { get; set; }
		internal bool isintroduction_;

		[XmlAttribute("isIntroduction")]
		public bool IsIntroduction {
			get {
				return isintroduction_;
			}
			set {
				isintroduction_ = value;
			}
		}
		#endregion
		#region public bool IsSummary { get; set; }
		internal bool issummary_;

		[XmlAttribute("isSummary")]
		public bool IsSummary {
			get {
				return issummary_;
			}
			set {
				issummary_ = value;
			}
		}
		#endregion
		#region public XS_attachmentsType Attachments { get; set; }
		internal XS_attachmentsType attachments__;
		internal object attachments__locker = new object();

		[XmlIgnore()]
		public XS_attachmentsType Attachments {
			get {

				// check before lock
				if (attachments__ == null) {

					lock (attachments__locker) {

						// double check, thread safer!
						if (attachments__ == null) {

							attachments__ = new XS_attachmentsType();
						}
					}
				}

				return attachments__;
			}
			set {
				attachments__ = value;
			}
		}

		[XmlElement("attachments")]
		public XS_attachmentsType attachments__xml {
			get { return attachments__; }
			set { attachments__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_itemType itemType_in) {
			int _index = -1;

			title_ = itemType_in.title_;
			subtitle_ = itemType_in.subtitle_;
			isintroduction_ = itemType_in.isintroduction_;
			issummary_ = itemType_in.issummary_;
			if (itemType_in.attachments__ != null) attachments__.CopyFrom(itemType_in.attachments__);
		}
		#endregion
	}
}