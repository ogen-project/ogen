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
	/// NWS_Content DataObject which provides access to NWS_Content's Database table.
	/// </summary>
	[DOClassAttribute("NWS_Content", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_NWS_Content 
#else
			DO_NWS_Content 
#endif
	{

	 	#region Methods...
		#region public static SO_NWS_Content getObject(...);
		/// <summary>
		/// Selects NWS_Content values from Database and assigns them to the appropriate DO0_NWS_Content property.
		/// </summary>
		/// <param name="IDContent_in">IDContent</param>
		/// <returns>null if NWS_Content doesn't exists at Database</returns>
		public static SO_NWS_Content getObject(
			long IDContent_in
		) {
			return getObject(
				IDContent_in, 
				null
			);
		}

		/// <summary>
		/// Selects NWS_Content values from Database and assigns them to the appropriate DO_NWS_Content property.
		/// </summary>
		/// <param name="IDContent_in">IDContent</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NWS_Content doesn't exists at Database</returns>
		public static SO_NWS_Content getObject(
			long IDContent_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_Content _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDContent_", DbType.Int64, ParameterDirection.InputOutput, IDContent_in, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Publish_date_", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser__Aproved_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Aproved_date_", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Begin_date_", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("End_date_", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("TX_Title_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("TX_Content_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("tx_subtitle_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("tx_summary_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Newslettersent_date_", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("isNews_notForum_", DbType.Boolean, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_Content_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NWS_Content();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDContent = 0L;
				} else {
					_output.IDContent = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.IFUser__Publisher = 0L;
				} else {
					_output.IFUser__Publisher = (long)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.Publish_date = new DateTime(1900, 1, 1);
				} else {
					_output.Publish_date = (DateTime)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.IFUser__Aproved_isNull = true;
				} else {
					_output.IFUser__Aproved = (long)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.Aproved_date_isNull = true;
				} else {
					_output.Aproved_date = (DateTime)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.Begin_date_isNull = true;
				} else {
					_output.Begin_date = (DateTime)_dataparameters[6].Value;
				}
				if (_dataparameters[7].Value == System.DBNull.Value) {
					_output.End_date_isNull = true;
				} else {
					_output.End_date = (DateTime)_dataparameters[7].Value;
				}
				if (_dataparameters[8].Value == System.DBNull.Value) {
					_output.TX_Title_isNull = true;
				} else {
					_output.TX_Title = (long)_dataparameters[8].Value;
				}
				if (_dataparameters[9].Value == System.DBNull.Value) {
					_output.TX_Content_isNull = true;
				} else {
					_output.TX_Content = (long)_dataparameters[9].Value;
				}
				if (_dataparameters[10].Value == System.DBNull.Value) {
					_output.tx_subtitle_isNull = true;
				} else {
					_output.tx_subtitle = (long)_dataparameters[10].Value;
				}
				if (_dataparameters[11].Value == System.DBNull.Value) {
					_output.tx_summary_isNull = true;
				} else {
					_output.tx_summary = (long)_dataparameters[11].Value;
				}
				if (_dataparameters[12].Value == System.DBNull.Value) {
					_output.Newslettersent_date_isNull = true;
				} else {
					_output.Newslettersent_date = (DateTime)_dataparameters[12].Value;
				}
				if (_dataparameters[13].Value == System.DBNull.Value) {
					_output.isNews_notForum_isNull = true;
				} else {
					_output.isNews_notForum = (bool)_dataparameters[13].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NWS_Content from Database.
		/// </summary>
		/// <param name="IDContent_in">IDContent</param>
		public static void delObject(
			long IDContent_in
		) {
			delObject(
				IDContent_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_Content from Database.
		/// </summary>
		/// <param name="IDContent_in">IDContent</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDContent_in, 
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
				_connection.newDBDataParameter("IDContent_", DbType.Int64, ParameterDirection.Input, IDContent_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_Content_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NWS_Content exists at Database
		/// </summary>
		/// <param name="IDContent_in">IDContent</param>
		/// <returns>True if NWS_Content exists at Database, False if not</returns>
		public static bool isObject(
			long IDContent_in
		) {
			return isObject(
				IDContent_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NWS_Content exists at Database
		/// </summary>
		/// <param name="IDContent_in">IDContent</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_Content exists at Database, False if not</returns>
		public static bool isObject(
			long IDContent_in, 
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
				_connection.newDBDataParameter("IDContent_", DbType.Int64, ParameterDirection.Input, IDContent_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_Content_isObject", 
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
		/// Inserts NWS_Content values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_NWS_Content NWS_Content_in, 
			bool selectIdentity_in
		) {
			return insObject(
				NWS_Content_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts NWS_Content values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_NWS_Content NWS_Content_in, 
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
				_connection.newDBDataParameter("IDContent_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, NWS_Content_in.IFApplication_isNull ? null : (object)NWS_Content_in.IFApplication, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.IFUser__Publisher, 0), 
				_connection.newDBDataParameter("Publish_date_", DbType.DateTime, ParameterDirection.Input, NWS_Content_in.Publish_date, 0), 
				_connection.newDBDataParameter("IFUser__Aproved_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.IFUser__Aproved_isNull ? null : (object)NWS_Content_in.IFUser__Aproved, 0), 
				_connection.newDBDataParameter("Aproved_date_", DbType.DateTime, ParameterDirection.Input, NWS_Content_in.Aproved_date_isNull ? null : (object)NWS_Content_in.Aproved_date, 0), 
				_connection.newDBDataParameter("Begin_date_", DbType.DateTime, ParameterDirection.Input, NWS_Content_in.Begin_date_isNull ? null : (object)NWS_Content_in.Begin_date, 0), 
				_connection.newDBDataParameter("End_date_", DbType.DateTime, ParameterDirection.Input, NWS_Content_in.End_date_isNull ? null : (object)NWS_Content_in.End_date, 0), 
				_connection.newDBDataParameter("TX_Title_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.TX_Title_isNull ? null : (object)NWS_Content_in.TX_Title, 0), 
				_connection.newDBDataParameter("TX_Content_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.TX_Content_isNull ? null : (object)NWS_Content_in.TX_Content, 0), 
				_connection.newDBDataParameter("tx_subtitle_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.tx_subtitle_isNull ? null : (object)NWS_Content_in.tx_subtitle, 0), 
				_connection.newDBDataParameter("tx_summary_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.tx_summary_isNull ? null : (object)NWS_Content_in.tx_summary, 0), 
				_connection.newDBDataParameter("Newslettersent_date_", DbType.DateTime, ParameterDirection.Input, NWS_Content_in.Newslettersent_date_isNull ? null : (object)NWS_Content_in.Newslettersent_date, 0), 
				_connection.newDBDataParameter("isNews_notForum_", DbType.Boolean, ParameterDirection.Input, NWS_Content_in.isNews_notForum_isNull ? null : (object)NWS_Content_in.isNews_notForum, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_NWS_Content_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			NWS_Content_in.IDContent = (long)_dataparameters[0].Value;NWS_Content_in.haschanges_ = false;
			

			return NWS_Content_in.IDContent;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates NWS_Content values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_NWS_Content NWS_Content_in, 
			bool forceUpdate_in
		) {
			updObject(
				NWS_Content_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates NWS_Content values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_NWS_Content NWS_Content_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || NWS_Content_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDContent_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.IDContent, 0), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, NWS_Content_in.IFApplication_isNull ? null : (object)NWS_Content_in.IFApplication, 0), 
					_connection.newDBDataParameter("IFUser__Publisher_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.IFUser__Publisher, 0), 
					_connection.newDBDataParameter("Publish_date_", DbType.DateTime, ParameterDirection.Input, NWS_Content_in.Publish_date, 0), 
					_connection.newDBDataParameter("IFUser__Aproved_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.IFUser__Aproved_isNull ? null : (object)NWS_Content_in.IFUser__Aproved, 0), 
					_connection.newDBDataParameter("Aproved_date_", DbType.DateTime, ParameterDirection.Input, NWS_Content_in.Aproved_date_isNull ? null : (object)NWS_Content_in.Aproved_date, 0), 
					_connection.newDBDataParameter("Begin_date_", DbType.DateTime, ParameterDirection.Input, NWS_Content_in.Begin_date_isNull ? null : (object)NWS_Content_in.Begin_date, 0), 
					_connection.newDBDataParameter("End_date_", DbType.DateTime, ParameterDirection.Input, NWS_Content_in.End_date_isNull ? null : (object)NWS_Content_in.End_date, 0), 
					_connection.newDBDataParameter("TX_Title_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.TX_Title_isNull ? null : (object)NWS_Content_in.TX_Title, 0), 
					_connection.newDBDataParameter("TX_Content_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.TX_Content_isNull ? null : (object)NWS_Content_in.TX_Content, 0), 
					_connection.newDBDataParameter("tx_subtitle_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.tx_subtitle_isNull ? null : (object)NWS_Content_in.tx_subtitle, 0), 
					_connection.newDBDataParameter("tx_summary_", DbType.Int64, ParameterDirection.Input, NWS_Content_in.tx_summary_isNull ? null : (object)NWS_Content_in.tx_summary, 0), 
					_connection.newDBDataParameter("Newslettersent_date_", DbType.DateTime, ParameterDirection.Input, NWS_Content_in.Newslettersent_date_isNull ? null : (object)NWS_Content_in.Newslettersent_date, 0), 
					_connection.newDBDataParameter("isNews_notForum_", DbType.Boolean, ParameterDirection.Input, NWS_Content_in.isNews_notForum_isNull ? null : (object)NWS_Content_in.isNews_notForum, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NWS_Content_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				NWS_Content_in.haschanges_ = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_NWS_Content[] getRecord(DataTable dataTable_in);
		private static SO_NWS_Content[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idcontent = null;
			DataColumn _dc_ifapplication = null;
			DataColumn _dc_ifuser__publisher = null;
			DataColumn _dc_publish_date = null;
			DataColumn _dc_ifuser__aproved = null;
			DataColumn _dc_aproved_date = null;
			DataColumn _dc_begin_date = null;
			DataColumn _dc_end_date = null;
			DataColumn _dc_tx_title = null;
			DataColumn _dc_tx_content = null;
			DataColumn _dc_tx_subtitle = null;
			DataColumn _dc_tx_summary = null;
			DataColumn _dc_newslettersent_date = null;
			DataColumn _dc_isnews_notforum = null;

			SO_NWS_Content[] _output 
				= new SO_NWS_Content[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idcontent = dataTable_in.Columns["IDContent"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
					_dc_ifuser__publisher = dataTable_in.Columns["IFUser__Publisher"];
					_dc_publish_date = dataTable_in.Columns["Publish_date"];
					_dc_ifuser__aproved = dataTable_in.Columns["IFUser__Aproved"];
					_dc_aproved_date = dataTable_in.Columns["Aproved_date"];
					_dc_begin_date = dataTable_in.Columns["Begin_date"];
					_dc_end_date = dataTable_in.Columns["End_date"];
					_dc_tx_title = dataTable_in.Columns["TX_Title"];
					_dc_tx_content = dataTable_in.Columns["TX_Content"];
					_dc_tx_subtitle = dataTable_in.Columns["tx_subtitle"];
					_dc_tx_summary = dataTable_in.Columns["tx_summary"];
					_dc_newslettersent_date = dataTable_in.Columns["Newslettersent_date"];
					_dc_isnews_notforum = dataTable_in.Columns["isNews_notForum"];
				}

				_output[r] = new SO_NWS_Content();
				if (dataTable_in.Rows[r][_dc_idcontent] == System.DBNull.Value) {
					_output[r].idcontent_ = 0L;
				} else {
					_output[r].idcontent_ = (long)dataTable_in.Rows[r][_dc_idcontent];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication_isNull = true;
				} else {
					_output[r].ifapplication_ = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}
				if (dataTable_in.Rows[r][_dc_ifuser__publisher] == System.DBNull.Value) {
					_output[r].ifuser__publisher_ = 0L;
				} else {
					_output[r].ifuser__publisher_ = (long)dataTable_in.Rows[r][_dc_ifuser__publisher];
				}
				if (dataTable_in.Rows[r][_dc_publish_date] == System.DBNull.Value) {
					_output[r].publish_date_ = new DateTime(1900, 1, 1);
				} else {
					_output[r].publish_date_ = (DateTime)dataTable_in.Rows[r][_dc_publish_date];
				}
				if (dataTable_in.Rows[r][_dc_ifuser__aproved] == System.DBNull.Value) {
					_output[r].IFUser__Aproved_isNull = true;
				} else {
					_output[r].ifuser__aproved_ = (long)dataTable_in.Rows[r][_dc_ifuser__aproved];
				}
				if (dataTable_in.Rows[r][_dc_aproved_date] == System.DBNull.Value) {
					_output[r].Aproved_date_isNull = true;
				} else {
					_output[r].aproved_date_ = (DateTime)dataTable_in.Rows[r][_dc_aproved_date];
				}
				if (dataTable_in.Rows[r][_dc_begin_date] == System.DBNull.Value) {
					_output[r].Begin_date_isNull = true;
				} else {
					_output[r].begin_date_ = (DateTime)dataTable_in.Rows[r][_dc_begin_date];
				}
				if (dataTable_in.Rows[r][_dc_end_date] == System.DBNull.Value) {
					_output[r].End_date_isNull = true;
				} else {
					_output[r].end_date_ = (DateTime)dataTable_in.Rows[r][_dc_end_date];
				}
				if (dataTable_in.Rows[r][_dc_tx_title] == System.DBNull.Value) {
					_output[r].TX_Title_isNull = true;
				} else {
					_output[r].tx_title_ = (long)dataTable_in.Rows[r][_dc_tx_title];
				}
				if (dataTable_in.Rows[r][_dc_tx_content] == System.DBNull.Value) {
					_output[r].TX_Content_isNull = true;
				} else {
					_output[r].tx_content_ = (long)dataTable_in.Rows[r][_dc_tx_content];
				}
				if (dataTable_in.Rows[r][_dc_tx_subtitle] == System.DBNull.Value) {
					_output[r].tx_subtitle_isNull = true;
				} else {
					_output[r].tx_subtitle_ = (long)dataTable_in.Rows[r][_dc_tx_subtitle];
				}
				if (dataTable_in.Rows[r][_dc_tx_summary] == System.DBNull.Value) {
					_output[r].tx_summary_isNull = true;
				} else {
					_output[r].tx_summary_ = (long)dataTable_in.Rows[r][_dc_tx_summary];
				}
				if (dataTable_in.Rows[r][_dc_newslettersent_date] == System.DBNull.Value) {
					_output[r].Newslettersent_date_isNull = true;
				} else {
					_output[r].newslettersent_date_ = (DateTime)dataTable_in.Rows[r][_dc_newslettersent_date];
				}
				if (dataTable_in.Rows[r][_dc_isnews_notforum] == System.DBNull.Value) {
					_output[r].isNews_notForum_isNull = true;
				} else {
					_output[r].isnews_notforum_ = (bool)dataTable_in.Rows[r][_dc_isnews_notforum];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#region ???_generic...
		#region public static SO_NWS_Content[] getRecord_generic(...);
		/// <summary>
		/// Gets Record, based on 'generic' search. It selects NWS_Content values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_NWS_Content[] getRecord_generic(
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_generic(
				IFApplication_search_in, 
				IFUser__Publisher_search_in, 
				IFUser__Aproved_search_in, 
				Begin_date_search_in, 
				End_date_search_in, 
				IDTag_search_in, 
				IDAuthor_search_in, 
				IDSource_search_in, 
				IDHighlight_search_in, 
				IDProfile_search_in, 
				Keywords_search_in, 
				IDLanguage_search_in, 
				isAND_notOR_search_in, 
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on 'generic' search. It selects NWS_Content values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_NWS_Content[] getRecord_generic(
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in, 
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_Content[] _output;

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
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
						_connection.newDBDataParameter("IFUser__Publisher_search_", DbType.Int64, ParameterDirection.Input, IFUser__Publisher_search_in, 0), 
						_connection.newDBDataParameter("IFUser__Aproved_search_", DbType.Int64, ParameterDirection.Input, IFUser__Aproved_search_in, 0), 
						_connection.newDBDataParameter("Begin_date_search_", DbType.DateTime, ParameterDirection.Input, Begin_date_search_in, 0), 
						_connection.newDBDataParameter("End_date_search_", DbType.DateTime, ParameterDirection.Input, End_date_search_in, 0), 
						_connection.newDBDataParameter("IDTag_search_", DbType.AnsiString, ParameterDirection.Input, IDTag_search_in, 8000), 
						_connection.newDBDataParameter("IDAuthor_search_", DbType.AnsiString, ParameterDirection.Input, IDAuthor_search_in, 8000), 
						_connection.newDBDataParameter("IDSource_search_", DbType.AnsiString, ParameterDirection.Input, IDSource_search_in, 8000), 
						_connection.newDBDataParameter("IDHighlight_search_", DbType.AnsiString, ParameterDirection.Input, IDHighlight_search_in, 8000), 
						_connection.newDBDataParameter("IDProfile_search_", DbType.AnsiString, ParameterDirection.Input, IDProfile_search_in, 8000), 
						_connection.newDBDataParameter("Keywords_search_", DbType.AnsiString, ParameterDirection.Input, Keywords_search_in, 8000), 
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
						_connection.newDBDataParameter("isAND_notOR_search_", DbType.Boolean, ParameterDirection.Input, isAND_notOR_search_in, 0), 
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
					: new IDbDataParameter[] {
						_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
						_connection.newDBDataParameter("IFUser__Publisher_search_", DbType.Int64, ParameterDirection.Input, IFUser__Publisher_search_in, 0), 
						_connection.newDBDataParameter("IFUser__Aproved_search_", DbType.Int64, ParameterDirection.Input, IFUser__Aproved_search_in, 0), 
						_connection.newDBDataParameter("Begin_date_search_", DbType.DateTime, ParameterDirection.Input, Begin_date_search_in, 0), 
						_connection.newDBDataParameter("End_date_search_", DbType.DateTime, ParameterDirection.Input, End_date_search_in, 0), 
						_connection.newDBDataParameter("IDTag_search_", DbType.AnsiString, ParameterDirection.Input, IDTag_search_in, 8000), 
						_connection.newDBDataParameter("IDAuthor_search_", DbType.AnsiString, ParameterDirection.Input, IDAuthor_search_in, 8000), 
						_connection.newDBDataParameter("IDSource_search_", DbType.AnsiString, ParameterDirection.Input, IDSource_search_in, 8000), 
						_connection.newDBDataParameter("IDHighlight_search_", DbType.AnsiString, ParameterDirection.Input, IDHighlight_search_in, 8000), 
						_connection.newDBDataParameter("IDProfile_search_", DbType.AnsiString, ParameterDirection.Input, IDProfile_search_in, 8000), 
						_connection.newDBDataParameter("Keywords_search_", DbType.AnsiString, ParameterDirection.Input, Keywords_search_in, 8000), 
						_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
						_connection.newDBDataParameter("isAND_notOR_search_", DbType.Boolean, ParameterDirection.Input, isAND_notOR_search_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					((page_in > 0) && (page_numRecords_in > 0))
						? "sp0_NWS_Content_Record_open_generic_page_fullmode"
						: "sp0_NWS_Content_Record_open_generic_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion
		#region public static bool isObject_inRecord_generic(...);
		/// <summary>
		/// It selects NWS_Content values from Database based on the 'generic' search and checks to see if NWS_Content Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDContent_in">NWS_Content's IDContent Key used for checking</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <returns>True if NWS_Content Keys are met in the 'generic' search, False if not</returns>
		public static bool isObject_inRecord_generic(
			long IDContent_in, 
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in
		) {
			return isObject_inRecord_generic(
				IDContent_in, IFApplication_search_in, IFUser__Publisher_search_in, IFUser__Aproved_search_in, Begin_date_search_in, End_date_search_in, IDTag_search_in, IDAuthor_search_in, IDSource_search_in, IDHighlight_search_in, IDProfile_search_in, Keywords_search_in, IDLanguage_search_in, isAND_notOR_search_in, 
				null
			);
		}

		/// <summary>
		/// It selects NWS_Content values from Database based on the 'generic' search and checks to see if NWS_Content Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDContent_in">NWS_Content's IDContent Key used for checking</param>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_Content Keys are met in the 'generic' search, False if not</returns>
		public static bool isObject_inRecord_generic(
			long IDContent_in, 
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in, 
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
				_connection.newDBDataParameter("IDContent_", DbType.Int64, ParameterDirection.Input, IDContent_in, 0), 
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_search_", DbType.Int64, ParameterDirection.Input, IFUser__Publisher_search_in, 0), 
				_connection.newDBDataParameter("IFUser__Aproved_search_", DbType.Int64, ParameterDirection.Input, IFUser__Aproved_search_in, 0), 
				_connection.newDBDataParameter("Begin_date_search_", DbType.DateTime, ParameterDirection.Input, Begin_date_search_in, 0), 
				_connection.newDBDataParameter("End_date_search_", DbType.DateTime, ParameterDirection.Input, End_date_search_in, 0), 
				_connection.newDBDataParameter("IDTag_search_", DbType.AnsiString, ParameterDirection.Input, IDTag_search_in, 8000), 
				_connection.newDBDataParameter("IDAuthor_search_", DbType.AnsiString, ParameterDirection.Input, IDAuthor_search_in, 8000), 
				_connection.newDBDataParameter("IDSource_search_", DbType.AnsiString, ParameterDirection.Input, IDSource_search_in, 8000), 
				_connection.newDBDataParameter("IDHighlight_search_", DbType.AnsiString, ParameterDirection.Input, IDHighlight_search_in, 8000), 
				_connection.newDBDataParameter("IDProfile_search_", DbType.AnsiString, ParameterDirection.Input, IDProfile_search_in, 8000), 
				_connection.newDBDataParameter("Keywords_search_", DbType.AnsiString, ParameterDirection.Input, Keywords_search_in, 8000), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
				_connection.newDBDataParameter("isAND_notOR_search_", DbType.Boolean, ParameterDirection.Input, isAND_notOR_search_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_Content_Record_hasObject_generic", 
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
		/// Count's number of search results from NWS_Content at Database based on the 'generic' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <returns>number of existing Records for the 'generic' search</returns>
		public static long getCount_inRecord_generic(
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in
		) {
			return getCount_inRecord_generic(
				IFApplication_search_in, 
				IFUser__Publisher_search_in, 
				IFUser__Aproved_search_in, 
				Begin_date_search_in, 
				End_date_search_in, 
				IDTag_search_in, 
				IDAuthor_search_in, 
				IDSource_search_in, 
				IDHighlight_search_in, 
				IDProfile_search_in, 
				Keywords_search_in, 
				IDLanguage_search_in, 
				isAND_notOR_search_in, 
				null
			);
		}

		/// <summary>
		/// Count's number of search results from NWS_Content at Database based on the 'generic' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the 'generic' search</returns>
		public static long getCount_inRecord_generic(
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in, 
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
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_search_", DbType.Int64, ParameterDirection.Input, IFUser__Publisher_search_in, 0), 
				_connection.newDBDataParameter("IFUser__Aproved_search_", DbType.Int64, ParameterDirection.Input, IFUser__Aproved_search_in, 0), 
				_connection.newDBDataParameter("Begin_date_search_", DbType.DateTime, ParameterDirection.Input, Begin_date_search_in, 0), 
				_connection.newDBDataParameter("End_date_search_", DbType.DateTime, ParameterDirection.Input, End_date_search_in, 0), 
				_connection.newDBDataParameter("IDTag_search_", DbType.AnsiString, ParameterDirection.Input, IDTag_search_in, 8000), 
				_connection.newDBDataParameter("IDAuthor_search_", DbType.AnsiString, ParameterDirection.Input, IDAuthor_search_in, 8000), 
				_connection.newDBDataParameter("IDSource_search_", DbType.AnsiString, ParameterDirection.Input, IDSource_search_in, 8000), 
				_connection.newDBDataParameter("IDHighlight_search_", DbType.AnsiString, ParameterDirection.Input, IDHighlight_search_in, 8000), 
				_connection.newDBDataParameter("IDProfile_search_", DbType.AnsiString, ParameterDirection.Input, IDProfile_search_in, 8000), 
				_connection.newDBDataParameter("Keywords_search_", DbType.AnsiString, ParameterDirection.Input, Keywords_search_in, 8000), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
				_connection.newDBDataParameter("isAND_notOR_search_", DbType.Boolean, ParameterDirection.Input, isAND_notOR_search_in, 0)
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_NWS_Content_Record_count_generic", 
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
		/// Deletes NWS_Content values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		public static void delRecord_generic(
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in
		) {
			delRecord_generic(
				IFApplication_search_in, 
				IFUser__Publisher_search_in, 
				IFUser__Aproved_search_in, 
				Begin_date_search_in, 
				End_date_search_in, 
				IDTag_search_in, 
				IDAuthor_search_in, 
				IDSource_search_in, 
				IDHighlight_search_in, 
				IDProfile_search_in, 
				Keywords_search_in, 
				IDLanguage_search_in, 
				isAND_notOR_search_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_Content values from Database based on the 'generic' search.
		/// </summary>
		/// <param name="IFApplication_search_in">IFApplication search condition</param>
		/// <param name="IFUser__Publisher_search_in">IFUser__Publisher search condition</param>
		/// <param name="IFUser__Aproved_search_in">IFUser__Aproved search condition</param>
		/// <param name="Begin_date_search_in">Begin_date search condition</param>
		/// <param name="End_date_search_in">End_date search condition</param>
		/// <param name="IDTag_search_in">IDTag search condition</param>
		/// <param name="IDAuthor_search_in">IDAuthor search condition</param>
		/// <param name="IDSource_search_in">IDSource search condition</param>
		/// <param name="IDHighlight_search_in">IDHighlight search condition</param>
		/// <param name="IDProfile_search_in">IDProfile search condition</param>
		/// <param name="Keywords_search_in">Keywords search condition</param>
		/// <param name="IDLanguage_search_in">IDLanguage search condition</param>
		/// <param name="isAND_notOR_search_in">isAND_notOR search condition</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_generic(
			object IFApplication_search_in, 
			long IFUser__Publisher_search_in, 
			object IFUser__Aproved_search_in, 
			object Begin_date_search_in, 
			object End_date_search_in, 
			object IDTag_search_in, 
			object IDAuthor_search_in, 
			object IDSource_search_in, 
			object IDHighlight_search_in, 
			object IDProfile_search_in, 
			object Keywords_search_in, 
			int IDLanguage_search_in, 
			object isAND_notOR_search_in, 
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
				_connection.newDBDataParameter("IFApplication_search_", DbType.Int32, ParameterDirection.Input, IFApplication_search_in, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_search_", DbType.Int64, ParameterDirection.Input, IFUser__Publisher_search_in, 0), 
				_connection.newDBDataParameter("IFUser__Aproved_search_", DbType.Int64, ParameterDirection.Input, IFUser__Aproved_search_in, 0), 
				_connection.newDBDataParameter("Begin_date_search_", DbType.DateTime, ParameterDirection.Input, Begin_date_search_in, 0), 
				_connection.newDBDataParameter("End_date_search_", DbType.DateTime, ParameterDirection.Input, End_date_search_in, 0), 
				_connection.newDBDataParameter("IDTag_search_", DbType.AnsiString, ParameterDirection.Input, IDTag_search_in, 8000), 
				_connection.newDBDataParameter("IDAuthor_search_", DbType.AnsiString, ParameterDirection.Input, IDAuthor_search_in, 8000), 
				_connection.newDBDataParameter("IDSource_search_", DbType.AnsiString, ParameterDirection.Input, IDSource_search_in, 8000), 
				_connection.newDBDataParameter("IDHighlight_search_", DbType.AnsiString, ParameterDirection.Input, IDHighlight_search_in, 8000), 
				_connection.newDBDataParameter("IDProfile_search_", DbType.AnsiString, ParameterDirection.Input, IDProfile_search_in, 8000), 
				_connection.newDBDataParameter("Keywords_search_", DbType.AnsiString, ParameterDirection.Input, Keywords_search_in, 8000), 
				_connection.newDBDataParameter("IDLanguage_search_", DbType.Int32, ParameterDirection.Input, IDLanguage_search_in, 0), 
				_connection.newDBDataParameter("isAND_notOR_search_", DbType.Boolean, ParameterDirection.Input, isAND_notOR_search_in, 0)
			};
			_connection.Execute_SQLFunction(
				"sp0_NWS_Content_Record_delete_generic", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#endregion
		#endregion
	}
}