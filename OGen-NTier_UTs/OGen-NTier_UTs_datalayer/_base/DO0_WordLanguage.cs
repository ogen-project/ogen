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
	/// WordLanguage DataObject which provides access to WordLanguage table at Database.
	/// </summary>
	[DOClassAttribute("WordLanguage", "", "", "", false, false)]
	public 
#if USE_PARTIAL_CLASSES && !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if USE_PARTIAL_CLASSES && !NET_1_1
		DO_WordLanguage 
#else
		DO0_WordLanguage 
#endif
		: DO__base {
		#region public DO_WordLanguage();
#if USE_PARTIAL_CLASSES && !NET_1_1
		///
		public DO_WordLanguage
#else
		internal DO0_WordLanguage
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
			public DO_WordLanguage
#else
			internal DO0_WordLanguage
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
		#region public SO_WordLanguage Fields { get; set; }
		internal SO_WordLanguage fields_;

		public ISO_WordLanguage Fields {
			get { return fields_; }
			set { fields_ = (SO_WordLanguage)value; }
		}
		#endregion
		#region public RO0_WordLanguage Record { get; }
		private RO0_WordLanguage record__;

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public RO0_WordLanguage Record {
			get {
				if (record__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					record__ = new RO0_WordLanguage(this);
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
		#region public SC_WordLanguage Serialize();
		public SO_WordLanguage Serialize() {
			return fields_;
		}
		#endregion
		#region public void clrObject();
		/// <summary>
		/// Clears all DO0_WordLanguage properties, assigning them with their appropriate default property value.
		/// </summary>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void clrObject() {
			fields_ = new SO_WordLanguage();
		}
		#endregion
		#region public bool getObject(...);
		/// <summary>
		/// Selects WordLanguage values from Database and assigns them to the appropriate DO0_WordLanguage property.
		/// </summary>
		/// <returns>True if WordLanguage exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool getObject() {
			return getObject(
				fields_.IDWord, 
				fields_.IDLanguage
			);
		}
		/// <summary>
		/// Selects WordLanguage values from Database and assigns them to the appropriate DO0_WordLanguage property.
		/// </summary>
		/// <param name="IDWord_in">IDWord</param>
		/// <param name="IDLanguage_in">IDLanguage</param>
		/// <returns>True if WordLanguage exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
			bool getObject(
			long IDWord_in, 
			long IDLanguage_in
		) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDWord_", DbType.Int64, ParameterDirection.InputOutput, IDWord_in, 0), 
					base.Connection.newDBDataParameter("IDLanguage_", DbType.Int64, ParameterDirection.InputOutput, IDLanguage_in, 0), 
					base.Connection.newDBDataParameter("Translation_", DbType.String, ParameterDirection.Output, null, 2048)
				};
				base.Connection.Execute_SQLFunction("sp0_WordLanguage_getObject", _dataparameters);

				if (_dataparameters[0].Value != DBNull.Value) {
					if (_dataparameters[0].Value == System.DBNull.Value) {
						fields_.IDWord = 0L;
					} else {
						fields_.IDWord = (long)_dataparameters[0].Value;
					}
					if (_dataparameters[1].Value == System.DBNull.Value) {
						fields_.IDLanguage = 0L;
					} else {
						fields_.IDLanguage = (long)_dataparameters[1].Value;
					}
					if (_dataparameters[2].Value == System.DBNull.Value) {
						fields_.Translation_isNull = true;
					} else {
						fields_.Translation = (string)_dataparameters[2].Value;
					}

					fields_.haschanges_ = false;
					return true;
				}

			//clrObject();
			//haschanges_ = false;

			return false;
		}
		#endregion
		#region public void delObject(...);
		/// <summary>
		/// Deletes WordLanguage from Database.
		/// </summary>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void delObject() {
			delObject(
				fields_.IDWord, 
				fields_.IDLanguage
			);
		}
		/// <summary>
		/// Deletes WordLanguage from Database.
		/// </summary>
		/// <param name="IDWord_in">IDWord</param>
		/// <param name="IDLanguage_in">IDLanguage</param>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void delObject(
			long IDWord_in, 
			long IDLanguage_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDWord_", DbType.Int64, ParameterDirection.Input, IDWord_in, 0), 
				base.Connection.newDBDataParameter("IDLanguage_", DbType.Int64, ParameterDirection.Input, IDLanguage_in, 0)
			};
			base.Connection.Execute_SQLFunction("sp0_WordLanguage_delObject", _dataparameters);

			clrObject();
		}
		#endregion
		#region public bool isObject(...);
		/// <summary>
		/// Checks to see if WordLanguage exists at Database
		/// </summary>
		/// <returns>True if WordLanguage exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool isObject() {
			return isObject(
				fields_.IDWord, 
				fields_.IDLanguage
			);
		}
		/// <summary>
		/// Checks to see if WordLanguage exists at Database
		/// </summary>
		/// <param name="IDWord_in">IDWord</param>
		/// <param name="IDLanguage_in">IDLanguage</param>
		/// <returns>True if WordLanguage exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool isObject(
			long IDWord_in, 
			long IDLanguage_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDWord_", DbType.Int64, ParameterDirection.Input, IDWord_in, 0), 
				base.Connection.newDBDataParameter("IDLanguage_", DbType.Int64, ParameterDirection.Input, IDLanguage_in, 0)
			};

			return (bool)base.Connection.Execute_SQLFunction(
				"fnc0_WordLanguage_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion
		#region public bool setObject(...);
		/// <summary>
		/// Inserts/Updates WordLanguage values into/on Database. Inserts if WordLanguage doesn't exist or Updates if WordLanguage already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
			bool setObject(bool forceUpdate_in) {
			bool ConstraintExist_out;
			if (forceUpdate_in || fields_.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDWord_", DbType.Int64, ParameterDirection.Input, fields_.IDWord, 0), 
					base.Connection.newDBDataParameter("IDLanguage_", DbType.Int64, ParameterDirection.Input, fields_.IDLanguage, 0), 
					base.Connection.newDBDataParameter("Translation_", DbType.String, ParameterDirection.Input, fields_.Translation_isNull ? null : (object)fields_.Translation, 2048), 

					//base.Connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					base.Connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				base.Connection.Execute_SQLFunction(
					"sp0_WordLanguage_setObject", 
					_dataparameters
				);

				ConstraintExist_out = (((int)_dataparameters[3].Value & 2) == 1);
				if (!ConstraintExist_out) {
					fields_.haschanges_ = false;
				}

				return (((int)_dataparameters[3].Value & 1) != 1);
			} else {
				ConstraintExist_out = false;

				return  false;
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