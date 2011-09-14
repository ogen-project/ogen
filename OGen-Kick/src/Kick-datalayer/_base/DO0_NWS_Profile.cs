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
	/// NWS_Profile DataObject which provides access to NWS_Profile's Database table.
	/// </summary>
	[DOClassAttribute("NWS_Profile", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_NWS_Profile 
#else
			DO_NWS_Profile 
#endif
	{

	 	#region Methods...
		#region public static SO_NWS_Profile getObject(...);
		/// <summary>
		/// Selects NWS_Profile values from Database and assigns them to the appropriate DO0_NWS_Profile property.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <returns>null if NWS_Profile doesn't exists at Database</returns>
		public static SO_NWS_Profile getObject(
			long IFProfile_in
		) {
			return getObject(
				IFProfile_in, 
				null
			);
		}

		/// <summary>
		/// Selects NWS_Profile values from Database and assigns them to the appropriate DO_NWS_Profile property.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if NWS_Profile doesn't exists at Database</returns>
		public static SO_NWS_Profile getObject(
			long IFProfile_in, 
			DBConnection dbConnection_in
		) {
			SO_NWS_Profile _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.InputOutput, IFProfile_in, 0), 
				_connection.newDBDataParameter("IFUser__Approved_", DbType.Int64, ParameterDirection.Output, null, 0), 
				_connection.newDBDataParameter("Approved_date_", DbType.DateTime, ParameterDirection.Output, null, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_Profile_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_NWS_Profile();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFProfile = 0L;
				} else {
					_output.IFProfile = (long)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFUser__Approved_isNull = true;
				} else {
					_output.IFUser__Approved = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					_output.Approved_date_isNull = true;
				} else {
					_output.Approved_date = (DateTime)_dataparameters[2].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes NWS_Profile from Database.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		public static void delObject(
			long IFProfile_in
		) {
			delObject(
				IFProfile_in, 
				null
			);
		}

		/// <summary>
		/// Deletes NWS_Profile from Database.
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			long IFProfile_in, 
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
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, IFProfile_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_NWS_Profile_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if NWS_Profile exists at Database
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <returns>True if NWS_Profile exists at Database, False if not</returns>
		public static bool isObject(
			long IFProfile_in
		) {
			return isObject(
				IFProfile_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if NWS_Profile exists at Database
		/// </summary>
		/// <param name="IFProfile_in">IFProfile</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if NWS_Profile exists at Database, False if not</returns>
		public static bool isObject(
			long IFProfile_in, 
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
				_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, IFProfile_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_NWS_Profile_isObject", 
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
		/// Inserts/Updates NWS_Profile values into/on Database. Inserts if NWS_Profile doesn't exist or Updates if NWS_Profile already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NWS_Profile NWS_Profile_in, 
			bool forceUpdate_in
		) {
			return setObject(
				NWS_Profile_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates NWS_Profile values into/on Database. Inserts if NWS_Profile doesn't exist or Updates if NWS_Profile already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_NWS_Profile NWS_Profile_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || NWS_Profile_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFProfile_", DbType.Int64, ParameterDirection.Input, NWS_Profile_in.IFProfile, 0), 
					_connection.newDBDataParameter("IFUser__Approved_", DbType.Int64, ParameterDirection.Input, NWS_Profile_in.IFUser__Approved_isNull ? null : (object)NWS_Profile_in.IFUser__Approved, 0), 
					_connection.newDBDataParameter("Approved_date_", DbType.DateTime, ParameterDirection.Input, NWS_Profile_in.Approved_date_isNull ? null : (object)NWS_Profile_in.Approved_date, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_NWS_Profile_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[3].Value & 2) == 1);
				if (!ConstraintExist_out) {
					NWS_Profile_in.haschanges_ = false;
				}

				return (((int)_dataparameters[3].Value & 1) != 1);
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
		#region private static SO_NWS_Profile[] getRecord(DataTable dataTable_in);
		private static SO_NWS_Profile[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_ifprofile = null;
			DataColumn _dc_ifuser__approved = null;
			DataColumn _dc_approved_date = null;

			SO_NWS_Profile[] _output 
				= new SO_NWS_Profile[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_ifprofile = dataTable_in.Columns["IFProfile"];
					_dc_ifuser__approved = dataTable_in.Columns["IFUser__Approved"];
					_dc_approved_date = dataTable_in.Columns["Approved_date"];
				}

				_output[r] = new SO_NWS_Profile();
				if (dataTable_in.Rows[r][_dc_ifprofile] == System.DBNull.Value) {
					_output[r].ifprofile_ = 0L;
				} else {
					_output[r].ifprofile_ = (long)dataTable_in.Rows[r][_dc_ifprofile];
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

		#endregion
	}
}