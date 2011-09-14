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
	/// FOR_Message DataObject which provides access to FOR_Message's Database table.
	/// </summary>
	[DOClassAttribute("FOR_Message", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_FOR_Message 
#else
			DO_FOR_Message 
#endif
	{

	 	#region Methods...
		#region public static SO_FOR_Message getObject(...);
		/// <summary>
		/// Selects FOR_Message values from Database and assigns them to the appropriate DO0_FOR_Message property.
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		/// <returns>null if FOR_Message doesn't exists at Database</returns>
		public static SO_FOR_Message getObject(
			long IDMessage_in
		) {
			return getObject(
				IDMessage_in, 
				null
			);
		}

		/// <summary>
		/// Selects FOR_Message values from Database and assigns them to the appropriate DO_FOR_Message property.
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if FOR_Message doesn't exists at Database</returns>
		public static SO_FOR_Message getObject(
			long IDMessage_in, 
			DBConnection dbConnection_in
		) {
			SO_FOR_Message _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.InputOutput, IDMessage_in, 0), 
				_connection.newDBDataParameter("IFMessage__parent_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("isSticky_", DbType.Boolean, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Subject_", DbType.AnsiString, ParameterDirection.Output, null, 255), 
				_connection.newDBDataParameter("Message__charvar8000_", DbType.AnsiString, ParameterDirection.Output, null, 8000), 
				_connection.newDBDataParameter("Message__text_", DbType.AnsiString, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Publish_date_", DbType.DateTime, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_FOR_Message_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_FOR_Message();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDMessage = 0L;
				} else {
					_output.IDMessage = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFMessage__parent_isNull = true;
				} else {
					_output.IFMessage__parent = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.isSticky = false;
				} else {
					_output.isSticky = (bool)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					_output.Subject_isNull = true;
				} else {
					_output.Subject = (string)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					_output.Message__charvar8000_isNull = true;
				} else {
					_output.Message__charvar8000 = (string)_dataparameters[4].Value;
				}
				if (_dataparameters[5].Value == System.DBNull.Value) {
					_output.Message__text_isNull = true;
				} else {
					_output.Message__text = (string)_dataparameters[5].Value;
				}
				if (_dataparameters[6].Value == System.DBNull.Value) {
					_output.IFUser__Publisher_isNull = true;
				} else {
					_output.IFUser__Publisher = (long)_dataparameters[6].Value;
				}
				if (_dataparameters[7].Value == System.DBNull.Value) {
					_output.Publish_date = new DateTime(1900, 1, 1);
				} else {
					_output.Publish_date = (DateTime)_dataparameters[7].Value;
				}
				if (_dataparameters[8].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[8].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes FOR_Message from Database.
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		public static void delObject(
			long IDMessage_in
		) {
			delObject(
				IDMessage_in, 
				null
			);
		}

		/// <summary>
		/// Deletes FOR_Message from Database.
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDMessage_in, 
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
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Input, IDMessage_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_FOR_Message_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if FOR_Message exists at Database
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		/// <returns>True if FOR_Message exists at Database, False if not</returns>
		public static bool isObject(
			long IDMessage_in
		) {
			return isObject(
				IDMessage_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if FOR_Message exists at Database
		/// </summary>
		/// <param name="IDMessage_in">IDMessage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if FOR_Message exists at Database, False if not</returns>
		public static bool isObject(
			long IDMessage_in, 
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
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Input, IDMessage_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_FOR_Message_isObject", 
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
		/// Inserts FOR_Message values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_FOR_Message FOR_Message_in, 
			bool selectIdentity_in
		) {
			return insObject(
				FOR_Message_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts FOR_Message values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_FOR_Message FOR_Message_in, 
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
				_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFMessage__parent_", DbType.Int64, ParameterDirection.Input, FOR_Message_in.IFMessage__parent_isNull ? null : (object)FOR_Message_in.IFMessage__parent, 0), 
				_connection.newDBDataParameter("isSticky_", DbType.Boolean, ParameterDirection.Input, FOR_Message_in.isSticky, 0), 
				_connection.newDBDataParameter("Subject_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Subject_isNull ? null : (object)FOR_Message_in.Subject, 255), 
				_connection.newDBDataParameter("Message__charvar8000_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Message__charvar8000_isNull ? null : (object)FOR_Message_in.Message__charvar8000, 8000), 
				_connection.newDBDataParameter("Message__text_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Message__text_isNull ? null : (object)FOR_Message_in.Message__text, 0), 
				_connection.newDBDataParameter("IFUser__Publisher_", DbType.Int64, ParameterDirection.Input, FOR_Message_in.IFUser__Publisher_isNull ? null : (object)FOR_Message_in.IFUser__Publisher, 0), 
				_connection.newDBDataParameter("Publish_date_", DbType.DateTime, ParameterDirection.Input, FOR_Message_in.Publish_date, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, FOR_Message_in.IFApplication_isNull ? null : (object)FOR_Message_in.IFApplication, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_FOR_Message_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			FOR_Message_in.IDMessage = (long)_dataparameters[0].Value;FOR_Message_in.haschanges_ = false;
			

			return FOR_Message_in.IDMessage;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates FOR_Message values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_FOR_Message FOR_Message_in, 
			bool forceUpdate_in
		) {
			updObject(
				FOR_Message_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates FOR_Message values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_FOR_Message FOR_Message_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || FOR_Message_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDMessage_", DbType.Int64, ParameterDirection.Input, FOR_Message_in.IDMessage, 0), 
					_connection.newDBDataParameter("IFMessage__parent_", DbType.Int64, ParameterDirection.Input, FOR_Message_in.IFMessage__parent_isNull ? null : (object)FOR_Message_in.IFMessage__parent, 0), 
					_connection.newDBDataParameter("isSticky_", DbType.Boolean, ParameterDirection.Input, FOR_Message_in.isSticky, 0), 
					_connection.newDBDataParameter("Subject_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Subject_isNull ? null : (object)FOR_Message_in.Subject, 255), 
					_connection.newDBDataParameter("Message__charvar8000_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Message__charvar8000_isNull ? null : (object)FOR_Message_in.Message__charvar8000, 8000), 
					_connection.newDBDataParameter("Message__text_", DbType.AnsiString, ParameterDirection.Input, FOR_Message_in.Message__text_isNull ? null : (object)FOR_Message_in.Message__text, 0), 
					_connection.newDBDataParameter("IFUser__Publisher_", DbType.Int64, ParameterDirection.Input, FOR_Message_in.IFUser__Publisher_isNull ? null : (object)FOR_Message_in.IFUser__Publisher, 0), 
					_connection.newDBDataParameter("Publish_date_", DbType.DateTime, ParameterDirection.Input, FOR_Message_in.Publish_date, 0), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, FOR_Message_in.IFApplication_isNull ? null : (object)FOR_Message_in.IFApplication, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_FOR_Message_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				FOR_Message_in.haschanges_ = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_FOR_Message[] getRecord(DataTable dataTable_in);
		private static SO_FOR_Message[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idmessage = null;
			DataColumn _dc_ifmessage__parent = null;
			DataColumn _dc_issticky = null;
			DataColumn _dc_subject = null;
			DataColumn _dc_message__charvar8000 = null;
			DataColumn _dc_message__text = null;
			DataColumn _dc_ifuser__publisher = null;
			DataColumn _dc_publish_date = null;
			DataColumn _dc_ifapplication = null;

			SO_FOR_Message[] _output 
				= new SO_FOR_Message[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idmessage = dataTable_in.Columns["IDMessage"];
					_dc_ifmessage__parent = dataTable_in.Columns["IFMessage__parent"];
					_dc_issticky = dataTable_in.Columns["isSticky"];
					_dc_subject = dataTable_in.Columns["Subject"];
					_dc_message__charvar8000 = dataTable_in.Columns["Message__charvar8000"];
					_dc_message__text = dataTable_in.Columns["Message__text"];
					_dc_ifuser__publisher = dataTable_in.Columns["IFUser__Publisher"];
					_dc_publish_date = dataTable_in.Columns["Publish_date"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
				}

				_output[r] = new SO_FOR_Message();
				if (dataTable_in.Rows[r][_dc_idmessage] == System.DBNull.Value) {
					_output[r].idmessage_ = 0L;
				} else {
					_output[r].idmessage_ = (long)dataTable_in.Rows[r][_dc_idmessage];
				}
				if (dataTable_in.Rows[r][_dc_ifmessage__parent] == System.DBNull.Value) {
					_output[r].IFMessage__parent_isNull = true;
				} else {
					_output[r].ifmessage__parent_ = (long)dataTable_in.Rows[r][_dc_ifmessage__parent];
				}
				if (dataTable_in.Rows[r][_dc_issticky] == System.DBNull.Value) {
					_output[r].issticky_ = false;
				} else {
					_output[r].issticky_ = (bool)dataTable_in.Rows[r][_dc_issticky];
				}
				if (dataTable_in.Rows[r][_dc_subject] == System.DBNull.Value) {
					_output[r].Subject_isNull = true;
				} else {
					_output[r].subject_ = (string)dataTable_in.Rows[r][_dc_subject];
				}
				if (dataTable_in.Rows[r][_dc_message__charvar8000] == System.DBNull.Value) {
					_output[r].Message__charvar8000_isNull = true;
				} else {
					_output[r].message__charvar8000_ = (string)dataTable_in.Rows[r][_dc_message__charvar8000];
				}
				if (dataTable_in.Rows[r][_dc_message__text] == System.DBNull.Value) {
					_output[r].Message__text_isNull = true;
				} else {
					_output[r].message__text_ = (string)dataTable_in.Rows[r][_dc_message__text];
				}
				if (dataTable_in.Rows[r][_dc_ifuser__publisher] == System.DBNull.Value) {
					_output[r].IFUser__Publisher_isNull = true;
				} else {
					_output[r].ifuser__publisher_ = (long)dataTable_in.Rows[r][_dc_ifuser__publisher];
				}
				if (dataTable_in.Rows[r][_dc_publish_date] == System.DBNull.Value) {
					_output[r].publish_date_ = new DateTime(1900, 1, 1);
				} else {
					_output[r].publish_date_ = (DateTime)dataTable_in.Rows[r][_dc_publish_date];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication_isNull = true;
				} else {
					_output[r].ifapplication_ = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#endregion
	}
}