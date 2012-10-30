#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.Doc.lib.metadata.documentation {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

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
				this.parent_ref_ = value;
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
				this.root_ref_ = value;
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
				return this.title_;
			}
			set {
				this.title_ = value;
			}
		}
		#endregion
		#region public string SubTitle { get; set; }
		internal string subtitle_;

		[XmlAttribute("subTitle")]
		public string SubTitle {
			get {
				return this.subtitle_;
			}
			set {
				this.subtitle_ = value;
			}
		}
		#endregion
		#region public bool IsIntroduction { get; set; }
		internal bool isintroduction_;

		[XmlAttribute("isIntroduction")]
		public bool IsIntroduction {
			get {
				return this.isintroduction_;
			}
			set {
				this.isintroduction_ = value;
			}
		}
		#endregion
		#region public bool IsSummary { get; set; }
		internal bool issummary_;

		[XmlAttribute("isSummary")]
		public bool IsSummary {
			get {
				return this.issummary_;
			}
			set {
				this.issummary_ = value;
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
				if (this.attachments__ == null) {

					lock (this.attachments__locker) {

						// double check, thread safer!
						if (this.attachments__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.attachments__ = new XS_attachmentsType();
						}
					}
				}

				return this.attachments__;
			}
			set {
				this.attachments__ = value;
			}
		}

		[XmlElement("attachments")]
		public XS_attachmentsType attachments__xml {
			get { return this.attachments__; }
			set { this.attachments__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_itemType itemType_in) {
			this.title_ = itemType_in.title_;
			this.subtitle_ = itemType_in.subtitle_;
			this.isintroduction_ = itemType_in.isintroduction_;
			this.issummary_ = itemType_in.issummary_;
			if (itemType_in.attachments__ != null) this.attachments__.CopyFrom(itemType_in.attachments__);
		}
		#endregion
	}
}