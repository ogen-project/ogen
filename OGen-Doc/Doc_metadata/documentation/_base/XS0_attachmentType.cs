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

namespace OGen.Doc.lib.documentation {
	#if NET_1_1
	public class XS0_attachmentType {
	#else
	public partial class XS_attachmentType {
	#endif
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
		#region public bool ShowTitle { get; set; }
		internal bool showtitle_;

		[XmlAttribute("showTitle")]
		public bool ShowTitle {
			get {
				return showtitle_;
			}
			set {
				showtitle_ = value;
			}
		}
		#endregion
		#region public string Source { get; set; }
		internal string source_;

		[XmlAttribute("source")]
		public string Source {
			get {
				return source_;
			}
			set {
				source_ = value;
			}
		}
		#endregion
		#region public XS_SourceTypeEnumeration SourceType { get; set; }
		internal XS_SourceTypeEnumeration sourcetype_;

		[XmlAttribute("sourceType")]
		public XS_SourceTypeEnumeration SourceType {
			get {
				return sourcetype_;
			}
			set {
				sourcetype_ = value;
			}
		}
		#endregion
		#region public XS_SourceContentTypeEnumeration SourceContentType { get; set; }
		internal XS_SourceContentTypeEnumeration sourcecontenttype_;

		[XmlAttribute("sourceContentType")]
		public XS_SourceContentTypeEnumeration SourceContentType {
			get {
				return sourcecontenttype_;
			}
			set {
				sourcecontenttype_ = value;
			}
		}
		#endregion
		#region public XS_SourceContentStyleEnumeration SourceContentStyle { get; set; }
		internal XS_SourceContentStyleEnumeration sourcecontentstyle_;

		[XmlAttribute("sourceContentStyle")]
		public XS_SourceContentStyleEnumeration SourceContentStyle {
			get {
				return sourcecontentstyle_;
			}
			set {
				sourcecontentstyle_ = value;
			}
		}
		#endregion
		#region public string Description { get; set; }
		internal string description_;

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

		#region public void CopyFrom(...);
		public void CopyFrom(XS_attachmentType attachmentType_in) {
			int _index = -1;

			title_ = attachmentType_in.title_;
			showtitle_ = attachmentType_in.showtitle_;
			source_ = attachmentType_in.source_;
			sourcetype_ = attachmentType_in.sourcetype_;
			sourcecontenttype_ = attachmentType_in.sourcecontenttype_;
			sourcecontentstyle_ = attachmentType_in.sourcecontentstyle_;
			description_ = attachmentType_in.description_;
		}
		#endregion
	}
}