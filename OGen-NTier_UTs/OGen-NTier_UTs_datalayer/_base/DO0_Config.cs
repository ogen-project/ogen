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
	/// Config DataObject which provides access to Config table at Database.
	/// </summary>
	[DOClassAttribute("Config", "", "", "", false, true)]
	public 
#if USE_PARTIAL_CLASSES && !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if USE_PARTIAL_CLASSES && !NET_1_1
		DO_Config 
#else
		DO0_Config 
#endif
		: DO__base {
		#region public DO_Config();
#if USE_PARTIAL_CLASSES && !NET_1_1
		///
		public DO_Config
#else
		internal DO0_Config
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
			public DO_Config
#else
			internal DO0_Config
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
		#region public SO_Config Fields { get; set; }
		internal SO_Config fields_;

		public ISO_Config Fields {
			get { return fields_; }
			set { fields_ = (SO_Config)value; }
		}
		#endregion
		#region public RO0_Config Record { get; }
		private RO0_Config record__;

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public RO0_Config Record {
			get {
				if (record__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					record__ = new RO0_Config(this);
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
		#region public SC_Config Serialize();
		public SO_Config Serialize() {
			return fields_;
		}
		#endregion
		#region public void clrObject();
		/// <summary>
		/// Clears all DO0_Config properties, assigning them with their appropriate default property value.
		/// </summary>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void clrObject() {
			fields_ = new SO_Config();
		}
		#endregion
		#region public bool getObject(...);
		/// <summary>
		/// Selects Config values from Database and assigns them to the appropriate DO0_Config property.
		/// </summary>
		/// <returns>True if Config exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool getObject() {
			return getObject(
				fields_.Name
			);
		}
		/// <summary>
		/// Selects Config values from Database and assigns them to the appropriate DO0_Config property.
		/// </summary>
		/// <param name="Name_in">Name</param>
		/// <returns>True if Config exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
			bool getObject(
			string Name_in
		) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("Name_", DbType.String, ParameterDirection.InputOutput, Name_in, 50), 
					base.Connection.newDBDataParameter("Config_", DbType.String, ParameterDirection.Output, null, 50), 
					base.Connection.newDBDataParameter("Type_", DbType.Int32, ParameterDirection.Output, null, 0), 
					base.Connection.newDBDataParameter("Description_", DbType.String, ParameterDirection.Output, null, 50)
				};
				base.Connection.Execute_SQLFunction("sp0_Config_getObject", _dataparameters);

				if (_dataparameters[0].Value != DBNull.Value) {
					if (_dataparameters[0].Value == System.DBNull.Value) {
						fields_.Name = string.Empty;
					} else {
						fields_.Name = (string)_dataparameters[0].Value;
					}
					if (_dataparameters[1].Value == System.DBNull.Value) {
						fields_.Config = string.Empty;
					} else {
						fields_.Config = (string)_dataparameters[1].Value;
					}
					if (_dataparameters[2].Value == System.DBNull.Value) {
						fields_.Type = 0;
					} else {
						fields_.Type = (int)_dataparameters[2].Value;
					}
					if (_dataparameters[3].Value == System.DBNull.Value) {
						fields_.Description = string.Empty;
					} else {
						fields_.Description = (string)_dataparameters[3].Value;
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
		/// Deletes Config from Database.
		/// </summary>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void delObject() {
			delObject(
				fields_.Name
			);
		}
		/// <summary>
		/// Deletes Config from Database.
		/// </summary>
		/// <param name="Name_in">Name</param>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		void delObject(
			string Name_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("Name_", DbType.String, ParameterDirection.Input, Name_in, 50)
			};
			base.Connection.Execute_SQLFunction("sp0_Config_delObject", _dataparameters);

			clrObject();
		}
		#endregion
		#region public bool isObject(...);
		/// <summary>
		/// Checks to see if Config exists at Database
		/// </summary>
		/// <returns>True if Config exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool isObject() {
			return isObject(
				fields_.Name
			);
		}
		/// <summary>
		/// Checks to see if Config exists at Database
		/// </summary>
		/// <param name="Name_in">Name</param>
		/// <returns>True if Config exists at Database, False if not</returns>
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool isObject(
			string Name_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("Name_", DbType.String, ParameterDirection.Input, Name_in, 50)
			};

			return (bool)base.Connection.Execute_SQLFunction(
				"fnc0_Config_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion
		#region public bool setObject(...);
		/// <summary>
		/// Inserts/Updates Config values into/on Database. Inserts if Config doesn't exist or Updates if Config already exists.
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
					base.Connection.newDBDataParameter("Name_", DbType.String, ParameterDirection.Input, fields_.Name, 50), 
					base.Connection.newDBDataParameter("Config_", DbType.String, ParameterDirection.Input, fields_.Config, 50), 
					base.Connection.newDBDataParameter("Type_", DbType.Int32, ParameterDirection.Input, fields_.Type, 0), 
					base.Connection.newDBDataParameter("Description_", DbType.String, ParameterDirection.Input, fields_.Description, 50), 

					//base.Connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					base.Connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				base.Connection.Execute_SQLFunction(
					"sp0_Config_setObject", 
					_dataparameters
				);

				ConstraintExist_out = (((int)_dataparameters[4].Value & 2) == 1);
				if (!ConstraintExist_out) {
					fields_.haschanges_ = false;

					#region DO__utils...._reset();
					switch (fields_.Name) {
						case "SomeBoolConfig": {
#if USE_PARTIAL_CLASSES && !NET_1_1
							DO__utils
#else
							DO0__utils
#endif
							.SomeBoolConfig_reset();
							break;
						}
						case "SomeIntConfig": {
#if USE_PARTIAL_CLASSES && !NET_1_1
							DO__utils
#else
							DO0__utils
#endif
							.SomeIntConfig_reset();
							break;
						}
						case "SomeMultiLineStringConfig": {
#if USE_PARTIAL_CLASSES && !NET_1_1
							DO__utils
#else
							DO0__utils
#endif
							.SomeMultiLineStringConfig_reset();
							break;
						}
						case "SomeStringConfig": {
#if USE_PARTIAL_CLASSES && !NET_1_1
							DO__utils
#else
							DO0__utils
#endif
							.SomeStringConfig_reset();
							break;
						}
					}
					#endregion
				}

				return (((int)_dataparameters[4].Value & 1) != 1);
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