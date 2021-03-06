#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.DataLayer {
	using System;
	using System.Data;

	using OGen.Libraries.DataLayer;
	using OGen.NTier.Libraries.DataLayer;

	using OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures;

	/// <summary>
	/// NET_Browser DataObject which provides access to NET_Browser's Database table.
	/// </summary>
	[DOClassAttribute("NET_Browser", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_NET_Browser 
#else
			DO_NET_Browser 
#endif
	{

	 	#region Methods...
		#region public static SO_NET_Browser getObject(...);
		/// <summary>
		/// Selects NET_Browser values from Database and assigns them to the appropriate DO0_NET_Browser property.
		/// </summary>
		/// <param name="IDBrowser_in">IDBrowser</param>
		/// <returns>null if NET_Browser doesn't exists at Database</returns>
		public static SO_NET_Browser getObject(
			long IDBrowser_in
		) {
			return getObject(
				IDBrowser_in, 
				null
			);
		}

		/// <summary>
		/// Selects NET_Browser values from Database and assigns them to the appropriate DO_NET_Browser property.
		/// </summary>
		/// <param name="IDBrowser_in">IDBrowser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NET_Browser doesn't exists at Database</returns>
		public static SO_NET_Browser getObject(
			long IDBrowser_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_Browser _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDBrowser_", DbType.Int64, ParameterDirection.InputOutput, IDBrowser_in, 0), 
				_connection.newDBDataParameter("HTTP_FULL_SIGNATURE_", DbType.AnsiString, ParameterDirection.Output, null, 1024), 
				_connection.newDBDataParameter("HTTP_FULL_SIGNATURE__CRC_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("HTTP_ACCEPT_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("HTTP_ACCEPT__CRC_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("HTTP_ACCEPT_CHARSET_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("HTTP_ACCEPT_CHARSET__CRC_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("HTTP_ACCEPT_ENCODING_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("HTTP_ACCEPT_ENCODING__CRC_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("HTTP_ACCEPT_LANGUAGE_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("HTTP_ACCEPT_LANGUAGE__CRC_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("HTTP_USER_AGENT_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("HTTP_USER_AGENT__CRC_", DbType.Int64, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_NET_Browser_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NET_Browser();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDBrowser = 0L;
				} else {
					_output.IDBrowser = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.HTTP_FULL_SIGNATURE = string.Empty;
				} else {
					_output.HTTP_FULL_SIGNATURE = (string)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.HTTP_FULL_SIGNATURE__CRC = 0L;
				} else {
					_output.HTTP_FULL_SIGNATURE__CRC = (long)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.HTTP_ACCEPT = string.Empty;
				} else {
					_output.HTTP_ACCEPT = (string)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.HTTP_ACCEPT__CRC = 0L;
				} else {
					_output.HTTP_ACCEPT__CRC = (long)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.HTTP_ACCEPT_CHARSET = string.Empty;
				} else {
					_output.HTTP_ACCEPT_CHARSET = (string)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.HTTP_ACCEPT_CHARSET__CRC = 0L;
				} else {
					_output.HTTP_ACCEPT_CHARSET__CRC = (long)_dataparameters[6].Value;
				}
				if (_dataparameters[7].Value == System.DBNull.Value) {
					_output.HTTP_ACCEPT_ENCODING = string.Empty;
				} else {
					_output.HTTP_ACCEPT_ENCODING = (string)_dataparameters[7].Value;
				}
				if (_dataparameters[8].Value == System.DBNull.Value) {
					_output.HTTP_ACCEPT_ENCODING__CRC = 0L;
				} else {
					_output.HTTP_ACCEPT_ENCODING__CRC = (long)_dataparameters[8].Value;
				}
				if (_dataparameters[9].Value == System.DBNull.Value) {
					_output.HTTP_ACCEPT_LANGUAGE = string.Empty;
				} else {
					_output.HTTP_ACCEPT_LANGUAGE = (string)_dataparameters[9].Value;
				}
				if (_dataparameters[10].Value == System.DBNull.Value) {
					_output.HTTP_ACCEPT_LANGUAGE__CRC = 0L;
				} else {
					_output.HTTP_ACCEPT_LANGUAGE__CRC = (long)_dataparameters[10].Value;
				}
				if (_dataparameters[11].Value == System.DBNull.Value) {
					_output.HTTP_USER_AGENT = string.Empty;
				} else {
					_output.HTTP_USER_AGENT = (string)_dataparameters[11].Value;
				}
				if (_dataparameters[12].Value == System.DBNull.Value) {
					_output.HTTP_USER_AGENT__CRC = 0L;
				} else {
					_output.HTTP_USER_AGENT__CRC = (long)_dataparameters[12].Value;
				}

				_output.HasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NET_Browser from Database.
		/// </summary>
		/// <param name="IDBrowser_in">IDBrowser</param>
		public static void delObject(
			long IDBrowser_in
		) {
			delObject(
				IDBrowser_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_Browser from Database.
		/// </summary>
		/// <param name="IDBrowser_in">IDBrowser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDBrowser_in, 
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDBrowser_", DbType.Int64, ParameterDirection.Input, IDBrowser_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NET_Browser_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NET_Browser exists at Database
		/// </summary>
		/// <param name="IDBrowser_in">IDBrowser</param>
		/// <returns>True if NET_Browser exists at Database, False if not</returns>
		public static bool isObject(
			long IDBrowser_in
		) {
			return isObject(
				IDBrowser_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NET_Browser exists at Database
		/// </summary>
		/// <param name="IDBrowser_in">IDBrowser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_Browser exists at Database, False if not</returns>
		public static bool isObject(
			long IDBrowser_in, 
			DBConnection dbConnection_in
		) {
			bool _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDBrowser_", DbType.Int64, ParameterDirection.Input, IDBrowser_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NET_Browser_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long insObject(...);
		/// <summary>
		/// Inserts NET_Browser values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_NET_Browser NET_Browser_in, 
			bool selectIdentity_in
		) {
			return insObject(
				NET_Browser_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts NET_Browser values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_NET_Browser NET_Browser_in, 
			bool selectIdentity_in, 
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDBrowser_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("HTTP_FULL_SIGNATURE_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_FULL_SIGNATURE, 1024), 
				_connection.newDBDataParameter("HTTP_FULL_SIGNATURE__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_FULL_SIGNATURE__CRC, 0), 
				_connection.newDBDataParameter("HTTP_ACCEPT_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT, 255), 
				_connection.newDBDataParameter("HTTP_ACCEPT__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT__CRC, 0), 
				_connection.newDBDataParameter("HTTP_ACCEPT_CHARSET_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_CHARSET, 255), 
				_connection.newDBDataParameter("HTTP_ACCEPT_CHARSET__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_CHARSET__CRC, 0), 
				_connection.newDBDataParameter("HTTP_ACCEPT_ENCODING_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_ENCODING, 255), 
				_connection.newDBDataParameter("HTTP_ACCEPT_ENCODING__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_ENCODING__CRC, 0), 
				_connection.newDBDataParameter("HTTP_ACCEPT_LANGUAGE_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_LANGUAGE, 255), 
				_connection.newDBDataParameter("HTTP_ACCEPT_LANGUAGE__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_LANGUAGE__CRC, 0), 
				_connection.newDBDataParameter("HTTP_USER_AGENT_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_USER_AGENT, 255), 
				_connection.newDBDataParameter("HTTP_USER_AGENT__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_USER_AGENT__CRC, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_NET_Browser_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			NET_Browser_in.IDBrowser = (long)_dataparameters[0].Value;NET_Browser_in.HasChanges = false;
			

			return NET_Browser_in.IDBrowser;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates NET_Browser values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_NET_Browser NET_Browser_in, 
			bool forceUpdate_in
		) {
			updObject(
				NET_Browser_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates NET_Browser values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_NET_Browser NET_Browser_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || NET_Browser_in.HasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__Utilities.DBConnection_createInstance(
						DO__Utilities.DBServerType,
						DO__Utilities.DBConnectionstring,
						DO__Utilities.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDBrowser_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.IDBrowser, 0), 
					_connection.newDBDataParameter("HTTP_FULL_SIGNATURE_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_FULL_SIGNATURE, 1024), 
					_connection.newDBDataParameter("HTTP_FULL_SIGNATURE__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_FULL_SIGNATURE__CRC, 0), 
					_connection.newDBDataParameter("HTTP_ACCEPT_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT, 255), 
					_connection.newDBDataParameter("HTTP_ACCEPT__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT__CRC, 0), 
					_connection.newDBDataParameter("HTTP_ACCEPT_CHARSET_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_CHARSET, 255), 
					_connection.newDBDataParameter("HTTP_ACCEPT_CHARSET__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_CHARSET__CRC, 0), 
					_connection.newDBDataParameter("HTTP_ACCEPT_ENCODING_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_ENCODING, 255), 
					_connection.newDBDataParameter("HTTP_ACCEPT_ENCODING__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_ENCODING__CRC, 0), 
					_connection.newDBDataParameter("HTTP_ACCEPT_LANGUAGE_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_LANGUAGE, 255), 
					_connection.newDBDataParameter("HTTP_ACCEPT_LANGUAGE__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_ACCEPT_LANGUAGE__CRC, 0), 
					_connection.newDBDataParameter("HTTP_USER_AGENT_", DbType.AnsiString, ParameterDirection.Input, NET_Browser_in.HTTP_USER_AGENT, 255), 
					_connection.newDBDataParameter("HTTP_USER_AGENT__CRC_", DbType.Int64, ParameterDirection.Input, NET_Browser_in.HTTP_USER_AGENT__CRC, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NET_Browser_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				NET_Browser_in.HasChanges = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#endregion
	}
}