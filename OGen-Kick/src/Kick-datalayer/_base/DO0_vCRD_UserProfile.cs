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
	/// vCRD_UserProfile DataObject which provides access to vCRD_UserProfile's Database table.
	/// </summary>
	[DOClassAttribute("vCRD_UserProfile", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vCRD_UserProfile 
#else
			DO_vCRD_UserProfile 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_vCRD_UserProfile[] getRecord(DataTable dataTable_in);
		private static SO_vCRD_UserProfile[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idprofile = null;
			DataColumn _dc_profilename = null;
			DataColumn _dc_iduser = null;
			DataColumn _dc_hasprofile = null;

			SO_vCRD_UserProfile[] _output 
				= new SO_vCRD_UserProfile[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idprofile = dataTable_in.Columns["IDProfile"];
					_dc_profilename = dataTable_in.Columns["ProfileName"];
					_dc_iduser = dataTable_in.Columns["IDUser"];
					_dc_hasprofile = dataTable_in.Columns["hasProfile"];
				}

				_output[r] = new SO_vCRD_UserProfile();
				if (dataTable_in.Rows[r][_dc_idprofile] == System.DBNull.Value) {
					_output[r].idprofile_ = 0L;
				} else {
					_output[r].idprofile_ = (long)dataTable_in.Rows[r][_dc_idprofile];
				}
				if (dataTable_in.Rows[r][_dc_profilename] == System.DBNull.Value) {
					_output[r].ProfileName_isNull = true;
				} else {
					_output[r].profilename_ = (string)dataTable_in.Rows[r][_dc_profilename];
				}
				if (dataTable_in.Rows[r][_dc_iduser] == System.DBNull.Value) {
					_output[r].iduser_ = 0L;
				} else {
					_output[r].iduser_ = (long)dataTable_in.Rows[r][_dc_iduser];
				}
				if (dataTable_in.Rows[r][_dc_hasprofile] == System.DBNull.Value) {
					_output[r].hasProfile_isNull = true;
				} else {
					_output[r].hasprofile_ = (bool)dataTable_in.Rows[r][_dc_hasprofile];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byUser...
		#region public static SO_vCRD_UserProfile[] getRecord_byUser(...);
		/// <summary>
		/// Gets Record, based on 'byUser' search. It selects vCRD_UserProfile values from Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vCRD_UserProfile[] getRecord_byUser(
			long IDUser_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byUser(
				IDUser_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byUser' search. It selects vCRD_UserProfile values from Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vCRD_UserProfile[] getRecord_byUser(
			long IDUser_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vCRD_UserProfile[] _output;

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
						? "sp0_vCRD_UserProfile_Record_open_byUser_page_fullmode"
						: "sp0_vCRD_UserProfile_Record_open_byUser_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byUser(...);
		/// <summary>
		/// It selects vCRD_UserProfile values from Database based on the 'byUser' search and checks to see if vCRD_UserProfile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDProfile_in">vCRD_UserProfile's IDProfile Key used for checking</param>
		/// <param name="IDUser_in">vCRD_UserProfile's IDUser Key used for checking</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <returns>True if vCRD_UserProfile Keys are met in the 'byUser' search, False if not</returns>
		public static bool isObject_inRecord_byUser(
			long IDProfile_in, 
			long IDUser_in, 
			long IDUser_search_in
		) {
			return isObject_inRecord_byUser(
				IDProfile_in, 
				IDUser_in, IDUser_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vCRD_UserProfile values from Database based on the 'byUser' search and checks to see if vCRD_UserProfile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDProfile_in">vCRD_UserProfile's IDProfile Key used for checking</param>
		/// <param name="IDUser_in">vCRD_UserProfile's IDUser Key used for checking</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vCRD_UserProfile Keys are met in the 'byUser' search, False if not</returns>
		public static bool isObject_inRecord_byUser(
			long IDProfile_in, 
			long IDUser_in, 
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
				_connection.newDBDataParameter("IDProfile_", DbType.Int64, ParameterDirection.Input, IDProfile_in, 0), 
				_connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, IDUser_in, 0), 
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vCRD_UserProfile_Record_hasObject_byUser", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byUser(...);
		/// <summary>
		/// Count's number of search results from vCRD_UserProfile at Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <returns>number of existing Records for the 'byUser' search</returns>
		public static long getCount_inRecord_byUser(
			long IDUser_search_in
		) {
			return getCount_inRecord_byUser(
				IDUser_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vCRD_UserProfile at Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byUser' search</returns>
		public static long getCount_inRecord_byUser(
			long IDUser_search_in, 
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
				"fnc0_vCRD_UserProfile_Record_count_byUser", 
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