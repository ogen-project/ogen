#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Data;

namespace OGen.lib.datalayer {
	public class cDBType {
//		#region public cDBType(...);
		public cDBType(
//DBServerTypes dbServerType_in
		) {
//			dbservertype_ = dbServerType_in;
		}
//		#endregion

//		#region private Fields...
//		private DBServerTypes dbservertype_;
//		#endregion

//		#region public Properties...
//		#region public DbType Value;
		private DbType value_;
		public DbType Value {
			get { return value_; }
			set {
				value_ = value;
				fwtype_ = DBUtils_convert.DbType2NSysType(value);
				fwemptyvalue_ = DBUtils_convert.DBType2NSysEmptyValue(value);
				fwunittestvalue_ = DBUtils_convert.DBType2NUnitTestValue(value);
//				dbemptyvalue_ = DBUtils_convert.DBType2DBEmptyValue(value, dbservertype_);
			}
		}
//		#endregion

		#region public string FWType;
		private string fwtype_;
		public string FWType {
			get { return fwtype_; }
		}
		#endregion
		#region public string FWEmptyValue;
		private string fwemptyvalue_;
		public string FWEmptyValue {
			get { return fwemptyvalue_; }
		}
		#endregion
		#region public string FWUnitTestValue;
		private string fwunittestvalue_;
		public string FWUnitTestValue {
			get { return fwunittestvalue_; }
		}
		#endregion
//		#region public string DBEmptyValue;
//		private string dbemptyvalue_;
//		public string DBEmptyValue {
//			get { return dbemptyvalue_; }
//		}
//		#endregion
//		#endregion
	}
}
