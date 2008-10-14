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
	/// GroupPermition BusinessObject which provides access to <see cref="OGen.NTier.UTs.lib.datalayer.DO_GroupPermition">DO_GroupPermition</see> for the Business Layer.
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
		BDO_GroupPermition 
#else
		BDO0_GroupPermition 
#endif
		: BO__base {
		#region public BDO_GroupPermition(...);
#if NET_1_1
		internal BDO0_GroupPermition() {}
#endif

		///
#if !NET_1_1
		~BDO_GroupPermition
#else
		~BDO0_GroupPermition
#endif
		() {
			if (mainaggregate__ != null) {
				mainaggregate__.Dispose(); mainaggregate__ = null;
			}
		}
		#endregion

		#region private Properties...
		private DO_GroupPermition mainaggregate__;

		///
#if !NET_1_1
		private 
#else
		protected 
#endif
		DO_GroupPermition mainAggregate {
			get {
				if (mainaggregate__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					mainaggregate__ = new DO_GroupPermition();
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

		public SO_GroupPermition Fields {
			get { return mainAggregate.Fields; }
		}
		#region public long IDGroup { get; set; }
		/// <summary>
		/// GroupPermition's IDGroup.
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
		#region public long IDPermition { get; set; }
		/// <summary>
		/// GroupPermition's IDPermition.
		/// </summary>
		[DOPropertyAttribute(
			"IDPermition", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"Permition", 
			"IDPermition", 
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
		long IDPermition {
			get { return mainAggregate.Fields.IDPermition; }
			set { mainAggregate.Fields.IDPermition = value; }
		}
		#endregion
		#endregion

		#region public Methods...
		#region public SC_GroupPermition Serialize();
		public SO_GroupPermition Serialize() {
			return mainAggregate.Serialize();
		}
		#endregion
		#region public void Deserialize(SO_GroupPermition GroupPermition_in);
		public void Deserialize(SO_GroupPermition GroupPermition_in) {
			mainAggregate.Fields = GroupPermition_in;
		}
		#endregion
		#region public SC_GroupPermition Record_Serialize();
		public SC_GroupPermition Record_Serialize() {
			return mainAggregate.Record.Serialize();
		}
		#endregion
		#endregion
	}
}