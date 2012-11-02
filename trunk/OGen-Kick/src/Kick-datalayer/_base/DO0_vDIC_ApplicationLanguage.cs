#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.lib.datalayer {
	using System;
	using System.Data;

	using OGen.lib.datalayer;
	using OGen.NTier.lib.datalayer;

	using OGen.NTier.Kick.lib.datalayer.shared.structures;

	/// <summary>
	/// vDIC_ApplicationLanguage DataObject which provides access to vDIC_ApplicationLanguage's Database table.
	/// </summary>
	[DOClassAttribute("vDIC_ApplicationLanguage", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vDIC_ApplicationLanguage 
#else
			DO_vDIC_ApplicationLanguage 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_vDIC_ApplicationLanguage[] getRecord(DataTable dataTable_in);
		private static SO_vDIC_ApplicationLanguage[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifapplication = null;
			DataColumn _dc_idlanguage = null;
			DataColumn _dc_language = null;

			SO_vDIC_ApplicationLanguage[] _output 
				= new SO_vDIC_ApplicationLanguage[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
					_dc_idlanguage = dataTable_in.Columns["IDLanguage"];
					_dc_language = dataTable_in.Columns["Language"];
				}

				_output[r] = new SO_vDIC_ApplicationLanguage();
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication = 0;
				} else {
					_output[r].IFApplication = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}
				if (dataTable_in.Rows[r][_dc_idlanguage] == System.DBNull.Value) {
					_output[r].IDLanguage = 0;
				} else {
					_output[r].IDLanguage = (int)dataTable_in.Rows[r][_dc_idlanguage];
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

		#region ???_byApplication...
		#region public static SO_vDIC_ApplicationLanguage[] getRecord_byApplication(...);
		/// <summary>
		/// Gets Record, based on 'byApplication' search. It selects vDIC_ApplicationLanguage values from Database based on the 'byApplication' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		public static SO_vDIC_ApplicationLanguage[] getRecord_byApplication(
			int IFApplication_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out
		) {
			return getRecord_byApplication(
				IFApplication_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byApplication' search. It selects vDIC_ApplicationLanguage values from Database based on the 'byApplication' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vDIC_ApplicationLanguage[] getRecord_byApplication(
			int IFApplication_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			DBConnection dbConnection_in
		) {
			SO_vDIC_ApplicationLanguage[] _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = 
				((page_in > 0) && (page_itemsPerPage_in > 0))
					? new IDbDataParameter[] {
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
						_connection.newDBDataParameter("page_orderBy_", DbType.Int32, ParameterDirection.Input, page_orderBy_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int64, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_itemsPerPage_", DbType.Int32, ParameterDirection.Input, page_itemsPerPage_in, 0), 

						//_connection.newDBDataParameter("page_itemsCount_", DbType.Int32, ParameterDirection.Output, null, 0), 

					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_itemsPerPage_in > 0))
						? "sp_vDIC_ApplicationLanguage_Record_open_byApplication_page"
						: "sp0_vDIC_ApplicationLanguage_Record_open_byApplication", 
					_dataparameters
				)
			);
			if ((page_in > 0) && (page_itemsPerPage_in > 0)) {
				// && (_dataparameters[_dataparameters.Length - 1].Value != DBNull.Value)) {
				//page_itemsCount_out = (int)_dataparameters[_dataparameters.Length - 1].Value;

				page_itemsCount_out = getCount_inRecord_byApplication(
					IFApplication_search_in, 
					dbConnection_in
				);
			} else {
				page_itemsCount_out = 0;
			}
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byApplication(...);
		/// <summary>
		/// It selects vDIC_ApplicationLanguage values from Database based on the 'byApplication' search and checks to see if vDIC_ApplicationLanguage Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFApplication_in">vDIC_ApplicationLanguage's IFApplication Key used for checking</param>
		/// <param name="IDLanguage_in">vDIC_ApplicationLanguage's IDLanguage Key used for checking</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <returns>True if vDIC_ApplicationLanguage Keys are met in the 'byApplication' search, False if not</returns>
		public static bool isObject_inRecord_byApplication(
			int IFApplication_in, 
			int IDLanguage_in, 
			int IFApplication_search_in
		) {
			return isObject_inRecord_byApplication(
				IFApplication_in, 
				IDLanguage_in, IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vDIC_ApplicationLanguage values from Database based on the 'byApplication' search and checks to see if vDIC_ApplicationLanguage Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFApplication_in">vDIC_ApplicationLanguage's IFApplication Key used for checking</param>
		/// <param name="IDLanguage_in">vDIC_ApplicationLanguage's IDLanguage Key used for checking</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vDIC_ApplicationLanguage Keys are met in the 'byApplication' search, False if not</returns>
		public static bool isObject_inRecord_byApplication(
			int IFApplication_in, 
			int IDLanguage_in, 
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
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, IFApplication_in, 0), 
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vDIC_ApplicationLanguage_Record_hasObject_byApplication", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byApplication(...);
		/// <summary>
		/// Count's number of search results from vDIC_ApplicationLanguage at Database based on the 'byApplication' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <returns>number of existing Records for the 'byApplication' search</returns>
		public static long getCount_inRecord_byApplication(
			int IFApplication_search_in
		) {
			return getCount_inRecord_byApplication(
				IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vDIC_ApplicationLanguage at Database based on the 'byApplication' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byApplication' search</returns>
		public static long getCount_inRecord_byApplication(
			int IFApplication_search_in, 
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
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vDIC_ApplicationLanguage_Record_count_byApplication", 
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