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
	/// Interface for Log SerializableObject.
	/// </summary>
	public interface ISO_Log {
		/// <summary>
		/// Indicates if changes have been made to FO0_Log properties since last time getObject method was run.
		/// </summary>
		bool hasChanges { get; }

		/// <summary>
		/// Log's IDLog.
		/// </summary>
		long IDLog { get; set; }
		/// <summary>
		/// Log's IDLogcode.
		/// </summary>
		long IDLogcode { get; set; }
		/// <summary>
		/// Log's IDUser_posted.
		/// </summary>
		long IDUser_posted { get; set; }
		/// <summary>
		/// Log's Date_posted.
		/// </summary>
		DateTime Date_posted { get; set; }
		/// <summary>
		/// Log's Logdata.
		/// </summary>
		string Logdata { get; set; }
	}

	/// <summary>
	/// Log SerializableObject which provides fields access at Log table at Database.
	/// </summary>
	public class SO_Log : ISO_Log {
		#region public SO_Log();
		public SO_Log(
		) : this (
			0L, 
			0L, 
			0L, 
			new DateTime(1900, 1, 1), 
			string.Empty
		) {
		}
		public SO_Log(
			long IDLog_in, 
			long IDLogcode_in, 
			long IDUser_posted_in, 
			DateTime Date_posted_in, 
			string Logdata_in
		) {
			haschanges_ = false;
			//---
			idlog_ = IDLog_in;
			idlogcode_ = IDLogcode_in;
			iduser_posted_ = IDUser_posted_in;
			date_posted_ = Date_posted_in;
			logdata_ = Logdata_in;
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_Log properties since last time getObject method was run.
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
		#region public long IDLog { get; set; }
		public long idlog_;// = 0L;
		
		/// <summary>
		/// Log's IDLog.
		/// </summary>
		[XmlElement("IDLog")]
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
			get {
				return idlog_;
			}
			set {
				if (
					(!value.Equals(idlog_))
				) {
					idlog_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDLogcode { get; set; }
		public long idlogcode_;// = 0L;
		
		/// <summary>
		/// Log's IDLogcode.
		/// </summary>
		[XmlElement("IDLogcode")]
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
		#region public long IDUser_posted { get; set; }
		public long iduser_posted_;// = 0L;
		
		/// <summary>
		/// Log's IDUser_posted.
		/// </summary>
		[XmlElement("IDUser_posted")]
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
			get {
				return iduser_posted_;
			}
			set {
				if (
					(!value.Equals(iduser_posted_))
				) {
					iduser_posted_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Date_posted { get; set; }
		public DateTime date_posted_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// Log's Date_posted.
		/// </summary>
		[XmlElement("Date_posted")]
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
			get {
				return date_posted_;
			}
			set {
				if (
					(!value.Equals(date_posted_))
				) {
					date_posted_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Logdata { get; set; }
		public string logdata_;// = string.Empty;
		
		/// <summary>
		/// Log's Logdata.
		/// </summary>
		[XmlElement("Logdata")]
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
			get {
				return logdata_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(logdata_))
				) {
					logdata_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion
	}
}