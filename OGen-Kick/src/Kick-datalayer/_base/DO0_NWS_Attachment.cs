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
	/// NWS_Attachment DataObject which provides access to NWS_Attachment's Database table.
	/// </summary>
	[DOClassAttribute("NWS_Attachment", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_NWS_Attachment 
#else
			DO_NWS_Attachment 
#endif
	{

	 	#region Methods...
		#region public static SO_NWS_Attachment getObject(...);
		/// <summary>
		/// Selects NWS_Attachment values from Database and assigns them to the appropriate DO0_NWS_Attachment property.
		/// </summary>
		/// <param name="IDAttachment_in">IDAttachment</param>
		/// <returns>null if NWS_Attachment doesn't exists at Database</returns>
		public static SO_NWS_Attachment getObject(
			long IDAttachment_in
		) {
			return getObject(
				IDAttachment_in, 
				null
			);
		}

		/// <summary>
		/// Selects NWS_Attachment values from Database and assigns them to the appropriate DO_NWS_Attachment property.
		/// </summary>
		/// <param name="IDAttachment_in">IDAttachment</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NWS_Attachment doesn't exists at Database</returns>
		public static SO_NWS_Attachment getObject(
			long IDAttachment_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_Attachment _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDAttachment_", DbType.Int64, ParameterDirection.InputOutput, IDAttachment_in, 0), 
				_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("GUID_", DbType.AnsiString, ParameterDirection.Output, null, 50), 
				_connection.newDBDataParameter("OrderNum_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("isImage_", DbType.Boolean, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("TX_Name_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("TX_Description_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("FileName_", DbType.AnsiString, ParameterDirection.Output, null, 255)
			};
			_connection.Execute_SQLFunction("sp0_NWS_Attachment_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NWS_Attachment();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDAttachment = 0L;
				} else {
					_output.IDAttachment = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFContent = 0L;
				} else {
					_output.IFContent = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.GUID = string.Empty;
				} else {
					_output.GUID = (string)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.OrderNum_isNull = true;
				} else {
					_output.OrderNum = (long)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.isImage = false;
				} else {
					_output.isImage = (bool)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.TX_Name_isNull = true;
				} else {
					_output.TX_Name = (long)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.TX_Description_isNull = true;
				} else {
					_output.TX_Description = (long)_dataparameters[6].Value;
				}
				if (_dataparameters[7].Value == System.DBNull.Value) {
					_output.FileName = string.Empty;
				} else {
					_output.FileName = (string)_dataparameters[7].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NWS_Attachment from Database.
		/// </summary>
		/// <param name="IDAttachment_in">IDAttachment</param>
		public static void delObject(
			long IDAttachment_in
		) {
			delObject(
				IDAttachment_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_Attachment from Database.
		/// </summary>
		/// <param name="IDAttachment_in">IDAttachment</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDAttachment_in, 
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
				_connection.newDBDataParameter("IDAttachment_", DbType.Int64, ParameterDirection.Input, IDAttachment_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_Attachment_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NWS_Attachment exists at Database
		/// </summary>
		/// <param name="IDAttachment_in">IDAttachment</param>
		/// <returns>True if NWS_Attachment exists at Database, False if not</returns>
		public static bool isObject(
			long IDAttachment_in
		) {
			return isObject(
				IDAttachment_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NWS_Attachment exists at Database
		/// </summary>
		/// <param name="IDAttachment_in">IDAttachment</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_Attachment exists at Database, False if not</returns>
		public static bool isObject(
			long IDAttachment_in, 
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
				_connection.newDBDataParameter("IDAttachment_", DbType.Int64, ParameterDirection.Input, IDAttachment_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_Attachment_isObject", 
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
		/// Inserts NWS_Attachment values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_NWS_Attachment NWS_Attachment_in, 
			bool selectIdentity_in
		) {
			return insObject(
				NWS_Attachment_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts NWS_Attachment values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_NWS_Attachment NWS_Attachment_in, 
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
				_connection.newDBDataParameter("IDAttachment_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.Input, NWS_Attachment_in.IFContent, 0), 
				_connection.newDBDataParameter("GUID_", DbType.AnsiString, ParameterDirection.Input, NWS_Attachment_in.GUID, 50), 
				_connection.newDBDataParameter("OrderNum_", DbType.Int64, ParameterDirection.Input, NWS_Attachment_in.OrderNum_isNull ? null : (object)NWS_Attachment_in.OrderNum, 0), 
				_connection.newDBDataParameter("isImage_", DbType.Boolean, ParameterDirection.Input, NWS_Attachment_in.isImage, 0), 
				_connection.newDBDataParameter("TX_Name_", DbType.Int64, ParameterDirection.Input, NWS_Attachment_in.TX_Name_isNull ? null : (object)NWS_Attachment_in.TX_Name, 0), 
				_connection.newDBDataParameter("TX_Description_", DbType.Int64, ParameterDirection.Input, NWS_Attachment_in.TX_Description_isNull ? null : (object)NWS_Attachment_in.TX_Description, 0), 
				_connection.newDBDataParameter("FileName_", DbType.AnsiString, ParameterDirection.Input, NWS_Attachment_in.FileName, 255), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_NWS_Attachment_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			NWS_Attachment_in.IDAttachment = (long)_dataparameters[0].Value;NWS_Attachment_in.haschanges_ = false;
			

			return NWS_Attachment_in.IDAttachment;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates NWS_Attachment values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_NWS_Attachment NWS_Attachment_in, 
			bool forceUpdate_in
		) {
			updObject(
				NWS_Attachment_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates NWS_Attachment values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_NWS_Attachment NWS_Attachment_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || NWS_Attachment_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDAttachment_", DbType.Int64, ParameterDirection.Input, NWS_Attachment_in.IDAttachment, 0), 
					_connection.newDBDataParameter("IFContent_", DbType.Int64, ParameterDirection.Input, NWS_Attachment_in.IFContent, 0), 
					_connection.newDBDataParameter("GUID_", DbType.AnsiString, ParameterDirection.Input, NWS_Attachment_in.GUID, 50), 
					_connection.newDBDataParameter("OrderNum_", DbType.Int64, ParameterDirection.Input, NWS_Attachment_in.OrderNum_isNull ? null : (object)NWS_Attachment_in.OrderNum, 0), 
					_connection.newDBDataParameter("isImage_", DbType.Boolean, ParameterDirection.Input, NWS_Attachment_in.isImage, 0), 
					_connection.newDBDataParameter("TX_Name_", DbType.Int64, ParameterDirection.Input, NWS_Attachment_in.TX_Name_isNull ? null : (object)NWS_Attachment_in.TX_Name, 0), 
					_connection.newDBDataParameter("TX_Description_", DbType.Int64, ParameterDirection.Input, NWS_Attachment_in.TX_Description_isNull ? null : (object)NWS_Attachment_in.TX_Description, 0), 
					_connection.newDBDataParameter("FileName_", DbType.AnsiString, ParameterDirection.Input, NWS_Attachment_in.FileName, 255)
				};
				_connection.Execute_SQLFunction(
					"sp0_NWS_Attachment_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				NWS_Attachment_in.haschanges_ = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_NWS_Attachment[] getRecord(DataTable dataTable_in);
		private static SO_NWS_Attachment[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idattachment = null;
			DataColumn _dc_ifcontent = null;
			DataColumn _dc_guid = null;
			DataColumn _dc_ordernum = null;
			DataColumn _dc_isimage = null;
			DataColumn _dc_tx_name = null;
			DataColumn _dc_tx_description = null;
			DataColumn _dc_filename = null;

			SO_NWS_Attachment[] _output 
				= new SO_NWS_Attachment[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idattachment = dataTable_in.Columns["IDAttachment"];
					_dc_ifcontent = dataTable_in.Columns["IFContent"];
					_dc_guid = dataTable_in.Columns["GUID"];
					_dc_ordernum = dataTable_in.Columns["OrderNum"];
					_dc_isimage = dataTable_in.Columns["isImage"];
					_dc_tx_name = dataTable_in.Columns["TX_Name"];
					_dc_tx_description = dataTable_in.Columns["TX_Description"];
					_dc_filename = dataTable_in.Columns["FileName"];
				}

				_output[r] = new SO_NWS_Attachment();
				if (dataTable_in.Rows[r][_dc_idattachment] == System.DBNull.Value) {
					_output[r].idattachment_ = 0L;
				} else {
					_output[r].idattachment_ = (long)dataTable_in.Rows[r][_dc_idattachment];
				}
				if (dataTable_in.Rows[r][_dc_ifcontent] == System.DBNull.Value) {
					_output[r].ifcontent_ = 0L;
				} else {
					_output[r].ifcontent_ = (long)dataTable_in.Rows[r][_dc_ifcontent];
				}
				if (dataTable_in.Rows[r][_dc_guid] == System.DBNull.Value) {
					_output[r].guid_ = string.Empty;
				} else {
					_output[r].guid_ = (string)dataTable_in.Rows[r][_dc_guid];
				}
				if (dataTable_in.Rows[r][_dc_ordernum] == System.DBNull.Value) {
					_output[r].OrderNum_isNull = true;
				} else {
					_output[r].ordernum_ = (long)dataTable_in.Rows[r][_dc_ordernum];
				}
				if (dataTable_in.Rows[r][_dc_isimage] == System.DBNull.Value) {
					_output[r].isimage_ = false;
				} else {
					_output[r].isimage_ = (bool)dataTable_in.Rows[r][_dc_isimage];
				}
				if (dataTable_in.Rows[r][_dc_tx_name] == System.DBNull.Value) {
					_output[r].TX_Name_isNull = true;
				} else {
					_output[r].tx_name_ = (long)dataTable_in.Rows[r][_dc_tx_name];
				}
				if (dataTable_in.Rows[r][_dc_tx_description] == System.DBNull.Value) {
					_output[r].TX_Description_isNull = true;
				} else {
					_output[r].tx_description_ = (long)dataTable_in.Rows[r][_dc_tx_description];
				}
				if (dataTable_in.Rows[r][_dc_filename] == System.DBNull.Value) {
					_output[r].filename_ = string.Empty;
				} else {
					_output[r].filename_ = (string)dataTable_in.Rows[r][_dc_filename];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_byContent...
		#region public static SO_NWS_Attachment[] getRecord_byContent(...);
		/// <summary>
		/// Gets Record, based on 'byContent' search. It selects NWS_Attachment values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IFContent_search_in">IFContent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_NWS_Attachment[] getRecord_byContent(
			long IFContent_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_byContent(
				IFContent_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'byContent' search. It selects NWS_Attachment values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IFContent_search_in">IFContent search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NWS_Attachment[] getRecord_byContent(
			long IFContent_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_Attachment[] _output;

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
						_connection.newDBDataParameter("IFContent_search_", DbType.Int64, ParameterDirection.Input, IFContent_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IFContent_search_", DbType.Int64, ParameterDirection.Input, IFContent_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_NWS_Attachment_Record_open_byContent_page_fullmode"
						: "sp0_NWS_Attachment_Record_open_byContent_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_byContent(...);
		/// <summary>
		/// It selects NWS_Attachment values from Database based on the 'byContent' search and checks to see if NWS_Attachment Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDAttachment_in">NWS_Attachment's IDAttachment Key used for checking</param>
		/// <param name="IFContent_search_in">IFContent search condition</param>
		/// <returns>True if NWS_Attachment Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IDAttachment_in, 
			long IFContent_search_in
		) {
			return isObject_inRecord_byContent(
				IDAttachment_in, IFContent_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NWS_Attachment values from Database based on the 'byContent' search and checks to see if NWS_Attachment Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDAttachment_in">NWS_Attachment's IDAttachment Key used for checking</param>
		/// <param name="IFContent_search_in">IFContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_Attachment Keys are met in the 'byContent' search, False if not</returns>
		public static bool isObject_inRecord_byContent(
			long IDAttachment_in, 
			long IFContent_search_in, 
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
				_connection.newDBDataParameter("IDAttachment_", DbType.Int64, ParameterDirection.Input, IDAttachment_in, 0), 
				_connection.newDBDataParameter("IFContent_search_", DbType.Int64, ParameterDirection.Input, IFContent_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_Attachment_Record_hasObject_byContent", 
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
		/// Count's number of search results from NWS_Attachment at Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IFContent_search_in">IFContent search condition</param>
		/// <returns>number of existing Records for the 'byContent' search</returns>
		public static long getCount_inRecord_byContent(
			long IFContent_search_in
		) {
			return getCount_inRecord_byContent(
				IFContent_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from NWS_Attachment at Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IFContent_search_in">IFContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'byContent' search</returns>
		public static long getCount_inRecord_byContent(
			long IFContent_search_in, 
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
				_connection.newDBDataParameter("IFContent_search_", DbType.Int64, ParameterDirection.Input, IFContent_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_NWS_Attachment_Record_count_byContent", 
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
		/// Deletes NWS_Attachment values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IFContent_search_in">IFContent search condition</param>
		public static void delRecord_byContent(
			long IFContent_search_in
		) {
			delRecord_byContent(
				IFContent_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_Attachment values from Database based on the 'byContent' search.
		/// </summary>
		/// <param name="IFContent_search_in">IFContent search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_byContent(
			long IFContent_search_in, 
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
				_connection.newDBDataParameter("IFContent_search_", DbType.Int64, ParameterDirection.Input, IFContent_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NWS_Attachment_Record_delete_byContent", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}