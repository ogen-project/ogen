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
	/// vFOR_Message SerializableObject which provides fields access at vFOR_Message view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vFOR_Message : 
		SO__ListItem<long, string> 
	{
		#region public SO_vFOR_Message();
		public SO_vFOR_Message(
		) {
			Clear();
		}
		public SO_vFOR_Message(
			long IDMessage_in, 
			long IDMessage__parent_in, 
			bool isThread_in, 
			bool isSticky_in, 
			string Subject_in, 
			string Message__charvar8000_in, 
			string Message__text_in, 
			long IDUser_in, 
			string Name_in, 
			DateTime Publish_date_in, 
			int IFApplication_in, 
			string Login_in
		) {
			haschanges_ = false;

			idmessage_ = IDMessage_in;
			idmessage__parent_ = IDMessage__parent_in;
			isthread_ = isThread_in;
			issticky_ = isSticky_in;
			subject_ = Subject_in;
			message__charvar8000_ = Message__charvar8000_in;
			message__text_ = Message__text_in;
			iduser_ = IDUser_in;
			name_ = Name_in;
			publish_date_ = Publish_date_in;
			ifapplication_ = IFApplication_in;
			login_ = Login_in;
		}
		public SO_vFOR_Message(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idmessage_ = (long)info_in.GetValue("IDMessage", typeof(long));
			idmessage__parent_ 
				= (info_in.GetValue("IDMessage__parent", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IDMessage__parent", typeof(long));
			IDMessage__parent_isNull = (bool)info_in.GetValue("IDMessage__parent_isNull", typeof(bool));
			isthread_ 
				= (info_in.GetValue("isThread", typeof(bool)) == null)
					? false
					: (bool)info_in.GetValue("isThread", typeof(bool));
			isThread_isNull = (bool)info_in.GetValue("isThread_isNull", typeof(bool));
			issticky_ 
				= (info_in.GetValue("isSticky", typeof(bool)) == null)
					? false
					: (bool)info_in.GetValue("isSticky", typeof(bool));
			isSticky_isNull = (bool)info_in.GetValue("isSticky_isNull", typeof(bool));
			subject_ 
				= (info_in.GetValue("Subject", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Subject", typeof(string));
			Subject_isNull = (bool)info_in.GetValue("Subject_isNull", typeof(bool));
			message__charvar8000_ 
				= (info_in.GetValue("Message__charvar8000", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Message__charvar8000", typeof(string));
			Message__charvar8000_isNull = (bool)info_in.GetValue("Message__charvar8000_isNull", typeof(bool));
			message__text_ 
				= (info_in.GetValue("Message__text", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Message__text", typeof(string));
			Message__text_isNull = (bool)info_in.GetValue("Message__text_isNull", typeof(bool));
			iduser_ 
				= (info_in.GetValue("IDUser", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IDUser", typeof(long));
			IDUser_isNull = (bool)info_in.GetValue("IDUser_isNull", typeof(bool));
			name_ 
				= (info_in.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Name", typeof(string));
			Name_isNull = (bool)info_in.GetValue("Name_isNull", typeof(bool));
			publish_date_ 
				= (info_in.GetValue("Publish_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Publish_date", typeof(DateTime));
			Publish_date_isNull = (bool)info_in.GetValue("Publish_date_isNull", typeof(bool));
			ifapplication_ 
				= (info_in.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IFApplication", typeof(int));
			IFApplication_isNull = (bool)info_in.GetValue("IFApplication_isNull", typeof(bool));
			login_ 
				= (info_in.GetValue("Login", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Login", typeof(string));
			Login_isNull = (bool)info_in.GetValue("Login_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vFOR_Message properties since last time getObject method was run.
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
				return idmessage_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return Subject;
			}
		} 
		#endregion

		#region public long IDMessage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idmessage_;// = 0L;
		
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
			true, 
			false, 
			0, 
			""
		)]
		public long IDMessage {
			get {
				return idmessage_;
			}
			set {
				if (
					(!value.Equals(idmessage_))
				) {
					idmessage_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDMessage__parent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object idmessage__parent_;// = 0L;
		
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
				return (long)((idmessage__parent_ == null) ? 0L : idmessage__parent_);
			}
			set {
				if (
					(!value.Equals(idmessage__parent_))
				) {
					idmessage__parent_ = value;
					haschanges_ = true;
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
			get { return (idmessage__parent_ == null); }
			set {
				//if (value) idmessage__parent_ = null;

				if ((value) && (idmessage__parent_ != null)) {
					idmessage__parent_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isThread { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object isthread_;// = false;
		
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
				return (bool)((isthread_ == null) ? false : isthread_);
			}
			set {
				if (
					(!value.Equals(isthread_))
				) {
					isthread_ = value;
					haschanges_ = true;
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
			get { return (isthread_ == null); }
			set {
				//if (value) isthread_ = null;

				if ((value) && (isthread_ != null)) {
					isthread_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isSticky { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object issticky_;// = false;
		
		/// <summary>
		/// vFOR_Message's isSticky.
		/// </summary>
		[XmlElement("isSticky")]
		[SoapElement("isSticky")]
		[DOPropertyAttribute(
			"isSticky", 
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
		public bool isSticky {
			get {
				return (bool)((issticky_ == null) ? false : issticky_);
			}
			set {
				if (
					(!value.Equals(issticky_))
				) {
					issticky_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isSticky_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's isSticky.
		/// </summary>
		[XmlElement("isSticky_isNull")]
		[SoapElement("isSticky_isNull")]
		public bool isSticky_isNull {
			get { return (issticky_ == null); }
			set {
				//if (value) issticky_ = null;

				if ((value) && (issticky_ != null)) {
					issticky_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Subject { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object subject_;// = string.Empty;
		
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
				return (string)((subject_ == null) ? string.Empty : subject_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(subject_))
				) {
					subject_ = value;
					haschanges_ = true;
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
			get { return (subject_ == null); }
			set {
				//if (value) subject_ = null;

				if ((value) && (subject_ != null)) {
					subject_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Message__charvar8000 { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object message__charvar8000_;// = string.Empty;
		
		/// <summary>
		/// vFOR_Message's Message__charvar8000.
		/// </summary>
		[XmlElement("Message__charvar8000")]
		[SoapElement("Message__charvar8000")]
		[DOPropertyAttribute(
			"Message__charvar8000", 
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
		public string Message__charvar8000 {
			get {
				return (string)((message__charvar8000_ == null) ? string.Empty : message__charvar8000_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(message__charvar8000_))
				) {
					message__charvar8000_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Message__charvar8000_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's Message__charvar8000.
		/// </summary>
		[XmlElement("Message__charvar8000_isNull")]
		[SoapElement("Message__charvar8000_isNull")]
		public bool Message__charvar8000_isNull {
			get { return (message__charvar8000_ == null); }
			set {
				//if (value) message__charvar8000_ = null;

				if ((value) && (message__charvar8000_ != null)) {
					message__charvar8000_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Message__text { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object message__text_;// = string.Empty;
		
		/// <summary>
		/// vFOR_Message's Message__text.
		/// </summary>
		[XmlElement("Message__text")]
		[SoapElement("Message__text")]
		[DOPropertyAttribute(
			"Message__text", 
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
			0, 
			""
		)]
		public string Message__text {
			get {
				return (string)((message__text_ == null) ? string.Empty : message__text_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(message__text_))
				) {
					message__text_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Message__text_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's Message__text.
		/// </summary>
		[XmlElement("Message__text_isNull")]
		[SoapElement("Message__text_isNull")]
		public bool Message__text_isNull {
			get { return (message__text_ == null); }
			set {
				//if (value) message__text_ = null;

				if ((value) && (message__text_ != null)) {
					message__text_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object iduser_;// = 0L;
		
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
				return (long)((iduser_ == null) ? 0L : iduser_);
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
		#region public bool IDUser_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's IDUser.
		/// </summary>
		[XmlElement("IDUser_isNull")]
		[SoapElement("IDUser_isNull")]
		public bool IDUser_isNull {
			get { return (iduser_ == null); }
			set {
				//if (value) iduser_ = null;

				if ((value) && (iduser_ != null)) {
					iduser_ = null;
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
		/// Allows assignement of null and check if null at vFOR_Message's Name.
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
		#region public DateTime Publish_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object publish_date_;// = new DateTime(1900, 1, 1);
		
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
			true, 
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
				return (DateTime)((publish_date_ == null) ? new DateTime(1900, 1, 1) : publish_date_);
			}
			set {
				if (
					(!value.Equals(publish_date_))
				) {
					publish_date_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Publish_date_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's Publish_date.
		/// </summary>
		[XmlElement("Publish_date_isNull")]
		[SoapElement("Publish_date_isNull")]
		public bool Publish_date_isNull {
			get { return (publish_date_ == null); }
			set {
				//if (value) publish_date_ = null;

				if ((value) && (publish_date_ != null)) {
					publish_date_ = null;
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
		/// Allows assignement of null and check if null at vFOR_Message's IFApplication.
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
		#region public string Login { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object login_;// = string.Empty;
		
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
		public string Login {
			get {
				return (string)((login_ == null) ? string.Empty : login_);
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
		#region public bool Login_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vFOR_Message's Login.
		/// </summary>
		[XmlElement("Login_isNull")]
		[SoapElement("Login_isNull")]
		public bool Login_isNull {
			get { return (login_ == null); }
			set {
				//if (value) login_ = null;

				if ((value) && (login_ != null)) {
					login_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vFOR_Message[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idmessage = new DataColumn("IDMessage", typeof(long));
			_output.Columns.Add(_dc_idmessage);
			DataColumn _dc_idmessage__parent = new DataColumn("IDMessage__parent", typeof(long));
			_output.Columns.Add(_dc_idmessage__parent);
			DataColumn _dc_isthread = new DataColumn("isThread", typeof(bool));
			_output.Columns.Add(_dc_isthread);
			DataColumn _dc_issticky = new DataColumn("isSticky", typeof(bool));
			_output.Columns.Add(_dc_issticky);
			DataColumn _dc_subject = new DataColumn("Subject", typeof(string));
			_output.Columns.Add(_dc_subject);
			DataColumn _dc_message__charvar8000 = new DataColumn("Message__charvar8000", typeof(string));
			_output.Columns.Add(_dc_message__charvar8000);
			DataColumn _dc_message__text = new DataColumn("Message__text", typeof(string));
			_output.Columns.Add(_dc_message__text);
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

			foreach (SO_vFOR_Message _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idmessage] = _serializableobject.IDMessage;
				_dr[_dc_idmessage__parent] = _serializableobject.IDMessage__parent;
				_dr[_dc_isthread] = _serializableobject.isThread;
				_dr[_dc_issticky] = _serializableobject.isSticky;
				_dr[_dc_subject] = _serializableobject.Subject;
				_dr[_dc_message__charvar8000] = _serializableobject.Message__charvar8000;
				_dr[_dc_message__text] = _serializableobject.Message__text;
				_dr[_dc_iduser] = _serializableobject.IDUser;
				_dr[_dc_name] = _serializableobject.Name;
				_dr[_dc_publish_date] = _serializableobject.Publish_date;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;
				_dr[_dc_login] = _serializableobject.Login;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idmessage_ = 0L;
			idmessage__parent_ = 0L;
			isthread_ = false;
			issticky_ = false;
			subject_ = string.Empty;
			message__charvar8000_ = string.Empty;
			message__text_ = string.Empty;
			iduser_ = 0L;
			name_ = string.Empty;
			publish_date_ = new DateTime(1900, 1, 1);
			ifapplication_ = 0;
			login_ = string.Empty;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDMessage", idmessage_);
			info_in.AddValue("IDMessage__parent", idmessage__parent_);
			info_in.AddValue("IDMessage__parent_isNull", IDMessage__parent_isNull);
			info_in.AddValue("isThread", isthread_);
			info_in.AddValue("isThread_isNull", isThread_isNull);
			info_in.AddValue("isSticky", issticky_);
			info_in.AddValue("isSticky_isNull", isSticky_isNull);
			info_in.AddValue("Subject", subject_);
			info_in.AddValue("Subject_isNull", Subject_isNull);
			info_in.AddValue("Message__charvar8000", message__charvar8000_);
			info_in.AddValue("Message__charvar8000_isNull", Message__charvar8000_isNull);
			info_in.AddValue("Message__text", message__text_);
			info_in.AddValue("Message__text_isNull", Message__text_isNull);
			info_in.AddValue("IDUser", iduser_);
			info_in.AddValue("IDUser_isNull", IDUser_isNull);
			info_in.AddValue("Name", name_);
			info_in.AddValue("Name_isNull", Name_isNull);
			info_in.AddValue("Publish_date", publish_date_);
			info_in.AddValue("Publish_date_isNull", Publish_date_isNull);
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IFApplication_isNull", IFApplication_isNull);
			info_in.AddValue("Login", login_);
			info_in.AddValue("Login_isNull", Login_isNull);
		}
		#endregion
		#endregion
	}
}