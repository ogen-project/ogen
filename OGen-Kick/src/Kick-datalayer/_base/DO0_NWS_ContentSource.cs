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
	/// NWS_ContentSource DataObject which provides access to NWS_ContentSource's Database table.
	/// </summary>
	[DOClassAttribute("NWS_ContentSource", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_NWS_ContentSource 
#else
			DO_NWS_ContentSource 
#endif
	{

	 	#region Methods...
		#region public static SO_NWS_ContentSource getObject(...);
		/// <summary>
		/// Selects NWS_ContentSource values from Database and assigns them to the appropriate DO0_NWS_ContentSource property.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFSource_in">IFSource</param>
		/// <returns>null if NWS_ContentSource doesn't exists at Database</returns>
		public static SO_NWS_ContentSource getObject(
			long IFContent_in, 
			long IFSource_in
		) {
			return getObject(
				IFContent_in, 
				IFSource_in, 
				null
			);
		}

		/// <summary>
		/// Selects NWS_ContentSource values from Database and assigns them to the appropriate DO_NWS_ContentSource property.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFSource_in">IFSource</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NWS_ContentSource doesn't exists at Database</returns>
		public static SO_NWS_ContentSource getObject(
			long IFContent_in, 
			long IFSource_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_ContentSource _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.InputOutput, IFContent_in, 0), 
				_connection.newDBDataParameter("IFSource_", DbType.Int64, ParameterDirection.InputOutput, IFSource_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_ContentSource_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NWS_ContentSource();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFContent = 0L;
				} else {
					_output.IFContent = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFSource = 0L;
				} else {
					_output.IFSource = (long)_dataparameters[1].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NWS_ContentSource from Database.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFSource_in">IFSource</param>
		public static void delObject(
			long IFContent_in, 
			long IFSource_in
		) {
			delObject(
				IFContent_in, 
				IFSource_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_ContentSource from Database.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFSource_in">IFSource</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFContent_in, 
			long IFSource_in, 
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
				_connection.newDBDataParameter("IFSource_", DbType.Int64, ParameterDirection.Input, IFSource_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_ContentSource_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NWS_ContentSource exists at Database
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFSource_in">IFSource</param>
		/// <returns>True if NWS_ContentSource exists at Database, False if not</returns>
		public static bool isObject(
			long IFContent_in, 
			long IFSource_in
		) {
			return isObject(
				IFContent_in, 
				IFSource_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NWS_ContentSource exists at Database
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFSource_in">IFSource</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_ContentSource exists at Database, False if not</returns>
		public static bool isObject(
			long IFContent_in, 
			long IFSource_in, 
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
				_connection.newDBDataParameter("IFSource_", DbType.Int64, ParameterDirection.Input, IFSource_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentSource_isObject", 
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
		/// Inserts/Updates NWS_ContentSource values into/on Database. Inserts if NWS_ContentSource doesn't exist or Updates if NWS_ContentSource already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NWS_ContentSource NWS_ContentSource_in, 
			bool forceUpdate_in
		) {
			return setObject(
				NWS_ContentSource_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates NWS_ContentSource values into/on Database. Inserts if NWS_ContentSource doesn't exist or Updates if NWS_ContentSource already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NWS_ContentSource NWS_ContentSource_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || NWS_ContentSource_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.Input, NWS_ContentSource_in.IFContent, 0), 
					_connection.newDBDataParameter("IFSource_", DbType.Int64, ParameterDirection.Input, NWS_ContentSource_in.IFSource, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NWS_ContentSource_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[2].Value & 2) == 1);
				if (!ConstraintExist_out) {
					NWS_ContentSource_in.haschanges_ = false;
				}

				return (((int)_dataparameters[2].Value & 1) != 1);
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
		#region private static SO_NWS_ContentSource[] getRecord(DataTable dataTable_in);
		private static SO_NWS_ContentSource[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifcontent = null;
			DataColumn _dc_ifsource = null;

			SO_NWS_ContentSource[] _output 
				= new SO_NWS_ContentSource[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifcontent = dataTable_in.Columns["IFContent"];
					_dc_ifsource = dataTable_in.Columns["IFSource"];
				}

				_output[r] = new SO_NWS_ContentSource();
				if (dataTable_in.Rows[r][_dc_ifcontent] == System.DBNull.Value) {
					_output[r].ifcontent_ = 0L;
				} else {
					_output[r].ifcontent_ = (long)dataTable_in.Rows[r][_dc_ifcontent];
				}
				if (dataTable_in.Rows[r][_dc_ifsource] == System.DBNull.Value) {
					_output[r].ifsource_ = 0L;
				} else {
					_output[r].ifsource_ = (long)dataTable_in.Rows[r][_dc_ifsource];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byContent...
		#region public static SO_NWS_ContentSource[] getRecord_byContent(...);
		/// <summary>
		/// Gets Record, based on 'byContent' search. It selects NWS_ContentSource values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_NWS_ContentSource[] getRecord_byContent(
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
		/// Gets Record, based on 'byContent' search. It selects NWS_ContentSource values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NWS_ContentSource[] getRecord_byContent(
			long IDContent_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_ContentSource[] _output;

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
						? "sp0_NWS_ContentSource_Record_open_byContent_page_fullmode"
						: "sp0_NWS_ContentSource_Record_open_byContent_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byContent(...);
		/// <summary>
		/// It selects NWS_ContentSource values from Database based on the 'byContent' search and checks to see if NWS_ContentSource Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentSource's IFContent Key used for checking</param>
		/// <param name="IFSource_in">NWS_ContentSource's IFSource Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <returns>True if NWS_ContentSource Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IFContent_in, 
			long IFSource_in, 
			long IDContent_search_in
		) {
			return isObject_inRecord_byContent(
				IFContent_in, 
				IFSource_in, IDContent_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NWS_ContentSource values from Database based on the 'byContent' search and checks to see if NWS_ContentSource Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentSource's IFContent Key used for checking</param>
		/// <param name="IFSource_in">NWS_ContentSource's IFSource Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_ContentSource Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IFContent_in, 
			long IFSource_in, 
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
				_connection.newDBDataParameter("IFSource_", DbType.Int64, ParameterDirection.Input, IFSource_in, 0), 
				_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentSource_Record_hasObject_byContent", 
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
		/// Count's number of search results from NWS_ContentSource at Database based on the 'byContent' search.
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
		/// Count's number of search results from NWS_ContentSource at Database based on the 'byContent' search.
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
				"fnc0_NWS_ContentSource_Record_count_byContent", 
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
		/// Deletes NWS_ContentSource values from Database based on the 'byContent' search.
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
		/// Deletes NWS_ContentSource values from Database based on the 'byContent' search.
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
				"sp0_NWS_ContentSource_Record_delete_byContent", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#region ???_bySource...
		#region public static SO_NWS_ContentSource[] getRecord_bySource(...);
		/// <summary>
		/// Gets Record, based on 'bySource' search. It selects NWS_ContentSource values from Database based on the 'bySource' search.
		/// </summary>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_NWS_ContentSource[] getRecord_bySource(
			long IDSource_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_bySource(
				IDSource_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'bySource' search. It selects NWS_ContentSource values from Database based on the 'bySource' search.
		/// </summary>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NWS_ContentSource[] getRecord_bySource(
			long IDSource_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_ContentSource[] _output;

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
						_connection.newDBDataParameter("IDSource_search_", DbType.Int64, ParameterDirection.Input, IDSource_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDSource_search_", DbType.Int64, ParameterDirection.Input, IDSource_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_NWS_ContentSource_Record_open_bySource_page_fullmode"
						: "sp0_NWS_ContentSource_Record_open_bySource_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_bySource(...);
		/// <summary>
		/// It selects NWS_ContentSource values from Database based on the 'bySource' search and checks to see if NWS_ContentSource Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentSource's IFContent Key used for checking</param>
		/// <param name="IFSource_in">NWS_ContentSource's IFSource Key used for checking</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <returns>True if NWS_ContentSource Keys are met in the 'bySource' search, False if not</returns>
		public static bool isObject_inRecord_bySource(
			long IFContent_in, 
			long IFSource_in, 
			long IDSource_search_in
		) {
			return isObject_inRecord_bySource(
				IFContent_in, 
				IFSource_in, IDSource_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NWS_ContentSource values from Database based on the 'bySource' search and checks to see if NWS_ContentSource Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentSource's IFContent Key used for checking</param>
		/// <param name="IFSource_in">NWS_ContentSource's IFSource Key used for checking</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_ContentSource Keys are met in the 'bySource' search, False if not</returns>
		public static bool isObject_inRecord_bySource(
			long IFContent_in, 
			long IFSource_in, 
			long IDSource_search_in, 
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
				_connection.newDBDataParameter("IFSource_", DbType.Int64, ParameterDirection.Input, IFSource_in, 0), 
				_connection.newDBDataParameter("IDSource_search_", DbType.Int64, ParameterDirection.Input, IDSource_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentSource_Record_hasObject_bySource", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_bySource(...);
		/// <summary>
		/// Count's number of search results from NWS_ContentSource at Database based on the 'bySource' search.
		/// </summary>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <returns>number of existing Records for the 'bySource' search</returns>
		public static long getCount_inRecord_bySource(
			long IDSource_search_in
		) {
			return getCount_inRecord_bySource(
				IDSource_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from NWS_ContentSource at Database based on the 'bySource' search.
		/// </summary>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'bySource' search</returns>
		public static long getCount_inRecord_bySource(
			long IDSource_search_in, 
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
				_connection.newDBDataParameter("IDSource_search_", DbType.Int64, ParameterDirection.Input, IDSource_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentSource_Record_count_bySource", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_bySource(...);
		/// <summary>
		/// Deletes NWS_ContentSource values from Database based on the 'bySource' search.
		/// </summary>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		public static void delRecord_bySource(
			long IDSource_search_in
		) {
			delRecord_bySource(
				IDSource_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_ContentSource values from Database based on the 'bySource' search.
		/// </summary>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_bySource(
			long IDSource_search_in, 
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
				_connection.newDBDataParameter("IDSource_search_", DbType.Int64, ParameterDirection.Input, IDSource_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NWS_ContentSource_Record_delete_bySource", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}