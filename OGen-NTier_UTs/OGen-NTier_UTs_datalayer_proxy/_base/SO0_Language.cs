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

namespace OGen.NTier.UTs.lib.datalayer.proxy {
	/// <summary>
	/// Interface for Language SerializableObject.
	/// </summary>
	public interface ISO_Language {
		/// <summary>
		/// Indicates if changes have been made to FO0_Language properties since last time getObject method was run.
		/// </summary>
		bool hasChanges { get; }

		/// <summary>
		/// Language's IDLanguage.
		/// </summary>
		long IDLanguage { get; set; }
		/// <summary>
		/// Language's IDWord_name.
		/// </summary>
		long IDWord_name { get; set; }
	}

	/// <summary>
	/// Language SerializableObject which provides fields access at Language table at Database.
	/// </summary>
	public class SO_Language : ISO_Language {
		#region public SO_Language();
		public SO_Language(
		) : this (
			0L, 
			0L
		) {
		}
		public SO_Language(
			long IDLanguage_in, 
			long IDWord_name_in
		) {
			haschanges_ = false;
			//---
			idlanguage_ = IDLanguage_in;
			idword_name_ = IDWord_name_in;
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_Language properties since last time getObject method was run.
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
		#region public long IDLanguage { get; set; }
		public long idlanguage_;// = 0L;
		
		/// <summary>
		/// Language's IDLanguage.
		/// </summary>
		[XmlElement("IDLanguage")]
		[DOPropertyAttribute(
			"IDLanguage", 
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
		#region public long IDWord_name { get; set; }
		public long idword_name_;// = 0L;
		
		/// <summary>
		/// Language's IDWord_name.
		/// </summary>
		[XmlElement("IDWord_name")]
		[DOPropertyAttribute(
			"IDWord_name", 
			"", 
			"", 
			false, 
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
		long IDWord_name {
			get {
				return idword_name_;
			}
			set {
				if (
					(!value.Equals(idword_name_))
				) {
					idword_name_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion
	}
}