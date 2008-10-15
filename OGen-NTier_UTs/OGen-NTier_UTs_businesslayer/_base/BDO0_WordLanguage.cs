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
	/// WordLanguage BusinessObject which provides access to <see cref="OGen.NTier.UTs.lib.datalayer.DO_WordLanguage">DO_WordLanguage</see> for the Business Layer.
	/// </summary>
	[DOClassAttribute("WordLanguage", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		BDO_WordLanguage 
#else
		BDO0_WordLanguage 
#endif
		: BO__base {
		#region public BDO_WordLanguage(...);
#if NET_1_1
		internal BDO0_WordLanguage() {}
#endif

		///
#if !NET_1_1
		~BDO_WordLanguage
#else
		~BDO0_WordLanguage
#endif
		() {
			if (mainaggregate__ != null) {
				mainaggregate__.Dispose(); mainaggregate__ = null;
			}
		}
		#endregion

		#region private Properties...
		private DO_WordLanguage mainaggregate__;

		///
#if !NET_1_1
		private 
#else
		protected 
#endif
		DO_WordLanguage mainAggregate {
			get {
				if (mainaggregate__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					mainaggregate__ = new DO_WordLanguage();
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

		public ISO_WordLanguage Fields {
			get { return mainAggregate.Fields; }
		}
		#region public long IDWord { get; set; }
		/// <summary>
		/// WordLanguage's IDWord.
		/// </summary>
		[DOPropertyAttribute(
			"IDWord", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"Word", 
			"IDWord", 
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
		#region public long IDLanguage { get; set; }
		/// <summary>
		/// WordLanguage's IDLanguage.
		/// </summary>
		[DOPropertyAttribute(
			"IDLanguage", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"Language", 
			"IDLanguage", 
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
		long IDLanguage {
			get { return mainAggregate.Fields.IDLanguage; }
			set { mainAggregate.Fields.IDLanguage = value; }
		}
		#endregion
		#region public bool Translation_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at WordLanguage's Translation.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		bool Translation_isNull {
			get { return mainAggregate.Fields.Translation_isNull; }
			set { mainAggregate.Fields.Translation_isNull = value; }
		}
		#endregion
		#region public string Translation { get; set; }
		/// <summary>
		/// WordLanguage's Translation.
		/// </summary>
		[DOPropertyAttribute(
			"Translation", 
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
			2048, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		string Translation {
			get { return mainAggregate.Fields.Translation; }
			set { mainAggregate.Fields.Translation = value; }
		}
		#endregion
		#endregion

		#region public Methods...
		#region public SC_WordLanguage Serialize();
		public SO_WordLanguage Serialize() {
			return mainAggregate.Serialize();
		}
		#endregion
		#region public void Deserialize(SO_WordLanguage WordLanguage_in);
		public void Deserialize(SO_WordLanguage WordLanguage_in) {
			mainAggregate.Fields = WordLanguage_in;
		}
		#endregion
		#region public SC_WordLanguage Record_Serialize();
		public SC_WordLanguage Record_Serialize() {
			return mainAggregate.Record.Serialize();
		}
		#endregion
		#endregion
	}
}