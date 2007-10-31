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

namespace OGen.NTier.lib.metadata.metadataDB {
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
				if (tabledbs__ != null) tabledbs__.parent_ref = this;
				if (tablefields__ != null) tablefields__.parent_ref = this;
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
				if (tabledbs__ != null) tabledbs__.root_ref = value;
				if (tablefields__ != null) tablefields__.root_ref = value;
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
		#region public XS_tableDBsType TableDBs { get; set; }
		private XS_tableDBsType tabledbs__;

		[XmlIgnore()]
		public XS_tableDBsType TableDBs {
			get {
				if (tabledbs__ == null) {
					tabledbs__ = new XS_tableDBsType();
				}
				return tabledbs__;
			}
			set {
				tabledbs__ = value;
			}
		}

		[XmlElement("tableDBs")]
		public XS_tableDBsType tabledbs__xml {
			get { return tabledbs__; }
			set { tabledbs__ = value; }
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
	}
}