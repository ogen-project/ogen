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
	public class XS0_chapterType {
	#else
	public partial class XS_chapterType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				if (items__ != null) items__.parent_ref = this;
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
				if (items__ != null) items__.root_ref = value;
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
		#region public string FileName { get; set; }
		internal string filename_;

		[XmlAttribute("fileName")]
		public string FileName {
			get {
				return this.filename_;
			}
			set {
				this.filename_ = value;
			}
		}
		#endregion
		#region public string Subtitle { get; set; }
		internal string subtitle_;

		[XmlAttribute("subtitle")]
		public string Subtitle {
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
		#region public bool IsAppendix { get; set; }
		internal bool isappendix_;

		[XmlAttribute("isAppendix")]
		public bool IsAppendix {
			get {
				return this.isappendix_;
			}
			set {
				this.isappendix_ = value;
			}
		}
		#endregion
		#region public XS_itemsType Items { get; set; }
		internal XS_itemsType items__;
		internal object items__locker = new object();

		[XmlIgnore()]
		public XS_itemsType Items {
			get {

				// check before lock
				if (this.items__ == null) {

					lock (this.items__locker) {

						// double check, thread safer!
						if (this.items__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.items__ = new XS_itemsType();
						}
					}
				}

				return this.items__;
			}
			set {
				this.items__ = value;
			}
		}

		[XmlElement("items")]
		public XS_itemsType items__xml {
			get { return this.items__; }
			set { this.items__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_chapterType chapterType_in) {
			this.title_ = chapterType_in.title_;
			this.filename_ = chapterType_in.filename_;
			this.subtitle_ = chapterType_in.subtitle_;
			this.isintroduction_ = chapterType_in.isintroduction_;
			this.isappendix_ = chapterType_in.isappendix_;
			if (chapterType_in.items__ != null) this.items__.CopyFrom(chapterType_in.items__);
		}
		#endregion
	}
}