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
	#region public struct KEY_tableFieldDBType { ... }
	public struct KEY_tableFieldDBType {
		public KEY_tableFieldDBType(
			KeyEnum type_in,
			object value_in
		) {
			Type = type_in;
			Value = value_in;
		}

		public enum KeyEnum : int {
			DBServerType = 0,
			DBType = 1
		}

		public KeyEnum Type;
		public object Value;
	}
	#endregion

	public class XS0_tableFieldDBType
#if !NET_1_1
		: 
			OGenRootrefCollectionInterface<XS__RootMetadata>, 
			OGenCollectionInterface<XS_tableFieldDBType, KEY_tableFieldDBType>
#endif
	{
		public XS0_tableFieldDBType (
		) {
		}
		public XS0_tableFieldDBType (
			string dbServerType_in
		) : this (
		) {
			dbservertype_ = dbServerType_in;
		}

#if !NET_1_1
		//#region public string CollectionName { get; }
		//[XmlIgnore()]
		//public string CollectionName {
		//    get {
		//        return DBServerType;
		//    }
		//}
		//#endregion

		#region public KEY_tableFieldDBType[] Keys { get; }
		private KEY_tableFieldDBType[] keys__ = null;

		public KEY_tableFieldDBType[] Keys {
			get {
				if (keys__ == null) {
					keys__ = new KEY_tableFieldDBType[] {
						new KEY_tableFieldDBType(KEY_tableFieldDBType.KeyEnum.DBServerType, dbservertype_), 
						new KEY_tableFieldDBType(KEY_tableFieldDBType.KeyEnum.DBType, dbtype_)
					};
				} else {
					keys__[0].Value = dbservertype_;
					keys__[1].Value = dbtype_;
				}
				return keys__;
			}
		}
		#endregion
		#region	public bool Keys_compare(params KEY_tableFieldDBType[] keys_in);
		public bool Keys_compare(params KEY_tableFieldDBType[] keys_in) {
			int _keyMatches = 0;
			for (int k = 0; k < keys_in.Length; k++) {
				switch (keys_in[k].Type) {
					case KEY_tableFieldDBType.KeyEnum.DBServerType:
						if (
							((string)keys_in[k].Value).ToLower() 
							== 
							dbservertype_.ToLower()
						)
							_keyMatches++;
						else 
							return false;
						break;
					case KEY_tableFieldDBType.KeyEnum.DBType:
						if (
							(string)keys_in[k].Value 
							== 
							dbtype_
						)
							_keyMatches++;
						else 
							return false;
						break;
					default:
						throw new Exception("...");
				}
			}

			return (
				_keyMatches == keys_in.Length
			);
		}
		#endregion
		#region public bool Equals_compareKeysOnly(XS_tableFieldDBType tableFieldDBType_in);
		public bool Equals_compareKeysOnly(XS_tableFieldDBType tableFieldDBType_in) {
			return Keys_compare(tableFieldDBType_in.Keys());
		}
		#endregion
		#region public static KEY_tableFieldDBType[] Keys_builder(...);
		public static KEY_tableFieldDBType[] Keys_builder(
			string dbServerType_in, 
			string dbType_in
		) {
			return new KEY_tableFieldDBType[] {
				new KEY_tableFieldDBType(
					KEY_tableFieldDBType.KeyEnum.DBServerType, 
					dbServerType_in
				), 
				new KEY_tableFieldDBType(
					KEY_tableFieldDBType.KeyEnum.DBType, 
					dbType_in
				)
			};
		}
		#endregion
#endif

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
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
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string DBServerType { get; set; }
		private string dbservertype_;

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
		private string dbtype_;

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
		#region public string DBDefaultValue { get; set; }
		private string dbdefaultvalue_;

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
		private string dbcollationname_;

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
		private string dbfieldname_;

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
			int _index = -1;

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