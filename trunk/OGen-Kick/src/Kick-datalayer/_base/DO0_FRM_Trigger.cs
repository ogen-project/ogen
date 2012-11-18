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
	/// FRM_Trigger DataObject which provides access to FRM_Trigger's Database table.
	/// </summary>
	[DOClassAttribute("FRM_Trigger", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_FRM_Trigger 
#else
			DO_FRM_Trigger 
#endif
	{

	 	#region Methods...
		#region public static SO_FRM_Trigger getObject(...);
		/// <summary>
		/// Selects FRM_Trigger values from Database and assigns them to the appropriate DO0_FRM_Trigger property.
		/// </summary>
		/// <param name="IDTrigger_in">IDTrigger</param>
		/// <returns>null if FRM_Trigger doesn't exists at Database</returns>
		public static SO_FRM_Trigger getObject(
			int IDTrigger_in
		) {
			return getObject(
				IDTrigger_in, 
				null
			);
		}

		/// <summary>
		/// Selects FRM_Trigger values from Database and assigns them to the appropriate DO_FRM_Trigger property.
		/// </summary>
		/// <param name="IDTrigger_in">IDTrigger</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if FRM_Trigger doesn't exists at Database</returns>
		public static SO_FRM_Trigger getObject(
			int IDTrigger_in, 
			DBConnection dbConnection_in
		) {
			SO_FRM_Trigger _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDTrigger_", DbType.Int32, ParameterDirection.InputOutput, IDTrigger_in, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Output, null, 255)
			};
			_connection.Execute_SQLFunction("sp0_FRM_Trigger_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_FRM_Trigger();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDTrigger = 0;
				} else {
					_output.IDTrigger = (int)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.Name = string.Empty;
				} else {
					_output.Name = (string)_dataparameters[1].Value;
				}

				_output.HasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes FRM_Trigger from Database.
		/// </summary>
		/// <param name="IDTrigger_in">IDTrigger</param>
		public static void delObject(
			int IDTrigger_in
		) {
			delObject(
				IDTrigger_in, 
				null
			);
		}

		/// <summary>
		/// Deletes FRM_Trigger from Database.
		/// </summary>
		/// <param name="IDTrigger_in">IDTrigger</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			int IDTrigger_in, 
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
				_connection.newDBDataParameter("IDTrigger_", DbType.Int32, ParameterDirection.Input, IDTrigger_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_FRM_Trigger_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if FRM_Trigger exists at Database
		/// </summary>
		/// <param name="IDTrigger_in">IDTrigger</param>
		/// <returns>True if FRM_Trigger exists at Database, False if not</returns>
		public static bool isObject(
			int IDTrigger_in
		) {
			return isObject(
				IDTrigger_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if FRM_Trigger exists at Database
		/// </summary>
		/// <param name="IDTrigger_in">IDTrigger</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if FRM_Trigger exists at Database, False if not</returns>
		public static bool isObject(
			int IDTrigger_in, 
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
				_connection.newDBDataParameter("IDTrigger_", DbType.Int32, ParameterDirection.Input, IDTrigger_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_FRM_Trigger_isObject", 
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
		/// Inserts FRM_Trigger values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static int insObject(
			SO_FRM_Trigger FRM_Trigger_in, 
			bool selectIdentity_in
		) {
			return insObject(
				FRM_Trigger_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts FRM_Trigger values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static int insObject(
			SO_FRM_Trigger FRM_Trigger_in, 
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
				_connection.newDBDataParameter("IDTrigger_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, FRM_Trigger_in.Name, 255), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_FRM_Trigger_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			FRM_Trigger_in.IDTrigger = (int)_dataparameters[0].Value;FRM_Trigger_in.HasChanges = false;
			

			return FRM_Trigger_in.IDTrigger;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates FRM_Trigger values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_FRM_Trigger FRM_Trigger_in, 
			bool forceUpdate_in
		) {
			updObject(
				FRM_Trigger_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates FRM_Trigger values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_FRM_Trigger FRM_Trigger_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || FRM_Trigger_in.HasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__Utilities.DBConnection_createInstance(
						DO__Utilities.DBServerType,
						DO__Utilities.DBConnectionstring,
						DO__Utilities.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDTrigger_", DbType.Int32, ParameterDirection.Input, FRM_Trigger_in.IDTrigger, 0), 
					_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, FRM_Trigger_in.Name, 255)
				};
				_connection.Execute_SQLFunction(
					"sp0_FRM_Trigger_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				FRM_Trigger_in.HasChanges = false;
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