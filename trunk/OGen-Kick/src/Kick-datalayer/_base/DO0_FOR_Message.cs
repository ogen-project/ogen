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
	/// FOR_Message DataObject which provides access to FOR_Message's Database table.
	/// </summary>
	[DOClassAttribute("FOR_Message", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_FOR_Message 
#else
			DO_FOR_Message 
#endif
	{

	 	#region Methods...
		#region public static SO_FOR_Message getObject(...);
		/// <summary>
		/// Selects FOR_Message values from Database and assigns them to the appropriate DO0_FOR_Message property.
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		/// <returns>null if FOR_Message doesn't exists at Database</returns>
		public static SO_FOR_Message getObject(
			long IDMessage_in
		) {
			return getObject(
				IDMessage_in, 
				null
			);
		}

		/// <summary>
		/// Selects FOR_Message values from Database and assigns them to the appropriate DO_FOR_Message property.
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if FOR_Message doesn't exists at Database</returns>
		public static SO_FOR_Message getObject(
			long IDMessage_in, 
			DBConnection dbConnection_in
		) {
			SO_FOR_Message _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.InputOutput, IDMessage_in, 0), 
				_connection.newDBDataParameter("IFMessage__parent_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IsSticky_", DbType.Boolean, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Subject_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Message__small_", DbType.AnsiString, ParameterDirection.Output, null, 8000), 
				_connection.newDBDataParameter("Message__large_", DbType.AnsiString, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Publish_date_", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_FOR_Message_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_FOR_Message();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDMessage = 0L;
				} else {
					_output.IDMessage = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFMessage__parent_isNull = true;
				} else {
					_output.IFMessage__parent = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IsSticky = false;
				} else {
					_output.IsSticky = (bool)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.Subject_isNull = true;
				} else {
					_output.Subject = (string)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.Message__small_isNull = true;
				} else {
					_output.Message__small = (string)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.Message__large_isNull = true;
				} else {
					_output.Message__large = (string)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.IFUser__Publisher_isNull = true;
				} else {
					_output.IFUser__Publisher = (long)_dataparameters[6].Value;
				}
				if (_dataparameters[7].Value == System.DBNull.Value) {
					_output.Publish_date = new DateTime(1900, 1, 1);
				} else {
					_output.Publish_date = (DateTime)_dataparameters[7].Value;
				}
				if (_dataparameters[8].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[8].Value;
				}

				_output.HasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes FOR_Message from Database.
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		public static void delObject(
			long IDMessage_in
		) {
			delObject(
				IDMessage_in, 
				null
			);
		}

		/// <summary>
		/// Deletes FOR_Message from Database.
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDMessage_in, 
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
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Input, IDMessage_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_FOR_Message_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if FOR_Message exists at Database
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		/// <returns>True if FOR_Message exists at Database, False if not</returns>
		public static bool isObject(
			long IDMessage_in
		) {
			return isObject(
				IDMessage_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if FOR_Message exists at Database
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if FOR_Message exists at Database, False if not</returns>
		public static bool isObject(
			long IDMessage_in, 
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
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Input, IDMessage_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_FOR_Message_isObject", 
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
		/// Inserts FOR_Message values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_FOR_Message FOR_Message_in, 
			bool selectIdentity_in
		) {
			return insObject(
				FOR_Message_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts FOR_Message values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_FOR_Message FOR_Message_in, 
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
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFMessage__parent_", DbType.Int64, ParameterDirection.Input, FOR_Message_in.IFMessage__parent_isNull ? null : (object)FOR_Message_in.IFMessage__parent, 0), 
				_connection.newDBDataParameter("IsSticky_", DbType.Boolean, ParameterDirection.Input, FOR_Message_in.IsSticky, 0), 
				_connection.newDBDataParameter("Subject_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Subject_isNull ? null : (object)FOR_Message_in.Subject, 255), 
				_connection.newDBDataParameter("Message__small_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Message__small_isNull ? null : (object)FOR_Message_in.Message__small, 8000), 
				_connection.newDBDataParameter("Message__large_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Message__large_isNull ? null : (object)FOR_Message_in.Message__large, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_", DbType.Int64, ParameterDirection.Input, FOR_Message_in.IFUser__Publisher_isNull ? null : (object)FOR_Message_in.IFUser__Publisher, 0), 
				_connection.newDBDataParameter("Publish_date_", DbType.DateTime, ParameterDirection.Input, FOR_Message_in.Publish_date, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, FOR_Message_in.IFApplication_isNull ? null : (object)FOR_Message_in.IFApplication, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_FOR_Message_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			FOR_Message_in.IDMessage = (long)_dataparameters[0].Value;FOR_Message_in.HasChanges = false;
			

			return FOR_Message_in.IDMessage;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates FOR_Message values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_FOR_Message FOR_Message_in, 
			bool forceUpdate_in
		) {
			updObject(
				FOR_Message_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates FOR_Message values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_FOR_Message FOR_Message_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || FOR_Message_in.HasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__Utilities.DBConnection_createInstance(
						DO__Utilities.DBServerType,
						DO__Utilities.DBConnectionstring,
						DO__Utilities.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Input, FOR_Message_in.IDMessage, 0), 
					_connection.newDBDataParameter("IFMessage__parent_", DbType.Int64, ParameterDirection.Input, FOR_Message_in.IFMessage__parent_isNull ? null : (object)FOR_Message_in.IFMessage__parent, 0), 
					_connection.newDBDataParameter("IsSticky_", DbType.Boolean, ParameterDirection.Input, FOR_Message_in.IsSticky, 0), 
					_connection.newDBDataParameter("Subject_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Subject_isNull ? null : (object)FOR_Message_in.Subject, 255), 
					_connection.newDBDataParameter("Message__small_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Message__small_isNull ? null : (object)FOR_Message_in.Message__small, 8000), 
					_connection.newDBDataParameter("Message__large_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Message__large_isNull ? null : (object)FOR_Message_in.Message__large, 0), 
					_connection.newDBDataParameter("IFUser__Publisher_", DbType.Int64, ParameterDirection.Input, FOR_Message_in.IFUser__Publisher_isNull ? null : (object)FOR_Message_in.IFUser__Publisher, 0), 
					_connection.newDBDataParameter("Publish_date_", DbType.DateTime, ParameterDirection.Input, FOR_Message_in.Publish_date, 0), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, FOR_Message_in.IFApplication_isNull ? null : (object)FOR_Message_in.IFApplication, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_FOR_Message_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				FOR_Message_in.HasChanges = false;
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