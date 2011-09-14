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
	/// vNWS_Content SerializableObject which provides fields access at vNWS_Content view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vNWS_Content : 
		SO__base 
	{
		#region public SO_vNWS_Content();
		public SO_vNWS_Content(
		) {
			Clear();
		}
		public SO_vNWS_Content(
			long IDContent_in, 
			int IDLanguage_in, 
			long IFUser__Publisher_in, 
			string PublisherName_in, 
			DateTime Publish_date_in, 
			long IFUser__Aproved_in, 
			DateTime Aproved_date_in, 
			string Title_in, 
			string Content_in, 
			string subtitle_in, 
			string summary_in
		) {
			haschanges_ = false;

			idcontent_ = IDContent_in;
			idlanguage_ = IDLanguage_in;
			ifuser__publisher_ = IFUser__Publisher_in;
			publishername_ = PublisherName_in;
			publish_date_ = Publish_date_in;
			ifuser__aproved_ = IFUser__Aproved_in;
			aproved_date_ = Aproved_date_in;
			title_ = Title_in;
			content_ = Content_in;
			subtitle_ = subtitle_in;
			summary_ = summary_in;
		}
		public SO_vNWS_Content(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idcontent_ = (long)info_in.GetValue("IDContent", typeof(long));
			idlanguage_ = (int)info_in.GetValue("IDLanguage", typeof(int));
			ifuser__publisher_ 
				= (info_in.GetValue("IFUser__Publisher", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFUser__Publisher", typeof(long));
			IFUser__Publisher_isNull = (bool)info_in.GetValue("IFUser__Publisher_isNull", typeof(bool));
			publishername_ 
				= (info_in.GetValue("PublisherName", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("PublisherName", typeof(string));
			PublisherName_isNull = (bool)info_in.GetValue("PublisherName_isNull", typeof(bool));
			publish_date_ 
				= (info_in.GetValue("Publish_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Publish_date", typeof(DateTime));
			Publish_date_isNull = (bool)info_in.GetValue("Publish_date_isNull", typeof(bool));
			ifuser__aproved_ 
				= (info_in.GetValue("IFUser__Aproved", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFUser__Aproved", typeof(long));
			IFUser__Aproved_isNull = (bool)info_in.GetValue("IFUser__Aproved_isNull", typeof(bool));
			aproved_date_ 
				= (info_in.GetValue("Aproved_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Aproved_date", typeof(DateTime));
			Aproved_date_isNull = (bool)info_in.GetValue("Aproved_date_isNull", typeof(bool));
			title_ 
				= (info_in.GetValue("Title", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Title", typeof(string));
			Title_isNull = (bool)info_in.GetValue("Title_isNull", typeof(bool));
			content_ 
				= (info_in.GetValue("Content", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Content", typeof(string));
			Content_isNull = (bool)info_in.GetValue("Content_isNull", typeof(bool));
			subtitle_ 
				= (info_in.GetValue("subtitle", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("subtitle", typeof(string));
			subtitle_isNull = (bool)info_in.GetValue("subtitle_isNull", typeof(bool));
			summary_ 
				= (info_in.GetValue("summary", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("summary", typeof(string));
			summary_isNull = (bool)info_in.GetValue("summary_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vNWS_Content properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IDContent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idcontent_;// = 0L;
		
		/// <summary>
		/// vNWS_Content's IDContent.
		/// </summary>
		[XmlElement("IDContent")]
		[SoapElement("IDContent")]
		[DOPropertyAttribute(
			"IDContent", 
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
			false, 
			false, 
			0, 
			""
		)]
		public long IDContent {
			get {
				return idcontent_;
			}
			set {
				if (
					(!value.Equals(idcontent_))
				) {
					idcontent_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IDLanguage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public int idlanguage_;// = 0;
		
		/// <summary>
		/// vNWS_Content's IDLanguage.
		/// </summary>
		[XmlElement("IDLanguage")]
		[SoapElement("IDLanguage")]
		[DOPropertyAttribute(
			"IDLanguage", 
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
			false, 
			false, 
			0, 
			""
		)]
		public int IDLanguage {
			get {
				return idlanguage_;
			}
			set {
				if (
					(!value.Equals(idlanguage_))
				) {
					idlanguage_ = value;
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
		/// vNWS_Content's IFUser__Publisher.
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
		/// Allows assignement of null and check if null at vNWS_Content's IFUser__Publisher.
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
		#region public string PublisherName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object publishername_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Content's PublisherName.
		/// </summary>
		[XmlElement("PublisherName")]
		[SoapElement("PublisherName")]
		[DOPropertyAttribute(
			"PublisherName", 
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
		public string PublisherName {
			get {
				return (string)((publishername_ == null) ? string.Empty : publishername_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(publishername_))
				) {
					publishername_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool PublisherName_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Content's PublisherName.
		/// </summary>
		[XmlElement("PublisherName_isNull")]
		[SoapElement("PublisherName_isNull")]
		public bool PublisherName_isNull {
			get { return (publishername_ == null); }
			set {
				//if (value) publishername_ = null;

				if ((value) && (publishername_ != null)) {
					publishername_ = null;
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
		/// vNWS_Content's Publish_date.
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
		/// Allows assignement of null and check if null at vNWS_Content's Publish_date.
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
		#region public long IFUser__Aproved { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifuser__aproved_;// = 0L;
		
		/// <summary>
		/// vNWS_Content's IFUser__Aproved.
		/// </summary>
		[XmlElement("IFUser__Aproved")]
		[SoapElement("IFUser__Aproved")]
		[DOPropertyAttribute(
			"IFUser__Aproved", 
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
		public long IFUser__Aproved {
			get {
				return (long)((ifuser__aproved_ == null) ? 0L : ifuser__aproved_);
			}
			set {
				if (
					(!value.Equals(ifuser__aproved_))
				) {
					ifuser__aproved_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFUser__Aproved_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Content's IFUser__Aproved.
		/// </summary>
		[XmlElement("IFUser__Aproved_isNull")]
		[SoapElement("IFUser__Aproved_isNull")]
		public bool IFUser__Aproved_isNull {
			get { return (ifuser__aproved_ == null); }
			set {
				//if (value) ifuser__aproved_ = null;

				if ((value) && (ifuser__aproved_ != null)) {
					ifuser__aproved_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Aproved_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object aproved_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// vNWS_Content's Aproved_date.
		/// </summary>
		[XmlElement("Aproved_date")]
		[SoapElement("Aproved_date")]
		[DOPropertyAttribute(
			"Aproved_date", 
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
		public DateTime Aproved_date {
			get {
				return (DateTime)((aproved_date_ == null) ? new DateTime(1900, 1, 1) : aproved_date_);
			}
			set {
				if (
					(!value.Equals(aproved_date_))
				) {
					aproved_date_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Aproved_date_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Content's Aproved_date.
		/// </summary>
		[XmlElement("Aproved_date_isNull")]
		[SoapElement("Aproved_date_isNull")]
		public bool Aproved_date_isNull {
			get { return (aproved_date_ == null); }
			set {
				//if (value) aproved_date_ = null;

				if ((value) && (aproved_date_ != null)) {
					aproved_date_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Title { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object title_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Content's Title.
		/// </summary>
		[XmlElement("Title")]
		[SoapElement("Title")]
		[DOPropertyAttribute(
			"Title", 
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
		public string Title {
			get {
				return (string)((title_ == null) ? string.Empty : title_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(title_))
				) {
					title_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Title_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Content's Title.
		/// </summary>
		[XmlElement("Title_isNull")]
		[SoapElement("Title_isNull")]
		public bool Title_isNull {
			get { return (title_ == null); }
			set {
				//if (value) title_ = null;

				if ((value) && (title_ != null)) {
					title_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Content { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object content_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Content's Content.
		/// </summary>
		[XmlElement("Content")]
		[SoapElement("Content")]
		[DOPropertyAttribute(
			"Content", 
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
		public string Content {
			get {
				return (string)((content_ == null) ? string.Empty : content_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(content_))
				) {
					content_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Content_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Content's Content.
		/// </summary>
		[XmlElement("Content_isNull")]
		[SoapElement("Content_isNull")]
		public bool Content_isNull {
			get { return (content_ == null); }
			set {
				//if (value) content_ = null;

				if ((value) && (content_ != null)) {
					content_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string subtitle { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object subtitle_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Content's subtitle.
		/// </summary>
		[XmlElement("subtitle")]
		[SoapElement("subtitle")]
		[DOPropertyAttribute(
			"subtitle", 
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
		public string subtitle {
			get {
				return (string)((subtitle_ == null) ? string.Empty : subtitle_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(subtitle_))
				) {
					subtitle_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool subtitle_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Content's subtitle.
		/// </summary>
		[XmlElement("subtitle_isNull")]
		[SoapElement("subtitle_isNull")]
		public bool subtitle_isNull {
			get { return (subtitle_ == null); }
			set {
				//if (value) subtitle_ = null;

				if ((value) && (subtitle_ != null)) {
					subtitle_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string summary { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object summary_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Content's summary.
		/// </summary>
		[XmlElement("summary")]
		[SoapElement("summary")]
		[DOPropertyAttribute(
			"summary", 
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
		public string summary {
			get {
				return (string)((summary_ == null) ? string.Empty : summary_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(summary_))
				) {
					summary_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool summary_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Content's summary.
		/// </summary>
		[XmlElement("summary_isNull")]
		[SoapElement("summary_isNull")]
		public bool summary_isNull {
			get { return (summary_ == null); }
			set {
				//if (value) summary_ = null;

				if ((value) && (summary_ != null)) {
					summary_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vNWS_Content[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idcontent = new DataColumn("IDContent", typeof(long));
			_output.Columns.Add(_dc_idcontent);
			DataColumn _dc_idlanguage = new DataColumn("IDLanguage", typeof(int));
			_output.Columns.Add(_dc_idlanguage);
			DataColumn _dc_ifuser__publisher = new DataColumn("IFUser__Publisher", typeof(long));
			_output.Columns.Add(_dc_ifuser__publisher);
			DataColumn _dc_publishername = new DataColumn("PublisherName", typeof(string));
			_output.Columns.Add(_dc_publishername);
			DataColumn _dc_publish_date = new DataColumn("Publish_date", typeof(DateTime));
			_output.Columns.Add(_dc_publish_date);
			DataColumn _dc_ifuser__aproved = new DataColumn("IFUser__Aproved", typeof(long));
			_output.Columns.Add(_dc_ifuser__aproved);
			DataColumn _dc_aproved_date = new DataColumn("Aproved_date", typeof(DateTime));
			_output.Columns.Add(_dc_aproved_date);
			DataColumn _dc_title = new DataColumn("Title", typeof(string));
			_output.Columns.Add(_dc_title);
			DataColumn _dc_content = new DataColumn("Content", typeof(string));
			_output.Columns.Add(_dc_content);
			DataColumn _dc_subtitle = new DataColumn("subtitle", typeof(string));
			_output.Columns.Add(_dc_subtitle);
			DataColumn _dc_summary = new DataColumn("summary", typeof(string));
			_output.Columns.Add(_dc_summary);

			foreach (SO_vNWS_Content _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idcontent] = _serializableobject.IDContent;
				_dr[_dc_idlanguage] = _serializableobject.IDLanguage;
				_dr[_dc_ifuser__publisher] = _serializableobject.IFUser__Publisher;
				_dr[_dc_publishername] = _serializableobject.PublisherName;
				_dr[_dc_publish_date] = _serializableobject.Publish_date;
				_dr[_dc_ifuser__aproved] = _serializableobject.IFUser__Aproved;
				_dr[_dc_aproved_date] = _serializableobject.Aproved_date;
				_dr[_dc_title] = _serializableobject.Title;
				_dr[_dc_content] = _serializableobject.Content;
				_dr[_dc_subtitle] = _serializableobject.subtitle;
				_dr[_dc_summary] = _serializableobject.summary;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idcontent_ = 0L;
			idlanguage_ = 0;
			ifuser__publisher_ = 0L;
			publishername_ = string.Empty;
			publish_date_ = new DateTime(1900, 1, 1);
			ifuser__aproved_ = 0L;
			aproved_date_ = new DateTime(1900, 1, 1);
			title_ = string.Empty;
			content_ = string.Empty;
			subtitle_ = string.Empty;
			summary_ = string.Empty;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDContent", idcontent_);
			info_in.AddValue("IDLanguage", idlanguage_);
			info_in.AddValue("IFUser__Publisher", ifuser__publisher_);
			info_in.AddValue("IFUser__Publisher_isNull", IFUser__Publisher_isNull);
			info_in.AddValue("PublisherName", publishername_);
			info_in.AddValue("PublisherName_isNull", PublisherName_isNull);
			info_in.AddValue("Publish_date", publish_date_);
			info_in.AddValue("Publish_date_isNull", Publish_date_isNull);
			info_in.AddValue("IFUser__Aproved", ifuser__aproved_);
			info_in.AddValue("IFUser__Aproved_isNull", IFUser__Aproved_isNull);
			info_in.AddValue("Aproved_date", aproved_date_);
			info_in.AddValue("Aproved_date_isNull", Aproved_date_isNull);
			info_in.AddValue("Title", title_);
			info_in.AddValue("Title_isNull", Title_isNull);
			info_in.AddValue("Content", content_);
			info_in.AddValue("Content_isNull", Content_isNull);
			info_in.AddValue("subtitle", subtitle_);
			info_in.AddValue("subtitle_isNull", subtitle_isNull);
			info_in.AddValue("summary", summary_);
			info_in.AddValue("summary_isNull", summary_isNull);
		}
		#endregion
		#endregion
	}
}