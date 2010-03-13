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

namespace OGen.SpreadsheetXML.lib.metadata.spreadsheet {
	#if NET_1_1
	public class XS0_spreadsheetType {
	#else
	public partial class XS_spreadsheetType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				pagecollection_.parent_ref = this;
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
				pagecollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string Spreadsheet { get; set; }
		internal string spreadsheet_;

		[XmlAttribute("spreadsheet")]
		public string Spreadsheet {
			get {
				return spreadsheet_;
			}
			set {
				spreadsheet_ = value;
			}
		}
		#endregion
		#region public XS_pageTypeCollection PageCollection { get; }
		internal XS_pageTypeCollection pagecollection_ 
			= new XS_pageTypeCollection();

		[XmlElement("page")]
		public XS_pageType[] pagecollection__xml {
			get { return pagecollection_.cols__; }
			set { pagecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_pageTypeCollection PageCollection {
			get { return pagecollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_spreadsheetType spreadsheetType_in) {
			int _index = -1;

			spreadsheet_ = spreadsheetType_in.spreadsheet_;
			pagecollection_.Clear();
			for (int d = 0; d < spreadsheetType_in.pagecollection_.Count; d++) {
				pagecollection_.Add(
					out _index,
					new XS_pageType()
				);
				pagecollection_[_index].CopyFrom(
					spreadsheetType_in.pagecollection_[d]
				);
			}
		}
		#endregion
	}
}