#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.lib.metadata.metadataExtended {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_tableType {
	#else
	public partial class XS_tableType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				if (this.tablefields__ != null) this.tablefields__.parent_ref = this;
				if (this.tablesearches__ != null) this.tablesearches__.parent_ref = this;
				if (this.tableupdates__ != null) this.tableupdates__.parent_ref = this;
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
				if (this.tablefields__ != null) this.tablefields__.root_ref = value;
				if (this.tablesearches__ != null) this.tablesearches__.root_ref = value;
				if (this.tableupdates__ != null) this.tableupdates__.root_ref = value;
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
		#region public string FriendlyName { get; set; }
		internal string friendlyname_;

		[XmlAttribute("friendlyName")]
		public string FriendlyName {
			get {
				return this.friendlyname_;
			}
			set {
				this.friendlyname_ = value;
			}
		}
		#endregion
		#region public string DBDescription { get; set; }
		internal string dbdescription_;

		[XmlAttribute("dbDescription")]
		public string DBDescription {
			get {
				return this.dbdescription_;
			}
			set {
				this.dbdescription_ = value;
			}
		}
		#endregion
		#region public string ExtendedDescription { get; set; }
		internal string extendeddescription_;

		[XmlAttribute("extendedDescription")]
		public string ExtendedDescription {
			get {
				return this.extendeddescription_;
			}
			set {
				this.extendeddescription_ = value;
			}
		}
		#endregion
		#region public bool isVirtualTable { get; set; }
		internal bool isvirtualtable_;

		[XmlAttribute("isVirtualTable")]
		public bool isVirtualTable {
			get {
				return this.isvirtualtable_;
			}
			set {
				this.isvirtualtable_ = value;
			}
		}
		#endregion
		#region public bool isConfig { get; set; }
		internal bool isconfig_;

		[XmlAttribute("isConfig")]
		public bool isConfig {
			get {
				return this.isconfig_;
			}
			set {
				this.isconfig_ = value;
			}
		}
		#endregion
		#region public string ConfigName { get; set; }
		internal string configname_;

		[XmlAttribute("configName")]
		public string ConfigName {
			get {
				return this.configname_;
			}
			set {
				this.configname_ = value;
			}
		}
		#endregion
		#region public string ConfigConfig { get; set; }
		internal string configconfig_;

		[XmlAttribute("configConfig")]
		public string ConfigConfig {
			get {
				return this.configconfig_;
			}
			set {
				this.configconfig_ = value;
			}
		}
		#endregion
		#region public string ConfigDatatype { get; set; }
		internal string configdatatype_;

		[XmlAttribute("configDatatype")]
		public string ConfigDatatype {
			get {
				return this.configdatatype_;
			}
			set {
				this.configdatatype_ = value;
			}
		}
		#endregion
		#region public XS_tableFieldsType TableFields { get; set; }
		internal XS_tableFieldsType tablefields__;
		internal object tablefields__locker = new object();

		[XmlIgnore()]
		public XS_tableFieldsType TableFields {
			get {

				// check before lock
				if (this.tablefields__ == null) {

					lock (this.tablefields__locker) {

						// double check, thread safer!
						if (this.tablefields__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.tablefields__ = new XS_tableFieldsType();
						}
					}
				}

				return this.tablefields__;
			}
			set {
				this.tablefields__ = value;
			}
		}

		[XmlElement("tableFields")]
		public XS_tableFieldsType tablefields__xml {
			get { return this.tablefields__; }
			set { this.tablefields__ = value; }
		}
		#endregion
		#region public XS_tableSearchesType TableSearches { get; set; }
		internal XS_tableSearchesType tablesearches__;
		internal object tablesearches__locker = new object();

		[XmlIgnore()]
		public XS_tableSearchesType TableSearches {
			get {

				// check before lock
				if (this.tablesearches__ == null) {

					lock (this.tablesearches__locker) {

						// double check, thread safer!
						if (this.tablesearches__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.tablesearches__ = new XS_tableSearchesType();
						}
					}
				}

				return this.tablesearches__;
			}
			set {
				this.tablesearches__ = value;
			}
		}

		[XmlElement("tableSearches")]
		public XS_tableSearchesType tablesearches__xml {
			get { return this.tablesearches__; }
			set { this.tablesearches__ = value; }
		}
		#endregion
		#region public XS_tableUpdatesType TableUpdates { get; set; }
		internal XS_tableUpdatesType tableupdates__;
		internal object tableupdates__locker = new object();

		[XmlIgnore()]
		public XS_tableUpdatesType TableUpdates {
			get {

				// check before lock
				if (this.tableupdates__ == null) {

					lock (this.tableupdates__locker) {

						// double check, thread safer!
						if (this.tableupdates__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.tableupdates__ = new XS_tableUpdatesType();
						}
					}
				}

				return this.tableupdates__;
			}
			set {
				this.tableupdates__ = value;
			}
		}

		[XmlElement("tableUpdates")]
		public XS_tableUpdatesType tableupdates__xml {
			get { return this.tableupdates__; }
			set { this.tableupdates__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableType tableType_in) {
			this.name_ = tableType_in.name_;
			this.friendlyname_ = tableType_in.friendlyname_;
			this.dbdescription_ = tableType_in.dbdescription_;
			this.extendeddescription_ = tableType_in.extendeddescription_;
			this.isvirtualtable_ = tableType_in.isvirtualtable_;
			this.isconfig_ = tableType_in.isconfig_;
			this.configname_ = tableType_in.configname_;
			this.configconfig_ = tableType_in.configconfig_;
			this.configdatatype_ = tableType_in.configdatatype_;
			if (tableType_in.tablefields__ != null) this.tablefields__.CopyFrom(tableType_in.tablefields__);
			if (tableType_in.tablesearches__ != null) this.tablesearches__.CopyFrom(tableType_in.tablesearches__);
			if (tableType_in.tableupdates__ != null) this.tableupdates__.CopyFrom(tableType_in.tableupdates__);
		}
		#endregion
	}
}