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
	/// vNET_User DataObject which provides access to vNET_User's Database table.
	/// </summary>
	[DOClassAttribute("vNET_User", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vNET_User 
#else
			DO_vNET_User 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#region ???Object_byUser...
		#region public static SO_vNET_User getObject_byUser(...);
		/// <summary>
		/// Selects vNET_User values from Database (based on the search condition) and assigns them to the appropriate DO0_vNET_User property.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <returns>null if vNET_User doesn't exists at Database</returns>
		public static SO_vNET_User getObject_byUser(
			long IDUser_search_in
		) {
			return getObject_byUser(
				IDUser_search_in, 
				null
			);
		}

		/// <summary>
		/// Selects vNET_User values from Database (based on the search condition) and assigns them to the appropriate DO0_vNET_User property.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if vNET_User doesn't exists at Database</returns>
		public static SO_vNET_User getObject_byUser(
			long IDUser_search_in, 
			DBConnection dbConnection_in
		) {
			SO_vNET_User _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
				_connection.newDBDataParameter("IDUser", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Login", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Name", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("EMail", DbType.AnsiString, ParameterDirection.Output, null, 255)
			};
			_connection.Execute_SQLFunction(
				"sp0_vNET_User_getObject_byUser", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[1].Value != DBNull.Value) {
				_output = new SO_vNET_User();
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IDUser = 0L;
				} else {
					_output.IDUser = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.Login_isNull = true;
				} else {
					_output.Login = (string)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.Name_isNull = true;
				} else {
					_output.Name = (string)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.EMail_isNull = true;
				} else {
					_output.EMail = (string)_dataparameters[5].Value;
				}

				return _output;
			}

			return null;
		}
		#endregion
		#region public static bool isObject_byUser(...);
		/// <summary>
		/// Checks to see if vNET_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <returns>True if vNET_User exists at Database, False if not</returns>
		public static bool isObject_byUser(
			long IDUser_search_in
		) {
			return isObject_byUser(
				IDUser_search_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if vNET_User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNET_User exists at Database, False if not</returns>
		public static bool isObject_byUser(
			long IDUser_search_in, 
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
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNET_User_isObject_byUser", 
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
		#region private static SO_vNET_User[] getRecord(DataTable dataTable_in);
		private static SO_vNET_User[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_iduser = null;
			DataColumn _dc_ifapplication = null;
			DataColumn _dc_login = null;
			DataColumn _dc_name = null;
			DataColumn _dc_email = null;

			SO_vNET_User[] _output 
				= new SO_vNET_User[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_iduser = dataTable_in.Columns["IDUser"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
					_dc_login = dataTable_in.Columns["Login"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_email = dataTable_in.Columns["EMail"];
				}

				_output[r] = new SO_vNET_User();
				if (dataTable_in.Rows[r][_dc_iduser] == System.DBNull.Value) {
					_output[r].iduser_ = 0L;
				} else {
					_output[r].iduser_ = (long)dataTable_in.Rows[r][_dc_iduser];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication_isNull = true;
				} else {
					_output[r].ifapplication_ = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}
				if (dataTable_in.Rows[r][_dc_login] == System.DBNull.Value) {
					_output[r].Login_isNull = true;
				} else {
					_output[r].login_ = (string)dataTable_in.Rows[r][_dc_login];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].Name_isNull = true;
				} else {
					_output[r].name_ = (string)dataTable_in.Rows[r][_dc_name];
				}
				if (dataTable_in.Rows[r][_dc_email] == System.DBNull.Value) {
					_output[r].EMail_isNull = true;
				} else {
					_output[r].email_ = (string)dataTable_in.Rows[r][_dc_email];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_generic...
		#region public static SO_vNET_User[] getRecord_generic(...);
		/// <summary>
		/// Gets Record, based on 'generic' search. It selects vNET_User values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="Login_search_in">Login search condition</param>
		/// <param name="Name_search_in">Name search condition</param>
		/// <param name="EMail_search_in">EMail search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IDProfile__in_search_in">IDProfile__in search condition</param>
		/// <param name="IDProfile__out_search_in">IDProfile__out search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNET_User[] getRecord_generic(
			object Login_search_in, 
			object Name_search_in, 
			object EMail_search_in, 
			object IFApplication_search_in, 
			long IDProfile__in_search_in, 
			long IDProfile__out_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_generic(
				Login_search_in, 
				Name_search_in, 
				EMail_search_in, 
				IFApplication_search_in, 
				IDProfile__in_search_in, 
				IDProfile__out_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'generic' search. It selects vNET_User values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="Login_search_in">Login search condition</param>
		/// <param name="Name_search_in">Name search condition</param>
		/// <param name="EMail_search_in">EMail search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IDProfile__in_search_in">IDProfile__in search condition</param>
		/// <param name="IDProfile__out_search_in">IDProfile__out search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNET_User[] getRecord_generic(
			object Login_search_in, 
			object Name_search_in, 
			object EMail_search_in, 
			object IFApplication_search_in, 
			long IDProfile__in_search_in, 
			long IDProfile__out_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNET_User[] _output;

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
						_connection.newDBDataParameter("Login_search_", DbType.AnsiString, ParameterDirection.Input, Login_search_in, 255), 
						_connection.newDBDataParameter("Name_search_", DbType.AnsiString, ParameterDirection.Input, Name_search_in, 255), 
						_connection.newDBDataParameter("EMail_search_", DbType.AnsiString, ParameterDirection.Input, EMail_search_in, 255), 
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
						_connection.newDBDataParameter("IDProfile__in_search_", DbType.Int64, ParameterDirection.Input, IDProfile__in_search_in, 0), 
						_connection.newDBDataParameter("IDProfile__out_search_", DbType.Int64, ParameterDirection.Input, IDProfile__out_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("Login_search_", DbType.AnsiString, ParameterDirection.Input, Login_search_in, 255), 
						_connection.newDBDataParameter("Name_search_", DbType.AnsiString, ParameterDirection.Input, Name_search_in, 255), 
						_connection.newDBDataParameter("EMail_search_", DbType.AnsiString, ParameterDirection.Input, EMail_search_in, 255), 
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
						_connection.newDBDataParameter("IDProfile__in_search_", DbType.Int64, ParameterDirection.Input, IDProfile__in_search_in, 0), 
						_connection.newDBDataParameter("IDProfile__out_search_", DbType.Int64, ParameterDirection.Input, IDProfile__out_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vNET_User_Record_open_generic_page_fullmode"
						: "sp0_vNET_User_Record_open_generic_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_generic(...);
		/// <summary>
		/// It selects vNET_User values from Database based on the 'generic' search and checks to see if vNET_User Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDUser_in">vNET_User's IDUser Key used for checking</param>
		/// <param name="Login_search_in">Login search condition</param>
		/// <param name="Name_search_in">Name search condition</param>
		/// <param name="EMail_search_in">EMail search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IDProfile__in_search_in">IDProfile__in search condition</param>
		/// <param name="IDProfile__out_search_in">IDProfile__out search condition</param>
		/// <returns>True if vNET_User Keys are met in the 'generic' search, False if not</returns>
		public static bool isObject_inRecord_generic(
			long IDUser_in, 
			object Login_search_in, 
			object Name_search_in, 
			object EMail_search_in, 
			object IFApplication_search_in, 
			long IDProfile__in_search_in, 
			long IDProfile__out_search_in
		) {
			return isObject_inRecord_generic(
				IDUser_in, Login_search_in, Name_search_in, EMail_search_in, IFApplication_search_in, IDProfile__in_search_in, IDProfile__out_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNET_User values from Database based on the 'generic' search and checks to see if vNET_User Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDUser_in">vNET_User's IDUser Key used for checking</param>
		/// <param name="Login_search_in">Login search condition</param>
		/// <param name="Name_search_in">Name search condition</param>
		/// <param name="EMail_search_in">EMail search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IDProfile__in_search_in">IDProfile__in search condition</param>
		/// <param name="IDProfile__out_search_in">IDProfile__out search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNET_User Keys are met in the 'generic' search, False if not</returns>
		public static bool isObject_inRecord_generic(
			long IDUser_in, 
			object Login_search_in, 
			object Name_search_in, 
			object EMail_search_in, 
			object IFApplication_search_in, 
			long IDProfile__in_search_in, 
			long IDProfile__out_search_in, 
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
				_connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, IDUser_in, 0), 
				_connection.newDBDataParameter("Login_search_", DbType.AnsiString, ParameterDirection.Input, Login_search_in, 255), 
				_connection.newDBDataParameter("Name_search_", DbType.AnsiString, ParameterDirection.Input, Name_search_in, 255), 
				_connection.newDBDataParameter("EMail_search_", DbType.AnsiString, ParameterDirection.Input, EMail_search_in, 255), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
				_connection.newDBDataParameter("IDProfile__in_search_", DbType.Int64, ParameterDirection.Input, IDProfile__in_search_in, 0), 
				_connection.newDBDataParameter("IDProfile__out_search_", DbType.Int64, ParameterDirection.Input, IDProfile__out_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNET_User_Record_hasObject_generic", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_generic(...);
		/// <summary>
		/// Count's number of search results from vNET_User at Database based on the 'generic' search.
		/// </summary>
		/// <param name="Login_search_in">Login search condition</param>
		/// <param name="Name_search_in">Name search condition</param>
		/// <param name="EMail_search_in">EMail search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IDProfile__in_search_in">IDProfile__in search condition</param>
		/// <param name="IDProfile__out_search_in">IDProfile__out search condition</param>
		/// <returns>number of existing Records for the 'generic' search</returns>
		public static long getCount_inRecord_generic(
			object Login_search_in, 
			object Name_search_in, 
			object EMail_search_in, 
			object IFApplication_search_in, 
			long IDProfile__in_search_in, 
			long IDProfile__out_search_in
		) {
			return getCount_inRecord_generic(
				Login_search_in, 
				Name_search_in, 
				EMail_search_in, 
				IFApplication_search_in, 
				IDProfile__in_search_in, 
				IDProfile__out_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNET_User at Database based on the 'generic' search.
		/// </summary>
		/// <param name="Login_search_in">Login search condition</param>
		/// <param name="Name_search_in">Name search condition</param>
		/// <param name="EMail_search_in">EMail search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IDProfile__in_search_in">IDProfile__in search condition</param>
		/// <param name="IDProfile__out_search_in">IDProfile__out search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'generic' search</returns>
		public static long getCount_inRecord_generic(
			object Login_search_in, 
			object Name_search_in, 
			object EMail_search_in, 
			object IFApplication_search_in, 
			long IDProfile__in_search_in, 
			long IDProfile__out_search_in, 
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
				_connection.newDBDataParameter("Login_search_", DbType.AnsiString, ParameterDirection.Input, Login_search_in, 255), 
				_connection.newDBDataParameter("Name_search_", DbType.AnsiString, ParameterDirection.Input, Name_search_in, 255), 
				_connection.newDBDataParameter("EMail_search_", DbType.AnsiString, ParameterDirection.Input, EMail_search_in, 255), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
				_connection.newDBDataParameter("IDProfile__in_search_", DbType.Int64, ParameterDirection.Input, IDProfile__in_search_in, 0), 
				_connection.newDBDataParameter("IDProfile__out_search_", DbType.Int64, ParameterDirection.Input, IDProfile__out_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vNET_User_Record_count_generic", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#endregion
	}
}