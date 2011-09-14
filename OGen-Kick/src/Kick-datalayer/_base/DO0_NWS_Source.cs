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
	/// NWS_Source DataObject which provides access to NWS_Source's Database table.
	/// </summary>
	[DOClassAttribute("NWS_Source", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_NWS_Source 
#else
			DO_NWS_Source 
#endif
	{

	 	#region Methods...
		#region public static SO_NWS_Source getObject(...);
		/// <summary>
		/// Selects NWS_Source values from Database and assigns them to the appropriate DO0_NWS_Source property.
		/// </summary>
		/// <param name="IDSource_in">IDSource</param>
		/// <returns>null if NWS_Source doesn't exists at Database</returns>
		public static SO_NWS_Source getObject(
			long IDSource_in
		) {
			return getObject(
				IDSource_in, 
				null
			);
		}

		/// <summary>
		/// Selects NWS_Source values from Database and assigns them to the appropriate DO_NWS_Source property.
		/// </summary>
		/// <param name="IDSource_in">IDSource</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NWS_Source doesn't exists at Database</returns>
		public static SO_NWS_Source getObject(
			long IDSource_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_Source _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDSource_", DbType.Int64, ParameterDirection.InputOutput, IDSource_in, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFSource__parent_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("IFUser__Approved_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Approved_date_", DbType.DateTime, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_Source_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NWS_Source();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDSource = 0L;
				} else {
					_output.IDSource = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IFSource__parent_isNull = true;
				} else {
					_output.IFSource__parent = (long)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.Name = string.Empty;
				} else {
					_output.Name = (string)_dataparameters[3].Value;
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

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NWS_Source from Database.
		/// </summary>
		/// <param name="IDSource_in">IDSource</param>
		public static void delObject(
			long IDSource_in
		) {
			delObject(
				IDSource_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_Source from Database.
		/// </summary>
		/// <param name="IDSource_in">IDSource</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDSource_in, 
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
				_connection.newDBDataParameter("IDSource_", DbType.Int64, ParameterDirection.Input, IDSource_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_Source_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NWS_Source exists at Database
		/// </summary>
		/// <param name="IDSource_in">IDSource</param>
		/// <returns>True if NWS_Source exists at Database, False if not</returns>
		public static bool isObject(
			long IDSource_in
		) {
			return isObject(
				IDSource_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NWS_Source exists at Database
		/// </summary>
		/// <param name="IDSource_in">IDSource</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_Source exists at Database, False if not</returns>
		public static bool isObject(
			long IDSource_in, 
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
				_connection.newDBDataParameter("IDSource_", DbType.Int64, ParameterDirection.Input, IDSource_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_Source_isObject", 
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
		/// Inserts NWS_Source values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_NWS_Source NWS_Source_in, 
			bool selectIdentity_in
		) {
			return insObject(
				NWS_Source_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts NWS_Source values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_NWS_Source NWS_Source_in, 
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
				_connection.newDBDataParameter("IDSource_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, NWS_Source_in.IFApplication_isNull ? null : (object)NWS_Source_in.IFApplication, 0), 
				_connection.newDBDataParameter("IFSource__parent_", DbType.Int64, ParameterDirection.Input, NWS_Source_in.IFSource__parent_isNull ? null : (object)NWS_Source_in.IFSource__parent, 0), 
				_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, NWS_Source_in.Name, 255), 
				_connection.newDBDataParameter("IFUser__Approved_", DbType.Int64, ParameterDirection.Input, NWS_Source_in.IFUser__Approved_isNull ? null : (object)NWS_Source_in.IFUser__Approved, 0), 
				_connection.newDBDataParameter("Approved_date_", DbType.DateTime, ParameterDirection.Input, NWS_Source_in.Approved_date_isNull ? null : (object)NWS_Source_in.Approved_date, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_NWS_Source_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			NWS_Source_in.IDSource = (long)_dataparameters[0].Value;NWS_Source_in.haschanges_ = false;
			

			return NWS_Source_in.IDSource;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates NWS_Source values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_NWS_Source NWS_Source_in, 
			bool forceUpdate_in
		) {
			updObject(
				NWS_Source_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates NWS_Source values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_NWS_Source NWS_Source_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || NWS_Source_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDSource_", DbType.Int64, ParameterDirection.Input, NWS_Source_in.IDSource, 0), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, NWS_Source_in.IFApplication_isNull ? null : (object)NWS_Source_in.IFApplication, 0), 
					_connection.newDBDataParameter("IFSource__parent_", DbType.Int64, ParameterDirection.Input, NWS_Source_in.IFSource__parent_isNull ? null : (object)NWS_Source_in.IFSource__parent, 0), 
					_connection.newDBDataParameter("Name_", DbType.AnsiString, ParameterDirection.Input, NWS_Source_in.Name, 255), 
					_connection.newDBDataParameter("IFUser__Approved_", DbType.Int64, ParameterDirection.Input, NWS_Source_in.IFUser__Approved_isNull ? null : (object)NWS_Source_in.IFUser__Approved, 0), 
					_connection.newDBDataParameter("Approved_date_", DbType.DateTime, ParameterDirection.Input, NWS_Source_in.Approved_date_isNull ? null : (object)NWS_Source_in.Approved_date, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NWS_Source_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				NWS_Source_in.haschanges_ = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_NWS_Source[] getRecord(DataTable dataTable_in);
		private static SO_NWS_Source[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idsource = null;
			DataColumn _dc_ifapplication = null;
			DataColumn _dc_ifsource__parent = null;
			DataColumn _dc_name = null;
			DataColumn _dc_ifuser__approved = null;
			DataColumn _dc_approved_date = null;

			SO_NWS_Source[] _output 
				= new SO_NWS_Source[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idsource = dataTable_in.Columns["IDSource"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
					_dc_ifsource__parent = dataTable_in.Columns["IFSource__parent"];
					_dc_name = dataTable_in.Columns["Name"];
					_dc_ifuser__approved = dataTable_in.Columns["IFUser__Approved"];
					_dc_approved_date = dataTable_in.Columns["Approved_date"];
				}

				_output[r] = new SO_NWS_Source();
				if (dataTable_in.Rows[r][_dc_idsource] == System.DBNull.Value) {
					_output[r].idsource_ = 0L;
				} else {
					_output[r].idsource_ = (long)dataTable_in.Rows[r][_dc_idsource];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication_isNull = true;
				} else {
					_output[r].ifapplication_ = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}
				if (dataTable_in.Rows[r][_dc_ifsource__parent] == System.DBNull.Value) {
					_output[r].IFSource__parent_isNull = true;
				} else {
					_output[r].ifsource__parent_ = (long)dataTable_in.Rows[r][_dc_ifsource__parent];
				}
				if (dataTable_in.Rows[r][_dc_name] == System.DBNull.Value) {
					_output[r].name_ = string.Empty;
				} else {
					_output[r].name_ = (string)dataTable_in.Rows[r][_dc_name];
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

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byParent...
		#region public static SO_NWS_Source[] getRecord_byParent(...);
		/// <summary>
		/// Gets Record, based on 'byParent' search. It selects NWS_Source values from Database based on the 'byParent' search.
		/// </summary>
		/// <param name="IDSource__parent_search_in">IDSource__parent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_NWS_Source[] getRecord_byParent(
			object IDSource__parent_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byParent(
				IDSource__parent_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byParent' search. It selects NWS_Source values from Database based on the 'byParent' search.
		/// </summary>
		/// <param name="IDSource__parent_search_in">IDSource__parent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NWS_Source[] getRecord_byParent(
			object IDSource__parent_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_Source[] _output;

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
						_connection.newDBDataParameter("IDSource__parent_search_", DbType.Int64, ParameterDirection.Input, IDSource__parent_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDSource__parent_search_", DbType.Int64, ParameterDirection.Input, IDSource__parent_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_NWS_Source_Record_open_byParent_page_fullmode"
						: "sp0_NWS_Source_Record_open_byParent_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byParent(...);
		/// <summary>
		/// It selects NWS_Source values from Database based on the 'byParent' search and checks to see if NWS_Source Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDSource_in">NWS_Source's IDSource Key used for checking</param>
		/// <param name="IDSource__parent_search_in">IDSource__parent search condition</param>
		/// <returns>True if NWS_Source Keys are met in the 'byParent' search, False if not</returns>
		public static bool isObject_inRecord_byParent(
			long IDSource_in, 
			object IDSource__parent_search_in
		) {
			return isObject_inRecord_byParent(
				IDSource_in, IDSource__parent_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NWS_Source values from Database based on the 'byParent' search and checks to see if NWS_Source Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDSource_in">NWS_Source's IDSource Key used for checking</param>
		/// <param name="IDSource__parent_search_in">IDSource__parent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_Source Keys are met in the 'byParent' search, False if not</returns>
		public static bool isObject_inRecord_byParent(
			long IDSource_in, 
			object IDSource__parent_search_in, 
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
				_connection.newDBDataParameter("IDSource_", DbType.Int64, ParameterDirection.Input, IDSource_in, 0), 
				_connection.newDBDataParameter("IDSource__parent_search_", DbType.Int64, ParameterDirection.Input, IDSource__parent_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_Source_Record_hasObject_byParent", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byParent(...);
		/// <summary>
		/// Count's number of search results from NWS_Source at Database based on the 'byParent' search.
		/// </summary>
		/// <param name="IDSource__parent_search_in">IDSource__parent search condition</param>
		/// <returns>number of existing Records for the 'byParent' search</returns>
		public static long getCount_inRecord_byParent(
			object IDSource__parent_search_in
		) {
			return getCount_inRecord_byParent(
				IDSource__parent_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from NWS_Source at Database based on the 'byParent' search.
		/// </summary>
		/// <param name="IDSource__parent_search_in">IDSource__parent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byParent' search</returns>
		public static long getCount_inRecord_byParent(
			object IDSource__parent_search_in, 
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
				_connection.newDBDataParameter("IDSource__parent_search_", DbType.Int64, ParameterDirection.Input, IDSource__parent_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_NWS_Source_Record_count_byParent", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_byParent(...);
		/// <summary>
		/// Deletes NWS_Source values from Database based on the 'byParent' search.
		/// </summary>
		/// <param name="IDSource__parent_search_in">IDSource__parent search condition</param>
		public static void delRecord_byParent(
			object IDSource__parent_search_in
		) {
			delRecord_byParent(
				IDSource__parent_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_Source values from Database based on the 'byParent' search.
		/// </summary>
		/// <param name="IDSource__parent_search_in">IDSource__parent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_byParent(
			object IDSource__parent_search_in, 
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
				_connection.newDBDataParameter("IDSource__parent_search_", DbType.Int64, ParameterDirection.Input, IDSource__parent_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NWS_Source_Record_delete_byParent", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}