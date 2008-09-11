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
	/// Word BusinessObject which provides access to <see cref="OGen.NTier.UTs.lib.datalayer.DO_Word">DO_Word</see> for the Business Layer.
	/// </summary>
	[DOClassAttribute("Word", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		BO_Word 
#else
		BO0_Word 
#endif
		: BO__base {
		#region public BO_Word(...);
#if NET_1_1
		internal BO0_Word() {}
#endif

		///
#if !NET_1_1
		~BO_Word
#else
		~BO0_Word
#endif
		() {
			if (mainaggregate__ != null) {
				mainaggregate__.Dispose(); mainaggregate__ = null;
			}
		}
		#endregion

		#region private Properties...
		private DO_Word mainaggregate__;

		///
#if !NET_1_1
		private 
#else
		protected 
#endif
		DO_Word mainAggregate {
			get {
				if (mainaggregate__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					mainaggregate__ = new DO_Word();
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

		public SO0_Word Fields {
			get { return mainAggregate.Fields; }
		}
		#region public long IDWord { get; set; }
		/// <summary>
		/// Word's IDWord.
		/// </summary>
		[DOPropertyAttribute(
			"IDWord", 
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
		long IDWord {
			get { return mainAggregate.Fields.IDWord; }
			set { mainAggregate.Fields.IDWord = value; }
		}
		#endregion
		#region public bool DeleteThisTestField_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at Word's DeleteThisTestField.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		bool DeleteThisTestField_isNull {
			get { return mainAggregate.Fields.DeleteThisTestField_isNull; }
			set { mainAggregate.Fields.DeleteThisTestField_isNull = value; }
		}
		#endregion
		#region public bool DeleteThisTestField { get; set; }
		/// <summary>
		/// Word's DeleteThisTestField.
		/// </summary>
		[DOPropertyAttribute(
			"DeleteThisTestField", 
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
		bool DeleteThisTestField {
			get { return mainAggregate.Fields.DeleteThisTestField; }
			set { mainAggregate.Fields.DeleteThisTestField = value; }
		}
		#endregion
		#endregion

		#region public Methods...
		#region public SC0_Word Serialize();
		public SO0_Word Serialize() {
			return mainAggregate.Serialize();
		}
		#endregion
		#region public void Deserialize(SO0_Word Word_in);
		public void Deserialize(SO0_Word Word_in) {
			mainAggregate.Fields = Word_in;
		}
		#endregion
		#region public SC0_Word Record_Serialize();
		public SC0_Word Record_Serialize() {
			return mainAggregate.Record.Serialize();
		}
		#endregion
		#endregion
	}
}