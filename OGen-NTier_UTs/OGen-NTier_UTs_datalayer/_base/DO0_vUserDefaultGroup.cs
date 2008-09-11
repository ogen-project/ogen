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
	/// vUserDefaultGroup DataObject which provides access to vUserDefaultGroup view at Database.
	/// </summary>
	[DOClassAttribute("vUserDefaultGroup", "", "", "", true, false)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		DO_vUserDefaultGroup 
#else
		DO0_vUserDefaultGroup 
#endif
		: DO__base {
		#region public DO_vUserDefaultGroup();
#if !NET_1_1
		///
		public DO_vUserDefaultGroup
#else
		internal DO0_vUserDefaultGroup
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
			public DO_vUserDefaultGroup
#else
			internal DO0_vUserDefaultGroup
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
		#region public FO0_vUserDefaultGroup Fields { get; set; }
		internal SO0_vUserDefaultGroup fields_;

		public SO0_vUserDefaultGroup Fields {
			get { return fields_; }
			set { fields_ = value; }
		}
		#endregion
		#region public RO0_vUserDefaultGroup Record { get; }
		private RO0_vUserDefaultGroup record__;

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public RO0_vUserDefaultGroup Record {
			get {
				if (record__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					record__ = new RO0_vUserDefaultGroup(this);
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
		#region public SC0_vUserDefaultGroup Serialize();
		public SO0_vUserDefaultGroup Serialize() {
			return Fields;
		}
		#endregion
		#region public void clrObject();
		/// <summary>
		/// Clears all DO0_vUserDefaultGroup properties, assigning them with their appropriate default property value.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		void clrObject() {
			Fields = new SO0_vUserDefaultGroup();
		}
		#endregion
		#region public bool getObject(...);
		/// <summary>
		/// Selects vUserDefaultGroup values from Database and assigns them to the appropriate DO0_vUserDefaultGroup property.
		/// </summary>
		/// <returns>True if vUserDefaultGroup exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool getObject() {
			return getObject(
				Fields.IDUser
			);
		}
		/// <summary>
		/// Selects vUserDefaultGroup values from Database and assigns them to the appropriate DO0_vUserDefaultGroup property.
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		/// <returns>True if vUserDefaultGroup exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
			bool getObject(
			long IDUser_in
		) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.InputOutput, IDUser_in, 0), 
					base.Connection.newDBDataParameter("Login_", DbType.String, ParameterDirection.Output, null, 50), 
					base.Connection.newDBDataParameter("IDGroup_", DbType.Int64, ParameterDirection.Output, null, 0), 
					base.Connection.newDBDataParameter("Name_", DbType.String, ParameterDirection.Output, null, 50), 
					base.Connection.newDBDataParameter("Relationdate_", DbType.DateTime, ParameterDirection.Output, null, 0)
				};
				base.Connection.Execute_SQLFunction("sp0_vUserDefaultGroup_getObject", _dataparameters);

				if (_dataparameters[0].Value != DBNull.Value) {
					if (_dataparameters[0].Value == System.DBNull.Value) {
						Fields.IDUser = 0L;
					} else {
						Fields.IDUser = (long)_dataparameters[0].Value;
					}
					if (_dataparameters[1].Value == System.DBNull.Value) {
						Fields.Login = string.Empty;
					} else {
						Fields.Login = (string)_dataparameters[1].Value;
					}
					if (_dataparameters[2].Value == System.DBNull.Value) {
						Fields.IDGroup = 0L;
					} else {
						Fields.IDGroup = (long)_dataparameters[2].Value;
					}
					if (_dataparameters[3].Value == System.DBNull.Value) {
						Fields.Name = string.Empty;
					} else {
						Fields.Name = (string)_dataparameters[3].Value;
					}
					if (_dataparameters[4].Value == System.DBNull.Value) {
						Fields.Relationdate = new DateTime(1900, 1, 1);
					} else {
						Fields.Relationdate = (DateTime)_dataparameters[4].Value;
					}

					Fields.haschanges_ = false;
					return true;
				}

			//clrObject();
			//haschanges_ = false;

			return false;
		}
		#endregion
		#region public bool isObject(...);
		/// <summary>
		/// Checks to see if vUserDefaultGroup exists at Database
		/// </summary>
		/// <returns>True if vUserDefaultGroup exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool isObject() {
			return isObject(
				Fields.IDUser
			);
		}
		/// <summary>
		/// Checks to see if vUserDefaultGroup exists at Database
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		/// <returns>True if vUserDefaultGroup exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool isObject(
			long IDUser_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, IDUser_in, 0)
			};

			return (bool)base.Connection.Execute_SQLFunction(
				"fnc0_vUserDefaultGroup_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion
		#endregion
		#region Methods - Search...
		#endregion
		#region Methods - Updates...
		#endregion
	}
}