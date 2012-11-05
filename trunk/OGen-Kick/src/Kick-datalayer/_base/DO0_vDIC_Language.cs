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
	/// vDIC_Language DataObject which provides access to vDIC_Language's Database table.
	/// </summary>
	[DOClassAttribute("vDIC_Language", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_vDIC_Language 
#else
			DO_vDIC_Language 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_vDIC_Language[] getRecord(DataTable dataTable_in);
		private static SO_vDIC_Language[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idlanguage = null;
			DataColumn _dc_idlanguage_translation = null;
			DataColumn _dc_language = null;

			SO_vDIC_Language[] _output 
				= new SO_vDIC_Language[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idlanguage = dataTable_in.Columns["IDLanguage"];
					_dc_idlanguage_translation = dataTable_in.Columns["IDLanguage_translation"];
					_dc_language = dataTable_in.Columns["Language"];
				}

				_output[r] = new SO_vDIC_Language();
				if (dataTable_in.Rows[r][_dc_idlanguage] == System.DBNull.Value) {
					_output[r].IDLanguage = 0;
				} else {
					_output[r].IDLanguage = (int)dataTable_in.Rows[r][_dc_idlanguage];
				}
				if (dataTable_in.Rows[r][_dc_idlanguage_translation] == System.DBNull.Value) {
					_output[r].IDLanguage_translation = 0;
				} else {
					_output[r].IDLanguage_translation = (int)dataTable_in.Rows[r][_dc_idlanguage_translation];
				}
				if (dataTable_in.Rows[r][_dc_language] == System.DBNull.Value) {
					_output[r].Language_isNull = true;
				} else {
					_output[r].Language = (string)dataTable_in.Rows[r][_dc_language];
				}

				_output[r].hasChanges = false;
			}

			return _output;
		}
		#endregion
		#region ???_byLanguage...
		#region public static SO_vDIC_Language[] getRecord_byLanguage(...);
		/// <summary>
		/// Gets Record, based on 'byLanguage' search. It selects vDIC_Language values from Database based on the 'byLanguage' search.
		/// </summary>
		/// <param name="IDLanguage_translation_search_in">IDLanguage_translation search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		public static SO_vDIC_Language[] getRecord_byLanguage(
			int IDLanguage_translation_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out
		) {
			return getRecord_byLanguage(
				IDLanguage_translation_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byLanguage' search. It selects vDIC_Language values from Database based on the 'byLanguage' search.
		/// </summary>
		/// <param name="IDLanguage_translation_search_in">IDLanguage_translation search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vDIC_Language[] getRecord_byLanguage(
			int IDLanguage_translation_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			DBConnection dbConnection_in
		) {
			SO_vDIC_Language[] _output;

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
						_connection.newDBDataParameter("IDLanguage_translation_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_translation_search_in, 0), 
						_connection.newDBDataParameter("page_orderBy_", DbType.Int32, ParameterDirection.Input, page_orderBy_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int64, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_itemsPerPage_", DbType.Int32, ParameterDirection.Input, page_itemsPerPage_in, 0), 

						//_connection.newDBDataParameter("page_itemsCount_", DbType.Int32, ParameterDirection.Output, null, 0), 

					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDLanguage_translation_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_translation_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_itemsPerPage_in > 0))
						? "sp_vDIC_Language_Record_open_byLanguage_page"
						: "sp0_vDIC_Language_Record_open_byLanguage", 
					_dataparameters
				)
			);
			if ((page_in > 0) && (page_itemsPerPage_in > 0)) {
				// && (_dataparameters[_dataparameters.Length - 1].Value != DBNull.Value)) {
				//page_itemsCount_out = (int)_dataparameters[_dataparameters.Length - 1].Value;

				page_itemsCount_out = getCount_inRecord_byLanguage(
					IDLanguage_translation_search_in, 
					dbConnection_in
				);
			} else {
				page_itemsCount_out = 0;
			}
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byLanguage(...);
		/// <summary>
		/// It selects vDIC_Language values from Database based on the 'byLanguage' search and checks to see if vDIC_Language Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDLanguage_in">vDIC_Language's IDLanguage Key used for checking</param>
		/// <param name="IDLanguage_translation_in">vDIC_Language's IDLanguage_translation Key used for checking</param>
		/// <param name="IDLanguage_translation_search_in">IDLanguage_translation search condition</param>
		/// <returns>True if vDIC_Language Keys are met in the 'byLanguage' search, False if not</returns>
		public static bool isObject_inRecord_byLanguage(
			int IDLanguage_in, 
			int IDLanguage_translation_in, 
			int IDLanguage_translation_search_in
		) {
			return isObject_inRecord_byLanguage(
				IDLanguage_in, 
				IDLanguage_translation_in, IDLanguage_translation_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vDIC_Language values from Database based on the 'byLanguage' search and checks to see if vDIC_Language Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDLanguage_in">vDIC_Language's IDLanguage Key used for checking</param>
		/// <param name="IDLanguage_translation_in">vDIC_Language's IDLanguage_translation Key used for checking</param>
		/// <param name="IDLanguage_translation_search_in">IDLanguage_translation search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vDIC_Language Keys are met in the 'byLanguage' search, False if not</returns>
		public static bool isObject_inRecord_byLanguage(
			int IDLanguage_in, 
			int IDLanguage_translation_in, 
			int IDLanguage_translation_search_in, 
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
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IDLanguage_translation_", DbType.Int32, ParameterDirection.Input, IDLanguage_translation_in, 0), 
				_connection.newDBDataParameter("IDLanguage_translation_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_translation_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vDIC_Language_Record_hasObject_byLanguage", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byLanguage(...);
		/// <summary>
		/// Count's number of search results from vDIC_Language at Database based on the 'byLanguage' search.
		/// </summary>
		/// <param name="IDLanguage_translation_search_in">IDLanguage_translation search condition</param>
		/// <returns>number of existing Records for the 'byLanguage' search</returns>
		public static long getCount_inRecord_byLanguage(
			int IDLanguage_translation_search_in
		) {
			return getCount_inRecord_byLanguage(
				IDLanguage_translation_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vDIC_Language at Database based on the 'byLanguage' search.
		/// </summary>
		/// <param name="IDLanguage_translation_search_in">IDLanguage_translation search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byLanguage' search</returns>
		public static long getCount_inRecord_byLanguage(
			int IDLanguage_translation_search_in, 
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
				_connection.newDBDataParameter("IDLanguage_translation_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_translation_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vDIC_Language_Record_count_byLanguage", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???_Language...
		#region public static SO_vDIC_Language[] getRecord_Language(...);
		/// <summary>
		/// Gets Record, based on 'Language' search. It selects vDIC_Language values from Database based on the 'Language' search.
		/// </summary>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		public static SO_vDIC_Language[] getRecord_Language(
			int IDLanguage_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out
		) {
			return getRecord_Language(
				IDLanguage_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'Language' search. It selects vDIC_Language values from Database based on the 'Language' search.
		/// </summary>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vDIC_Language[] getRecord_Language(
			int IDLanguage_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			DBConnection dbConnection_in
		) {
			SO_vDIC_Language[] _output;

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
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
						_connection.newDBDataParameter("page_orderBy_", DbType.Int32, ParameterDirection.Input, page_orderBy_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int64, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_itemsPerPage_", DbType.Int32, ParameterDirection.Input, page_itemsPerPage_in, 0), 

						//_connection.newDBDataParameter("page_itemsCount_", DbType.Int32, ParameterDirection.Output, null, 0), 

					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_itemsPerPage_in > 0))
						? "sp_vDIC_Language_Record_open_Language_page"
						: "sp0_vDIC_Language_Record_open_Language", 
					_dataparameters
				)
			);
			if ((page_in > 0) && (page_itemsPerPage_in > 0)) {
				// && (_dataparameters[_dataparameters.Length - 1].Value != DBNull.Value)) {
				//page_itemsCount_out = (int)_dataparameters[_dataparameters.Length - 1].Value;

				page_itemsCount_out = getCount_inRecord_Language(
					IDLanguage_search_in, 
					dbConnection_in
				);
			} else {
				page_itemsCount_out = 0;
			}
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_Language(...);
		/// <summary>
		/// It selects vDIC_Language values from Database based on the 'Language' search and checks to see if vDIC_Language Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDLanguage_in">vDIC_Language's IDLanguage Key used for checking</param>
		/// <param name="IDLanguage_translation_in">vDIC_Language's IDLanguage_translation Key used for checking</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>True if vDIC_Language Keys are met in the 'Language' search, False if not</returns>
		public static bool isObject_inRecord_Language(
			int IDLanguage_in, 
			int IDLanguage_translation_in, 
			int IDLanguage_search_in
		) {
			return isObject_inRecord_Language(
				IDLanguage_in, 
				IDLanguage_translation_in, IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vDIC_Language values from Database based on the 'Language' search and checks to see if vDIC_Language Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDLanguage_in">vDIC_Language's IDLanguage Key used for checking</param>
		/// <param name="IDLanguage_translation_in">vDIC_Language's IDLanguage_translation Key used for checking</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vDIC_Language Keys are met in the 'Language' search, False if not</returns>
		public static bool isObject_inRecord_Language(
			int IDLanguage_in, 
			int IDLanguage_translation_in, 
			int IDLanguage_search_in, 
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
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IDLanguage_translation_", DbType.Int32, ParameterDirection.Input, IDLanguage_translation_in, 0), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vDIC_Language_Record_hasObject_Language", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_Language(...);
		/// <summary>
		/// Count's number of search results from vDIC_Language at Database based on the 'Language' search.
		/// </summary>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>number of existing Records for the 'Language' search</returns>
		public static long getCount_inRecord_Language(
			int IDLanguage_search_in
		) {
			return getCount_inRecord_Language(
				IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vDIC_Language at Database based on the 'Language' search.
		/// </summary>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'Language' search</returns>
		public static long getCount_inRecord_Language(
			int IDLanguage_search_in, 
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
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vDIC_Language_Record_count_Language", 
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