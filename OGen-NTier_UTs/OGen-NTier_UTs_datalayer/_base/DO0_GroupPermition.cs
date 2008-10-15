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
	/// GroupPermition DataObject which provides access to GroupPermition table at Database.
	/// </summary>
	[DOClassAttribute("GroupPermition", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		DO_GroupPermition 
#else
		DO0_GroupPermition 
#endif
		: DO__base {
		#region public DO_GroupPermition();
#if !NET_1_1
		///
		public DO_GroupPermition
#else
		internal DO0_GroupPermition
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
			public DO_GroupPermition
#else
			internal DO0_GroupPermition
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
		#region public SO_GroupPermition Fields { get; set; }
		internal SO_GroupPermition fields_;

		public ISO_GroupPermition Fields {
			get { return fields_; }
			set { fields_ = (SO_GroupPermition)value; }
		}
		#endregion
		#region public RO0_GroupPermition Record { get; }
		private RO0_GroupPermition record__;

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public RO0_GroupPermition Record {
			get {
				if (record__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					record__ = new RO0_GroupPermition(this);
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
		#region public SC_GroupPermition Serialize();
		public SO_GroupPermition Serialize() {
			return fields_;
		}
		#endregion
		#region public void clrObject();
		/// <summary>
		/// Clears all DO0_GroupPermition properties, assigning them with their appropriate default property value.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		void clrObject() {
			fields_ = new SO_GroupPermition();
		}
		#endregion
		#region public bool getObject(...);
		/// <summary>
		/// Selects GroupPermition values from Database and assigns them to the appropriate DO0_GroupPermition property.
		/// </summary>
		/// <returns>True if GroupPermition exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool getObject() {
			return getObject(
				fields_.IDGroup, 
				fields_.IDPermition
			);
		}
		/// <summary>
		/// Selects GroupPermition values from Database and assigns them to the appropriate DO0_GroupPermition property.
		/// </summary>
		/// <param name="IDGroup_in">IDGroup</param>
		/// <param name="IDPermition_in">IDPermition</param>
		/// <returns>True if GroupPermition exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
			bool getObject(
			long IDGroup_in, 
			long IDPermition_in
		) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDGroup_", DbType.Int64, ParameterDirection.InputOutput, IDGroup_in, 0), 
					base.Connection.newDBDataParameter("IDPermition_", DbType.Int64, ParameterDirection.InputOutput, IDPermition_in, 0)
				};
				base.Connection.Execute_SQLFunction("sp0_GroupPermition_getObject", _dataparameters);

				if (_dataparameters[0].Value != DBNull.Value) {
					if (_dataparameters[0].Value == System.DBNull.Value) {
						fields_.IDGroup = 0L;
					} else {
						fields_.IDGroup = (long)_dataparameters[0].Value;
					}
					if (_dataparameters[1].Value == System.DBNull.Value) {
						fields_.IDPermition = 0L;
					} else {
						fields_.IDPermition = (long)_dataparameters[1].Value;
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
		/// Deletes GroupPermition from Database.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		void delObject() {
			delObject(
				fields_.IDGroup, 
				fields_.IDPermition
			);
		}
		/// <summary>
		/// Deletes GroupPermition from Database.
		/// </summary>
		/// <param name="IDGroup_in">IDGroup</param>
		/// <param name="IDPermition_in">IDPermition</param>
		public 
#if NET_1_1
			virtual 
#endif
		void delObject(
			long IDGroup_in, 
			long IDPermition_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDGroup_", DbType.Int64, ParameterDirection.Input, IDGroup_in, 0), 
				base.Connection.newDBDataParameter("IDPermition_", DbType.Int64, ParameterDirection.Input, IDPermition_in, 0)
			};
			base.Connection.Execute_SQLFunction("sp0_GroupPermition_delObject", _dataparameters);

			clrObject();
		}
		#endregion
		#region public bool isObject(...);
		/// <summary>
		/// Checks to see if GroupPermition exists at Database
		/// </summary>
		/// <returns>True if GroupPermition exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool isObject() {
			return isObject(
				fields_.IDGroup, 
				fields_.IDPermition
			);
		}
		/// <summary>
		/// Checks to see if GroupPermition exists at Database
		/// </summary>
		/// <param name="IDGroup_in">IDGroup</param>
		/// <param name="IDPermition_in">IDPermition</param>
		/// <returns>True if GroupPermition exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool isObject(
			long IDGroup_in, 
			long IDPermition_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				base.Connection.newDBDataParameter("IDGroup_", DbType.Int64, ParameterDirection.Input, IDGroup_in, 0), 
				base.Connection.newDBDataParameter("IDPermition_", DbType.Int64, ParameterDirection.Input, IDPermition_in, 0)
			};

			return (bool)base.Connection.Execute_SQLFunction(
				"fnc0_GroupPermition_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion
		#region public bool setObject(...);
		/// <summary>
		/// Inserts/Updates GroupPermition values into/on Database. Inserts if GroupPermition doesn't exist or Updates if GroupPermition already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public 
#if NET_1_1
			virtual 
#endif
			bool setObject(bool forceUpdate_in) {
			bool ConstraintExist_out;
			if (forceUpdate_in || fields_.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
					base.Connection.newDBDataParameter("IDGroup_", DbType.Int64, ParameterDirection.Input, fields_.IDGroup, 0), 
					base.Connection.newDBDataParameter("IDPermition_", DbType.Int64, ParameterDirection.Input, fields_.IDPermition, 0), 

					//base.Connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)
					base.Connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				base.Connection.Execute_SQLFunction(
					"sp0_GroupPermition_setObject", 
					_dataparameters
				);

				ConstraintExist_out = (((int)_dataparameters[2].Value & 2) == 1);
				if (!ConstraintExist_out) {
					fields_.haschanges_ = false;
				}

				return (((int)_dataparameters[2].Value & 1) != 1);
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