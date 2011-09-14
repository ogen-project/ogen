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
	/// LOG_Log SerializableObject which provides fields access at LOG_Log table at Database.
	/// </summary>
	[Serializable()]
	public class SO_LOG_Log : 
		SO__base 
	{
		#region public SO_LOG_Log();
		public SO_LOG_Log(
		) {
			Clear();
		}
		public SO_LOG_Log(
			long IDLog_in, 
			int IFLogtype_in, 
			long IFUser_in, 
			long IFUser__read_in, 
			int IFErrortype_in, 
			DateTime Stamp_in, 
			DateTime Stamp__read_in, 
			string Message_in, 
			long IFPermition_in, 
			int IFApplication_in, 
			long IFBrowser__OPT_in
		) {
			haschanges_ = false;

			idlog_ = IDLog_in;
			iflogtype_ = IFLogtype_in;
			ifuser_ = IFUser_in;
			ifuser__read_ = IFUser__read_in;
			iferrortype_ = IFErrortype_in;
			stamp_ = Stamp_in;
			stamp__read_ = Stamp__read_in;
			message_ = Message_in;
			ifpermition_ = IFPermition_in;
			ifapplication_ = IFApplication_in;
			ifbrowser__opt_ = IFBrowser__OPT_in;
		}
		public SO_LOG_Log(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idlog_ = (long)info_in.GetValue("IDLog", typeof(long));
			iflogtype_ = (int)info_in.GetValue("IFLogtype", typeof(int));
			ifuser_ 
				= (info_in.GetValue("IFUser", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFUser", typeof(long));
			IFUser_isNull = (bool)info_in.GetValue("IFUser_isNull", typeof(bool));
			ifuser__read_ 
				= (info_in.GetValue("IFUser__read", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFUser__read", typeof(long));
			IFUser__read_isNull = (bool)info_in.GetValue("IFUser__read_isNull", typeof(bool));
			iferrortype_ 
				= (info_in.GetValue("IFErrortype", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IFErrortype", typeof(int));
			IFErrortype_isNull = (bool)info_in.GetValue("IFErrortype_isNull", typeof(bool));
			stamp_ = (DateTime)info_in.GetValue("Stamp", typeof(DateTime));
			stamp__read_ 
				= (info_in.GetValue("Stamp__read", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Stamp__read", typeof(DateTime));
			Stamp__read_isNull = (bool)info_in.GetValue("Stamp__read_isNull", typeof(bool));
			message_ = (string)info_in.GetValue("Message", typeof(string));
			ifpermition_ 
				= (info_in.GetValue("IFPermition", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFPermition", typeof(long));
			IFPermition_isNull = (bool)info_in.GetValue("IFPermition_isNull", typeof(bool));
			ifapplication_ 
				= (info_in.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IFApplication", typeof(int));
			IFApplication_isNull = (bool)info_in.GetValue("IFApplication_isNull", typeof(bool));
			ifbrowser__opt_ 
				= (info_in.GetValue("IFBrowser__OPT", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFBrowser__OPT", typeof(long));
			IFBrowser__OPT_isNull = (bool)info_in.GetValue("IFBrowser__OPT_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_LOG_Log properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IDLog { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idlog_;// = 0L;
		
		/// <summary>
		/// LOG_Log's IDLog.
		/// </summary>
		[XmlElement("IDLog")]
		[SoapElement("IDLog")]
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
		public long IDLog {
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
		#region public int IFLogtype { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public int iflogtype_;// = 0;
		
		/// <summary>
		/// LOG_Log's IFLogtype.
		/// </summary>
		[XmlElement("IFLogtype")]
		[SoapElement("IFLogtype")]
		[DOPropertyAttribute(
			"IFLogtype", 
			"", 
			"", 
			false, 
			false, 
			false, 
			"", 
			"LOG_Logtype", 
			"IDLogtype", 
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
		public int IFLogtype {
			get {
				return iflogtype_;
			}
			set {
				if (
					(!value.Equals(iflogtype_))
				) {
					iflogtype_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifuser_;// = 0L;
		
		/// <summary>
		/// LOG_Log's IFUser.
		/// </summary>
		[XmlElement("IFUser")]
		[SoapElement("IFUser")]
		[DOPropertyAttribute(
			"IFUser", 
			"", 
			"", 
			false, 
			false, 
			true, 
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
			false, 
			false, 
			0, 
			""
		)]
		public long IFUser {
			get {
				return (long)((ifuser_ == null) ? 0L : ifuser_);
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
		#region public bool IFUser_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at LOG_Log's IFUser.
		/// </summary>
		[XmlElement("IFUser_isNull")]
		[SoapElement("IFUser_isNull")]
		public bool IFUser_isNull {
			get { return (ifuser_ == null); }
			set {
				//if (value) ifuser_ = null;

				if ((value) && (ifuser_ != null)) {
					ifuser_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser__read { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifuser__read_;// = 0L;
		
		/// <summary>
		/// LOG_Log's IFUser__read.
		/// </summary>
		[XmlElement("IFUser__read")]
		[SoapElement("IFUser__read")]
		[DOPropertyAttribute(
			"IFUser__read", 
			"", 
			"", 
			false, 
			false, 
			true, 
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
			false, 
			false, 
			0, 
			""
		)]
		public long IFUser__read {
			get {
				return (long)((ifuser__read_ == null) ? 0L : ifuser__read_);
			}
			set {
				if (
					(!value.Equals(ifuser__read_))
				) {
					ifuser__read_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFUser__read_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at LOG_Log's IFUser__read.
		/// </summary>
		[XmlElement("IFUser__read_isNull")]
		[SoapElement("IFUser__read_isNull")]
		public bool IFUser__read_isNull {
			get { return (ifuser__read_ == null); }
			set {
				//if (value) ifuser__read_ = null;

				if ((value) && (ifuser__read_ != null)) {
					ifuser__read_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFErrortype { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object iferrortype_;// = 0;
		
		/// <summary>
		/// LOG_Log's IFErrortype.
		/// </summary>
		[XmlElement("IFErrortype")]
		[SoapElement("IFErrortype")]
		[DOPropertyAttribute(
			"IFErrortype", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"LOG_Errortype", 
			"IDErrortype", 
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
		public int IFErrortype {
			get {
				return (int)((iferrortype_ == null) ? 0 : iferrortype_);
			}
			set {
				if (
					(!value.Equals(iferrortype_))
				) {
					iferrortype_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFErrortype_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at LOG_Log's IFErrortype.
		/// </summary>
		[XmlElement("IFErrortype_isNull")]
		[SoapElement("IFErrortype_isNull")]
		public bool IFErrortype_isNull {
			get { return (iferrortype_ == null); }
			set {
				//if (value) iferrortype_ = null;

				if ((value) && (iferrortype_ != null)) {
					iferrortype_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Stamp { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public DateTime stamp_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// LOG_Log's Stamp.
		/// </summary>
		[XmlElement("Stamp")]
		[SoapElement("Stamp")]
		[DOPropertyAttribute(
			"Stamp", 
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
		public DateTime Stamp {
			get {
				return stamp_;
			}
			set {
				if (
					(!value.Equals(stamp_))
				) {
					stamp_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Stamp__read { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object stamp__read_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// LOG_Log's Stamp__read.
		/// </summary>
		[XmlElement("Stamp__read")]
		[SoapElement("Stamp__read")]
		[DOPropertyAttribute(
			"Stamp__read", 
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
		public DateTime Stamp__read {
			get {
				return (DateTime)((stamp__read_ == null) ? new DateTime(1900, 1, 1) : stamp__read_);
			}
			set {
				if (
					(!value.Equals(stamp__read_))
				) {
					stamp__read_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Stamp__read_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at LOG_Log's Stamp__read.
		/// </summary>
		[XmlElement("Stamp__read_isNull")]
		[SoapElement("Stamp__read_isNull")]
		public bool Stamp__read_isNull {
			get { return (stamp__read_ == null); }
			set {
				//if (value) stamp__read_ = null;

				if ((value) && (stamp__read_ != null)) {
					stamp__read_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Message { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string message_;// = string.Empty;
		
		/// <summary>
		/// LOG_Log's Message.
		/// </summary>
		[XmlElement("Message")]
		[SoapElement("Message")]
		[DOPropertyAttribute(
			"Message", 
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
			4000, 
			""
		)]
		public string Message {
			get {
				return message_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(message_))
				) {
					message_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFPermition { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifpermition_;// = 0L;
		
		/// <summary>
		/// LOG_Log's IFPermition.
		/// </summary>
		[XmlElement("IFPermition")]
		[SoapElement("IFPermition")]
		[DOPropertyAttribute(
			"IFPermition", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"CRD_Permition", 
			"IDPermition", 
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
		public long IFPermition {
			get {
				return (long)((ifpermition_ == null) ? 0L : ifpermition_);
			}
			set {
				if (
					(!value.Equals(ifpermition_))
				) {
					ifpermition_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFPermition_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at LOG_Log's IFPermition.
		/// </summary>
		[XmlElement("IFPermition_isNull")]
		[SoapElement("IFPermition_isNull")]
		public bool IFPermition_isNull {
			get { return (ifpermition_ == null); }
			set {
				//if (value) ifpermition_ = null;

				if ((value) && (ifpermition_ != null)) {
					ifpermition_ = null;
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
		/// LOG_Log's IFApplication.
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
		/// Allows assignement of null and check if null at LOG_Log's IFApplication.
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
		#region public long IFBrowser__OPT { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifbrowser__opt_;// = 0L;
		
		/// <summary>
		/// LOG_Log's IFBrowser__OPT.
		/// </summary>
		[XmlElement("IFBrowser__OPT")]
		[SoapElement("IFBrowser__OPT")]
		[DOPropertyAttribute(
			"IFBrowser__OPT", 
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
		public long IFBrowser__OPT {
			get {
				return (long)((ifbrowser__opt_ == null) ? 0L : ifbrowser__opt_);
			}
			set {
				if (
					(!value.Equals(ifbrowser__opt_))
				) {
					ifbrowser__opt_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFBrowser__OPT_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at LOG_Log's IFBrowser__OPT.
		/// </summary>
		[XmlElement("IFBrowser__OPT_isNull")]
		[SoapElement("IFBrowser__OPT_isNull")]
		public bool IFBrowser__OPT_isNull {
			get { return (ifbrowser__opt_ == null); }
			set {
				//if (value) ifbrowser__opt_ = null;

				if ((value) && (ifbrowser__opt_ != null)) {
					ifbrowser__opt_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_LOG_Log[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idlog = new DataColumn("IDLog", typeof(long));
			_output.Columns.Add(_dc_idlog);
			DataColumn _dc_iflogtype = new DataColumn("IFLogtype", typeof(int));
			_output.Columns.Add(_dc_iflogtype);
			DataColumn _dc_ifuser = new DataColumn("IFUser", typeof(long));
			_output.Columns.Add(_dc_ifuser);
			DataColumn _dc_ifuser__read = new DataColumn("IFUser__read", typeof(long));
			_output.Columns.Add(_dc_ifuser__read);
			DataColumn _dc_iferrortype = new DataColumn("IFErrortype", typeof(int));
			_output.Columns.Add(_dc_iferrortype);
			DataColumn _dc_stamp = new DataColumn("Stamp", typeof(DateTime));
			_output.Columns.Add(_dc_stamp);
			DataColumn _dc_stamp__read = new DataColumn("Stamp__read", typeof(DateTime));
			_output.Columns.Add(_dc_stamp__read);
			DataColumn _dc_message = new DataColumn("Message", typeof(string));
			_output.Columns.Add(_dc_message);
			DataColumn _dc_ifpermition = new DataColumn("IFPermition", typeof(long));
			_output.Columns.Add(_dc_ifpermition);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_ifbrowser__opt = new DataColumn("IFBrowser__OPT", typeof(long));
			_output.Columns.Add(_dc_ifbrowser__opt);

			foreach (SO_LOG_Log _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idlog] = _serializableobject.IDLog;
				_dr[_dc_iflogtype] = _serializableobject.IFLogtype;
				_dr[_dc_ifuser] = _serializableobject.IFUser;
				_dr[_dc_ifuser__read] = _serializableobject.IFUser__read;
				_dr[_dc_iferrortype] = _serializableobject.IFErrortype;
				_dr[_dc_stamp] = _serializableobject.Stamp;
				_dr[_dc_stamp__read] = _serializableobject.Stamp__read;
				_dr[_dc_message] = _serializableobject.Message;
				_dr[_dc_ifpermition] = _serializableobject.IFPermition;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;
				_dr[_dc_ifbrowser__opt] = _serializableobject.IFBrowser__OPT;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idlog_ = 0L;
			iflogtype_ = 0;
			ifuser_ = 0L;
			ifuser__read_ = 0L;
			iferrortype_ = 0;
			stamp_ = new DateTime(1900, 1, 1);
			stamp__read_ = new DateTime(1900, 1, 1);
			message_ = string.Empty;
			ifpermition_ = 0L;
			ifapplication_ = 0;
			ifbrowser__opt_ = 0L;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDLog", idlog_);
			info_in.AddValue("IFLogtype", iflogtype_);
			info_in.AddValue("IFUser", ifuser_);
			info_in.AddValue("IFUser_isNull", IFUser_isNull);
			info_in.AddValue("IFUser__read", ifuser__read_);
			info_in.AddValue("IFUser__read_isNull", IFUser__read_isNull);
			info_in.AddValue("IFErrortype", iferrortype_);
			info_in.AddValue("IFErrortype_isNull", IFErrortype_isNull);
			info_in.AddValue("Stamp", stamp_);
			info_in.AddValue("Stamp__read", stamp__read_);
			info_in.AddValue("Stamp__read_isNull", Stamp__read_isNull);
			info_in.AddValue("Message", message_);
			info_in.AddValue("IFPermition", ifpermition_);
			info_in.AddValue("IFPermition_isNull", IFPermition_isNull);
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IFApplication_isNull", IFApplication_isNull);
			info_in.AddValue("IFBrowser__OPT", ifbrowser__opt_);
			info_in.AddValue("IFBrowser__OPT_isNull", IFBrowser__OPT_isNull);
		}
		#endregion
		#endregion
	}
}