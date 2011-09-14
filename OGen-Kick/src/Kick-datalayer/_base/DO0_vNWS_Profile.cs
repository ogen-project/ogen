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
	/// vNWS_Profile DataObject which provides access to vNWS_Profile's Database table.
	/// </summary>
	[DOClassAttribute("vNWS_Profile", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_vNWS_Profile 
#else
			DO_vNWS_Profile 
#endif
	{

	 	#region Methods...
		#endregion
		#region Methods - Object Searches...
		#region ???Object_byProfile...
		#region public static SO_vNWS_Profile getObject_byProfile(...);
		/// <summary>
		/// Selects vNWS_Profile values from Database (based on the search condition) and assigns them to the appropriate DO0_vNWS_Profile property.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <returns>null if vNWS_Profile doesn't exists at Database</returns>
		public static SO_vNWS_Profile getObject_byProfile(
			long IDProfile_search_in
		) {
			return getObject_byProfile(
				IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// Selects vNWS_Profile values from Database (based on the search condition) and assigns them to the appropriate DO0_vNWS_Profile property.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if vNWS_Profile doesn't exists at Database</returns>
		public static SO_vNWS_Profile getObject_byProfile(
			long IDProfile_search_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Profile _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0), 
				_connection.newDBDataParameter("IDProfile", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("IDApplication", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser__Approved", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Approved_date", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("ManagerName", DbType.AnsiString, ParameterDirection.Output, null, 255)
			};
			_connection.Execute_SQLFunction(
				"sp0_vNWS_Profile_getObject_byProfile", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[1].Value != DBNull.Value) {
				_output = new SO_vNWS_Profile();
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IDProfile = 0L;
				} else {
					_output.IDProfile = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.Name_isNull = true;
				} else {
					_output.Name = (string)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.IDApplication_isNull = true;
				} else {
					_output.IDApplication = (int)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.IFUser__Approved_isNull = true;
				} else {
					_output.IFUser__Approved = (long)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.Approved_date_isNull = true;
				} else {
					_output.Approved_date = (DateTime)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.ManagerName_isNull = true;
				} else {
					_output.ManagerName = (string)_dataparameters[6].Value;
				}

				return _output;
			}

			return null;
		}
		#endregion
		#region public static bool isObject_byProfile(...);
		/// <summary>
		/// Checks to see if vNWS_Profile exists at Database (based on the search condition).
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <returns>True if vNWS_Profile exists at Database, False if not</returns>
		public static bool isObject_byProfile(
			long IDProfile_search_in
		) {
			return isObject_byProfile(
				IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if vNWS_Profile exists at Database (based on the search condition).
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Profile exists at Database, False if not</returns>
		public static bool isObject_byProfile(
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
				_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_vNWS_Profile_isObject_byProfile", 
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
		#region private static SO_vNWS_Profile[] getRecord(DataTable dataTable_in);
		private static SO_vNWS_Profile[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idprofile = null;
			DataColumn _dc_name = null;
			DataColumn _dc_idapplication = null;
			DataColumn _dc_ifuser__approved = null;
			DataColumn _dc_approved_date = null;
			DataColumn _dc_managername = null;

			SO_vNWS_Profile[] _output 
				= new SO_vNWS_Profile[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idprofile = dataTable_in.Columns["IDProfile"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_idapplication = dataTable_in.Columns["IDApplication"];
					_dc_ifuser__approved = dataTable_in.Columns["IFUser__Approved"];
					_dc_approved_date = dataTable_in.Columns["Approved_date"];
					_dc_managername = dataTable_in.Columns["ManagerName"];
				}

				_output[r] = new SO_vNWS_Profile();
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
				if (dataTable_in.Rows[r][_dc_idapplication] == System.DBNull.Value) {
					_output[r].IDApplication_isNull = true;
				} else {
					_output[r].idapplication_ = (int)dataTable_in.Rows[r][_dc_idapplication];
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
				if (dataTable_in.Rows[r][_dc_managername] == System.DBNull.Value) {
					_output[r].ManagerName_isNull = true;
				} else {
					_output[r].managername_ = (string)dataTable_in.Rows[r][_dc_managername];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_all...
		#region public static SO_vNWS_Profile[] getRecord_all(...);
		/// <summary>
		/// Gets Record, based on 'all' search. It selects vNWS_Profile values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Profile[] getRecord_all(
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
		/// Gets Record, based on 'all' search. It selects vNWS_Profile values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Profile[] getRecord_all(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Profile[] _output;

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
						? "sp0_vNWS_Profile_Record_open_all_page_fullmode"
						: "sp0_vNWS_Profile_Record_open_all_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_all(...);
		/// <summary>
		/// It selects vNWS_Profile values from Database based on the 'all' search and checks to see if vNWS_Profile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDProfile_in">vNWS_Profile's IDProfile Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if vNWS_Profile Keys are met in the 'all' search, False if not</returns>
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
		/// It selects vNWS_Profile values from Database based on the 'all' search and checks to see if vNWS_Profile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDProfile_in">vNWS_Profile's IDProfile Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Profile Keys are met in the 'all' search, False if not</returns>
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
				"fnc0_vNWS_Profile_Record_hasObject_all", 
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
		/// Count's number of search results from vNWS_Profile at Database based on the 'all' search.
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
		/// Count's number of search results from vNWS_Profile at Database based on the 'all' search.
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
				"fnc0_vNWS_Profile_Record_count_all", 
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
		#region public static SO_vNWS_Profile[] getRecord_Approved(...);
		/// <summary>
		/// Gets Record, based on 'Approved' search. It selects vNWS_Profile values from Database based on the 'Approved' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_vNWS_Profile[] getRecord_Approved(
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
		/// Gets Record, based on 'Approved' search. It selects vNWS_Profile values from Database based on the 'Approved' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_vNWS_Profile[] getRecord_Approved(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_vNWS_Profile[] _output;

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
						? "sp0_vNWS_Profile_Record_open_Approved_page_fullmode"
						: "sp0_vNWS_Profile_Record_open_Approved_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_Approved(...);
		/// <summary>
		/// It selects vNWS_Profile values from Database based on the 'Approved' search and checks to see if vNWS_Profile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDProfile_in">vNWS_Profile's IDProfile Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if vNWS_Profile Keys are met in the 'Approved' search, False if not</returns>
		public static bool isObject_inRecord_Approved(
			long IDProfile_in, 
			object IDApplication_search_in
		) {
			return isObject_inRecord_Approved(
				IDProfile_in, IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects vNWS_Profile values from Database based on the 'Approved' search and checks to see if vNWS_Profile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDProfile_in">vNWS_Profile's IDProfile Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if vNWS_Profile Keys are met in the 'Approved' search, False if not</returns>
		public static bool isObject_inRecord_Approved(
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
				"fnc0_vNWS_Profile_Record_hasObject_Approved", 
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
		/// Count's number of search results from vNWS_Profile at Database based on the 'Approved' search.
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
		/// Count's number of search results from vNWS_Profile at Database based on the 'Approved' search.
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
				"fnc0_vNWS_Profile_Record_count_Approved", 
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