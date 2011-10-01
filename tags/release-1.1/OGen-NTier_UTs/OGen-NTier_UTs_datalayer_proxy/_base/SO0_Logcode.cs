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
	#region public interface ISO_Logcode;
	/// <summary>
	/// Interface for Logcode SerializableObject.
	/// </summary>
	public interface ISO_Logcode : ISO__base {

		/// <summary>
		/// Logcode's IDLogcode.
		/// </summary>
		long IDLogcode { get; set; }

		/// <summary>
		/// Logcode's Warning.
		/// </summary>
		bool Warning { get; set; }

		/// <summary>
		/// Logcode's Error.
		/// </summary>
		bool Error { get; set; }

		/// <summary>
		/// Logcode's Code.
		/// </summary>
		string Code { get; set; }

		/// <summary>
		/// Logcode's Description.
		/// </summary>
		string Description { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at Logcode's Description.
		/// </summary>
		bool Description_isNull { get; set; }
	}
	#endregion

	/// <summary>
	/// Logcode SerializableObject which provides fields access at Logcode table at Database.
	/// </summary>
	[Serializable()]
	public class SO_Logcode : ISO_Logcode, ISerializable {
		#region public SO_Logcode();
		public SO_Logcode(
		) : this (
			0L, 
			false, 
			false, 
			string.Empty, 
			string.Empty
		) {
		}
		public SO_Logcode(
			long IDLogcode_in, 
			bool Warning_in, 
			bool Error_in, 
			string Code_in, 
			string Description_in
		) {
			haschanges_ = false;

			idlogcode_ = IDLogcode_in;
			warning_ = Warning_in;
			error_ = Error_in;
			code_ = Code_in;
			description_ = Description_in;
		}
		public SO_Logcode(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idlogcode_ = (long)info_in.GetValue("IDLogcode", typeof(long));
			warning_ = (bool)info_in.GetValue("Warning", typeof(bool));
			error_ = (bool)info_in.GetValue("Error", typeof(bool));
			code_ = (string)info_in.GetValue("Code", typeof(string));
			description_ 
				= (info_in.GetValue("Description", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Description", typeof(string));
			Description_isNull = (bool)info_in.GetValue("Description_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_Logcode properties since last time getObject method was run.
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
		#region public long IDLogcode { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public long idlogcode_;// = 0L;
		
		/// <summary>
		/// Logcode's IDLogcode.
		/// </summary>
		[XmlElement("IDLogcode")]
		[SoapElement("IDLogcode")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		long IDLogcode {
			get {
				return idlogcode_;
			}
			set {
				if (
					(!value.Equals(idlogcode_))
				) {
					idlogcode_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Warning { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public bool warning_;// = false;
		
		/// <summary>
		/// Logcode's Warning.
		/// </summary>
		[XmlElement("Warning")]
		[SoapElement("Warning")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool Warning {
			get {
				return warning_;
			}
			set {
				if (
					(!value.Equals(warning_))
				) {
					warning_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Error { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public bool error_;// = false;
		
		/// <summary>
		/// Logcode's Error.
		/// </summary>
		[XmlElement("Error")]
		[SoapElement("Error")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool Error {
			get {
				return error_;
			}
			set {
				if (
					(!value.Equals(error_))
				) {
					error_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Code { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public string code_;// = string.Empty;
		
		/// <summary>
		/// Logcode's Code.
		/// </summary>
		[XmlElement("Code")]
		[SoapElement("Code")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		string Code {
			get {
				return code_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(code_))
				) {
					code_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Description { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public object description_;// = string.Empty;
		
		/// <summary>
		/// Logcode's Description.
		/// </summary>
		[XmlElement("Description")]
		[SoapElement("Description")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		string Description {
			get {
				return (string)((description_ == null) ? string.Empty : description_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(description_))
				) {
					description_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Description_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at Logcode's Description.
		/// </summary>
		[XmlElement("Description_isNull")]
		[SoapElement("Description_isNull")]
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool Description_isNull {
			get { return (description_ == null); }
			set {
				//if (value) description_ = null;

				if ((value) && (description_ != null)) {
					description_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDLogcode", idlogcode_);
			info_in.AddValue("Warning", warning_);
			info_in.AddValue("Error", error_);
			info_in.AddValue("Code", code_);
			info_in.AddValue("Description", description_);
			info_in.AddValue("Description_isNull", Description_isNull);
		}
		#endregion
		#endregion
	}
}