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
	/// vNWS_Tag DataObject which provides access to vNWS_Tag's Database table.
	/// </summary>
	[DOClassAttribute("vNWS_Tag", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vNWS_Tag 
#else
			DO_vNWS_Tag 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#region ???Object_byTag_andL...
		#region public static SO_vNWS_Tag getObject_byTag_andL(...);
		/// <summary>
		/// Selects vNWS_Tag values from Database (based on the search condition) and assigns them to the appropriate DO0_vNWS_Tag property.
		/// </summary>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>null if vNWS_Tag doesn't exists at Database</returns>
		public static SO_vNWS_Tag getObject_byTag_andL(
			long IDTag_search_in, 
			int IDLanguage_search_in
		) {
			return getObject_byTag_andL(
				IDTag_search_in, 
				IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// Selects vNWS_Tag values from Database (based on the search condition) and assigns them to the appropriate DO0_vNWS_Tag property.
		/// </summary>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if vNWS_Tag doesn't exists at Database</returns>
		public static SO_vNWS_Tag getObject_byTag_andL(
			long IDTag_search_in, 
			int IDLanguage_search_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Tag _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDTag_search_", DbType.Int64, ParameterDirection.Input, IDTag_search_in, 0), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
				_connection.newDBDataParameter("IDTag", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IDLanguage", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFTag__parent", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser__Approved", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Approved_date", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name", DbType.AnsiString, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("ManagerName", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("ShortName", DbType.AnsiString, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_vNWS_Tag_getObject_byTag_andL", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[2].Value != DBNull.Value) {
				_output = new SO_vNWS_Tag();
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IDTag = 0L;
				} else {
					_output.IDTag = (long)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.IDLanguage = 0;
				} else {
					_output.IDLanguage = (int)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.IFTag__parent_isNull = true;
				} else {
					_output.IFTag__parent = (long)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.IFUser__Approved_isNull = true;
				} else {
					_output.IFUser__Approved = (long)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.Approved_date_isNull = true;
				} else {
					_output.Approved_date = (DateTime)_dataparameters[6].Value;
				}
				if (_dataparameters[7].Value == System.DBNull.Value) {
					_output.Name_isNull = true;
				} else {
					_output.Name = (string)_dataparameters[7].Value;
				}
				if (_dataparameters[8].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[8].Value;
				}
				if (_dataparameters[9].Value == System.DBNull.Value) {
					_output.ManagerName_isNull = true;
				} else {
					_output.ManagerName = (string)_dataparameters[9].Value;
				}
				if (_dataparameters[10].Value == System.DBNull.Value) {
					_output.ShortName_isNull = true;
				} else {
					_output.ShortName = (string)_dataparameters[10].Value;
				}

				return _output;
			}

			return null;
		}
		#endregion
		#region public static bool isObject_byTag_andL(...);
		/// <summary>
		/// Checks to see if vNWS_Tag exists at Database (based on the search condition).
		/// </summary>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>True if vNWS_Tag exists at Database, False if not</returns>
		public static bool isObject_byTag_andL(
			long IDTag_search_in, 
			int IDLanguage_search_in
		) {
			return isObject_byTag_andL(
				IDTag_search_in, 
				IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if vNWS_Tag exists at Database (based on the search condition).
		/// </summary>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Tag exists at Database, False if not</returns>
		public static bool isObject_byTag_andL(
			long IDTag_search_in, 
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
				_connection.newDBDataParameter("IDTag_search_", DbType.Int64, ParameterDirection.Input, IDTag_search_in, 0), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Tag_isObject_byTag_andL", 
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
		#region private static SO_vNWS_Tag[] getRecord(DataTable dataTable_in);
		private static SO_vNWS_Tag[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idtag = null;
			DataColumn _dc_idlanguage = null;
			DataColumn _dc_iftag__parent = null;
			DataColumn _dc_ifuser__approved = null;
			DataColumn _dc_approved_date = null;
			DataColumn _dc_name = null;
			DataColumn _dc_ifapplication = null;
			DataColumn _dc_managername = null;
			DataColumn _dc_shortname = null;

			SO_vNWS_Tag[] _output 
				= new SO_vNWS_Tag[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idtag = dataTable_in.Columns["IDTag"];
					_dc_idlanguage = dataTable_in.Columns["IDLanguage"];
					_dc_iftag__parent = dataTable_in.Columns["IFTag__parent"];
					_dc_ifuser__approved = dataTable_in.Columns["IFUser__Approved"];
					_dc_approved_date = dataTable_in.Columns["Approved_date"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
					_dc_managername = dataTable_in.Columns["ManagerName"];
					_dc_shortname = dataTable_in.Columns["ShortName"];
				}

				_output[r] = new SO_vNWS_Tag();
				if (dataTable_in.Rows[r][_dc_idtag] == System.DBNull.Value) {
					_output[r].idtag_ = 0L;
				} else {
					_output[r].idtag_ = (long)dataTable_in.Rows[r][_dc_idtag];
				}
				if (dataTable_in.Rows[r][_dc_idlanguage] == System.DBNull.Value) {
					_output[r].idlanguage_ = 0;
				} else {
					_output[r].idlanguage_ = (int)dataTable_in.Rows[r][_dc_idlanguage];
				}
				if (dataTable_in.Rows[r][_dc_iftag__parent] == System.DBNull.Value) {
					_output[r].IFTag__parent_isNull = true;
				} else {
					_output[r].iftag__parent_ = (long)dataTable_in.Rows[r][_dc_iftag__parent];
				}
				if (dataTable_in.Rows[r][_dc_ifuser__approved] == System.DBNull.Value) {
					_output[r].IFUser__Approved_isNull = true;
				} else {
					_output[r].ifuser__approved_ = (long)dataTable_in.Rows[r][_dc_ifuser__approved];
				}
				if (dataTable_in.Rows[r][_dc_approved_date] == System.DBNull.Value) {
					_output[r].Approved_date_isNull = true;
				} else {
					_output[r].approved_date_ = (DateTime)dataTable_in.Rows[r][_dc_approved_date];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].Name_isNull = true;
				} else {
					_output[r].name_ = (string)dataTable_in.Rows[r][_dc_name];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication_isNull = true;
				} else {
					_output[r].ifapplication_ = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}
				if (dataTable_in.Rows[r][_dc_managername] == System.DBNull.Value) {
					_output[r].ManagerName_isNull = true;
				} else {
					_output[r].managername_ = (string)dataTable_in.Rows[r][_dc_managername];
				}
				if (dataTable_in.Rows[r][_dc_shortname] == System.DBNull.Value) {
					_output[r].ShortName_isNull = true;
				} else {
					_output[r].shortname_ = (string)dataTable_in.Rows[r][_dc_shortname];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byTag...
		#region public static SO_vNWS_Tag[] getRecord_byTag(...);
		/// <summary>
		/// Gets Record, based on 'byTag' search. It selects vNWS_Tag values from Database based on the 'byTag' search.
		/// </summary>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Tag[] getRecord_byTag(
			long IDTag_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byTag(
				IDTag_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byTag' search. It selects vNWS_Tag values from Database based on the 'byTag' search.
		/// </summary>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Tag[] getRecord_byTag(
			long IDTag_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Tag[] _output;

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
						_connection.newDBDataParameter("IDTag_search_", DbType.Int64, ParameterDirection.Input, IDTag_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDTag_search_", DbType.Int64, ParameterDirection.Input, IDTag_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vNWS_Tag_Record_open_byTag_page_fullmode"
						: "sp0_vNWS_Tag_Record_open_byTag_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byTag(...);
		/// <summary>
		/// It selects vNWS_Tag values from Database based on the 'byTag' search and checks to see if vNWS_Tag Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDTag_in">vNWS_Tag's IDTag Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Tag's IDLanguage Key used for checking</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <returns>True if vNWS_Tag Keys are met in the 'byTag' search, False if not</returns>
		public static bool isObject_inRecord_byTag(
			long IDTag_in, 
			int IDLanguage_in, 
			long IDTag_search_in
		) {
			return isObject_inRecord_byTag(
				IDTag_in, 
				IDLanguage_in, IDTag_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Tag values from Database based on the 'byTag' search and checks to see if vNWS_Tag Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDTag_in">vNWS_Tag's IDTag Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Tag's IDLanguage Key used for checking</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Tag Keys are met in the 'byTag' search, False if not</returns>
		public static bool isObject_inRecord_byTag(
			long IDTag_in, 
			int IDLanguage_in, 
			long IDTag_search_in, 
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
				_connection.newDBDataParameter("IDTag_", DbType.Int64, ParameterDirection.Input, IDTag_in, 0), 
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IDTag_search_", DbType.Int64, ParameterDirection.Input, IDTag_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Tag_Record_hasObject_byTag", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byTag(...);
		/// <summary>
		/// Count's number of search results from vNWS_Tag at Database based on the 'byTag' search.
		/// </summary>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <returns>number of existing Records for the 'byTag' search</returns>
		public static long getCount_inRecord_byTag(
			long IDTag_search_in
		) {
			return getCount_inRecord_byTag(
				IDTag_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNWS_Tag at Database based on the 'byTag' search.
		/// </summary>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byTag' search</returns>
		public static long getCount_inRecord_byTag(
			long IDTag_search_in, 
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
				_connection.newDBDataParameter("IDTag_search_", DbType.Int64, ParameterDirection.Input, IDTag_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Tag_Record_count_byTag", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???_byLang...
		#region public static SO_vNWS_Tag[] getRecord_byLang(...);
		/// <summary>
		/// Gets Record, based on 'byLang' search. It selects vNWS_Tag values from Database based on the 'byLang' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Tag[] getRecord_byLang(
			object IDApplication_search_in, 
			int IDLanguage_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byLang(
				IDApplication_search_in, 
				IDLanguage_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byLang' search. It selects vNWS_Tag values from Database based on the 'byLang' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Tag[] getRecord_byLang(
			object IDApplication_search_in, 
			int IDLanguage_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Tag[] _output;

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
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vNWS_Tag_Record_open_byLang_page_fullmode"
						: "sp0_vNWS_Tag_Record_open_byLang_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byLang(...);
		/// <summary>
		/// It selects vNWS_Tag values from Database based on the 'byLang' search and checks to see if vNWS_Tag Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDTag_in">vNWS_Tag's IDTag Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Tag's IDLanguage Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>True if vNWS_Tag Keys are met in the 'byLang' search, False if not</returns>
		public static bool isObject_inRecord_byLang(
			long IDTag_in, 
			int IDLanguage_in, 
			object IDApplication_search_in, 
			int IDLanguage_search_in
		) {
			return isObject_inRecord_byLang(
				IDTag_in, 
				IDLanguage_in, IDApplication_search_in, IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Tag values from Database based on the 'byLang' search and checks to see if vNWS_Tag Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDTag_in">vNWS_Tag's IDTag Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Tag's IDLanguage Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Tag Keys are met in the 'byLang' search, False if not</returns>
		public static bool isObject_inRecord_byLang(
			long IDTag_in, 
			int IDLanguage_in, 
			object IDApplication_search_in, 
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
				_connection.newDBDataParameter("IDTag_", DbType.Int64, ParameterDirection.Input, IDTag_in, 0), 
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Tag_Record_hasObject_byLang", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byLang(...);
		/// <summary>
		/// Count's number of search results from vNWS_Tag at Database based on the 'byLang' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>number of existing Records for the 'byLang' search</returns>
		public static long getCount_inRecord_byLang(
			object IDApplication_search_in, 
			int IDLanguage_search_in
		) {
			return getCount_inRecord_byLang(
				IDApplication_search_in, 
				IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNWS_Tag at Database based on the 'byLang' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byLang' search</returns>
		public static long getCount_inRecord_byLang(
			object IDApplication_search_in, 
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
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Tag_Record_count_byLang", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion
		#region ???_Approved_byLang...
		#region public static SO_vNWS_Tag[] getRecord_Approved_byLang(...);
		/// <summary>
		/// Gets Record, based on 'Approved_byLang' search. It selects vNWS_Tag values from Database based on the 'Approved_byLang' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Tag[] getRecord_Approved_byLang(
			object IDApplication_search_in, 
			int IDLanguage_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_Approved_byLang(
				IDApplication_search_in, 
				IDLanguage_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'Approved_byLang' search. It selects vNWS_Tag values from Database based on the 'Approved_byLang' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Tag[] getRecord_Approved_byLang(
			object IDApplication_search_in, 
			int IDLanguage_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Tag[] _output;

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
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vNWS_Tag_Record_open_Approved_byLang_page_fullmode"
						: "sp0_vNWS_Tag_Record_open_Approved_byLang_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_Approved_byLang(...);
		/// <summary>
		/// It selects vNWS_Tag values from Database based on the 'Approved_byLang' search and checks to see if vNWS_Tag Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDTag_in">vNWS_Tag's IDTag Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Tag's IDLanguage Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>True if vNWS_Tag Keys are met in the 'Approved_byLang' search, False if not</returns>
		public static bool isObject_inRecord_Approved_byLang(
			long IDTag_in, 
			int IDLanguage_in, 
			object IDApplication_search_in, 
			int IDLanguage_search_in
		) {
			return isObject_inRecord_Approved_byLang(
				IDTag_in, 
				IDLanguage_in, IDApplication_search_in, IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Tag values from Database based on the 'Approved_byLang' search and checks to see if vNWS_Tag Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDTag_in">vNWS_Tag's IDTag Key used for checking</param>
		/// <param name="IDLanguage_in">vNWS_Tag's IDLanguage Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Tag Keys are met in the 'Approved_byLang' search, False if not</returns>
		public static bool isObject_inRecord_Approved_byLang(
			long IDTag_in, 
			int IDLanguage_in, 
			object IDApplication_search_in, 
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
				_connection.newDBDataParameter("IDTag_", DbType.Int64, ParameterDirection.Input, IDTag_in, 0), 
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Tag_Record_hasObject_Approved_byLang", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_Approved_byLang(...);
		/// <summary>
		/// Count's number of search results from vNWS_Tag at Database based on the 'Approved_byLang' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <returns>number of existing Records for the 'Approved_byLang' search</returns>
		public static long getCount_inRecord_Approved_byLang(
			object IDApplication_search_in, 
			int IDLanguage_search_in
		) {
			return getCount_inRecord_Approved_byLang(
				IDApplication_search_in, 
				IDLanguage_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vNWS_Tag at Database based on the 'Approved_byLang' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'Approved_byLang' search</returns>
		public static long getCount_inRecord_Approved_byLang(
			object IDApplication_search_in, 
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
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Tag_Record_count_Approved_byLang", 
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