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
using System.Data;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.Kick.lib.datalayer.shared.structures {
	/// <summary>
	/// NET_User SerializableObject which provides fields access at NET_User table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NET_User : 
		SO__ListItem<long, string> 
	{
		#region public SO_NET_User();
		public SO_NET_User(
		) {
			Clear();
		}
		public SO_NET_User(
			long IFUser_in, 
			string Name_in, 
			string EMail_in, 
			string EMail_verify_in, 
			int IFApplication_in
		) {
			haschanges_ = false;

			ifuser_ = IFUser_in;
			name_ = Name_in;
			email_ = EMail_in;
			email_verify_ = EMail_verify_in;
			ifapplication_ = IFApplication_in;
		}
		public SO_NET_User(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			ifuser_ = (long)info_in.GetValue("IFUser", typeof(long));
			name_ 
				= (info_in.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Name", typeof(string));
			Name_isNull = (bool)info_in.GetValue("Name_isNull", typeof(bool));
			email_ = (string)info_in.GetValue("EMail", typeof(string));
			email_verify_ 
				= (info_in.GetValue("EMail_verify", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("EMail_verify", typeof(string));
			EMail_verify_isNull = (bool)info_in.GetValue("EMail_verify_isNull", typeof(bool));
			ifapplication_ 
				= (info_in.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IFApplication", typeof(int));
			IFApplication_isNull = (bool)info_in.GetValue("IFApplication_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_NET_User properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public override long ListItem_Value { get; }
		public override long ListItem_Value {
			get {
				return ifuser_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return Name;
			}
		} 
		#endregion

		#region public long IFUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifuser_;// = 0L;
		
		/// <summary>
		/// NET_User's IFUser.
		/// </summary>
		[XmlElement("IFUser")]
		[SoapElement("IFUser")]
		[DOPropertyAttribute(
			"IFUser", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"CRD_User", 
			"IDUser", 
			false, 
			false, 
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			true, 
			false, 
			0, 
			""
		)]
		public long IFUser {
			get {
				return ifuser_;
			}
			set {
				if (
					(!value.Equals(ifuser_))
				) {
					ifuser_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object name_;// = string.Empty;
		
		/// <summary>
		/// NET_User's Name.
		/// </summary>
		[XmlElement("Name")]
		[SoapElement("Name")]
		[DOPropertyAttribute(
			"Name", 
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
			true, 
			255, 
			""
		)]
		public string Name {
			get {
				return (string)((name_ == null) ? string.Empty : name_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(name_))
				) {
					name_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Name_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NET_User's Name.
		/// </summary>
		[XmlElement("Name_isNull")]
		[SoapElement("Name_isNull")]
		public bool Name_isNull {
			get { return (name_ == null); }
			set {
				//if (value) name_ = null;

				if ((value) && (name_ != null)) {
					name_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string EMail { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string email_;// = string.Empty;
		
		/// <summary>
		/// NET_User's EMail.
		/// </summary>
		[XmlElement("EMail")]
		[SoapElement("EMail")]
		[DOPropertyAttribute(
			"EMail", 
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
			255, 
			""
		)]
		public string EMail {
			get {
				return email_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(email_))
				) {
					email_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string EMail_verify { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object email_verify_;// = string.Empty;
		
		/// <summary>
		/// NET_User's EMail_verify.
		/// </summary>
		[XmlElement("EMail_verify")]
		[SoapElement("EMail_verify")]
		[DOPropertyAttribute(
			"EMail_verify", 
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
		public string EMail_verify {
			get {
				return (string)((email_verify_ == null) ? string.Empty : email_verify_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(email_verify_))
				) {
					email_verify_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool EMail_verify_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NET_User's EMail_verify.
		/// </summary>
		[XmlElement("EMail_verify_isNull")]
		[SoapElement("EMail_verify_isNull")]
		public bool EMail_verify_isNull {
			get { return (email_verify_ == null); }
			set {
				//if (value) email_verify_ = null;

				if ((value) && (email_verify_ != null)) {
					email_verify_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifapplication_;// = 0;
		
		/// <summary>
		/// NET_User's IFApplication.
		/// </summary>
		[XmlElement("IFApplication")]
		[SoapElement("IFApplication")]
		[DOPropertyAttribute(
			"IFApplication", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"APP_Application", 
			"IDApplication", 
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
		public int IFApplication {
			get {
				return (int)((ifapplication_ == null) ? 0 : ifapplication_);
			}
			set {
				if (
					(!value.Equals(ifapplication_))
				) {
					ifapplication_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFApplication_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NET_User's IFApplication.
		/// </summary>
		[XmlElement("IFApplication_isNull")]
		[SoapElement("IFApplication_isNull")]
		public bool IFApplication_isNull {
			get { return (ifapplication_ == null); }
			set {
				//if (value) ifapplication_ = null;

				if ((value) && (ifapplication_ != null)) {
					ifapplication_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NET_User[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_ifuser = new DataColumn("IFUser", typeof(long));
			_output.Columns.Add(_dc_ifuser);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_email = new DataColumn("EMail", typeof(string));
			_output.Columns.Add(_dc_email);
			DataColumn _dc_email_verify = new DataColumn("EMail_verify", typeof(string));
			_output.Columns.Add(_dc_email_verify);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);

			foreach (SO_NET_User _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifuser] = _serializableobject.IFUser;
				_dr[_dc_name] = _serializableobject.Name;
				_dr[_dc_email] = _serializableobject.EMail;
				_dr[_dc_email_verify] = _serializableobject.EMail_verify;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			ifuser_ = 0L;
			name_ = string.Empty;
			email_ = string.Empty;
			email_verify_ = string.Empty;
			ifapplication_ = 0;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IFUser", ifuser_);
			info_in.AddValue("Name", name_);
			info_in.AddValue("Name_isNull", Name_isNull);
			info_in.AddValue("EMail", email_);
			info_in.AddValue("EMail_verify", email_verify_);
			info_in.AddValue("EMail_verify_isNull", EMail_verify_isNull);
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IFApplication_isNull", IFApplication_isNull);
		}
		#endregion
		#endregion
	}
}