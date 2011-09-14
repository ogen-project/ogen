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
	/// LOG_Errortype DataObject which provides access to LOG_Errortype's Database table.
	/// </summary>
	[DOClassAttribute("LOG_Errortype", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_LOG_Errortype 
#else
			DO_LOG_Errortype 
#endif
	{

	 	#region Methods...
		#region public static SO_LOG_Errortype getObject(...);
		/// <summary>
		/// Selects LOG_Errortype values from Database and assigns them to the appropriate DO0_LOG_Errortype property.
		/// </summary>
		/// <param name="IDErrortype_in">IDErrortype</param>
		/// <returns>null if LOG_Errortype doesn't exists at Database</returns>
		public static SO_LOG_Errortype getObject(
			int IDErrortype_in
		) {
			return getObject(
				IDErrortype_in, 
				null
			);
		}

		/// <summary>
		/// Selects LOG_Errortype values from Database and assigns them to the appropriate DO_LOG_Errortype property.
		/// </summary>
		/// <param name="IDErrortype_in">IDErrortype</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if LOG_Errortype doesn't exists at Database</returns>
		public static SO_LOG_Errortype getObject(
			int IDErrortype_in, 
			DBConnection dbConnection_in
		) {
			SO_LOG_Errortype _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDErrortype_", DbType.Int32, ParameterDirection.InputOutput, IDErrortype_in, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Description_", DbType.AnsiString, ParameterDirection.Output, null, 2048), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_LOG_Errortype_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_LOG_Errortype();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDErrortype = 0;
				} else {
					_output.IDErrortype = (int)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.Name = string.Empty;
				} else {
					_output.Name = (string)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.Description_isNull = true;
				} else {
					_output.Description = (string)_dataparameters[2].Value;
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
		/// Deletes LOG_Errortype from Database.
		/// </summary>
		/// <param name="IDErrortype_in">IDErrortype</param>
		public static void delObject(
			int IDErrortype_in
		) {
			delObject(
				IDErrortype_in, 
				null
			);
		}

		/// <summary>
		/// Deletes LOG_Errortype from Database.
		/// </summary>
		/// <param name="IDErrortype_in">IDErrortype</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			int IDErrortype_in, 
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
				_connection.newDBDataParameter("IDErrortype_", DbType.Int32, ParameterDirection.Input, IDErrortype_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_LOG_Errortype_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if LOG_Errortype exists at Database
		/// </summary>
		/// <param name="IDErrortype_in">IDErrortype</param>
		/// <returns>True if LOG_Errortype exists at Database, False if not</returns>
		public static bool isObject(
			int IDErrortype_in
		) {
			return isObject(
				IDErrortype_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if LOG_Errortype exists at Database
		/// </summary>
		/// <param name="IDErrortype_in">IDErrortype</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if LOG_Errortype exists at Database, False if not</returns>
		public static bool isObject(
			int IDErrortype_in, 
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
				_connection.newDBDataParameter("IDErrortype_", DbType.Int32, ParameterDirection.Input, IDErrortype_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_LOG_Errortype_isObject", 
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
		/// Inserts/Updates LOG_Errortype values into/on Database. Inserts if LOG_Errortype doesn't exist or Updates if LOG_Errortype already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_LOG_Errortype LOG_Errortype_in, 
			bool forceUpdate_in
		) {
			return setObject(
				LOG_Errortype_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates LOG_Errortype values into/on Database. Inserts if LOG_Errortype doesn't exist or Updates if LOG_Errortype already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_LOG_Errortype LOG_Errortype_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || LOG_Errortype_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDErrortype_", DbType.Int32, ParameterDirection.Input, LOG_Errortype_in.IDErrortype, 0), 
					_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, LOG_Errortype_in.Name, 255), 
					_connection.newDBDataParameter("Description_", DbType.AnsiString, ParameterDirection.Input, LOG_Errortype_in.Description_isNull ? null : (object)LOG_Errortype_in.Description, 2048), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, LOG_Errortype_in.IFApplication_isNull ? null : (object)LOG_Errortype_in.IFApplication, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_LOG_Errortype_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[4].Value & 2) == 1);
				if (!ConstraintExist_out) {
					LOG_Errortype_in.haschanges_ = false;
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
		#region private static SO_LOG_Errortype[] getRecord(DataTable dataTable_in);
		private static SO_LOG_Errortype[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_iderrortype = null;
			DataColumn _dc_name = null;
			DataColumn _dc_description = null;
			DataColumn _dc_ifapplication = null;

			SO_LOG_Errortype[] _output 
				= new SO_LOG_Errortype[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_iderrortype = dataTable_in.Columns["IDErrortype"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_description = dataTable_in.Columns["Description"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
				}

				_output[r] = new SO_LOG_Errortype();
				if (dataTable_in.Rows[r][_dc_iderrortype] == System.DBNull.Value) {
					_output[r].iderrortype_ = 0;
				} else {
					_output[r].iderrortype_ = (int)dataTable_in.Rows[r][_dc_iderrortype];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].name_ = string.Empty;
				} else {
					_output[r].name_ = (string)dataTable_in.Rows[r][_dc_name];
				}
				if (dataTable_in.Rows[r][_dc_description] == System.DBNull.Value) {
					_output[r].Description_isNull = true;
				} else {
					_output[r].description_ = (string)dataTable_in.Rows[r][_dc_description];
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