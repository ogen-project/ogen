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

using OGen.lib.collections;
using OGen.lib.datalayer;

namespace OGen.NTier.lib.metadata.metadataDB {
	#if NET_1_1
	public class XS_tableFieldDBType : XS0_tableFieldDBType {
	#else
	public partial class XS_tableFieldDBType {
	#endif
		public XS_tableFieldDBType (
		) {
		}
		public XS_tableFieldDBType (
			string dbServerType_in
		) {
			dbservertype_ = dbServerType_in;
		}

		#region public int DBType_inDB { get; set; }
		[XmlIgnore()]
		public int DBType_inDB {
			get {
				return DBUtilssupport.GetInstance(
					(DBServerTypes)Enum.Parse(typeof(DBServerTypes), DBServerType)
				).Convert.XDbType_Parse(
					DBType, 
					false
				);
			}
		}
		#endregion
		#region public cDBType DBType_generic { get; }
		[XmlIgnore()]
		public cDBType DBType_generic {
			get {
				cDBType DBType_generic_out = new cDBType(
//					dbservertype_
				);
				DBType_generic_out.Value 
					=  DBUtilssupport.GetInstance(
						(DBServerTypes)Enum.Parse(typeof(DBServerTypes), DBServerType)
					).Convert.XDbType2DbType(
						DBType_inDB
					);

				return DBType_generic_out;
			}
		}
		#endregion
		#region public bool isBool { get; }
		[XmlIgnore()]
		public bool isBool {
			get { return DBUtils.isBool(DBType_generic.Value); }
		}
		#endregion
		#region public bool isDateTime { get; }
		[XmlIgnore()]
		public bool isDateTime {
			get { return DBUtils.isDateTime(DBType_generic.Value); }
		}
		#endregion
		#region public bool isInt { get; }
		[XmlIgnore()]
		public bool isInt {
			get { return DBUtils.isInt(DBType_generic.Value); }
		}
		#endregion
		#region public bool isDecimal { get; }
		[XmlIgnore()]
		public bool isDecimal {
			get { return DBUtils.isDecimal(DBType_generic.Value); }
		}
		#endregion
		#region public bool isText { get; }
		[XmlIgnore()]
		public bool isText {
			get { return DBUtils.isText(DBType_generic.Value); }
		}
		#endregion
	}
}
