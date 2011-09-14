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
	/// NET_Browser SerializableObject which provides fields access at NET_Browser table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NET_Browser : 
		SO__base 
	{
		#region public SO_NET_Browser();
		public SO_NET_Browser(
		) {
			Clear();
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
			haschanges_ = false;

			idbrowser_ = IDBrowser_in;
			http_full_signature_ = HTTP_FULL_SIGNATURE_in;
			http_full_signature__crc_ = HTTP_FULL_SIGNATURE__CRC_in;
			http_accept_ = HTTP_ACCEPT_in;
			http_accept__crc_ = HTTP_ACCEPT__CRC_in;
			http_accept_charset_ = HTTP_ACCEPT_CHARSET_in;
			http_accept_charset__crc_ = HTTP_ACCEPT_CHARSET__CRC_in;
			http_accept_encoding_ = HTTP_ACCEPT_ENCODING_in;
			http_accept_encoding__crc_ = HTTP_ACCEPT_ENCODING__CRC_in;
			http_accept_language_ = HTTP_ACCEPT_LANGUAGE_in;
			http_accept_language__crc_ = HTTP_ACCEPT_LANGUAGE__CRC_in;
			http_user_agent_ = HTTP_USER_AGENT_in;
			http_user_agent__crc_ = HTTP_USER_AGENT__CRC_in;
		}
		public SO_NET_Browser(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idbrowser_ = (long)info_in.GetValue("IDBrowser", typeof(long));
			http_full_signature_ = (string)info_in.GetValue("HTTP_FULL_SIGNATURE", typeof(string));
			http_full_signature__crc_ = (long)info_in.GetValue("HTTP_FULL_SIGNATURE__CRC", typeof(long));
			http_accept_ = (string)info_in.GetValue("HTTP_ACCEPT", typeof(string));
			http_accept__crc_ = (long)info_in.GetValue("HTTP_ACCEPT__CRC", typeof(long));
			http_accept_charset_ = (string)info_in.GetValue("HTTP_ACCEPT_CHARSET", typeof(string));
			http_accept_charset__crc_ = (long)info_in.GetValue("HTTP_ACCEPT_CHARSET__CRC", typeof(long));
			http_accept_encoding_ = (string)info_in.GetValue("HTTP_ACCEPT_ENCODING", typeof(string));
			http_accept_encoding__crc_ = (long)info_in.GetValue("HTTP_ACCEPT_ENCODING__CRC", typeof(long));
			http_accept_language_ = (string)info_in.GetValue("HTTP_ACCEPT_LANGUAGE", typeof(string));
			http_accept_language__crc_ = (long)info_in.GetValue("HTTP_ACCEPT_LANGUAGE__CRC", typeof(long));
			http_user_agent_ = (string)info_in.GetValue("HTTP_USER_AGENT", typeof(string));
			http_user_agent__crc_ = (long)info_in.GetValue("HTTP_USER_AGENT__CRC", typeof(long));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_NET_Browser properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IDBrowser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idbrowser_;// = 0L;
		
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
				return idbrowser_;
			}
			set {
				if (
					(!value.Equals(idbrowser_))
				) {
					idbrowser_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_FULL_SIGNATURE { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string http_full_signature_;// = string.Empty;
		
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
				return http_full_signature_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(http_full_signature_))
				) {
					http_full_signature_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_FULL_SIGNATURE__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long http_full_signature__crc_;// = 0L;
		
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
				return http_full_signature__crc_;
			}
			set {
				if (
					(!value.Equals(http_full_signature__crc_))
				) {
					http_full_signature__crc_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_ACCEPT { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string http_accept_;// = string.Empty;
		
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
				return http_accept_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(http_accept_))
				) {
					http_accept_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_ACCEPT__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long http_accept__crc_;// = 0L;
		
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
				return http_accept__crc_;
			}
			set {
				if (
					(!value.Equals(http_accept__crc_))
				) {
					http_accept__crc_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_ACCEPT_CHARSET { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string http_accept_charset_;// = string.Empty;
		
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
				return http_accept_charset_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(http_accept_charset_))
				) {
					http_accept_charset_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_ACCEPT_CHARSET__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long http_accept_charset__crc_;// = 0L;
		
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
				return http_accept_charset__crc_;
			}
			set {
				if (
					(!value.Equals(http_accept_charset__crc_))
				) {
					http_accept_charset__crc_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_ACCEPT_ENCODING { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string http_accept_encoding_;// = string.Empty;
		
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
				return http_accept_encoding_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(http_accept_encoding_))
				) {
					http_accept_encoding_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_ACCEPT_ENCODING__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long http_accept_encoding__crc_;// = 0L;
		
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
				return http_accept_encoding__crc_;
			}
			set {
				if (
					(!value.Equals(http_accept_encoding__crc_))
				) {
					http_accept_encoding__crc_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_ACCEPT_LANGUAGE { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string http_accept_language_;// = string.Empty;
		
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
				return http_accept_language_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(http_accept_language_))
				) {
					http_accept_language_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_ACCEPT_LANGUAGE__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long http_accept_language__crc_;// = 0L;
		
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
				return http_accept_language__crc_;
			}
			set {
				if (
					(!value.Equals(http_accept_language__crc_))
				) {
					http_accept_language__crc_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string HTTP_USER_AGENT { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string http_user_agent_;// = string.Empty;
		
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
				return http_user_agent_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(http_user_agent_))
				) {
					http_user_agent_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long HTTP_USER_AGENT__CRC { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long http_user_agent__crc_;// = 0L;
		
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
				return http_user_agent__crc_;
			}
			set {
				if (
					(!value.Equals(http_user_agent__crc_))
				) {
					http_user_agent__crc_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NET_Browser[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
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

			foreach (SO_NET_Browser _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idbrowser] = _serializableobject.IDBrowser;
				_dr[_dc_http_full_signature] = _serializableobject.HTTP_FULL_SIGNATURE;
				_dr[_dc_http_full_signature__crc] = _serializableobject.HTTP_FULL_SIGNATURE__CRC;
				_dr[_dc_http_accept] = _serializableobject.HTTP_ACCEPT;
				_dr[_dc_http_accept__crc] = _serializableobject.HTTP_ACCEPT__CRC;
				_dr[_dc_http_accept_charset] = _serializableobject.HTTP_ACCEPT_CHARSET;
				_dr[_dc_http_accept_charset__crc] = _serializableobject.HTTP_ACCEPT_CHARSET__CRC;
				_dr[_dc_http_accept_encoding] = _serializableobject.HTTP_ACCEPT_ENCODING;
				_dr[_dc_http_accept_encoding__crc] = _serializableobject.HTTP_ACCEPT_ENCODING__CRC;
				_dr[_dc_http_accept_language] = _serializableobject.HTTP_ACCEPT_LANGUAGE;
				_dr[_dc_http_accept_language__crc] = _serializableobject.HTTP_ACCEPT_LANGUAGE__CRC;
				_dr[_dc_http_user_agent] = _serializableobject.HTTP_USER_AGENT;
				_dr[_dc_http_user_agent__crc] = _serializableobject.HTTP_USER_AGENT__CRC;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idbrowser_ = 0L;
			http_full_signature_ = string.Empty;
			http_full_signature__crc_ = 0L;
			http_accept_ = string.Empty;
			http_accept__crc_ = 0L;
			http_accept_charset_ = string.Empty;
			http_accept_charset__crc_ = 0L;
			http_accept_encoding_ = string.Empty;
			http_accept_encoding__crc_ = 0L;
			http_accept_language_ = string.Empty;
			http_accept_language__crc_ = 0L;
			http_user_agent_ = string.Empty;
			http_user_agent__crc_ = 0L;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDBrowser", idbrowser_);
			info_in.AddValue("HTTP_FULL_SIGNATURE", http_full_signature_);
			info_in.AddValue("HTTP_FULL_SIGNATURE__CRC", http_full_signature__crc_);
			info_in.AddValue("HTTP_ACCEPT", http_accept_);
			info_in.AddValue("HTTP_ACCEPT__CRC", http_accept__crc_);
			info_in.AddValue("HTTP_ACCEPT_CHARSET", http_accept_charset_);
			info_in.AddValue("HTTP_ACCEPT_CHARSET__CRC", http_accept_charset__crc_);
			info_in.AddValue("HTTP_ACCEPT_ENCODING", http_accept_encoding_);
			info_in.AddValue("HTTP_ACCEPT_ENCODING__CRC", http_accept_encoding__crc_);
			info_in.AddValue("HTTP_ACCEPT_LANGUAGE", http_accept_language_);
			info_in.AddValue("HTTP_ACCEPT_LANGUAGE__CRC", http_accept_language__crc_);
			info_in.AddValue("HTTP_USER_AGENT", http_user_agent_);
			info_in.AddValue("HTTP_USER_AGENT__CRC", http_user_agent__crc_);
		}
		#endregion
		#endregion
	}
}