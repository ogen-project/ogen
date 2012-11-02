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
	/// NWS_Attachment SerializableObject which provides fields access at NWS_Attachment table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NWS_Attachment : 
		ISerializable
	{
		#region public SO_NWS_Attachment();
		public SO_NWS_Attachment(
		) {
			this.Clear();
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
			this.idattachment_ = IDAttachment_in;
			this.ifcontent_ = IFContent_in;
			this.guid_ = GUID_in;
			this.ordernum_ = OrderNum_in;
			this.isimage_ = isImage_in;
			this.tx_name_ = TX_Name_in;
			this.tx_description_ = TX_Description_in;
			this.filename_ = FileName_in;

			this.haschanges_ = false;
		}
		protected SO_NWS_Attachment(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idattachment_ = (long)info.GetValue("IDAttachment", typeof(long));
			this.ifcontent_ = (long)info.GetValue("IFContent", typeof(long));
			this.guid_ = (string)info.GetValue("GUID", typeof(string));
			this.ordernum_ 
				= (info.GetValue("OrderNum", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("OrderNum", typeof(long));
			this.OrderNum_isNull = (bool)info.GetValue("OrderNum_isNull", typeof(bool));
			this.isimage_ = (bool)info.GetValue("isImage", typeof(bool));
			this.tx_name_ 
				= (info.GetValue("TX_Name", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("TX_Name", typeof(long));
			this.TX_Name_isNull = (bool)info.GetValue("TX_Name_isNull", typeof(bool));
			this.tx_description_ 
				= (info.GetValue("TX_Description", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("TX_Description", typeof(long));
			this.TX_Description_isNull = (bool)info.GetValue("TX_Description_isNull", typeof(bool));
			this.filename_ = (string)info.GetValue("FileName", typeof(string));

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
		/// Indicates if changes have been made to FO0_NWS_Attachment properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IDAttachment { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idattachment_;// = 0L;
		
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
				return this.idattachment_;
			}
			set {
				if (
					(!value.Equals(this.idattachment_))
				) {
					this.idattachment_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFContent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifcontent_;// = 0L;
		
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
				return this.ifcontent_;
			}
			set {
				if (
					(!value.Equals(this.ifcontent_))
				) {
					this.ifcontent_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string GUID { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string guid_;// = string.Empty;
		
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
				return this.guid_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.guid_))
				) {
					this.guid_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long OrderNum { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ordernum_;// = 0L;
		
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
				return (long)((this.ordernum_ == null) ? 0L : this.ordernum_);
			}
			set {
				if (
					(!value.Equals(this.ordernum_))
				) {
					this.ordernum_ = value;
					this.haschanges_ = true;
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
			get { return (this.ordernum_ == null); }
			set {
				//if (value) this.ordernum_ = null;

				if ((value) && (this.ordernum_ != null)) {
					this.ordernum_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isImage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private bool isimage_;// = false;
		
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
				return this.isimage_;
			}
			set {
				if (
					(!value.Equals(this.isimage_))
				) {
					this.isimage_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object tx_name_;// = 0L;
		
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
				return (long)((this.tx_name_ == null) ? 0L : this.tx_name_);
			}
			set {
				if (
					(!value.Equals(this.tx_name_))
				) {
					this.tx_name_ = value;
					this.haschanges_ = true;
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
			get { return (this.tx_name_ == null); }
			set {
				//if (value) this.tx_name_ = null;

				if ((value) && (this.tx_name_ != null)) {
					this.tx_name_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Description { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object tx_description_;// = 0L;
		
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
				return (long)((this.tx_description_ == null) ? 0L : this.tx_description_);
			}
			set {
				if (
					(!value.Equals(this.tx_description_))
				) {
					this.tx_description_ = value;
					this.haschanges_ = true;
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
			get { return (this.tx_description_ == null); }
			set {
				//if (value) this.tx_description_ = null;

				if ((value) && (this.tx_description_ != null)) {
					this.tx_description_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string FileName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string filename_;// = string.Empty;
		
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
				return this.filename_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.filename_))
				) {
					this.filename_ = value;
					this.haschanges_ = true;
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
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
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
		#region public void Clear();
		/// <summary>
		/// Clears SerializableObject's properties.
		/// </summary>
		public void Clear() {
			this.idattachment_ = 0L;
			this.ifcontent_ = 0L;
			this.guid_ = string.Empty;
			this.ordernum_ = 0L;
			this.isimage_ = false;
			this.tx_name_ = 0L;
			this.tx_description_ = 0L;
			this.filename_ = string.Empty;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDAttachment", this.idattachment_);
			info.AddValue("IFContent", this.ifcontent_);
			info.AddValue("GUID", this.guid_);
			info.AddValue("OrderNum", this.ordernum_);
			info.AddValue("OrderNum_isNull", this.OrderNum_isNull);
			info.AddValue("isImage", this.isimage_);
			info.AddValue("TX_Name", this.tx_name_);
			info.AddValue("TX_Name_isNull", this.TX_Name_isNull);
			info.AddValue("TX_Description", this.tx_description_);
			info.AddValue("TX_Description_isNull", this.TX_Description_isNull);
			info.AddValue("FileName", this.filename_);
		}
		#endregion
		#endregion
	}
}