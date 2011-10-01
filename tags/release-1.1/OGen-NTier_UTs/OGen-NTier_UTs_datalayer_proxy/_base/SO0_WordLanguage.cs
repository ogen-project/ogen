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
using System.Runtime.Serialization;

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.UTs.lib.datalayer.proxy {
	#region public interface ISO_WordLanguage;
	/// <summary>
	/// Interface for WordLanguage SerializableObject.
	/// </summary>
	public interface ISO_WordLanguage : ISO__base {

		/// <summary>
		/// WordLanguage's IDWord.
		/// </summary>
		long IDWord { get; set; }

		/// <summary>
		/// WordLanguage's IDLanguage.
		/// </summary>
		long IDLanguage { get; set; }

		/// <summary>
		/// WordLanguage's Translation.
		/// </summary>
		string Translation { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at WordLanguage's Translation.
		/// </summary>
		bool Translation_isNull { get; set; }
	}
	#endregion

	/// <summary>
	/// WordLanguage SerializableObject which provides fields access at WordLanguage table at Database.
	/// </summary>
	[Serializable()]
	public class SO_WordLanguage : ISO_WordLanguage, ISerializable {
		#region public SO_WordLanguage();
		public SO_WordLanguage(
		) : this (
			0L, 
			0L, 
			string.Empty
		) {
		}
		public SO_WordLanguage(
			long IDWord_in, 
			long IDLanguage_in, 
			string Translation_in
		) {
			haschanges_ = false;

			idword_ = IDWord_in;
			idlanguage_ = IDLanguage_in;
			translation_ = Translation_in;
		}
		public SO_WordLanguage(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idword_ = (long)info_in.GetValue("IDWord", typeof(long));
			idlanguage_ = (long)info_in.GetValue("IDLanguage", typeof(long));
			translation_ 
				= (info_in.GetValue("Translation", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Translation", typeof(string));
			Translation_isNull = (bool)info_in.GetValue("Translation_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_WordLanguage properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool hasChanges {
			get { return haschanges_; }
		}
		#endregion
		//---
		#region public long IDWord { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public long idword_;// = 0L;
		
		/// <summary>
		/// WordLanguage's IDWord.
		/// </summary>
		[XmlElement("IDWord")]
		[SoapElement("IDWord")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		long IDWord {
			get {
				return idword_;
			}
			set {
				if (
					(!value.Equals(idword_))
				) {
					idword_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDLanguage { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public long idlanguage_;// = 0L;
		
		/// <summary>
		/// WordLanguage's IDLanguage.
		/// </summary>
		[XmlElement("IDLanguage")]
		[SoapElement("IDLanguage")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		long IDLanguage {
			get {
				return idlanguage_;
			}
			set {
				if (
					(!value.Equals(idlanguage_))
				) {
					idlanguage_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Translation { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public object translation_;// = string.Empty;
		
		/// <summary>
		/// WordLanguage's Translation.
		/// </summary>
		[XmlElement("Translation")]
		[SoapElement("Translation")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		string Translation {
			get {
				return (string)((translation_ == null) ? string.Empty : translation_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(translation_))
				) {
					translation_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Translation_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at WordLanguage's Translation.
		/// </summary>
		[XmlElement("Translation_isNull")]
		[SoapElement("Translation_isNull")]
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool Translation_isNull {
			get { return (translation_ == null); }
			set {
				//if (value) translation_ = null;

				if ((value) && (translation_ != null)) {
					translation_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDWord", idword_);
			info_in.AddValue("IDLanguage", idlanguage_);
			info_in.AddValue("Translation", translation_);
			info_in.AddValue("Translation_isNull", Translation_isNull);
		}
		#endregion
		#endregion
	}
}