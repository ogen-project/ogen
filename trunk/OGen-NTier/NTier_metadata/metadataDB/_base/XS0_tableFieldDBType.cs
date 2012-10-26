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

namespace OGen.NTier.lib.metadata.metadataDB {
	#if NET_1_1
	public class XS0_tableFieldDBType {
	#else
	public partial class XS_tableFieldDBType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
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
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string DBServerType { get; set; }
		internal string dbservertype_;

		[XmlAttribute("dbServerType")]
		public string DBServerType {
			get {
				return dbservertype_;
			}
			set {
				dbservertype_ = value;
			}
		}
		#endregion
		#region public string DBType { get; set; }
		internal string dbtype_;

		[XmlAttribute("dbType")]
		public string DBType {
			get {
				return dbtype_;
			}
			set {
				dbtype_ = value;
			}
		}
		#endregion
		#region public string DBDescription { get; set; }
		internal string dbdescription_;

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
		#region public string DBDefaultValue { get; set; }
		internal string dbdefaultvalue_;

		[XmlAttribute("dbDefaultValue")]
		public string DBDefaultValue {
			get {
				return dbdefaultvalue_;
			}
			set {
				dbdefaultvalue_ = value;
			}
		}
		#endregion
		#region public string DBCollationName { get; set; }
		internal string dbcollationname_;

		[XmlAttribute("dbCollationName")]
		public string DBCollationName {
			get {
				return dbcollationname_;
			}
			set {
				dbcollationname_ = value;
			}
		}
		#endregion
		#region public string DBFieldName { get; set; }
		internal string dbfieldname_;

		[XmlAttribute("dbFieldName")]
		public string DBFieldName {
			get {
				return dbfieldname_;
			}
			set {
				dbfieldname_ = value;
			}
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableFieldDBType tableFieldDBType_in) {
			dbservertype_ = tableFieldDBType_in.dbservertype_;
			dbtype_ = tableFieldDBType_in.dbtype_;
			dbdescription_ = tableFieldDBType_in.dbdescription_;
			dbdefaultvalue_ = tableFieldDBType_in.dbdefaultvalue_;
			dbcollationname_ = tableFieldDBType_in.dbcollationname_;
			dbfieldname_ = tableFieldDBType_in.dbfieldname_;
		}
		#endregion
	}
}