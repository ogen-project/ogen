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
	public class XS0_tableType
#if !NET_1_1
		: OGenRootrefCollectionInterface<XS__RootMetadata> , OGenCollectionInterface<string>
#endif
	{
		public XS0_tableType (
		) {
		}
		public XS0_tableType (
			string name_in
		) : this (
		) {
			name_ = name_in;
		}

#if !NET_1_1
		#region public string CollectionName { get; }
		[XmlIgnore()]
		public string CollectionName {
			get {
				return Name;
			}
		}
		#endregion
#endif

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (tablefields__ != null) tablefields__.parent_ref = this;
				if (tablesearches__ != null) tablesearches__.parent_ref = this;
				if (tableupdates__ != null) tableupdates__.parent_ref = this;
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
				if (tablefields__ != null) tablefields__.root_ref = value;
				if (tablesearches__ != null) tablesearches__.root_ref = value;
				if (tableupdates__ != null) tableupdates__.root_ref = value;
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
		#region public string FriendlyName { get; set; }
		private string friendlyname_;

		[XmlAttribute("friendlyName")]
		public string FriendlyName {
			get {
				return friendlyname_;
			}
			set {
				friendlyname_ = value;
			}
		}
		#endregion
		#region public string DBDescription { get; set; }
		private string dbdescription_;

		[XmlAttribute("dbDescription")]
		public string DBDescription {
			get {
				return dbdescription_;
			}
			set {
				dbdescription_ = value;
			}
		}
		#endregion
		#region public string ExtendedDescription { get; set; }
		private string extendeddescription_;

		[XmlAttribute("extendedDescription")]
		public string ExtendedDescription {
			get {
				return extendeddescription_;
			}
			set {
				extendeddescription_ = value;
			}
		}
		#endregion
		#region public bool isVirtualTable { get; set; }
		private bool isvirtualtable_;

		[XmlAttribute("isVirtualTable")]
		public bool isVirtualTable {
			get {
				return isvirtualtable_;
			}
			set {
				isvirtualtable_ = value;
			}
		}
		#endregion
		#region public bool isConfig { get; set; }
		private bool isconfig_;

		[XmlAttribute("isConfig")]
		public bool isConfig {
			get {
				return isconfig_;
			}
			set {
				isconfig_ = value;
			}
		}
		#endregion
		#region public string ConfigName { get; set; }
		private string configname_;

		[XmlAttribute("configName")]
		public string ConfigName {
			get {
				return configname_;
			}
			set {
				configname_ = value;
			}
		}
		#endregion
		#region public string ConfigConfig { get; set; }
		private string configconfig_;

		[XmlAttribute("configConfig")]
		public string ConfigConfig {
			get {
				return configconfig_;
			}
			set {
				configconfig_ = value;
			}
		}
		#endregion
		#region public string ConfigDatatype { get; set; }
		private string configdatatype_;

		[XmlAttribute("configDatatype")]
		public string ConfigDatatype {
			get {
				return configdatatype_;
			}
			set {
				configdatatype_ = value;
			}
		}
		#endregion
		#region public XS_tableFieldsType TableFields { get; set; }
		private XS_tableFieldsType tablefields__;

		[XmlIgnore()]
		public XS_tableFieldsType TableFields {
			get {
				if (tablefields__ == null) {
					tablefields__ = new XS_tableFieldsType();
				}
				return tablefields__;
			}
			set {
				tablefields__ = value;
			}
		}

		[XmlElement("tableFields")]
		public XS_tableFieldsType tablefields__xml {
			get { return tablefields__; }
			set { tablefields__ = value; }
		}
		#endregion
		#region public XS_tableSearchesType TableSearches { get; set; }
		private XS_tableSearchesType tablesearches__;

		[XmlIgnore()]
		public XS_tableSearchesType TableSearches {
			get {
				if (tablesearches__ == null) {
					tablesearches__ = new XS_tableSearchesType();
				}
				return tablesearches__;
			}
			set {
				tablesearches__ = value;
			}
		}

		[XmlElement("tableSearches")]
		public XS_tableSearchesType tablesearches__xml {
			get { return tablesearches__; }
			set { tablesearches__ = value; }
		}
		#endregion
		#region public XS_tableUpdatesType TableUpdates { get; set; }
		private XS_tableUpdatesType tableupdates__;

		[XmlIgnore()]
		public XS_tableUpdatesType TableUpdates {
			get {
				if (tableupdates__ == null) {
					tableupdates__ = new XS_tableUpdatesType();
				}
				return tableupdates__;
			}
			set {
				tableupdates__ = value;
			}
		}

		[XmlElement("tableUpdates")]
		public XS_tableUpdatesType tableupdates__xml {
			get { return tableupdates__; }
			set { tableupdates__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableType tableType_in) {
			int _index = -1;

			name_ = tableType_in.name_;
			friendlyname_ = tableType_in.friendlyname_;
			dbdescription_ = tableType_in.dbdescription_;
			extendeddescription_ = tableType_in.extendeddescription_;
			isvirtualtable_ = tableType_in.isvirtualtable_;
			isconfig_ = tableType_in.isconfig_;
			configname_ = tableType_in.configname_;
			configconfig_ = tableType_in.configconfig_;
			configdatatype_ = tableType_in.configdatatype_;
			if (tableType_in.tablefields__ != null) tablefields__.CopyFrom(tableType_in.tablefields__);
			if (tableType_in.tablesearches__ != null) tablesearches__.CopyFrom(tableType_in.tablesearches__);
			if (tableType_in.tableupdates__ != null) tableupdates__.CopyFrom(tableType_in.tableupdates__);
		}
		#endregion
	}
}