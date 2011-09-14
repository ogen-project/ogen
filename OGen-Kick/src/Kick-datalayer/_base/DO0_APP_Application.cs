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

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;

using OGen.NTier.Kick.lib.datalayer.shared.structures;

namespace OGen.NTier.Kick.lib.datalayer {
	/// <summary>
	/// APP_Application DataObject which provides access to APP_Application's Database table.
	/// </summary>
	[DOClassAttribute("APP_Application", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_APP_Application 
#else
			DO_APP_Application 
#endif
	{

	 	#region Methods...
		#region public static SO_APP_Application getObject(...);
		/// <summary>
		/// Selects APP_Application values from Database and assigns them to the appropriate DO0_APP_Application property.
		/// </summary>
		/// <param name="IDApplication_in">IDApplication</param>
		/// <returns>null if APP_Application doesn't exists at Database</returns>
		public static SO_APP_Application getObject(
			int IDApplication_in
		) {
			return getObject(
				IDApplication_in, 
				null
			);
		}

		/// <summary>
		/// Selects APP_Application values from Database and assigns them to the appropriate DO_APP_Application property.
		/// </summary>
		/// <param name="IDApplication_in">IDApplication</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if APP_Application doesn't exists at Database</returns>
		public static SO_APP_Application getObject(
			int IDApplication_in, 
			DBConnection dbConnection_in
		) {
			SO_APP_Application _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDApplication_", DbType.Int32, ParameterDirection.InputOutput, IDApplication_in, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Output, null, 20)
			};
			_connection.Execute_SQLFunction("sp0_APP_Application_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_APP_Application();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDApplication = 0;
				} else {
					_output.IDApplication = (int)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.Name = string.Empty;
				} else {
					_output.Name = (string)_dataparameters[1].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes APP_Application from Database.
		/// </summary>
		/// <param name="IDApplication_in">IDApplication</param>
		public static void delObject(
			int IDApplication_in
		) {
			delObject(
				IDApplication_in, 
				null
			);
		}

		/// <summary>
		/// Deletes APP_Application from Database.
		/// </summary>
		/// <param name="IDApplication_in">IDApplication</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			int IDApplication_in, 
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDApplication_", DbType.Int32, ParameterDirection.Input, IDApplication_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_APP_Application_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if APP_Application exists at Database
		/// </summary>
		/// <param name="IDApplication_in">IDApplication</param>
		/// <returns>True if APP_Application exists at Database, False if not</returns>
		public static bool isObject(
			int IDApplication_in
		) {
			return isObject(
				IDApplication_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if APP_Application exists at Database
		/// </summary>
		/// <param name="IDApplication_in">IDApplication</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if APP_Application exists at Database, False if not</returns>
		public static bool isObject(
			int IDApplication_in, 
			DBConnection dbConnection_in
		) {
			bool _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDApplication_", DbType.Int32, ParameterDirection.Input, IDApplication_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_APP_Application_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static int insObject(...);
		/// <summary>
		/// Inserts APP_Application values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static int insObject(
			SO_APP_Application APP_Application_in, 
			bool selectIdentity_in
		) {
			return insObject(
				APP_Application_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts APP_Application values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static int insObject(
			SO_APP_Application APP_Application_in, 
			bool selectIdentity_in, 
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDApplication_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, APP_Application_in.Name, 20), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_APP_Application_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			APP_Application_in.IDApplication = (int)_dataparameters[0].Value;APP_Application_in.haschanges_ = false;
			

			return APP_Application_in.IDApplication;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates APP_Application values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_APP_Application APP_Application_in, 
			bool forceUpdate_in
		) {
			updObject(
				APP_Application_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates APP_Application values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_APP_Application APP_Application_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || APP_Application_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDApplication_", DbType.Int32, ParameterDirection.Input, APP_Application_in.IDApplication, 0), 
					_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, APP_Application_in.Name, 20)
				};
				_connection.Execute_SQLFunction(
					"sp0_APP_Application_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				APP_Application_in.haschanges_ = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_APP_Application[] getRecord(DataTable dataTable_in);
		private static SO_APP_Application[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idapplication = null;
			DataColumn _dc_name = null;

			SO_APP_Application[] _output 
				= new SO_APP_Application[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idapplication = dataTable_in.Columns["IDApplication"];
					_dc_name = dataTable_in.Columns["Name"];
				}

				_output[r] = new SO_APP_Application();
				if (dataTable_in.Rows[r][_dc_idapplication] == System.DBNull.Value) {
					_output[r].idapplication_ = 0;
				} else {
					_output[r].idapplication_ = (int)dataTable_in.Rows[r][_dc_idapplication];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].name_ = string.Empty;
				} else {
					_output[r].name_ = (string)dataTable_in.Rows[r][_dc_name];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#endregion
	}
}