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
	/// DIC_LanguageApplication DataObject which provides access to DIC_LanguageApplication's Database table.
	/// </summary>
	[DOClassAttribute("DIC_LanguageApplication", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_DIC_LanguageApplication 
#else
			DO_DIC_LanguageApplication 
#endif
	{

	 	#region Methods...
		#region public static SO_DIC_LanguageApplication getObject(...);
		/// <summary>
		/// Selects DIC_LanguageApplication values from Database and assigns them to the appropriate DO0_DIC_LanguageApplication property.
		/// </summary>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <param name="IFApplication_in">IFApplication</param>
		/// <returns>null if DIC_LanguageApplication doesn't exists at Database</returns>
		public static SO_DIC_LanguageApplication getObject(
			int IFLanguage_in, 
			int IFApplication_in
		) {
			return getObject(
				IFLanguage_in, 
				IFApplication_in, 
				null
			);
		}

		/// <summary>
		/// Selects DIC_LanguageApplication values from Database and assigns them to the appropriate DO_DIC_LanguageApplication property.
		/// </summary>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <param name="IFApplication_in">IFApplication</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if DIC_LanguageApplication doesn't exists at Database</returns>
		public static SO_DIC_LanguageApplication getObject(
			int IFLanguage_in, 
			int IFApplication_in, 
			DBConnection dbConnection_in
		) {
			SO_DIC_LanguageApplication _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_connection.newDBDataParameter("IFLanguage_", DbType.Int32, ParameterDirection.InputOutput, IFLanguage_in, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.InputOutput, IFApplication_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_DIC_LanguageApplication_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[0].Value != DBNull.Value) {
				_output = new SO_DIC_LanguageApplication();

				if (_dataparameters[0].Value == System.DBNull.Value) {
					_output.IFLanguage = 0;
				} else {
					_output.IFLanguage = (int)_dataparameters[0].Value;
				}
				if (_dataparameters[1].Value == System.DBNull.Value) {
					_output.IFApplication = 0;
				} else {
					_output.IFApplication = (int)_dataparameters[1].Value;
				}

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes DIC_LanguageApplication from Database.
		/// </summary>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <param name="IFApplication_in">IFApplication</param>
		public static void delObject(
			int IFLanguage_in, 
			int IFApplication_in
		) {
			delObject(
				IFLanguage_in, 
				IFApplication_in, 
				null
			);
		}

		/// <summary>
		/// Deletes DIC_LanguageApplication from Database.
		/// </summary>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <param name="IFApplication_in">IFApplication</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(
			int IFLanguage_in, 
			int IFApplication_in, 
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
				_connection.newDBDataParameter("IFLanguage_", DbType.Int32, ParameterDirection.Input, IFLanguage_in, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, IFApplication_in, 0)
			};
			_connection.Execute_SQLFunction("sp0_DIC_LanguageApplication_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if DIC_LanguageApplication exists at Database
		/// </summary>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <param name="IFApplication_in">IFApplication</param>
		/// <returns>True if DIC_LanguageApplication exists at Database, False if not</returns>
		public static bool isObject(
			int IFLanguage_in, 
			int IFApplication_in
		) {
			return isObject(
				IFLanguage_in, 
				IFApplication_in, 
				null
			);
		}

		/// <summary>
		/// Checks to see if DIC_LanguageApplication exists at Database
		/// </summary>
		/// <param name="IFLanguage_in">IFLanguage</param>
		/// <param name="IFApplication_in">IFApplication</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if DIC_LanguageApplication exists at Database, False if not</returns>
		public static bool isObject(
			int IFLanguage_in, 
			int IFApplication_in, 
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
				_connection.newDBDataParameter("IFLanguage_", DbType.Int32, ParameterDirection.Input, IFLanguage_in, 0), 
				_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, IFApplication_in, 0)
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_DIC_LanguageApplication_isObject", 
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
		/// Inserts/Updates DIC_LanguageApplication values into/on Database. Inserts if DIC_LanguageApplication doesn't exist or Updates if DIC_LanguageApplication already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_DIC_LanguageApplication DIC_LanguageApplication_in, 
			bool forceUpdate_in
		) {
			return setObject(
				DIC_LanguageApplication_in, 
				forceUpdate_in, 
				null
			);
		}

		/// <summary>
		/// Inserts/Updates DIC_LanguageApplication values into/on Database. Inserts if DIC_LanguageApplication doesn't exist or Updates if DIC_LanguageApplication already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_DIC_LanguageApplication DIC_LanguageApplication_in, 
			bool forceUpdate_in, 
			DBConnection dbConnection_in
		) {
			bool ConstraintExist_out;
			if (forceUpdate_in || DIC_LanguageApplication_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					_connection.newDBDataParameter("IFLanguage_", DbType.Int32, ParameterDirection.Input, DIC_LanguageApplication_in.IFLanguage, 0), 
					_connection.newDBDataParameter("IFApplication_", DbType.Int32, ParameterDirection.Input, DIC_LanguageApplication_in.IFApplication, 0), 

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_DIC_LanguageApplication_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[2].Value & 2) == 1);
				if (!ConstraintExist_out) {
					DIC_LanguageApplication_in.haschanges_ = false;
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
		#region private static SO_DIC_LanguageApplication[] getRecord(DataTable dataTable_in);
		private static SO_DIC_LanguageApplication[] getRecord(
			DataTable dataTable_in
		) {
			DataColumn _dc_iflanguage = null;
			DataColumn _dc_ifapplication = null;

			SO_DIC_LanguageApplication[] _output 
				= new SO_DIC_LanguageApplication[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				if (r == 0) {
					_dc_iflanguage = dataTable_in.Columns["IFLanguage"];
					_dc_ifapplication = dataTable_in.Columns["IFApplication"];
				}

				_output[r] = new SO_DIC_LanguageApplication();
				if (dataTable_in.Rows[r][_dc_iflanguage] == System.DBNull.Value) {
					_output[r].iflanguage_ = 0;
				} else {
					_output[r].iflanguage_ = (int)dataTable_in.Rows[r][_dc_iflanguage];
				}
				if (dataTable_in.Rows[r][_dc_ifapplication] == System.DBNull.Value) {
					_output[r].ifapplication_ = 0;
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