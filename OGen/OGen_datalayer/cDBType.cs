#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

*/
#endregion
using System;
using System.Data;

namespace OGen.lib.datalayer {
	public class cDBType {
//		#region public cDBType(...);
		public cDBType(
//eDBServerTypes dbServerType_in
		) {
//			dbservertype_ = dbServerType_in;
		}
//		#endregion

//		#region private Fields...
//		private eDBServerTypes dbservertype_;
//		#endregion

//		#region public Properties...
//		#region public DbType Value;
		private DbType value_;
		public DbType Value {
			get { return value_; }
			set {
				value_ = value;
				fwtype_ = utils.convert.DbType2NSysType(value);
				fwemptyvalue_ = utils.convert.DBType2NSysEmptyValue(value);
				fwunittestvalue_ = utils.convert.DBType2NUnitTestValue(value);
//				dbemptyvalue_ = utils.convert.DBType2DBEmptyValue(value, dbservertype_);
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