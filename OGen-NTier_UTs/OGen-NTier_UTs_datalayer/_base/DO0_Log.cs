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
using System.Xml.Serialization;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;

namespace OGen.NTier.UTs.lib.datalayer {
	/// <summary>
	/// Log DataObject which provides access to Log table at Database.
	/// </summary>
	[DOClassAttribute("Log", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		DO_Log 
#else
		DO0_Log 
#endif
		: DO__base {
		#region public DO_Log();
#if !NET_1_1
		///
		public DO_Log
#else
		internal DO0_Log
#endif
		() : base(
#if !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
			.DBServerType, 
#if !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
			.DBConnectionstring,
#if !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
			.DBLogfile
		) {
			clrObject();
			Fields.haschanges_ = false;
		}
#if !NET_1_1
			/// <summary>
			/// Making the use of Database Transactions possible on a sequence of operations across multiple DataObjects.
			/// </summary>
			/// <param name="connection_in">opened Database connection with an initiated Transaction</param>
			public DO_Log
#else
			internal DO0_Log
#endif
		(
			DBConnection connection_in
		) : base(
			connection_in
		) {
			clrObject();
			Fields.haschanges_ = false;
		}
		#endregion

		#region Properties...
		#region public FO0_Log Fields { get; set; }
		internal SO_Log fields_;

		public SO_Log Fields {
			get { return fields_; }
			set { fields_ = value; }
		}
		#endregion
		#region public RO0_Log Record { get; }
		private RO0_Log record__;

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public RO0_Log Record {
			get {
				if (record__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					record__ = new RO0_Log(this);
				}
				return record__;
			}
		}
		#endregion
		#endregion

		#region Methods...
		public override DBConnection DBConnection_createInstance(
			string dbServerType_in, 
			string connectionstring_in, 
			string logfile_in
		) {
			return 
				#if !NET_1_1
				DO__utils
				#else
				DO0__utils
				#endif
					.DBConnection_createInstance(
						dbServerType_in, 
						connectionstring_in, 
						logfile_in
					);
		}
		#region public SC_Log Serialize();
		public SO_Log Serialize() {
			return Fields;
		}
		#endregion
		#region public void clrObject();
		/// <summary>
		/// Clears all DO0_Log properties, assigning them with their appropriate default property value.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		void clrObject() {
			Fields = new SO_Log();
		}
		#endregion
		#region public bool getObject(...);
		/// <summary>
		/// Selects Log values from Database and assigns them to the appropriate DO0_Log property.
		/// </summary>
		/// <returns>True if Log exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool getObject() {
			return getObject(
				Fields.IDLog
			);
		}
		/// <summary>
		/// Selects Log values from Database and assigns them to the appropriate DO0_Log property.
		/// </summary>
		/// <param name="IDLog_in">IDLog</param>
		/// <returns>True if Log exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
			bool getObject(
			long IDLog_in
		) {
			if (IDLog_in != 0L) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.InputOutput, IDLog_in, 0), 
					base.Connection.newDBDataParameter("IDLogcode_", DbType.Int64, ParameterDirection.Output, null, 0), 
					base.Connection.newDBDataParameter("IDUser_posted_", DbType.Int64, ParameterDirection.Output, null, 0), 
					base.Connection.newDBDataParameter("Date_posted_", DbType.DateTime, ParameterDirection.Output, null, 0), 
					base.Connection.newDBDataParameter("Logdata_", DbType.String, ParameterDirection.Output, null, 1024)
				};
				base.Connection.Execute_SQLFunction("sp0_Log_getObject", _dataparameters);

				if (_dataparameters[0].Value != DBNull.Value) {
					if (_dataparameters[0].Value == System.DBNull.Value) {
						Fields.IDLog = 0L;
					} else {
						Fields.IDLog = (long)_dataparameters[0].Value;
					}
					if (_dataparameters[1].Value == System.DBNull.Value) {
						Fields.IDLogcode = 0L;
					} else {
						Fields.IDLogcode = (long)_dataparameters[1].Value;
					}
					if (_dataparameters[2].Value == System.DBNull.Value) {
						Fields.IDUser_posted = 0L;
					} else {
						Fields.IDUser_posted = (long)_dataparameters[2].Value;
					}
					if (_dataparameters[3].Value == System.DBNull.Value) {
						Fields.Date_posted = new DateTime(1900, 1, 1);
					} else {
						Fields.Date_posted = (DateTime)_dataparameters[3].Value;
					}
					if (_dataparameters[4].Value == System.DBNull.Value) {
						Fields.Logdata = string.Empty;
					} else {
						Fields.Logdata = (string)_dataparameters[4].Value;
					}

					Fields.haschanges_ = false;
					return true;
				}
			}

			//clrObject();
			//haschanges_ = false;

			return false;
		}
		#endregion
		#region public void delObject(...);
		/// <summary>
		/// Deletes Log from Database.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		void delObject() {
			delObject(
				Fields.IDLog
			);
		}
		/// <summary>
		/// Deletes Log from Database.
		/// </summary>
		/// <param name="IDLog_in">IDLog</param>
		public 
#if NET_1_1
			virtual 
#endif
		void delObject(
			long IDLog_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.Input, IDLog_in, 0)
			};
			base.Connection.Execute_SQLFunction("sp0_Log_delObject", _dataparameters);

			clrObject();
		}
		#endregion
		#region public bool isObject(...);
		/// <summary>
		/// Checks to see if Log exists at Database
		/// </summary>
		/// <returns>True if Log exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool isObject() {
			return isObject(
				Fields.IDLog
			);
		}
		/// <summary>
		/// Checks to see if Log exists at Database
		/// </summary>
		/// <param name="IDLog_in">IDLog</param>
		/// <returns>True if Log exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool isObject(
			long IDLog_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.Input, IDLog_in, 0)
			};

			return (bool)base.Connection.Execute_SQLFunction(
				"fnc0_Log_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion
		#region public long insObject(...);
		/// <summary>
		/// Inserts Log values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public 
#if NET_1_1
			virtual 
#endif
		long insObject(
			bool selectIdentity_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.Output, null, 0), 
				base.Connection.newDBDataParameter("IDLogcode_", DbType.Int64, ParameterDirection.Input, Fields.IDLogcode, 0), 
				base.Connection.newDBDataParameter("IDUser_posted_", DbType.Int64, ParameterDirection.Input, Fields.IDUser_posted, 0), 
				base.Connection.newDBDataParameter("Date_posted_", DbType.DateTime, ParameterDirection.Input, Fields.Date_posted, 0), 
				base.Connection.newDBDataParameter("Logdata_", DbType.String, ParameterDirection.Input, Fields.Logdata, 1024), 

				base.Connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			base.Connection.Execute_SQLFunction(
				"sp0_Log_insObject", 
				_dataparameters
			);

			Fields.IDLog = (long)_dataparameters[0].Value;
			Fields.haschanges_ = false;
			

			return Fields.IDLog;
		}
		#endregion
		#region public void updObject(...);
		/// <summary>
		/// Updates Log values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public 
#if NET_1_1
			virtual 
#endif
		void updObject(bool forceUpdate_in) {
			if (forceUpdate_in || Fields.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDLog_", DbType.Int64, ParameterDirection.Input, Fields.IDLog, 0), 
					base.Connection.newDBDataParameter("IDLogcode_", DbType.Int64, ParameterDirection.Input, Fields.IDLogcode, 0), 
					base.Connection.newDBDataParameter("IDUser_posted_", DbType.Int64, ParameterDirection.Input, Fields.IDUser_posted, 0), 
					base.Connection.newDBDataParameter("Date_posted_", DbType.DateTime, ParameterDirection.Input, Fields.Date_posted, 0), 
					base.Connection.newDBDataParameter("Logdata_", DbType.String, ParameterDirection.Input, Fields.Logdata, 1024)
				};
				base.Connection.Execute_SQLFunction(
					"sp0_Log_updObject", 
					_dataparameters
				);
				Fields.haschanges_ = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Search...
		#endregion
		#region Methods - Updates...
		#endregion
	}
}