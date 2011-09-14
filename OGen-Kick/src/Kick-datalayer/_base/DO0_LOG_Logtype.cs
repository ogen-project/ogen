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
	/// LOG_Logtype DataObject which provides access to LOG_Logtype's Database table.
	/// </summary>
	[DOClassAttribute("LOG_Logtype", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_LOG_Logtype 
#else
			DO_LOG_Logtype 
#endif
	{

	 	#region Methods...
		#region public static SO_LOG_Logtype getObject(...);
		/// <summary>
		/// Selects LOG_Logtype values from Database and assigns them to the appropriate DO0_LOG_Logtype property.
		/// </summary>
		/// <param name="IDLogtype_in">IDLogtype</param>
		/// <returns>null if LOG_Logtype doesn't exists at Database</returns>
		public static SO_LOG_Logtype getObject(
			int IDLogtype_in
		) {
			return getObject(
				IDLogtype_in, 
				null
			);
		}

		/// <summary>
		/// Selects LOG_Logtype values from Database and assigns them to the appropriate DO_LOG_Logtype property.
		/// </summary>
		/// <param name="IDLogtype_in">IDLogtype</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if LOG_Logtype doesn't exists at Database</returns>
		public static SO_LOG_Logtype getObject(
			int IDLogtype_in, 
			DBConnection dbConnection_in
		) {
			SO_LOG_Logtype _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDLogtype_", DbType.Int32, ParameterDirection.InputOutput, IDLogtype_in, 0), 
				_connection.newDBDataParameter("IFLogtype_parent_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Output, null, 20), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_LOG_Logtype_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_LOG_Logtype();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDLogtype = 0;
				} else {
					_output.IDLogtype = (int)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFLogtype_parent_isNull = true;
				} else {
					_output.IFLogtype_parent = (int)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.Name = string.Empty;
				} else {
					_output.Name = (string)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[3].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes LOG_Logtype from Database.
		/// </summary>
		/// <param name="IDLogtype_in">IDLogtype</param>
		public static void delObject(
			int IDLogtype_in
		) {
			delObject(
				IDLogtype_in, 
				null
			);
		}

		/// <summary>
		/// Deletes LOG_Logtype from Database.
		/// </summary>
		/// <param name="IDLogtype_in">IDLogtype</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			int IDLogtype_in, 
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
				_connection.newDBDataParameter("IDLogtype_", DbType.Int32, ParameterDirection.Input, IDLogtype_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_LOG_Logtype_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if LOG_Logtype exists at Database
		/// </summary>
		/// <param name="IDLogtype_in">IDLogtype</param>
		/// <returns>True if LOG_Logtype exists at Database, False if not</returns>
		public static bool isObject(
			int IDLogtype_in
		) {
			return isObject(
				IDLogtype_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if LOG_Logtype exists at Database
		/// </summary>
		/// <param name="IDLogtype_in">IDLogtype</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if LOG_Logtype exists at Database, False if not</returns>
		public static bool isObject(
			int IDLogtype_in, 
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
				_connection.newDBDataParameter("IDLogtype_", DbType.Int32, ParameterDirection.Input, IDLogtype_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_LOG_Logtype_isObject", 
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
		/// Inserts/Updates LOG_Logtype values into/on Database. Inserts if LOG_Logtype doesn't exist or Updates if LOG_Logtype already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_LOG_Logtype LOG_Logtype_in, 
			bool forceUpdate_in
		) {
			return setObject(
				LOG_Logtype_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates LOG_Logtype values into/on Database. Inserts if LOG_Logtype doesn't exist or Updates if LOG_Logtype already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_LOG_Logtype LOG_Logtype_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || LOG_Logtype_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDLogtype_", DbType.Int32, ParameterDirection.Input, LOG_Logtype_in.IDLogtype, 0), 
					_connection.newDBDataParameter("IFLogtype_parent_", DbType.Int32, ParameterDirection.Input, LOG_Logtype_in.IFLogtype_parent_isNull ? null : (object)LOG_Logtype_in.IFLogtype_parent, 0), 
					_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, LOG_Logtype_in.Name, 20), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, LOG_Logtype_in.IFApplication_isNull ? null : (object)LOG_Logtype_in.IFApplication, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_LOG_Logtype_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[4].Value & 2) == 1);
				if (!ConstraintExist_out) {
					LOG_Logtype_in.haschanges_ = false;
				}

				return (((int)_dataparameters[4].Value & 1) != 1);
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
		#region private static SO_LOG_Logtype[] getRecord(DataTable dataTable_in);
		private static SO_LOG_Logtype[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idlogtype = null;
			DataColumn _dc_iflogtype_parent = null;
			DataColumn _dc_name = null;
			DataColumn _dc_ifapplication = null;

			SO_LOG_Logtype[] _output 
				= new SO_LOG_Logtype[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idlogtype = dataTable_in.Columns["IDLogtype"];
					_dc_iflogtype_parent = dataTable_in.Columns["IFLogtype_parent"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
				}

				_output[r] = new SO_LOG_Logtype();
				if (dataTable_in.Rows[r][_dc_idlogtype] == System.DBNull.Value) {
					_output[r].idlogtype_ = 0;
				} else {
					_output[r].idlogtype_ = (int)dataTable_in.Rows[r][_dc_idlogtype];
				}
				if (dataTable_in.Rows[r][_dc_iflogtype_parent] == System.DBNull.Value) {
					_output[r].IFLogtype_parent_isNull = true;
				} else {
					_output[r].iflogtype_parent_ = (int)dataTable_in.Rows[r][_dc_iflogtype_parent];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].name_ = string.Empty;
				} else {
					_output[r].name_ = (string)dataTable_in.Rows[r][_dc_name];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication_isNull = true;
				} else {
					_output[r].ifapplication_ = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#endregion
	}
}