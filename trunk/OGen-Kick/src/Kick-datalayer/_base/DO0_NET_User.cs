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
	/// NET_User DataObject which provides access to NET_User's Database table.
	/// </summary>
	[DOClassAttribute("NET_User", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_NET_User 
#else
			DO_NET_User 
#endif
	{

	 	#region Methods...
		#region public static SO_NET_User getObject(...);
		/// <summary>
		/// Selects NET_User values from Database and assigns them to the appropriate DO0_NET_User property.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <returns>null if NET_User doesn't exists at Database</returns>
		public static SO_NET_User getObject(
			long IFUser_in
		) {
			return getObject(
				IFUser_in, 
				null
			);
		}

		/// <summary>
		/// Selects NET_User values from Database and assigns them to the appropriate DO_NET_User property.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NET_User doesn't exists at Database</returns>
		public static SO_NET_User getObject(
			long IFUser_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_User _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.InputOutput, IFUser_in, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Email_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Email_verify_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_NET_User_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NET_User();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFUser = 0L;
				} else {
					_output.IFUser = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.Name_isNull = true;
				} else {
					_output.Name = (string)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.Email = string.Empty;
				} else {
					_output.Email = (string)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.Email_verify_isNull = true;
				} else {
					_output.Email_verify = (string)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[4].Value;
				}

				_output.HasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NET_User from Database.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		public static void delObject(
			long IFUser_in
		) {
			delObject(
				IFUser_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_User from Database.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFUser_in, 
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
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, IFUser_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NET_User_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NET_User exists at Database
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <returns>True if NET_User exists at Database, False if not</returns>
		public static bool isObject(
			long IFUser_in
		) {
			return isObject(
				IFUser_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NET_User exists at Database
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_User exists at Database, False if not</returns>
		public static bool isObject(
			long IFUser_in, 
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
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, IFUser_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NET_User_isObject", 
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
		/// Inserts/Updates NET_User values into/on Database. Inserts if NET_User doesn't exist or Updates if NET_User already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NET_User NET_User_in, 
			bool forceUpdate_in, 
			out bool ConstraintExist_out
		) {
			return setObject(
				NET_User_in, 
				forceUpdate_in, 
				out ConstraintExist_out, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates NET_User values into/on Database. Inserts if NET_User doesn't exist or Updates if NET_User already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NET_User NET_User_in, 
			bool forceUpdate_in, 
			out bool ConstraintExist_out, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || NET_User_in.HasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__Utilities.DBConnection_createInstance(
						DO__Utilities.DBServerType,
						DO__Utilities.DBConnectionstring,
						DO__Utilities.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, NET_User_in.IFUser, 0), 
					_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, NET_User_in.Name_isNull ? null : (object)NET_User_in.Name, 255), 
					_connection.newDBDataParameter("Email_", DbType.AnsiString, ParameterDirection.Input, NET_User_in.Email, 255), 
					_connection.newDBDataParameter("Email_verify_", DbType.AnsiString, ParameterDirection.Input, NET_User_in.Email_verify_isNull ? null : (object)NET_User_in.Email_verify, 255), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, NET_User_in.IFApplication_isNull ? null : (object)NET_User_in.IFApplication, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1), 
					//_connection.newDBDataParameter("ConstraintExist", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NET_User_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[5].Value & 2) == 1);
				if (!ConstraintExist_out) {
					NET_User_in.HasChanges = false;
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
		#region ???Object_byEmail...
		#region public static SO_NET_User getObject_byEmail(...);
		/// <summary>
		/// Selects NET_User values from Database (based on the search condition) and assigns them to the appropriate DO0_NET_User property.
		/// </summary>
		/// <param name="Email_search_in">Email search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>null if NET_User doesn't exists at Database</returns>
		public static SO_NET_User getObject_byEmail(
			string Email_search_in, 
			int IDApplication_search_in
		) {
			return getObject_byEmail(
				Email_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Selects NET_User values from Database (based on the search condition) and assigns them to the appropriate DO0_NET_User property.
		/// </summary>
		/// <param name="Email_search_in">Email search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NET_User doesn't exists at Database</returns>
		public static SO_NET_User getObject_byEmail(
			string Email_search_in, 
			int IDApplication_search_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_User _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("Email_search_", DbType.AnsiString, ParameterDirection.Input, Email_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
				_connection.newDBDataParameter("IFUser", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Email", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Email_verify", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("IFApplication", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NET_User_getObject_byEmail", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[2].Value != DBNull.Value) {
				_output = new SO_NET_User();
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IFUser = 0L;
				} else {
					_output.IFUser = (long)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.Name_isNull = true;
				} else {
					_output.Name = (string)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.Email = string.Empty;
				} else {
					_output.Email = (string)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.Email_verify_isNull = true;
				} else {
					_output.Email_verify = (string)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[6].Value;
				}

				return _output;
			}

			return null;
		}
		#endregion
		#region public static bool delObject_byEmail(...);
		/// <summary>
		/// Deletes NET_User from Database (based on the search condition).
		/// </summary>
		/// <param name="Email_search_in"> Email search condition</param>
		/// <param name="IDApplication_search_in"> IDApplication search condition</param>
		/// <returns>True if NET_User existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byEmail(
			string Email_search_in, 
			int IDApplication_search_in
		) {
			return delObject_byEmail(
				Email_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_User from Database (based on the search condition).
		/// </summary>
		/// <param name="Email_search_in"> Email search condition</param>
		/// <param name="IDApplication_search_in"> IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_User existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byEmail(
			string Email_search_in, 
			int IDApplication_search_in, 
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
				_connection.newDBDataParameter("Email_search_", DbType.AnsiString, ParameterDirection.Input, Email_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 

				_connection.newDBDataParameter("Exists_", DbType.Boolean, ParameterDirection.Output, null, 1)
			};
			_connection.Execute_SQLFunction("sp0_NET_User_delObject_byEmail", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return ((bool)_dataparameters[2].Value);
		}
		#endregion
		#region public static bool isObject_byEmail(...);
		/// <summary>
		/// Checks to see if NET_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="Email_search_in">Email search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if NET_User exists at Database, False if not</returns>
		public static bool isObject_byEmail(
			string Email_search_in, 
			int IDApplication_search_in
		) {
			return isObject_byEmail(
				Email_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NET_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="Email_search_in">Email search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_User exists at Database, False if not</returns>
		public static bool isObject_byEmail(
			string Email_search_in, 
			int IDApplication_search_in, 
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
				_connection.newDBDataParameter("Email_search_", DbType.AnsiString, ParameterDirection.Input, Email_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NET_User_isObject_byEmail", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???Object_byEmail_verify...
		#region public static SO_NET_User getObject_byEmail_verify(...);
		/// <summary>
		/// Selects NET_User values from Database (based on the search condition) and assigns them to the appropriate DO0_NET_User property.
		/// </summary>
		/// <param name="Email_verify_search_in">Email_verify search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>null if NET_User doesn't exists at Database</returns>
		public static SO_NET_User getObject_byEmail_verify(
			string Email_verify_search_in, 
			int IDApplication_search_in
		) {
			return getObject_byEmail_verify(
				Email_verify_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Selects NET_User values from Database (based on the search condition) and assigns them to the appropriate DO0_NET_User property.
		/// </summary>
		/// <param name="Email_verify_search_in">Email_verify search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NET_User doesn't exists at Database</returns>
		public static SO_NET_User getObject_byEmail_verify(
			string Email_verify_search_in, 
			int IDApplication_search_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_User _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("Email_verify_search_", DbType.AnsiString, ParameterDirection.Input, Email_verify_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
				_connection.newDBDataParameter("IFUser", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Email", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Email_verify", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("IFApplication", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NET_User_getObject_byEmail_verify", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[2].Value != DBNull.Value) {
				_output = new SO_NET_User();
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IFUser = 0L;
				} else {
					_output.IFUser = (long)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.Name_isNull = true;
				} else {
					_output.Name = (string)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.Email = string.Empty;
				} else {
					_output.Email = (string)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.Email_verify_isNull = true;
				} else {
					_output.Email_verify = (string)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[6].Value;
				}

				return _output;
			}

			return null;
		}
		#endregion
		#region public static bool delObject_byEmail_verify(...);
		/// <summary>
		/// Deletes NET_User from Database (based on the search condition).
		/// </summary>
		/// <param name="Email_verify_search_in"> Email_verify search condition</param>
		/// <param name="IDApplication_search_in"> IDApplication search condition</param>
		/// <returns>True if NET_User existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byEmail_verify(
			string Email_verify_search_in, 
			int IDApplication_search_in
		) {
			return delObject_byEmail_verify(
				Email_verify_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_User from Database (based on the search condition).
		/// </summary>
		/// <param name="Email_verify_search_in"> Email_verify search condition</param>
		/// <param name="IDApplication_search_in"> IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_User existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byEmail_verify(
			string Email_verify_search_in, 
			int IDApplication_search_in, 
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
				_connection.newDBDataParameter("Email_verify_search_", DbType.AnsiString, ParameterDirection.Input, Email_verify_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 

				_connection.newDBDataParameter("Exists_", DbType.Boolean, ParameterDirection.Output, null, 1)
			};
			_connection.Execute_SQLFunction("sp0_NET_User_delObject_byEmail_verify", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return ((bool)_dataparameters[2].Value);
		}
		#endregion
		#region public static bool isObject_byEmail_verify(...);
		/// <summary>
		/// Checks to see if NET_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="Email_verify_search_in">Email_verify search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if NET_User exists at Database, False if not</returns>
		public static bool isObject_byEmail_verify(
			string Email_verify_search_in, 
			int IDApplication_search_in
		) {
			return isObject_byEmail_verify(
				Email_verify_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NET_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="Email_verify_search_in">Email_verify search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_User exists at Database, False if not</returns>
		public static bool isObject_byEmail_verify(
			string Email_verify_search_in, 
			int IDApplication_search_in, 
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
				_connection.newDBDataParameter("Email_verify_search_", DbType.AnsiString, ParameterDirection.Input, Email_verify_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NET_User_isObject_byEmail_verify", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_NET_User[] getRecord(DataTable dataTable_in);
		private static SO_NET_User[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifuser = null;
			DataColumn _dc_name = null;
			DataColumn _dc_email = null;
			DataColumn _dc_email_verify = null;
			DataColumn _dc_ifapplication = null;

			SO_NET_User[] _output 
				= new SO_NET_User[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifuser = dataTable_in.Columns["IFUser"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_email = dataTable_in.Columns["Email"];
					_dc_email_verify = dataTable_in.Columns["Email_verify"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
				}

				_output[r] = new SO_NET_User();
				if (dataTable_in.Rows[r][_dc_ifuser] == System.DBNull.Value) {
					_output[r].IFUser = 0L;
				} else {
					_output[r].IFUser = (long)dataTable_in.Rows[r][_dc_ifuser];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].Name_isNull = true;
				} else {
					_output[r].Name = (string)dataTable_in.Rows[r][_dc_name];
				}
				if (dataTable_in.Rows[r][_dc_email] == System.DBNull.Value) {
					_output[r].Email = string.Empty;
				} else {
					_output[r].Email = (string)dataTable_in.Rows[r][_dc_email];
				}
				if (dataTable_in.Rows[r][_dc_email_verify] == System.DBNull.Value) {
					_output[r].Email_verify_isNull = true;
				} else {
					_output[r].Email_verify = (string)dataTable_in.Rows[r][_dc_email_verify];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication_isNull = true;
				} else {
					_output[r].IFApplication = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}

				_output[r].HasChanges = false;
			}

			return _output;
		}
		#endregion
		#region ???_Publisher...
		#region public static SO_NET_User[] getRecord_Publisher(...);
		/// <summary>
		/// Gets Record, based on 'Publisher' search. It selects NET_User values from Database based on the 'Publisher' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		public static SO_NET_User[] getRecord_Publisher(
			object IDApplication_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out
		) {
			return getRecord_Publisher(
				IDApplication_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'Publisher' search. It selects NET_User values from Database based on the 'Publisher' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NET_User[] getRecord_Publisher(
			object IDApplication_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			DBConnection dbConnection_in
		) {
			SO_NET_User[] _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = 
				((page_in > 0) && (page_itemsPerPage_in > 0))
					? new IDbDataParameter[] {
						_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
						_connection.newDBDataParameter("page_orderBy_", DbType.Int32, ParameterDirection.Input, page_orderBy_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int64, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_itemsPerPage_", DbType.Int32, ParameterDirection.Input, page_itemsPerPage_in, 0), 

						//_connection.newDBDataParameter("page_itemsCount_", DbType.Int32, ParameterDirection.Output, null, 0), 

					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_itemsPerPage_in > 0))
						? "sp_NET_User_Record_open_Publisher_page"
						: "sp0_NET_User_Record_open_Publisher", 
					_dataparameters
				)
			);
			if ((page_in > 0) && (page_itemsPerPage_in > 0)) {
				// && (_dataparameters[_dataparameters.Length - 1].Value != DBNull.Value)) {
				//page_itemsCount_out = (int)_dataparameters[_dataparameters.Length - 1].Value;

				page_itemsCount_out = getCount_inRecord_Publisher(
					IDApplication_search_in, 
					dbConnection_in
				);
			} else {
				page_itemsCount_out = 0;
			}
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_Publisher(...);
		/// <summary>
		/// It selects NET_User values from Database based on the 'Publisher' search and checks to see if NET_User Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFUser_in">NET_User's IFUser Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if NET_User Keys are met in the 'Publisher' search, False if not</returns>
		public static bool isObject_inRecord_Publisher(
			long IFUser_in, 
			object IDApplication_search_in
		) {
			return isObject_inRecord_Publisher(
				IFUser_in, IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NET_User values from Database based on the 'Publisher' search and checks to see if NET_User Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFUser_in">NET_User's IFUser Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_User Keys are met in the 'Publisher' search, False if not</returns>
		public static bool isObject_inRecord_Publisher(
			long IFUser_in, 
			object IDApplication_search_in, 
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
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, IFUser_in, 0), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NET_User_Record_hasObject_Publisher", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_Publisher(...);
		/// <summary>
		/// Count's number of search results from NET_User at Database based on the 'Publisher' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>number of existing Records for the 'Publisher' search</returns>
		public static long getCount_inRecord_Publisher(
			object IDApplication_search_in
		) {
			return getCount_inRecord_Publisher(
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from NET_User at Database based on the 'Publisher' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'Publisher' search</returns>
		public static long getCount_inRecord_Publisher(
			object IDApplication_search_in, 
			DBConnection dbConnection_in
		) {
			long _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_NET_User_Record_count_Publisher", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_Publisher(...);
		/// <summary>
		/// Deletes NET_User values from Database based on the 'Publisher' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		public static void delRecord_Publisher(
			object IDApplication_search_in
		) {
			delRecord_Publisher(
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_User values from Database based on the 'Publisher' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_Publisher(
			object IDApplication_search_in, 
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
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NET_User_Record_delete_Publisher", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}