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
	/// Logcode BusinessObject which provides access to <see cref="OGen.NTier.UTs.lib.datalayer.DO_Logcode">DO_Logcode</see> for the Business Layer.
	/// </summary>
	[DOClassAttribute("Logcode", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		BO_Logcode 
#else
		BO0_Logcode 
#endif
		: BO__base {
		#region public BO_Logcode(...);
#if NET_1_1
		internal BO0_Logcode() {}
#endif

		///
#if !NET_1_1
		~BO_Logcode
#else
		~BO0_Logcode
#endif
		() {
			if (mainaggregate__ != null) {
				mainaggregate__.Dispose(); mainaggregate__ = null;
			}
		}
		#endregion

		#region private Properties...
		private DO_Logcode mainaggregate__;

		///
#if !NET_1_1
		private 
#else
		protected 
#endif
		DO_Logcode mainAggregate {
			get {
				if (mainaggregate__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					mainaggregate__ = new DO_Logcode();
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

		public SO0_Logcode Fields {
			get { return mainAggregate.Fields; }
		}
		#region public long IDLogcode { get; set; }
		/// <summary>
		/// Logcode's IDLogcode.
		/// </summary>
		[DOPropertyAttribute(
			"IDLogcode", 
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
		long IDLogcode {
			get { return mainAggregate.Fields.IDLogcode; }
			set { mainAggregate.Fields.IDLogcode = value; }
		}
		#endregion
		#region public bool Warning { get; set; }
		/// <summary>
		/// Logcode's Warning.
		/// </summary>
		[DOPropertyAttribute(
			"Warning", 
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
		bool Warning {
			get { return mainAggregate.Fields.Warning; }
			set { mainAggregate.Fields.Warning = value; }
		}
		#endregion
		#region public bool Error { get; set; }
		/// <summary>
		/// Logcode's Error.
		/// </summary>
		[DOPropertyAttribute(
			"Error", 
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
		bool Error {
			get { return mainAggregate.Fields.Error; }
			set { mainAggregate.Fields.Error = value; }
		}
		#endregion
		#region public string Code { get; set; }
		/// <summary>
		/// Logcode's Code.
		/// </summary>
		[DOPropertyAttribute(
			"Code", 
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
		string Code {
			get { return mainAggregate.Fields.Code; }
			set { mainAggregate.Fields.Code = value; }
		}
		#endregion
		#region public bool Description_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at Logcode's Description.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		bool Description_isNull {
			get { return mainAggregate.Fields.Description_isNull; }
			set { mainAggregate.Fields.Description_isNull = value; }
		}
		#endregion
		#region public string Description { get; set; }
		/// <summary>
		/// Logcode's Description.
		/// </summary>
		[DOPropertyAttribute(
			"Description", 
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
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			255, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		string Description {
			get { return mainAggregate.Fields.Description; }
			set { mainAggregate.Fields.Description = value; }
		}
		#endregion
		#endregion

		#region public Methods...
		#region public SC0_Logcode Serialize();
		public SO0_Logcode Serialize() {
			return mainAggregate.Serialize();
		}
		#endregion
		#region public void Deserialize(SO0_Logcode Logcode_in);
		public void Deserialize(SO0_Logcode Logcode_in) {
			mainAggregate.Fields = Logcode_in;
		}
		#endregion
		#region public SC0_Logcode Record_Serialize();
		public SC0_Logcode Record_Serialize() {
			return mainAggregate.Record.Serialize();
		}
		#endregion
		#endregion
	}
}