#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.DataLayer {
	using System;
	using OGen.Libraries.DataLayer;
	#if PostgreSQL
	using OGen.Libraries.DataLayer.PostgreSQL;
	#endif
	#if MySQL
	using OGen.Libraries.DataLayer.MySQL;
	#endif
	using OGen.Libraries.DataLayer.SQLServer;

#if NET_1_1
	public class DBConnectionsupport { private DBConnectionsupport() {}
#else
	public static class DBConnectionsupport {
#endif

		#region public static DBConnection CreateInstance();
		public static DBConnection CreateInstance(
			DBServerTypes dbServerType_in, 
			string connectionString_in
		) {
			return CreateInstance(
				dbServerType_in, 
				connectionString_in, 
				null
			);
		}
		public static DBConnection CreateInstance(
			DBServerTypes dbServerType_in, 
			string connectionString_in, 
			string logFile_in
		) {
			switch (dbServerType_in) {
#if PostgreSQL
				case DBServerTypes.PostgreSQL:
					return new DBConnection_PostgreSQL(
						connectionString_in, 
						logFile_in
					);
#endif
				case DBServerTypes.SQLServer:
					return new DBConnection_SQLServer(
						connectionString_in, 
						logFile_in
					);
#if MySQL
				case DBServerTypes.MySQL:
					return new DBConnection_MySQL(
						connectionString_in, 
						logFile_in
					);
#endif
			}
			
			throw new Exception(
				string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"unsuported db type: {0}", 
					dbServerType_in.ToString()
				)
			);
		}
		#endregion
		#region public static DBServerTypes GetDBServerType(...);
		public static DBServerTypes GetDBServerType(
			DBConnection connection_in
		) {
#if PostgreSQL
			if (connection_in is DBConnection_PostgreSQL) {
				return DBServerTypes.PostgreSQL;
			}
			else
#endif
			if (connection_in is DBConnection_SQLServer) {
				return DBServerTypes.SQLServer;
			}
#if MySQL
			else
			if (connection_in is DBConnection_MySQL) {
				return DBServerTypes.MySQL;
			}
#endif
			
			throw new Exception(
				string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"unsuported db type: {0}", 
					connection_in.ToString()
				)
			);
		}
		#endregion
	}
}
