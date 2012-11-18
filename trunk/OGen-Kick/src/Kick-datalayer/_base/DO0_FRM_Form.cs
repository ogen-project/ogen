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
	/// FRM_Form DataObject which provides access to FRM_Form's Database table.
	/// </summary>
	[DOClassAttribute("FRM_Form", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_FRM_Form 
#else
			DO_FRM_Form 
#endif
	{

	 	#region Methods...
		#region public static SO_FRM_Form getObject(...);
		/// <summary>
		/// Selects FRM_Form values from Database and assigns them to the appropriate DO0_FRM_Form property.
		/// </summary>
		/// <param name="IDForm_in">IDForm</param>
		/// <returns>null if FRM_Form doesn't exists at Database</returns>
		public static SO_FRM_Form getObject(
			long IDForm_in
		) {
			return getObject(
				IDForm_in, 
				null
			);
		}

		/// <summary>
		/// Selects FRM_Form values from Database and assigns them to the appropriate DO_FRM_Form property.
		/// </summary>
		/// <param name="IDForm_in">IDForm</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if FRM_Form doesn't exists at Database</returns>
		public static SO_FRM_Form getObject(
			long IDForm_in, 
			DBConnection dbConnection_in
		) {
			SO_FRM_Form _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDForm_", DbType.Int64, ParameterDirection.InputOutput, IDForm_in, 0), 
				_connection.newDBDataParameter("TX_Name_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("TX_Description_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser__audit_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Date__audit_", DbType.DateTime, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_FRM_Form_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_FRM_Form();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDForm = 0L;
				} else {
					_output.IDForm = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.TX_Name_isNull = true;
				} else {
					_output.TX_Name = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.TX_Description_isNull = true;
				} else {
					_output.TX_Description = (long)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.IFUser__audit = 0L;
				} else {
					_output.IFUser__audit = (long)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.Date__audit = new DateTime(1900, 1, 1);
				} else {
					_output.Date__audit = (DateTime)_dataparameters[5].Value;
				}

				_output.HasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes FRM_Form from Database.
		/// </summary>
		/// <param name="IDForm_in">IDForm</param>
		public static void delObject(
			long IDForm_in
		) {
			delObject(
				IDForm_in, 
				null
			);
		}

		/// <summary>
		/// Deletes FRM_Form from Database.
		/// </summary>
		/// <param name="IDForm_in">IDForm</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDForm_in, 
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
				_connection.newDBDataParameter("IDForm_", DbType.Int64, ParameterDirection.Input, IDForm_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_FRM_Form_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if FRM_Form exists at Database
		/// </summary>
		/// <param name="IDForm_in">IDForm</param>
		/// <returns>True if FRM_Form exists at Database, False if not</returns>
		public static bool isObject(
			long IDForm_in
		) {
			return isObject(
				IDForm_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if FRM_Form exists at Database
		/// </summary>
		/// <param name="IDForm_in">IDForm</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if FRM_Form exists at Database, False if not</returns>
		public static bool isObject(
			long IDForm_in, 
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
				_connection.newDBDataParameter("IDForm_", DbType.Int64, ParameterDirection.Input, IDForm_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_FRM_Form_isObject", 
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
		/// Inserts FRM_Form values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_FRM_Form FRM_Form_in, 
			bool selectIdentity_in
		) {
			return insObject(
				FRM_Form_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts FRM_Form values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_FRM_Form FRM_Form_in, 
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
				_connection.newDBDataParameter("IDForm_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("TX_Name_", DbType.Int64, ParameterDirection.Input, FRM_Form_in.TX_Name_isNull ? null : (object)FRM_Form_in.TX_Name, 0), 
				_connection.newDBDataParameter("TX_Description_", DbType.Int64, ParameterDirection.Input, FRM_Form_in.TX_Description_isNull ? null : (object)FRM_Form_in.TX_Description, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, FRM_Form_in.IFApplication_isNull ? null : (object)FRM_Form_in.IFApplication, 0), 
				_connection.newDBDataParameter("IFUser__audit_", DbType.Int64, ParameterDirection.Input, FRM_Form_in.IFUser__audit, 0), 
				_connection.newDBDataParameter("Date__audit_", DbType.DateTime, ParameterDirection.Input, FRM_Form_in.Date__audit, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_FRM_Form_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			FRM_Form_in.IDForm = (long)_dataparameters[0].Value;FRM_Form_in.HasChanges = false;
			

			return FRM_Form_in.IDForm;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates FRM_Form values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_FRM_Form FRM_Form_in, 
			bool forceUpdate_in
		) {
			updObject(
				FRM_Form_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates FRM_Form values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_FRM_Form FRM_Form_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || FRM_Form_in.HasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__Utilities.DBConnection_createInstance(
						DO__Utilities.DBServerType,
						DO__Utilities.DBConnectionstring,
						DO__Utilities.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDForm_", DbType.Int64, ParameterDirection.Input, FRM_Form_in.IDForm, 0), 
					_connection.newDBDataParameter("TX_Name_", DbType.Int64, ParameterDirection.Input, FRM_Form_in.TX_Name_isNull ? null : (object)FRM_Form_in.TX_Name, 0), 
					_connection.newDBDataParameter("TX_Description_", DbType.Int64, ParameterDirection.Input, FRM_Form_in.TX_Description_isNull ? null : (object)FRM_Form_in.TX_Description, 0), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, FRM_Form_in.IFApplication_isNull ? null : (object)FRM_Form_in.IFApplication, 0), 
					_connection.newDBDataParameter("IFUser__audit_", DbType.Int64, ParameterDirection.Input, FRM_Form_in.IFUser__audit, 0), 
					_connection.newDBDataParameter("Date__audit_", DbType.DateTime, ParameterDirection.Input, FRM_Form_in.Date__audit, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_FRM_Form_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				FRM_Form_in.HasChanges = false;
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