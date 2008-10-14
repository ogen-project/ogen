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

namespace OGen.NTier.UTs.lib.datalayer {
	/// <summary>
	/// Logcode SerializableObject which provides fields access at Logcode table at Database.
	/// </summary>
	public class SO_Logcode {
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
			//---
			idlogcode_ = IDLogcode_in;
			warning_ = Warning_in;
			error_ = Error_in;
			code_ = Code_in;
			description_ = Description_in;
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		internal bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_Logcode properties since last time getObject method was run.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		bool hasChanges {
			get { return haschanges_; }
		}
		#endregion
		//---
		#region public long IDLogcode { get; set; }
		internal long idlogcode_;// = 0L;
		
		/// <summary>
		/// Logcode's IDLogcode.
		/// </summary>
		[XmlElement("IDLogcode")]
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
		internal bool warning_;// = false;
		
		/// <summary>
		/// Logcode's Warning.
		/// </summary>
		[XmlElement("Warning")]
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
		internal bool error_;// = false;
		
		/// <summary>
		/// Logcode's Error.
		/// </summary>
		[XmlElement("Error")]
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
		internal string code_;// = string.Empty;
		
		/// <summary>
		/// Logcode's Code.
		/// </summary>
		[XmlElement("Code")]
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
		#region public bool Description_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at Logcode's Description.
		/// </summary>
		[XmlIgnore]
		public 
#if NET_1_1
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
		#region public string Description { get; set; }
		internal object description_;// = string.Empty;
		
		/// <summary>
		/// Logcode's Description.
		/// </summary>
		[XmlElement("Description")]
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
		#endregion
	}
}