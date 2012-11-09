#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Libraries.Metadata.MetadataDB {
	using System;
	using System.Xml.Serialization;

	using OGen.Libraries.DataLayer;

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
			this.dbservertype_ = dbServerType_in;
		}

		#region public int DBType_inDB { get; set; }
		[XmlIgnore()]
		public int DBType_inDB {
			get {
				return DBUtilitiesSupport.GetInstance(
					(DBServerTypes)Enum.Parse(typeof(DBServerTypes), this.DBServerType)
				).Convert.XDbType_Parse(
					this.DBType, 
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
					=  DBUtilitiesSupport.GetInstance(
						(DBServerTypes)Enum.Parse(typeof(DBServerTypes), this.DBServerType)
					).Convert.XDbType2DbType(
						this.DBType_inDB
					);

				return DBType_generic_out;
			}
		}
		#endregion
		#region public bool IsBoolean { get; }
		[XmlIgnore()]
		public bool IsBoolean {
			get { return DBUtilities.IsBoolean(this.DBType_generic.Value); }
		}
		#endregion
		#region public bool IsDateTime { get; }
		[XmlIgnore()]
		public bool IsDateTime {
			get { return DBUtilities.IsDateTime(this.DBType_generic.Value); }
		}
		#endregion
		#region public bool IsInteger { get; }
		[XmlIgnore()]
		public bool IsInteger {
			get { return DBUtilities.IsInteger(this.DBType_generic.Value); }
		}
		#endregion
		#region public bool IsDecimal { get; }
		[XmlIgnore()]
		public bool IsDecimal {
			get { return DBUtilities.IsDecimal(this.DBType_generic.Value); }
		}
		#endregion
		#region public bool IsText { get; }
		[XmlIgnore()]
		public bool IsText {
			get { return DBUtilities.IsText(this.DBType_generic.Value); }
		}
		#endregion
	}
}
