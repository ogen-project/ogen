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
	/// NWS_ContentHighlight DataObject which provides access to NWS_ContentHighlight's Database table.
	/// </summary>
	[DOClassAttribute("NWS_ContentHighlight", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_NWS_ContentHighlight 
#else
			DO_NWS_ContentHighlight 
#endif
	{

	 	#region Methods...
		#region public static SO_NWS_ContentHighlight getObject(...);
		/// <summary>
		/// Selects NWS_ContentHighlight values from Database and assigns them to the appropriate DO0_NWS_ContentHighlight property.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFHighlight_in">IFHighlight</param>
		/// <returns>null if NWS_ContentHighlight doesn't exists at Database</returns>
		public static SO_NWS_ContentHighlight getObject(
			long IFContent_in, 
			long IFHighlight_in
		) {
			return getObject(
				IFContent_in, 
				IFHighlight_in, 
				null
			);
		}

		/// <summary>
		/// Selects NWS_ContentHighlight values from Database and assigns them to the appropriate DO_NWS_ContentHighlight property.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFHighlight_in">IFHighlight</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NWS_ContentHighlight doesn't exists at Database</returns>
		public static SO_NWS_ContentHighlight getObject(
			long IFContent_in, 
			long IFHighlight_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_ContentHighlight _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.InputOutput, IFContent_in, 0), 
				_connection.newDBDataParameter("IFHighlight_", DbType.Int64, ParameterDirection.InputOutput, IFHighlight_in, 0), 
				_connection.newDBDataParameter("Begin_date_", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("End_date_", DbType.DateTime, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_ContentHighlight_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NWS_ContentHighlight();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFContent = 0L;
				} else {
					_output.IFContent = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFHighlight = 0L;
				} else {
					_output.IFHighlight = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.Begin_date_isNull = true;
				} else {
					_output.Begin_date = (DateTime)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.End_date_isNull = true;
				} else {
					_output.End_date = (DateTime)_dataparameters[3].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NWS_ContentHighlight from Database.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFHighlight_in">IFHighlight</param>
		public static void delObject(
			long IFContent_in, 
			long IFHighlight_in
		) {
			delObject(
				IFContent_in, 
				IFHighlight_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_ContentHighlight from Database.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFHighlight_in">IFHighlight</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFContent_in, 
			long IFHighlight_in, 
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.Input, IFContent_in, 0), 
				_connection.newDBDataParameter("IFHighlight_", DbType.Int64, ParameterDirection.Input, IFHighlight_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_ContentHighlight_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NWS_ContentHighlight exists at Database
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFHighlight_in">IFHighlight</param>
		/// <returns>True if NWS_ContentHighlight exists at Database, False if not</returns>
		public static bool isObject(
			long IFContent_in, 
			long IFHighlight_in
		) {
			return isObject(
				IFContent_in, 
				IFHighlight_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NWS_ContentHighlight exists at Database
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFHighlight_in">IFHighlight</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_ContentHighlight exists at Database, False if not</returns>
		public static bool isObject(
			long IFContent_in, 
			long IFHighlight_in, 
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
				_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.Input, IFContent_in, 0), 
				_connection.newDBDataParameter("IFHighlight_", DbType.Int64, ParameterDirection.Input, IFHighlight_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentHighlight_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static bool setObject(...);
		/// <summary>
		/// Inserts/Updates NWS_ContentHighlight values into/on Database. Inserts if NWS_ContentHighlight doesn't exist or Updates if NWS_ContentHighlight already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NWS_ContentHighlight NWS_ContentHighlight_in, 
			bool forceUpdate_in
		) {
			return setObject(
				NWS_ContentHighlight_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates NWS_ContentHighlight values into/on Database. Inserts if NWS_ContentHighlight doesn't exist or Updates if NWS_ContentHighlight already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NWS_ContentHighlight NWS_ContentHighlight_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || NWS_ContentHighlight_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.Input, NWS_ContentHighlight_in.IFContent, 0), 
					_connection.newDBDataParameter("IFHighlight_", DbType.Int64, ParameterDirection.Input, NWS_ContentHighlight_in.IFHighlight, 0), 
					_connection.newDBDataParameter("Begin_date_", DbType.DateTime, ParameterDirection.Input, NWS_ContentHighlight_in.Begin_date_isNull ? null : (object)NWS_ContentHighlight_in.Begin_date, 0), 
					_connection.newDBDataParameter("End_date_", DbType.DateTime, ParameterDirection.Input, NWS_ContentHighlight_in.End_date_isNull ? null : (object)NWS_ContentHighlight_in.End_date, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NWS_ContentHighlight_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[4].Value & 2) == 1);
				if (!ConstraintExist_out) {
					NWS_ContentHighlight_in.haschanges_ = false;
				}

				return (((int)_dataparameters[4].Value & 1) != 1);
			} else {
				ConstraintExist_out = false;

				return  false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_NWS_ContentHighlight[] getRecord(DataTable dataTable_in);
		private static SO_NWS_ContentHighlight[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifcontent = null;
			DataColumn _dc_ifhighlight = null;
			DataColumn _dc_begin_date = null;
			DataColumn _dc_end_date = null;

			SO_NWS_ContentHighlight[] _output 
				= new SO_NWS_ContentHighlight[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifcontent = dataTable_in.Columns["IFContent"];
					_dc_ifhighlight = dataTable_in.Columns["IFHighlight"];
					_dc_begin_date = dataTable_in.Columns["Begin_date"];
					_dc_end_date = dataTable_in.Columns["End_date"];
				}

				_output[r] = new SO_NWS_ContentHighlight();
				if (dataTable_in.Rows[r][_dc_ifcontent] == System.DBNull.Value) {
					_output[r].ifcontent_ = 0L;
				} else {
					_output[r].ifcontent_ = (long)dataTable_in.Rows[r][_dc_ifcontent];
				}
				if (dataTable_in.Rows[r][_dc_ifhighlight] == System.DBNull.Value) {
					_output[r].ifhighlight_ = 0L;
				} else {
					_output[r].ifhighlight_ = (long)dataTable_in.Rows[r][_dc_ifhighlight];
				}
				if (dataTable_in.Rows[r][_dc_begin_date] == System.DBNull.Value) {
					_output[r].Begin_date_isNull = true;
				} else {
					_output[r].begin_date_ = (DateTime)dataTable_in.Rows[r][_dc_begin_date];
				}
				if (dataTable_in.Rows[r][_dc_end_date] == System.DBNull.Value) {
					_output[r].End_date_isNull = true;
				} else {
					_output[r].end_date_ = (DateTime)dataTable_in.Rows[r][_dc_end_date];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byContent...
		#region public static SO_NWS_ContentHighlight[] getRecord_byContent(...);
		/// <summary>
		/// Gets Record, based on 'byContent' search. It selects NWS_ContentHighlight values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_NWS_ContentHighlight[] getRecord_byContent(
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
		/// Gets Record, based on 'byContent' search. It selects NWS_ContentHighlight values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NWS_ContentHighlight[] getRecord_byContent(
			long IDContent_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_ContentHighlight[] _output;

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
						? "sp0_NWS_ContentHighlight_Record_open_byContent_page_fullmode"
						: "sp0_NWS_ContentHighlight_Record_open_byContent_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byContent(...);
		/// <summary>
		/// It selects NWS_ContentHighlight values from Database based on the 'byContent' search and checks to see if NWS_ContentHighlight Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentHighlight's IFContent Key used for checking</param>
		/// <param name="IFHighlight_in">NWS_ContentHighlight's IFHighlight Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <returns>True if NWS_ContentHighlight Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IFContent_in, 
			long IFHighlight_in, 
			long IDContent_search_in
		) {
			return isObject_inRecord_byContent(
				IFContent_in, 
				IFHighlight_in, IDContent_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NWS_ContentHighlight values from Database based on the 'byContent' search and checks to see if NWS_ContentHighlight Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentHighlight's IFContent Key used for checking</param>
		/// <param name="IFHighlight_in">NWS_ContentHighlight's IFHighlight Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_ContentHighlight Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IFContent_in, 
			long IFHighlight_in, 
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
				_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.Input, IFContent_in, 0), 
				_connection.newDBDataParameter("IFHighlight_", DbType.Int64, ParameterDirection.Input, IFHighlight_in, 0), 
				_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentHighlight_Record_hasObject_byContent", 
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
		/// Count's number of search results from NWS_ContentHighlight at Database based on the 'byContent' search.
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
		/// Count's number of search results from NWS_ContentHighlight at Database based on the 'byContent' search.
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
				"fnc0_NWS_ContentHighlight_Record_count_byContent", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_byContent(...);
		/// <summary>
		/// Deletes NWS_ContentHighlight values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		public static void delRecord_byContent(
			long IDContent_search_in
		) {
			delRecord_byContent(
				IDContent_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_ContentHighlight values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_byContent(
			long IDContent_search_in, 
			DBConnection dbConnection_in
		) {
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
			_connection.Execute_SQLFunction(
				"sp0_NWS_ContentHighlight_Record_delete_byContent", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#region ???_byHighlight...
		#region public static SO_NWS_ContentHighlight[] getRecord_byHighlight(...);
		/// <summary>
		/// Gets Record, based on 'byHighlight' search. It selects NWS_ContentHighlight values from Database based on the 'byHighlight' search.
		/// </summary>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_NWS_ContentHighlight[] getRecord_byHighlight(
			long IDHighlight_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byHighlight(
				IDHighlight_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byHighlight' search. It selects NWS_ContentHighlight values from Database based on the 'byHighlight' search.
		/// </summary>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NWS_ContentHighlight[] getRecord_byHighlight(
			long IDHighlight_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_ContentHighlight[] _output;

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
						_connection.newDBDataParameter("IDHighlight_search_", DbType.Int64, ParameterDirection.Input, IDHighlight_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDHighlight_search_", DbType.Int64, ParameterDirection.Input, IDHighlight_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_NWS_ContentHighlight_Record_open_byHighlight_page_fullmode"
						: "sp0_NWS_ContentHighlight_Record_open_byHighlight_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byHighlight(...);
		/// <summary>
		/// It selects NWS_ContentHighlight values from Database based on the 'byHighlight' search and checks to see if NWS_ContentHighlight Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentHighlight's IFContent Key used for checking</param>
		/// <param name="IFHighlight_in">NWS_ContentHighlight's IFHighlight Key used for checking</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <returns>True if NWS_ContentHighlight Keys are met in the 'byHighlight' search, False if not</returns>
		public static bool isObject_inRecord_byHighlight(
			long IFContent_in, 
			long IFHighlight_in, 
			long IDHighlight_search_in
		) {
			return isObject_inRecord_byHighlight(
				IFContent_in, 
				IFHighlight_in, IDHighlight_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NWS_ContentHighlight values from Database based on the 'byHighlight' search and checks to see if NWS_ContentHighlight Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentHighlight's IFContent Key used for checking</param>
		/// <param name="IFHighlight_in">NWS_ContentHighlight's IFHighlight Key used for checking</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_ContentHighlight Keys are met in the 'byHighlight' search, False if not</returns>
		public static bool isObject_inRecord_byHighlight(
			long IFContent_in, 
			long IFHighlight_in, 
			long IDHighlight_search_in, 
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
				_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.Input, IFContent_in, 0), 
				_connection.newDBDataParameter("IFHighlight_", DbType.Int64, ParameterDirection.Input, IFHighlight_in, 0), 
				_connection.newDBDataParameter("IDHighlight_search_", DbType.Int64, ParameterDirection.Input, IDHighlight_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentHighlight_Record_hasObject_byHighlight", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byHighlight(...);
		/// <summary>
		/// Count's number of search results from NWS_ContentHighlight at Database based on the 'byHighlight' search.
		/// </summary>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <returns>number of existing Records for the 'byHighlight' search</returns>
		public static long getCount_inRecord_byHighlight(
			long IDHighlight_search_in
		) {
			return getCount_inRecord_byHighlight(
				IDHighlight_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from NWS_ContentHighlight at Database based on the 'byHighlight' search.
		/// </summary>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byHighlight' search</returns>
		public static long getCount_inRecord_byHighlight(
			long IDHighlight_search_in, 
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
				_connection.newDBDataParameter("IDHighlight_search_", DbType.Int64, ParameterDirection.Input, IDHighlight_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentHighlight_Record_count_byHighlight", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_byHighlight(...);
		/// <summary>
		/// Deletes NWS_ContentHighlight values from Database based on the 'byHighlight' search.
		/// </summary>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		public static void delRecord_byHighlight(
			long IDHighlight_search_in
		) {
			delRecord_byHighlight(
				IDHighlight_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_ContentHighlight values from Database based on the 'byHighlight' search.
		/// </summary>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_byHighlight(
			long IDHighlight_search_in, 
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDHighlight_search_", DbType.Int64, ParameterDirection.Input, IDHighlight_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NWS_ContentHighlight_Record_delete_byHighlight", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}