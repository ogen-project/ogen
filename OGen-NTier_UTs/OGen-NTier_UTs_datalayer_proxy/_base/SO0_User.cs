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
	/// <summary>
	/// Interface for User SerializableObject.
	/// </summary>
	public interface ISO_User {
		/// <summary>
		/// Indicates if changes have been made to FO0_User properties since last time getObject method was run.
		/// </summary>
		bool hasChanges { get; }

		/// <summary>
		/// User's IDUser.
		/// </summary>
		long IDUser { get; set; }
		/// <summary>
		/// User's Login.
		/// </summary>
		string Login { get; set; }
		/// <summary>
		/// User's Password.
		/// </summary>
		string Password { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at User's SomeNullValue.
		/// </summary>
		bool SomeNullValue_isNull { get; set; }
		/// <summary>
		/// User's SomeNullValue.
		/// </summary>
		int SomeNullValue { get; set; }
	}

	/// <summary>
	/// User SerializableObject which provides fields access at User table at Database.
	/// </summary>
	[Serializable()]
	public class SO_User : ISO_User, ISerializable {
		#region public SO_User();
		public SO_User(
		) : this (
			0L, 
			string.Empty, 
			string.Empty, 
			0
		) {
		}
		public SO_User(
			long IDUser_in, 
			string Login_in, 
			string Password_in, 
			int SomeNullValue_in
		) {
			haschanges_ = false;
			//---
			iduser_ = IDUser_in;
			login_ = Login_in;
			password_ = Password_in;
			somenullvalue_ = SomeNullValue_in;
		}
		public SO_User(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			iduser_ = (long)info_in.GetValue("IDUser", typeof(long));
			login_ = (string)info_in.GetValue("Login", typeof(string));
			password_ = (string)info_in.GetValue("Password", typeof(string));
			somenullvalue_ = (int)info_in.GetValue("SomeNullValue", typeof(int));
			SomeNullValue_isNull = (int)info_in.GetValue("SomeNullValue_isNull", typeof(int));
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[XmlIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_User properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		public 
#if NET_1_1
			virtual 
#endif
		bool hasChanges {
			get { return haschanges_; }
		}
		#endregion
		//---
		#region public long IDUser { get; set; }
		[XmlIgnore()]
		public long iduser_;// = 0L;
		
		/// <summary>
		/// User's IDUser.
		/// </summary>
		[XmlElement("IDUser")]
		[DOPropertyAttribute(
			"IDUser", 
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
		long IDUser {
			get {
				return iduser_;
			}
			set {
				if (
					(!value.Equals(iduser_))
				) {
					iduser_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Login { get; set; }
		[XmlIgnore()]
		public string login_;// = string.Empty;
		
		/// <summary>
		/// User's Login.
		/// </summary>
		[XmlElement("Login")]
		[DOPropertyAttribute(
			"Login", 
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
		string Login {
			get {
				return login_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(login_))
				) {
					login_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Password { get; set; }
		[XmlIgnore()]
		public string password_;// = string.Empty;
		
		/// <summary>
		/// User's Password.
		/// </summary>
		[XmlElement("Password")]
		[DOPropertyAttribute(
			"Password", 
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
		string Password {
			get {
				return password_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(password_))
				) {
					password_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool SomeNullValue_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at User's SomeNullValue.
		/// </summary>
		[XmlElement("SomeNullValue_isNull")]
		public 
#if NET_1_1
			virtual 
#endif
		bool SomeNullValue_isNull {
			get { return (somenullvalue_ == null); }
			set {
				//if (value) somenullvalue_ = null;

				if ((value) && (somenullvalue_ != null)) {
					somenullvalue_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int SomeNullValue { get; set; }
		[XmlIgnore()]
		public object somenullvalue_;// = 0;
		
		/// <summary>
		/// User's SomeNullValue.
		/// </summary>
		[XmlElement("SomeNullValue")]
		[DOPropertyAttribute(
			"SomeNullValue", 
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
		int SomeNullValue {
			get {
				return (int)((somenullvalue_ == null) ? 0 : somenullvalue_);
			}
			set {
				if (
					(!value.Equals(somenullvalue_))
				) {
					somenullvalue_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDUser", iduser_);
			info_in.AddValue("Login", login_);
			info_in.AddValue("Password", password_);
			info_in.AddValue("SomeNullValue", somenullvalue_);
			info_in.AddValue("SomeNullValue_isNull", SomeNullValue_isNull);
		}
		#endregion
		#endregion
	}
}