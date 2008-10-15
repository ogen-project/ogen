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
	/// User DataObject which provides access to User table at Database.
	/// </summary>
	[DOClassAttribute("User", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		DO_User 
#else
		DO0_User 
#endif
		: DO__base {
		#region public DO_User();
#if !NET_1_1
		///
		public DO_User
#else
		internal DO0_User
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
			fields_.haschanges_ = false;
		}
#if !NET_1_1
			/// <summary>
			/// Making the use of Database Transactions possible on a sequence of operations across multiple DataObjects.
			/// </summary>
			/// <param name="connection_in">opened Database connection with an initiated Transaction</param>
			public DO_User
#else
			internal DO0_User
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
		#region public SO_User Fields { get; set; }
		internal SO_User fields_;

		public ISO_User Fields {
			get { return fields_; }
			set { fields_ = (SO_User)value; }
		}
		#endregion
		#region public RO0_User Record { get; }
		private RO0_User record__;

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public RO0_User Record {
			get {
				if (record__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					record__ = new RO0_User(this);
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
		#region public SC_User Serialize();
		public SO_User Serialize() {
			return fields_;
		}
		#endregion
		#region public void clrObject();
		/// <summary>
		/// Clears all DO0_User properties, assigning them with their appropriate default property value.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		void clrObject() {
			fields_ = new SO_User();
		}
		#endregion
		#region public bool getObject(...);
		/// <summary>
		/// Selects User values from Database and assigns them to the appropriate DO0_User property.
		/// </summary>
		/// <returns>True if User exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool getObject() {
			return getObject(
				fields_.IDUser
			);
		}
		/// <summary>
		/// Selects User values from Database and assigns them to the appropriate DO0_User property.
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		/// <returns>True if User exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
			bool getObject(
			long IDUser_in
		) {
			if (IDUser_in != 0L) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.InputOutput, IDUser_in, 0), 
					base.Connection.newDBDataParameter("Login_", DbType.String, ParameterDirection.Output, null, 50), 
					base.Connection.newDBDataParameter("Password_", DbType.String, ParameterDirection.Output, null, 50), 
					base.Connection.newDBDataParameter("SomeNullValue_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				base.Connection.Execute_SQLFunction("sp0_User_getObject", _dataparameters);

				if (_dataparameters[0].Value != DBNull.Value) {
					if (_dataparameters[0].Value == System.DBNull.Value) {
						fields_.IDUser = 0L;
					} else {
						fields_.IDUser = (long)_dataparameters[0].Value;
					}
					if (_dataparameters[1].Value == System.DBNull.Value) {
						fields_.Login = string.Empty;
					} else {
						fields_.Login = (string)_dataparameters[1].Value;
					}
					if (_dataparameters[2].Value == System.DBNull.Value) {
						fields_.Password = string.Empty;
					} else {
						fields_.Password = (string)_dataparameters[2].Value;
					}
					if (_dataparameters[3].Value == System.DBNull.Value) {
						fields_.SomeNullValue_isNull = true;
					} else {
						fields_.SomeNullValue = (int)_dataparameters[3].Value;
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
		/// Deletes User from Database.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		void delObject() {
			delObject(
				fields_.IDUser
			);
		}
		/// <summary>
		/// Deletes User from Database.
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		public 
#if NET_1_1
			virtual 
#endif
		void delObject(
			long IDUser_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, IDUser_in, 0)
			};
			base.Connection.Execute_SQLFunction("sp0_User_delObject", _dataparameters);

			clrObject();
		}
		#endregion
		#region public bool isObject(...);
		/// <summary>
		/// Checks to see if User exists at Database
		/// </summary>
		/// <returns>True if User exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool isObject() {
			return isObject(
				fields_.IDUser
			);
		}
		/// <summary>
		/// Checks to see if User exists at Database
		/// </summary>
		/// <param name="IDUser_in">IDUser</param>
		/// <returns>True if User exists at Database, False if not</returns>
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
				"fnc0_User_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion
		#region public long insObject(...);
		/// <summary>
		/// Inserts User values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param>
		/// <param name="constraintExist_out">returns True if constraint exists and insertion failed, and False if no constraint and insertion was successful</param>
		/// <returns>insertion sequence/identity seed</returns>
		public 
#if NET_1_1
			virtual 
#endif
		long insObject(
			bool selectIdentity_in, 
			out bool constraintExist_out
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Output, null, 0), 
				base.Connection.newDBDataParameter("Login_", DbType.String, ParameterDirection.Input, fields_.Login, 50), 
				base.Connection.newDBDataParameter("Password_", DbType.String, ParameterDirection.Input, fields_.Password, 50), 
				base.Connection.newDBDataParameter("SomeNullValue_", DbType.Int32, ParameterDirection.Input, fields_.SomeNullValue_isNull ? null : (object)fields_.SomeNullValue, 0), 

				base.Connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			base.Connection.Execute_SQLFunction(
				"sp0_User_insObject", 
				_dataparameters
			);

			fields_.IDUser = (long)_dataparameters[0].Value;
			constraintExist_out = (fields_.IDUser == -1L);
			if (!constraintExist_out) {
				fields_.haschanges_ = false;
			}

			return fields_.IDUser;
		}
		#endregion
		#region public void updObject(...);
		/// <summary>
		/// Updates User values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="constraintExist_out">returns True if constraint exists and Update failed, and False if no constraint and Update was successful</param>
		public 
#if NET_1_1
			virtual 
#endif
		void updObject(bool forceUpdate_in, out bool constraintExist_out) {
			if (forceUpdate_in || fields_.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, fields_.IDUser, 0), 
					base.Connection.newDBDataParameter("Login_", DbType.String, ParameterDirection.Input, fields_.Login, 50), 
					base.Connection.newDBDataParameter("Password_", DbType.String, ParameterDirection.Input, fields_.Password, 50), 
					base.Connection.newDBDataParameter("SomeNullValue_", DbType.Int32, ParameterDirection.Input, fields_.SomeNullValue_isNull ? null : (object)fields_.SomeNullValue, 0), 

					base.Connection.newDBDataParameter("ConstraintExist_", DbType.Boolean, ParameterDirection.Output, null, 1)
				};
				base.Connection.Execute_SQLFunction(
					"sp0_User_updObject", 
					_dataparameters
				);
				
				constraintExist_out = (bool)_dataparameters[4].Value;
				if (!constraintExist_out) {
					fields_.haschanges_ = false;
				}
			} else {
				constraintExist_out = false;
			}
		}
		#endregion
		#endregion
		#region Methods - Search...
		#region public void ???Object_byLogin
		#region public bool getObject_byLogin(...);
		/// <summary>
		/// Selects User values from Database (based on the search condition) and assigns them to the appropriate DO0_User property.
		/// </summary>
		/// <param name="Login_search_in">Login search condition</param>
		/// <returns>True if User exists at Database, False if not</returns>
		public bool getObject_byLogin(
			string Login_search_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("Login_search_", DbType.String, ParameterDirection.Input, Login_search_in, 50), 
				base.Connection.newDBDataParameter("IDUser", DbType.Int64, ParameterDirection.Output, null, 0), 
				base.Connection.newDBDataParameter("Login", DbType.String, ParameterDirection.Output, null, 50), 
				base.Connection.newDBDataParameter("Password", DbType.String, ParameterDirection.Output, null, 50), 
				base.Connection.newDBDataParameter("SomeNullValue", DbType.Int32, ParameterDirection.Output, null, 0)
			};
			base.Connection.Execute_SQLFunction(
				"sp0_User_getObject_byLogin", 
				_dataparameters
			);

			if (_dataparameters[1].Value != DBNull.Value) {
				if (_dataparameters[1].Value == System.DBNull.Value) {
					fields_.IDUser = 0L;
				} else {
					fields_.IDUser = (long)_dataparameters[1].Value;
				}
				if (_dataparameters[2].Value == System.DBNull.Value) {
					fields_.Login = string.Empty;
				} else {
					fields_.Login = (string)_dataparameters[2].Value;
				}
				if (_dataparameters[3].Value == System.DBNull.Value) {
					fields_.Password = string.Empty;
				} else {
					fields_.Password = (string)_dataparameters[3].Value;
				}
				if (_dataparameters[4].Value == System.DBNull.Value) {
					fields_.SomeNullValue_isNull = true;
				} else {
					fields_.SomeNullValue = (int)_dataparameters[4].Value;
				}

				fields_.haschanges_ = false;
				return true;
			}

			//clrObject();
			//fields_.haschanges_ = false;

			return false;
		}
		#endregion
		#region public bool delObject_byLogin(...);
		/// <summary>
		/// Deletes User from Database (based on the search condition).
		/// </summary>
		/// <param name="Login_search_in"> Login search condition</param>
		/// <returns>True if User existed and was Deleted at Database, False if it didn't exist</returns>
		public bool delObject_byLogin(
			string Login_search_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("Login_search_", DbType.String, ParameterDirection.Input, Login_search_in, 50), 

				base.Connection.newDBDataParameter("Exists_", DbType.Boolean, ParameterDirection.Output, null, 1)
			};
			base.Connection.Execute_SQLFunction("sp0_User_delObject_byLogin", _dataparameters);

			return ((bool)_dataparameters[1].Value);
		}
		#endregion
		#region public bool isObject_byLogin(...);
		/// <summary>
		/// Checks to see if User exists at Database (based on the search condition).
		/// </summary>
		/// <param name="Login_search_in">Login search condition</param>
		/// <returns>True if User exists at Database, False if not</returns>
		public bool isObject_byLogin(
			string Login_search_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("Login_search_", DbType.String, ParameterDirection.Input, Login_search_in, 50)
			};
			return (bool)base.Connection.Execute_SQLFunction(
				"fnc0_User_isObject_byLogin", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion
		#endregion
		#endregion
		#region Methods - Updates...
		#region public void updObject_SomeUpdateTest(...);
		/// <summary>
		/// Updates User specific(only) values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="constraintExist_out">returns True if constraint exists and Update failed, and False if no constraint and Update was successful</param>
		public 
#if NET_1_1
			virtual 
#endif
		void updObject_SomeUpdateTest(bool forceUpdate_in, out bool constraintExist_out) {
			if (forceUpdate_in || fields_.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDUser", DbType.Int64, ParameterDirection.Input, fields_.IDUser, 0), 
					base.Connection.newDBDataParameter("Password_update", DbType.String, ParameterDirection.Input, fields_.Password, 50), 

					base.Connection.newDBDataParameter("ConstraintExist", DbType.Boolean, ParameterDirection.Output, null, 1)
				};
				base.Connection.Execute_SQLFunction(
					"sp0_User_updObject_SomeUpdateTest", 
					_dataparameters
				);
				
				constraintExist_out = (bool)_dataparameters[4].Value;
				if (!constraintExist_out) {
					fields_.haschanges_ = false;
				}
			} else {
				constraintExist_out = false;
			}
		}
		#endregion
		#endregion
	}
}