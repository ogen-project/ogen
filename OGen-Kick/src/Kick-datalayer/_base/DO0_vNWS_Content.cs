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
	/// vNWS_Content DataObject which provides access to vNWS_Content's Database table.
	/// </summary>
	[DOClassAttribute("vNWS_Content", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vNWS_Content 
#else
			DO_vNWS_Content 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_vNWS_Content[] getRecord(DataTable dataTable_in);
		private static SO_vNWS_Content[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idcontent = null;
			DataColumn _dc_idlanguage = null;
			DataColumn _dc_ifuser__publisher = null;
			DataColumn _dc_publishername = null;
			DataColumn _dc_publish_date = null;
			DataColumn _dc_ifuser__aproved = null;
			DataColumn _dc_aproved_date = null;
			DataColumn _dc_title = null;
			DataColumn _dc_content = null;
			DataColumn _dc_subtitle = null;
			DataColumn _dc_summary = null;

			SO_vNWS_Content[] _output 
				= new SO_vNWS_Content[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idcontent = dataTable_in.Columns["IDContent"];
					_dc_idlanguage = dataTable_in.Columns["IDLanguage"];
					_dc_ifuser__publisher = dataTable_in.Columns["IFUser__Publisher"];
					_dc_publishername = dataTable_in.Columns["PublisherName"];
					_dc_publish_date = dataTable_in.Columns["Publish_date"];
					_dc_ifuser__aproved = dataTable_in.Columns["IFUser__Aproved"];
					_dc_aproved_date = dataTable_in.Columns["Aproved_date"];
					_dc_title = dataTable_in.Columns["Title"];
					_dc_content = dataTable_in.Columns["Content"];
					_dc_subtitle = dataTable_in.Columns["subtitle"];
					_dc_summary = dataTable_in.Columns["summary"];
				}

				_output[r] = new SO_vNWS_Content();
				if (dataTable_in.Rows[r][_dc_idcontent] == System.DBNull.Value) {
					_output[r].idcontent_ = 0L;
				} else {
					_output[r].idcontent_ = (long)dataTable_in.Rows[r][_dc_idcontent];
				}
				if (dataTable_in.Rows[r][_dc_idlanguage] == System.DBNull.Value) {
					_output[r].idlanguage_ = 0;
				} else {
					_output[r].idlanguage_ = (int)dataTable_in.Rows[r][_dc_idlanguage];
				}
				if (dataTable_in.Rows[r][_dc_ifuser__publisher] == System.DBNull.Value) {
					_output[r].IFUser__Publisher_isNull = true;
				} else {
					_output[r].ifuser__publisher_ = (long)dataTable_in.Rows[r][_dc_ifuser__publisher];
				}
				if (dataTable_in.Rows[r][_dc_publishername] == System.DBNull.Value) {
					_output[r].PublisherName_isNull = true;
				} else {
					_output[r].publishername_ = (string)dataTable_in.Rows[r][_dc_publishername];
				}
				if (dataTable_in.Rows[r][_dc_publish_date] == System.DBNull.Value) {
					_output[r].Publish_date_isNull = true;
				} else {
					_output[r].publish_date_ = (DateTime)dataTable_in.Rows[r][_dc_publish_date];
				}
				if (dataTable_in.Rows[r][_dc_ifuser__aproved] == System.DBNull.Value) {
					_output[r].IFUser__Aproved_isNull = true;
				} else {
					_output[r].ifuser__aproved_ = (long)dataTable_in.Rows[r][_dc_ifuser__aproved];
				}
				if (dataTable_in.Rows[r][_dc_aproved_date] == System.DBNull.Value) {
					_output[r].Aproved_date_isNull = true;
				} else {
					_output[r].aproved_date_ = (DateTime)dataTable_in.Rows[r][_dc_aproved_date];
				}
				if (dataTable_in.Rows[r][_dc_title] == System.DBNull.Value) {
					_output[r].Title_isNull = true;
				} else {
					_output[r].title_ = (string)dataTable_in.Rows[r][_dc_title];
				}
				if (dataTable_in.Rows[r][_dc_content] == System.DBNull.Value) {
					_output[r].Content_isNull = true;
				} else {
					_output[r].content_ = (string)dataTable_in.Rows[r][_dc_content];
				}
				if (dataTable_in.Rows[r][_dc_subtitle] == System.DBNull.Value) {
					_output[r].subtitle_isNull = true;
				} else {
					_output[r].subtitle_ = (string)dataTable_in.Rows[r][_dc_subtitle];
				}
				if (dataTable_in.Rows[r][_dc_summary] == System.DBNull.Value) {
					_output[r].summary_isNull = true;
				} else {
					_output[r].summary_ = (string)dataTable_in.Rows[r][_dc_summary];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byContent...
		#region public static SO_vNWS_Content[] getRecord_byContent(...);
		/// <summary>
		/// Gets Record, based on 'byContent' search. It selects vNWS_Content values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Content[] getRecord_byContent(
			long IDContent_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byContent(
				IDContent_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byContent' search. It selects vNWS_Content values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Content[] getRecord_byContent(
			long IDContent_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Content[] _output;

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
						_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vNWS_Content_Record_open_byContent_page_fullmode"
						: "sp0_vNWS_Content_Record_open_byContent_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byContent(...);
		/// <summary>
		/// It selects vNWS_Content values from Database based on the 'byContent' search and checks to see if vNWS_Content Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDContent_in">vNWS_Content's IDContent Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Content's IDLanguage Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <returns>True if vNWS_Content Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IDContent_in, 
			int IDLanguage_in, 
			long IDContent_search_in
		) {
			return isObject_inRecord_byContent(
				IDContent_in, 
				IDLanguage_in, IDContent_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Content values from Database based on the 'byContent' search and checks to see if vNWS_Content Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDContent_in">vNWS_Content's IDContent Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Content's IDLanguage Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Content Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IDContent_in, 
			int IDLanguage_in, 
			long IDContent_search_in, 
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
				_connection.newDBDataParameter("IDContent_", DbType.Int64, ParameterDirection.Input, IDContent_in, 0), 
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Content_Record_hasObject_byContent", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byContent(...);
		/// <summary>
		/// Count's number of search results from vNWS_Content at Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <returns>number of existing Records for the 'byContent' search</returns>
		public static long getCount_inRecord_byContent(
			long IDContent_search_in
		) {
			return getCount_inRecord_byContent(
				IDContent_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNWS_Content at Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byContent' search</returns>
		public static long getCount_inRecord_byContent(
			long IDContent_search_in, 
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
				_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Content_Record_count_byContent", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???_byContent_andL...
		#region public static SO_vNWS_Content[] getRecord_byContent_andL(...);
		/// <summary>
		/// Gets Record, based on 'byContent_andL' search. It selects vNWS_Content values from Database based on the 'byContent_andL' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Content[] getRecord_byContent_andL(
			long IDContent_search_in, 
			int IDLanguage_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byContent_andL(
				IDContent_search_in, 
				IDLanguage_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byContent_andL' search. It selects vNWS_Content values from Database based on the 'byContent_andL' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Content[] getRecord_byContent_andL(
			long IDContent_search_in, 
			int IDLanguage_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Content[] _output;

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
						_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0), 
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0), 
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vNWS_Content_Record_open_byContent_andL_page_fullmode"
						: "sp0_vNWS_Content_Record_open_byContent_andL_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byContent_andL(...);
		/// <summary>
		/// It selects vNWS_Content values from Database based on the 'byContent_andL' search and checks to see if vNWS_Content Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDContent_in">vNWS_Content's IDContent Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Content's IDLanguage Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>True if vNWS_Content Keys are met in the 'byContent_andL' search, False if not</returns>
		public static bool isObject_inRecord_byContent_andL(
			long IDContent_in, 
			int IDLanguage_in, 
			long IDContent_search_in, 
			int IDLanguage_search_in
		) {
			return isObject_inRecord_byContent_andL(
				IDContent_in, 
				IDLanguage_in, IDContent_search_in, IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Content values from Database based on the 'byContent_andL' search and checks to see if vNWS_Content Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDContent_in">vNWS_Content's IDContent Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Content's IDLanguage Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Content Keys are met in the 'byContent_andL' search, False if not</returns>
		public static bool isObject_inRecord_byContent_andL(
			long IDContent_in, 
			int IDLanguage_in, 
			long IDContent_search_in, 
			int IDLanguage_search_in, 
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
				_connection.newDBDataParameter("IDContent_", DbType.Int64, ParameterDirection.Input, IDContent_in, 0), 
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Content_Record_hasObject_byContent_andL", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byContent_andL(...);
		/// <summary>
		/// Count's number of search results from vNWS_Content at Database based on the 'byContent_andL' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>number of existing Records for the 'byContent_andL' search</returns>
		public static long getCount_inRecord_byContent_andL(
			long IDContent_search_in, 
			int IDLanguage_search_in
		) {
			return getCount_inRecord_byContent_andL(
				IDContent_search_in, 
				IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNWS_Content at Database based on the 'byContent_andL' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byContent_andL' search</returns>
		public static long getCount_inRecord_byContent_andL(
			long IDContent_search_in, 
			int IDLanguage_search_in, 
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
				_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Content_Record_count_byContent_andL", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???_generic...
		#region public static SO_vNWS_Content[] getRecord_generic(...);
		/// <summary>
		/// Gets Record, based on 'generic' search. It selects vNWS_Content values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Content[] getRecord_generic(
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_generic(
				IFApplication_search_in, 
				IFUser__Publisher_search_in, 
				IFUser__Aproved_search_in, 
				Begin_date_search_in, 
				End_date_search_in, 
				IDTag_search_in, 
				IDAuthor_search_in, 
				IDSource_search_in, 
				IDHighlight_search_in, 
				IDProfile_search_in, 
				Keywords_search_in, 
				IDLanguage_search_in, 
				isAND_notOR_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'generic' search. It selects vNWS_Content values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Content[] getRecord_generic(
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Content[] _output;

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
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
						_connection.newDBDataParameter("IFUser__Publisher_search_", DbType.Int64, ParameterDirection.Input, IFUser__Publisher_search_in, 0), 
						_connection.newDBDataParameter("IFUser__Aproved_search_", DbType.Int64, ParameterDirection.Input, IFUser__Aproved_search_in, 0), 
						_connection.newDBDataParameter("Begin_date_search_", DbType.DateTime, ParameterDirection.Input, Begin_date_search_in, 0), 
						_connection.newDBDataParameter("End_date_search_", DbType.DateTime, ParameterDirection.Input, End_date_search_in, 0), 
						_connection.newDBDataParameter("IDTag_search_", DbType.AnsiString, ParameterDirection.Input, IDTag_search_in, 8000), 
						_connection.newDBDataParameter("IDAuthor_search_", DbType.AnsiString, ParameterDirection.Input, IDAuthor_search_in, 8000), 
						_connection.newDBDataParameter("IDSource_search_", DbType.AnsiString, ParameterDirection.Input, IDSource_search_in, 8000), 
						_connection.newDBDataParameter("IDHighlight_search_", DbType.AnsiString, ParameterDirection.Input, IDHighlight_search_in, 8000), 
						_connection.newDBDataParameter("IDProfile_search_", DbType.AnsiString, ParameterDirection.Input, IDProfile_search_in, 8000), 
						_connection.newDBDataParameter("Keywords_search_", DbType.AnsiString, ParameterDirection.Input, Keywords_search_in, 8000), 
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
						_connection.newDBDataParameter("isAND_notOR_search_", DbType.Boolean, ParameterDirection.Input, isAND_notOR_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
						_connection.newDBDataParameter("IFUser__Publisher_search_", DbType.Int64, ParameterDirection.Input, IFUser__Publisher_search_in, 0), 
						_connection.newDBDataParameter("IFUser__Aproved_search_", DbType.Int64, ParameterDirection.Input, IFUser__Aproved_search_in, 0), 
						_connection.newDBDataParameter("Begin_date_search_", DbType.DateTime, ParameterDirection.Input, Begin_date_search_in, 0), 
						_connection.newDBDataParameter("End_date_search_", DbType.DateTime, ParameterDirection.Input, End_date_search_in, 0), 
						_connection.newDBDataParameter("IDTag_search_", DbType.AnsiString, ParameterDirection.Input, IDTag_search_in, 8000), 
						_connection.newDBDataParameter("IDAuthor_search_", DbType.AnsiString, ParameterDirection.Input, IDAuthor_search_in, 8000), 
						_connection.newDBDataParameter("IDSource_search_", DbType.AnsiString, ParameterDirection.Input, IDSource_search_in, 8000), 
						_connection.newDBDataParameter("IDHighlight_search_", DbType.AnsiString, ParameterDirection.Input, IDHighlight_search_in, 8000), 
						_connection.newDBDataParameter("IDProfile_search_", DbType.AnsiString, ParameterDirection.Input, IDProfile_search_in, 8000), 
						_connection.newDBDataParameter("Keywords_search_", DbType.AnsiString, ParameterDirection.Input, Keywords_search_in, 8000), 
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
						_connection.newDBDataParameter("isAND_notOR_search_", DbType.Boolean, ParameterDirection.Input, isAND_notOR_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vNWS_Content_Record_open_generic_page_fullmode"
						: "sp0_vNWS_Content_Record_open_generic_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_generic(...);
		/// <summary>
		/// It selects vNWS_Content values from Database based on the 'generic' search and checks to see if vNWS_Content Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDContent_in">vNWS_Content's IDContent Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Content's IDLanguage Key used for checking</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <returns>True if vNWS_Content Keys are met in the 'generic' search, False if not</returns>
		public static bool isObject_inRecord_generic(
			long IDContent_in, 
			int IDLanguage_in, 
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in
		) {
			return isObject_inRecord_generic(
				IDContent_in, 
				IDLanguage_in, IFApplication_search_in, IFUser__Publisher_search_in, IFUser__Aproved_search_in, Begin_date_search_in, End_date_search_in, IDTag_search_in, IDAuthor_search_in, IDSource_search_in, IDHighlight_search_in, IDProfile_search_in, Keywords_search_in, IDLanguage_search_in, isAND_notOR_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Content values from Database based on the 'generic' search and checks to see if vNWS_Content Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDContent_in">vNWS_Content's IDContent Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Content's IDLanguage Key used for checking</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Content Keys are met in the 'generic' search, False if not</returns>
		public static bool isObject_inRecord_generic(
			long IDContent_in, 
			int IDLanguage_in, 
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in, 
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
				_connection.newDBDataParameter("IDContent_", DbType.Int64, ParameterDirection.Input, IDContent_in, 0), 
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_search_", DbType.Int64, ParameterDirection.Input, IFUser__Publisher_search_in, 0), 
				_connection.newDBDataParameter("IFUser__Aproved_search_", DbType.Int64, ParameterDirection.Input, IFUser__Aproved_search_in, 0), 
				_connection.newDBDataParameter("Begin_date_search_", DbType.DateTime, ParameterDirection.Input, Begin_date_search_in, 0), 
				_connection.newDBDataParameter("End_date_search_", DbType.DateTime, ParameterDirection.Input, End_date_search_in, 0), 
				_connection.newDBDataParameter("IDTag_search_", DbType.AnsiString, ParameterDirection.Input, IDTag_search_in, 8000), 
				_connection.newDBDataParameter("IDAuthor_search_", DbType.AnsiString, ParameterDirection.Input, IDAuthor_search_in, 8000), 
				_connection.newDBDataParameter("IDSource_search_", DbType.AnsiString, ParameterDirection.Input, IDSource_search_in, 8000), 
				_connection.newDBDataParameter("IDHighlight_search_", DbType.AnsiString, ParameterDirection.Input, IDHighlight_search_in, 8000), 
				_connection.newDBDataParameter("IDProfile_search_", DbType.AnsiString, ParameterDirection.Input, IDProfile_search_in, 8000), 
				_connection.newDBDataParameter("Keywords_search_", DbType.AnsiString, ParameterDirection.Input, Keywords_search_in, 8000), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
				_connection.newDBDataParameter("isAND_notOR_search_", DbType.Boolean, ParameterDirection.Input, isAND_notOR_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Content_Record_hasObject_generic", 
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
		/// Count's number of search results from vNWS_Content at Database based on the 'generic' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <returns>number of existing Records for the 'generic' search</returns>
		public static long getCount_inRecord_generic(
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in
		) {
			return getCount_inRecord_generic(
				IFApplication_search_in, 
				IFUser__Publisher_search_in, 
				IFUser__Aproved_search_in, 
				Begin_date_search_in, 
				End_date_search_in, 
				IDTag_search_in, 
				IDAuthor_search_in, 
				IDSource_search_in, 
				IDHighlight_search_in, 
				IDProfile_search_in, 
				Keywords_search_in, 
				IDLanguage_search_in, 
				isAND_notOR_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNWS_Content at Database based on the 'generic' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'generic' search</returns>
		public static long getCount_inRecord_generic(
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in, 
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
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_search_", DbType.Int64, ParameterDirection.Input, IFUser__Publisher_search_in, 0), 
				_connection.newDBDataParameter("IFUser__Aproved_search_", DbType.Int64, ParameterDirection.Input, IFUser__Aproved_search_in, 0), 
				_connection.newDBDataParameter("Begin_date_search_", DbType.DateTime, ParameterDirection.Input, Begin_date_search_in, 0), 
				_connection.newDBDataParameter("End_date_search_", DbType.DateTime, ParameterDirection.Input, End_date_search_in, 0), 
				_connection.newDBDataParameter("IDTag_search_", DbType.AnsiString, ParameterDirection.Input, IDTag_search_in, 8000), 
				_connection.newDBDataParameter("IDAuthor_search_", DbType.AnsiString, ParameterDirection.Input, IDAuthor_search_in, 8000), 
				_connection.newDBDataParameter("IDSource_search_", DbType.AnsiString, ParameterDirection.Input, IDSource_search_in, 8000), 
				_connection.newDBDataParameter("IDHighlight_search_", DbType.AnsiString, ParameterDirection.Input, IDHighlight_search_in, 8000), 
				_connection.newDBDataParameter("IDProfile_search_", DbType.AnsiString, ParameterDirection.Input, IDProfile_search_in, 8000), 
				_connection.newDBDataParameter("Keywords_search_", DbType.AnsiString, ParameterDirection.Input, Keywords_search_in, 8000), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
				_connection.newDBDataParameter("isAND_notOR_search_", DbType.Boolean, ParameterDirection.Input, isAND_notOR_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Content_Record_count_generic", 
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