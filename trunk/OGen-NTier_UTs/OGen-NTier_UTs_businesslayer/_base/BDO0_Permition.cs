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
	/// Permition BusinessObject which provides access to <see cref="OGen.NTier.UTs.lib.datalayer.DO_Permition">DO_Permition</see> for the Business Layer.
	/// </summary>
	[DOClassAttribute("Permition", "", "", "", false, false)]
	public 
#if USE_PARTIAL_CLASSES && !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if USE_PARTIAL_CLASSES && !NET_1_1
		BDO_Permition 
#else
		BDO0_Permition 
#endif
		: BDO__base {
		#region public BDO_Permition(...);
#if !USE_PARTIAL_CLASSES || NET_1_1
		internal BDO0_Permition() {}
#endif

		///
#if USE_PARTIAL_CLASSES && !NET_1_1
		~BDO_Permition
#else
		~BDO0_Permition
#endif
		() {
			if (mainaggregate__ != null) {
				mainaggregate__.Dispose(); mainaggregate__ = null;
			}
		}
		#endregion

		#region private Properties...
		private DO_Permition mainaggregate__;

		///
#if USE_PARTIAL_CLASSES && !NET_1_1
		private 
#else
		protected 
#endif
		DO_Permition mainAggregate {
			get {
				if (mainaggregate__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					mainaggregate__ = new DO_Permition();
				}
				return mainaggregate__;
			}
		}
		#endregion
		#region public Properties...
		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public override IRecordObject Record {
			get { return mainAggregate.Record; }
		}

		public ISO_Permition Fields {
			get { return mainAggregate.Fields; }
		}
		#region public long IDPermition { get; set; }
		/// <summary>
		/// Permition's IDPermition.
		/// </summary>
		[DOPropertyAttribute(
			"IDPermition", 
			"", 
			"", 
			true, 
			true, 
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		long IDPermition {
			get { return mainAggregate.Fields.IDPermition; }
			set { mainAggregate.Fields.IDPermition = value; }
		}
		#endregion
		#region public string Name { get; set; }
		/// <summary>
		/// Permition's Name.
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		string Name {
			get { return mainAggregate.Fields.Name; }
			set { mainAggregate.Fields.Name = value; }
		}
		#endregion
		#endregion

		#region public Methods...
		#region public SC_Permition Serialize();
		public SO_Permition Serialize() {
			return mainAggregate.Serialize();
		}
		#endregion
		#region public void Deserialize(SO_Permition Permition_in);
		public void Deserialize(SO_Permition Permition_in) {
			mainAggregate.Fields = Permition_in;
		}
		#endregion
		#region public SC_Permition Record_Serialize();
		public SC_Permition Record_Serialize() {
			return mainAggregate.Record.Serialize();
		}
		#endregion
		#endregion
	}
}