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
	/// vFOR_Message DataObject which provides access to vFOR_Message's Database table.
	/// </summary>
	[DOClassAttribute("vFOR_Message", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vFOR_Message 
#else
			DO_vFOR_Message 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#region ???Object_byMessage...
		#region public static SO_vFOR_Message getObject_byMessage(...);
		/// <summary>
		/// Selects vFOR_Message values from Database (based on the search condition) and assigns them to the appropriate DO0_vFOR_Message property.
		/// </summary>
		/// <param name="IDMessage_search_in">IDMessage search condition</param>
		/// <returns>null if vFOR_Message doesn't exists at Database</returns>
		public static SO_vFOR_Message getObject_byMessage(
			long IDMessage_search_in
		) {
			return getObject_byMessage(
				IDMessage_search_in, 
				null
			);
		}

		/// <summary>
		/// Selects vFOR_Message values from Database (based on the search condition) and assigns them to the appropriate DO0_vFOR_Message property.
		/// </summary>
		/// <param name="IDMessage_search_in">IDMessage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if vFOR_Message doesn't exists at Database</returns>
		public static SO_vFOR_Message getObject_byMessage(
			long IDMessage_search_in, 
			DBConnection dbConnection_in
		) {
			SO_vFOR_Message _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDMessage_search_", DbType.Int64, ParameterDirection.Input, IDMessage_search_in, 0), 
				_connection.newDBDataParameter("IDMessage", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IDMessage__parent", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("isThread", DbType.Boolean, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("isSticky", DbType.Boolean, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Subject", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Message__charvar8000", DbType.AnsiString, ParameterDirection.Output, null, 8000), 
				_connection.newDBDataParameter("Message__text", DbType.AnsiString, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IDUser", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Publish_date", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Login", DbType.AnsiString, ParameterDirection.Output, null, 255)
			};
			_connection.Execute_SQLFunction(
				"sp0_vFOR_Message_getObject_byMessage", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[1].Value != DBNull.Value) {
				_output = new SO_vFOR_Message();
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IDMessage = 0L;
				} else {
					_output.IDMessage = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IDMessage__parent_isNull = true;
				} else {
					_output.IDMessage__parent = (long)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.isThread_isNull = true;
				} else {
					_output.isThread = (bool)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.isSticky_isNull = true;
				} else {
					_output.isSticky = (bool)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.Subject_isNull = true;
				} else {
					_output.Subject = (string)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.Message__charvar8000_isNull = true;
				} else {
					_output.Message__charvar8000 = (string)_dataparameters[6].Value;
				}
				if (_dataparameters[7].Value == System.DBNull.Value) {
					_output.Message__text_isNull = true;
				} else {
					_output.Message__text = (string)_dataparameters[7].Value;
				}
				if (_dataparameters[8].Value == System.DBNull.Value) {
					_output.IDUser_isNull = true;
				} else {
					_output.IDUser = (long)_dataparameters[8].Value;
				}
				if (_dataparameters[9].Value == System.DBNull.Value) {
					_output.Name_isNull = true;
				} else {
					_output.Name = (string)_dataparameters[9].Value;
				}
				if (_dataparameters[10].Value == System.DBNull.Value) {
					_output.Publish_date_isNull = true;
				} else {
					_output.Publish_date = (DateTime)_dataparameters[10].Value;
				}
				if (_dataparameters[11].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[11].Value;
				}
				if (_dataparameters[12].Value == System.DBNull.Value) {
					_output.Login_isNull = true;
				} else {
					_output.Login = (string)_dataparameters[12].Value;
				}

				return _output;
			}

			return null;
		}
		#endregion
		#region public static bool isObject_byMessage(...);
		/// <summary>
		/// Checks to see if vFOR_Message exists at Database (based on the search condition).
		/// </summary>
		/// <param name="IDMessage_search_in">IDMessage search condition</param>
		/// <returns>True if vFOR_Message exists at Database, False if not</returns>
		public static bool isObject_byMessage(
			long IDMessage_search_in
		) {
			return isObject_byMessage(
				IDMessage_search_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if vFOR_Message exists at Database (based on the search condition).
		/// </summary>
		/// <param name="IDMessage_search_in">IDMessage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vFOR_Message exists at Database, False if not</returns>
		public static bool isObject_byMessage(
			long IDMessage_search_in, 
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
				_connection.newDBDataParameter("IDMessage_search_", DbType.Int64, ParameterDirection.Input, IDMessage_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vFOR_Message_isObject_byMessage", 
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
		#region private static SO_vFOR_Message[] getRecord(DataTable dataTable_in);
		private static SO_vFOR_Message[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idmessage = null;
			DataColumn _dc_idmessage__parent = null;
			DataColumn _dc_isthread = null;
			DataColumn _dc_issticky = null;
			DataColumn _dc_subject = null;
			DataColumn _dc_message__charvar8000 = null;
			DataColumn _dc_message__text = null;
			DataColumn _dc_iduser = null;
			DataColumn _dc_name = null;
			DataColumn _dc_publish_date = null;
			DataColumn _dc_ifapplication = null;
			DataColumn _dc_login = null;

			SO_vFOR_Message[] _output 
				= new SO_vFOR_Message[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idmessage = dataTable_in.Columns["IDMessage"];
					_dc_idmessage__parent = dataTable_in.Columns["IDMessage__parent"];
					_dc_isthread = dataTable_in.Columns["isThread"];
					_dc_issticky = dataTable_in.Columns["isSticky"];
					_dc_subject = dataTable_in.Columns["Subject"];
					_dc_message__charvar8000 = dataTable_in.Columns["Message__charvar8000"];
					_dc_message__text = dataTable_in.Columns["Message__text"];
					_dc_iduser = dataTable_in.Columns["IDUser"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_publish_date = dataTable_in.Columns["Publish_date"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
					_dc_login = dataTable_in.Columns["Login"];
				}

				_output[r] = new SO_vFOR_Message();
				if (dataTable_in.Rows[r][_dc_idmessage] == System.DBNull.Value) {
					_output[r].idmessage_ = 0L;
				} else {
					_output[r].idmessage_ = (long)dataTable_in.Rows[r][_dc_idmessage];
				}
				if (dataTable_in.Rows[r][_dc_idmessage__parent] == System.DBNull.Value) {
					_output[r].IDMessage__parent_isNull = true;
				} else {
					_output[r].idmessage__parent_ = (long)dataTable_in.Rows[r][_dc_idmessage__parent];
				}
				if (dataTable_in.Rows[r][_dc_isthread] == System.DBNull.Value) {
					_output[r].isThread_isNull = true;
				} else {
					_output[r].isthread_ = (bool)dataTable_in.Rows[r][_dc_isthread];
				}
				if (dataTable_in.Rows[r][_dc_issticky] == System.DBNull.Value) {
					_output[r].isSticky_isNull = true;
				} else {
					_output[r].issticky_ = (bool)dataTable_in.Rows[r][_dc_issticky];
				}
				if (dataTable_in.Rows[r][_dc_subject] == System.DBNull.Value) {
					_output[r].Subject_isNull = true;
				} else {
					_output[r].subject_ = (string)dataTable_in.Rows[r][_dc_subject];
				}
				if (dataTable_in.Rows[r][_dc_message__charvar8000] == System.DBNull.Value) {
					_output[r].Message__charvar8000_isNull = true;
				} else {
					_output[r].message__charvar8000_ = (string)dataTable_in.Rows[r][_dc_message__charvar8000];
				}
				if (dataTable_in.Rows[r][_dc_message__text] == System.DBNull.Value) {
					_output[r].Message__text_isNull = true;
				} else {
					_output[r].message__text_ = (string)dataTable_in.Rows[r][_dc_message__text];
				}
				if (dataTable_in.Rows[r][_dc_iduser] == System.DBNull.Value) {
					_output[r].IDUser_isNull = true;
				} else {
					_output[r].iduser_ = (long)dataTable_in.Rows[r][_dc_iduser];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].Name_isNull = true;
				} else {
					_output[r].name_ = (string)dataTable_in.Rows[r][_dc_name];
				}
				if (dataTable_in.Rows[r][_dc_publish_date] == System.DBNull.Value) {
					_output[r].Publish_date_isNull = true;
				} else {
					_output[r].publish_date_ = (DateTime)dataTable_in.Rows[r][_dc_publish_date];
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

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byParent...
		#region public static SO_vFOR_Message[] getRecord_byParent(...);
		/// <summary>
		/// Gets Record, based on 'byParent' search. It selects vFOR_Message values from Database based on the 'byParent' search.
		/// </summary>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vFOR_Message[] getRecord_byParent(
			object IDMessage__parent_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byParent(
				IDMessage__parent_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byParent' search. It selects vFOR_Message values from Database based on the 'byParent' search.
		/// </summary>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vFOR_Message[] getRecord_byParent(
			object IDMessage__parent_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vFOR_Message[] _output;

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
						_connection.newDBDataParameter("IDMessage__parent_search_", DbType.Int64, ParameterDirection.Input, IDMessage__parent_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDMessage__parent_search_", DbType.Int64, ParameterDirection.Input, IDMessage__parent_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vFOR_Message_Record_open_byParent_page_fullmode"
						: "sp0_vFOR_Message_Record_open_byParent_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byParent(...);
		/// <summary>
		/// It selects vFOR_Message values from Database based on the 'byParent' search and checks to see if vFOR_Message Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDMessage_in">vFOR_Message's IDMessage Key used for checking</param>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <returns>True if vFOR_Message Keys are met in the 'byParent' search, False if not</returns>
		public static bool isObject_inRecord_byParent(
			long IDMessage_in, 
			object IDMessage__parent_search_in
		) {
			return isObject_inRecord_byParent(
				IDMessage_in, IDMessage__parent_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vFOR_Message values from Database based on the 'byParent' search and checks to see if vFOR_Message Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDMessage_in">vFOR_Message's IDMessage Key used for checking</param>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vFOR_Message Keys are met in the 'byParent' search, False if not</returns>
		public static bool isObject_inRecord_byParent(
			long IDMessage_in, 
			object IDMessage__parent_search_in, 
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
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Input, IDMessage_in, 0), 
				_connection.newDBDataParameter("IDMessage__parent_search_", DbType.Int64, ParameterDirection.Input, IDMessage__parent_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vFOR_Message_Record_hasObject_byParent", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byParent(...);
		/// <summary>
		/// Count's number of search results from vFOR_Message at Database based on the 'byParent' search.
		/// </summary>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <returns>number of existing Records for the 'byParent' search</returns>
		public static long getCount_inRecord_byParent(
			object IDMessage__parent_search_in
		) {
			return getCount_inRecord_byParent(
				IDMessage__parent_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vFOR_Message at Database based on the 'byParent' search.
		/// </summary>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byParent' search</returns>
		public static long getCount_inRecord_byParent(
			object IDMessage__parent_search_in, 
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
				_connection.newDBDataParameter("IDMessage__parent_search_", DbType.Int64, ParameterDirection.Input, IDMessage__parent_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vFOR_Message_Record_count_byParent", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???_byParent_Recursive...
		#region public static SO_vFOR_Message[] getRecord_byParent_Recursive(...);
		/// <summary>
		/// Gets Record, based on 'byParent_Recursive' search. It selects vFOR_Message values from Database based on the 'byParent_Recursive' search.
		/// </summary>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vFOR_Message[] getRecord_byParent_Recursive(
			object IDMessage__parent_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byParent_Recursive(
				IDMessage__parent_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byParent_Recursive' search. It selects vFOR_Message values from Database based on the 'byParent_Recursive' search.
		/// </summary>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vFOR_Message[] getRecord_byParent_Recursive(
			object IDMessage__parent_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vFOR_Message[] _output;

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
						_connection.newDBDataParameter("IDMessage__parent_search_", DbType.Int64, ParameterDirection.Input, IDMessage__parent_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDMessage__parent_search_", DbType.Int64, ParameterDirection.Input, IDMessage__parent_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vFOR_Message_Record_open_byParent_Recursive_page_fullmode"
						: "sp0_vFOR_Message_Record_open_byParent_Recursive_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byParent_Recursive(...);
		/// <summary>
		/// It selects vFOR_Message values from Database based on the 'byParent_Recursive' search and checks to see if vFOR_Message Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDMessage_in">vFOR_Message's IDMessage Key used for checking</param>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <returns>True if vFOR_Message Keys are met in the 'byParent_Recursive' search, False if not</returns>
		public static bool isObject_inRecord_byParent_Recursive(
			long IDMessage_in, 
			object IDMessage__parent_search_in
		) {
			return isObject_inRecord_byParent_Recursive(
				IDMessage_in, IDMessage__parent_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vFOR_Message values from Database based on the 'byParent_Recursive' search and checks to see if vFOR_Message Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDMessage_in">vFOR_Message's IDMessage Key used for checking</param>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vFOR_Message Keys are met in the 'byParent_Recursive' search, False if not</returns>
		public static bool isObject_inRecord_byParent_Recursive(
			long IDMessage_in, 
			object IDMessage__parent_search_in, 
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
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Input, IDMessage_in, 0), 
				_connection.newDBDataParameter("IDMessage__parent_search_", DbType.Int64, ParameterDirection.Input, IDMessage__parent_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vFOR_Message_Record_hasObject_byParent_Recursive", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byParent_Recursive(...);
		/// <summary>
		/// Count's number of search results from vFOR_Message at Database based on the 'byParent_Recursive' search.
		/// </summary>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <returns>number of existing Records for the 'byParent_Recursive' search</returns>
		public static long getCount_inRecord_byParent_Recursive(
			object IDMessage__parent_search_in
		) {
			return getCount_inRecord_byParent_Recursive(
				IDMessage__parent_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vFOR_Message at Database based on the 'byParent_Recursive' search.
		/// </summary>
		/// <param name="IDMessage__parent_search_in">IDMessage__parent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byParent_Recursive' search</returns>
		public static long getCount_inRecord_byParent_Recursive(
			object IDMessage__parent_search_in, 
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
				_connection.newDBDataParameter("IDMessage__parent_search_", DbType.Int64, ParameterDirection.Input, IDMessage__parent_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vFOR_Message_Record_count_byParent_Recursive", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???_Forum...
		#region public static SO_vFOR_Message[] getRecord_Forum(...);
		/// <summary>
		/// Gets Record, based on 'Forum' search. It selects vFOR_Message values from Database based on the 'Forum' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vFOR_Message[] getRecord_Forum(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_Forum(
				IDApplication_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'Forum' search. It selects vFOR_Message values from Database based on the 'Forum' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vFOR_Message[] getRecord_Forum(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vFOR_Message[] _output;

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
						? "sp0_vFOR_Message_Record_open_Forum_page_fullmode"
						: "sp0_vFOR_Message_Record_open_Forum_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_Forum(...);
		/// <summary>
		/// It selects vFOR_Message values from Database based on the 'Forum' search and checks to see if vFOR_Message Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDMessage_in">vFOR_Message's IDMessage Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if vFOR_Message Keys are met in the 'Forum' search, False if not</returns>
		public static bool isObject_inRecord_Forum(
			long IDMessage_in, 
			object IDApplication_search_in
		) {
			return isObject_inRecord_Forum(
				IDMessage_in, IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vFOR_Message values from Database based on the 'Forum' search and checks to see if vFOR_Message Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDMessage_in">vFOR_Message's IDMessage Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vFOR_Message Keys are met in the 'Forum' search, False if not</returns>
		public static bool isObject_inRecord_Forum(
			long IDMessage_in, 
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
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Input, IDMessage_in, 0), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vFOR_Message_Record_hasObject_Forum", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_Forum(...);
		/// <summary>
		/// Count's number of search results from vFOR_Message at Database based on the 'Forum' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>number of existing Records for the 'Forum' search</returns>
		public static long getCount_inRecord_Forum(
			object IDApplication_search_in
		) {
			return getCount_inRecord_Forum(
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vFOR_Message at Database based on the 'Forum' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'Forum' search</returns>
		public static long getCount_inRecord_Forum(
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
				"fnc0_vFOR_Message_Record_count_Forum", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???_byIDUser...
		#region public static SO_vFOR_Message[] getRecord_byIDUser(...);
		/// <summary>
		/// Gets Record, based on 'byIDUser' search. It selects vFOR_Message values from Database based on the 'byIDUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vFOR_Message[] getRecord_byIDUser(
			object IDUser_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byIDUser(
				IDUser_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byIDUser' search. It selects vFOR_Message values from Database based on the 'byIDUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vFOR_Message[] getRecord_byIDUser(
			object IDUser_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vFOR_Message[] _output;

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
						_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vFOR_Message_Record_open_byIDUser_page_fullmode"
						: "sp0_vFOR_Message_Record_open_byIDUser_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byIDUser(...);
		/// <summary>
		/// It selects vFOR_Message values from Database based on the 'byIDUser' search and checks to see if vFOR_Message Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDMessage_in">vFOR_Message's IDMessage Key used for checking</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <returns>True if vFOR_Message Keys are met in the 'byIDUser' search, False if not</returns>
		public static bool isObject_inRecord_byIDUser(
			long IDMessage_in, 
			object IDUser_search_in
		) {
			return isObject_inRecord_byIDUser(
				IDMessage_in, IDUser_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vFOR_Message values from Database based on the 'byIDUser' search and checks to see if vFOR_Message Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDMessage_in">vFOR_Message's IDMessage Key used for checking</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vFOR_Message Keys are met in the 'byIDUser' search, False if not</returns>
		public static bool isObject_inRecord_byIDUser(
			long IDMessage_in, 
			object IDUser_search_in, 
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
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Input, IDMessage_in, 0), 
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vFOR_Message_Record_hasObject_byIDUser", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byIDUser(...);
		/// <summary>
		/// Count's number of search results from vFOR_Message at Database based on the 'byIDUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <returns>number of existing Records for the 'byIDUser' search</returns>
		public static long getCount_inRecord_byIDUser(
			object IDUser_search_in
		) {
			return getCount_inRecord_byIDUser(
				IDUser_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vFOR_Message at Database based on the 'byIDUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byIDUser' search</returns>
		public static long getCount_inRecord_byIDUser(
			object IDUser_search_in, 
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
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vFOR_Message_Record_count_byIDUser", 
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