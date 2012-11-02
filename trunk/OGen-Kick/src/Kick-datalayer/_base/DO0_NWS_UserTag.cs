#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.lib.datalayer {
	using System;
	using System.Data;

	using OGen.lib.datalayer;
	using OGen.NTier.lib.datalayer;

	using OGen.NTier.Kick.lib.datalayer.shared.structures;

	/// <summary>
	/// NWS_UserTag DataObject which provides access to NWS_UserTag's Database table.
	/// </summary>
	[DOClassAttribute("NWS_UserTag", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_NWS_UserTag 
#else
			DO_NWS_UserTag 
#endif
	{

	 	#region Methods...
		#region public static SO_NWS_UserTag getObject(...);
		/// <summary>
		/// Selects NWS_UserTag values from Database and assigns them to the appropriate DO0_NWS_UserTag property.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFTag_in">IFTag</param>
		/// <returns>null if NWS_UserTag doesn't exists at Database</returns>
		public static SO_NWS_UserTag getObject(
			long IFUser_in, 
			long IFTag_in
		) {
			return getObject(
				IFUser_in, 
				IFTag_in, 
				null
			);
		}

		/// <summary>
		/// Selects NWS_UserTag values from Database and assigns them to the appropriate DO_NWS_UserTag property.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFTag_in">IFTag</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NWS_UserTag doesn't exists at Database</returns>
		public static SO_NWS_UserTag getObject(
			long IFUser_in, 
			long IFTag_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_UserTag _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.InputOutput, IFUser_in, 0), 
				_connection.newDBDataParameter("IFTag_", DbType.Int64, ParameterDirection.InputOutput, IFTag_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_UserTag_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NWS_UserTag();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFUser = 0L;
				} else {
					_output.IFUser = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFTag = 0L;
				} else {
					_output.IFTag = (long)_dataparameters[1].Value;
				}

				_output.hasChanges = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NWS_UserTag from Database.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFTag_in">IFTag</param>
		public static void delObject(
			long IFUser_in, 
			long IFTag_in
		) {
			delObject(
				IFUser_in, 
				IFTag_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_UserTag from Database.
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFTag_in">IFTag</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFUser_in, 
			long IFTag_in, 
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
				_connection.newDBDataParameter("IFTag_", DbType.Int64, ParameterDirection.Input, IFTag_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_UserTag_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NWS_UserTag exists at Database
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFTag_in">IFTag</param>
		/// <returns>True if NWS_UserTag exists at Database, False if not</returns>
		public static bool isObject(
			long IFUser_in, 
			long IFTag_in
		) {
			return isObject(
				IFUser_in, 
				IFTag_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NWS_UserTag exists at Database
		/// </summary>
		/// <param name="IFUser_in">IFUser</param>
		/// <param name="IFTag_in">IFTag</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_UserTag exists at Database, False if not</returns>
		public static bool isObject(
			long IFUser_in, 
			long IFTag_in, 
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
				_connection.newDBDataParameter("IFTag_", DbType.Int64, ParameterDirection.Input, IFTag_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_UserTag_isObject", 
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
		/// Inserts/Updates NWS_UserTag values into/on Database. Inserts if NWS_UserTag doesn't exist or Updates if NWS_UserTag already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NWS_UserTag NWS_UserTag_in, 
			bool forceUpdate_in
		) {
			return setObject(
				NWS_UserTag_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates NWS_UserTag values into/on Database. Inserts if NWS_UserTag doesn't exist or Updates if NWS_UserTag already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NWS_UserTag NWS_UserTag_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || NWS_UserTag_in.hasChanges) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFUser_", DbType.Int64, ParameterDirection.Input, NWS_UserTag_in.IFUser, 0), 
					_connection.newDBDataParameter("IFTag_", DbType.Int64, ParameterDirection.Input, NWS_UserTag_in.IFTag, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NWS_UserTag_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[2].Value & 2) == 1);
				if (!ConstraintExist_out) {
					NWS_UserTag_in.hasChanges = false;
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
		#region private static SO_NWS_UserTag[] getRecord(DataTable dataTable_in);
		private static SO_NWS_UserTag[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifuser = null;
			DataColumn _dc_iftag = null;

			SO_NWS_UserTag[] _output 
				= new SO_NWS_UserTag[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifuser = dataTable_in.Columns["IFUser"];
					_dc_iftag = dataTable_in.Columns["IFTag"];
				}

				_output[r] = new SO_NWS_UserTag();
				if (dataTable_in.Rows[r][_dc_ifuser] == System.DBNull.Value) {
					_output[r].IFUser = 0L;
				} else {
					_output[r].IFUser = (long)dataTable_in.Rows[r][_dc_ifuser];
				}
				if (dataTable_in.Rows[r][_dc_iftag] == System.DBNull.Value) {
					_output[r].IFTag = 0L;
				} else {
					_output[r].IFTag = (long)dataTable_in.Rows[r][_dc_iftag];
				}

				_output[r].hasChanges = false;
			}

			return _output;
		}
		#endregion

		#endregion
	}
}