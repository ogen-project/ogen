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
	/// CRD_UserProfile DataObject which provides access to CRD_UserProfile's Database table.
	/// </summary>
	[DOClassAttribute("CRD_UserProfile", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_CRD_UserProfile 
#else
			DO_CRD_UserProfile 
#endif
	{

	 	#region Methods...
		#region public static SO_CRD_UserProfile getObject(...);
		/// <summary>
		/// Selects CRD_UserProfile values from Database and assigns them to the appropriate DO0_CRD_UserProfile property.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <returns>null if CRD_UserProfile doesn't exists at Database</returns>
		public static SO_CRD_UserProfile getObject(
			long IFUser_in, 
			long IFProfile_in
		) {
			return getObject(
				IFUser_in, 
				IFProfile_in, 
				null
			);
		}

		/// <summary>
		/// Selects CRD_UserProfile values from Database and assigns them to the appropriate DO_CRD_UserProfile property.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if CRD_UserProfile doesn't exists at Database</returns>
		public static SO_CRD_UserProfile getObject(
			long IFUser_in, 
			long IFProfile_in, 
			DBConnection dbConnection_in
		) {
			SO_CRD_UserProfile _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.InputOutput, IFUser_in, 0), 
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.InputOutput, IFProfile_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_UserProfile_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_CRD_UserProfile();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFUser = 0L;
				} else {
					_output.IFUser = (long)_dataparameters[0].Value;
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
		/// Deletes CRD_UserProfile from Database.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFProfile_in">IFProfile</param>
		public static void delObject(
			long IFUser_in, 
			long IFProfile_in
		) {
			delObject(
				IFUser_in, 
				IFProfile_in, 
				null
			);
		}

		/// <summary>
		/// Deletes CRD_UserProfile from Database.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFUser_in, 
			long IFProfile_in, 
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
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, IFUser_in, 0), 
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, IFProfile_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_UserProfile_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if CRD_UserProfile exists at Database
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <returns>True if CRD_UserProfile exists at Database, False if not</returns>
		public static bool isObject(
			long IFUser_in, 
			long IFProfile_in
		) {
			return isObject(
				IFUser_in, 
				IFProfile_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if CRD_UserProfile exists at Database
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_UserProfile exists at Database, False if not</returns>
		public static bool isObject(
			long IFUser_in, 
			long IFProfile_in, 
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
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, IFUser_in, 0), 
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, IFProfile_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_UserProfile_isObject", 
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
		/// Inserts/Updates CRD_UserProfile values into/on Database. Inserts if CRD_UserProfile doesn't exist or Updates if CRD_UserProfile already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_CRD_UserProfile CRD_UserProfile_in, 
			bool forceUpdate_in
		) {
			return setObject(
				CRD_UserProfile_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates CRD_UserProfile values into/on Database. Inserts if CRD_UserProfile doesn't exist or Updates if CRD_UserProfile already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_CRD_UserProfile CRD_UserProfile_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || CRD_UserProfile_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, CRD_UserProfile_in.IFUser, 0), 
					_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, CRD_UserProfile_in.IFProfile, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_CRD_UserProfile_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[2].Value & 2) == 1);
				if (!ConstraintExist_out) {
					CRD_UserProfile_in.haschanges_ = false;
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
		#region private static SO_CRD_UserProfile[] getRecord(DataTable dataTable_in);
		private static SO_CRD_UserProfile[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifuser = null;
			DataColumn _dc_ifprofile = null;

			SO_CRD_UserProfile[] _output 
				= new SO_CRD_UserProfile[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifuser = dataTable_in.Columns["IFUser"];
					_dc_ifprofile = dataTable_in.Columns["IFProfile"];
				}

				_output[r] = new SO_CRD_UserProfile();
				if (dataTable_in.Rows[r][_dc_ifuser] == System.DBNull.Value) {
					_output[r].ifuser_ = 0L;
				} else {
					_output[r].ifuser_ = (long)dataTable_in.Rows[r][_dc_ifuser];
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

		#region ???_byProfile...
		#region public static SO_CRD_UserProfile[] getRecord_byProfile(...);
		/// <summary>
		/// Gets Record, based on 'byProfile' search. It selects CRD_UserProfile values from Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_CRD_UserProfile[] getRecord_byProfile(
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
		/// Gets Record, based on 'byProfile' search. It selects CRD_UserProfile values from Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_CRD_UserProfile[] getRecord_byProfile(
			long IDProfile_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_CRD_UserProfile[] _output;

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
						? "sp0_CRD_UserProfile_Record_open_byProfile_page_fullmode"
						: "sp0_CRD_UserProfile_Record_open_byProfile_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byProfile(...);
		/// <summary>
		/// It selects CRD_UserProfile values from Database based on the 'byProfile' search and checks to see if CRD_UserProfile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFUser_in">CRD_UserProfile's IFUser Key used for checking</param>
		/// <param name="IFProfile_in">CRD_UserProfile's IFProfile Key used for checking</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <returns>True if CRD_UserProfile Keys are met in the 'byProfile' search, False if not</returns>
		public static bool isObject_inRecord_byProfile(
			long IFUser_in, 
			long IFProfile_in, 
			long IDProfile_search_in
		) {
			return isObject_inRecord_byProfile(
				IFUser_in, 
				IFProfile_in, IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects CRD_UserProfile values from Database based on the 'byProfile' search and checks to see if CRD_UserProfile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFUser_in">CRD_UserProfile's IFUser Key used for checking</param>
		/// <param name="IFProfile_in">CRD_UserProfile's IFProfile Key used for checking</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_UserProfile Keys are met in the 'byProfile' search, False if not</returns>
		public static bool isObject_inRecord_byProfile(
			long IFUser_in, 
			long IFProfile_in, 
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
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, IFUser_in, 0), 
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, IFProfile_in, 0), 
				_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_UserProfile_Record_hasObject_byProfile", 
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
		/// Count's number of search results from CRD_UserProfile at Database based on the 'byProfile' search.
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
		/// Count's number of search results from CRD_UserProfile at Database based on the 'byProfile' search.
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
				"fnc0_CRD_UserProfile_Record_count_byProfile", 
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
		/// Deletes CRD_UserProfile values from Database based on the 'byProfile' search.
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
		/// Deletes CRD_UserProfile values from Database based on the 'byProfile' search.
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
				"sp0_CRD_UserProfile_Record_delete_byProfile", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#region ???_byUser...
		#region public static SO_CRD_UserProfile[] getRecord_byUser(...);
		/// <summary>
		/// Gets Record, based on 'byUser' search. It selects CRD_UserProfile values from Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_CRD_UserProfile[] getRecord_byUser(
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
		/// Gets Record, based on 'byUser' search. It selects CRD_UserProfile values from Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_CRD_UserProfile[] getRecord_byUser(
			long IDUser_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_CRD_UserProfile[] _output;

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
						? "sp0_CRD_UserProfile_Record_open_byUser_page_fullmode"
						: "sp0_CRD_UserProfile_Record_open_byUser_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byUser(...);
		/// <summary>
		/// It selects CRD_UserProfile values from Database based on the 'byUser' search and checks to see if CRD_UserProfile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFUser_in">CRD_UserProfile's IFUser Key used for checking</param>
		/// <param name="IFProfile_in">CRD_UserProfile's IFProfile Key used for checking</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <returns>True if CRD_UserProfile Keys are met in the 'byUser' search, False if not</returns>
		public static bool isObject_inRecord_byUser(
			long IFUser_in, 
			long IFProfile_in, 
			long IDUser_search_in
		) {
			return isObject_inRecord_byUser(
				IFUser_in, 
				IFProfile_in, IDUser_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects CRD_UserProfile values from Database based on the 'byUser' search and checks to see if CRD_UserProfile Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFUser_in">CRD_UserProfile's IFUser Key used for checking</param>
		/// <param name="IFProfile_in">CRD_UserProfile's IFProfile Key used for checking</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_UserProfile Keys are met in the 'byUser' search, False if not</returns>
		public static bool isObject_inRecord_byUser(
			long IFUser_in, 
			long IFProfile_in, 
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
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, IFUser_in, 0), 
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, IFProfile_in, 0), 
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_UserProfile_Record_hasObject_byUser", 
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
		/// Count's number of search results from CRD_UserProfile at Database based on the 'byUser' search.
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
		/// Count's number of search results from CRD_UserProfile at Database based on the 'byUser' search.
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
				"fnc0_CRD_UserProfile_Record_count_byUser", 
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
		/// Deletes CRD_UserProfile values from Database based on the 'byUser' search.
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
		/// Deletes CRD_UserProfile values from Database based on the 'byUser' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_byUser(
			long IDUser_search_in, 
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
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_CRD_UserProfile_Record_delete_byUser", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}