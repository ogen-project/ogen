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
	/// NWS_ContentAuthor DataObject which provides access to NWS_ContentAuthor's Database table.
	/// </summary>
	[DOClassAttribute("NWS_ContentAuthor", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_NWS_ContentAuthor 
#else
			DO_NWS_ContentAuthor 
#endif
	{

	 	#region Methods...
		#region public static SO_NWS_ContentAuthor getObject(...);
		/// <summary>
		/// Selects NWS_ContentAuthor values from Database and assigns them to the appropriate DO0_NWS_ContentAuthor property.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFAuthor_in">IFAuthor</param>
		/// <returns>null if NWS_ContentAuthor doesn't exists at Database</returns>
		public static SO_NWS_ContentAuthor getObject(
			long IFContent_in, 
			long IFAuthor_in
		) {
			return getObject(
				IFContent_in, 
				IFAuthor_in, 
				null
			);
		}

		/// <summary>
		/// Selects NWS_ContentAuthor values from Database and assigns them to the appropriate DO_NWS_ContentAuthor property.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFAuthor_in">IFAuthor</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NWS_ContentAuthor doesn't exists at Database</returns>
		public static SO_NWS_ContentAuthor getObject(
			long IFContent_in, 
			long IFAuthor_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_ContentAuthor _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.InputOutput, IFContent_in, 0), 
				_connection.newDBDataParameter("IFAuthor_", DbType.Int64, ParameterDirection.InputOutput, IFAuthor_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_ContentAuthor_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NWS_ContentAuthor();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFContent = 0L;
				} else {
					_output.IFContent = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFAuthor = 0L;
				} else {
					_output.IFAuthor = (long)_dataparameters[1].Value;
				}

				_output.hasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NWS_ContentAuthor from Database.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFAuthor_in">IFAuthor</param>
		public static void delObject(
			long IFContent_in, 
			long IFAuthor_in
		) {
			delObject(
				IFContent_in, 
				IFAuthor_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_ContentAuthor from Database.
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFAuthor_in">IFAuthor</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFContent_in, 
			long IFAuthor_in, 
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
				_connection.newDBDataParameter("IFAuthor_", DbType.Int64, ParameterDirection.Input, IFAuthor_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_ContentAuthor_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NWS_ContentAuthor exists at Database
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFAuthor_in">IFAuthor</param>
		/// <returns>True if NWS_ContentAuthor exists at Database, False if not</returns>
		public static bool isObject(
			long IFContent_in, 
			long IFAuthor_in
		) {
			return isObject(
				IFContent_in, 
				IFAuthor_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NWS_ContentAuthor exists at Database
		/// </summary>
		/// <param name="IFContent_in">IFContent</param>
		/// <param name="IFAuthor_in">IFAuthor</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_ContentAuthor exists at Database, False if not</returns>
		public static bool isObject(
			long IFContent_in, 
			long IFAuthor_in, 
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
				_connection.newDBDataParameter("IFAuthor_", DbType.Int64, ParameterDirection.Input, IFAuthor_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentAuthor_isObject", 
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
		/// Inserts/Updates NWS_ContentAuthor values into/on Database. Inserts if NWS_ContentAuthor doesn't exist or Updates if NWS_ContentAuthor already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NWS_ContentAuthor NWS_ContentAuthor_in, 
			bool forceUpdate_in
		) {
			return setObject(
				NWS_ContentAuthor_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates NWS_ContentAuthor values into/on Database. Inserts if NWS_ContentAuthor doesn't exist or Updates if NWS_ContentAuthor already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NWS_ContentAuthor NWS_ContentAuthor_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || NWS_ContentAuthor_in.hasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.Input, NWS_ContentAuthor_in.IFContent, 0), 
					_connection.newDBDataParameter("IFAuthor_", DbType.Int64, ParameterDirection.Input, NWS_ContentAuthor_in.IFAuthor, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NWS_ContentAuthor_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[2].Value & 2) == 1);
				if (!ConstraintExist_out) {
					NWS_ContentAuthor_in.hasChanges = false;
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
		#region private static SO_NWS_ContentAuthor[] getRecord(DataTable dataTable_in);
		private static SO_NWS_ContentAuthor[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifcontent = null;
			DataColumn _dc_ifauthor = null;

			SO_NWS_ContentAuthor[] _output 
				= new SO_NWS_ContentAuthor[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifcontent = dataTable_in.Columns["IFContent"];
					_dc_ifauthor = dataTable_in.Columns["IFAuthor"];
				}

				_output[r] = new SO_NWS_ContentAuthor();
				if (dataTable_in.Rows[r][_dc_ifcontent] == System.DBNull.Value) {
					_output[r].IFContent = 0L;
				} else {
					_output[r].IFContent = (long)dataTable_in.Rows[r][_dc_ifcontent];
				}
				if (dataTable_in.Rows[r][_dc_ifauthor] == System.DBNull.Value) {
					_output[r].IFAuthor = 0L;
				} else {
					_output[r].IFAuthor = (long)dataTable_in.Rows[r][_dc_ifauthor];
				}

				_output[r].hasChanges = false;
			}

			return _output;
		}
		#endregion

		#region ???_byContent...
		#region public static SO_NWS_ContentAuthor[] getRecord_byContent(...);
		/// <summary>
		/// Gets Record, based on 'byContent' search. It selects NWS_ContentAuthor values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		public static SO_NWS_ContentAuthor[] getRecord_byContent(
			long IDContent_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out
		) {
			return getRecord_byContent(
				IDContent_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byContent' search. It selects NWS_ContentAuthor values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NWS_ContentAuthor[] getRecord_byContent(
			long IDContent_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			DBConnection dbConnection_in
		) {
			SO_NWS_ContentAuthor[] _output;

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
						_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0), 
						_connection.newDBDataParameter("page_orderBy_", DbType.Int32, ParameterDirection.Input, page_orderBy_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int64, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_itemsPerPage_", DbType.Int32, ParameterDirection.Input, page_itemsPerPage_in, 0), 

						//_connection.newDBDataParameter("page_itemsCount_", DbType.Int32, ParameterDirection.Output, null, 0), 

					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_itemsPerPage_in > 0))
						? "sp_NWS_ContentAuthor_Record_open_byContent_page"
						: "sp0_NWS_ContentAuthor_Record_open_byContent", 
					_dataparameters
				)
			);
			if ((page_in > 0) && (page_itemsPerPage_in > 0)) {
				// && (_dataparameters[_dataparameters.Length - 1].Value != DBNull.Value)) {
				//page_itemsCount_out = (int)_dataparameters[_dataparameters.Length - 1].Value;

				page_itemsCount_out = getCount_inRecord_byContent(
					IDContent_search_in, 
					dbConnection_in
				);
			} else {
				page_itemsCount_out = 0;
			}
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byContent(...);
		/// <summary>
		/// It selects NWS_ContentAuthor values from Database based on the 'byContent' search and checks to see if NWS_ContentAuthor Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentAuthor's IFContent Key used for checking</param>
		/// <param name="IFAuthor_in">NWS_ContentAuthor's IFAuthor Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <returns>True if NWS_ContentAuthor Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IFContent_in, 
			long IFAuthor_in, 
			long IDContent_search_in
		) {
			return isObject_inRecord_byContent(
				IFContent_in, 
				IFAuthor_in, IDContent_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NWS_ContentAuthor values from Database based on the 'byContent' search and checks to see if NWS_ContentAuthor Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentAuthor's IFContent Key used for checking</param>
		/// <param name="IFAuthor_in">NWS_ContentAuthor's IFAuthor Key used for checking</param>
		/// <param name="IDContent_search_in">IDContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_ContentAuthor Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IFContent_in, 
			long IFAuthor_in, 
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
				_connection.newDBDataParameter("IFAuthor_", DbType.Int64, ParameterDirection.Input, IFAuthor_in, 0), 
				_connection.newDBDataParameter("IDContent_search_", DbType.Int64, ParameterDirection.Input, IDContent_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentAuthor_Record_hasObject_byContent", 
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
		/// Count's number of search results from NWS_ContentAuthor at Database based on the 'byContent' search.
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
		/// Count's number of search results from NWS_ContentAuthor at Database based on the 'byContent' search.
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
				"fnc0_NWS_ContentAuthor_Record_count_byContent", 
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
		/// Deletes NWS_ContentAuthor values from Database based on the 'byContent' search.
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
		/// Deletes NWS_ContentAuthor values from Database based on the 'byContent' search.
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
				"sp0_NWS_ContentAuthor_Record_delete_byContent", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#region ???_byAuthor...
		#region public static SO_NWS_ContentAuthor[] getRecord_byAuthor(...);
		/// <summary>
		/// Gets Record, based on 'byAuthor' search. It selects NWS_ContentAuthor values from Database based on the 'byAuthor' search.
		/// </summary>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		public static SO_NWS_ContentAuthor[] getRecord_byAuthor(
			long IDAuthor_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out
		) {
			return getRecord_byAuthor(
				IDAuthor_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byAuthor' search. It selects NWS_ContentAuthor values from Database based on the 'byAuthor' search.
		/// </summary>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NWS_ContentAuthor[] getRecord_byAuthor(
			long IDAuthor_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			DBConnection dbConnection_in
		) {
			SO_NWS_ContentAuthor[] _output;

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
						_connection.newDBDataParameter("IDAuthor_search_", DbType.Int64, ParameterDirection.Input, IDAuthor_search_in, 0), 
						_connection.newDBDataParameter("page_orderBy_", DbType.Int32, ParameterDirection.Input, page_orderBy_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int64, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_itemsPerPage_", DbType.Int32, ParameterDirection.Input, page_itemsPerPage_in, 0), 

						//_connection.newDBDataParameter("page_itemsCount_", DbType.Int32, ParameterDirection.Output, null, 0), 

					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDAuthor_search_", DbType.Int64, ParameterDirection.Input, IDAuthor_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_itemsPerPage_in > 0))
						? "sp_NWS_ContentAuthor_Record_open_byAuthor_page"
						: "sp0_NWS_ContentAuthor_Record_open_byAuthor", 
					_dataparameters
				)
			);
			if ((page_in > 0) && (page_itemsPerPage_in > 0)) {
				// && (_dataparameters[_dataparameters.Length - 1].Value != DBNull.Value)) {
				//page_itemsCount_out = (int)_dataparameters[_dataparameters.Length - 1].Value;

				page_itemsCount_out = getCount_inRecord_byAuthor(
					IDAuthor_search_in, 
					dbConnection_in
				);
			} else {
				page_itemsCount_out = 0;
			}
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byAuthor(...);
		/// <summary>
		/// It selects NWS_ContentAuthor values from Database based on the 'byAuthor' search and checks to see if NWS_ContentAuthor Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentAuthor's IFContent Key used for checking</param>
		/// <param name="IFAuthor_in">NWS_ContentAuthor's IFAuthor Key used for checking</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <returns>True if NWS_ContentAuthor Keys are met in the 'byAuthor' search, False if not</returns>
		public static bool isObject_inRecord_byAuthor(
			long IFContent_in, 
			long IFAuthor_in, 
			long IDAuthor_search_in
		) {
			return isObject_inRecord_byAuthor(
				IFContent_in, 
				IFAuthor_in, IDAuthor_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NWS_ContentAuthor values from Database based on the 'byAuthor' search and checks to see if NWS_ContentAuthor Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFContent_in">NWS_ContentAuthor's IFContent Key used for checking</param>
		/// <param name="IFAuthor_in">NWS_ContentAuthor's IFAuthor Key used for checking</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_ContentAuthor Keys are met in the 'byAuthor' search, False if not</returns>
		public static bool isObject_inRecord_byAuthor(
			long IFContent_in, 
			long IFAuthor_in, 
			long IDAuthor_search_in, 
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
				_connection.newDBDataParameter("IFAuthor_", DbType.Int64, ParameterDirection.Input, IFAuthor_in, 0), 
				_connection.newDBDataParameter("IDAuthor_search_", DbType.Int64, ParameterDirection.Input, IDAuthor_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentAuthor_Record_hasObject_byAuthor", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byAuthor(...);
		/// <summary>
		/// Count's number of search results from NWS_ContentAuthor at Database based on the 'byAuthor' search.
		/// </summary>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <returns>number of existing Records for the 'byAuthor' search</returns>
		public static long getCount_inRecord_byAuthor(
			long IDAuthor_search_in
		) {
			return getCount_inRecord_byAuthor(
				IDAuthor_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from NWS_ContentAuthor at Database based on the 'byAuthor' search.
		/// </summary>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byAuthor' search</returns>
		public static long getCount_inRecord_byAuthor(
			long IDAuthor_search_in, 
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
				_connection.newDBDataParameter("IDAuthor_search_", DbType.Int64, ParameterDirection.Input, IDAuthor_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_NWS_ContentAuthor_Record_count_byAuthor", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_byAuthor(...);
		/// <summary>
		/// Deletes NWS_ContentAuthor values from Database based on the 'byAuthor' search.
		/// </summary>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		public static void delRecord_byAuthor(
			long IDAuthor_search_in
		) {
			delRecord_byAuthor(
				IDAuthor_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_ContentAuthor values from Database based on the 'byAuthor' search.
		/// </summary>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_byAuthor(
			long IDAuthor_search_in, 
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
				_connection.newDBDataParameter("IDAuthor_search_", DbType.Int64, ParameterDirection.Input, IDAuthor_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NWS_ContentAuthor_Record_delete_byAuthor", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}