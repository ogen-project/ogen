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
	/// LOG_Log SerializableObject which provides fields access at LOG_Log table at Database.
	/// </summary>
	[Serializable()]
	public class SO_LOG_Log : 
		ISerializable
	{
		#region public SO_LOG_Log();
		public SO_LOG_Log(
		) {
			this.Clear();
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
			this.idlog_ = IDLog_in;
			this.iflogtype_ = IFLogtype_in;
			this.ifuser_ = IFUser_in;
			this.ifuser__read_ = IFUser__read_in;
			this.iferrortype_ = IFErrortype_in;
			this.stamp_ = Stamp_in;
			this.stamp__read_ = Stamp__read_in;
			this.message_ = Message_in;
			this.ifpermition_ = IFPermition_in;
			this.ifapplication_ = IFApplication_in;
			this.ifbrowser__opt_ = IFBrowser__OPT_in;

			this.haschanges_ = false;
		}
		protected SO_LOG_Log(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idlog_ = (long)info.GetValue("IDLog", typeof(long));
			this.iflogtype_ = (int)info.GetValue("IFLogtype", typeof(int));
			this.ifuser_ 
				= (info.GetValue("IFUser", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFUser", typeof(long));
			this.IFUser_isNull = (bool)info.GetValue("IFUser_isNull", typeof(bool));
			this.ifuser__read_ 
				= (info.GetValue("IFUser__read", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFUser__read", typeof(long));
			this.IFUser__read_isNull = (bool)info.GetValue("IFUser__read_isNull", typeof(bool));
			this.iferrortype_ 
				= (info.GetValue("IFErrortype", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFErrortype", typeof(int));
			this.IFErrortype_isNull = (bool)info.GetValue("IFErrortype_isNull", typeof(bool));
			this.stamp_ = (DateTime)info.GetValue("Stamp", typeof(DateTime));
			this.stamp__read_ 
				= (info.GetValue("Stamp__read", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info.GetValue("Stamp__read", typeof(DateTime));
			this.Stamp__read_isNull = (bool)info.GetValue("Stamp__read_isNull", typeof(bool));
			this.message_ = (string)info.GetValue("Message", typeof(string));
			this.ifpermition_ 
				= (info.GetValue("IFPermition", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFPermition", typeof(long));
			this.IFPermition_isNull = (bool)info.GetValue("IFPermition_isNull", typeof(bool));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));
			this.ifbrowser__opt_ 
				= (info.GetValue("IFBrowser__OPT", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFBrowser__OPT", typeof(long));
			this.IFBrowser__OPT_isNull = (bool)info.GetValue("IFBrowser__OPT_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_LOG_Log properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IDLog { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idlog_;// = 0L;
		
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
				return this.idlog_;
			}
			set {
				if (
					(!value.Equals(this.idlog_))
				) {
					this.idlog_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFLogtype { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private int iflogtype_;// = 0;
		
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
				return this.iflogtype_;
			}
			set {
				if (
					(!value.Equals(this.iflogtype_))
				) {
					this.iflogtype_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifuser_;// = 0L;
		
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
				return (long)((this.ifuser_ == null) ? 0L : this.ifuser_);
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
		#region public bool IFUser_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at LOG_Log's IFUser.
		/// </summary>
		[XmlElement("IFUser_isNull")]
		[SoapElement("IFUser_isNull")]
		public bool IFUser_isNull {
			get { return (this.ifuser_ == null); }
			set {
				//if (value) this.ifuser_ = null;

				if ((value) && (this.ifuser_ != null)) {
					this.ifuser_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser__read { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifuser__read_;// = 0L;
		
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
				return (long)((this.ifuser__read_ == null) ? 0L : this.ifuser__read_);
			}
			set {
				if (
					(!value.Equals(this.ifuser__read_))
				) {
					this.ifuser__read_ = value;
					this.haschanges_ = true;
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
			get { return (this.ifuser__read_ == null); }
			set {
				//if (value) this.ifuser__read_ = null;

				if ((value) && (this.ifuser__read_ != null)) {
					this.ifuser__read_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFErrortype { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object iferrortype_;// = 0;
		
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
				return (int)((this.iferrortype_ == null) ? 0 : this.iferrortype_);
			}
			set {
				if (
					(!value.Equals(this.iferrortype_))
				) {
					this.iferrortype_ = value;
					this.haschanges_ = true;
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
			get { return (this.iferrortype_ == null); }
			set {
				//if (value) this.iferrortype_ = null;

				if ((value) && (this.iferrortype_ != null)) {
					this.iferrortype_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Stamp { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private DateTime stamp_;// = new DateTime(1900, 1, 1);
		
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
				return this.stamp_;
			}
			set {
				if (
					(!value.Equals(this.stamp_))
				) {
					this.stamp_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Stamp__read { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object stamp__read_;// = new DateTime(1900, 1, 1);
		
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
				return (DateTime)((this.stamp__read_ == null) ? new DateTime(1900, 1, 1) : this.stamp__read_);
			}
			set {
				if (
					(!value.Equals(this.stamp__read_))
				) {
					this.stamp__read_ = value;
					this.haschanges_ = true;
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
			get { return (this.stamp__read_ == null); }
			set {
				//if (value) this.stamp__read_ = null;

				if ((value) && (this.stamp__read_ != null)) {
					this.stamp__read_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Message { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string message_;// = string.Empty;
		
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
				return this.message_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.message_))
				) {
					this.message_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFPermition { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifpermition_;// = 0L;
		
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
				return (long)((this.ifpermition_ == null) ? 0L : this.ifpermition_);
			}
			set {
				if (
					(!value.Equals(this.ifpermition_))
				) {
					this.ifpermition_ = value;
					this.haschanges_ = true;
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
			get { return (this.ifpermition_ == null); }
			set {
				//if (value) this.ifpermition_ = null;

				if ((value) && (this.ifpermition_ != null)) {
					this.ifpermition_ = null;
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
		/// Allows assignement of null and check if null at LOG_Log's IFApplication.
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
		#region public long IFBrowser__OPT { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifbrowser__opt_;// = 0L;
		
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
				return (long)((this.ifbrowser__opt_ == null) ? 0L : this.ifbrowser__opt_);
			}
			set {
				if (
					(!value.Equals(this.ifbrowser__opt_))
				) {
					this.ifbrowser__opt_ = value;
					this.haschanges_ = true;
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
			get { return (this.ifbrowser__opt_ == null); }
			set {
				//if (value) this.ifbrowser__opt_ = null;

				if ((value) && (this.ifbrowser__opt_ != null)) {
					this.ifbrowser__opt_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_LOG_Log[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
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

			foreach (SO_LOG_Log _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idlog] = _serializableObject.IDLog;
				_dr[_dc_iflogtype] = _serializableObject.IFLogtype;
				_dr[_dc_ifuser] = _serializableObject.IFUser;
				_dr[_dc_ifuser__read] = _serializableObject.IFUser__read;
				_dr[_dc_iferrortype] = _serializableObject.IFErrortype;
				_dr[_dc_stamp] = _serializableObject.Stamp;
				_dr[_dc_stamp__read] = _serializableObject.Stamp__read;
				_dr[_dc_message] = _serializableObject.Message;
				_dr[_dc_ifpermition] = _serializableObject.IFPermition;
				_dr[_dc_ifapplication] = _serializableObject.IFApplication;
				_dr[_dc_ifbrowser__opt] = _serializableObject.IFBrowser__OPT;

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
			this.idlog_ = 0L;
			this.iflogtype_ = 0;
			this.ifuser_ = 0L;
			this.ifuser__read_ = 0L;
			this.iferrortype_ = 0;
			this.stamp_ = new DateTime(1900, 1, 1);
			this.stamp__read_ = new DateTime(1900, 1, 1);
			this.message_ = string.Empty;
			this.ifpermition_ = 0L;
			this.ifapplication_ = 0;
			this.ifbrowser__opt_ = 0L;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDLog", this.idlog_);
			info.AddValue("IFLogtype", this.iflogtype_);
			info.AddValue("IFUser", this.ifuser_);
			info.AddValue("IFUser_isNull", this.IFUser_isNull);
			info.AddValue("IFUser__read", this.ifuser__read_);
			info.AddValue("IFUser__read_isNull", this.IFUser__read_isNull);
			info.AddValue("IFErrortype", this.iferrortype_);
			info.AddValue("IFErrortype_isNull", this.IFErrortype_isNull);
			info.AddValue("Stamp", this.stamp_);
			info.AddValue("Stamp__read", this.stamp__read_);
			info.AddValue("Stamp__read_isNull", this.Stamp__read_isNull);
			info.AddValue("Message", this.message_);
			info.AddValue("IFPermition", this.ifpermition_);
			info.AddValue("IFPermition_isNull", this.IFPermition_isNull);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("IFBrowser__OPT", this.ifbrowser__opt_);
			info.AddValue("IFBrowser__OPT_isNull", this.IFBrowser__OPT_isNull);
		}
		#endregion
		#endregion
	}
}