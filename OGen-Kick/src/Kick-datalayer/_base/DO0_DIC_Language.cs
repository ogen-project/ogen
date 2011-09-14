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
	/// DIC_Language DataObject which provides access to DIC_Language's Database table.
	/// </summary>
	[DOClassAttribute("DIC_Language", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_DIC_Language 
#else
			DO_DIC_Language 
#endif
	{

	 	#region Methods...
		#region public static SO_DIC_Language getObject(...);
		/// <summary>
		/// Selects DIC_Language values from Database and assigns them to the appropriate DO0_DIC_Language property.
		/// </summary>
		/// <param name="IDLanguage_in">IDLanguage</param>
		/// <returns>null if DIC_Language doesn't exists at Database</returns>
		public static SO_DIC_Language getObject(
			int IDLanguage_in
		) {
			return getObject(
				IDLanguage_in, 
				null
			);
		}

		/// <summary>
		/// Selects DIC_Language values from Database and assigns them to the appropriate DO_DIC_Language property.
		/// </summary>
		/// <param name="IDLanguage_in">IDLanguage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if DIC_Language doesn't exists at Database</returns>
		public static SO_DIC_Language getObject(
			int IDLanguage_in, 
			DBConnection dbConnection_in
		) {
			SO_DIC_Language _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.InputOutput, IDLanguage_in, 0), 
				_connection.newDBDataParameter("TX_Name_", DbType.Int64, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_DIC_Language_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_DIC_Language();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDLanguage = 0;
				} else {
					_output.IDLanguage = (int)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.TX_Name = 0L;
				} else {
					_output.TX_Name = (long)_dataparameters[1].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes DIC_Language from Database.
		/// </summary>
		/// <param name="IDLanguage_in">IDLanguage</param>
		public static void delObject(
			int IDLanguage_in
		) {
			delObject(
				IDLanguage_in, 
				null
			);
		}

		/// <summary>
		/// Deletes DIC_Language from Database.
		/// </summary>
		/// <param name="IDLanguage_in">IDLanguage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			int IDLanguage_in, 
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
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_DIC_Language_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if DIC_Language exists at Database
		/// </summary>
		/// <param name="IDLanguage_in">IDLanguage</param>
		/// <returns>True if DIC_Language exists at Database, False if not</returns>
		public static bool isObject(
			int IDLanguage_in
		) {
			return isObject(
				IDLanguage_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if DIC_Language exists at Database
		/// </summary>
		/// <param name="IDLanguage_in">IDLanguage</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if DIC_Language exists at Database, False if not</returns>
		public static bool isObject(
			int IDLanguage_in, 
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
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, IDLanguage_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_DIC_Language_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static int insObject(...);
		/// <summary>
		/// Inserts DIC_Language values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static int insObject(
			SO_DIC_Language DIC_Language_in, 
			bool selectIdentity_in
		) {
			return insObject(
				DIC_Language_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts DIC_Language values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static int insObject(
			SO_DIC_Language DIC_Language_in, 
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
				_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("TX_Name_", DbType.Int64, ParameterDirection.Input, DIC_Language_in.TX_Name, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_DIC_Language_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			DIC_Language_in.IDLanguage = (int)_dataparameters[0].Value;DIC_Language_in.haschanges_ = false;
			

			return DIC_Language_in.IDLanguage;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates DIC_Language values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_DIC_Language DIC_Language_in, 
			bool forceUpdate_in
		) {
			updObject(
				DIC_Language_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates DIC_Language values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_DIC_Language DIC_Language_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || DIC_Language_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDLanguage_", DbType.Int32, ParameterDirection.Input, DIC_Language_in.IDLanguage, 0), 
					_connection.newDBDataParameter("TX_Name_", DbType.Int64, ParameterDirection.Input, DIC_Language_in.TX_Name, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_DIC_Language_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				DIC_Language_in.haschanges_ = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_DIC_Language[] getRecord(DataTable dataTable_in);
		private static SO_DIC_Language[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idlanguage = null;
			DataColumn _dc_tx_name = null;

			SO_DIC_Language[] _output 
				= new SO_DIC_Language[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idlanguage = dataTable_in.Columns["IDLanguage"];
					_dc_tx_name = dataTable_in.Columns["TX_Name"];
				}

				_output[r] = new SO_DIC_Language();
				if (dataTable_in.Rows[r][_dc_idlanguage] == System.DBNull.Value) {
					_output[r].idlanguage_ = 0;
				} else {
					_output[r].idlanguage_ = (int)dataTable_in.Rows[r][_dc_idlanguage];
				}
				if (dataTable_in.Rows[r][_dc_tx_name] == System.DBNull.Value) {
					_output[r].tx_name_ = 0L;
				} else {
					_output[r].tx_name_ = (long)dataTable_in.Rows[r][_dc_tx_name];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#endregion
	}
}