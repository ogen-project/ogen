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
	/// NWS_Attachment SerializableObject which provides fields access at NWS_Attachment table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NWS_Attachment : 
		SO__base 
	{
		#region public SO_NWS_Attachment();
		public SO_NWS_Attachment(
		) {
			Clear();
		}
		public SO_NWS_Attachment(
			long IDAttachment_in, 
			long IFContent_in, 
			string GUID_in, 
			long OrderNum_in, 
			bool isImage_in, 
			long TX_Name_in, 
			long TX_Description_in, 
			string FileName_in
		) {
			haschanges_ = false;

			idattachment_ = IDAttachment_in;
			ifcontent_ = IFContent_in;
			guid_ = GUID_in;
			ordernum_ = OrderNum_in;
			isimage_ = isImage_in;
			tx_name_ = TX_Name_in;
			tx_description_ = TX_Description_in;
			filename_ = FileName_in;
		}
		public SO_NWS_Attachment(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idattachment_ = (long)info_in.GetValue("IDAttachment", typeof(long));
			ifcontent_ = (long)info_in.GetValue("IFContent", typeof(long));
			guid_ = (string)info_in.GetValue("GUID", typeof(string));
			ordernum_ 
				= (info_in.GetValue("OrderNum", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("OrderNum", typeof(long));
			OrderNum_isNull = (bool)info_in.GetValue("OrderNum_isNull", typeof(bool));
			isimage_ = (bool)info_in.GetValue("isImage", typeof(bool));
			tx_name_ 
				= (info_in.GetValue("TX_Name", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("TX_Name", typeof(long));
			TX_Name_isNull = (bool)info_in.GetValue("TX_Name_isNull", typeof(bool));
			tx_description_ 
				= (info_in.GetValue("TX_Description", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("TX_Description", typeof(long));
			TX_Description_isNull = (bool)info_in.GetValue("TX_Description_isNull", typeof(bool));
			filename_ = (string)info_in.GetValue("FileName", typeof(string));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_NWS_Attachment properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IDAttachment { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idattachment_;// = 0L;
		
		/// <summary>
		/// NWS_Attachment's IDAttachment.
		/// </summary>
		[XmlElement("IDAttachment")]
		[SoapElement("IDAttachment")]
		[DOPropertyAttribute(
			"IDAttachment", 
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
		public long IDAttachment {
			get {
				return idattachment_;
			}
			set {
				if (
					(!value.Equals(idattachment_))
				) {
					idattachment_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFContent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifcontent_;// = 0L;
		
		/// <summary>
		/// NWS_Attachment's IFContent.
		/// </summary>
		[XmlElement("IFContent")]
		[SoapElement("IFContent")]
		[DOPropertyAttribute(
			"IFContent", 
			"", 
			"", 
			false, 
			false, 
			false, 
			"", 
			"NWS_Content", 
			"IDContent", 
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
		public long IFContent {
			get {
				return ifcontent_;
			}
			set {
				if (
					(!value.Equals(ifcontent_))
				) {
					ifcontent_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string GUID { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string guid_;// = string.Empty;
		
		/// <summary>
		/// NWS_Attachment's GUID.
		/// </summary>
		[XmlElement("GUID")]
		[SoapElement("GUID")]
		[DOPropertyAttribute(
			"GUID", 
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
			50, 
			""
		)]
		public string GUID {
			get {
				return guid_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(guid_))
				) {
					guid_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long OrderNum { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ordernum_;// = 0L;
		
		/// <summary>
		/// NWS_Attachment's OrderNum.
		/// </summary>
		[XmlElement("OrderNum")]
		[SoapElement("OrderNum")]
		[DOPropertyAttribute(
			"OrderNum", 
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
		public long OrderNum {
			get {
				return (long)((ordernum_ == null) ? 0L : ordernum_);
			}
			set {
				if (
					(!value.Equals(ordernum_))
				) {
					ordernum_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool OrderNum_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Attachment's OrderNum.
		/// </summary>
		[XmlElement("OrderNum_isNull")]
		[SoapElement("OrderNum_isNull")]
		public bool OrderNum_isNull {
			get { return (ordernum_ == null); }
			set {
				//if (value) ordernum_ = null;

				if ((value) && (ordernum_ != null)) {
					ordernum_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isImage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool isimage_;// = false;
		
		/// <summary>
		/// NWS_Attachment's isImage.
		/// </summary>
		[XmlElement("isImage")]
		[SoapElement("isImage")]
		[DOPropertyAttribute(
			"isImage", 
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
		public bool isImage {
			get {
				return isimage_;
			}
			set {
				if (
					(!value.Equals(isimage_))
				) {
					isimage_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object tx_name_;// = 0L;
		
		/// <summary>
		/// NWS_Attachment's TX_Name.
		/// </summary>
		[XmlElement("TX_Name")]
		[SoapElement("TX_Name")]
		[DOPropertyAttribute(
			"TX_Name", 
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
		public long TX_Name {
			get {
				return (long)((tx_name_ == null) ? 0L : tx_name_);
			}
			set {
				if (
					(!value.Equals(tx_name_))
				) {
					tx_name_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool TX_Name_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Attachment's TX_Name.
		/// </summary>
		[XmlElement("TX_Name_isNull")]
		[SoapElement("TX_Name_isNull")]
		public bool TX_Name_isNull {
			get { return (tx_name_ == null); }
			set {
				//if (value) tx_name_ = null;

				if ((value) && (tx_name_ != null)) {
					tx_name_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Description { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object tx_description_;// = 0L;
		
		/// <summary>
		/// NWS_Attachment's TX_Description.
		/// </summary>
		[XmlElement("TX_Description")]
		[SoapElement("TX_Description")]
		[DOPropertyAttribute(
			"TX_Description", 
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
		public long TX_Description {
			get {
				return (long)((tx_description_ == null) ? 0L : tx_description_);
			}
			set {
				if (
					(!value.Equals(tx_description_))
				) {
					tx_description_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool TX_Description_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_Attachment's TX_Description.
		/// </summary>
		[XmlElement("TX_Description_isNull")]
		[SoapElement("TX_Description_isNull")]
		public bool TX_Description_isNull {
			get { return (tx_description_ == null); }
			set {
				//if (value) tx_description_ = null;

				if ((value) && (tx_description_ != null)) {
					tx_description_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string FileName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string filename_;// = string.Empty;
		
		/// <summary>
		/// NWS_Attachment's FileName.
		/// </summary>
		[XmlElement("FileName")]
		[SoapElement("FileName")]
		[DOPropertyAttribute(
			"FileName", 
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
		public string FileName {
			get {
				return filename_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(filename_))
				) {
					filename_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NWS_Attachment[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idattachment = new DataColumn("IDAttachment", typeof(long));
			_output.Columns.Add(_dc_idattachment);
			DataColumn _dc_ifcontent = new DataColumn("IFContent", typeof(long));
			_output.Columns.Add(_dc_ifcontent);
			DataColumn _dc_guid = new DataColumn("GUID", typeof(string));
			_output.Columns.Add(_dc_guid);
			DataColumn _dc_ordernum = new DataColumn("OrderNum", typeof(long));
			_output.Columns.Add(_dc_ordernum);
			DataColumn _dc_isimage = new DataColumn("isImage", typeof(bool));
			_output.Columns.Add(_dc_isimage);
			DataColumn _dc_tx_name = new DataColumn("TX_Name", typeof(long));
			_output.Columns.Add(_dc_tx_name);
			DataColumn _dc_tx_description = new DataColumn("TX_Description", typeof(long));
			_output.Columns.Add(_dc_tx_description);
			DataColumn _dc_filename = new DataColumn("FileName", typeof(string));
			_output.Columns.Add(_dc_filename);

			foreach (SO_NWS_Attachment _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idattachment] = _serializableobject.IDAttachment;
				_dr[_dc_ifcontent] = _serializableobject.IFContent;
				_dr[_dc_guid] = _serializableobject.GUID;
				_dr[_dc_ordernum] = _serializableobject.OrderNum;
				_dr[_dc_isimage] = _serializableobject.isImage;
				_dr[_dc_tx_name] = _serializableobject.TX_Name;
				_dr[_dc_tx_description] = _serializableobject.TX_Description;
				_dr[_dc_filename] = _serializableobject.FileName;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idattachment_ = 0L;
			ifcontent_ = 0L;
			guid_ = string.Empty;
			ordernum_ = 0L;
			isimage_ = false;
			tx_name_ = 0L;
			tx_description_ = 0L;
			filename_ = string.Empty;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDAttachment", idattachment_);
			info_in.AddValue("IFContent", ifcontent_);
			info_in.AddValue("GUID", guid_);
			info_in.AddValue("OrderNum", ordernum_);
			info_in.AddValue("OrderNum_isNull", OrderNum_isNull);
			info_in.AddValue("isImage", isimage_);
			info_in.AddValue("TX_Name", tx_name_);
			info_in.AddValue("TX_Name_isNull", TX_Name_isNull);
			info_in.AddValue("TX_Description", tx_description_);
			info_in.AddValue("TX_Description_isNull", TX_Description_isNull);
			info_in.AddValue("FileName", filename_);
		}
		#endregion
		#endregion
	}
}