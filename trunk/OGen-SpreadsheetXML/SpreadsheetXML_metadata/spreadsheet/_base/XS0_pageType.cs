#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.SpreadsheetXML.lib.metadata.spreadsheet {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_pageType {
	#else
	public partial class XS_pageType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				rowcollection_.parent_ref = this;
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
				rowcollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string Name { get; set; }
		internal string name_;

		[XmlAttribute("name")]
		public string Name {
			get {
				return this.name_;
			}
			set {
				this.name_ = value;
			}
		}
		#endregion
		#region public XS_rowTypeCollection RowCollection { get; }
		internal XS_rowTypeCollection rowcollection_ 
			= new XS_rowTypeCollection();

		[XmlElement("row")]
		public XS_rowType[] rowcollection__xml {
			get { return this.rowcollection_.cols__; }
			set { this.rowcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_rowTypeCollection RowCollection {
			get { return this.rowcollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_pageType pageType_in) {
			int _index = -1;

			this.name_ = pageType_in.name_;
			this.rowcollection_.Clear();
			for (int d = 0; d < pageType_in.rowcollection_.Count; d++) {
				this.rowcollection_.Add(
					out _index,
					new XS_rowType()
				);
				this.rowcollection_[_index].CopyFrom(
					pageType_in.rowcollection_[d]
				);
			}
		}
		#endregion
	}
}