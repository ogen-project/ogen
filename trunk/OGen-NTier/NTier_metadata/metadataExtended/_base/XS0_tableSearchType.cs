#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.Libraries.Metadata.MetadataExtended {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_tableSearchType {
	#else
	public partial class XS_tableSearchType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				if (this.tablesearchparameters__ != null) this.tablesearchparameters__.parent_ref = this;
				if (this.tablesearchupdates__ != null) this.tablesearchupdates__.parent_ref = this;
			}
			get { return this.parent_ref_; }
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		internal XS__RootMetadata root_ref_;

		[XmlIgnore()]
		public XS__RootMetadata root_ref {
			set {
				this.root_ref_ = value;
				if (this.tablesearchparameters__ != null) this.tablesearchparameters__.root_ref = value;
				if (this.tablesearchupdates__ != null) this.tablesearchupdates__.root_ref = value;
			}
			get { return this.root_ref_; }
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
		#region public bool IsRange { get; set; }
		internal bool isrange_;

		[XmlAttribute("isRange")]
		public bool IsRange {
			get {
				return this.isrange_;
			}
			set {
				this.isrange_ = value;
			}
		}
		#endregion
		#region public bool IsExplicitUniqueIndex { get; set; }
		internal bool isexplicituniqueindex_;

		[XmlAttribute("isExplicitUniqueIndex")]
		public bool IsExplicitUniqueIndex {
			get {
				return this.isexplicituniqueindex_;
			}
			set {
				this.isexplicituniqueindex_ = value;
			}
		}
		#endregion
		#region public XS_tableSearchParametersType TableSearchParameters { get; set; }
		internal XS_tableSearchParametersType tablesearchparameters__;
		internal object tablesearchparameters__locker = new object();

		[XmlIgnore()]
		public XS_tableSearchParametersType TableSearchParameters {
			get {

				// check before lock
				if (this.tablesearchparameters__ == null) {

					lock (this.tablesearchparameters__locker) {

						// double check, thread safer!
						if (this.tablesearchparameters__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.tablesearchparameters__ = new XS_tableSearchParametersType();
						}
					}
				}

				return this.tablesearchparameters__;
			}
			set {
				this.tablesearchparameters__ = value;
			}
		}

		[XmlElement("tableSearchParameters")]
		public XS_tableSearchParametersType tablesearchparameters__xml {
			get { return this.tablesearchparameters__; }
			set { this.tablesearchparameters__ = value; }
		}
		#endregion
		#region public XS_tableSearchUpdatesType TableSearchUpdates { get; set; }
		internal XS_tableSearchUpdatesType tablesearchupdates__;
		internal object tablesearchupdates__locker = new object();

		[XmlIgnore()]
		public XS_tableSearchUpdatesType TableSearchUpdates {
			get {

				// check before lock
				if (this.tablesearchupdates__ == null) {

					lock (this.tablesearchupdates__locker) {

						// double check, thread safer!
						if (this.tablesearchupdates__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.tablesearchupdates__ = new XS_tableSearchUpdatesType();
						}
					}
				}

				return this.tablesearchupdates__;
			}
			set {
				this.tablesearchupdates__ = value;
			}
		}

		[XmlElement("tableSearchUpdates")]
		public XS_tableSearchUpdatesType tablesearchupdates__xml {
			get { return this.tablesearchupdates__; }
			set { this.tablesearchupdates__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableSearchType tableSearchType_in) {
			this.name_ = tableSearchType_in.name_;
			this.isrange_ = tableSearchType_in.isrange_;
			this.isexplicituniqueindex_ = tableSearchType_in.isexplicituniqueindex_;
			if (tableSearchType_in.tablesearchparameters__ != null) this.tablesearchparameters__.CopyFrom(tableSearchType_in.tablesearchparameters__);
			if (tableSearchType_in.tablesearchupdates__ != null) this.tablesearchupdates__.CopyFrom(tableSearchType_in.tablesearchupdates__);
		}
		#endregion
	}
}