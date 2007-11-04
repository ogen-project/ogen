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

namespace OGen.NTier.lib.metadata.metadataExtended {
	public class XS0_tableSearchType {
		public XS0_tableSearchType (
		) {
		}
		public XS0_tableSearchType (
			string name_in
		) : this (
		) {
			name_ = name_in;
		}

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (tablesearchparameters__ != null) tablesearchparameters__.parent_ref = this;
				if (tablesearchupdates__ != null) tablesearchupdates__.parent_ref = this;
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
				if (tablesearchparameters__ != null) tablesearchparameters__.root_ref = value;
				if (tablesearchupdates__ != null) tablesearchupdates__.root_ref = value;
			}
			get { return root_ref_; }
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
		#region public bool isRange { get; set; }
		private bool isrange_;

		[XmlAttribute("isRange")]
		public bool isRange {
			get {
				return isrange_;
			}
			set {
				isrange_ = value;
			}
		}
		#endregion
		#region public bool isExplicitUniqueIndex { get; set; }
		private bool isexplicituniqueindex_;

		[XmlAttribute("isExplicitUniqueIndex")]
		public bool isExplicitUniqueIndex {
			get {
				return isexplicituniqueindex_;
			}
			set {
				isexplicituniqueindex_ = value;
			}
		}
		#endregion
		#region public XS_tableSearchParametersType TableSearchParameters { get; set; }
		private XS_tableSearchParametersType tablesearchparameters__;

		[XmlIgnore()]
		public XS_tableSearchParametersType TableSearchParameters {
			get {
				if (tablesearchparameters__ == null) {
					tablesearchparameters__ = new XS_tableSearchParametersType();
				}
				return tablesearchparameters__;
			}
			set {
				tablesearchparameters__ = value;
			}
		}

		[XmlElement("tableSearchParameters")]
		public XS_tableSearchParametersType tablesearchparameters__xml {
			get { return tablesearchparameters__; }
			set { tablesearchparameters__ = value; }
		}
		#endregion
		#region public XS_tableSearchUpdatesType TableSearchUpdates { get; set; }
		private XS_tableSearchUpdatesType tablesearchupdates__;

		[XmlIgnore()]
		public XS_tableSearchUpdatesType TableSearchUpdates {
			get {
				if (tablesearchupdates__ == null) {
					tablesearchupdates__ = new XS_tableSearchUpdatesType();
				}
				return tablesearchupdates__;
			}
			set {
				tablesearchupdates__ = value;
			}
		}

		[XmlElement("tableSearchUpdates")]
		public XS_tableSearchUpdatesType tablesearchupdates__xml {
			get { return tablesearchupdates__; }
			set { tablesearchupdates__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableSearchType tableSearchType_in) {
			int _index = -1;

			name_ = tableSearchType_in.name_;
			isrange_ = tableSearchType_in.isrange_;
			isexplicituniqueindex_ = tableSearchType_in.isexplicituniqueindex_;
			if (tableSearchType_in.tablesearchparameters__ != null) tablesearchparameters__.CopyFrom(tableSearchType_in.tablesearchparameters__);
			if (tableSearchType_in.tablesearchupdates__ != null) tablesearchupdates__.CopyFrom(tableSearchType_in.tablesearchupdates__);
		}
		#endregion
	}
}