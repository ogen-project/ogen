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
	/// vNET_Profile DataObject which provides access to vNET_Profile's Database table.
	/// </summary>
	[DOClassAttribute("vNET_Profile", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vNET_Profile 
#else
			DO_vNET_Profile 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_vNET_Profile[] getRecord(DataTable dataTable_in);
		private static SO_vNET_Profile[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idprofile = null;
			DataColumn _dc_name = null;
			DataColumn _dc_ifapplication = null;
			DataColumn _dc_isdefaultprofile = null;

			SO_vNET_Profile[] _output 
				= new SO_vNET_Profile[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idprofile = dataTable_in.Columns["IDProfile"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
					_dc_isdefaultprofile = dataTable_in.Columns["isDefaultprofile"];
				}

				_output[r] = new SO_vNET_Profile();
				if (dataTable_in.Rows[r][_dc_idprofile] == System.DBNull.Value) {
					_output[r].idprofile_ = 0L;
				} else {
					_output[r].idprofile_ = (long)dataTable_in.Rows[r][_dc_idprofile];
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
				if (dataTable_in.Rows[r][_dc_isdefaultprofile] == System.DBNull.Value) {
					_output[r].isDefaultprofile_isNull = true;
				} else {
					_output[r].isdefaultprofile_ = (bool)dataTable_in.Rows[r][_dc_isdefaultprofile];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_all...
		#region public static SO_vNET_Profile[] getRecord_all(...);
		/// <summary>
		/// Gets Record, based on 'all' search. It selects vNET_Profile values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNET_Profile[] getRecord_all(
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
		/// Gets Record, based on 'all' search. It selects vNET_Profile values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNET_Profile[] getRecord_all(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNET_Profile[] _output;

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
						? "sp0_vNET_Profile_Record_open_all_page_fullmode"
						: "sp0_vNET_Profile_Record_open_all_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_all(...);
		/// <summary>
		/// It selects vNET_Profile values from Database based on the 'all' search and checks to see if vNET_Profile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDProfile_in">vNET_Profile's IDProfile Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if vNET_Profile Keys are met in the 'all' search, False if not</returns>
		public static bool isObject_inRecord_all(
			long IDProfile_in, 
			object IDApplication_search_in
		) {
			return isObject_inRecord_all(
				IDProfile_in, IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNET_Profile values from Database based on the 'all' search and checks to see if vNET_Profile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDProfile_in">vNET_Profile's IDProfile Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNET_Profile Keys are met in the 'all' search, False if not</returns>
		public static bool isObject_inRecord_all(
			long IDProfile_in, 
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
				_connection.newDBDataParameter("IDProfile_", DbType.Int64, ParameterDirection.Input, IDProfile_in, 0), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNET_Profile_Record_hasObject_all", 
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
		/// Count's number of search results from vNET_Profile at Database based on the 'all' search.
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
		/// Count's number of search results from vNET_Profile at Database based on the 'all' search.
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
				"fnc0_vNET_Profile_Record_count_all", 
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