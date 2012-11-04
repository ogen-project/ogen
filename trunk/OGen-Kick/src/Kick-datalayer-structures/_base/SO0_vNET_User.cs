#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.lib.datalayer.shared.structures {
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;

	using OGen.NTier.lib.datalayer;

	/// <summary>
	/// vNET_User SerializableObject which provides fields access at vNET_User view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vNET_User : 
		SO__ListItem<long, string>, ISerializable
	{
		#region public SO_vNET_User();
		public SO_vNET_User(
		) {
			this.Clear();
		}
		public SO_vNET_User(
			long IDUser_in, 
			int IFApplication_in, 
			string Login_in, 
			string Name_in, 
			string Email_in
		) {
			this.iduser_ = IDUser_in;
			this.ifapplication_ = IFApplication_in;
			this.login_ = Login_in;
			this.name_ = Name_in;
			this.email_ = Email_in;

			this.haschanges_ = false;
		}
		protected SO_vNET_User(
			SerializationInfo info,
			StreamingContext context
		) {
			this.iduser_ = (long)info.GetValue("IDUser", typeof(long));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));
			this.login_ = (string)info.GetValue("Login", typeof(string));
			this.name_ 
				= (info.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Name", typeof(string));
			this.Name_isNull = (bool)info.GetValue("Name_isNull", typeof(bool));
			this.email_ 
				= (info.GetValue("Email", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Email", typeof(string));
			this.Email_isNull = (bool)info.GetValue("Email_isNull", typeof(bool));

			this.haschanges_ = false;
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vNET_User properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public override long ListItem_Value { get; }
		public override long ListItem_Value {
			get {
				return this.iduser_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return this.login_;
			}
		} 
		#endregion

		#region public long IDUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long iduser_;// = 0L;
		
		/// <summary>
		/// vNET_User's IDUser.
		/// </summary>
		[XmlElement("IDUser")]
		[SoapElement("IDUser")]
		[DOPropertyAttribute(
			"IDUser", 
			"", 
			"", 
			true, 
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
			true, 
			false, 
			false, 
			true, 
			false, 
			0, 
			""
		)]
		public long IDUser {
			get {
				return this.iduser_;
			}
			set {
				if (
					(!value.Equals(this.iduser_))
				) {
					this.iduser_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifapplication_;// = 0;
		
		/// <summary>
		/// vNET_User's IFApplication.
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
		public int IFApplication {
			get {
				return (int)((this.ifapplication_ == null) ? 0 : this.ifapplication_);
			}
			set {
				if (
					(!value.Equals(this.ifapplication_))
				) {
					this.ifapplication_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFApplication_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNET_User's IFApplication.
		/// </summary>
		[XmlElement("IFApplication_isNull")]
		[SoapElement("IFApplication_isNull")]
		public bool IFApplication_isNull {
			get { return (this.ifapplication_ == null); }
			set {
				//if (value) this.ifapplication_ = null;

				if ((value) && (this.ifapplication_ != null)) {
					this.ifapplication_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Login { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string login_;// = string.Empty;
		
		/// <summary>
		/// vNET_User's Login.
		/// </summary>
		[XmlElement("Login")]
		[SoapElement("Login")]
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
			true, 
			255, 
			""
		)]
		public string Login {
			get {
				return this.login_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.login_))
				) {
					this.login_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object name_;// = string.Empty;
		
		/// <summary>
		/// vNET_User's Name.
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
			false, 
			255, 
			""
		)]
		public string Name {
			get {
				return (string)((this.name_ == null) ? string.Empty : this.name_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.name_))
				) {
					this.name_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Name_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNET_User's Name.
		/// </summary>
		[XmlElement("Name_isNull")]
		[SoapElement("Name_isNull")]
		public bool Name_isNull {
			get { return (this.name_ == null); }
			set {
				//if (value) this.name_ = null;

				if ((value) && (this.name_ != null)) {
					this.name_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Email { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object email_;// = string.Empty;
		
		/// <summary>
		/// vNET_User's Email.
		/// </summary>
		[XmlElement("Email")]
		[SoapElement("Email")]
		[DOPropertyAttribute(
			"Email", 
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
		public string Email {
			get {
				return (string)((this.email_ == null) ? string.Empty : this.email_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.email_))
				) {
					this.email_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Email_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNET_User's Email.
		/// </summary>
		[XmlElement("Email_isNull")]
		[SoapElement("Email_isNull")]
		public bool Email_isNull {
			get { return (this.email_ == null); }
			set {
				//if (value) this.email_ = null;

				if ((value) && (this.email_ != null)) {
					this.email_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vNET_User[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_iduser = new DataColumn("IDUser", typeof(long));
			_output.Columns.Add(_dc_iduser);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_login = new DataColumn("Login", typeof(string));
			_output.Columns.Add(_dc_login);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_email = new DataColumn("Email", typeof(string));
			_output.Columns.Add(_dc_email);

			foreach (SO_vNET_User _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_iduser] = _serializableObject.IDUser;
				_dr[_dc_ifapplication] = _serializableObject.IFApplication;
				_dr[_dc_login] = _serializableObject.Login;
				_dr[_dc_name] = _serializableObject.Name;
				_dr[_dc_email] = _serializableObject.Email;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public void Clear();
		/// <summary>
		/// Clears SerializableObject's properties.
		/// </summary>
		public void Clear() {
			this.iduser_ = 0L;
			this.ifapplication_ = 0;
			this.login_ = string.Empty;
			this.name_ = string.Empty;
			this.email_ = string.Empty;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDUser", this.iduser_);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("Login", this.login_);
			info.AddValue("Name", this.name_);
			info.AddValue("Name_isNull", this.Name_isNull);
			info.AddValue("Email", this.email_);
			info.AddValue("Email_isNull", this.Email_isNull);
		}
		#endregion
		#endregion
	}
}