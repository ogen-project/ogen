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
	/// Log BusinessObject which provides access to <see cref="OGen.NTier.UTs.lib.datalayer.DO_Log">DO_Log</see> for the Business Layer.
	/// </summary>
	[DOClassAttribute("Log", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		BDO_Log 
#else
		BDO0_Log 
#endif
		: BO__base {
		#region public BDO_Log(...);
#if NET_1_1
		internal BDO0_Log() {}
#endif

		///
#if !NET_1_1
		~BDO_Log
#else
		~BDO0_Log
#endif
		() {
			if (mainaggregate__ != null) {
				mainaggregate__.Dispose(); mainaggregate__ = null;
			}
		}
		#endregion

		#region private Properties...
		private DO_Log mainaggregate__;

		///
#if !NET_1_1
		private 
#else
		protected 
#endif
		DO_Log mainAggregate {
			get {
				if (mainaggregate__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					mainaggregate__ = new DO_Log();
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

		public SO0_Log Fields {
			get { return mainAggregate.Fields; }
		}
		#region public long IDLog { get; set; }
		/// <summary>
		/// Log's IDLog.
		/// </summary>
		[DOPropertyAttribute(
			"IDLog", 
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
#if NET_1_1
			virtual 
#endif
		long IDLog {
			get { return mainAggregate.Fields.IDLog; }
			set { mainAggregate.Fields.IDLog = value; }
		}
		#endregion
		#region public long IDLogcode { get; set; }
		/// <summary>
		/// Log's IDLogcode.
		/// </summary>
		[DOPropertyAttribute(
			"IDLogcode", 
			"", 
			"", 
			false, 
			false, 
			false, 
			"", 
			"Logcode", 
			"IDLogcode", 
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
		long IDLogcode {
			get { return mainAggregate.Fields.IDLogcode; }
			set { mainAggregate.Fields.IDLogcode = value; }
		}
		#endregion
		#region public long IDUser_posted { get; set; }
		/// <summary>
		/// Log's IDUser_posted.
		/// </summary>
		[DOPropertyAttribute(
			"IDUser_posted", 
			"", 
			"", 
			false, 
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
		long IDUser_posted {
			get { return mainAggregate.Fields.IDUser_posted; }
			set { mainAggregate.Fields.IDUser_posted = value; }
		}
		#endregion
		#region public DateTime Date_posted { get; set; }
		/// <summary>
		/// Log's Date_posted.
		/// </summary>
		[DOPropertyAttribute(
			"Date_posted", 
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
		DateTime Date_posted {
			get { return mainAggregate.Fields.Date_posted; }
			set { mainAggregate.Fields.Date_posted = value; }
		}
		#endregion
		#region public string Logdata { get; set; }
		/// <summary>
		/// Log's Logdata.
		/// </summary>
		[DOPropertyAttribute(
			"Logdata", 
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
			1024, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		string Logdata {
			get { return mainAggregate.Fields.Logdata; }
			set { mainAggregate.Fields.Logdata = value; }
		}
		#endregion
		#endregion

		#region public Methods...
		#region public SC0_Log Serialize();
		public SO0_Log Serialize() {
			return mainAggregate.Serialize();
		}
		#endregion
		#region public void Deserialize(SO0_Log Log_in);
		public void Deserialize(SO0_Log Log_in) {
			mainAggregate.Fields = Log_in;
		}
		#endregion
		#region public SC0_Log Record_Serialize();
		public SC0_Log Record_Serialize() {
			return mainAggregate.Record.Serialize();
		}
		#endregion
		#endregion
	}
}