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
	/// Language DataObject which provides access to Language table at Database.
	/// </summary>
	[DOClassAttribute("Language", "", "", "", false, false)]
	public 
#if USE_PARTIAL_CLASSES && !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if USE_PARTIAL_CLASSES && !NET_1_1
		DO_Language 
#else
		DO0_Language 
#endif
		: DO__base {
		#region public DO_Language();
#if USE_PARTIAL_CLASSES && !NET_1_1
		///
		public DO_Language
#else
		internal DO0_Language
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
			public DO_Language
#else
			internal DO0_Language
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
		#region public SO_Language Fields { get; set; }
		internal SO_Language fields_;

		public ISO_Language Fields {
			get { return fields_; }
			set { fields_ = (SO_Language)value; }
		}
		#endregion
		#region public RO0_Language Record { get; }
		private RO0_Language record__;

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public RO0_Language Record {
			get {
				if (record__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					record__ = new RO0_Language(this);
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
		#region public SC_Language Serialize();
		public SO_Language Serialize() {
			return fields_;
		}
		#endregion
		#region public void clrObject();
		/// <summary>
		/// Clears all DO0_Language properties, assigning them with their appropriate default property value.
		/// </summary>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void clrObject() {
			fields_ = new SO_Language();
		}
		#endregion
		#region public bool getObject(...);
		/// <summary>
		/// Selects Language values from Database and assigns them to the appropriate DO0_Language property.
		/// </summary>
		/// <returns>True if Language exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool getObject() {
			return getObject(
				fields_.IDLanguage
			);
		}
		/// <summary>
		/// Selects Language values from Database and assigns them to the appropriate DO0_Language property.
		/// </summary>
		/// <param name="IDLanguage_in">IDLanguage</param>
		/// <returns>True if Language exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
			bool getObject(
			long IDLanguage_in
		) {
			if (IDLanguage_in != 0L) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDLanguage_", DbType.Int64, ParameterDirection.InputOutput, IDLanguage_in, 0), 
					base.Connection.newDBDataParameter("IDWord_name_", DbType.Int64, ParameterDirection.Output, null, 0)
				};
				base.Connection.Execute_SQLFunction("sp0_Language_getObject", _dataparameters);

				if (_dataparameters[0].Value != DBNull.Value) {
					if (_dataparameters[0].Value == System.DBNull.Value) {
						fields_.IDLanguage = 0L;
					} else {
						fields_.IDLanguage = (long)_dataparameters[0].Value;
					}
					if (_dataparameters[1].Value == System.DBNull.Value) {
						fields_.IDWord_name = 0L;
					} else {
						fields_.IDWord_name = (long)_dataparameters[1].Value;
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
		/// Deletes Language from Database.
		/// </summary>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void delObject() {
			delObject(
				fields_.IDLanguage
			);
		}
		/// <summary>
		/// Deletes Language from Database.
		/// </summary>
		/// <param name="IDLanguage_in">IDLanguage</param>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void delObject(
			long IDLanguage_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDLanguage_", DbType.Int64, ParameterDirection.Input, IDLanguage_in, 0)
			};
			base.Connection.Execute_SQLFunction("sp0_Language_delObject", _dataparameters);

			clrObject();
		}
		#endregion
		#region public bool isObject(...);
		/// <summary>
		/// Checks to see if Language exists at Database
		/// </summary>
		/// <returns>True if Language exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool isObject() {
			return isObject(
				fields_.IDLanguage
			);
		}
		/// <summary>
		/// Checks to see if Language exists at Database
		/// </summary>
		/// <param name="IDLanguage_in">IDLanguage</param>
		/// <returns>True if Language exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool isObject(
			long IDLanguage_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDLanguage_", DbType.Int64, ParameterDirection.Input, IDLanguage_in, 0)
			};

			return (bool)base.Connection.Execute_SQLFunction(
				"fnc0_Language_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion
		#region public long insObject(...);
		/// <summary>
		/// Inserts Language values into Database.
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
				base.Connection.newDBDataParameter("IDLanguage_", DbType.Int64, ParameterDirection.Output, null, 0), 
				base.Connection.newDBDataParameter("IDWord_name_", DbType.Int64, ParameterDirection.Input, fields_.IDWord_name, 0), 

				base.Connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			base.Connection.Execute_SQLFunction(
				"sp0_Language_insObject", 
				_dataparameters
			);

			fields_.IDLanguage = (long)_dataparameters[0].Value;
			fields_.haschanges_ = false;
			

			return fields_.IDLanguage;
		}
		#endregion
		#region public void updObject(...);
		/// <summary>
		/// Updates Language values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void updObject(bool forceUpdate_in) {
			if (forceUpdate_in || fields_.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDLanguage_", DbType.Int64, ParameterDirection.Input, fields_.IDLanguage, 0), 
					base.Connection.newDBDataParameter("IDWord_name_", DbType.Int64, ParameterDirection.Input, fields_.IDWord_name, 0)
				};
				base.Connection.Execute_SQLFunction(
					"sp0_Language_updObject", 
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