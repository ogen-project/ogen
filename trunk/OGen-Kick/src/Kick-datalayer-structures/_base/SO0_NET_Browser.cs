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
	/// NET_Browser SerializableObject which provides fields access at NET_Browser table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NET_Browser : 
		ISerializable
	{
		#region public SO_NET_Browser();
		public SO_NET_Browser(
		) {
			this.Clear();
		}
		public SO_NET_Browser(
			long IDBrowser_in, 
			string HTTP_FULL_SIGNATURE_in, 
			long HTTP_FULL_SIGNATURE__CRC_in, 
			string HTTP_ACCEPT_in, 
			long HTTP_ACCEPT__CRC_in, 
			string HTTP_ACCEPT_CHARSET_in, 
			long HTTP_ACCEPT_CHARSET__CRC_in, 
			string HTTP_ACCEPT_ENCODING_in, 
			long HTTP_ACCEPT_ENCODING__CRC_in, 
			string HTTP_ACCEPT_LANGUAGE_in, 
			long HTTP_ACCEPT_LANGUAGE__CRC_in, 
			string HTTP_USER_AGENT_in, 
			long HTTP_USER_AGENT__CRC_in
		) {
			this.idbrowser_ = IDBrowser_in;
			this.http_full_signature_ = HTTP_FULL_SIGNATURE_in;
			this.http_full_signature__crc_ = HTTP_FULL_SIGNATURE__CRC_in;
			this.http_accept_ = HTTP_ACCEPT_in;
			this.http_accept__crc_ = HTTP_ACCEPT__CRC_in;
			this.http_accept_charset_ = HTTP_ACCEPT_CHARSET_in;
			this.http_accept_charset__crc_ = HTTP_ACCEPT_CHARSET__CRC_in;
			this.http_accept_encoding_ = HTTP_ACCEPT_ENCODING_in;
			this.http_accept_encoding__crc_ = HTTP_ACCEPT_ENCODING__CRC_in;
			this.http_accept_language_ = HTTP_ACCEPT_LANGUAGE_in;
			this.http_accept_language__crc_ = HTTP_ACCEPT_LANGUAGE__CRC_in;
			this.http_user_agent_ = HTTP_USER_AGENT_in;
			this.http_user_agent__crc_ = HTTP_USER_AGENT__CRC_in;

			this.haschanges_ = false;
		}
		protected SO_NET_Browser(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idbrowser_ = (long)info.GetValue("IDBrowser", typeof(long));
			this.http_full_signature_ = (string)info.GetValue("HTTP_FULL_SIGNATURE", typeof(string));
			this.http_full_signature__crc_ = (long)info.GetValue("HTTP_FULL_SIGNATURE__CRC", typeof(long));
			this.http_accept_ = (string)info.GetValue("HTTP_ACCEPT", typeof(string));
			this.http_accept__crc_ = (long)info.GetValue("HTTP_ACCEPT__CRC", typeof(long));
			this.http_accept_charset_ = (string)info.GetValue("HTTP_ACCEPT_CHARSET", typeof(string));
			this.http_accept_charset__crc_ = (long)info.GetValue("HTTP_ACCEPT_CHARSET__CRC", typeof(long));
			this.http_accept_encoding_ = (string)info.GetValue("HTTP_ACCEPT_ENCODING", typeof(string));
			this.http_accept_encoding__crc_ = (long)info.GetValue("HTTP_ACCEPT_ENCODING__CRC", typeof(long));
			this.http_accept_language_ = (string)info.GetValue("HTTP_ACCEPT_LANGUAGE", typeof(string));
			this.http_accept_language__crc_ = (long)info.GetValue("HTTP_ACCEPT_LANGUAGE__CRC", typeof(long));
			this.http_user_agent_ = (string)info.GetValue("HTTP_USER_AGENT", typeof(string));
			this.http_user_agent__crc_ = (long)info.GetValue("HTTP_USER_AGENT__CRC", typeof(long));

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
		/// Indicates if changes have been made to FO0_NET_Browser properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IDBrowser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idbrowser_;// = 0L;
		
		/// <summary>
		/// NET_Browser's IDBrowser.
		/// </summary>
		[XmlElement("IDBrowser")]
		[SoapElement("IDBrowser")]
		[DOPropertyAttribute(
			"IDBrowser", 
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
		public long IDBrowser {
			get {
				return this.idbrowser_;
			}
			set {
				if (
					(!value.Equals(this.idbrowser_))
				) {
					this.idbrowser_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_FULL_SIGNATURE { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string http_full_signature_;// = string.Empty;
		
		/// <summary>
		/// NET_Browser's HTTP_FULL_SIGNATURE.
		/// </summary>
		[XmlElement("HTTP_FULL_SIGNATURE")]
		[SoapElement("HTTP_FULL_SIGNATURE")]
		[DOPropertyAttribute(
			"HTTP_FULL_SIGNATURE", 
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
		public string HTTP_FULL_SIGNATURE {
			get {
				return this.http_full_signature_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.http_full_signature_))
				) {
					this.http_full_signature_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_FULL_SIGNATURE__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long http_full_signature__crc_;// = 0L;
		
		/// <summary>
		/// NET_Browser's HTTP_FULL_SIGNATURE__CRC.
		/// </summary>
		[XmlElement("HTTP_FULL_SIGNATURE__CRC")]
		[SoapElement("HTTP_FULL_SIGNATURE__CRC")]
		[DOPropertyAttribute(
			"HTTP_FULL_SIGNATURE__CRC", 
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
			true, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public long HTTP_FULL_SIGNATURE__CRC {
			get {
				return this.http_full_signature__crc_;
			}
			set {
				if (
					(!value.Equals(this.http_full_signature__crc_))
				) {
					this.http_full_signature__crc_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_ACCEPT { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string http_accept_;// = string.Empty;
		
		/// <summary>
		/// NET_Browser's HTTP_ACCEPT.
		/// </summary>
		[XmlElement("HTTP_ACCEPT")]
		[SoapElement("HTTP_ACCEPT")]
		[DOPropertyAttribute(
			"HTTP_ACCEPT", 
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
		public string HTTP_ACCEPT {
			get {
				return this.http_accept_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.http_accept_))
				) {
					this.http_accept_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_ACCEPT__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long http_accept__crc_;// = 0L;
		
		/// <summary>
		/// NET_Browser's HTTP_ACCEPT__CRC.
		/// </summary>
		[XmlElement("HTTP_ACCEPT__CRC")]
		[SoapElement("HTTP_ACCEPT__CRC")]
		[DOPropertyAttribute(
			"HTTP_ACCEPT__CRC", 
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
			true, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public long HTTP_ACCEPT__CRC {
			get {
				return this.http_accept__crc_;
			}
			set {
				if (
					(!value.Equals(this.http_accept__crc_))
				) {
					this.http_accept__crc_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_ACCEPT_CHARSET { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string http_accept_charset_;// = string.Empty;
		
		/// <summary>
		/// NET_Browser's HTTP_ACCEPT_CHARSET.
		/// </summary>
		[XmlElement("HTTP_ACCEPT_CHARSET")]
		[SoapElement("HTTP_ACCEPT_CHARSET")]
		[DOPropertyAttribute(
			"HTTP_ACCEPT_CHARSET", 
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
		public string HTTP_ACCEPT_CHARSET {
			get {
				return this.http_accept_charset_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.http_accept_charset_))
				) {
					this.http_accept_charset_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_ACCEPT_CHARSET__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long http_accept_charset__crc_;// = 0L;
		
		/// <summary>
		/// NET_Browser's HTTP_ACCEPT_CHARSET__CRC.
		/// </summary>
		[XmlElement("HTTP_ACCEPT_CHARSET__CRC")]
		[SoapElement("HTTP_ACCEPT_CHARSET__CRC")]
		[DOPropertyAttribute(
			"HTTP_ACCEPT_CHARSET__CRC", 
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
			true, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public long HTTP_ACCEPT_CHARSET__CRC {
			get {
				return this.http_accept_charset__crc_;
			}
			set {
				if (
					(!value.Equals(this.http_accept_charset__crc_))
				) {
					this.http_accept_charset__crc_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_ACCEPT_ENCODING { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string http_accept_encoding_;// = string.Empty;
		
		/// <summary>
		/// NET_Browser's HTTP_ACCEPT_ENCODING.
		/// </summary>
		[XmlElement("HTTP_ACCEPT_ENCODING")]
		[SoapElement("HTTP_ACCEPT_ENCODING")]
		[DOPropertyAttribute(
			"HTTP_ACCEPT_ENCODING", 
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
		public string HTTP_ACCEPT_ENCODING {
			get {
				return this.http_accept_encoding_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.http_accept_encoding_))
				) {
					this.http_accept_encoding_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_ACCEPT_ENCODING__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long http_accept_encoding__crc_;// = 0L;
		
		/// <summary>
		/// NET_Browser's HTTP_ACCEPT_ENCODING__CRC.
		/// </summary>
		[XmlElement("HTTP_ACCEPT_ENCODING__CRC")]
		[SoapElement("HTTP_ACCEPT_ENCODING__CRC")]
		[DOPropertyAttribute(
			"HTTP_ACCEPT_ENCODING__CRC", 
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
			true, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public long HTTP_ACCEPT_ENCODING__CRC {
			get {
				return this.http_accept_encoding__crc_;
			}
			set {
				if (
					(!value.Equals(this.http_accept_encoding__crc_))
				) {
					this.http_accept_encoding__crc_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_ACCEPT_LANGUAGE { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string http_accept_language_;// = string.Empty;
		
		/// <summary>
		/// NET_Browser's HTTP_ACCEPT_LANGUAGE.
		/// </summary>
		[XmlElement("HTTP_ACCEPT_LANGUAGE")]
		[SoapElement("HTTP_ACCEPT_LANGUAGE")]
		[DOPropertyAttribute(
			"HTTP_ACCEPT_LANGUAGE", 
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
		public string HTTP_ACCEPT_LANGUAGE {
			get {
				return this.http_accept_language_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.http_accept_language_))
				) {
					this.http_accept_language_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_ACCEPT_LANGUAGE__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long http_accept_language__crc_;// = 0L;
		
		/// <summary>
		/// NET_Browser's HTTP_ACCEPT_LANGUAGE__CRC.
		/// </summary>
		[XmlElement("HTTP_ACCEPT_LANGUAGE__CRC")]
		[SoapElement("HTTP_ACCEPT_LANGUAGE__CRC")]
		[DOPropertyAttribute(
			"HTTP_ACCEPT_LANGUAGE__CRC", 
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
			true, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public long HTTP_ACCEPT_LANGUAGE__CRC {
			get {
				return this.http_accept_language__crc_;
			}
			set {
				if (
					(!value.Equals(this.http_accept_language__crc_))
				) {
					this.http_accept_language__crc_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_USER_AGENT { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string http_user_agent_;// = string.Empty;
		
		/// <summary>
		/// NET_Browser's HTTP_USER_AGENT.
		/// </summary>
		[XmlElement("HTTP_USER_AGENT")]
		[SoapElement("HTTP_USER_AGENT")]
		[DOPropertyAttribute(
			"HTTP_USER_AGENT", 
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
		public string HTTP_USER_AGENT {
			get {
				return this.http_user_agent_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.http_user_agent_))
				) {
					this.http_user_agent_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_USER_AGENT__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long http_user_agent__crc_;// = 0L;
		
		/// <summary>
		/// NET_Browser's HTTP_USER_AGENT__CRC.
		/// </summary>
		[XmlElement("HTTP_USER_AGENT__CRC")]
		[SoapElement("HTTP_USER_AGENT__CRC")]
		[DOPropertyAttribute(
			"HTTP_USER_AGENT__CRC", 
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
			true, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public long HTTP_USER_AGENT__CRC {
			get {
				return this.http_user_agent__crc_;
			}
			set {
				if (
					(!value.Equals(this.http_user_agent__crc_))
				) {
					this.http_user_agent__crc_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NET_Browser[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idbrowser = new DataColumn("IDBrowser", typeof(long));
			_output.Columns.Add(_dc_idbrowser);
			DataColumn _dc_http_full_signature = new DataColumn("HTTP_FULL_SIGNATURE", typeof(string));
			_output.Columns.Add(_dc_http_full_signature);
			DataColumn _dc_http_full_signature__crc = new DataColumn("HTTP_FULL_SIGNATURE__CRC", typeof(long));
			_output.Columns.Add(_dc_http_full_signature__crc);
			DataColumn _dc_http_accept = new DataColumn("HTTP_ACCEPT", typeof(string));
			_output.Columns.Add(_dc_http_accept);
			DataColumn _dc_http_accept__crc = new DataColumn("HTTP_ACCEPT__CRC", typeof(long));
			_output.Columns.Add(_dc_http_accept__crc);
			DataColumn _dc_http_accept_charset = new DataColumn("HTTP_ACCEPT_CHARSET", typeof(string));
			_output.Columns.Add(_dc_http_accept_charset);
			DataColumn _dc_http_accept_charset__crc = new DataColumn("HTTP_ACCEPT_CHARSET__CRC", typeof(long));
			_output.Columns.Add(_dc_http_accept_charset__crc);
			DataColumn _dc_http_accept_encoding = new DataColumn("HTTP_ACCEPT_ENCODING", typeof(string));
			_output.Columns.Add(_dc_http_accept_encoding);
			DataColumn _dc_http_accept_encoding__crc = new DataColumn("HTTP_ACCEPT_ENCODING__CRC", typeof(long));
			_output.Columns.Add(_dc_http_accept_encoding__crc);
			DataColumn _dc_http_accept_language = new DataColumn("HTTP_ACCEPT_LANGUAGE", typeof(string));
			_output.Columns.Add(_dc_http_accept_language);
			DataColumn _dc_http_accept_language__crc = new DataColumn("HTTP_ACCEPT_LANGUAGE__CRC", typeof(long));
			_output.Columns.Add(_dc_http_accept_language__crc);
			DataColumn _dc_http_user_agent = new DataColumn("HTTP_USER_AGENT", typeof(string));
			_output.Columns.Add(_dc_http_user_agent);
			DataColumn _dc_http_user_agent__crc = new DataColumn("HTTP_USER_AGENT__CRC", typeof(long));
			_output.Columns.Add(_dc_http_user_agent__crc);

			foreach (SO_NET_Browser _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idbrowser] = _serializableObject.IDBrowser;
				_dr[_dc_http_full_signature] = _serializableObject.HTTP_FULL_SIGNATURE;
				_dr[_dc_http_full_signature__crc] = _serializableObject.HTTP_FULL_SIGNATURE__CRC;
				_dr[_dc_http_accept] = _serializableObject.HTTP_ACCEPT;
				_dr[_dc_http_accept__crc] = _serializableObject.HTTP_ACCEPT__CRC;
				_dr[_dc_http_accept_charset] = _serializableObject.HTTP_ACCEPT_CHARSET;
				_dr[_dc_http_accept_charset__crc] = _serializableObject.HTTP_ACCEPT_CHARSET__CRC;
				_dr[_dc_http_accept_encoding] = _serializableObject.HTTP_ACCEPT_ENCODING;
				_dr[_dc_http_accept_encoding__crc] = _serializableObject.HTTP_ACCEPT_ENCODING__CRC;
				_dr[_dc_http_accept_language] = _serializableObject.HTTP_ACCEPT_LANGUAGE;
				_dr[_dc_http_accept_language__crc] = _serializableObject.HTTP_ACCEPT_LANGUAGE__CRC;
				_dr[_dc_http_user_agent] = _serializableObject.HTTP_USER_AGENT;
				_dr[_dc_http_user_agent__crc] = _serializableObject.HTTP_USER_AGENT__CRC;

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
			this.idbrowser_ = 0L;
			this.http_full_signature_ = string.Empty;
			this.http_full_signature__crc_ = 0L;
			this.http_accept_ = string.Empty;
			this.http_accept__crc_ = 0L;
			this.http_accept_charset_ = string.Empty;
			this.http_accept_charset__crc_ = 0L;
			this.http_accept_encoding_ = string.Empty;
			this.http_accept_encoding__crc_ = 0L;
			this.http_accept_language_ = string.Empty;
			this.http_accept_language__crc_ = 0L;
			this.http_user_agent_ = string.Empty;
			this.http_user_agent__crc_ = 0L;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDBrowser", this.idbrowser_);
			info.AddValue("HTTP_FULL_SIGNATURE", this.http_full_signature_);
			info.AddValue("HTTP_FULL_SIGNATURE__CRC", this.http_full_signature__crc_);
			info.AddValue("HTTP_ACCEPT", this.http_accept_);
			info.AddValue("HTTP_ACCEPT__CRC", this.http_accept__crc_);
			info.AddValue("HTTP_ACCEPT_CHARSET", this.http_accept_charset_);
			info.AddValue("HTTP_ACCEPT_CHARSET__CRC", this.http_accept_charset__crc_);
			info.AddValue("HTTP_ACCEPT_ENCODING", this.http_accept_encoding_);
			info.AddValue("HTTP_ACCEPT_ENCODING__CRC", this.http_accept_encoding__crc_);
			info.AddValue("HTTP_ACCEPT_LANGUAGE", this.http_accept_language_);
			info.AddValue("HTTP_ACCEPT_LANGUAGE__CRC", this.http_accept_language__crc_);
			info.AddValue("HTTP_USER_AGENT", this.http_user_agent_);
			info.AddValue("HTTP_USER_AGENT__CRC", this.http_user_agent__crc_);
		}
		#endregion
		#endregion
	}
}