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
	/// vNWS_Content SerializableObject which provides fields access at vNWS_Content view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vNWS_Content : 
		SO__base 
	{
		#region public SO_vNWS_Content();
		public SO_vNWS_Content(
		) {
			this.Clear();
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
			this.haschanges_ = false;

			this.idcontent_ = IDContent_in;
			this.idlanguage_ = IDLanguage_in;
			this.ifuser__publisher_ = IFUser__Publisher_in;
			this.publishername_ = PublisherName_in;
			this.publish_date_ = Publish_date_in;
			this.ifuser__aproved_ = IFUser__Aproved_in;
			this.aproved_date_ = Aproved_date_in;
			this.title_ = Title_in;
			this.content_ = Content_in;
			this.subtitle_ = subtitle_in;
			this.summary_ = summary_in;
		}
		public SO_vNWS_Content(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			this.haschanges_ = false;

			this.idcontent_ = (long)info_in.GetValue("IDContent", typeof(long));
			this.idlanguage_ = (int)info_in.GetValue("IDLanguage", typeof(int));
			this.ifuser__publisher_ = (long)info_in.GetValue("IFUser__Publisher", typeof(long));
			this.publishername_ 
				= (info_in.GetValue("PublisherName", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("PublisherName", typeof(string));
			this.PublisherName_isNull = (bool)info_in.GetValue("PublisherName_isNull", typeof(bool));
			this.publish_date_ = (DateTime)info_in.GetValue("Publish_date", typeof(DateTime));
			this.ifuser__aproved_ 
				= (info_in.GetValue("IFUser__Aproved", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFUser__Aproved", typeof(long));
			this.IFUser__Aproved_isNull = (bool)info_in.GetValue("IFUser__Aproved_isNull", typeof(bool));
			this.aproved_date_ 
				= (info_in.GetValue("Aproved_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Aproved_date", typeof(DateTime));
			this.Aproved_date_isNull = (bool)info_in.GetValue("Aproved_date_isNull", typeof(bool));
			this.title_ 
				= (info_in.GetValue("Title", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Title", typeof(string));
			this.Title_isNull = (bool)info_in.GetValue("Title_isNull", typeof(bool));
			this.content_ 
				= (info_in.GetValue("Content", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Content", typeof(string));
			this.Content_isNull = (bool)info_in.GetValue("Content_isNull", typeof(bool));
			this.subtitle_ 
				= (info_in.GetValue("subtitle", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("subtitle", typeof(string));
			this.subtitle_isNull = (bool)info_in.GetValue("subtitle_isNull", typeof(bool));
			this.summary_ 
				= (info_in.GetValue("summary", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("summary", typeof(string));
			this.summary_isNull = (bool)info_in.GetValue("summary_isNull", typeof(bool));
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
			get { return this.haschanges_; }
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
		public long IDContent {
			get {
				return this.idcontent_;
			}
			set {
				if (
					(!value.Equals(this.idcontent_))
				) {
					this.idcontent_ = value;
					this.haschanges_ = true;
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
				return this.idlanguage_;
			}
			set {
				if (
					(!value.Equals(this.idlanguage_))
				) {
					this.idlanguage_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser__Publisher { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifuser__publisher_;// = 0L;
		
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
		public long IFUser__Publisher {
			get {
				return this.ifuser__publisher_;
			}
			set {
				if (
					(!value.Equals(this.ifuser__publisher_))
				) {
					this.ifuser__publisher_ = value;
					this.haschanges_ = true;
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
				return (string)((this.publishername_ == null) ? string.Empty : this.publishername_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.publishername_))
				) {
					this.publishername_ = value;
					this.haschanges_ = true;
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
			get { return (this.publishername_ == null); }
			set {
				//if (value) this.publishername_ = null;

				if ((value) && (this.publishername_ != null)) {
					this.publishername_ = null;
					this.haschanges_ = true;
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
				return (long)((this.ifuser__aproved_ == null) ? 0L : this.ifuser__aproved_);
			}
			set {
				if (
					(!value.Equals(this.ifuser__aproved_))
				) {
					this.ifuser__aproved_ = value;
					this.haschanges_ = true;
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
			get { return (this.ifuser__aproved_ == null); }
			set {
				//if (value) this.ifuser__aproved_ = null;

				if ((value) && (this.ifuser__aproved_ != null)) {
					this.ifuser__aproved_ = null;
					this.haschanges_ = true;
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
				return (DateTime)((this.aproved_date_ == null) ? new DateTime(1900, 1, 1) : this.aproved_date_);
			}
			set {
				if (
					(!value.Equals(this.aproved_date_))
				) {
					this.aproved_date_ = value;
					this.haschanges_ = true;
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
			get { return (this.aproved_date_ == null); }
			set {
				//if (value) this.aproved_date_ = null;

				if ((value) && (this.aproved_date_ != null)) {
					this.aproved_date_ = null;
					this.haschanges_ = true;
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
			2147483647, 
			""
		)]
		public string Title {
			get {
				return (string)((this.title_ == null) ? string.Empty : this.title_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.title_))
				) {
					this.title_ = value;
					this.haschanges_ = true;
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
			get { return (this.title_ == null); }
			set {
				//if (value) this.title_ = null;

				if ((value) && (this.title_ != null)) {
					this.title_ = null;
					this.haschanges_ = true;
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
			2147483647, 
			""
		)]
		public string Content {
			get {
				return (string)((this.content_ == null) ? string.Empty : this.content_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.content_))
				) {
					this.content_ = value;
					this.haschanges_ = true;
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
			get { return (this.content_ == null); }
			set {
				//if (value) this.content_ = null;

				if ((value) && (this.content_ != null)) {
					this.content_ = null;
					this.haschanges_ = true;
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
			2147483647, 
			""
		)]
		public string subtitle {
			get {
				return (string)((this.subtitle_ == null) ? string.Empty : this.subtitle_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.subtitle_))
				) {
					this.subtitle_ = value;
					this.haschanges_ = true;
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
			get { return (this.subtitle_ == null); }
			set {
				//if (value) this.subtitle_ = null;

				if ((value) && (this.subtitle_ != null)) {
					this.subtitle_ = null;
					this.haschanges_ = true;
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
			2147483647, 
			""
		)]
		public string summary {
			get {
				return (string)((this.summary_ == null) ? string.Empty : this.summary_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.summary_))
				) {
					this.summary_ = value;
					this.haschanges_ = true;
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
			get { return (this.summary_ == null); }
			set {
				//if (value) this.summary_ = null;

				if ((value) && (this.summary_ != null)) {
					this.summary_ = null;
					this.haschanges_ = true;
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
			this.haschanges_ = false;

			this.idcontent_ = 0L;
			this.idlanguage_ = 0;
			this.ifuser__publisher_ = 0L;
			this.publishername_ = string.Empty;
			this.publish_date_ = new DateTime(1900, 1, 1);
			this.ifuser__aproved_ = 0L;
			this.aproved_date_ = new DateTime(1900, 1, 1);
			this.title_ = string.Empty;
			this.content_ = string.Empty;
			this.subtitle_ = string.Empty;
			this.summary_ = string.Empty;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDContent", this.idcontent_);
			info_in.AddValue("IDLanguage", this.idlanguage_);
			info_in.AddValue("IFUser__Publisher", this.ifuser__publisher_);
			info_in.AddValue("PublisherName", this.publishername_);
			info_in.AddValue("PublisherName_isNull", this.PublisherName_isNull);
			info_in.AddValue("Publish_date", this.publish_date_);
			info_in.AddValue("IFUser__Aproved", this.ifuser__aproved_);
			info_in.AddValue("IFUser__Aproved_isNull", this.IFUser__Aproved_isNull);
			info_in.AddValue("Aproved_date", this.aproved_date_);
			info_in.AddValue("Aproved_date_isNull", this.Aproved_date_isNull);
			info_in.AddValue("Title", this.title_);
			info_in.AddValue("Title_isNull", this.Title_isNull);
			info_in.AddValue("Content", this.content_);
			info_in.AddValue("Content_isNull", this.Content_isNull);
			info_in.AddValue("subtitle", this.subtitle_);
			info_in.AddValue("subtitle_isNull", this.subtitle_isNull);
			info_in.AddValue("summary", this.summary_);
			info_in.AddValue("summary_isNull", this.summary_isNull);
		}
		#endregion
		#endregion
	}
}