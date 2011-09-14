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
	/// DIC_TextLanguage DataObject which provides access to DIC_TextLanguage's Database table.
	/// </summary>
	[DOClassAttribute("DIC_TextLanguage", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_DIC_TextLanguage 
#else
			DO_DIC_TextLanguage 
#endif
	{

	 	#region Methods...
		#region public static SO_DIC_TextLanguage getObject(...);
		/// <summary>
		/// Selects DIC_TextLanguage values from Database and assigns them to the appropriate DO0_DIC_TextLanguage property.
		/// </summary>
		/// <param name="IFText_in">IFText</param>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <returns>null if DIC_TextLanguage doesn't exists at Database</returns>
		public static SO_DIC_TextLanguage getObject(
			long IFText_in, 
			int IFLanguage_in
		) {
			return getObject(
				IFText_in, 
				IFLanguage_in, 
				null
			);
		}

		/// <summary>
		/// Selects DIC_TextLanguage values from Database and assigns them to the appropriate DO_DIC_TextLanguage property.
		/// </summary>
		/// <param name="IFText_in">IFText</param>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if DIC_TextLanguage doesn't exists at Database</returns>
		public static SO_DIC_TextLanguage getObject(
			long IFText_in, 
			int IFLanguage_in, 
			DBConnection dbConnection_in
		) {
			SO_DIC_TextLanguage _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFText_", DbType.Int64, ParameterDirection.InputOutput, IFText_in, 0), 
				_connection.newDBDataParameter("IFLanguage_", DbType.Int32, ParameterDirection.InputOutput, IFLanguage_in, 0), 
				_connection.newDBDataParameter("CharVar8000_", DbType.AnsiString, ParameterDirection.Output, null, 8000), 
				_connection.newDBDataParameter("Text_", DbType.AnsiString, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_DIC_TextLanguage_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_DIC_TextLanguage();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFText = 0L;
				} else {
					_output.IFText = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFLanguage = 0;
				} else {
					_output.IFLanguage = (int)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.CharVar8000_isNull = true;
				} else {
					_output.CharVar8000 = (string)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.Text_isNull = true;
				} else {
					_output.Text = (string)_dataparameters[3].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes DIC_TextLanguage from Database.
		/// </summary>
		/// <param name="IFText_in">IFText</param>
		/// <param name="IFLanguage_in">IFLanguage</param>
		public static void delObject(
			long IFText_in, 
			int IFLanguage_in
		) {
			delObject(
				IFText_in, 
				IFLanguage_in, 
				null
			);
		}

		/// <summary>
		/// Deletes DIC_TextLanguage from Database.
		/// </summary>
		/// <param name="IFText_in">IFText</param>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFText_in, 
			int IFLanguage_in, 
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
				_connection.newDBDataParameter("IFText_", DbType.Int64, ParameterDirection.Input, IFText_in, 0), 
				_connection.newDBDataParameter("IFLanguage_", DbType.Int32, ParameterDirection.Input, IFLanguage_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_DIC_TextLanguage_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if DIC_TextLanguage exists at Database
		/// </summary>
		/// <param name="IFText_in">IFText</param>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <returns>True if DIC_TextLanguage exists at Database, False if not</returns>
		public static bool isObject(
			long IFText_in, 
			int IFLanguage_in
		) {
			return isObject(
				IFText_in, 
				IFLanguage_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if DIC_TextLanguage exists at Database
		/// </summary>
		/// <param name="IFText_in">IFText</param>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if DIC_TextLanguage exists at Database, False if not</returns>
		public static bool isObject(
			long IFText_in, 
			int IFLanguage_in, 
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
				_connection.newDBDataParameter("IFText_", DbType.Int64, ParameterDirection.Input, IFText_in, 0), 
				_connection.newDBDataParameter("IFLanguage_", DbType.Int32, ParameterDirection.Input, IFLanguage_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_DIC_TextLanguage_isObject", 
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
		/// Inserts/Updates DIC_TextLanguage values into/on Database. Inserts if DIC_TextLanguage doesn't exist or Updates if DIC_TextLanguage already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_DIC_TextLanguage DIC_TextLanguage_in, 
			bool forceUpdate_in
		) {
			return setObject(
				DIC_TextLanguage_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates DIC_TextLanguage values into/on Database. Inserts if DIC_TextLanguage doesn't exist or Updates if DIC_TextLanguage already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_DIC_TextLanguage DIC_TextLanguage_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || DIC_TextLanguage_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFText_", DbType.Int64, ParameterDirection.Input, DIC_TextLanguage_in.IFText, 0), 
					_connection.newDBDataParameter("IFLanguage_", DbType.Int32, ParameterDirection.Input, DIC_TextLanguage_in.IFLanguage, 0), 
					_connection.newDBDataParameter("CharVar8000_", DbType.AnsiString, ParameterDirection.Input, DIC_TextLanguage_in.CharVar8000_isNull ? null : (object)DIC_TextLanguage_in.CharVar8000, 8000), 
					_connection.newDBDataParameter("Text_", DbType.AnsiString, ParameterDirection.Input, DIC_TextLanguage_in.Text_isNull ? null : (object)DIC_TextLanguage_in.Text, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_DIC_TextLanguage_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[4].Value & 2) == 1);
				if (!ConstraintExist_out) {
					DIC_TextLanguage_in.haschanges_ = false;
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
		#region private static SO_DIC_TextLanguage[] getRecord(DataTable dataTable_in);
		private static SO_DIC_TextLanguage[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_iftext = null;
			DataColumn _dc_iflanguage = null;
			DataColumn _dc_charvar8000 = null;
			DataColumn _dc_text = null;

			SO_DIC_TextLanguage[] _output 
				= new SO_DIC_TextLanguage[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_iftext = dataTable_in.Columns["IFText"];
					_dc_iflanguage = dataTable_in.Columns["IFLanguage"];
					_dc_charvar8000 = dataTable_in.Columns["CharVar8000"];
					_dc_text = dataTable_in.Columns["Text"];
				}

				_output[r] = new SO_DIC_TextLanguage();
				if (dataTable_in.Rows[r][_dc_iftext] == System.DBNull.Value) {
					_output[r].iftext_ = 0L;
				} else {
					_output[r].iftext_ = (long)dataTable_in.Rows[r][_dc_iftext];
				}
				if (dataTable_in.Rows[r][_dc_iflanguage] == System.DBNull.Value) {
					_output[r].iflanguage_ = 0;
				} else {
					_output[r].iflanguage_ = (int)dataTable_in.Rows[r][_dc_iflanguage];
				}
				if (dataTable_in.Rows[r][_dc_charvar8000] == System.DBNull.Value) {
					_output[r].CharVar8000_isNull = true;
				} else {
					_output[r].charvar8000_ = (string)dataTable_in.Rows[r][_dc_charvar8000];
				}
				if (dataTable_in.Rows[r][_dc_text] == System.DBNull.Value) {
					_output[r].Text_isNull = true;
				} else {
					_output[r].text_ = (string)dataTable_in.Rows[r][_dc_text];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byText...
		#region public static SO_DIC_TextLanguage[] getRecord_byText(...);
		/// <summary>
		/// Gets Record, based on 'byText' search. It selects DIC_TextLanguage values from Database based on the 'byText' search.
		/// </summary>
		/// <param name="IFText_search_in">IFText search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_DIC_TextLanguage[] getRecord_byText(
			long IFText_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byText(
				IFText_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byText' search. It selects DIC_TextLanguage values from Database based on the 'byText' search.
		/// </summary>
		/// <param name="IFText_search_in">IFText search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_DIC_TextLanguage[] getRecord_byText(
			long IFText_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_DIC_TextLanguage[] _output;

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
						_connection.newDBDataParameter("IFText_search_", DbType.Int64, ParameterDirection.Input, IFText_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IFText_search_", DbType.Int64, ParameterDirection.Input, IFText_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_DIC_TextLanguage_Record_open_byText_page_fullmode"
						: "sp0_DIC_TextLanguage_Record_open_byText_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byText(...);
		/// <summary>
		/// It selects DIC_TextLanguage values from Database based on the 'byText' search and checks to see if DIC_TextLanguage Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFText_in">DIC_TextLanguage's IFText Key used for checking</param>
		/// <param name="IFLanguage_in">DIC_TextLanguage's IFLanguage Key used for checking</param>
		/// <param name="IFText_search_in">IFText search condition</param>
		/// <returns>True if DIC_TextLanguage Keys are met in the 'byText' search, False if not</returns>
		public static bool isObject_inRecord_byText(
			long IFText_in, 
			int IFLanguage_in, 
			long IFText_search_in
		) {
			return isObject_inRecord_byText(
				IFText_in, 
				IFLanguage_in, IFText_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects DIC_TextLanguage values from Database based on the 'byText' search and checks to see if DIC_TextLanguage Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IFText_in">DIC_TextLanguage's IFText Key used for checking</param>
		/// <param name="IFLanguage_in">DIC_TextLanguage's IFLanguage Key used for checking</param>
		/// <param name="IFText_search_in">IFText search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if DIC_TextLanguage Keys are met in the 'byText' search, False if not</returns>
		public static bool isObject_inRecord_byText(
			long IFText_in, 
			int IFLanguage_in, 
			long IFText_search_in, 
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
				_connection.newDBDataParameter("IFText_", DbType.Int64, ParameterDirection.Input, IFText_in, 0), 
				_connection.newDBDataParameter("IFLanguage_", DbType.Int32, ParameterDirection.Input, IFLanguage_in, 0), 
				_connection.newDBDataParameter("IFText_search_", DbType.Int64, ParameterDirection.Input, IFText_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_DIC_TextLanguage_Record_hasObject_byText", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_byText(...);
		/// <summary>
		/// Count's number of search results from DIC_TextLanguage at Database based on the 'byText' search.
		/// </summary>
		/// <param name="IFText_search_in">IFText search condition</param>
		/// <returns>number of existing Records for the 'byText' search</returns>
		public static long getCount_inRecord_byText(
			long IFText_search_in
		) {
			return getCount_inRecord_byText(
				IFText_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from DIC_TextLanguage at Database based on the 'byText' search.
		/// </summary>
		/// <param name="IFText_search_in">IFText search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byText' search</returns>
		public static long getCount_inRecord_byText(
			long IFText_search_in, 
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
				_connection.newDBDataParameter("IFText_search_", DbType.Int64, ParameterDirection.Input, IFText_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_DIC_TextLanguage_Record_count_byText", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static void delRecord_byText(...);
		/// <summary>
		/// Deletes DIC_TextLanguage values from Database based on the 'byText' search.
		/// </summary>
		/// <param name="IFText_search_in">IFText search condition</param>
		public static void delRecord_byText(
			long IFText_search_in
		) {
			delRecord_byText(
				IFText_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes DIC_TextLanguage values from Database based on the 'byText' search.
		/// </summary>
		/// <param name="IFText_search_in">IFText search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_byText(
			long IFText_search_in, 
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
				_connection.newDBDataParameter("IFText_search_", DbType.Int64, ParameterDirection.Input, IFText_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_DIC_TextLanguage_Record_delete_byText", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}