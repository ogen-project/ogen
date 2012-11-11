#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.DataLayer {
	using System;
	using System.Data;

	using OGen.Libraries.DataLayer;
	using OGen.NTier.Libraries.DataLayer;

	using OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures;

	/// <summary>
	/// CRD_Permission DataObject which provides access to CRD_Permission's Database table.
	/// </summary>
	[DOClassAttribute("CRD_Permission", "", "", "", false, false)]
	public 
#if !NET_1_1
		static partial 
#endif
		class 
#if NET_1_1
			DO0_CRD_Permission 
#else
			DO_CRD_Permission 
#endif
	{

	 	#region Methods...
		#region public static SO_CRD_Permission getObject(...);
		/// <summary>
		/// Selects CRD_Permission values from Database and assigns them to the appropriate DO0_CRD_Permission property.
		/// </summary>
		/// <param name="IDPermission_in">IDPermission</param>
		/// <returns>null if CRD_Permission doesn't exists at Database</returns>
		public static SO_CRD_Permission getObject(
			long IDPermission_in
		) {
			return getObject(
				IDPermission_in, 
				null
			);
		}

		/// <summary>
		/// Selects CRD_Permission values from Database and assigns them to the appropriate DO_CRD_Permission property.
		/// </summary>
		/// <param name="IDPermission_in">IDPermission</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if CRD_Permission doesn't exists at Database</returns>
		public static SO_CRD_Permission getObject(
			long IDPermission_in, 
			DBConnection dbConnection_in
		) {
			SO_CRD_Permission _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDPermission_", DbType.Int64, ParameterDirection.InputOutput, IDPermission_in, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFTable_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFAction_", DbType.Int64, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_Permission_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_CRD_Permission();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDPermission = 0L;
				} else {
					_output.IDPermission = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.Name = string.Empty;
				} else {
					_output.Name = (string)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.IFTable_isNull = true;
				} else {
					_output.IFTable = (long)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.IFAction_isNull = true;
				} else {
					_output.IFAction = (long)_dataparameters[4].Value;
				}

				_output.HasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes CRD_Permission from Database.
		/// </summary>
		/// <param name="IDPermission_in">IDPermission</param>
		public static void delObject(
			long IDPermission_in
		) {
			delObject(
				IDPermission_in, 
				null
			);
		}

		/// <summary>
		/// Deletes CRD_Permission from Database.
		/// </summary>
		/// <param name="IDPermission_in">IDPermission</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDPermission_in, 
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDPermission_", DbType.Int64, ParameterDirection.Input, IDPermission_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_Permission_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if CRD_Permission exists at Database
		/// </summary>
		/// <param name="IDPermission_in">IDPermission</param>
		/// <returns>True if CRD_Permission exists at Database, False if not</returns>
		public static bool isObject(
			long IDPermission_in
		) {
			return isObject(
				IDPermission_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if CRD_Permission exists at Database
		/// </summary>
		/// <param name="IDPermission_in">IDPermission</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_Permission exists at Database, False if not</returns>
		public static bool isObject(
			long IDPermission_in, 
			DBConnection dbConnection_in
		) {
			bool _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDPermission_", DbType.Int64, ParameterDirection.Input, IDPermission_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_Permission_isObject", 
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
		/// Inserts/Updates CRD_Permission values into/on Database. Inserts if CRD_Permission doesn't exist or Updates if CRD_Permission already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_CRD_Permission CRD_Permission_in, 
			bool forceUpdate_in
		) {
			return setObject(
				CRD_Permission_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates CRD_Permission values into/on Database. Inserts if CRD_Permission doesn't exist or Updates if CRD_Permission already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_CRD_Permission CRD_Permission_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || CRD_Permission_in.HasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__Utilities.DBConnection_createInstance(
						DO__Utilities.DBServerType,
						DO__Utilities.DBConnectionstring,
						DO__Utilities.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDPermission_", DbType.Int64, ParameterDirection.Input, CRD_Permission_in.IDPermission, 0), 
					_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, CRD_Permission_in.Name, 255), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, CRD_Permission_in.IFApplication_isNull ? null : (object)CRD_Permission_in.IFApplication, 0), 
					_connection.newDBDataParameter("IFTable_", DbType.Int64, ParameterDirection.Input, CRD_Permission_in.IFTable_isNull ? null : (object)CRD_Permission_in.IFTable, 0), 
					_connection.newDBDataParameter("IFAction_", DbType.Int64, ParameterDirection.Input, CRD_Permission_in.IFAction_isNull ? null : (object)CRD_Permission_in.IFAction, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_CRD_Permission_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[5].Value & 2) == 1);
				if (!ConstraintExist_out) {
					CRD_Permission_in.HasChanges = false;
				}

				return (((int)_dataparameters[5].Value & 1) != 1);
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
		#region private static SO_CRD_Permission[] getRecord(DataTable dataTable_in);
		private static SO_CRD_Permission[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idpermission = null;
			DataColumn _dc_name = null;
			DataColumn _dc_ifapplication = null;
			DataColumn _dc_iftable = null;
			DataColumn _dc_ifaction = null;

			SO_CRD_Permission[] _output 
				= new SO_CRD_Permission[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idpermission = dataTable_in.Columns["IDPermission"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
					_dc_iftable = dataTable_in.Columns["IFTable"];
					_dc_ifaction = dataTable_in.Columns["IFAction"];
				}

				_output[r] = new SO_CRD_Permission();
				if (dataTable_in.Rows[r][_dc_idpermission] == System.DBNull.Value) {
					_output[r].IDPermission = 0L;
				} else {
					_output[r].IDPermission = (long)dataTable_in.Rows[r][_dc_idpermission];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].Name = string.Empty;
				} else {
					_output[r].Name = (string)dataTable_in.Rows[r][_dc_name];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication_isNull = true;
				} else {
					_output[r].IFApplication = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}
				if (dataTable_in.Rows[r][_dc_iftable] == System.DBNull.Value) {
					_output[r].IFTable_isNull = true;
				} else {
					_output[r].IFTable = (long)dataTable_in.Rows[r][_dc_iftable];
				}
				if (dataTable_in.Rows[r][_dc_ifaction] == System.DBNull.Value) {
					_output[r].IFAction_isNull = true;
				} else {
					_output[r].IFAction = (long)dataTable_in.Rows[r][_dc_ifaction];
				}

				_output[r].HasChanges = false;
			}

			return _output;
		}
		#endregion
		#region ???_all...
		#region public static SO_CRD_Permission[] getRecord_all(...);
		/// <summary>
		/// Gets Record, based on 'all' search. It selects CRD_Permission values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		public static SO_CRD_Permission[] getRecord_all(
			object IFApplication_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out
		) {
			return getRecord_all(
				IFApplication_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'all' search. It selects CRD_Permission values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_CRD_Permission[] getRecord_all(
			object IFApplication_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			DBConnection dbConnection_in
		) {
			SO_CRD_Permission[] _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = 
				((page_in > 0) && (page_itemsPerPage_in > 0))
					? new IDbDataParameter[] {
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
						_connection.newDBDataParameter("page_orderBy_", DbType.Int32, ParameterDirection.Input, page_orderBy_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int64, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_itemsPerPage_", DbType.Int32, ParameterDirection.Input, page_itemsPerPage_in, 0), 

						//_connection.newDBDataParameter("page_itemsCount_", DbType.Int32, ParameterDirection.Output, null, 0), 

					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_itemsPerPage_in > 0))
						? "sp_CRD_Permission_Record_open_all_page"
						: "sp0_CRD_Permission_Record_open_all", 
					_dataparameters
				)
			);
			if ((page_in > 0) && (page_itemsPerPage_in > 0)) {
				// && (_dataparameters[_dataparameters.Length - 1].Value != DBNull.Value)) {
				//page_itemsCount_out = (int)_dataparameters[_dataparameters.Length - 1].Value;

				page_itemsCount_out = getCount_inRecord_all(
					IFApplication_search_in, 
					dbConnection_in
				);
			} else {
				page_itemsCount_out = 0;
			}
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_all(...);
		/// <summary>
		/// It selects CRD_Permission values from Database based on the 'all' search and checks to see if CRD_Permission Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDPermission_in">CRD_Permission's IDPermission Key used for checking</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <returns>True if CRD_Permission Keys are met in the 'all' search, False if not</returns>
		public static bool isObject_inRecord_all(
			long IDPermission_in, 
			object IFApplication_search_in
		) {
			return isObject_inRecord_all(
				IDPermission_in, IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects CRD_Permission values from Database based on the 'all' search and checks to see if CRD_Permission Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDPermission_in">CRD_Permission's IDPermission Key used for checking</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_Permission Keys are met in the 'all' search, False if not</returns>
		public static bool isObject_inRecord_all(
			long IDPermission_in, 
			object IFApplication_search_in, 
			DBConnection dbConnection_in
		) {
			bool _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDPermission_", DbType.Int64, ParameterDirection.Input, IDPermission_in, 0), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_Permission_Record_hasObject_all", 
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
		/// Count's number of search results from CRD_Permission at Database based on the 'all' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <returns>number of existing Records for the 'all' search</returns>
		public static long getCount_inRecord_all(
			object IFApplication_search_in
		) {
			return getCount_inRecord_all(
				IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from CRD_Permission at Database based on the 'all' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'all' search</returns>
		public static long getCount_inRecord_all(
			object IFApplication_search_in, 
			DBConnection dbConnection_in
		) {
			long _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_CRD_Permission_Record_count_all", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_all(...);
		/// <summary>
		/// Deletes CRD_Permission values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		public static void delRecord_all(
			object IFApplication_search_in
		) {
			delRecord_all(
				IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes CRD_Permission values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_all(
			object IFApplication_search_in, 
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_CRD_Permission_Record_delete_all", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#region ???_byUser...
		#region public static SO_CRD_Permission[] getRecord_byUser(...);
		/// <summary>
		/// Gets Record, based on 'byUser' search. It selects CRD_Permission values from Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		public static SO_CRD_Permission[] getRecord_byUser(
			long IDUser_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out
		) {
			return getRecord_byUser(
				IDUser_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byUser' search. It selects CRD_Permission values from Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="page_orderBy_in">page order by</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_itemsPerPage_in">number of records per page</param>
		/// <param name="page_itemsCount_out">total number of items</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_CRD_Permission[] getRecord_byUser(
			long IDUser_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			DBConnection dbConnection_in
		) {
			SO_CRD_Permission[] _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = 
				((page_in > 0) && (page_itemsPerPage_in > 0))
					? new IDbDataParameter[] {
						_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
						_connection.newDBDataParameter("page_orderBy_", DbType.Int32, ParameterDirection.Input, page_orderBy_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int64, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_itemsPerPage_", DbType.Int32, ParameterDirection.Input, page_itemsPerPage_in, 0), 

						//_connection.newDBDataParameter("page_itemsCount_", DbType.Int32, ParameterDirection.Output, null, 0), 

					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_itemsPerPage_in > 0))
						? "sp_CRD_Permission_Record_open_byUser_page"
						: "sp0_CRD_Permission_Record_open_byUser", 
					_dataparameters
				)
			);
			if ((page_in > 0) && (page_itemsPerPage_in > 0)) {
				// && (_dataparameters[_dataparameters.Length - 1].Value != DBNull.Value)) {
				//page_itemsCount_out = (int)_dataparameters[_dataparameters.Length - 1].Value;

				page_itemsCount_out = getCount_inRecord_byUser(
					IDUser_search_in, 
					dbConnection_in
				);
			} else {
				page_itemsCount_out = 0;
			}
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byUser(...);
		/// <summary>
		/// It selects CRD_Permission values from Database based on the 'byUser' search and checks to see if CRD_Permission Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDPermission_in">CRD_Permission's IDPermission Key used for checking</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <returns>True if CRD_Permission Keys are met in the 'byUser' search, False if not</returns>
		public static bool isObject_inRecord_byUser(
			long IDPermission_in, 
			long IDUser_search_in
		) {
			return isObject_inRecord_byUser(
				IDPermission_in, IDUser_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects CRD_Permission values from Database based on the 'byUser' search and checks to see if CRD_Permission Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDPermission_in">CRD_Permission's IDPermission Key used for checking</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_Permission Keys are met in the 'byUser' search, False if not</returns>
		public static bool isObject_inRecord_byUser(
			long IDPermission_in, 
			long IDUser_search_in, 
			DBConnection dbConnection_in
		) {
			bool _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDPermission_", DbType.Int64, ParameterDirection.Input, IDPermission_in, 0), 
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_Permission_Record_hasObject_byUser", 
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
		/// Count's number of search results from CRD_Permission at Database based on the 'byUser' search.
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
		/// Count's number of search results from CRD_Permission at Database based on the 'byUser' search.
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
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_CRD_Permission_Record_count_byUser", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_byUser(...);
		/// <summary>
		/// Deletes CRD_Permission values from Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		public static void delRecord_byUser(
			long IDUser_search_in
		) {
			delRecord_byUser(
				IDUser_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes CRD_Permission values from Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_byUser(
			long IDUser_search_in, 
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_CRD_Permission_Record_delete_byUser", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}