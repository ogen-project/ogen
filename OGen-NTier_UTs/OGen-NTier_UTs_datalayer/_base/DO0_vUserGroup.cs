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
	/// vUserGroup DataObject which provides access to vUserGroup view at Database.
	/// </summary>
	[DOClassAttribute("vUserGroup", "", "", "", true, false)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		DO_vUserGroup 
#else
		DO0_vUserGroup 
#endif
		: DO__base {
		#region public DO_vUserGroup();
#if !NET_1_1
		///
		public DO_vUserGroup
#else
		internal DO0_vUserGroup
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
			public DO_vUserGroup
#else
			internal DO0_vUserGroup
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
		#region public SO_vUserGroup Fields { get; set; }
		internal SO_vUserGroup fields_;

		public ISO_vUserGroup Fields {
			get { return fields_; }
			set { fields_ = (SO_vUserGroup)value; }
		}
		#endregion
		#region public RO0_vUserGroup Record { get; }
		private RO0_vUserGroup record__;

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public RO0_vUserGroup Record {
			get {
				if (record__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					record__ = new RO0_vUserGroup(this);
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
		#region public SC_vUserGroup Serialize();
		public SO_vUserGroup Serialize() {
			return fields_;
		}
		#endregion
		#region public void clrObject();
		/// <summary>
		/// Clears all DO0_vUserGroup properties, assigning them with their appropriate default property value.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		void clrObject() {
			fields_ = new SO_vUserGroup();
		}
		#endregion
		#endregion
		#region Methods - Search...
		#endregion
		#region Methods - Updates...
		#endregion
	}
}