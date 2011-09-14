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
	/// LOG_Log DataObject which provides access to LOG_Log's Database table.
	/// </summary>
	[DOClassAttribute("LOG_Log", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_LOG_Log 
#else
			DO_LOG_Log 
#endif
	{

	 	#region Methods...
		#region public static SO_LOG_Log getObject(...);
		/// <summary>
		/// Selects LOG_Log values from Database and assigns them to the appropriate DO0_LOG_Log property.
		/// </summary>
		/// <param name="IDLog_in">IDLog</param>
		/// <returns>null if LOG_Log doesn't exists at Database</returns>
		public static SO_LOG_Log getObject(
			long IDLog_in
		) {
			return getObject(
				IDLog_in, 
				null
			);
		}

		/// <summary>
		/// Selects LOG_Log values from Database and assigns them to the appropriate DO_LOG_Log property.
		/// </summary>
		/// <param name="IDLog_in">IDLog</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if LOG_Log doesn't exists at Database</returns>
		public static SO_LOG_Log getObject(
			long IDLog_in, 
			DBConnection dbConnection_in
		) {
			SO_LOG_Log _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.InputOutput, IDLog_in, 0), 
				_connection.newDBDataParameter("IFLogtype_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser__read_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFErrortype_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Stamp_", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Stamp__read_", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Message_", DbType.AnsiString, ParameterDirection.Output, null, 4000), 
				_connection.newDBDataParameter("IFPermition_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFBrowser__OPT_", DbType.Int64, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_LOG_Log_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_LOG_Log();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDLog = 0L;
				} else {
					_output.IDLog = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFLogtype = 0;
				} else {
					_output.IFLogtype = (int)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IFUser_isNull = true;
				} else {
					_output.IFUser = (long)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.IFUser__read_isNull = true;
				} else {
					_output.IFUser__read = (long)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.IFErrortype_isNull = true;
				} else {
					_output.IFErrortype = (int)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.Stamp = new DateTime(1900, 1, 1);
				} else {
					_output.Stamp = (DateTime)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.Stamp__read_isNull = true;
				} else {
					_output.Stamp__read = (DateTime)_dataparameters[6].Value;
				}
				if (_dataparameters[7].Value == System.DBNull.Value) {
					_output.Message = string.Empty;
				} else {
					_output.Message = (string)_dataparameters[7].Value;
				}
				if (_dataparameters[8].Value == System.DBNull.Value) {
					_output.IFPermition_isNull = true;
				} else {
					_output.IFPermition = (long)_dataparameters[8].Value;
				}
				if (_dataparameters[9].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[9].Value;
				}
				if (_dataparameters[10].Value == System.DBNull.Value) {
					_output.IFBrowser__OPT_isNull = true;
				} else {
					_output.IFBrowser__OPT = (long)_dataparameters[10].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes LOG_Log from Database.
		/// </summary>
		/// <param name="IDLog_in">IDLog</param>
		public static void delObject(
			long IDLog_in
		) {
			delObject(
				IDLog_in, 
				null
			);
		}

		/// <summary>
		/// Deletes LOG_Log from Database.
		/// </summary>
		/// <param name="IDLog_in">IDLog</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDLog_in, 
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
				_connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.Input, IDLog_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_LOG_Log_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if LOG_Log exists at Database
		/// </summary>
		/// <param name="IDLog_in">IDLog</param>
		/// <returns>True if LOG_Log exists at Database, False if not</returns>
		public static bool isObject(
			long IDLog_in
		) {
			return isObject(
				IDLog_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if LOG_Log exists at Database
		/// </summary>
		/// <param name="IDLog_in">IDLog</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if LOG_Log exists at Database, False if not</returns>
		public static bool isObject(
			long IDLog_in, 
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
				_connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.Input, IDLog_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_LOG_Log_isObject", 
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
		/// Inserts LOG_Log values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_LOG_Log LOG_Log_in, 
			bool selectIdentity_in
		) {
			return insObject(
				LOG_Log_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts LOG_Log values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_LOG_Log LOG_Log_in, 
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
				_connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFLogtype_", DbType.Int32, ParameterDirection.Input, LOG_Log_in.IFLogtype, 0), 
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, LOG_Log_in.IFUser_isNull ? null : (object)LOG_Log_in.IFUser, 0), 
				_connection.newDBDataParameter("IFUser__read_", DbType.Int64, ParameterDirection.Input, LOG_Log_in.IFUser__read_isNull ? null : (object)LOG_Log_in.IFUser__read, 0), 
				_connection.newDBDataParameter("IFErrortype_", DbType.Int32, ParameterDirection.Input, LOG_Log_in.IFErrortype_isNull ? null : (object)LOG_Log_in.IFErrortype, 0), 
				_connection.newDBDataParameter("Stamp_", DbType.DateTime, ParameterDirection.Input, LOG_Log_in.Stamp, 0), 
				_connection.newDBDataParameter("Stamp__read_", DbType.DateTime, ParameterDirection.Input, LOG_Log_in.Stamp__read_isNull ? null : (object)LOG_Log_in.Stamp__read, 0), 
				_connection.newDBDataParameter("Message_", DbType.AnsiString, ParameterDirection.Input, LOG_Log_in.Message, 4000), 
				_connection.newDBDataParameter("IFPermition_", DbType.Int64, ParameterDirection.Input, LOG_Log_in.IFPermition_isNull ? null : (object)LOG_Log_in.IFPermition, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, LOG_Log_in.IFApplication_isNull ? null : (object)LOG_Log_in.IFApplication, 0), 
				_connection.newDBDataParameter("IFBrowser__OPT_", DbType.Int64, ParameterDirection.Input, LOG_Log_in.IFBrowser__OPT_isNull ? null : (object)LOG_Log_in.IFBrowser__OPT, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_LOG_Log_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			LOG_Log_in.IDLog = (long)_dataparameters[0].Value;LOG_Log_in.haschanges_ = false;
			

			return LOG_Log_in.IDLog;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates LOG_Log values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_LOG_Log LOG_Log_in, 
			bool forceUpdate_in
		) {
			updObject(
				LOG_Log_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates LOG_Log values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_LOG_Log LOG_Log_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || LOG_Log_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.Input, LOG_Log_in.IDLog, 0), 
					_connection.newDBDataParameter("IFLogtype_", DbType.Int32, ParameterDirection.Input, LOG_Log_in.IFLogtype, 0), 
					_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, LOG_Log_in.IFUser_isNull ? null : (object)LOG_Log_in.IFUser, 0), 
					_connection.newDBDataParameter("IFUser__read_", DbType.Int64, ParameterDirection.Input, LOG_Log_in.IFUser__read_isNull ? null : (object)LOG_Log_in.IFUser__read, 0), 
					_connection.newDBDataParameter("IFErrortype_", DbType.Int32, ParameterDirection.Input, LOG_Log_in.IFErrortype_isNull ? null : (object)LOG_Log_in.IFErrortype, 0), 
					_connection.newDBDataParameter("Stamp_", DbType.DateTime, ParameterDirection.Input, LOG_Log_in.Stamp, 0), 
					_connection.newDBDataParameter("Stamp__read_", DbType.DateTime, ParameterDirection.Input, LOG_Log_in.Stamp__read_isNull ? null : (object)LOG_Log_in.Stamp__read, 0), 
					_connection.newDBDataParameter("Message_", DbType.AnsiString, ParameterDirection.Input, LOG_Log_in.Message, 4000), 
					_connection.newDBDataParameter("IFPermition_", DbType.Int64, ParameterDirection.Input, LOG_Log_in.IFPermition_isNull ? null : (object)LOG_Log_in.IFPermition, 0), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, LOG_Log_in.IFApplication_isNull ? null : (object)LOG_Log_in.IFApplication, 0), 
					_connection.newDBDataParameter("IFBrowser__OPT_", DbType.Int64, ParameterDirection.Input, LOG_Log_in.IFBrowser__OPT_isNull ? null : (object)LOG_Log_in.IFBrowser__OPT, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_LOG_Log_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				LOG_Log_in.haschanges_ = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_LOG_Log[] getRecord(DataTable dataTable_in);
		private static SO_LOG_Log[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idlog = null;
			DataColumn _dc_iflogtype = null;
			DataColumn _dc_ifuser = null;
			DataColumn _dc_ifuser__read = null;
			DataColumn _dc_iferrortype = null;
			DataColumn _dc_stamp = null;
			DataColumn _dc_stamp__read = null;
			DataColumn _dc_message = null;
			DataColumn _dc_ifpermition = null;
			DataColumn _dc_ifapplication = null;
			DataColumn _dc_ifbrowser__opt = null;

			SO_LOG_Log[] _output 
				= new SO_LOG_Log[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idlog = dataTable_in.Columns["IDLog"];
					_dc_iflogtype = dataTable_in.Columns["IFLogtype"];
					_dc_ifuser = dataTable_in.Columns["IFUser"];
					_dc_ifuser__read = dataTable_in.Columns["IFUser__read"];
					_dc_iferrortype = dataTable_in.Columns["IFErrortype"];
					_dc_stamp = dataTable_in.Columns["Stamp"];
					_dc_stamp__read = dataTable_in.Columns["Stamp__read"];
					_dc_message = dataTable_in.Columns["Message"];
					_dc_ifpermition = dataTable_in.Columns["IFPermition"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
					_dc_ifbrowser__opt = dataTable_in.Columns["IFBrowser__OPT"];
				}

				_output[r] = new SO_LOG_Log();
				if (dataTable_in.Rows[r][_dc_idlog] == System.DBNull.Value) {
					_output[r].idlog_ = 0L;
				} else {
					_output[r].idlog_ = (long)dataTable_in.Rows[r][_dc_idlog];
				}
				if (dataTable_in.Rows[r][_dc_iflogtype] == System.DBNull.Value) {
					_output[r].iflogtype_ = 0;
				} else {
					_output[r].iflogtype_ = (int)dataTable_in.Rows[r][_dc_iflogtype];
				}
				if (dataTable_in.Rows[r][_dc_ifuser] == System.DBNull.Value) {
					_output[r].IFUser_isNull = true;
				} else {
					_output[r].ifuser_ = (long)dataTable_in.Rows[r][_dc_ifuser];
				}
				if (dataTable_in.Rows[r][_dc_ifuser__read] == System.DBNull.Value) {
					_output[r].IFUser__read_isNull = true;
				} else {
					_output[r].ifuser__read_ = (long)dataTable_in.Rows[r][_dc_ifuser__read];
				}
				if (dataTable_in.Rows[r][_dc_iferrortype] == System.DBNull.Value) {
					_output[r].IFErrortype_isNull = true;
				} else {
					_output[r].iferrortype_ = (int)dataTable_in.Rows[r][_dc_iferrortype];
				}
				if (dataTable_in.Rows[r][_dc_stamp] == System.DBNull.Value) {
					_output[r].stamp_ = new DateTime(1900, 1, 1);
				} else {
					_output[r].stamp_ = (DateTime)dataTable_in.Rows[r][_dc_stamp];
				}
				if (dataTable_in.Rows[r][_dc_stamp__read] == System.DBNull.Value) {
					_output[r].Stamp__read_isNull = true;
				} else {
					_output[r].stamp__read_ = (DateTime)dataTable_in.Rows[r][_dc_stamp__read];
				}
				if (dataTable_in.Rows[r][_dc_message] == System.DBNull.Value) {
					_output[r].message_ = string.Empty;
				} else {
					_output[r].message_ = (string)dataTable_in.Rows[r][_dc_message];
				}
				if (dataTable_in.Rows[r][_dc_ifpermition] == System.DBNull.Value) {
					_output[r].IFPermition_isNull = true;
				} else {
					_output[r].ifpermition_ = (long)dataTable_in.Rows[r][_dc_ifpermition];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication_isNull = true;
				} else {
					_output[r].ifapplication_ = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}
				if (dataTable_in.Rows[r][_dc_ifbrowser__opt] == System.DBNull.Value) {
					_output[r].IFBrowser__OPT_isNull = true;
				} else {
					_output[r].ifbrowser__opt_ = (long)dataTable_in.Rows[r][_dc_ifbrowser__opt];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_generic...
		#region public static SO_LOG_Log[] getRecord_generic(...);
		/// <summary>
		/// Gets Record, based on 'generic' search. It selects LOG_Log values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="IDLogtype_search_in">IDLogtype search condition</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="IDErrortype_search_in">IDErrortype search condition</param>
		/// <param name="Stamp_begin_search_in">Stamp_begin search condition</param>
		/// <param name="Stamp_end_search_in">Stamp_end search condition</param>
		/// <param name="Read_search_in">Read search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_LOG_Log[] getRecord_generic(
			int IDLogtype_search_in, 
			object IDUser_search_in, 
			object IDErrortype_search_in, 
			DateTime Stamp_begin_search_in, 
			DateTime Stamp_end_search_in, 
			object Read_search_in, 
			object IFApplication_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_generic(
				IDLogtype_search_in, 
				IDUser_search_in, 
				IDErrortype_search_in, 
				Stamp_begin_search_in, 
				Stamp_end_search_in, 
				Read_search_in, 
				IFApplication_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'generic' search. It selects LOG_Log values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="IDLogtype_search_in">IDLogtype search condition</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="IDErrortype_search_in">IDErrortype search condition</param>
		/// <param name="Stamp_begin_search_in">Stamp_begin search condition</param>
		/// <param name="Stamp_end_search_in">Stamp_end search condition</param>
		/// <param name="Read_search_in">Read search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_LOG_Log[] getRecord_generic(
			int IDLogtype_search_in, 
			object IDUser_search_in, 
			object IDErrortype_search_in, 
			DateTime Stamp_begin_search_in, 
			DateTime Stamp_end_search_in, 
			object Read_search_in, 
			object IFApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_LOG_Log[] _output;

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
						_connection.newDBDataParameter("IDLogtype_search_", DbType.Int32, ParameterDirection.Input, IDLogtype_search_in, 0), 
						_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
						_connection.newDBDataParameter("IDErrortype_search_", DbType.Int32, ParameterDirection.Input, IDErrortype_search_in, 0), 
						_connection.newDBDataParameter("Stamp_begin_search_", DbType.DateTime, ParameterDirection.Input, Stamp_begin_search_in, 0), 
						_connection.newDBDataParameter("Stamp_end_search_", DbType.DateTime, ParameterDirection.Input, Stamp_end_search_in, 0), 
						_connection.newDBDataParameter("Read_search_", DbType.Boolean, ParameterDirection.Input, Read_search_in, 0), 
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IDLogtype_search_", DbType.Int32, ParameterDirection.Input, IDLogtype_search_in, 0), 
						_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
						_connection.newDBDataParameter("IDErrortype_search_", DbType.Int32, ParameterDirection.Input, IDErrortype_search_in, 0), 
						_connection.newDBDataParameter("Stamp_begin_search_", DbType.DateTime, ParameterDirection.Input, Stamp_begin_search_in, 0), 
						_connection.newDBDataParameter("Stamp_end_search_", DbType.DateTime, ParameterDirection.Input, Stamp_end_search_in, 0), 
						_connection.newDBDataParameter("Read_search_", DbType.Boolean, ParameterDirection.Input, Read_search_in, 0), 
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_LOG_Log_Record_open_generic_page_fullmode"
						: "sp0_LOG_Log_Record_open_generic_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_generic(...);
		/// <summary>
		/// It selects LOG_Log values from Database based on the 'generic' search and checks to see if LOG_Log Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDLog_in">LOG_Log's IDLog Key used for checking</param>
		/// <param name="IDLogtype_search_in">IDLogtype search condition</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="IDErrortype_search_in">IDErrortype search condition</param>
		/// <param name="Stamp_begin_search_in">Stamp_begin search condition</param>
		/// <param name="Stamp_end_search_in">Stamp_end search condition</param>
		/// <param name="Read_search_in">Read search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <returns>True if LOG_Log Keys are met in the 'generic' search, False if not</returns>
		public static bool isObject_inRecord_generic(
			long IDLog_in, 
			int IDLogtype_search_in, 
			object IDUser_search_in, 
			object IDErrortype_search_in, 
			DateTime Stamp_begin_search_in, 
			DateTime Stamp_end_search_in, 
			object Read_search_in, 
			object IFApplication_search_in
		) {
			return isObject_inRecord_generic(
				IDLog_in, IDLogtype_search_in, IDUser_search_in, IDErrortype_search_in, Stamp_begin_search_in, Stamp_end_search_in, Read_search_in, IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects LOG_Log values from Database based on the 'generic' search and checks to see if LOG_Log Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDLog_in">LOG_Log's IDLog Key used for checking</param>
		/// <param name="IDLogtype_search_in">IDLogtype search condition</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="IDErrortype_search_in">IDErrortype search condition</param>
		/// <param name="Stamp_begin_search_in">Stamp_begin search condition</param>
		/// <param name="Stamp_end_search_in">Stamp_end search condition</param>
		/// <param name="Read_search_in">Read search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if LOG_Log Keys are met in the 'generic' search, False if not</returns>
		public static bool isObject_inRecord_generic(
			long IDLog_in, 
			int IDLogtype_search_in, 
			object IDUser_search_in, 
			object IDErrortype_search_in, 
			DateTime Stamp_begin_search_in, 
			DateTime Stamp_end_search_in, 
			object Read_search_in, 
			object IFApplication_search_in, 
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
				_connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.Input, IDLog_in, 0), 
				_connection.newDBDataParameter("IDLogtype_search_", DbType.Int32, ParameterDirection.Input, IDLogtype_search_in, 0), 
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
				_connection.newDBDataParameter("IDErrortype_search_", DbType.Int32, ParameterDirection.Input, IDErrortype_search_in, 0), 
				_connection.newDBDataParameter("Stamp_begin_search_", DbType.DateTime, ParameterDirection.Input, Stamp_begin_search_in, 0), 
				_connection.newDBDataParameter("Stamp_end_search_", DbType.DateTime, ParameterDirection.Input, Stamp_end_search_in, 0), 
				_connection.newDBDataParameter("Read_search_", DbType.Boolean, ParameterDirection.Input, Read_search_in, 0), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_LOG_Log_Record_hasObject_generic", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_generic(...);
		/// <summary>
		/// Count's number of search results from LOG_Log at Database based on the 'generic' search.
		/// </summary>
		/// <param name="IDLogtype_search_in">IDLogtype search condition</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="IDErrortype_search_in">IDErrortype search condition</param>
		/// <param name="Stamp_begin_search_in">Stamp_begin search condition</param>
		/// <param name="Stamp_end_search_in">Stamp_end search condition</param>
		/// <param name="Read_search_in">Read search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <returns>number of existing Records for the 'generic' search</returns>
		public static long getCount_inRecord_generic(
			int IDLogtype_search_in, 
			object IDUser_search_in, 
			object IDErrortype_search_in, 
			DateTime Stamp_begin_search_in, 
			DateTime Stamp_end_search_in, 
			object Read_search_in, 
			object IFApplication_search_in
		) {
			return getCount_inRecord_generic(
				IDLogtype_search_in, 
				IDUser_search_in, 
				IDErrortype_search_in, 
				Stamp_begin_search_in, 
				Stamp_end_search_in, 
				Read_search_in, 
				IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from LOG_Log at Database based on the 'generic' search.
		/// </summary>
		/// <param name="IDLogtype_search_in">IDLogtype search condition</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="IDErrortype_search_in">IDErrortype search condition</param>
		/// <param name="Stamp_begin_search_in">Stamp_begin search condition</param>
		/// <param name="Stamp_end_search_in">Stamp_end search condition</param>
		/// <param name="Read_search_in">Read search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'generic' search</returns>
		public static long getCount_inRecord_generic(
			int IDLogtype_search_in, 
			object IDUser_search_in, 
			object IDErrortype_search_in, 
			DateTime Stamp_begin_search_in, 
			DateTime Stamp_end_search_in, 
			object Read_search_in, 
			object IFApplication_search_in, 
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
				_connection.newDBDataParameter("IDLogtype_search_", DbType.Int32, ParameterDirection.Input, IDLogtype_search_in, 0), 
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
				_connection.newDBDataParameter("IDErrortype_search_", DbType.Int32, ParameterDirection.Input, IDErrortype_search_in, 0), 
				_connection.newDBDataParameter("Stamp_begin_search_", DbType.DateTime, ParameterDirection.Input, Stamp_begin_search_in, 0), 
				_connection.newDBDataParameter("Stamp_end_search_", DbType.DateTime, ParameterDirection.Input, Stamp_end_search_in, 0), 
				_connection.newDBDataParameter("Read_search_", DbType.Boolean, ParameterDirection.Input, Read_search_in, 0), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_LOG_Log_Record_count_generic", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_generic(...);
		/// <summary>
		/// Deletes LOG_Log values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="IDLogtype_search_in">IDLogtype search condition</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="IDErrortype_search_in">IDErrortype search condition</param>
		/// <param name="Stamp_begin_search_in">Stamp_begin search condition</param>
		/// <param name="Stamp_end_search_in">Stamp_end search condition</param>
		/// <param name="Read_search_in">Read search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		public static void delRecord_generic(
			int IDLogtype_search_in, 
			object IDUser_search_in, 
			object IDErrortype_search_in, 
			DateTime Stamp_begin_search_in, 
			DateTime Stamp_end_search_in, 
			object Read_search_in, 
			object IFApplication_search_in
		) {
			delRecord_generic(
				IDLogtype_search_in, 
				IDUser_search_in, 
				IDErrortype_search_in, 
				Stamp_begin_search_in, 
				Stamp_end_search_in, 
				Read_search_in, 
				IFApplication_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes LOG_Log values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="IDLogtype_search_in">IDLogtype search condition</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="IDErrortype_search_in">IDErrortype search condition</param>
		/// <param name="Stamp_begin_search_in">Stamp_begin search condition</param>
		/// <param name="Stamp_end_search_in">Stamp_end search condition</param>
		/// <param name="Read_search_in">Read search condition</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_generic(
			int IDLogtype_search_in, 
			object IDUser_search_in, 
			object IDErrortype_search_in, 
			DateTime Stamp_begin_search_in, 
			DateTime Stamp_end_search_in, 
			object Read_search_in, 
			object IFApplication_search_in, 
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
				_connection.newDBDataParameter("IDLogtype_search_", DbType.Int32, ParameterDirection.Input, IDLogtype_search_in, 0), 
				_connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
				_connection.newDBDataParameter("IDErrortype_search_", DbType.Int32, ParameterDirection.Input, IDErrortype_search_in, 0), 
				_connection.newDBDataParameter("Stamp_begin_search_", DbType.DateTime, ParameterDirection.Input, Stamp_begin_search_in, 0), 
				_connection.newDBDataParameter("Stamp_end_search_", DbType.DateTime, ParameterDirection.Input, Stamp_end_search_in, 0), 
				_connection.newDBDataParameter("Read_search_", DbType.Boolean, ParameterDirection.Input, Read_search_in, 0), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_LOG_Log_Record_delete_generic", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}