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
	/// NWS_Content SerializableObject which provides fields access at NWS_Content table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NWS_Content : 
		SO__base 
	{
		#region public SO_NWS_Content();
		public SO_NWS_Content(
		) {
			Clear();
		}
		public SO_NWS_Content(
			long IDContent_in, 
			int IFApplication_in, 
			long IFUser__Publisher_in, 
			DateTime Publish_date_in, 
			long IFUser__Aproved_in, 
			DateTime Aproved_date_in, 
			DateTime Begin_date_in, 
			DateTime End_date_in, 
			long TX_Title_in, 
			long TX_Content_in, 
			long tx_subtitle_in, 
			long tx_summary_in, 
			DateTime Newslettersent_date_in, 
			bool isNews_notForum_in
		) {
			haschanges_ = false;

			idcontent_ = IDContent_in;
			ifapplication_ = IFApplication_in;
			ifuser__publisher_ = IFUser__Publisher_in;
			publish_date_ = Publish_date_in;
			ifuser__aproved_ = IFUser__Aproved_in;
			aproved_date_ = Aproved_date_in;
			begin_date_ = Begin_date_in;
			end_date_ = End_date_in;
			tx_title_ = TX_Title_in;
			tx_content_ = TX_Content_in;
			tx_subtitle_ = tx_subtitle_in;
			tx_summary_ = tx_summary_in;
			newslettersent_date_ = Newslettersent_date_in;
			isnews_notforum_ = isNews_notForum_in;
		}
		public SO_NWS_Content(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idcontent_ = (long)info_in.GetValue("IDContent", typeof(long));
			ifapplication_ 
				= (info_in.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IFApplication", typeof(int));
			IFApplication_isNull = (bool)info_in.GetValue("IFApplication_isNull", typeof(bool));
			ifuser__publisher_ = (long)info_in.GetValue("IFUser__Publisher", typeof(long));
			publish_date_ = (DateTime)info_in.GetValue("Publish_date", typeof(DateTime));
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
			begin_date_ 
				= (info_in.GetValue("Begin_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Begin_date", typeof(DateTime));
			Begin_date_isNull = (bool)info_in.GetValue("Begin_date_isNull", typeof(bool));
			end_date_ 
				= (info_in.GetValue("End_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("End_date", typeof(DateTime));
			End_date_isNull = (bool)info_in.GetValue("End_date_isNull", typeof(bool));
			tx_title_ 
				= (info_in.GetValue("TX_Title", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("TX_Title", typeof(long));
			TX_Title_isNull = (bool)info_in.GetValue("TX_Title_isNull", typeof(bool));
			tx_content_ 
				= (info_in.GetValue("TX_Content", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("TX_Content", typeof(long));
			TX_Content_isNull = (bool)info_in.GetValue("TX_Content_isNull", typeof(bool));
			tx_subtitle_ 
				= (info_in.GetValue("tx_subtitle", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("tx_subtitle", typeof(long));
			tx_subtitle_isNull = (bool)info_in.GetValue("tx_subtitle_isNull", typeof(bool));
			tx_summary_ 
				= (info_in.GetValue("tx_summary", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("tx_summary", typeof(long));
			tx_summary_isNull = (bool)info_in.GetValue("tx_summary_isNull", typeof(bool));
			newslettersent_date_ 
				= (info_in.GetValue("Newslettersent_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Newslettersent_date", typeof(DateTime));
			Newslettersent_date_isNull = (bool)info_in.GetValue("Newslettersent_date_isNull", typeof(bool));
			isnews_notforum_ 
				= (info_in.GetValue("isNews_notForum", typeof(bool)) == null)
					? false
					: (bool)info_in.GetValue("isNews_notForum", typeof(bool));
			isNews_notForum_isNull = (bool)info_in.GetValue("isNews_notForum_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_NWS_Content properties since last time getObject method was run.
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
		/// NWS_Content's IDContent.
		/// </summary>
		[XmlElement("IDContent")]
		[SoapElement("IDContent")]
		[DOPropertyAttribute(
			"IDContent", 
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
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifapplication_;// = 0;
		
		/// <summary>
		/// NWS_Content's IFApplication.
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
		/// Allows assignement of null and check if null at NWS_Content's IFApplication.
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
		#region public long IFUser__Publisher { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifuser__publisher_;// = 0L;
		
		/// <summary>
		/// NWS_Content's IFUser__Publisher.
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
				return ifuser__publisher_;
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
		#region public DateTime Publish_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public DateTime publish_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// NWS_Content's Publish_date.
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
		#region public long IFUser__Aproved { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifuser__aproved_;// = 0L;
		
		/// <summary>
		/// NWS_Content's IFUser__Aproved.
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
		/// Allows assignement of null and check if null at NWS_Content's IFUser__Aproved.
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
		/// NWS_Content's Aproved_date.
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
		/// Allows assignement of null and check if null at NWS_Content's Aproved_date.
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
		#region public DateTime Begin_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object begin_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// NWS_Content's Begin_date.
		/// </summary>
		[XmlElement("Begin_date")]
		[SoapElement("Begin_date")]
		[DOPropertyAttribute(
			"Begin_date", 
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
		public DateTime Begin_date {
			get {
				return (DateTime)((begin_date_ == null) ? new DateTime(1900, 1, 1) : begin_date_);
			}
			set {
				if (
					(!value.Equals(begin_date_))
				) {
					begin_date_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Begin_date_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Content's Begin_date.
		/// </summary>
		[XmlElement("Begin_date_isNull")]
		[SoapElement("Begin_date_isNull")]
		public bool Begin_date_isNull {
			get { return (begin_date_ == null); }
			set {
				//if (value) begin_date_ = null;

				if ((value) && (begin_date_ != null)) {
					begin_date_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime End_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object end_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// NWS_Content's End_date.
		/// </summary>
		[XmlElement("End_date")]
		[SoapElement("End_date")]
		[DOPropertyAttribute(
			"End_date", 
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
		public DateTime End_date {
			get {
				return (DateTime)((end_date_ == null) ? new DateTime(1900, 1, 1) : end_date_);
			}
			set {
				if (
					(!value.Equals(end_date_))
				) {
					end_date_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool End_date_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Content's End_date.
		/// </summary>
		[XmlElement("End_date_isNull")]
		[SoapElement("End_date_isNull")]
		public bool End_date_isNull {
			get { return (end_date_ == null); }
			set {
				//if (value) end_date_ = null;

				if ((value) && (end_date_ != null)) {
					end_date_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Title { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object tx_title_;// = 0L;
		
		/// <summary>
		/// NWS_Content's TX_Title.
		/// </summary>
		[XmlElement("TX_Title")]
		[SoapElement("TX_Title")]
		[DOPropertyAttribute(
			"TX_Title", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"DIC_Text", 
			"IDText", 
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
		public long TX_Title {
			get {
				return (long)((tx_title_ == null) ? 0L : tx_title_);
			}
			set {
				if (
					(!value.Equals(tx_title_))
				) {
					tx_title_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool TX_Title_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Content's TX_Title.
		/// </summary>
		[XmlElement("TX_Title_isNull")]
		[SoapElement("TX_Title_isNull")]
		public bool TX_Title_isNull {
			get { return (tx_title_ == null); }
			set {
				//if (value) tx_title_ = null;

				if ((value) && (tx_title_ != null)) {
					tx_title_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Content { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object tx_content_;// = 0L;
		
		/// <summary>
		/// NWS_Content's TX_Content.
		/// </summary>
		[XmlElement("TX_Content")]
		[SoapElement("TX_Content")]
		[DOPropertyAttribute(
			"TX_Content", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"DIC_Text", 
			"IDText", 
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
		public long TX_Content {
			get {
				return (long)((tx_content_ == null) ? 0L : tx_content_);
			}
			set {
				if (
					(!value.Equals(tx_content_))
				) {
					tx_content_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool TX_Content_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Content's TX_Content.
		/// </summary>
		[XmlElement("TX_Content_isNull")]
		[SoapElement("TX_Content_isNull")]
		public bool TX_Content_isNull {
			get { return (tx_content_ == null); }
			set {
				//if (value) tx_content_ = null;

				if ((value) && (tx_content_ != null)) {
					tx_content_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long tx_subtitle { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object tx_subtitle_;// = 0L;
		
		/// <summary>
		/// NWS_Content's tx_subtitle.
		/// </summary>
		[XmlElement("tx_subtitle")]
		[SoapElement("tx_subtitle")]
		[DOPropertyAttribute(
			"tx_subtitle", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"DIC_Text", 
			"IDText", 
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
		public long tx_subtitle {
			get {
				return (long)((tx_subtitle_ == null) ? 0L : tx_subtitle_);
			}
			set {
				if (
					(!value.Equals(tx_subtitle_))
				) {
					tx_subtitle_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool tx_subtitle_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Content's tx_subtitle.
		/// </summary>
		[XmlElement("tx_subtitle_isNull")]
		[SoapElement("tx_subtitle_isNull")]
		public bool tx_subtitle_isNull {
			get { return (tx_subtitle_ == null); }
			set {
				//if (value) tx_subtitle_ = null;

				if ((value) && (tx_subtitle_ != null)) {
					tx_subtitle_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long tx_summary { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object tx_summary_;// = 0L;
		
		/// <summary>
		/// NWS_Content's tx_summary.
		/// </summary>
		[XmlElement("tx_summary")]
		[SoapElement("tx_summary")]
		[DOPropertyAttribute(
			"tx_summary", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"DIC_Text", 
			"IDText", 
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
		public long tx_summary {
			get {
				return (long)((tx_summary_ == null) ? 0L : tx_summary_);
			}
			set {
				if (
					(!value.Equals(tx_summary_))
				) {
					tx_summary_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool tx_summary_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Content's tx_summary.
		/// </summary>
		[XmlElement("tx_summary_isNull")]
		[SoapElement("tx_summary_isNull")]
		public bool tx_summary_isNull {
			get { return (tx_summary_ == null); }
			set {
				//if (value) tx_summary_ = null;

				if ((value) && (tx_summary_ != null)) {
					tx_summary_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Newslettersent_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object newslettersent_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// NWS_Content's Newslettersent_date.
		/// </summary>
		[XmlElement("Newslettersent_date")]
		[SoapElement("Newslettersent_date")]
		[DOPropertyAttribute(
			"Newslettersent_date", 
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
		public DateTime Newslettersent_date {
			get {
				return (DateTime)((newslettersent_date_ == null) ? new DateTime(1900, 1, 1) : newslettersent_date_);
			}
			set {
				if (
					(!value.Equals(newslettersent_date_))
				) {
					newslettersent_date_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Newslettersent_date_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Content's Newslettersent_date.
		/// </summary>
		[XmlElement("Newslettersent_date_isNull")]
		[SoapElement("Newslettersent_date_isNull")]
		public bool Newslettersent_date_isNull {
			get { return (newslettersent_date_ == null); }
			set {
				//if (value) newslettersent_date_ = null;

				if ((value) && (newslettersent_date_ != null)) {
					newslettersent_date_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isNews_notForum { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object isnews_notforum_;// = false;
		
		/// <summary>
		/// NWS_Content's isNews_notForum.
		/// </summary>
		[XmlElement("isNews_notForum")]
		[SoapElement("isNews_notForum")]
		[DOPropertyAttribute(
			"isNews_notForum", 
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
		public bool isNews_notForum {
			get {
				return (bool)((isnews_notforum_ == null) ? false : isnews_notforum_);
			}
			set {
				if (
					(!value.Equals(isnews_notforum_))
				) {
					isnews_notforum_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isNews_notForum_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Content's isNews_notForum.
		/// </summary>
		[XmlElement("isNews_notForum_isNull")]
		[SoapElement("isNews_notForum_isNull")]
		public bool isNews_notForum_isNull {
			get { return (isnews_notforum_ == null); }
			set {
				//if (value) isnews_notforum_ = null;

				if ((value) && (isnews_notforum_ != null)) {
					isnews_notforum_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NWS_Content[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idcontent = new DataColumn("IDContent", typeof(long));
			_output.Columns.Add(_dc_idcontent);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_ifuser__publisher = new DataColumn("IFUser__Publisher", typeof(long));
			_output.Columns.Add(_dc_ifuser__publisher);
			DataColumn _dc_publish_date = new DataColumn("Publish_date", typeof(DateTime));
			_output.Columns.Add(_dc_publish_date);
			DataColumn _dc_ifuser__aproved = new DataColumn("IFUser__Aproved", typeof(long));
			_output.Columns.Add(_dc_ifuser__aproved);
			DataColumn _dc_aproved_date = new DataColumn("Aproved_date", typeof(DateTime));
			_output.Columns.Add(_dc_aproved_date);
			DataColumn _dc_begin_date = new DataColumn("Begin_date", typeof(DateTime));
			_output.Columns.Add(_dc_begin_date);
			DataColumn _dc_end_date = new DataColumn("End_date", typeof(DateTime));
			_output.Columns.Add(_dc_end_date);
			DataColumn _dc_tx_title = new DataColumn("TX_Title", typeof(long));
			_output.Columns.Add(_dc_tx_title);
			DataColumn _dc_tx_content = new DataColumn("TX_Content", typeof(long));
			_output.Columns.Add(_dc_tx_content);
			DataColumn _dc_tx_subtitle = new DataColumn("tx_subtitle", typeof(long));
			_output.Columns.Add(_dc_tx_subtitle);
			DataColumn _dc_tx_summary = new DataColumn("tx_summary", typeof(long));
			_output.Columns.Add(_dc_tx_summary);
			DataColumn _dc_newslettersent_date = new DataColumn("Newslettersent_date", typeof(DateTime));
			_output.Columns.Add(_dc_newslettersent_date);
			DataColumn _dc_isnews_notforum = new DataColumn("isNews_notForum", typeof(bool));
			_output.Columns.Add(_dc_isnews_notforum);

			foreach (SO_NWS_Content _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idcontent] = _serializableobject.IDContent;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;
				_dr[_dc_ifuser__publisher] = _serializableobject.IFUser__Publisher;
				_dr[_dc_publish_date] = _serializableobject.Publish_date;
				_dr[_dc_ifuser__aproved] = _serializableobject.IFUser__Aproved;
				_dr[_dc_aproved_date] = _serializableobject.Aproved_date;
				_dr[_dc_begin_date] = _serializableobject.Begin_date;
				_dr[_dc_end_date] = _serializableobject.End_date;
				_dr[_dc_tx_title] = _serializableobject.TX_Title;
				_dr[_dc_tx_content] = _serializableobject.TX_Content;
				_dr[_dc_tx_subtitle] = _serializableobject.tx_subtitle;
				_dr[_dc_tx_summary] = _serializableobject.tx_summary;
				_dr[_dc_newslettersent_date] = _serializableobject.Newslettersent_date;
				_dr[_dc_isnews_notforum] = _serializableobject.isNews_notForum;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idcontent_ = 0L;
			ifapplication_ = 0;
			ifuser__publisher_ = 0L;
			publish_date_ = new DateTime(1900, 1, 1);
			ifuser__aproved_ = 0L;
			aproved_date_ = new DateTime(1900, 1, 1);
			begin_date_ = new DateTime(1900, 1, 1);
			end_date_ = new DateTime(1900, 1, 1);
			tx_title_ = 0L;
			tx_content_ = 0L;
			tx_subtitle_ = 0L;
			tx_summary_ = 0L;
			newslettersent_date_ = new DateTime(1900, 1, 1);
			isnews_notforum_ = false;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDContent", idcontent_);
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IFApplication_isNull", IFApplication_isNull);
			info_in.AddValue("IFUser__Publisher", ifuser__publisher_);
			info_in.AddValue("Publish_date", publish_date_);
			info_in.AddValue("IFUser__Aproved", ifuser__aproved_);
			info_in.AddValue("IFUser__Aproved_isNull", IFUser__Aproved_isNull);
			info_in.AddValue("Aproved_date", aproved_date_);
			info_in.AddValue("Aproved_date_isNull", Aproved_date_isNull);
			info_in.AddValue("Begin_date", begin_date_);
			info_in.AddValue("Begin_date_isNull", Begin_date_isNull);
			info_in.AddValue("End_date", end_date_);
			info_in.AddValue("End_date_isNull", End_date_isNull);
			info_in.AddValue("TX_Title", tx_title_);
			info_in.AddValue("TX_Title_isNull", TX_Title_isNull);
			info_in.AddValue("TX_Content", tx_content_);
			info_in.AddValue("TX_Content_isNull", TX_Content_isNull);
			info_in.AddValue("tx_subtitle", tx_subtitle_);
			info_in.AddValue("tx_subtitle_isNull", tx_subtitle_isNull);
			info_in.AddValue("tx_summary", tx_summary_);
			info_in.AddValue("tx_summary_isNull", tx_summary_isNull);
			info_in.AddValue("Newslettersent_date", newslettersent_date_);
			info_in.AddValue("Newslettersent_date_isNull", Newslettersent_date_isNull);
			info_in.AddValue("isNews_notForum", isnews_notforum_);
			info_in.AddValue("isNews_notForum_isNull", isNews_notForum_isNull);
		}
		#endregion
		#endregion
	}
}