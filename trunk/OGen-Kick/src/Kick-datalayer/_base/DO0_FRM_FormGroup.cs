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
	/// FRM_FormGroup DataObject which provides access to FRM_FormGroup's Database table.
	/// </summary>
	[DOClassAttribute("FRM_FormGroup", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_FRM_FormGroup 
#else
			DO_FRM_FormGroup 
#endif
	{

	 	#region Methods...
		#region public static SO_FRM_FormGroup getObject(...);
		/// <summary>
		/// Selects FRM_FormGroup values from Database and assigns them to the appropriate DO0_FRM_FormGroup property.
		/// </summary>
		/// <param name="IFForm_in">IFForm</param>
		/// <param name="IFGroup_in">IFGroup</param>
		/// <returns>null if FRM_FormGroup doesn't exists at Database</returns>
		public static SO_FRM_FormGroup getObject(
			long IFForm_in, 
			long IFGroup_in
		) {
			return getObject(
				IFForm_in, 
				IFGroup_in, 
				null
			);
		}

		/// <summary>
		/// Selects FRM_FormGroup values from Database and assigns them to the appropriate DO_FRM_FormGroup property.
		/// </summary>
		/// <param name="IFForm_in">IFForm</param>
		/// <param name="IFGroup_in">IFGroup</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if FRM_FormGroup doesn't exists at Database</returns>
		public static SO_FRM_FormGroup getObject(
			long IFForm_in, 
			long IFGroup_in, 
			DBConnection dbConnection_in
		) {
			SO_FRM_FormGroup _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFForm_", DbType.Int64, ParameterDirection.InputOutput, IFForm_in, 0), 
				_connection.newDBDataParameter("IFGroup_", DbType.Int64, ParameterDirection.InputOutput, IFGroup_in, 0), 
				_connection.newDBDataParameter("Order_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser__audit_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Date__audit_", DbType.DateTime, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_FRM_FormGroup_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_FRM_FormGroup();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFForm = 0L;
				} else {
					_output.IFForm = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFGroup = 0L;
				} else {
					_output.IFGroup = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.Order_isNull = true;
				} else {
					_output.Order = (int)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.IFUser__audit = 0L;
				} else {
					_output.IFUser__audit = (long)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.Date__audit = new DateTime(1900, 1, 1);
				} else {
					_output.Date__audit = (DateTime)_dataparameters[4].Value;
				}

				_output.HasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes FRM_FormGroup from Database.
		/// </summary>
		/// <param name="IFForm_in">IFForm</param>
		/// <param name="IFGroup_in">IFGroup</param>
		public static void delObject(
			long IFForm_in, 
			long IFGroup_in
		) {
			delObject(
				IFForm_in, 
				IFGroup_in, 
				null
			);
		}

		/// <summary>
		/// Deletes FRM_FormGroup from Database.
		/// </summary>
		/// <param name="IFForm_in">IFForm</param>
		/// <param name="IFGroup_in">IFGroup</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFForm_in, 
			long IFGroup_in, 
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
				_connection.newDBDataParameter("IFForm_", DbType.Int64, ParameterDirection.Input, IFForm_in, 0), 
				_connection.newDBDataParameter("IFGroup_", DbType.Int64, ParameterDirection.Input, IFGroup_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_FRM_FormGroup_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if FRM_FormGroup exists at Database
		/// </summary>
		/// <param name="IFForm_in">IFForm</param>
		/// <param name="IFGroup_in">IFGroup</param>
		/// <returns>True if FRM_FormGroup exists at Database, False if not</returns>
		public static bool isObject(
			long IFForm_in, 
			long IFGroup_in
		) {
			return isObject(
				IFForm_in, 
				IFGroup_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if FRM_FormGroup exists at Database
		/// </summary>
		/// <param name="IFForm_in">IFForm</param>
		/// <param name="IFGroup_in">IFGroup</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if FRM_FormGroup exists at Database, False if not</returns>
		public static bool isObject(
			long IFForm_in, 
			long IFGroup_in, 
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
				_connection.newDBDataParameter("IFForm_", DbType.Int64, ParameterDirection.Input, IFForm_in, 0), 
				_connection.newDBDataParameter("IFGroup_", DbType.Int64, ParameterDirection.Input, IFGroup_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_FRM_FormGroup_isObject", 
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
		/// Inserts/Updates FRM_FormGroup values into/on Database. Inserts if FRM_FormGroup doesn't exist or Updates if FRM_FormGroup already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_FRM_FormGroup FRM_FormGroup_in, 
			bool forceUpdate_in
		) {
			return setObject(
				FRM_FormGroup_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates FRM_FormGroup values into/on Database. Inserts if FRM_FormGroup doesn't exist or Updates if FRM_FormGroup already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_FRM_FormGroup FRM_FormGroup_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || FRM_FormGroup_in.HasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__Utilities.DBConnection_createInstance(
						DO__Utilities.DBServerType,
						DO__Utilities.DBConnectionstring,
						DO__Utilities.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFForm_", DbType.Int64, ParameterDirection.Input, FRM_FormGroup_in.IFForm, 0), 
					_connection.newDBDataParameter("IFGroup_", DbType.Int64, ParameterDirection.Input, FRM_FormGroup_in.IFGroup, 0), 
					_connection.newDBDataParameter("Order_", DbType.Int32, ParameterDirection.Input, FRM_FormGroup_in.Order_isNull ? null : (object)FRM_FormGroup_in.Order, 0), 
					_connection.newDBDataParameter("IFUser__audit_", DbType.Int64, ParameterDirection.Input, FRM_FormGroup_in.IFUser__audit, 0), 
					_connection.newDBDataParameter("Date__audit_", DbType.DateTime, ParameterDirection.Input, FRM_FormGroup_in.Date__audit, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_FRM_FormGroup_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[5].Value & 2) == 1);
				if (!ConstraintExist_out) {
					FRM_FormGroup_in.HasChanges = false;
				}

				return (((int)_dataparameters[5].Value & 1) != 1);
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