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
	public class XS0_chapterType {
	#else
	public partial class XS_chapterType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
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
				root_ref_ = value;
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
				return title_;
			}
			set {
				title_ = value;
			}
		}
		#endregion
		#region public string FileName { get; set; }
		internal string filename_;

		[XmlAttribute("fileName")]
		public string FileName {
			get {
				return filename_;
			}
			set {
				filename_ = value;
			}
		}
		#endregion
		#region public string Subtitle { get; set; }
		internal string subtitle_;

		[XmlAttribute("subtitle")]
		public string Subtitle {
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
		#region public bool IsAppendix { get; set; }
		internal bool isappendix_;

		[XmlAttribute("isAppendix")]
		public bool IsAppendix {
			get {
				return isappendix_;
			}
			set {
				isappendix_ = value;
			}
		}
		#endregion
		#region public XS_itemsType Items { get; set; }
		internal XS_itemsType items__;

		[XmlIgnore()]
		public XS_itemsType Items {
			get {
				if (items__ == null) {
					items__ = new XS_itemsType();
				}
				return items__;
			}
			set {
				items__ = value;
			}
		}

		[XmlElement("items")]
		public XS_itemsType items__xml {
			get { return items__; }
			set { items__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_chapterType chapterType_in) {
			int _index = -1;

			title_ = chapterType_in.title_;
			filename_ = chapterType_in.filename_;
			subtitle_ = chapterType_in.subtitle_;
			isintroduction_ = chapterType_in.isintroduction_;
			isappendix_ = chapterType_in.isappendix_;
			if (chapterType_in.items__ != null) items__.CopyFrom(chapterType_in.items__);
		}
		#endregion
	}
}