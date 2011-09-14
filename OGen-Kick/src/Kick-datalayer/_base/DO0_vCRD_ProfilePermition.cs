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
	/// vCRD_ProfilePermition DataObject which provides access to vCRD_ProfilePermition's Database table.
	/// </summary>
	[DOClassAttribute("vCRD_ProfilePermition", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vCRD_ProfilePermition 
#else
			DO_vCRD_ProfilePermition 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_vCRD_ProfilePermition[] getRecord(DataTable dataTable_in);
		private static SO_vCRD_ProfilePermition[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idpermition = null;
			DataColumn _dc_permitionname = null;
			DataColumn _dc_idprofile = null;
			DataColumn _dc_haspermition = null;

			SO_vCRD_ProfilePermition[] _output 
				= new SO_vCRD_ProfilePermition[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idpermition = dataTable_in.Columns["IDPermition"];
					_dc_permitionname = dataTable_in.Columns["PermitionName"];
					_dc_idprofile = dataTable_in.Columns["IDProfile"];
					_dc_haspermition = dataTable_in.Columns["hasPermition"];
				}

				_output[r] = new SO_vCRD_ProfilePermition();
				if (dataTable_in.Rows[r][_dc_idpermition] == System.DBNull.Value) {
					_output[r].idpermition_ = 0L;
				} else {
					_output[r].idpermition_ = (long)dataTable_in.Rows[r][_dc_idpermition];
				}
				if (dataTable_in.Rows[r][_dc_permitionname] == System.DBNull.Value) {
					_output[r].PermitionName_isNull = true;
				} else {
					_output[r].permitionname_ = (string)dataTable_in.Rows[r][_dc_permitionname];
				}
				if (dataTable_in.Rows[r][_dc_idprofile] == System.DBNull.Value) {
					_output[r].idprofile_ = 0L;
				} else {
					_output[r].idprofile_ = (long)dataTable_in.Rows[r][_dc_idprofile];
				}
				if (dataTable_in.Rows[r][_dc_haspermition] == System.DBNull.Value) {
					_output[r].hasPermition_isNull = true;
				} else {
					_output[r].haspermition_ = (bool)dataTable_in.Rows[r][_dc_haspermition];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byProfile...
		#region public static SO_vCRD_ProfilePermition[] getRecord_byProfile(...);
		/// <summary>
		/// Gets Record, based on 'byProfile' search. It selects vCRD_ProfilePermition values from Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vCRD_ProfilePermition[] getRecord_byProfile(
			long IDProfile_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byProfile(
				IDProfile_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byProfile' search. It selects vCRD_ProfilePermition values from Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vCRD_ProfilePermition[] getRecord_byProfile(
			long IDProfile_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vCRD_ProfilePermition[] _output;

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
						_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_vCRD_ProfilePermition_Record_open_byProfile_page_fullmode"
						: "sp0_vCRD_ProfilePermition_Record_open_byProfile_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byProfile(...);
		/// <summary>
		/// It selects vCRD_ProfilePermition values from Database based on the 'byProfile' search and checks to see if vCRD_ProfilePermition Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDPermition_in">vCRD_ProfilePermition's IDPermition Key used for checking</param>
		/// <param name="IDProfile_in">vCRD_ProfilePermition's IDProfile Key used for checking</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <returns>True if vCRD_ProfilePermition Keys are met in the 'byProfile' search, False if not</returns>
		public static bool isObject_inRecord_byProfile(
			long IDPermition_in, 
			long IDProfile_in, 
			long IDProfile_search_in
		) {
			return isObject_inRecord_byProfile(
				IDPermition_in, 
				IDProfile_in, IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vCRD_ProfilePermition values from Database based on the 'byProfile' search and checks to see if vCRD_ProfilePermition Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDPermition_in">vCRD_ProfilePermition's IDPermition Key used for checking</param>
		/// <param name="IDProfile_in">vCRD_ProfilePermition's IDProfile Key used for checking</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vCRD_ProfilePermition Keys are met in the 'byProfile' search, False if not</returns>
		public static bool isObject_inRecord_byProfile(
			long IDPermition_in, 
			long IDProfile_in, 
			long IDProfile_search_in, 
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
				_connection.newDBDataParameter("IDPermition_", DbType.Int64, ParameterDirection.Input, IDPermition_in, 0), 
				_connection.newDBDataParameter("IDProfile_", DbType.Int64, ParameterDirection.Input, IDProfile_in, 0), 
				_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vCRD_ProfilePermition_Record_hasObject_byProfile", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byProfile(...);
		/// <summary>
		/// Count's number of search results from vCRD_ProfilePermition at Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <returns>number of existing Records for the 'byProfile' search</returns>
		public static long getCount_inRecord_byProfile(
			long IDProfile_search_in
		) {
			return getCount_inRecord_byProfile(
				IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from vCRD_ProfilePermition at Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byProfile' search</returns>
		public static long getCount_inRecord_byProfile(
			long IDProfile_search_in, 
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
				_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_vCRD_ProfilePermition_Record_count_byProfile", 
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