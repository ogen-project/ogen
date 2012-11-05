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
	/// LOG_Type DataObject which provides access to LOG_Type's Database table.
	/// </summary>
	[DOClassAttribute("LOG_Type", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_LOG_Type 
#else
			DO_LOG_Type 
#endif
	{

	 	#region Methods...
		#region public static SO_LOG_Type getObject(...);
		/// <summary>
		/// Selects LOG_Type values from Database and assigns them to the appropriate DO0_LOG_Type property.
		/// </summary>
		/// <param name="IDType_in">IDType</param>
		/// <returns>null if LOG_Type doesn't exists at Database</returns>
		public static SO_LOG_Type getObject(
			int IDType_in
		) {
			return getObject(
				IDType_in, 
				null
			);
		}

		/// <summary>
		/// Selects LOG_Type values from Database and assigns them to the appropriate DO_LOG_Type property.
		/// </summary>
		/// <param name="IDType_in">IDType</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if LOG_Type doesn't exists at Database</returns>
		public static SO_LOG_Type getObject(
			int IDType_in, 
			DBConnection dbConnection_in
		) {
			SO_LOG_Type _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDType_", DbType.Int32, ParameterDirection.InputOutput, IDType_in, 0), 
				_connection.newDBDataParameter("IFType_parent_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Output, null, 20), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_LOG_Type_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_LOG_Type();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDType = 0;
				} else {
					_output.IDType = (int)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFType_parent_isNull = true;
				} else {
					_output.IFType_parent = (int)_dataparameters[1].Value;
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

				_output.hasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes LOG_Type from Database.
		/// </summary>
		/// <param name="IDType_in">IDType</param>
		public static void delObject(
			int IDType_in
		) {
			delObject(
				IDType_in, 
				null
			);
		}

		/// <summary>
		/// Deletes LOG_Type from Database.
		/// </summary>
		/// <param name="IDType_in">IDType</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			int IDType_in, 
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
				_connection.newDBDataParameter("IDType_", DbType.Int32, ParameterDirection.Input, IDType_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_LOG_Type_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if LOG_Type exists at Database
		/// </summary>
		/// <param name="IDType_in">IDType</param>
		/// <returns>True if LOG_Type exists at Database, False if not</returns>
		public static bool isObject(
			int IDType_in
		) {
			return isObject(
				IDType_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if LOG_Type exists at Database
		/// </summary>
		/// <param name="IDType_in">IDType</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if LOG_Type exists at Database, False if not</returns>
		public static bool isObject(
			int IDType_in, 
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
				_connection.newDBDataParameter("IDType_", DbType.Int32, ParameterDirection.Input, IDType_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_LOG_Type_isObject", 
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
		/// Inserts/Updates LOG_Type values into/on Database. Inserts if LOG_Type doesn't exist or Updates if LOG_Type already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_LOG_Type LOG_Type_in, 
			bool forceUpdate_in
		) {
			return setObject(
				LOG_Type_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates LOG_Type values into/on Database. Inserts if LOG_Type doesn't exist or Updates if LOG_Type already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_LOG_Type LOG_Type_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || LOG_Type_in.hasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__Utilities.DBConnection_createInstance(
						DO__Utilities.DBServerType,
						DO__Utilities.DBConnectionstring,
						DO__Utilities.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDType_", DbType.Int32, ParameterDirection.Input, LOG_Type_in.IDType, 0), 
					_connection.newDBDataParameter("IFType_parent_", DbType.Int32, ParameterDirection.Input, LOG_Type_in.IFType_parent_isNull ? null : (object)LOG_Type_in.IFType_parent, 0), 
					_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, LOG_Type_in.Name, 20), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, LOG_Type_in.IFApplication_isNull ? null : (object)LOG_Type_in.IFApplication, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_LOG_Type_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[4].Value & 2) == 1);
				if (!ConstraintExist_out) {
					LOG_Type_in.hasChanges = false;
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
		#endregion
	}
}