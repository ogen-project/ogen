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

using OGen.lib.datalayer;
#if PostgreSQL
using OGen.lib.datalayer.PostgreSQL;
#endif

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.Kick.lib.datalayer {
	/// <summary>
	/// utils DataObject which works as a repository of useful Properties and Methods for DataObjects at OGen.NTier.Kick.lib.datalayer namespace.
	/// </summary>
	public 
#if USE_PARTIAL_CLASSES && !NET_1_1
		partial class DO__utils 
#else
		abstract class DO0__utils 
#endif
	{
		static 
#if USE_PARTIAL_CLASSES && !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
		(
		) {
			dbservertype__ = string.Empty;
			dbconnectionstring__ = null;
			dblogfile__ = string.Empty;
		}

		/// <summary>
		/// Application's Name
		/// </summary>
		public const string ApplicationName = "Kick";

		#region public static Properties...
		#region public static string DBServerType { get; }
		private static string dbservertype__;
		/// <summary>
		/// DB Server Type.
		/// </summary>
		public static string DBServerType {
			get {
				if (dbservertype__ == string.Empty) {
					DBServerType_read(false);
				}
				return dbservertype__;
			}
		}
		#endregion
		#region public static string DBConnectionstring { get; }
		private static string dbconnectionstring__;
		/// <summary>
		/// Connection String.
		/// </summary>
		public static string DBConnectionstring {
			get {
				if (dbconnectionstring__ == null) {
					DBConnectionstring_read(false);
				}
				return dbconnectionstring__;
			}
		}
		#endregion
		#region public static string DBLogfile { get; }
		private static string dblogfile__;

		/// <summary>
		/// DataBase Operation's Log File
		/// </summary>
		public static string DBLogfile {
			get {
				if (dblogfile__ == string.Empty) {
					if (
						#if !NET_1_1
						System.Configuration.ConfigurationManager.AppSettings
						#else
						System.Configuration.ConfigurationSettings.AppSettings
						#endif
							["DBLogfile"] == null
					) {
						dblogfile__ = null;
					} else {
						dblogfile__ = System.Configuration.ConfigurationSettings.AppSettings["DBLogfile"];
					}
					
				}
				return dblogfile__;
			}
		}
		#endregion
		#endregion

		#region public static Methods...
		public static DBConnection DBConnection_createInstance(
			string dbServerType_in, 
			string connectionstring_in, 
			string logfile_in
		) {
			switch (dbServerType_in) {
#if PostgreSQL
				case "PostgreSQL":
					return new DBConnection_PostgreSQL(
						connectionstring_in, 
						logfile_in
					);
#endif
			}

			throw new Exception(
				"unsuported db server type"
			);
		}
		#region public static void DBConnectionstring_reset();
		/// <summary>
		/// Forces DataBase's ConnectionString to be re-read from config file.
		/// </summary>
		public static void DBConnectionstring_reset() {
			Config_DBConnectionstrings.Reset();
		}
		#endregion
		#region private static void DBConnectionstring_read(bool andReset_in);
		private static void DBConnectionstring_read(bool andReset_in) {
			DBServerType_read(andReset_in);
		}
		#endregion
		#region public static void DBServerType_reset();
		/// <summary>
		/// Forces DataBase's Server Type to be re-read from config file.
		/// </summary>
		public static void DBServerType_reset() {
			Config_DBConnectionstrings.Reset();
		}
		#endregion
		#region private static void DBServerType_read(bool andReset_in);
		private static void DBServerType_read(bool andReset_in) {
			if (andReset_in) {
				DBServerType_reset();
			}
			dbservertype__ = string.Empty;
			dbconnectionstring__ = null;

			string[] _dbservertypes = Config_DBConnectionstrings.DBServerTypes(ApplicationName);
			Config_DBConnectionstrings _dbconnectionstrings = Config_DBConnectionstrings.DBConnectionstrings(ApplicationName);
			Config_DBConnectionstring _con;
			for (int _db = 0; _db < _dbservertypes.Length; _db++) {
				_con = _dbconnectionstrings[
					_dbservertypes[_db],
#if DEBUG
					"DEBUG"
#elif !DEBUG
					"!DEBUG"
#endif
				];
				if (_con.isDefault) {
					dbservertype__ = _dbservertypes[_db];
					dbconnectionstring__ = _con.Connectionstring;
					return;
				}
			}
		}
		#endregion
		#endregion
	}
}