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
using System.Data;
using NUnit.Framework;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.lib.datalayer.UTs {
	internal class UT0__utils {
		private UT0__utils() {}
		#region static UT0__utils();
		static UT0__utils() {
			dbconnections__ = null;
		}
		#endregion

		#region public static DBConnection[] DBConnections { get; }
		private static DBConnection[] dbconnections__;
		public static DBConnection[] DBConnections {
			get {
				if (dbconnections__ == null) {
					Config_DBConnectionstring _dbcon;

					int _count = 0;
					for (int _db = 0; _db < Config_DBConnectionstrings.DBServerTypes(DO__utils.ApplicationName).Length; _db++) {
						_dbcon = Config_DBConnectionstrings.DBConnectionstrings(DO__utils.ApplicationName)[
							Config_DBConnectionstrings.DBServerTypes(DO__utils.ApplicationName)[_db], 
							"DEBUG"
						];
						if (_dbcon.GeneratedSQL) {
							_count++;
						}
					}

					dbconnections__ = new DBConnection[_count];
					_count = 0;
					for (int _db = 0; _db < Config_DBConnectionstrings.DBServerTypes(DO__utils.ApplicationName).Length; _db++) {
						_dbcon = Config_DBConnectionstrings.DBConnectionstrings(DO__utils.ApplicationName)[
							Config_DBConnectionstrings.DBServerTypes(DO__utils.ApplicationName)[_db],
							"DEBUG"
						];
						if (_dbcon.GeneratedSQL) {
							dbconnections__[_count++]
#if !NET_1_1
								= DO__utils.DBConnection_createInstance(
#else
								= DO0__utils.DBConnection_createInstance(
#endif
									Config_DBConnectionstrings.DBServerTypes(DO__utils.ApplicationName)[_db], 
									_dbcon.Connectionstring, 
									null
								);
						}
					}
				}
				return dbconnections__;
			}
		}
		#endregion
	}
}