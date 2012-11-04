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
	/// CRD_ProfilePermission DataObject which provides access to CRD_ProfilePermission's Database table.
	/// </summary>
	[DOClassAttribute("CRD_ProfilePermission", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_CRD_ProfilePermission 
#else
			DO_CRD_ProfilePermission 
#endif
	{

	 	#region Methods...
		#region public static SO_CRD_ProfilePermission getObject(...);
		/// <summary>
		/// Selects CRD_ProfilePermission values from Database and assigns them to the appropriate DO0_CRD_ProfilePermission property.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermission_in">IFPermission</param>
		/// <returns>null if CRD_ProfilePermission doesn't exists at Database</returns>
		public static SO_CRD_ProfilePermission getObject(
			long IFProfile_in, 
			long IFPermission_in
		) {
			return getObject(
				IFProfile_in, 
				IFPermission_in, 
				null
			);
		}

		/// <summary>
		/// Selects CRD_ProfilePermission values from Database and assigns them to the appropriate DO_CRD_ProfilePermission property.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermission_in">IFPermission</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if CRD_ProfilePermission doesn't exists at Database</returns>
		public static SO_CRD_ProfilePermission getObject(
			long IFProfile_in, 
			long IFPermission_in, 
			DBConnection dbConnection_in
		) {
			SO_CRD_ProfilePermission _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.InputOutput, IFProfile_in, 0), 
				_connection.newDBDataParameter("IFPermission_", DbType.Int64, ParameterDirection.InputOutput, IFPermission_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_ProfilePermission_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_CRD_ProfilePermission();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFProfile = 0L;
				} else {
					_output.IFProfile = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFPermission = 0L;
				} else {
					_output.IFPermission = (long)_dataparameters[1].Value;
				}

				_output.hasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes CRD_ProfilePermission from Database.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermission_in">IFPermission</param>
		public static void delObject(
			long IFProfile_in, 
			long IFPermission_in
		) {
			delObject(
				IFProfile_in, 
				IFPermission_in, 
				null
			);
		}

		/// <summary>
		/// Deletes CRD_ProfilePermission from Database.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermission_in">IFPermission</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFProfile_in, 
			long IFPermission_in, 
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
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, IFProfile_in, 0), 
				_connection.newDBDataParameter("IFPermission_", DbType.Int64, ParameterDirection.Input, IFPermission_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_ProfilePermission_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if CRD_ProfilePermission exists at Database
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermission_in">IFPermission</param>
		/// <returns>True if CRD_ProfilePermission exists at Database, False if not</returns>
		public static bool isObject(
			long IFProfile_in, 
			long IFPermission_in
		) {
			return isObject(
				IFProfile_in, 
				IFPermission_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if CRD_ProfilePermission exists at Database
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermission_in">IFPermission</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_ProfilePermission exists at Database, False if not</returns>
		public static bool isObject(
			long IFProfile_in, 
			long IFPermission_in, 
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
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, IFProfile_in, 0), 
				_connection.newDBDataParameter("IFPermission_", DbType.Int64, ParameterDirection.Input, IFPermission_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_ProfilePermission_isObject", 
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
		/// Inserts/Updates CRD_ProfilePermission values into/on Database. Inserts if CRD_ProfilePermission doesn't exist or Updates if CRD_ProfilePermission already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_CRD_ProfilePermission CRD_ProfilePermission_in, 
			bool forceUpdate_in
		) {
			return setObject(
				CRD_ProfilePermission_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates CRD_ProfilePermission values into/on Database. Inserts if CRD_ProfilePermission doesn't exist or Updates if CRD_ProfilePermission already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_CRD_ProfilePermission CRD_ProfilePermission_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || CRD_ProfilePermission_in.hasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, CRD_ProfilePermission_in.IFProfile, 0), 
					_connection.newDBDataParameter("IFPermission_", DbType.Int64, ParameterDirection.Input, CRD_ProfilePermission_in.IFPermission, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_CRD_ProfilePermission_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[2].Value & 2) == 1);
				if (!ConstraintExist_out) {
					CRD_ProfilePermission_in.hasChanges = false;
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
		#region private static SO_CRD_ProfilePermission[] getRecord(DataTable dataTable_in);
		private static SO_CRD_ProfilePermission[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifprofile = null;
			DataColumn _dc_ifpermission = null;

			SO_CRD_ProfilePermission[] _output 
				= new SO_CRD_ProfilePermission[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifprofile = dataTable_in.Columns["IFProfile"];
					_dc_ifpermission = dataTable_in.Columns["IFPermission"];
				}

				_output[r] = new SO_CRD_ProfilePermission();
				if (dataTable_in.Rows[r][_dc_ifprofile] == System.DBNull.Value) {
					_output[r].IFProfile = 0L;
				} else {
					_output[r].IFProfile = (long)dataTable_in.Rows[r][_dc_ifprofile];
				}
				if (dataTable_in.Rows[r][_dc_ifpermission] == System.DBNull.Value) {
					_output[r].IFPermission = 0L;
				} else {
					_output[r].IFPermission = (long)dataTable_in.Rows[r][_dc_ifpermission];
				}

				_output[r].hasChanges = false;
			}

			return _output;
		}
		#endregion
		#region ???_byProfile...
		#region public static SO_CRD_ProfilePermission[] getRecord_byProfile(...);
		/// <summary>
		/// Gets Record, based on 'byProfile' search. It selects CRD_ProfilePermission values from Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		public static SO_CRD_ProfilePermission[] getRecord_byProfile(
			long IDProfile_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out
		) {
			return getRecord_byProfile(
				IDProfile_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byProfile' search. It selects CRD_ProfilePermission values from Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_CRD_ProfilePermission[] getRecord_byProfile(
			long IDProfile_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			DBConnection dbConnection_in
		) {
			SO_CRD_ProfilePermission[] _output;

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
						_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0), 
						_connection.newDBDataParameter("page_orderBy_", DbType.Int32, ParameterDirection.Input, page_orderBy_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int64, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_itemsPerPage_", DbType.Int32, ParameterDirection.Input, page_itemsPerPage_in, 0), 

						//_connection.newDBDataParameter("page_itemsCount_", DbType.Int32, ParameterDirection.Output, null, 0), 

					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_itemsPerPage_in > 0))
						? "sp_CRD_ProfilePermission_Record_open_byProfile_page"
						: "sp0_CRD_ProfilePermission_Record_open_byProfile", 
					_dataparameters
				)
			);
			if ((page_in > 0) && (page_itemsPerPage_in > 0)) {
				// && (_dataparameters[_dataparameters.Length - 1].Value != DBNull.Value)) {
				//page_itemsCount_out = (int)_dataparameters[_dataparameters.Length - 1].Value;

				page_itemsCount_out = getCount_inRecord_byProfile(
					IDProfile_search_in, 
					dbConnection_in
				);
			} else {
				page_itemsCount_out = 0;
			}
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byProfile(...);
		/// <summary>
		/// It selects CRD_ProfilePermission values from Database based on the 'byProfile' search and checks to see if CRD_ProfilePermission Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFProfile_in">CRD_ProfilePermission's IFProfile Key used for checking</param>
		/// <param name="IFPermission_in">CRD_ProfilePermission's IFPermission Key used for checking</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <returns>True if CRD_ProfilePermission Keys are met in the 'byProfile' search, False if not</returns>
		public static bool isObject_inRecord_byProfile(
			long IFProfile_in, 
			long IFPermission_in, 
			long IDProfile_search_in
		) {
			return isObject_inRecord_byProfile(
				IFProfile_in, 
				IFPermission_in, IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects CRD_ProfilePermission values from Database based on the 'byProfile' search and checks to see if CRD_ProfilePermission Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFProfile_in">CRD_ProfilePermission's IFProfile Key used for checking</param>
		/// <param name="IFPermission_in">CRD_ProfilePermission's IFPermission Key used for checking</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_ProfilePermission Keys are met in the 'byProfile' search, False if not</returns>
		public static bool isObject_inRecord_byProfile(
			long IFProfile_in, 
			long IFPermission_in, 
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
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, IFProfile_in, 0), 
				_connection.newDBDataParameter("IFPermission_", DbType.Int64, ParameterDirection.Input, IFPermission_in, 0), 
				_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_ProfilePermission_Record_hasObject_byProfile", 
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
		/// Count's number of search results from CRD_ProfilePermission at Database based on the 'byProfile' search.
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
		/// Count's number of search results from CRD_ProfilePermission at Database based on the 'byProfile' search.
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
				"fnc0_CRD_ProfilePermission_Record_count_byProfile", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_byProfile(...);
		/// <summary>
		/// Deletes CRD_ProfilePermission values from Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		public static void delRecord_byProfile(
			long IDProfile_search_in
		) {
			delRecord_byProfile(
				IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes CRD_ProfilePermission values from Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_byProfile(
			long IDProfile_search_in, 
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
				_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_CRD_ProfilePermission_Record_delete_byProfile", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}