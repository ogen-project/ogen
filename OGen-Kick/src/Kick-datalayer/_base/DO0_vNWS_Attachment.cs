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
	/// vNWS_Attachment DataObject which provides access to vNWS_Attachment's Database table.
	/// </summary>
	[DOClassAttribute("vNWS_Attachment", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vNWS_Attachment 
#else
			DO_vNWS_Attachment 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_vNWS_Attachment[] getRecord(DataTable dataTable_in);
		private static SO_vNWS_Attachment[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idattachment = null;
			DataColumn _dc_idlanguage = null;
			DataColumn _dc_ifcontent = null;
			DataColumn _dc_guid = null;
			DataColumn _dc_ordernum = null;
			DataColumn _dc_isimage = null;
			DataColumn _dc_name = null;
			DataColumn _dc_description = null;
			DataColumn _dc_filename = null;

			SO_vNWS_Attachment[] _output 
				= new SO_vNWS_Attachment[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idattachment = dataTable_in.Columns["IDAttachment"];
					_dc_idlanguage = dataTable_in.Columns["IDLanguage"];
					_dc_ifcontent = dataTable_in.Columns["IFContent"];
					_dc_guid = dataTable_in.Columns["GUID"];
					_dc_ordernum = dataTable_in.Columns["OrderNum"];
					_dc_isimage = dataTable_in.Columns["isImage"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_description = dataTable_in.Columns["Description"];
					_dc_filename = dataTable_in.Columns["FileName"];
				}

				_output[r] = new SO_vNWS_Attachment();
				if (dataTable_in.Rows[r][_dc_idattachment] == System.DBNull.Value) {
					_output[r].idattachment_ = 0L;
				} else {
					_output[r].idattachment_ = (long)dataTable_in.Rows[r][_dc_idattachment];
				}
				if (dataTable_in.Rows[r][_dc_idlanguage] == System.DBNull.Value) {
					_output[r].idlanguage_ = 0;
				} else {
					_output[r].idlanguage_ = (int)dataTable_in.Rows[r][_dc_idlanguage];
				}
				if (dataTable_in.Rows[r][_dc_ifcontent] == System.DBNull.Value) {
					_output[r].IFContent_isNull = true;
				} else {
					_output[r].ifcontent_ = (long)dataTable_in.Rows[r][_dc_ifcontent];
				}
				if (dataTable_in.Rows[r][_dc_guid] == System.DBNull.Value) {
					_output[r].GUID_isNull = true;
				} else {
					_output[r].guid_ = (string)dataTable_in.Rows[r][_dc_guid];
				}
				if (dataTable_in.Rows[r][_dc_ordernum] == System.DBNull.Value) {
					_output[r].OrderNum_isNull = true;
				} else {
					_output[r].ordernum_ = (long)dataTable_in.Rows[r][_dc_ordernum];
				}
				if (dataTable_in.Rows[r][_dc_isimage] == System.DBNull.Value) {
					_output[r].isImage_isNull = true;
				} else {
					_output[r].isimage_ = (bool)dataTable_in.Rows[r][_dc_isimage];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].Name_isNull = true;
				} else {
					_output[r].name_ = (string)dataTable_in.Rows[r][_dc_name];
				}
				if (dataTable_in.Rows[r][_dc_description] == System.DBNull.Value) {
					_output[r].Description_isNull = true;
				} else {
					_output[r].description_ = (string)dataTable_in.Rows[r][_dc_description];
				}
				if (dataTable_in.Rows[r][_dc_filename] == System.DBNull.Value) {
					_output[r].FileName_isNull = true;
				} else {
					_output[r].filename_ = (string)dataTable_in.Rows[r][_dc_filename];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byContent...
		#region public static SO_vNWS_Attachment[] getRecord_byContent(...);
		/// <summary>
		/// Gets Record, based on 'byContent' search. It selects vNWS_Attachment values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Attachment[] getRecord_byContent(
			object IDContent_search_in, 
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
		/// Gets Record, based on 'byContent' search. It selects vNWS_Attachment values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Attachment[] getRecord_byContent(
			object IDContent_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Attachment[] _output;

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
						? "sp0_vNWS_Attachment_Record_open_byContent_page_fullmode"
						: "sp0_vNWS_Attachment_Record_open_byContent_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byContent(...);
		/// <summary>
		/// It selects vNWS_Attachment values from Database based on the 'byContent' search and checks to see if vNWS_Attachment Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDAttachment_in">vNWS_Attachment's IDAttachment Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Attachment's IDLanguage Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <returns>True if vNWS_Attachment Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IDAttachment_in, 
			int IDLanguage_in, 
			object IDContent_search_in
		) {
			return isObject_inRecord_byContent(
				IDAttachment_in, 
				IDLanguage_in, IDContent_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Attachment values from Database based on the 'byContent' search and checks to see if vNWS_Attachment Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDAttachment_in">vNWS_Attachment's IDAttachment Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Attachment's IDLanguage Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Attachment Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IDAttachment_in, 
			int IDLanguage_in, 
			object IDContent_search_in, 
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
				_connection.newDBDataParameter("IDAttachment_", DbType.Int64, ParameterDirection.Input, IDAttachment_in, 0), 
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Attachment_Record_hasObject_byContent", 
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
		/// Count's number of search results from vNWS_Attachment at Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <returns>number of existing Records for the 'byContent' search</returns>
		public static long getCount_inRecord_byContent(
			object IDContent_search_in
		) {
			return getCount_inRecord_byContent(
				IDContent_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNWS_Attachment at Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byContent' search</returns>
		public static long getCount_inRecord_byContent(
			object IDContent_search_in, 
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
				"fnc0_vNWS_Attachment_Record_count_byContent", 
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
		#region public static SO_vNWS_Attachment[] getRecord_byContent_andL(...);
		/// <summary>
		/// Gets Record, based on 'byContent_andL' search. It selects vNWS_Attachment values from Database based on the 'byContent_andL' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Attachment[] getRecord_byContent_andL(
			object IDContent_search_in, 
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
		/// Gets Record, based on 'byContent_andL' search. It selects vNWS_Attachment values from Database based on the 'byContent_andL' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Attachment[] getRecord_byContent_andL(
			object IDContent_search_in, 
			int IDLanguage_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Attachment[] _output;

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
						? "sp0_vNWS_Attachment_Record_open_byContent_andL_page_fullmode"
						: "sp0_vNWS_Attachment_Record_open_byContent_andL_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byContent_andL(...);
		/// <summary>
		/// It selects vNWS_Attachment values from Database based on the 'byContent_andL' search and checks to see if vNWS_Attachment Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDAttachment_in">vNWS_Attachment's IDAttachment Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Attachment's IDLanguage Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>True if vNWS_Attachment Keys are met in the 'byContent_andL' search, False if not</returns>
		public static bool isObject_inRecord_byContent_andL(
			long IDAttachment_in, 
			int IDLanguage_in, 
			object IDContent_search_in, 
			int IDLanguage_search_in
		) {
			return isObject_inRecord_byContent_andL(
				IDAttachment_in, 
				IDLanguage_in, IDContent_search_in, IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Attachment values from Database based on the 'byContent_andL' search and checks to see if vNWS_Attachment Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDAttachment_in">vNWS_Attachment's IDAttachment Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Attachment's IDLanguage Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Attachment Keys are met in the 'byContent_andL' search, False if not</returns>
		public static bool isObject_inRecord_byContent_andL(
			long IDAttachment_in, 
			int IDLanguage_in, 
			object IDContent_search_in, 
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
				_connection.newDBDataParameter("IDAttachment_", DbType.Int64, ParameterDirection.Input, IDAttachment_in, 0), 
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Attachment_Record_hasObject_byContent_andL", 
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
		/// Count's number of search results from vNWS_Attachment at Database based on the 'byContent_andL' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>number of existing Records for the 'byContent_andL' search</returns>
		public static long getCount_inRecord_byContent_andL(
			object IDContent_search_in, 
			int IDLanguage_search_in
		) {
			return getCount_inRecord_byContent_andL(
				IDContent_search_in, 
				IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNWS_Attachment at Database based on the 'byContent_andL' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byContent_andL' search</returns>
		public static long getCount_inRecord_byContent_andL(
			object IDContent_search_in, 
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
				"fnc0_vNWS_Attachment_Record_count_byContent_andL", 
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