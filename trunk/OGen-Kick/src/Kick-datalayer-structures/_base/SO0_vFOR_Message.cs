#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures {
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;

	using OGen.NTier.Libraries.DataLayer;

	/// <summary>
	/// vFOR_Message SerializableObject which provides fields access at vFOR_Message view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vFOR_Message : 
		SO__ListItem<long, string>, ISerializable
	{
		#region public SO_vFOR_Message();
		public SO_vFOR_Message(
		) {
			this.Clear();
		}
		public SO_vFOR_Message(
			long IDMessage_in, 
			long IDMessage__parent_in, 
			bool isThread_in, 
			bool IsSticky_in, 
			string Subject_in, 
			string Message__small_in, 
			string Message__large_in, 
			long IDUser_in, 
			string Name_in, 
			DateTime Publish_date_in, 
			int IFApplication_in, 
			string Login_in
		) {
			this.idmessage_ = IDMessage_in;
			this.idmessage__parent_ = IDMessage__parent_in;
			this.isthread_ = isThread_in;
			this.issticky_ = IsSticky_in;
			this.subject_ = Subject_in;
			this.message__small_ = Message__small_in;
			this.message__large_ = Message__large_in;
			this.iduser_ = IDUser_in;
			this.name_ = Name_in;
			this.publish_date_ = Publish_date_in;
			this.ifapplication_ = IFApplication_in;
			this.login_ = Login_in;

			this.haschanges_ = false;
		}
		protected SO_vFOR_Message(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idmessage_ = (long)info.GetValue("IDMessage", typeof(long));
			this.idmessage__parent_ 
				= (info.GetValue("IDMessage__parent", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IDMessage__parent", typeof(long));
			this.IDMessage__parent_isNull = (bool)info.GetValue("IDMessage__parent_isNull", typeof(bool));
			this.isthread_ 
				= (info.GetValue("isThread", typeof(bool)) == null)
					? false
					: (bool)info.GetValue("isThread", typeof(bool));
			this.isThread_isNull = (bool)info.GetValue("isThread_isNull", typeof(bool));
			this.issticky_ = (bool)info.GetValue("IsSticky", typeof(bool));
			this.subject_ 
				= (info.GetValue("Subject", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Subject", typeof(string));
			this.Subject_isNull = (bool)info.GetValue("Subject_isNull", typeof(bool));
			this.message__small_ 
				= (info.GetValue("Message__small", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Message__small", typeof(string));
			this.Message__small_isNull = (bool)info.GetValue("Message__small_isNull", typeof(bool));
			this.message__large_ 
				= (info.GetValue("Message__large", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Message__large", typeof(string));
			this.Message__large_isNull = (bool)info.GetValue("Message__large_isNull", typeof(bool));
			this.iduser_ 
				= (info.GetValue("IDUser", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IDUser", typeof(long));
			this.IDUser_isNull = (bool)info.GetValue("IDUser_isNull", typeof(bool));
			this.name_ 
				= (info.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Name", typeof(string));
			this.Name_isNull = (bool)info.GetValue("Name_isNull", typeof(bool));
			this.publish_date_ = (DateTime)info.GetValue("Publish_date", typeof(DateTime));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));
			this.login_ = (string)info.GetValue("Login", typeof(string));

			this.haschanges_ = false;
		}
		#endregion

		#region Properties...
		#region public bool HasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vFOR_Message properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public override long ListItem_Value { get; }
		public override long ListItem_Value {
			get {
				return this.idmessage_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return this.Subject;
			}
		} 
		#endregion

		#region public long IDMessage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idmessage_;// = 0L;
		
		/// <summary>
		/// vFOR_Message's IDMessage.
		/// </summary>
		[XmlElement("IDMessage")]
		[SoapElement("IDMessage")]
		[DOPropertyAttribute(
			"IDMessage", 
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
		public long IDMessage {
			get {
				return this.idmessage_;
			}
			set {
				if (
					(!value.Equals(this.idmessage_))
				) {
					this.idmessage_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDMessage__parent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object idmessage__parent_;// = 0L;
		
		/// <summary>
		/// vFOR_Message's IDMessage__parent.
		/// </summary>
		[XmlElement("IDMessage__parent")]
		[SoapElement("IDMessage__parent")]
		[DOPropertyAttribute(
			"IDMessage__parent", 
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
		public long IDMessage__parent {
			get {
				return (long)((this.idmessage__parent_ == null) ? 0L : this.idmessage__parent_);
			}
			set {
				if (
					(!value.Equals(this.idmessage__parent_))
				) {
					this.idmessage__parent_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IDMessage__parent_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's IDMessage__parent.
		/// </summary>
		[XmlElement("IDMessage__parent_isNull")]
		[SoapElement("IDMessage__parent_isNull")]
		public bool IDMessage__parent_isNull {
			get { return (this.idmessage__parent_ == null); }
			set {
				//if (value) this.idmessage__parent_ = null;

				if ((value) && (this.idmessage__parent_ != null)) {
					this.idmessage__parent_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isThread { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object isthread_;// = false;
		
		/// <summary>
		/// vFOR_Message's isThread.
		/// </summary>
		[XmlElement("isThread")]
		[SoapElement("isThread")]
		[DOPropertyAttribute(
			"isThread", 
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
		public bool isThread {
			get {
				return (bool)((this.isthread_ == null) ? false : this.isthread_);
			}
			set {
				if (
					(!value.Equals(this.isthread_))
				) {
					this.isthread_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isThread_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's isThread.
		/// </summary>
		[XmlElement("isThread_isNull")]
		[SoapElement("isThread_isNull")]
		public bool isThread_isNull {
			get { return (this.isthread_ == null); }
			set {
				//if (value) this.isthread_ = null;

				if ((value) && (this.isthread_ != null)) {
					this.isthread_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IsSticky { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private bool issticky_;// = false;
		
		/// <summary>
		/// vFOR_Message's IsSticky.
		/// </summary>
		[XmlElement("IsSticky")]
		[SoapElement("IsSticky")]
		[DOPropertyAttribute(
			"IsSticky", 
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
		public bool IsSticky {
			get {
				return this.issticky_;
			}
			set {
				if (
					(!value.Equals(this.issticky_))
				) {
					this.issticky_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Subject { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object subject_;// = string.Empty;
		
		/// <summary>
		/// vFOR_Message's Subject.
		/// </summary>
		[XmlElement("Subject")]
		[SoapElement("Subject")]
		[DOPropertyAttribute(
			"Subject", 
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
		public string Subject {
			get {
				return (string)((this.subject_ == null) ? string.Empty : this.subject_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.subject_))
				) {
					this.subject_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Subject_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's Subject.
		/// </summary>
		[XmlElement("Subject_isNull")]
		[SoapElement("Subject_isNull")]
		public bool Subject_isNull {
			get { return (this.subject_ == null); }
			set {
				//if (value) this.subject_ = null;

				if ((value) && (this.subject_ != null)) {
					this.subject_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Message__small { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object message__small_;// = string.Empty;
		
		/// <summary>
		/// vFOR_Message's Message__small.
		/// </summary>
		[XmlElement("Message__small")]
		[SoapElement("Message__small")]
		[DOPropertyAttribute(
			"Message__small", 
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
			8000, 
			""
		)]
		public string Message__small {
			get {
				return (string)((this.message__small_ == null) ? string.Empty : this.message__small_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.message__small_))
				) {
					this.message__small_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Message__small_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's Message__small.
		/// </summary>
		[XmlElement("Message__small_isNull")]
		[SoapElement("Message__small_isNull")]
		public bool Message__small_isNull {
			get { return (this.message__small_ == null); }
			set {
				//if (value) this.message__small_ = null;

				if ((value) && (this.message__small_ != null)) {
					this.message__small_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Message__large { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object message__large_;// = string.Empty;
		
		/// <summary>
		/// vFOR_Message's Message__large.
		/// </summary>
		[XmlElement("Message__large")]
		[SoapElement("Message__large")]
		[DOPropertyAttribute(
			"Message__large", 
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
			2147483647, 
			""
		)]
		public string Message__large {
			get {
				return (string)((this.message__large_ == null) ? string.Empty : this.message__large_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.message__large_))
				) {
					this.message__large_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Message__large_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's Message__large.
		/// </summary>
		[XmlElement("Message__large_isNull")]
		[SoapElement("Message__large_isNull")]
		public bool Message__large_isNull {
			get { return (this.message__large_ == null); }
			set {
				//if (value) this.message__large_ = null;

				if ((value) && (this.message__large_ != null)) {
					this.message__large_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object iduser_;// = 0L;
		
		/// <summary>
		/// vFOR_Message's IDUser.
		/// </summary>
		[XmlElement("IDUser")]
		[SoapElement("IDUser")]
		[DOPropertyAttribute(
			"IDUser", 
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
		public long IDUser {
			get {
				return (long)((this.iduser_ == null) ? 0L : this.iduser_);
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
		#region public bool IDUser_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's IDUser.
		/// </summary>
		[XmlElement("IDUser_isNull")]
		[SoapElement("IDUser_isNull")]
		public bool IDUser_isNull {
			get { return (this.iduser_ == null); }
			set {
				//if (value) this.iduser_ = null;

				if ((value) && (this.iduser_ != null)) {
					this.iduser_ = null;
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
		/// vFOR_Message's Name.
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
		/// Allows assignement of null and check if null at vFOR_Message's Name.
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
		#region public DateTime Publish_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private DateTime publish_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// vFOR_Message's Publish_date.
		/// </summary>
		[XmlElement("Publish_date")]
		[SoapElement("Publish_date")]
		[DOPropertyAttribute(
			"Publish_date", 
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
		public DateTime Publish_date {
			get {
				return this.publish_date_;
			}
			set {
				if (
					(!value.Equals(this.publish_date_))
				) {
					this.publish_date_ = value;
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
		/// vFOR_Message's IFApplication.
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
		/// Allows assignement of null and check if null at vFOR_Message's IFApplication.
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
		/// vFOR_Message's Login.
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
			false, 
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
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vFOR_Message[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idmessage = new DataColumn("IDMessage", typeof(long));
			_output.Columns.Add(_dc_idmessage);
			DataColumn _dc_idmessage__parent = new DataColumn("IDMessage__parent", typeof(long));
			_output.Columns.Add(_dc_idmessage__parent);
			DataColumn _dc_isthread = new DataColumn("isThread", typeof(bool));
			_output.Columns.Add(_dc_isthread);
			DataColumn _dc_issticky = new DataColumn("IsSticky", typeof(bool));
			_output.Columns.Add(_dc_issticky);
			DataColumn _dc_subject = new DataColumn("Subject", typeof(string));
			_output.Columns.Add(_dc_subject);
			DataColumn _dc_message__small = new DataColumn("Message__small", typeof(string));
			_output.Columns.Add(_dc_message__small);
			DataColumn _dc_message__large = new DataColumn("Message__large", typeof(string));
			_output.Columns.Add(_dc_message__large);
			DataColumn _dc_iduser = new DataColumn("IDUser", typeof(long));
			_output.Columns.Add(_dc_iduser);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_publish_date = new DataColumn("Publish_date", typeof(DateTime));
			_output.Columns.Add(_dc_publish_date);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_login = new DataColumn("Login", typeof(string));
			_output.Columns.Add(_dc_login);

			foreach (SO_vFOR_Message _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idmessage] = _serializableObject.IDMessage;
				_dr[_dc_idmessage__parent] = _serializableObject.IDMessage__parent;
				_dr[_dc_isthread] = _serializableObject.isThread;
				_dr[_dc_issticky] = _serializableObject.IsSticky;
				_dr[_dc_subject] = _serializableObject.Subject;
				_dr[_dc_message__small] = _serializableObject.Message__small;
				_dr[_dc_message__large] = _serializableObject.Message__large;
				_dr[_dc_iduser] = _serializableObject.IDUser;
				_dr[_dc_name] = _serializableObject.Name;
				_dr[_dc_publish_date] = _serializableObject.Publish_date;
				_dr[_dc_ifapplication] = _serializableObject.IFApplication;
				_dr[_dc_login] = _serializableObject.Login;

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
			this.idmessage_ = 0L;
			this.idmessage__parent_ = 0L;
			this.isthread_ = false;
			this.issticky_ = false;
			this.subject_ = string.Empty;
			this.message__small_ = string.Empty;
			this.message__large_ = string.Empty;
			this.iduser_ = 0L;
			this.name_ = string.Empty;
			this.publish_date_ = new DateTime(1900, 1, 1);
			this.ifapplication_ = 0;
			this.login_ = string.Empty;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDMessage", this.idmessage_);
			info.AddValue("IDMessage__parent", this.idmessage__parent_);
			info.AddValue("IDMessage__parent_isNull", this.IDMessage__parent_isNull);
			info.AddValue("isThread", this.isthread_);
			info.AddValue("isThread_isNull", this.isThread_isNull);
			info.AddValue("IsSticky", this.issticky_);
			info.AddValue("Subject", this.subject_);
			info.AddValue("Subject_isNull", this.Subject_isNull);
			info.AddValue("Message__small", this.message__small_);
			info.AddValue("Message__small_isNull", this.Message__small_isNull);
			info.AddValue("Message__large", this.message__large_);
			info.AddValue("Message__large_isNull", this.Message__large_isNull);
			info.AddValue("IDUser", this.iduser_);
			info.AddValue("IDUser_isNull", this.IDUser_isNull);
			info.AddValue("Name", this.name_);
			info.AddValue("Name_isNull", this.Name_isNull);
			info.AddValue("Publish_date", this.publish_date_);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("Login", this.login_);
		}
		#endregion
		#endregion
	}
}