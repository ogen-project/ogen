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
	/// vNWS_Attachment SerializableObject which provides fields access at vNWS_Attachment view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vNWS_Attachment : 
		ISerializable
	{
		#region public SO_vNWS_Attachment();
		public SO_vNWS_Attachment(
		) {
			this.Clear();
		}
		public SO_vNWS_Attachment(
			long IDAttachment_in, 
			int IDLanguage_in, 
			long IFContent_in, 
			string GUID_in, 
			long OrderNum_in, 
			bool isImage_in, 
			string Name_in, 
			string Description_in, 
			string FileName_in
		) {
			this.idattachment_ = IDAttachment_in;
			this.idlanguage_ = IDLanguage_in;
			this.ifcontent_ = IFContent_in;
			this.guid_ = GUID_in;
			this.ordernum_ = OrderNum_in;
			this.isimage_ = isImage_in;
			this.name_ = Name_in;
			this.description_ = Description_in;
			this.filename_ = FileName_in;

			this.haschanges_ = false;
		}
		protected SO_vNWS_Attachment(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idattachment_ = (long)info.GetValue("IDAttachment", typeof(long));
			this.idlanguage_ = (int)info.GetValue("IDLanguage", typeof(int));
			this.ifcontent_ = (long)info.GetValue("IFContent", typeof(long));
			this.guid_ = (string)info.GetValue("GUID", typeof(string));
			this.ordernum_ 
				= (info.GetValue("OrderNum", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("OrderNum", typeof(long));
			this.OrderNum_isNull = (bool)info.GetValue("OrderNum_isNull", typeof(bool));
			this.isimage_ = (bool)info.GetValue("isImage", typeof(bool));
			this.name_ 
				= (info.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Name", typeof(string));
			this.Name_isNull = (bool)info.GetValue("Name_isNull", typeof(bool));
			this.description_ 
				= (info.GetValue("Description", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Description", typeof(string));
			this.Description_isNull = (bool)info.GetValue("Description_isNull", typeof(bool));
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
		/// Indicates if changes have been made to FO0_vNWS_Attachment properties since last time getObject method was run.
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
		/// vNWS_Attachment's IDAttachment.
		/// </summary>
		[XmlElement("IDAttachment")]
		[SoapElement("IDAttachment")]
		[DOPropertyAttribute(
			"IDAttachment", 
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
		#region public int IDLanguage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private int idlanguage_;// = 0;
		
		/// <summary>
		/// vNWS_Attachment's IDLanguage.
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
		#region public long IFContent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifcontent_;// = 0L;
		
		/// <summary>
		/// vNWS_Attachment's IFContent.
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
		/// vNWS_Attachment's GUID.
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
		/// vNWS_Attachment's OrderNum.
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
		/// Allows assignement of null and check if null at vNWS_Attachment's OrderNum.
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
		/// vNWS_Attachment's isImage.
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
		#region public string Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object name_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Attachment's Name.
		/// </summary>
		[XmlElement("Name")]
		[SoapElement("Name")]
		[DOPropertyAttribute(
			"Name", 
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
		public string Name {
			get {
				return (string)((this.name_ == null) ? string.Empty : this.name_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.name_))
				) {
					this.name_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Name_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Attachment's Name.
		/// </summary>
		[XmlElement("Name_isNull")]
		[SoapElement("Name_isNull")]
		public bool Name_isNull {
			get { return (this.name_ == null); }
			set {
				//if (value) this.name_ = null;

				if ((value) && (this.name_ != null)) {
					this.name_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Description { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object description_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Attachment's Description.
		/// </summary>
		[XmlElement("Description")]
		[SoapElement("Description")]
		[DOPropertyAttribute(
			"Description", 
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
		public string Description {
			get {
				return (string)((this.description_ == null) ? string.Empty : this.description_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.description_))
				) {
					this.description_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Description_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Attachment's Description.
		/// </summary>
		[XmlElement("Description_isNull")]
		[SoapElement("Description_isNull")]
		public bool Description_isNull {
			get { return (this.description_ == null); }
			set {
				//if (value) this.description_ = null;

				if ((value) && (this.description_ != null)) {
					this.description_ = null;
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
		/// vNWS_Attachment's FileName.
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
			SO_vNWS_Attachment[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idattachment = new DataColumn("IDAttachment", typeof(long));
			_output.Columns.Add(_dc_idattachment);
			DataColumn _dc_idlanguage = new DataColumn("IDLanguage", typeof(int));
			_output.Columns.Add(_dc_idlanguage);
			DataColumn _dc_ifcontent = new DataColumn("IFContent", typeof(long));
			_output.Columns.Add(_dc_ifcontent);
			DataColumn _dc_guid = new DataColumn("GUID", typeof(string));
			_output.Columns.Add(_dc_guid);
			DataColumn _dc_ordernum = new DataColumn("OrderNum", typeof(long));
			_output.Columns.Add(_dc_ordernum);
			DataColumn _dc_isimage = new DataColumn("isImage", typeof(bool));
			_output.Columns.Add(_dc_isimage);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_description = new DataColumn("Description", typeof(string));
			_output.Columns.Add(_dc_description);
			DataColumn _dc_filename = new DataColumn("FileName", typeof(string));
			_output.Columns.Add(_dc_filename);

			foreach (SO_vNWS_Attachment _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idattachment] = _serializableobject.IDAttachment;
				_dr[_dc_idlanguage] = _serializableobject.IDLanguage;
				_dr[_dc_ifcontent] = _serializableobject.IFContent;
				_dr[_dc_guid] = _serializableobject.GUID;
				_dr[_dc_ordernum] = _serializableobject.OrderNum;
				_dr[_dc_isimage] = _serializableobject.isImage;
				_dr[_dc_name] = _serializableobject.Name;
				_dr[_dc_description] = _serializableobject.Description;
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
			this.idlanguage_ = 0;
			this.ifcontent_ = 0L;
			this.guid_ = string.Empty;
			this.ordernum_ = 0L;
			this.isimage_ = false;
			this.name_ = string.Empty;
			this.description_ = string.Empty;
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
			info.AddValue("IDLanguage", this.idlanguage_);
			info.AddValue("IFContent", this.ifcontent_);
			info.AddValue("GUID", this.guid_);
			info.AddValue("OrderNum", this.ordernum_);
			info.AddValue("OrderNum_isNull", this.OrderNum_isNull);
			info.AddValue("isImage", this.isimage_);
			info.AddValue("Name", this.name_);
			info.AddValue("Name_isNull", this.Name_isNull);
			info.AddValue("Description", this.description_);
			info.AddValue("Description_isNull", this.Description_isNull);
			info.AddValue("FileName", this.filename_);
		}
		#endregion
		#endregion
	}
}