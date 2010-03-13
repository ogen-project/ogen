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
	public class XS0_rowType {
	#else
	public partial class XS_rowType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				cellcollection_.parent_ref = this;
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
				cellcollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public bool isHeader { get; set; }
		internal bool isheader_;

		[XmlAttribute("isHeader")]
		public bool isHeader {
			get {
				return isheader_;
			}
			set {
				isheader_ = value;
			}
		}
		#endregion
		#region public XS_cellTypeCollection CellCollection { get; }
		internal XS_cellTypeCollection cellcollection_ 
			= new XS_cellTypeCollection();

		[XmlElement("cell")]
		public XS_cellType[] cellcollection__xml {
			get { return cellcollection_.cols__; }
			set { cellcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_cellTypeCollection CellCollection {
			get { return cellcollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_rowType rowType_in) {
			int _index = -1;

			isheader_ = rowType_in.isheader_;
			cellcollection_.Clear();
			for (int d = 0; d < rowType_in.cellcollection_.Count; d++) {
				cellcollection_.Add(
					out _index,
					new XS_cellType()
				);
				cellcollection_[_index].CopyFrom(
					rowType_in.cellcollection_[d]
				);
			}
		}
		#endregion
	}
}