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
	/// CRD_ProfilePermition DataObject which provides access to CRD_ProfilePermition's Database table.
	/// </summary>
	[DOClassAttribute("CRD_ProfilePermition", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_CRD_ProfilePermition 
#else
			DO_CRD_ProfilePermition 
#endif
	{

	 	#region Methods...
		#region public static SO_CRD_ProfilePermition getObject(...);
		/// <summary>
		/// Selects CRD_ProfilePermition values from Database and assigns them to the appropriate DO0_CRD_ProfilePermition property.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermition_in">IFPermition</param>
		/// <returns>null if CRD_ProfilePermition doesn't exists at Database</returns>
		public static SO_CRD_ProfilePermition getObject(
			long IFProfile_in, 
			long IFPermition_in
		) {
			return getObject(
				IFProfile_in, 
				IFPermition_in, 
				null
			);
		}

		/// <summary>
		/// Selects CRD_ProfilePermition values from Database and assigns them to the appropriate DO_CRD_ProfilePermition property.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermition_in">IFPermition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if CRD_ProfilePermition doesn't exists at Database</returns>
		public static SO_CRD_ProfilePermition getObject(
			long IFProfile_in, 
			long IFPermition_in, 
			DBConnection dbConnection_in
		) {
			SO_CRD_ProfilePermition _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.InputOutput, IFProfile_in, 0), 
				_connection.newDBDataParameter("IFPermition_", DbType.Int64, ParameterDirection.InputOutput, IFPermition_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_ProfilePermition_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_CRD_ProfilePermition();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFProfile = 0L;
				} else {
					_output.IFProfile = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFPermition = 0L;
				} else {
					_output.IFPermition = (long)_dataparameters[1].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes CRD_ProfilePermition from Database.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermition_in">IFPermition</param>
		public static void delObject(
			long IFProfile_in, 
			long IFPermition_in
		) {
			delObject(
				IFProfile_in, 
				IFPermition_in, 
				null
			);
		}

		/// <summary>
		/// Deletes CRD_ProfilePermition from Database.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermition_in">IFPermition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFProfile_in, 
			long IFPermition_in, 
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
				_connection.newDBDataParameter("IFPermition_", DbType.Int64, ParameterDirection.Input, IFPermition_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_CRD_ProfilePermition_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if CRD_ProfilePermition exists at Database
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermition_in">IFPermition</param>
		/// <returns>True if CRD_ProfilePermition exists at Database, False if not</returns>
		public static bool isObject(
			long IFProfile_in, 
			long IFPermition_in
		) {
			return isObject(
				IFProfile_in, 
				IFPermition_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if CRD_ProfilePermition exists at Database
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="IFPermition_in">IFPermition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_ProfilePermition exists at Database, False if not</returns>
		public static bool isObject(
			long IFProfile_in, 
			long IFPermition_in, 
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
				_connection.newDBDataParameter("IFPermition_", DbType.Int64, ParameterDirection.Input, IFPermition_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_ProfilePermition_isObject", 
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
		/// Inserts/Updates CRD_ProfilePermition values into/on Database. Inserts if CRD_ProfilePermition doesn't exist or Updates if CRD_ProfilePermition already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_CRD_ProfilePermition CRD_ProfilePermition_in, 
			bool forceUpdate_in
		) {
			return setObject(
				CRD_ProfilePermition_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates CRD_ProfilePermition values into/on Database. Inserts if CRD_ProfilePermition doesn't exist or Updates if CRD_ProfilePermition already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_CRD_ProfilePermition CRD_ProfilePermition_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || CRD_ProfilePermition_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, CRD_ProfilePermition_in.IFProfile, 0), 
					_connection.newDBDataParameter("IFPermition_", DbType.Int64, ParameterDirection.Input, CRD_ProfilePermition_in.IFPermition, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_CRD_ProfilePermition_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[2].Value & 2) == 1);
				if (!ConstraintExist_out) {
					CRD_ProfilePermition_in.haschanges_ = false;
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
		#region private static SO_CRD_ProfilePermition[] getRecord(DataTable dataTable_in);
		private static SO_CRD_ProfilePermition[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifprofile = null;
			DataColumn _dc_ifpermition = null;

			SO_CRD_ProfilePermition[] _output 
				= new SO_CRD_ProfilePermition[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifprofile = dataTable_in.Columns["IFProfile"];
					_dc_ifpermition = dataTable_in.Columns["IFPermition"];
				}

				_output[r] = new SO_CRD_ProfilePermition();
				if (dataTable_in.Rows[r][_dc_ifprofile] == System.DBNull.Value) {
					_output[r].ifprofile_ = 0L;
				} else {
					_output[r].ifprofile_ = (long)dataTable_in.Rows[r][_dc_ifprofile];
				}
				if (dataTable_in.Rows[r][_dc_ifpermition] == System.DBNull.Value) {
					_output[r].ifpermition_ = 0L;
				} else {
					_output[r].ifpermition_ = (long)dataTable_in.Rows[r][_dc_ifpermition];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byProfile...
		#region public static SO_CRD_ProfilePermition[] getRecord_byProfile(...);
		/// <summary>
		/// Gets Record, based on 'byProfile' search. It selects CRD_ProfilePermition values from Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_CRD_ProfilePermition[] getRecord_byProfile(
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
		/// Gets Record, based on 'byProfile' search. It selects CRD_ProfilePermition values from Database based on the 'byProfile' search.
		/// </summary>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_CRD_ProfilePermition[] getRecord_byProfile(
			long IDProfile_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_CRD_ProfilePermition[] _output;

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
						? "sp0_CRD_ProfilePermition_Record_open_byProfile_page_fullmode"
						: "sp0_CRD_ProfilePermition_Record_open_byProfile_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byProfile(...);
		/// <summary>
		/// It selects CRD_ProfilePermition values from Database based on the 'byProfile' search and checks to see if CRD_ProfilePermition Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFProfile_in">CRD_ProfilePermition's IFProfile Key used for checking</param>
		/// <param name="IFPermition_in">CRD_ProfilePermition's IFPermition Key used for checking</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <returns>True if CRD_ProfilePermition Keys are met in the 'byProfile' search, False if not</returns>
		public static bool isObject_inRecord_byProfile(
			long IFProfile_in, 
			long IFPermition_in, 
			long IDProfile_search_in
		) {
			return isObject_inRecord_byProfile(
				IFProfile_in, 
				IFPermition_in, IDProfile_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects CRD_ProfilePermition values from Database based on the 'byProfile' search and checks to see if CRD_ProfilePermition Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFProfile_in">CRD_ProfilePermition's IFProfile Key used for checking</param>
		/// <param name="IFPermition_in">CRD_ProfilePermition's IFPermition Key used for checking</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if CRD_ProfilePermition Keys are met in the 'byProfile' search, False if not</returns>
		public static bool isObject_inRecord_byProfile(
			long IFProfile_in, 
			long IFPermition_in, 
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
				_connection.newDBDataParameter("IFPermition_", DbType.Int64, ParameterDirection.Input, IFPermition_in, 0), 
				_connection.newDBDataParameter("IDProfile_search_", DbType.Int64, ParameterDirection.Input, IDProfile_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_CRD_ProfilePermition_Record_hasObject_byProfile", 
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
		/// Count's number of search results from CRD_ProfilePermition at Database based on the 'byProfile' search.
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
		/// Count's number of search results from CRD_ProfilePermition at Database based on the 'byProfile' search.
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
				"fnc0_CRD_ProfilePermition_Record_count_byProfile", 
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
		/// Deletes CRD_ProfilePermition values from Database based on the 'byProfile' search.
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
		/// Deletes CRD_ProfilePermition values from Database based on the 'byProfile' search.
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
				"sp0_CRD_ProfilePermition_Record_delete_byProfile", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}