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
	/// NET_User DataObject which provides access to NET_User's Database table.
	/// </summary>
	[DOClassAttribute("NET_User", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
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
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.InputOutput, IFUser_in, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("EMail_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("EMail_verify_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
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
					_output.EMail = string.Empty;
				} else {
					_output.EMail = (string)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.EMail_verify_isNull = true;
				} else {
					_output.EMail_verify = (string)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[4].Value;
				}

				_output.haschanges_ = false;
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
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
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
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
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
			if (forceUpdate_in || NET_User_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, NET_User_in.IFUser, 0), 
					_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, NET_User_in.Name_isNull ? null : (object)NET_User_in.Name, 255), 
					_connection.newDBDataParameter("EMail_", DbType.AnsiString, ParameterDirection.Input, NET_User_in.EMail, 255), 
					_connection.newDBDataParameter("EMail_verify_", DbType.AnsiString, ParameterDirection.Input, NET_User_in.EMail_verify_isNull ? null : (object)NET_User_in.EMail_verify, 255), 
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
					NET_User_in.haschanges_ = false;
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
		#region ???Object_byEMail...
		#region public static SO_NET_User getObject_byEMail(...);
		/// <summary>
		/// Selects NET_User values from Database (based on the search condition) and assigns them to the appropriate DO0_NET_User property.
		/// </summary>
		/// <param name="EMail_search_in">EMail search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>null if NET_User doesn't exists at Database</returns>
		public static SO_NET_User getObject_byEMail(
			string EMail_search_in, 
			int IDApplication_search_in
		) {
			return getObject_byEMail(
				EMail_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Selects NET_User values from Database (based on the search condition) and assigns them to the appropriate DO0_NET_User property.
		/// </summary>
		/// <param name="EMail_search_in">EMail search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NET_User doesn't exists at Database</returns>
		public static SO_NET_User getObject_byEMail(
			string EMail_search_in, 
			int IDApplication_search_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_User _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("EMail_search_", DbType.AnsiString, ParameterDirection.Input, EMail_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
				_connection.newDBDataParameter("IFUser", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("EMail", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("EMail_verify", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("IFApplication", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NET_User_getObject_byEMail", 
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
					_output.EMail = string.Empty;
				} else {
					_output.EMail = (string)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.EMail_verify_isNull = true;
				} else {
					_output.EMail_verify = (string)_dataparameters[5].Value;
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
		#region public static bool delObject_byEMail(...);
		/// <summary>
		/// Deletes NET_User from Database (based on the search condition).
		/// </summary>
		/// <param name="EMail_search_in"> EMail search condition</param>
		/// <param name="IDApplication_search_in"> IDApplication search condition</param>
		/// <returns>True if NET_User existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byEMail(
			string EMail_search_in, 
			int IDApplication_search_in
		) {
			return delObject_byEMail(
				EMail_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_User from Database (based on the search condition).
		/// </summary>
		/// <param name="EMail_search_in"> EMail search condition</param>
		/// <param name="IDApplication_search_in"> IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_User existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byEMail(
			string EMail_search_in, 
			int IDApplication_search_in, 
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
				_connection.newDBDataParameter("EMail_search_", DbType.AnsiString, ParameterDirection.Input, EMail_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 

				_connection.newDBDataParameter("Exists_", DbType.Boolean, ParameterDirection.Output, null, 1)
			};
			_connection.Execute_SQLFunction("sp0_NET_User_delObject_byEMail", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return ((bool)_dataparameters[2].Value);
		}
		#endregion
		#region public static bool isObject_byEMail(...);
		/// <summary>
		/// Checks to see if NET_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="EMail_search_in">EMail search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if NET_User exists at Database, False if not</returns>
		public static bool isObject_byEMail(
			string EMail_search_in, 
			int IDApplication_search_in
		) {
			return isObject_byEMail(
				EMail_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NET_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="EMail_search_in">EMail search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_User exists at Database, False if not</returns>
		public static bool isObject_byEMail(
			string EMail_search_in, 
			int IDApplication_search_in, 
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
				_connection.newDBDataParameter("EMail_search_", DbType.AnsiString, ParameterDirection.Input, EMail_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NET_User_isObject_byEMail", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???Object_byEMail_verify...
		#region public static SO_NET_User getObject_byEMail_verify(...);
		/// <summary>
		/// Selects NET_User values from Database (based on the search condition) and assigns them to the appropriate DO0_NET_User property.
		/// </summary>
		/// <param name="EMail_verify_search_in">EMail_verify search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>null if NET_User doesn't exists at Database</returns>
		public static SO_NET_User getObject_byEMail_verify(
			string EMail_verify_search_in, 
			int IDApplication_search_in
		) {
			return getObject_byEMail_verify(
				EMail_verify_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Selects NET_User values from Database (based on the search condition) and assigns them to the appropriate DO0_NET_User property.
		/// </summary>
		/// <param name="EMail_verify_search_in">EMail_verify search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NET_User doesn't exists at Database</returns>
		public static SO_NET_User getObject_byEMail_verify(
			string EMail_verify_search_in, 
			int IDApplication_search_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_User _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("EMail_verify_search_", DbType.AnsiString, ParameterDirection.Input, EMail_verify_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
				_connection.newDBDataParameter("IFUser", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("EMail", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("EMail_verify", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("IFApplication", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NET_User_getObject_byEMail_verify", 
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
					_output.EMail = string.Empty;
				} else {
					_output.EMail = (string)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.EMail_verify_isNull = true;
				} else {
					_output.EMail_verify = (string)_dataparameters[5].Value;
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
		#region public static bool delObject_byEMail_verify(...);
		/// <summary>
		/// Deletes NET_User from Database (based on the search condition).
		/// </summary>
		/// <param name="EMail_verify_search_in"> EMail_verify search condition</param>
		/// <param name="IDApplication_search_in"> IDApplication search condition</param>
		/// <returns>True if NET_User existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byEMail_verify(
			string EMail_verify_search_in, 
			int IDApplication_search_in
		) {
			return delObject_byEMail_verify(
				EMail_verify_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_User from Database (based on the search condition).
		/// </summary>
		/// <param name="EMail_verify_search_in"> EMail_verify search condition</param>
		/// <param name="IDApplication_search_in"> IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_User existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byEMail_verify(
			string EMail_verify_search_in, 
			int IDApplication_search_in, 
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
				_connection.newDBDataParameter("EMail_verify_search_", DbType.AnsiString, ParameterDirection.Input, EMail_verify_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 

				_connection.newDBDataParameter("Exists_", DbType.Boolean, ParameterDirection.Output, null, 1)
			};
			_connection.Execute_SQLFunction("sp0_NET_User_delObject_byEMail_verify", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return ((bool)_dataparameters[2].Value);
		}
		#endregion
		#region public static bool isObject_byEMail_verify(...);
		/// <summary>
		/// Checks to see if NET_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="EMail_verify_search_in">EMail_verify search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if NET_User exists at Database, False if not</returns>
		public static bool isObject_byEMail_verify(
			string EMail_verify_search_in, 
			int IDApplication_search_in
		) {
			return isObject_byEMail_verify(
				EMail_verify_search_in, 
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NET_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="EMail_verify_search_in">EMail_verify search condition</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_User exists at Database, False if not</returns>
		public static bool isObject_byEMail_verify(
			string EMail_verify_search_in, 
			int IDApplication_search_in, 
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
				_connection.newDBDataParameter("EMail_verify_search_", DbType.AnsiString, ParameterDirection.Input, EMail_verify_search_in, 255), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NET_User_isObject_byEMail_verify", 
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
					_dc_email = dataTable_in.Columns["EMail"];
					_dc_email_verify = dataTable_in.Columns["EMail_verify"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
				}

				_output[r] = new SO_NET_User();
				if (dataTable_in.Rows[r][_dc_ifuser] == System.DBNull.Value) {
					_output[r].ifuser_ = 0L;
				} else {
					_output[r].ifuser_ = (long)dataTable_in.Rows[r][_dc_ifuser];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].Name_isNull = true;
				} else {
					_output[r].name_ = (string)dataTable_in.Rows[r][_dc_name];
				}
				if (dataTable_in.Rows[r][_dc_email] == System.DBNull.Value) {
					_output[r].email_ = string.Empty;
				} else {
					_output[r].email_ = (string)dataTable_in.Rows[r][_dc_email];
				}
				if (dataTable_in.Rows[r][_dc_email_verify] == System.DBNull.Value) {
					_output[r].EMail_verify_isNull = true;
				} else {
					_output[r].email_verify_ = (string)dataTable_in.Rows[r][_dc_email_verify];
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

		#region ???_Publisher...
		#region public static SO_NET_User[] getRecord_Publisher(...);
		/// <summary>
		/// Gets Record, based on 'Publisher' search. It selects NET_User values from Database based on the 'Publisher' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_NET_User[] getRecord_Publisher(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_Publisher(
				IDApplication_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'Publisher' search. It selects NET_User values from Database based on the 'Publisher' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NET_User[] getRecord_Publisher(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_User[] _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = 
				((page_in > 0) && (page_numRecords_in > 0))
					? new IDbDataParameter[] {
						_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_NET_User_Record_open_Publisher_page_fullmode"
						: "sp0_NET_User_Record_open_Publisher_fullmode", 
					_dataparameters
				)
			);
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
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
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
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
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
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
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