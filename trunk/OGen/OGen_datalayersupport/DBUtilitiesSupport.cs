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
	public class DBUtilitiesSupport {
		private DBUtilitiesSupport() {}
#else
	public static class DBUtilitiesSupport {
#endif

		#region public static DBUtilities GetInstance(...);
#if PostgreSQL
		#region private static DBUtilities_PostgreSQL dbUtilities_PostgreSQL { get; }
		private static DBUtilities_PostgreSQL dbutilities_postgresql__;
		private static object dbutilities_postgresql__locker = new object();

		private static DBUtilities_PostgreSQL dbUtilities_PostgreSQL {
			get{

				// check before lock
				if (dbutilities_postgresql__ == null) {

					lock (dbutilities_postgresql__locker) {

						// double check, thread safer!
						if (dbutilities_postgresql__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							dbutilities_postgresql__ = new DBUtilities_PostgreSQL();
						}
					}
				}

				return dbutilities_postgresql__;
			}
		}
		#endregion
#endif
		#region private static DBUtilities_SQLServer dbUtilities_SQLServer { get; }
		private static DBUtilities_SQLServer dbutilities_sqlserver__;
		private static object dbutilities_sqlserver__locker = new object();

		private static DBUtilities_SQLServer dbUtilities_SQLServer {
			get{

				// check before lock
				if (dbutilities_sqlserver__ == null) {

					lock (dbutilities_sqlserver__locker) {

						// double check, thread safer!
						if (dbutilities_sqlserver__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							dbutilities_sqlserver__ = new DBUtilities_SQLServer();
						}
					}
				}

				return dbutilities_sqlserver__;
			}
		}
		#endregion
#if MySQL
		#region private static DBUtilities_MySQL dbUtilities_MySQL { get; }
		private static DBUtilities_MySQL dbutilities_mysql__;
		private static object dbutilities_mysql__locker = new object();

		private static DBUtilities_MySQL dbUtilities_MySQL {
			get{

				// check before lock
				if (dbutilities_mysql__ == null) {

					lock (dbutilities_mysql__locker) {

						// double check, thread safer!
						if (dbutilities_mysql__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							dbutilities_mysql__ = new DBUtilities_MySQL();
						}
					}
				}

				return dbutilities_mysql__;
			}
		}
		#endregion
#endif

		#region public static DBUtilities GetInstance(...);
//		public static DBUtilities GetInstance(
//			string dbServerType_in
//		) {
//			return GetInstance(
//				(DBServerTypes)Enum.Parse(typeof(DBServerTypes), dbServerType_in)
//			);
//		}
		public static DBUtilities GetInstance(
			DBServerTypes dbServerType_in
		) {
			switch (dbServerType_in) {
#if PostgreSQL
				case DBServerTypes.PostgreSQL:
					return dbUtilities_PostgreSQL;
#endif
#if MySQL
				case DBServerTypes.MySQL:
					return dbUtilities_MySQL;
#endif
				case DBServerTypes.SQLServer:
					return dbUtilities_SQLServer;
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
		#endregion
	}
}
