#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.lib.datalayer {
	using System;
	using OGen.lib.datalayer;
	#if PostgreSQL
	using OGen.lib.datalayer.PostgreSQL;
	#endif
	#if MySQL
	using OGen.lib.datalayer.MySQL;
	#endif
	using OGen.lib.datalayer.SQLServer;

#if NET_1_1
	public class DBUtilssupport {
		private DBUtilssupport() {}
#else
	public static class DBUtilssupport {
#endif

		#region public static DBUtils GetInstance(...);
#if PostgreSQL
		#region private static DBUtils_PostgreSQL dbUtils_PostgreSQL { get; }
		private static DBUtils_PostgreSQL dbutils_postgresql__;
		private static object dbutils_postgresql__locker = new object();

		private static DBUtils_PostgreSQL dbUtils_PostgreSQL {
			get{

				// check before lock
				if (dbutils_postgresql__ == null) {

					lock (dbutils_postgresql__locker) {

						// double check, thread safer!
						if (dbutils_postgresql__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							dbutils_postgresql__ = new DBUtils_PostgreSQL();
						}
					}
				}

				return dbutils_postgresql__;
			}
		}
		#endregion
#endif
		#region private static DBUtils_SQLServer dbUtils_SQLServer { get; }
		private static DBUtils_SQLServer dbutils_sqlserver__;
		private static object dbutils_sqlserver__locker = new object();

		private static DBUtils_SQLServer dbUtils_SQLServer {
			get{

				// check before lock
				if (dbutils_sqlserver__ == null) {

					lock (dbutils_sqlserver__locker) {

						// double check, thread safer!
						if (dbutils_sqlserver__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							dbutils_sqlserver__ = new DBUtils_SQLServer();
						}
					}
				}

				return dbutils_sqlserver__;
			}
		}
		#endregion
#if MySQL
		#region private static DBUtils_MySQL dbUtils_MySQL { get; }
		private static DBUtils_MySQL dbutils_mysql__;
		private static object dbutils_mysql__locker = new object();

		private static DBUtils_MySQL dbUtils_MySQL {
			get{

				// check before lock
				if (dbutils_mysql__ == null) {

					lock (dbutils_mysql__locker) {

						// double check, thread safer!
						if (dbutils_mysql__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							dbutils_mysql__ = new DBUtils_MySQL();
						}
					}
				}

				return dbutils_mysql__;
			}
		}
		#endregion
#endif

		#region public static DBUtils GetInstance(...);
//		public static DBUtils GetInstance(
//			string dbServerType_in
//		) {
//			return GetInstance(
//				(DBServerTypes)Enum.Parse(typeof(DBServerTypes), dbServerType_in)
//			);
//		}
		public static DBUtils GetInstance(
			DBServerTypes dbServerType_in
		) {
			switch (dbServerType_in) {
#if PostgreSQL
				case DBServerTypes.PostgreSQL:
					return dbUtils_PostgreSQL;
#endif
#if MySQL
				case DBServerTypes.MySQL:
					return dbUtils_MySQL;
#endif
				case DBServerTypes.SQLServer:
					return dbUtils_SQLServer;
			}
			
			throw new Exception(
				string.Format(
					"unsuported db type: {0}", 
					dbServerType_in.ToString()
				)
			);
		}
		#endregion
		#endregion
	}
}
