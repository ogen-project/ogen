#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.lib.datalayer {
	using System;
	using System.Data;

	using OGen.lib.datalayer;
	using OGen.NTier.lib.datalayer;

	using OGen.NTier.Kick.lib.datalayer.shared.structures;

	/// <summary>
	/// CRD_Table DataObject which provides access to CRD_Table's Database table.
	/// </summary>
	[DOClassAttribute("CRD_Table", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_CRD_Table 
#else
			DO_CRD_Table 
#endif
	{

	 	#region Methods...
		#region public static SO_CRD_Table getObject(...);
		/// <summary>
		/// Selects CRD_Table values from Database and assigns them to the appropriate DO0_CRD_Table property.
		/// </summary>
		/// <param name="IDTable_in">IDTable</param>
		/// <returns>null if CRD_Table doesn't exists at Database</returns>
		public static SO_CRD_Table getObject(
			long IDTable_in
		) {
			return getObject(
				IDTable_in, 
				null
			);
		}

		/// <summary>
		/// Selects CRD_Table values from Database and assigns them to the appropriate DO_CRD_Table property.
		/// </summary>
		/// <param name="IDTable_in">IDTable</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if CRD_Table doesn't exists at Database</returns>
		public static SO_CRD_Table getObject(
			long IDTable_in, 
			DBConnection dbConnection_in
		) {
			SO_CRD_Table _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDTable_", DbType.Int64, ParameterDirection.InputOutput, IDTable_in, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Output, null, 255)
			};
			_connection.Execute_SQLFunction("sp0_CRD_Table_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_CRD_Table();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDTable = 0L;
				} else {
					_output.IDTable = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.Name = string.Empty;
				} else {
					_output.Name = (string)_dataparameters[1].Value;
				}

				_output.hasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes CRD_Table from Database.
		/// </summary>
		/// <param name="IDTable_in">IDTable</param>
		public static void delObject(
			long IDTable_in
		) {
			delObject(
				IDTable_in, 
				null
			);
		}

		/// <summary>
		/// Deletes CRD_Table from Database.
		/// </summary>
		/// <param name="IDTable_in">IDTable</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDTable_in, 
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
				_connection.newDBDataParameter("IDTable_", DbType.Int64, ParameterDirection.Input, IDTable_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_Table_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if CRD_Table exists at Database
		/// </summary>
		/// <param name="IDTable_in">IDTable</param>
		/// <returns>True if CRD_Table exists at Database, False if not</returns>
		public static bool isObject(
			long IDTable_in
		) {
			return isObject(
				IDTable_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if CRD_Table exists at Database
		/// </summary>
		/// <param name="IDTable_in">IDTable</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_Table exists at Database, False if not</returns>
		public static bool isObject(
			long IDTable_in, 
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
				_connection.newDBDataParameter("IDTable_", DbType.Int64, ParameterDirection.Input, IDTable_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_Table_isObject", 
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
		/// Inserts/Updates CRD_Table values into/on Database. Inserts if CRD_Table doesn't exist or Updates if CRD_Table already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_CRD_Table CRD_Table_in, 
			bool forceUpdate_in
		) {
			return setObject(
				CRD_Table_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates CRD_Table values into/on Database. Inserts if CRD_Table doesn't exist or Updates if CRD_Table already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_CRD_Table CRD_Table_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || CRD_Table_in.hasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDTable_", DbType.Int64, ParameterDirection.Input, CRD_Table_in.IDTable, 0), 
					_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, CRD_Table_in.Name, 255), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_CRD_Table_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[2].Value & 2) == 1);
				if (!ConstraintExist_out) {
					CRD_Table_in.hasChanges = false;
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
		#endregion
	}
}