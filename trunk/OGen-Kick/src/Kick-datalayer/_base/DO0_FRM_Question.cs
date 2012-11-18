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
	/// FRM_Question DataObject which provides access to FRM_Question's Database table.
	/// </summary>
	[DOClassAttribute("FRM_Question", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_FRM_Question 
#else
			DO_FRM_Question 
#endif
	{

	 	#region Methods...
		#region public static SO_FRM_Question getObject(...);
		/// <summary>
		/// Selects FRM_Question values from Database and assigns them to the appropriate DO0_FRM_Question property.
		/// </summary>
		/// <param name="IDQuestion_in">IDQuestion</param>
		/// <returns>null if FRM_Question doesn't exists at Database</returns>
		public static SO_FRM_Question getObject(
			long IDQuestion_in
		) {
			return getObject(
				IDQuestion_in, 
				null
			);
		}

		/// <summary>
		/// Selects FRM_Question values from Database and assigns them to the appropriate DO_FRM_Question property.
		/// </summary>
		/// <param name="IDQuestion_in">IDQuestion</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if FRM_Question doesn't exists at Database</returns>
		public static SO_FRM_Question getObject(
			long IDQuestion_in, 
			DBConnection dbConnection_in
		) {
			SO_FRM_Question _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDQuestion_", DbType.Int64, ParameterDirection.InputOutput, IDQuestion_in, 0), 
				_connection.newDBDataParameter("IFQuestion__parent_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFQuestiontype_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("TX_Question_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("TX_Details_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IsRequired_", DbType.Boolean, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IsTemplate_", DbType.Boolean, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser__audit_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Date__audit_", DbType.DateTime, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_FRM_Question_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_FRM_Question();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDQuestion = 0L;
				} else {
					_output.IDQuestion = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFQuestion__parent_isNull = true;
				} else {
					_output.IFQuestion__parent = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IFQuestiontype_isNull = true;
				} else {
					_output.IFQuestiontype = (int)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.TX_Question_isNull = true;
				} else {
					_output.TX_Question = (long)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.TX_Details_isNull = true;
				} else {
					_output.TX_Details = (long)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.IsRequired_isNull = true;
				} else {
					_output.IsRequired = (bool)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.IsTemplate_isNull = true;
				} else {
					_output.IsTemplate = (bool)_dataparameters[6].Value;
				}
				if (_dataparameters[7].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[7].Value;
				}
				if (_dataparameters[8].Value == System.DBNull.Value) {
					_output.IFUser__audit = 0L;
				} else {
					_output.IFUser__audit = (long)_dataparameters[8].Value;
				}
				if (_dataparameters[9].Value == System.DBNull.Value) {
					_output.Date__audit = new DateTime(1900, 1, 1);
				} else {
					_output.Date__audit = (DateTime)_dataparameters[9].Value;
				}

				_output.HasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes FRM_Question from Database.
		/// </summary>
		/// <param name="IDQuestion_in">IDQuestion</param>
		public static void delObject(
			long IDQuestion_in
		) {
			delObject(
				IDQuestion_in, 
				null
			);
		}

		/// <summary>
		/// Deletes FRM_Question from Database.
		/// </summary>
		/// <param name="IDQuestion_in">IDQuestion</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDQuestion_in, 
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
				_connection.newDBDataParameter("IDQuestion_", DbType.Int64, ParameterDirection.Input, IDQuestion_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_FRM_Question_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if FRM_Question exists at Database
		/// </summary>
		/// <param name="IDQuestion_in">IDQuestion</param>
		/// <returns>True if FRM_Question exists at Database, False if not</returns>
		public static bool isObject(
			long IDQuestion_in
		) {
			return isObject(
				IDQuestion_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if FRM_Question exists at Database
		/// </summary>
		/// <param name="IDQuestion_in">IDQuestion</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if FRM_Question exists at Database, False if not</returns>
		public static bool isObject(
			long IDQuestion_in, 
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
				_connection.newDBDataParameter("IDQuestion_", DbType.Int64, ParameterDirection.Input, IDQuestion_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_FRM_Question_isObject", 
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
		/// Inserts FRM_Question values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_FRM_Question FRM_Question_in, 
			bool selectIdentity_in
		) {
			return insObject(
				FRM_Question_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts FRM_Question values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_FRM_Question FRM_Question_in, 
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
				_connection.newDBDataParameter("IDQuestion_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFQuestion__parent_", DbType.Int64, ParameterDirection.Input, FRM_Question_in.IFQuestion__parent_isNull ? null : (object)FRM_Question_in.IFQuestion__parent, 0), 
				_connection.newDBDataParameter("IFQuestiontype_", DbType.Int32, ParameterDirection.Input, FRM_Question_in.IFQuestiontype_isNull ? null : (object)FRM_Question_in.IFQuestiontype, 0), 
				_connection.newDBDataParameter("TX_Question_", DbType.Int64, ParameterDirection.Input, FRM_Question_in.TX_Question_isNull ? null : (object)FRM_Question_in.TX_Question, 0), 
				_connection.newDBDataParameter("TX_Details_", DbType.Int64, ParameterDirection.Input, FRM_Question_in.TX_Details_isNull ? null : (object)FRM_Question_in.TX_Details, 0), 
				_connection.newDBDataParameter("IsRequired_", DbType.Boolean, ParameterDirection.Input, FRM_Question_in.IsRequired_isNull ? null : (object)FRM_Question_in.IsRequired, 0), 
				_connection.newDBDataParameter("IsTemplate_", DbType.Boolean, ParameterDirection.Input, FRM_Question_in.IsTemplate_isNull ? null : (object)FRM_Question_in.IsTemplate, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, FRM_Question_in.IFApplication_isNull ? null : (object)FRM_Question_in.IFApplication, 0), 
				_connection.newDBDataParameter("IFUser__audit_", DbType.Int64, ParameterDirection.Input, FRM_Question_in.IFUser__audit, 0), 
				_connection.newDBDataParameter("Date__audit_", DbType.DateTime, ParameterDirection.Input, FRM_Question_in.Date__audit, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_FRM_Question_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			FRM_Question_in.IDQuestion = (long)_dataparameters[0].Value;FRM_Question_in.HasChanges = false;
			

			return FRM_Question_in.IDQuestion;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates FRM_Question values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_FRM_Question FRM_Question_in, 
			bool forceUpdate_in
		) {
			updObject(
				FRM_Question_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates FRM_Question values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_FRM_Question FRM_Question_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || FRM_Question_in.HasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__Utilities.DBConnection_createInstance(
						DO__Utilities.DBServerType,
						DO__Utilities.DBConnectionstring,
						DO__Utilities.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDQuestion_", DbType.Int64, ParameterDirection.Input, FRM_Question_in.IDQuestion, 0), 
					_connection.newDBDataParameter("IFQuestion__parent_", DbType.Int64, ParameterDirection.Input, FRM_Question_in.IFQuestion__parent_isNull ? null : (object)FRM_Question_in.IFQuestion__parent, 0), 
					_connection.newDBDataParameter("IFQuestiontype_", DbType.Int32, ParameterDirection.Input, FRM_Question_in.IFQuestiontype_isNull ? null : (object)FRM_Question_in.IFQuestiontype, 0), 
					_connection.newDBDataParameter("TX_Question_", DbType.Int64, ParameterDirection.Input, FRM_Question_in.TX_Question_isNull ? null : (object)FRM_Question_in.TX_Question, 0), 
					_connection.newDBDataParameter("TX_Details_", DbType.Int64, ParameterDirection.Input, FRM_Question_in.TX_Details_isNull ? null : (object)FRM_Question_in.TX_Details, 0), 
					_connection.newDBDataParameter("IsRequired_", DbType.Boolean, ParameterDirection.Input, FRM_Question_in.IsRequired_isNull ? null : (object)FRM_Question_in.IsRequired, 0), 
					_connection.newDBDataParameter("IsTemplate_", DbType.Boolean, ParameterDirection.Input, FRM_Question_in.IsTemplate_isNull ? null : (object)FRM_Question_in.IsTemplate, 0), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, FRM_Question_in.IFApplication_isNull ? null : (object)FRM_Question_in.IFApplication, 0), 
					_connection.newDBDataParameter("IFUser__audit_", DbType.Int64, ParameterDirection.Input, FRM_Question_in.IFUser__audit, 0), 
					_connection.newDBDataParameter("Date__audit_", DbType.DateTime, ParameterDirection.Input, FRM_Question_in.Date__audit, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_FRM_Question_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				FRM_Question_in.HasChanges = false;
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