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
	/// FOR_Message SerializableObject which provides fields access at FOR_Message table at Database.
	/// </summary>
	[Serializable()]
	public class SO_FOR_Message : 
		SO__base 
	{
		#region public SO_FOR_Message();
		public SO_FOR_Message(
		) {
			Clear();
		}
		public SO_FOR_Message(
			long IDMessage_in, 
			long IFMessage__parent_in, 
			bool isSticky_in, 
			string Subject_in, 
			string Message__charvar8000_in, 
			string Message__text_in, 
			long IFUser__Publisher_in, 
			DateTime Publish_date_in, 
			int IFApplication_in
		) {
			haschanges_ = false;

			idmessage_ = IDMessage_in;
			ifmessage__parent_ = IFMessage__parent_in;
			issticky_ = isSticky_in;
			subject_ = Subject_in;
			message__charvar8000_ = Message__charvar8000_in;
			message__text_ = Message__text_in;
			ifuser__publisher_ = IFUser__Publisher_in;
			publish_date_ = Publish_date_in;
			ifapplication_ = IFApplication_in;
		}
		public SO_FOR_Message(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idmessage_ = (long)info_in.GetValue("IDMessage", typeof(long));
			ifmessage__parent_ 
				= (info_in.GetValue("IFMessage__parent", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFMessage__parent", typeof(long));
			IFMessage__parent_isNull = (bool)info_in.GetValue("IFMessage__parent_isNull", typeof(bool));
			issticky_ = (bool)info_in.GetValue("isSticky", typeof(bool));
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
			ifuser__publisher_ 
				= (info_in.GetValue("IFUser__Publisher", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFUser__Publisher", typeof(long));
			IFUser__Publisher_isNull = (bool)info_in.GetValue("IFUser__Publisher_isNull", typeof(bool));
			publish_date_ = (DateTime)info_in.GetValue("Publish_date", typeof(DateTime));
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
		/// Indicates if changes have been made to FO0_FOR_Message properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IDMessage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idmessage_;// = 0L;
		
		/// <summary>
		/// FOR_Message's IDMessage.
		/// </summary>
		[XmlElement("IDMessage")]
		[SoapElement("IDMessage")]
		[DOPropertyAttribute(
			"IDMessage", 
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
		#region public long IFMessage__parent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifmessage__parent_;// = 0L;
		
		/// <summary>
		/// FOR_Message's IFMessage__parent.
		/// </summary>
		[XmlElement("IFMessage__parent")]
		[SoapElement("IFMessage__parent")]
		[DOPropertyAttribute(
			"IFMessage__parent", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"FOR_Message", 
			"IDMessage", 
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
		public long IFMessage__parent {
			get {
				return (long)((ifmessage__parent_ == null) ? 0L : ifmessage__parent_);
			}
			set {
				if (
					(!value.Equals(ifmessage__parent_))
				) {
					ifmessage__parent_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFMessage__parent_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FOR_Message's IFMessage__parent.
		/// </summary>
		[XmlElement("IFMessage__parent_isNull")]
		[SoapElement("IFMessage__parent_isNull")]
		public bool IFMessage__parent_isNull {
			get { return (ifmessage__parent_ == null); }
			set {
				//if (value) ifmessage__parent_ = null;

				if ((value) && (ifmessage__parent_ != null)) {
					ifmessage__parent_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isSticky { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool issticky_;// = false;
		
		/// <summary>
		/// FOR_Message's isSticky.
		/// </summary>
		[XmlElement("isSticky")]
		[SoapElement("isSticky")]
		[DOPropertyAttribute(
			"isSticky", 
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
		public bool isSticky {
			get {
				return issticky_;
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
		#region public string Subject { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object subject_;// = string.Empty;
		
		/// <summary>
		/// FOR_Message's Subject.
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
			false, 
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
		/// Allows assignement of null and check if null at FOR_Message's Subject.
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
		/// FOR_Message's Message__charvar8000.
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
		/// Allows assignement of null and check if null at FOR_Message's Message__charvar8000.
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
		/// FOR_Message's Message__text.
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
		/// Allows assignement of null and check if null at FOR_Message's Message__text.
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
		#region public long IFUser__Publisher { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifuser__publisher_;// = 0L;
		
		/// <summary>
		/// FOR_Message's IFUser__Publisher.
		/// </summary>
		[XmlElement("IFUser__Publisher")]
		[SoapElement("IFUser__Publisher")]
		[DOPropertyAttribute(
			"IFUser__Publisher", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"NET_User", 
			"IFUser", 
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
		public long IFUser__Publisher {
			get {
				return (long)((ifuser__publisher_ == null) ? 0L : ifuser__publisher_);
			}
			set {
				if (
					(!value.Equals(ifuser__publisher_))
				) {
					ifuser__publisher_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFUser__Publisher_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FOR_Message's IFUser__Publisher.
		/// </summary>
		[XmlElement("IFUser__Publisher_isNull")]
		[SoapElement("IFUser__Publisher_isNull")]
		public bool IFUser__Publisher_isNull {
			get { return (ifuser__publisher_ == null); }
			set {
				//if (value) ifuser__publisher_ = null;

				if ((value) && (ifuser__publisher_ != null)) {
					ifuser__publisher_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Publish_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public DateTime publish_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// FOR_Message's Publish_date.
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
				return publish_date_;
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
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifapplication_;// = 0;
		
		/// <summary>
		/// FOR_Message's IFApplication.
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
		/// Allows assignement of null and check if null at FOR_Message's IFApplication.
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
			SO_FOR_Message[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idmessage = new DataColumn("IDMessage", typeof(long));
			_output.Columns.Add(_dc_idmessage);
			DataColumn _dc_ifmessage__parent = new DataColumn("IFMessage__parent", typeof(long));
			_output.Columns.Add(_dc_ifmessage__parent);
			DataColumn _dc_issticky = new DataColumn("isSticky", typeof(bool));
			_output.Columns.Add(_dc_issticky);
			DataColumn _dc_subject = new DataColumn("Subject", typeof(string));
			_output.Columns.Add(_dc_subject);
			DataColumn _dc_message__charvar8000 = new DataColumn("Message__charvar8000", typeof(string));
			_output.Columns.Add(_dc_message__charvar8000);
			DataColumn _dc_message__text = new DataColumn("Message__text", typeof(string));
			_output.Columns.Add(_dc_message__text);
			DataColumn _dc_ifuser__publisher = new DataColumn("IFUser__Publisher", typeof(long));
			_output.Columns.Add(_dc_ifuser__publisher);
			DataColumn _dc_publish_date = new DataColumn("Publish_date", typeof(DateTime));
			_output.Columns.Add(_dc_publish_date);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);

			foreach (SO_FOR_Message _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idmessage] = _serializableobject.IDMessage;
				_dr[_dc_ifmessage__parent] = _serializableobject.IFMessage__parent;
				_dr[_dc_issticky] = _serializableobject.isSticky;
				_dr[_dc_subject] = _serializableobject.Subject;
				_dr[_dc_message__charvar8000] = _serializableobject.Message__charvar8000;
				_dr[_dc_message__text] = _serializableobject.Message__text;
				_dr[_dc_ifuser__publisher] = _serializableobject.IFUser__Publisher;
				_dr[_dc_publish_date] = _serializableobject.Publish_date;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idmessage_ = 0L;
			ifmessage__parent_ = 0L;
			issticky_ = false;
			subject_ = string.Empty;
			message__charvar8000_ = string.Empty;
			message__text_ = string.Empty;
			ifuser__publisher_ = 0L;
			publish_date_ = new DateTime(1900, 1, 1);
			ifapplication_ = 0;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDMessage", idmessage_);
			info_in.AddValue("IFMessage__parent", ifmessage__parent_);
			info_in.AddValue("IFMessage__parent_isNull", IFMessage__parent_isNull);
			info_in.AddValue("isSticky", issticky_);
			info_in.AddValue("Subject", subject_);
			info_in.AddValue("Subject_isNull", Subject_isNull);
			info_in.AddValue("Message__charvar8000", message__charvar8000_);
			info_in.AddValue("Message__charvar8000_isNull", Message__charvar8000_isNull);
			info_in.AddValue("Message__text", message__text_);
			info_in.AddValue("Message__text_isNull", Message__text_isNull);
			info_in.AddValue("IFUser__Publisher", ifuser__publisher_);
			info_in.AddValue("IFUser__Publisher_isNull", IFUser__Publisher_isNull);
			info_in.AddValue("Publish_date", publish_date_);
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IFApplication_isNull", IFApplication_isNull);
		}
		#endregion
		#endregion
	}
}