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
	/// NET_BrowserUser DataObject which provides access to NET_BrowserUser's Database table.
	/// </summary>
	[DOClassAttribute("NET_BrowserUser", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_NET_BrowserUser 
#else
			DO_NET_BrowserUser 
#endif
	{

	 	#region Methods...
		#region public static SO_NET_BrowserUser getObject(...);
		/// <summary>
		/// Selects NET_BrowserUser values from Database and assigns them to the appropriate DO0_NET_BrowserUser property.
		/// </summary>
		/// <param name="IFBrowser_in">IFBrowser</param>
		/// <param name="IFUser_in">IFUser</param>
		/// <returns>null if NET_BrowserUser doesn't exists at Database</returns>
		public static SO_NET_BrowserUser getObject(
			long IFBrowser_in, 
			long IFUser_in
		) {
			return getObject(
				IFBrowser_in, 
				IFUser_in, 
				null
			);
		}

		/// <summary>
		/// Selects NET_BrowserUser values from Database and assigns them to the appropriate DO_NET_BrowserUser property.
		/// </summary>
		/// <param name="IFBrowser_in">IFBrowser</param>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NET_BrowserUser doesn't exists at Database</returns>
		public static SO_NET_BrowserUser getObject(
			long IFBrowser_in, 
			long IFUser_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_BrowserUser _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFBrowser_", DbType.Int64, ParameterDirection.InputOutput, IFBrowser_in, 0), 
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.InputOutput, IFUser_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NET_BrowserUser_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NET_BrowserUser();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFBrowser = 0L;
				} else {
					_output.IFBrowser = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFUser = 0L;
				} else {
					_output.IFUser = (long)_dataparameters[1].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NET_BrowserUser from Database.
		/// </summary>
		/// <param name="IFBrowser_in">IFBrowser</param>
		/// <param name="IFUser_in">IFUser</param>
		public static void delObject(
			long IFBrowser_in, 
			long IFUser_in
		) {
			delObject(
				IFBrowser_in, 
				IFUser_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_BrowserUser from Database.
		/// </summary>
		/// <param name="IFBrowser_in">IFBrowser</param>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFBrowser_in, 
			long IFUser_in, 
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
				_connection.newDBDataParameter("IFBrowser_", DbType.Int64, ParameterDirection.Input, IFBrowser_in, 0), 
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, IFUser_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NET_BrowserUser_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NET_BrowserUser exists at Database
		/// </summary>
		/// <param name="IFBrowser_in">IFBrowser</param>
		/// <param name="IFUser_in">IFUser</param>
		/// <returns>True if NET_BrowserUser exists at Database, False if not</returns>
		public static bool isObject(
			long IFBrowser_in, 
			long IFUser_in
		) {
			return isObject(
				IFBrowser_in, 
				IFUser_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NET_BrowserUser exists at Database
		/// </summary>
		/// <param name="IFBrowser_in">IFBrowser</param>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_BrowserUser exists at Database, False if not</returns>
		public static bool isObject(
			long IFBrowser_in, 
			long IFUser_in, 
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
				_connection.newDBDataParameter("IFBrowser_", DbType.Int64, ParameterDirection.Input, IFBrowser_in, 0), 
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, IFUser_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NET_BrowserUser_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static bool setObject(...);
		/// <summary>
		/// Inserts/Updates NET_BrowserUser values into/on Database. Inserts if NET_BrowserUser doesn't exist or Updates if NET_BrowserUser already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NET_BrowserUser NET_BrowserUser_in, 
			bool forceUpdate_in
		) {
			return setObject(
				NET_BrowserUser_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates NET_BrowserUser values into/on Database. Inserts if NET_BrowserUser doesn't exist or Updates if NET_BrowserUser already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NET_BrowserUser NET_BrowserUser_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || NET_BrowserUser_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFBrowser_", DbType.Int64, ParameterDirection.Input, NET_BrowserUser_in.IFBrowser, 0), 
					_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, NET_BrowserUser_in.IFUser, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NET_BrowserUser_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[2].Value & 2) == 1);
				if (!ConstraintExist_out) {
					NET_BrowserUser_in.haschanges_ = false;
				}

				return (((int)_dataparameters[2].Value & 1) != 1);
			} else {
				ConstraintExist_out = false;

				return  false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_NET_BrowserUser[] getRecord(DataTable dataTable_in);
		private static SO_NET_BrowserUser[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifbrowser = null;
			DataColumn _dc_ifuser = null;

			SO_NET_BrowserUser[] _output 
				= new SO_NET_BrowserUser[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifbrowser = dataTable_in.Columns["IFBrowser"];
					_dc_ifuser = dataTable_in.Columns["IFUser"];
				}

				_output[r] = new SO_NET_BrowserUser();
				if (dataTable_in.Rows[r][_dc_ifbrowser] == System.DBNull.Value) {
					_output[r].ifbrowser_ = 0L;
				} else {
					_output[r].ifbrowser_ = (long)dataTable_in.Rows[r][_dc_ifbrowser];
				}
				if (dataTable_in.Rows[r][_dc_ifuser] == System.DBNull.Value) {
					_output[r].ifuser_ = 0L;
				} else {
					_output[r].ifuser_ = (long)dataTable_in.Rows[r][_dc_ifuser];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#endregion
	}
}