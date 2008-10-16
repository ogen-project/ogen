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
using System.Xml.Serialization;

using OGen.NTier.lib.datalayer;
using OGen.NTier.lib.businesslayer;

using OGen.NTier.UTs.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer.proxy;

namespace OGen.NTier.UTs.lib.businesslayer {
	/// <summary>
	/// vUserGroup BusinessObject which provides access to <see cref="OGen.NTier.UTs.lib.datalayer.DO_vUserGroup">DO_vUserGroup</see> for the Business Layer.
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
		BDO_vUserGroup 
#else
		BDO0_vUserGroup 
#endif
		: BDO__base {
		#region public BDO_vUserGroup(...);
#if NET_1_1
		internal BDO0_vUserGroup() {}
#endif

		///
#if !NET_1_1
		~BDO_vUserGroup
#else
		~BDO0_vUserGroup
#endif
		() {
			if (mainaggregate__ != null) {
				mainaggregate__.Dispose(); mainaggregate__ = null;
			}
		}
		#endregion

		#region private Properties...
		private DO_vUserGroup mainaggregate__;

		///
#if !NET_1_1
		private 
#else
		protected 
#endif
		DO_vUserGroup mainAggregate {
			get {
				if (mainaggregate__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					mainaggregate__ = new DO_vUserGroup();
				}
				return mainaggregate__;
			}
		}
		#endregion
		#region public Properties...
		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public override iRecordObject Record {
			get { return mainAggregate.Record; }
		}

		public ISO_vUserGroup Fields {
			get { return mainAggregate.Fields; }
		}
		#region public long IDUser { get; set; }
		/// <summary>
		/// vUserGroup's IDUser.
		/// </summary>
		[DOPropertyAttribute(
			"IDUser", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"", 
			"", 
			false, 
			false, 
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		long IDUser {
			get { return mainAggregate.Fields.IDUser; }
			set { mainAggregate.Fields.IDUser = value; }
		}
		#endregion
		#region public string Login { get; set; }
		/// <summary>
		/// vUserGroup's Login.
		/// </summary>
		[DOPropertyAttribute(
			"Login", 
			"", 
			"", 
			false, 
			false, 
			false, 
			"", 
			"", 
			"", 
			false, 
			false, 
			false, 
			false, 
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			50, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		string Login {
			get { return mainAggregate.Fields.Login; }
			set { mainAggregate.Fields.Login = value; }
		}
		#endregion
		#region public long IDGroup { get; set; }
		/// <summary>
		/// vUserGroup's IDGroup.
		/// </summary>
		[DOPropertyAttribute(
			"IDGroup", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"", 
			"", 
			false, 
			false, 
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		long IDGroup {
			get { return mainAggregate.Fields.IDGroup; }
			set { mainAggregate.Fields.IDGroup = value; }
		}
		#endregion
		#region public string Name { get; set; }
		/// <summary>
		/// vUserGroup's Name.
		/// </summary>
		[DOPropertyAttribute(
			"Name", 
			"", 
			"", 
			false, 
			false, 
			false, 
			"", 
			"", 
			"", 
			false, 
			false, 
			false, 
			false, 
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			50, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		string Name {
			get { return mainAggregate.Fields.Name; }
			set { mainAggregate.Fields.Name = value; }
		}
		#endregion
		#region public DateTime Relationdate { get; set; }
		/// <summary>
		/// vUserGroup's Relationdate.
		/// </summary>
		[DOPropertyAttribute(
			"Relationdate", 
			"", 
			"", 
			false, 
			false, 
			false, 
			"", 
			"", 
			"", 
			false, 
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		DateTime Relationdate {
			get { return mainAggregate.Fields.Relationdate; }
			set { mainAggregate.Fields.Relationdate = value; }
		}
		#endregion
		#endregion

		#region public Methods...
		#region public SC_vUserGroup Serialize();
		public SO_vUserGroup Serialize() {
			return mainAggregate.Serialize();
		}
		#endregion
		#region public void Deserialize(SO_vUserGroup vUserGroup_in);
		public void Deserialize(SO_vUserGroup vUserGroup_in) {
			mainAggregate.Fields = vUserGroup_in;
		}
		#endregion
		#region public SC_vUserGroup Record_Serialize();
		public SC_vUserGroup Record_Serialize() {
			return mainAggregate.Record.Serialize();
		}
		#endregion
		#endregion
	}
}