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
	/// NET_User SerializableObject which provides fields access at NET_User table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NET_User : 
		SO__ListItem<long, string>, ISerializable
	{
		#region public SO_NET_User();
		public SO_NET_User(
		) {
			this.Clear();
		}
		public SO_NET_User(
			long IFUser_in, 
			string Name_in, 
			string EMail_in, 
			string EMail_verify_in, 
			int IFApplication_in
		) {
			this.ifuser_ = IFUser_in;
			this.name_ = Name_in;
			this.email_ = EMail_in;
			this.email_verify_ = EMail_verify_in;
			this.ifapplication_ = IFApplication_in;

			this.haschanges_ = false;
		}
		protected SO_NET_User(
			SerializationInfo info,
			StreamingContext context
		) {
			this.ifuser_ = (long)info.GetValue("IFUser", typeof(long));
			this.name_ 
				= (info.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Name", typeof(string));
			this.Name_isNull = (bool)info.GetValue("Name_isNull", typeof(bool));
			this.email_ = (string)info.GetValue("EMail", typeof(string));
			this.email_verify_ 
				= (info.GetValue("EMail_verify", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("EMail_verify", typeof(string));
			this.EMail_verify_isNull = (bool)info.GetValue("EMail_verify_isNull", typeof(bool));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_NET_User properties since last time getObject method was run.
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
				return this.ifuser_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return this.Name;
			}
		} 
		#endregion

		#region public long IFUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifuser_;// = 0L;
		
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
				return this.ifuser_;
			}
			set {
				if (
					(!value.Equals(this.ifuser_))
				) {
					this.ifuser_ = value;
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
		/// Allows assignement of null and check if null at NET_User's Name.
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
		#region public string EMail { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string email_;// = string.Empty;
		
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
				return this.email_;
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
		#region public string EMail_verify { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object email_verify_;// = string.Empty;
		
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
				return (string)((this.email_verify_ == null) ? string.Empty : this.email_verify_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.email_verify_))
				) {
					this.email_verify_ = value;
					this.haschanges_ = true;
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
			get { return (this.email_verify_ == null); }
			set {
				//if (value) this.email_verify_ = null;

				if ((value) && (this.email_verify_ != null)) {
					this.email_verify_ = null;
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
		/// Allows assignement of null and check if null at NET_User's IFApplication.
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
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NET_User[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
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
		#region public void Clear();
		/// <summary>
		/// Clears SerializableObject's properties.
		/// </summary>
		public void Clear() {
			this.ifuser_ = 0L;
			this.name_ = string.Empty;
			this.email_ = string.Empty;
			this.email_verify_ = string.Empty;
			this.ifapplication_ = 0;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IFUser", this.ifuser_);
			info.AddValue("Name", this.name_);
			info.AddValue("Name_isNull", this.Name_isNull);
			info.AddValue("EMail", this.email_);
			info.AddValue("EMail_verify", this.email_verify_);
			info.AddValue("EMail_verify_isNull", this.EMail_verify_isNull);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
		}
		#endregion
		#endregion
	}
}