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
	/// DIC_Text DataObject which provides access to DIC_Text's Database table.
	/// </summary>
	[DOClassAttribute("DIC_Text", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_DIC_Text 
#else
			DO_DIC_Text 
#endif
	{

	 	#region Methods...
		#region public static SO_DIC_Text getObject(...);
		/// <summary>
		/// Selects DIC_Text values from Database and assigns them to the appropriate DO0_DIC_Text property.
		/// </summary>
		/// <param name="IDText_in">IDText</param>
		/// <returns>null if DIC_Text doesn't exists at Database</returns>
		public static SO_DIC_Text getObject(
			long IDText_in
		) {
			return getObject(
				IDText_in, 
				null
			);
		}

		/// <summary>
		/// Selects DIC_Text values from Database and assigns them to the appropriate DO_DIC_Text property.
		/// </summary>
		/// <param name="IDText_in">IDText</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if DIC_Text doesn't exists at Database</returns>
		public static SO_DIC_Text getObject(
			long IDText_in, 
			DBConnection dbConnection_in
		) {
			SO_DIC_Text _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IDText_", DbType.Int64, ParameterDirection.InputOutput, IDText_in, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("SourceTableField_ref_", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_DIC_Text_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_DIC_Text();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IDText = 0L;
				} else {
					_output.IDText = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFApplication_isNull = true;
				} else {
					_output.IFApplication = (int)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.SourceTableField_ref_isNull = true;
				} else {
					_output.SourceTableField_ref = (int)_dataparameters[2].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes DIC_Text from Database.
		/// </summary>
		/// <param name="IDText_in">IDText</param>
		public static void delObject(
			long IDText_in
		) {
			delObject(
				IDText_in, 
				null
			);
		}

		/// <summary>
		/// Deletes DIC_Text from Database.
		/// </summary>
		/// <param name="IDText_in">IDText</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IDText_in, 
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
				_connection.newDBDataParameter("IDText_", DbType.Int64, ParameterDirection.Input, IDText_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_DIC_Text_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if DIC_Text exists at Database
		/// </summary>
		/// <param name="IDText_in">IDText</param>
		/// <returns>True if DIC_Text exists at Database, False if not</returns>
		public static bool isObject(
			long IDText_in
		) {
			return isObject(
				IDText_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if DIC_Text exists at Database
		/// </summary>
		/// <param name="IDText_in">IDText</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if DIC_Text exists at Database, False if not</returns>
		public static bool isObject(
			long IDText_in, 
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
				_connection.newDBDataParameter("IDText_", DbType.Int64, ParameterDirection.Input, IDText_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_DIC_Text_isObject", 
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
		/// Inserts DIC_Text values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_DIC_Text DIC_Text_in, 
			bool selectIdentity_in
		) {
			return insObject(
				DIC_Text_in, 
				selectIdentity_in, 
				null
			);
		}

		/// <summary>
		/// Inserts DIC_Text values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static long insObject(
			SO_DIC_Text DIC_Text_in, 
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
				_connection.newDBDataParameter("IDText_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, DIC_Text_in.IFApplication_isNull ? null : (object)DIC_Text_in.IFApplication, 0), 
				_connection.newDBDataParameter("SourceTableField_ref_", DbType.Int32, ParameterDirection.Input, DIC_Text_in.SourceTableField_ref_isNull ? null : (object)DIC_Text_in.SourceTableField_ref, 0), 

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_DIC_Text_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			DIC_Text_in.IDText = (long)_dataparameters[0].Value;DIC_Text_in.haschanges_ = false;
			

			return DIC_Text_in.IDText;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates DIC_Text values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public static void updObject(
			SO_DIC_Text DIC_Text_in, 
			bool forceUpdate_in
		) {
			updObject(
				DIC_Text_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Updates DIC_Text values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_DIC_Text DIC_Text_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || DIC_Text_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IDText_", DbType.Int64, ParameterDirection.Input, DIC_Text_in.IDText, 0), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, DIC_Text_in.IFApplication_isNull ? null : (object)DIC_Text_in.IFApplication, 0), 
					_connection.newDBDataParameter("SourceTableField_ref_", DbType.Int32, ParameterDirection.Input, DIC_Text_in.SourceTableField_ref_isNull ? null : (object)DIC_Text_in.SourceTableField_ref, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_DIC_Text_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				DIC_Text_in.haschanges_ = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Object Searches...
		#endregion
		#region Methods - Object Updates...
		#endregion

		#region Methods - Record Searches...
		#region private static SO_DIC_Text[] getRecord(DataTable dataTable_in);
		private static SO_DIC_Text[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_idtext = null;
			DataColumn _dc_ifapplication = null;
			DataColumn _dc_sourcetablefield_ref = null;

			SO_DIC_Text[] _output 
				= new SO_DIC_Text[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_idtext = dataTable_in.Columns["IDText"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
					_dc_sourcetablefield_ref = dataTable_in.Columns["SourceTableField_ref"];
				}

				_output[r] = new SO_DIC_Text();
				if (dataTable_in.Rows[r][_dc_idtext] == System.DBNull.Value) {
					_output[r].idtext_ = 0L;
				} else {
					_output[r].idtext_ = (long)dataTable_in.Rows[r][_dc_idtext];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].IFApplication_isNull = true;
				} else {
					_output[r].ifapplication_ = (int)dataTable_in.Rows[r][_dc_ifapplication];
				}
				if (dataTable_in.Rows[r][_dc_sourcetablefield_ref] == System.DBNull.Value) {
					_output[r].SourceTableField_ref_isNull = true;
				} else {
					_output[r].sourcetablefield_ref_ = (int)dataTable_in.Rows[r][_dc_sourcetablefield_ref];
				}

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion

		#endregion
	}
}