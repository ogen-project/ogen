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

namespace OGen.NTier.UTs.lib.businesslayer {
	/// <summary>
	/// UserGroup BusinessObject which provides access to <see cref="OGen.NTier.UTs.lib.datalayer.DO_UserGroup">DO_UserGroup</see> for the Business Layer.
	/// </summary>
	[DOClassAttribute("UserGroup", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		BDO_UserGroup 
#else
		BDO0_UserGroup 
#endif
		: BO__base {
		#region public BDO_UserGroup(...);
#if NET_1_1
		internal BDO0_UserGroup() {}
#endif

		///
#if !NET_1_1
		~BDO_UserGroup
#else
		~BDO0_UserGroup
#endif
		() {
			if (mainaggregate__ != null) {
				mainaggregate__.Dispose(); mainaggregate__ = null;
			}
		}
		#endregion

		#region private Properties...
		private DO_UserGroup mainaggregate__;

		///
#if !NET_1_1
		private 
#else
		protected 
#endif
		DO_UserGroup mainAggregate {
			get {
				if (mainaggregate__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					mainaggregate__ = new DO_UserGroup();
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

		public SO0_UserGroup Fields {
			get { return mainAggregate.Fields; }
		}
		#region public long IDUser { get; set; }
		/// <summary>
		/// UserGroup's IDUser.
		/// </summary>
		[DOPropertyAttribute(
			"IDUser", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"User", 
			"IDUser", 
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
		#region public long IDGroup { get; set; }
		/// <summary>
		/// UserGroup's IDGroup.
		/// </summary>
		[DOPropertyAttribute(
			"IDGroup", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"Group", 
			"IDGroup", 
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
		#region public bool Relationdate_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at UserGroup's Relationdate.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		bool Relationdate_isNull {
			get { return mainAggregate.Fields.Relationdate_isNull; }
			set { mainAggregate.Fields.Relationdate_isNull = value; }
		}
		#endregion
		#region public DateTime Relationdate { get; set; }
		/// <summary>
		/// UserGroup's Relationdate.
		/// </summary>
		[DOPropertyAttribute(
			"Relationdate", 
			"", 
			"", 
			false, 
			false, 
			true, 
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
		#region public bool Defaultrelation_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at UserGroup's Defaultrelation.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		bool Defaultrelation_isNull {
			get { return mainAggregate.Fields.Defaultrelation_isNull; }
			set { mainAggregate.Fields.Defaultrelation_isNull = value; }
		}
		#endregion
		#region public bool Defaultrelation { get; set; }
		/// <summary>
		/// UserGroup's Defaultrelation.
		/// </summary>
		[DOPropertyAttribute(
			"Defaultrelation", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"", 
			"", 
			false, 
			false, 
			false, 
			true, 
			false, 
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
		bool Defaultrelation {
			get { return mainAggregate.Fields.Defaultrelation; }
			set { mainAggregate.Fields.Defaultrelation = value; }
		}
		#endregion
		#endregion

		#region public Methods...
		#region public SC0_UserGroup Serialize();
		public SO0_UserGroup Serialize() {
			return mainAggregate.Serialize();
		}
		#endregion
		#region public void Deserialize(SO0_UserGroup UserGroup_in);
		public void Deserialize(SO0_UserGroup UserGroup_in) {
			mainAggregate.Fields = UserGroup_in;
		}
		#endregion
		#region public SC0_UserGroup Record_Serialize();
		public SC0_UserGroup Record_Serialize() {
			return mainAggregate.Record.Serialize();
		}
		#endregion
		#endregion
	}
}