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
	/// vNWS_Author DataObject which provides access to vNWS_Author's Database table.
	/// </summary>
	[DOClassAttribute("vNWS_Author", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vNWS_Author 
#else
			DO_vNWS_Author 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_vNWS_Author[] getRecord(DataTable dataTable_in);
		private static SO_vNWS_Author[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idauthor = null;
			DataColumn _dc_idapplication = null;
			DataColumn _dc_name = null;
			DataColumn _dc_ifuser__approved = null;
			DataColumn _dc_managername = null;
			DataColumn _dc_approved_date = null;

			SO_vNWS_Author[] _output 
				= new SO_vNWS_Author[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idauthor = dataTable_in.Columns["IDAuthor"];
					_dc_idapplication = dataTable_in.Columns["IDApplication"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_ifuser__approved = dataTable_in.Columns["IFUser__Approved"];
					_dc_managername = dataTable_in.Columns["ManagerName"];
					_dc_approved_date = dataTable_in.Columns["Approved_date"];
				}

				_output[r] = new SO_vNWS_Author();
				if (dataTable_in.Rows[r][_dc_idauthor] == System.DBNull.Value) {
					_output[r].idauthor_ = 0L;
				} else {
					_output[r].idauthor_ = (long)dataTable_in.Rows[r][_dc_idauthor];
				}
				if (dataTable_in.Rows[r][_dc_idapplication] == System.DBNull.Value) {
					_output[r].IDApplication_isNull = true;
				} else {
					_output[r].idapplication_ = (int)dataTable_in.Rows[r][_dc_idapplication];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].Name_isNull = true;
				} else {
					_output[r].name_ = (string)dataTable_in.Rows[r][_dc_name];
				}
				if (dataTable_in.Rows[r][_dc_ifuser__approved] == System.DBNull.Value) {
					_output[r].IFUser__Approved_isNull = true;
				} else {
					_output[r].ifuser__approved_ = (long)dataTable_in.Rows[r][_dc_ifuser__approved];
				}
				if (dataTable_in.Rows[r][_dc_managername] == System.DBNull.Value) {
					_output[r].ManagerName_isNull = true;
				} else {
					_output[r].managername_ = (string)dataTable_in.Rows[r][_dc_managername];
				}
				if (dataTable_in.Rows[r][_dc_approved_date] == System.DBNull.Value) {
					_output[r].Approved_date_isNull = true;
				} else {
					_output[r].approved_date_ = (DateTime)dataTable_in.Rows[r][_dc_approved_date];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_all...
		#region public static SO_vNWS_Author[] getRecord_all(...);
		/// <summary>
		/// Gets Record, based on 'all' search. It selects vNWS_Author values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Author[] getRecord_all(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_all(
				IDApplication_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'all' search. It selects vNWS_Author values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Author[] getRecord_all(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Author[] _output;

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
						? "sp0_vNWS_Author_Record_open_all_page_fullmode"
						: "sp0_vNWS_Author_Record_open_all_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_all(...);
		/// <summary>
		/// It selects vNWS_Author values from Database based on the 'all' search and checks to see if vNWS_Author Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDAuthor_in">vNWS_Author's IDAuthor Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if vNWS_Author Keys are met in the 'all' search, False if not</returns>
		public static bool isObject_inRecord_all(
			long IDAuthor_in, 
			object IDApplication_search_in
		) {
			return isObject_inRecord_all(
				IDAuthor_in, IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Author values from Database based on the 'all' search and checks to see if vNWS_Author Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDAuthor_in">vNWS_Author's IDAuthor Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Author Keys are met in the 'all' search, False if not</returns>
		public static bool isObject_inRecord_all(
			long IDAuthor_in, 
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
				_connection.newDBDataParameter("IDAuthor_", DbType.Int64, ParameterDirection.Input, IDAuthor_in, 0), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Author_Record_hasObject_all", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_all(...);
		/// <summary>
		/// Count's number of search results from vNWS_Author at Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>number of existing Records for the 'all' search</returns>
		public static long getCount_inRecord_all(
			object IDApplication_search_in
		) {
			return getCount_inRecord_all(
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNWS_Author at Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'all' search</returns>
		public static long getCount_inRecord_all(
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
				"fnc0_vNWS_Author_Record_count_all", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???_Approved...
		#region public static SO_vNWS_Author[] getRecord_Approved(...);
		/// <summary>
		/// Gets Record, based on 'Approved' search. It selects vNWS_Author values from Database based on the 'Approved' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Author[] getRecord_Approved(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_Approved(
				IDApplication_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'Approved' search. It selects vNWS_Author values from Database based on the 'Approved' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Author[] getRecord_Approved(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Author[] _output;

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
						? "sp0_vNWS_Author_Record_open_Approved_page_fullmode"
						: "sp0_vNWS_Author_Record_open_Approved_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_Approved(...);
		/// <summary>
		/// It selects vNWS_Author values from Database based on the 'Approved' search and checks to see if vNWS_Author Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDAuthor_in">vNWS_Author's IDAuthor Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if vNWS_Author Keys are met in the 'Approved' search, False if not</returns>
		public static bool isObject_inRecord_Approved(
			long IDAuthor_in, 
			object IDApplication_search_in
		) {
			return isObject_inRecord_Approved(
				IDAuthor_in, IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Author values from Database based on the 'Approved' search and checks to see if vNWS_Author Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDAuthor_in">vNWS_Author's IDAuthor Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Author Keys are met in the 'Approved' search, False if not</returns>
		public static bool isObject_inRecord_Approved(
			long IDAuthor_in, 
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
				_connection.newDBDataParameter("IDAuthor_", DbType.Int64, ParameterDirection.Input, IDAuthor_in, 0), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Author_Record_hasObject_Approved", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_Approved(...);
		/// <summary>
		/// Count's number of search results from vNWS_Author at Database based on the 'Approved' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>number of existing Records for the 'Approved' search</returns>
		public static long getCount_inRecord_Approved(
			object IDApplication_search_in
		) {
			return getCount_inRecord_Approved(
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNWS_Author at Database based on the 'Approved' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'Approved' search</returns>
		public static long getCount_inRecord_Approved(
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
				"fnc0_vNWS_Author_Record_count_Approved", 
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