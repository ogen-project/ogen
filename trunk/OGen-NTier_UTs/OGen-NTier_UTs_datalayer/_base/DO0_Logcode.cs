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
using OGen.NTier.UTs.lib.datalayer.proxy;

namespace OGen.NTier.UTs.lib.datalayer {
	/// <summary>
	/// Logcode DataObject which provides access to Logcode table at Database.
	/// </summary>
	[DOClassAttribute("Logcode", "", "", "", false, false)]
	public 
#if USE_PARTIAL_CLASSES && !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if USE_PARTIAL_CLASSES && !NET_1_1
		DO_Logcode 
#else
		DO0_Logcode 
#endif
		: DO__base {
		#region public DO_Logcode();
#if USE_PARTIAL_CLASSES && !NET_1_1
		///
		public DO_Logcode
#else
		internal DO0_Logcode
#endif
		() : base(
#if USE_PARTIAL_CLASSES && !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
			.DBServerType, 
#if USE_PARTIAL_CLASSES && !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
			.DBConnectionstring,
#if USE_PARTIAL_CLASSES && !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
			.DBLogfile
		) {
			clrObject();
			fields_.haschanges_ = false;
		}
#if USE_PARTIAL_CLASSES && !NET_1_1
			/// <summary>
			/// Making the use of Database Transactions possible on a sequence of operations across multiple DataObjects.
			/// </summary>
			/// <param name="connection_in">opened Database connection with an initiated Transaction</param>
			public DO_Logcode
#else
			internal DO0_Logcode
#endif
		(
			DBConnection connection_in
		) : base(
			connection_in
		) {
			clrObject();
			fields_.haschanges_ = false;
		}
		#endregion

		#region Properties...
		#region public SO_Logcode Fields { get; set; }
		internal SO_Logcode fields_;

		public ISO_Logcode Fields {
			get { return fields_; }
			set { fields_ = (SO_Logcode)value; }
		}
		#endregion
		#region public RO0_Logcode Record { get; }
		private RO0_Logcode record__;

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public RO0_Logcode Record {
			get {
				if (record__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					record__ = new RO0_Logcode(this);
				}
				return record__;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public override DBConnection DBConnection_createInstance(...);
		public override DBConnection DBConnection_createInstance(
			string dbServerType_in, 
			string connectionstring_in, 
			string logfile_in
		) {
			return 
				#if USE_PARTIAL_CLASSES && !NET_1_1
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
		#endregion
		#region public SC_Logcode Serialize();
		public SO_Logcode Serialize() {
			return fields_;
		}
		#endregion
		#region public void clrObject();
		/// <summary>
		/// Clears all DO0_Logcode properties, assigning them with their appropriate default property value.
		/// </summary>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void clrObject() {
			fields_ = new SO_Logcode();
		}
		#endregion
		#region public bool getObject(...);
		/// <summary>
		/// Selects Logcode values from Database and assigns them to the appropriate DO0_Logcode property.
		/// </summary>
		/// <returns>True if Logcode exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool getObject() {
			return getObject(
				fields_.IDLogcode
			);
		}
		/// <summary>
		/// Selects Logcode values from Database and assigns them to the appropriate DO0_Logcode property.
		/// </summary>
		/// <param name="IDLogcode_in">IDLogcode</param>
		/// <returns>True if Logcode exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
			bool getObject(
			long IDLogcode_in
		) {
			if (IDLogcode_in != 0L) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDLogcode_", DbType.Int64, ParameterDirection.InputOutput, IDLogcode_in, 0), 
					base.Connection.newDBDataParameter("Warning_", DbType.Boolean, ParameterDirection.Output, null, 0), 
					base.Connection.newDBDataParameter("Error_", DbType.Boolean, ParameterDirection.Output, null, 0), 
					base.Connection.newDBDataParameter("Code_", DbType.String, ParameterDirection.Output, null, 50), 
					base.Connection.newDBDataParameter("Description_", DbType.String, ParameterDirection.Output, null, 255)
				};
				base.Connection.Execute_SQLFunction("sp0_Logcode_getObject", _dataparameters);

				if (_dataparameters[0].Value != DBNull.Value) {
					if (_dataparameters[0].Value == System.DBNull.Value) {
						fields_.IDLogcode = 0L;
					} else {
						fields_.IDLogcode = (long)_dataparameters[0].Value;
					}
					if (_dataparameters[1].Value == System.DBNull.Value) {
						fields_.Warning = false;
					} else {
						fields_.Warning = (bool)_dataparameters[1].Value;
					}
					if (_dataparameters[2].Value == System.DBNull.Value) {
						fields_.Error = false;
					} else {
						fields_.Error = (bool)_dataparameters[2].Value;
					}
					if (_dataparameters[3].Value == System.DBNull.Value) {
						fields_.Code = string.Empty;
					} else {
						fields_.Code = (string)_dataparameters[3].Value;
					}
					if (_dataparameters[4].Value == System.DBNull.Value) {
						fields_.Description_isNull = true;
					} else {
						fields_.Description = (string)_dataparameters[4].Value;
					}

					fields_.haschanges_ = false;
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
		/// Deletes Logcode from Database.
		/// </summary>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void delObject() {
			delObject(
				fields_.IDLogcode
			);
		}
		/// <summary>
		/// Deletes Logcode from Database.
		/// </summary>
		/// <param name="IDLogcode_in">IDLogcode</param>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void delObject(
			long IDLogcode_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDLogcode_", DbType.Int64, ParameterDirection.Input, IDLogcode_in, 0)
			};
			base.Connection.Execute_SQLFunction("sp0_Logcode_delObject", _dataparameters);

			clrObject();
		}
		#endregion
		#region public bool isObject(...);
		/// <summary>
		/// Checks to see if Logcode exists at Database
		/// </summary>
		/// <returns>True if Logcode exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool isObject() {
			return isObject(
				fields_.IDLogcode
			);
		}
		/// <summary>
		/// Checks to see if Logcode exists at Database
		/// </summary>
		/// <param name="IDLogcode_in">IDLogcode</param>
		/// <returns>True if Logcode exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool isObject(
			long IDLogcode_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDLogcode_", DbType.Int64, ParameterDirection.Input, IDLogcode_in, 0)
			};

			return (bool)base.Connection.Execute_SQLFunction(
				"fnc0_Logcode_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion
		#region public long insObject(...);
		/// <summary>
		/// Inserts Logcode values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <returns>insertion sequence/identity seed</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		long insObject(
			bool selectIdentity_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDLogcode_", DbType.Int64, ParameterDirection.Output, null, 0), 
				base.Connection.newDBDataParameter("Warning_", DbType.Boolean, ParameterDirection.Input, fields_.Warning, 0), 
				base.Connection.newDBDataParameter("Error_", DbType.Boolean, ParameterDirection.Input, fields_.Error, 0), 
				base.Connection.newDBDataParameter("Code_", DbType.String, ParameterDirection.Input, fields_.Code, 50), 
				base.Connection.newDBDataParameter("Description_", DbType.String, ParameterDirection.Input, fields_.Description_isNull ? null : (object)fields_.Description, 255), 

				base.Connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			base.Connection.Execute_SQLFunction(
				"sp0_Logcode_insObject", 
				_dataparameters
			);

			fields_.IDLogcode = (long)_dataparameters[0].Value;
			fields_.haschanges_ = false;
			

			return fields_.IDLogcode;
		}
		#endregion
		#region public void updObject(...);
		/// <summary>
		/// Updates Logcode values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void updObject(bool forceUpdate_in) {
			if (forceUpdate_in || fields_.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDLogcode_", DbType.Int64, ParameterDirection.Input, fields_.IDLogcode, 0), 
					base.Connection.newDBDataParameter("Warning_", DbType.Boolean, ParameterDirection.Input, fields_.Warning, 0), 
					base.Connection.newDBDataParameter("Error_", DbType.Boolean, ParameterDirection.Input, fields_.Error, 0), 
					base.Connection.newDBDataParameter("Code_", DbType.String, ParameterDirection.Input, fields_.Code, 50), 
					base.Connection.newDBDataParameter("Description_", DbType.String, ParameterDirection.Input, fields_.Description_isNull ? null : (object)fields_.Description, 255)
				};
				base.Connection.Execute_SQLFunction(
					"sp0_Logcode_updObject", 
					_dataparameters
				);
				fields_.haschanges_ = false;
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