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
	/// NET_Defaultprofile DataObject which provides access to NET_Defaultprofile's Database table.
	/// </summary>
	[DOClassAttribute("NET_Defaultprofile", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_NET_Defaultprofile 
#else
			DO_NET_Defaultprofile 
#endif
	{

	 	#region Methods...
		#region public static SO_NET_Defaultprofile getObject(...);
		/// <summary>
		/// Selects NET_Defaultprofile values from Database and assigns them to the appropriate DO0_NET_Defaultprofile property.
		/// </summary>
		/// <param name="IDDefaultprofile_in">IDDefaultprofile</param>
		/// <returns>null if NET_Defaultprofile doesn't exists at Database</returns>
		public static SO_NET_Defaultprofile getObject(
			long IDDefaultprofile_in
		) {
			return getObject(
				IDDefaultprofile_in, 
				null
			);
		}

		/// <summary>
		/// Selects NET_Defaultprofile values from Database and assigns them to the appropriate DO_NET_Defaultprofile property.
		/// </summary>
		/// <param name="IDDefaultprofile_in">IDDefaultprofile</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NET_Defaultprofile doesn't exists at Database</returns>
		public static SO_NET_Defaultprofile getObject(
			long IDDefaultprofile_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_Defaultprofile _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDDefaultprofile_", DbType.Int64, ParameterDirection.InputOutput, IDDefaultprofile_in, 0), 
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_NET_Defaultprofile_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NET_Defaultprofile();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDDefaultprofile = 0L;
				} else {
					_output.IDDefaultprofile = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFProfile = 0L;
				} else {
					_output.IFProfile = (long)_dataparameters[1].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NET_Defaultprofile from Database.
		/// </summary>
		/// <param name="IDDefaultprofile_in">IDDefaultprofile</param>
		public static void delObject(
			long IDDefaultprofile_in
		) {
			delObject(
				IDDefaultprofile_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_Defaultprofile from Database.
		/// </summary>
		/// <param name="IDDefaultprofile_in">IDDefaultprofile</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDDefaultprofile_in, 
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
				_connection.newDBDataParameter("IDDefaultprofile_", DbType.Int64, ParameterDirection.Input, IDDefaultprofile_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NET_Defaultprofile_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NET_Defaultprofile exists at Database
		/// </summary>
		/// <param name="IDDefaultprofile_in">IDDefaultprofile</param>
		/// <returns>True if NET_Defaultprofile exists at Database, False if not</returns>
		public static bool isObject(
			long IDDefaultprofile_in
		) {
			return isObject(
				IDDefaultprofile_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NET_Defaultprofile exists at Database
		/// </summary>
		/// <param name="IDDefaultprofile_in">IDDefaultprofile</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_Defaultprofile exists at Database, False if not</returns>
		public static bool isObject(
			long IDDefaultprofile_in, 
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
				_connection.newDBDataParameter("IDDefaultprofile_", DbType.Int64, ParameterDirection.Input, IDDefaultprofile_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NET_Defaultprofile_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long insObject(...);
		/// <summary>
		/// Inserts NET_Defaultprofile values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_NET_Defaultprofile NET_Defaultprofile_in, 
			bool selectIdentity_in
		) {
			return insObject(
				NET_Defaultprofile_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts NET_Defaultprofile values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_NET_Defaultprofile NET_Defaultprofile_in, 
			bool selectIdentity_in, 
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
				_connection.newDBDataParameter("IDDefaultprofile_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, NET_Defaultprofile_in.IFProfile, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_NET_Defaultprofile_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			NET_Defaultprofile_in.IDDefaultprofile = (long)_dataparameters[0].Value;NET_Defaultprofile_in.haschanges_ = false;
			

			return NET_Defaultprofile_in.IDDefaultprofile;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates NET_Defaultprofile values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_NET_Defaultprofile NET_Defaultprofile_in, 
			bool forceUpdate_in
		) {
			updObject(
				NET_Defaultprofile_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates NET_Defaultprofile values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_NET_Defaultprofile NET_Defaultprofile_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || NET_Defaultprofile_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDDefaultprofile_", DbType.Int64, ParameterDirection.Input, NET_Defaultprofile_in.IDDefaultprofile, 0), 
					_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, NET_Defaultprofile_in.IFProfile, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NET_Defaultprofile_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				NET_Defaultprofile_in.haschanges_ = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#region ???Object_byProfile...
		#region public static SO_NET_Defaultprofile getObject_byProfile(...);
		/// <summary>
		/// Selects NET_Defaultprofile values from Database (based on the search condition) and assigns them to the appropriate DO0_NET_Defaultprofile property.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <returns>null if NET_Defaultprofile doesn't exists at Database</returns>
		public static SO_NET_Defaultprofile getObject_byProfile(
			long IDProfile_search_in
		) {
			return getObject_byProfile(
				IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// Selects NET_Defaultprofile values from Database (based on the search condition) and assigns them to the appropriate DO0_NET_Defaultprofile property.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NET_Defaultprofile doesn't exists at Database</returns>
		public static SO_NET_Defaultprofile getObject_byProfile(
			long IDProfile_search_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_Defaultprofile _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0), 
				_connection.newDBDataParameter("IDDefaultprofile", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFProfile", DbType.Int64, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NET_Defaultprofile_getObject_byProfile", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[1].Value != DBNull.Value) {
				_output = new SO_NET_Defaultprofile();
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IDDefaultprofile = 0L;
				} else {
					_output.IDDefaultprofile = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IFProfile = 0L;
				} else {
					_output.IFProfile = (long)_dataparameters[2].Value;
				}

				return _output;
			}

			return null;
		}
		#endregion
		#region public static bool delObject_byProfile(...);
		/// <summary>
		/// Deletes NET_Defaultprofile from Database (based on the search condition).
		/// </summary>
		/// <param name="IDProfile_search_in"> IDProfile search condition</param>
		/// <returns>True if NET_Defaultprofile existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byProfile(
			long IDProfile_search_in
		) {
			return delObject_byProfile(
				IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_Defaultprofile from Database (based on the search condition).
		/// </summary>
		/// <param name="IDProfile_search_in"> IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_Defaultprofile existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_byProfile(
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
				_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0), 

				_connection.newDBDataParameter("Exists_", DbType.Boolean, ParameterDirection.Output, null, 1)
			};
			_connection.Execute_SQLFunction("sp0_NET_Defaultprofile_delObject_byProfile", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return ((bool)_dataparameters[1].Value);
		}
		#endregion
		#region public static bool isObject_byProfile(...);
		/// <summary>
		/// Checks to see if NET_Defaultprofile exists at Database (based on the search condition).
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <returns>True if NET_Defaultprofile exists at Database, False if not</returns>
		public static bool isObject_byProfile(
			long IDProfile_search_in
		) {
			return isObject_byProfile(
				IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NET_Defaultprofile exists at Database (based on the search condition).
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_Defaultprofile exists at Database, False if not</returns>
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
				"fnc0_NET_Defaultprofile_isObject_byProfile", 
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
		#region private static SO_NET_Defaultprofile[] getRecord(DataTable dataTable_in);
		private static SO_NET_Defaultprofile[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_iddefaultprofile = null;
			DataColumn _dc_ifprofile = null;

			SO_NET_Defaultprofile[] _output 
				= new SO_NET_Defaultprofile[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_iddefaultprofile = dataTable_in.Columns["IDDefaultprofile"];
					_dc_ifprofile = dataTable_in.Columns["IFProfile"];
				}

				_output[r] = new SO_NET_Defaultprofile();
				if (dataTable_in.Rows[r][_dc_iddefaultprofile] == System.DBNull.Value) {
					_output[r].iddefaultprofile_ = 0L;
				} else {
					_output[r].iddefaultprofile_ = (long)dataTable_in.Rows[r][_dc_iddefaultprofile];
				}
				if (dataTable_in.Rows[r][_dc_ifprofile] == System.DBNull.Value) {
					_output[r].ifprofile_ = 0L;
				} else {
					_output[r].ifprofile_ = (long)dataTable_in.Rows[r][_dc_ifprofile];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_all...
		#region public static SO_NET_Defaultprofile[] getRecord_all(...);
		/// <summary>
		/// Gets Record, based on 'all' search. It selects NET_Defaultprofile values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_NET_Defaultprofile[] getRecord_all(
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
		/// Gets Record, based on 'all' search. It selects NET_Defaultprofile values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NET_Defaultprofile[] getRecord_all(
			object IDApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_NET_Defaultprofile[] _output;

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
						? "sp0_NET_Defaultprofile_Record_open_all_page_fullmode"
						: "sp0_NET_Defaultprofile_Record_open_all_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_all(...);
		/// <summary>
		/// It selects NET_Defaultprofile values from Database based on the 'all' search and checks to see if NET_Defaultprofile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDDefaultprofile_in">NET_Defaultprofile's IDDefaultprofile Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <returns>True if NET_Defaultprofile Keys are met in the 'all' search, False if not</returns>
		public static bool isObject_inRecord_all(
			long IDDefaultprofile_in, 
			object IDApplication_search_in
		) {
			return isObject_inRecord_all(
				IDDefaultprofile_in, IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NET_Defaultprofile values from Database based on the 'all' search and checks to see if NET_Defaultprofile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDDefaultprofile_in">NET_Defaultprofile's IDDefaultprofile Key used for checking</param>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NET_Defaultprofile Keys are met in the 'all' search, False if not</returns>
		public static bool isObject_inRecord_all(
			long IDDefaultprofile_in, 
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
				_connection.newDBDataParameter("IDDefaultprofile_", DbType.Int64, ParameterDirection.Input, IDDefaultprofile_in, 0), 
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NET_Defaultprofile_Record_hasObject_all", 
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
		/// Count's number of search results from NET_Defaultprofile at Database based on the 'all' search.
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
		/// Count's number of search results from NET_Defaultprofile at Database based on the 'all' search.
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
				"fnc0_NET_Defaultprofile_Record_count_all", 
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
		/// Deletes NET_Defaultprofile values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		public static void delRecord_all(
			object IDApplication_search_in
		) {
			delRecord_all(
				IDApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NET_Defaultprofile values from Database based on the 'all' search.
		/// </summary>
		/// <param name="IDApplication_search_in">IDApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_all(
			object IDApplication_search_in, 
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
				_connection.newDBDataParameter("IDApplication_search_", DbType.Int32, ParameterDirection.Input, IDApplication_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NET_Defaultprofile_Record_delete_all", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}