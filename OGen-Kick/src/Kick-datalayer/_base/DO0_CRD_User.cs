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
	/// CRD_User DataObject which provides access to CRD_User's Database table.
	/// </summary>
	[DOClassAttribute("CRD_User", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_CRD_User 
#else
			DO_CRD_User 
#endif
	{

	 	#region Methods...
		#region public static SO_CRD_User getObject(...);
		/// <summary>
		/// Selects CRD_User values from Database and assigns them to the appropriate DO0_CRD_User property.
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		/// <returns>null if CRD_User doesn't exists at Database</returns>
		public static SO_CRD_User getObject(
			long IDUser_in
		) {
			return getObject(
				IDUser_in, 
				null
			);
		}

		/// <summary>
		/// Selects CRD_User values from Database and assigns them to the appropriate DO_CRD_User property.
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if CRD_User doesn't exists at Database</returns>
		public static SO_CRD_User getObject(
			long IDUser_in, 
			DBConnection dbConnection_in
		) {
			SO_CRD_User _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.InputOutput, IDUser_in, 0), 
				_connection.newDBDataParameter("Login_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Password_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_User_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_CRD_User();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDUser = 0L;
				} else {
					_output.IDUser = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.Login = string.Empty;
				} else {
					_output.Login = (string)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.Password = string.Empty;
				} else {
					_output.Password = (string)_dataparameters[2].Value;
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
		/// Deletes CRD_User from Database.
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		public static void delObject(
			long IDUser_in
		) {
			delObject(
				IDUser_in, 
				null
			);
		}

		/// <summary>
		/// Deletes CRD_User from Database.
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDUser_in, 
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
				_connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, IDUser_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_User_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if CRD_User exists at Database
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		/// <returns>True if CRD_User exists at Database, False if not</returns>
		public static bool isObject(
			long IDUser_in
		) {
			return isObject(
				IDUser_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if CRD_User exists at Database
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_User exists at Database, False if not</returns>
		public static bool isObject(
			long IDUser_in, 
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
				_connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, IDUser_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_User_isObject", 
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
		/// Inserts CRD_User values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="constraintExist_out">returns True if constraint exists and insertion failed, and False if no constraint and insertion was successful</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_CRD_User CRD_User_in, 
			bool selectIdentity_in, 
			out bool constraintExist_out
		) {
			return insObject(
				CRD_User_in, 
				selectIdentity_in, 
				out constraintExist_out, 
				null
			);
		}

		/// <summary>
		/// Inserts CRD_User values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="constraintExist_out">returns True if constraint exists and insertion failed, and False if no constraint and insertion was successful</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_CRD_User CRD_User_in, 
			bool selectIdentity_in, 
			out bool constraintExist_out, 
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
				_connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Login_", DbType.AnsiString, ParameterDirection.Input, CRD_User_in.Login, 255), 
				_connection.newDBDataParameter("Password_", DbType.AnsiString, ParameterDirection.Input, CRD_User_in.Password, 255), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, CRD_User_in.IFApplication_isNull ? null : (object)CRD_User_in.IFApplication, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_CRD_User_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			CRD_User_in.IDUser = (long)_dataparameters[0].Value;
			constraintExist_out = (CRD_User_in.IDUser == -1L);
			if (!constraintExist_out) {
				CRD_User_in.haschanges_ = false;
			}

			return CRD_User_in.IDUser;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates CRD_User values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="constraintExist_out">returns True if constraint exists and Update failed, and False if no constraint and Update was successful</param>
		public static void updObject(
			SO_CRD_User CRD_User_in, 
			bool forceUpdate_in, 
			out bool constraintExist_out
		) {
			updObject(
				CRD_User_in, 
				forceUpdate_in, 
				out constraintExist_out, 
				null
			);
		}

		/// <summary>
		/// Updates CRD_User values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="constraintExist_out">returns True if constraint exists and Update failed, and False if no constraint and Update was successful</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_CRD_User CRD_User_in, 
			bool forceUpdate_in, 
			out bool constraintExist_out, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || CRD_User_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, CRD_User_in.IDUser, 0), 
					_connection.newDBDataParameter("Login_", DbType.AnsiString, ParameterDirection.Input, CRD_User_in.Login, 255), 
					_connection.newDBDataParameter("Password_", DbType.AnsiString, ParameterDirection.Input, CRD_User_in.Password, 255), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, CRD_User_in.IFApplication_isNull ? null : (object)CRD_User_in.IFApplication, 0), 

					_connection.newDBDataParameter("ConstraintExist_", DbType.Boolean, ParameterDirection.Output, null, 1)
				};
				_connection.Execute_SQLFunction(
					"sp0_CRD_User_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				
				constraintExist_out = (bool)_dataparameters[4].Value;
				if (!constraintExist_out) {
					CRD_User_in.haschanges_ = false;
				}
			} else {
				constraintExist_out = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#region ???Object_byLogin...
		#region public static SO_CRD_User getObject_byLogin(...);
		/// <summary>
		/// Selects CRD_User values from Database (based on the search condition) and assigns them to the appropriate DO0_CRD_User property.
		/// </summary>
		/// <param name="Login_search_in">Login search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <returns>null if CRD_User doesn't exists at Database</returns>
		public static SO_CRD_User getObject_byLogin(
			string Login_search_in, 
			int IFApplication_search_in
		) {
			return getObject_byLogin(
				Login_search_in, 
				IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Selects CRD_User values from Database (based on the search condition) and assigns them to the appropriate DO0_CRD_User property.
		/// </summary>
		/// <param name="Login_search_in">Login search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if CRD_User doesn't exists at Database</returns>
		public static SO_CRD_User getObject_byLogin(
			string Login_search_in, 
			int IFApplication_search_in, 
			DBConnection dbConnection_in
		) {
			SO_CRD_User _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("Login_search_", DbType.AnsiString, ParameterDirection.Input, Login_search_in, 255), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
				_connection.newDBDataParameter("IDUser", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Login", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Password", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("IFApplication", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_CRD_User_getObject_byLogin", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[2].Value != DBNull.Value) {
				_output = new SO_CRD_User();
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IDUser = 0L;
				} else {
					_output.IDUser = (long)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.Login = string.Empty;
				} else {
					_output.Login = (string)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.Password = string.Empty;
				} else {
					_output.Password = (string)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[5].Value;
				}

				return _output;
			}

			return null;
		}
		#endregion
		#region public static bool delObject_byLogin(...);
		/// <summary>
		/// Deletes CRD_User from Database (based on the search condition).
		/// </summary>
		/// <param name="Login_search_in"> Login search condition</param>
		/// <param name="IFApplication_search_in"> IFApplication search condition</param>
		/// <returns>True if CRD_User existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byLogin(
			string Login_search_in, 
			int IFApplication_search_in
		) {
			return delObject_byLogin(
				Login_search_in, 
				IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes CRD_User from Database (based on the search condition).
		/// </summary>
		/// <param name="Login_search_in"> Login search condition</param>
		/// <param name="IFApplication_search_in"> IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_User existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byLogin(
			string Login_search_in, 
			int IFApplication_search_in, 
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
				_connection.newDBDataParameter("Login_search_", DbType.AnsiString, ParameterDirection.Input, Login_search_in, 255), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 

				_connection.newDBDataParameter("Exists_", DbType.Boolean, ParameterDirection.Output, null, 1)
			};
			_connection.Execute_SQLFunction("sp0_CRD_User_delObject_byLogin", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return ((bool)_dataparameters[2].Value);
		}
		#endregion
		#region public static bool isObject_byLogin(...);
		/// <summary>
		/// Checks to see if CRD_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="Login_search_in">Login search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <returns>True if CRD_User exists at Database, False if not</returns>
		public static bool isObject_byLogin(
			string Login_search_in, 
			int IFApplication_search_in
		) {
			return isObject_byLogin(
				Login_search_in, 
				IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if CRD_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="Login_search_in">Login search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_User exists at Database, False if not</returns>
		public static bool isObject_byLogin(
			string Login_search_in, 
			int IFApplication_search_in, 
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
				_connection.newDBDataParameter("Login_search_", DbType.AnsiString, ParameterDirection.Input, Login_search_in, 255), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_User_isObject_byLogin", 
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
		#region private static SO_CRD_User[] getRecord(DataTable dataTable_in);
		private static SO_CRD_User[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_iduser = null;
			DataColumn _dc_login = null;
			DataColumn _dc_password = null;
			DataColumn _dc_ifapplication = null;

			SO_CRD_User[] _output 
				= new SO_CRD_User[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_iduser = dataTable_in.Columns["IDUser"];
					_dc_login = dataTable_in.Columns["Login"];
					_dc_password = dataTable_in.Columns["Password"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
				}

				_output[r] = new SO_CRD_User();
				if (dataTable_in.Rows[r][_dc_iduser] == System.DBNull.Value) {
					_output[r].iduser_ = 0L;
				} else {
					_output[r].iduser_ = (long)dataTable_in.Rows[r][_dc_iduser];
				}
				if (dataTable_in.Rows[r][_dc_login] == System.DBNull.Value) {
					_output[r].login_ = string.Empty;
				} else {
					_output[r].login_ = (string)dataTable_in.Rows[r][_dc_login];
				}
				if (dataTable_in.Rows[r][_dc_password] == System.DBNull.Value) {
					_output[r].password_ = string.Empty;
				} else {
					_output[r].password_ = (string)dataTable_in.Rows[r][_dc_password];
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