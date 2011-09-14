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
	/// vNWS_Attachment SerializableObject which provides fields access at vNWS_Attachment view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vNWS_Attachment : 
		SO__base 
	{
		#region public SO_vNWS_Attachment();
		public SO_vNWS_Attachment(
		) {
			Clear();
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
			haschanges_ = false;

			idattachment_ = IDAttachment_in;
			idlanguage_ = IDLanguage_in;
			ifcontent_ = IFContent_in;
			guid_ = GUID_in;
			ordernum_ = OrderNum_in;
			isimage_ = isImage_in;
			name_ = Name_in;
			description_ = Description_in;
			filename_ = FileName_in;
		}
		public SO_vNWS_Attachment(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idattachment_ = (long)info_in.GetValue("IDAttachment", typeof(long));
			idlanguage_ = (int)info_in.GetValue("IDLanguage", typeof(int));
			ifcontent_ 
				= (info_in.GetValue("IFContent", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFContent", typeof(long));
			IFContent_isNull = (bool)info_in.GetValue("IFContent_isNull", typeof(bool));
			guid_ 
				= (info_in.GetValue("GUID", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("GUID", typeof(string));
			GUID_isNull = (bool)info_in.GetValue("GUID_isNull", typeof(bool));
			ordernum_ 
				= (info_in.GetValue("OrderNum", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("OrderNum", typeof(long));
			OrderNum_isNull = (bool)info_in.GetValue("OrderNum_isNull", typeof(bool));
			isimage_ 
				= (info_in.GetValue("isImage", typeof(bool)) == null)
					? false
					: (bool)info_in.GetValue("isImage", typeof(bool));
			isImage_isNull = (bool)info_in.GetValue("isImage_isNull", typeof(bool));
			name_ 
				= (info_in.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Name", typeof(string));
			Name_isNull = (bool)info_in.GetValue("Name_isNull", typeof(bool));
			description_ 
				= (info_in.GetValue("Description", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Description", typeof(string));
			Description_isNull = (bool)info_in.GetValue("Description_isNull", typeof(bool));
			filename_ 
				= (info_in.GetValue("FileName", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("FileName", typeof(string));
			FileName_isNull = (bool)info_in.GetValue("FileName_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vNWS_Attachment properties since last time getObject method was run.
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
		#region public int IDLanguage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public int idlanguage_;// = 0;
		
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
		#region public long IFContent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifcontent_;// = 0L;
		
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
		public long IFContent {
			get {
				return (long)((ifcontent_ == null) ? 0L : ifcontent_);
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
		#region public bool IFContent_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Attachment's IFContent.
		/// </summary>
		[XmlElement("IFContent_isNull")]
		[SoapElement("IFContent_isNull")]
		public bool IFContent_isNull {
			get { return (ifcontent_ == null); }
			set {
				//if (value) ifcontent_ = null;

				if ((value) && (ifcontent_ != null)) {
					ifcontent_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string GUID { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object guid_;// = string.Empty;
		
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
			50, 
			""
		)]
		public string GUID {
			get {
				return (string)((guid_ == null) ? string.Empty : guid_);
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
		#region public bool GUID_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Attachment's GUID.
		/// </summary>
		[XmlElement("GUID_isNull")]
		[SoapElement("GUID_isNull")]
		public bool GUID_isNull {
			get { return (guid_ == null); }
			set {
				//if (value) guid_ = null;

				if ((value) && (guid_ != null)) {
					guid_ = null;
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
		/// Allows assignement of null and check if null at vNWS_Attachment's OrderNum.
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
		public object isimage_;// = false;
		
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
		public bool isImage {
			get {
				return (bool)((isimage_ == null) ? false : isimage_);
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
		#region public bool isImage_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Attachment's isImage.
		/// </summary>
		[XmlElement("isImage_isNull")]
		[SoapElement("isImage_isNull")]
		public bool isImage_isNull {
			get { return (isimage_ == null); }
			set {
				//if (value) isimage_ = null;

				if ((value) && (isimage_ != null)) {
					isimage_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object name_;// = string.Empty;
		
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
			0, 
			""
		)]
		public string Name {
			get {
				return (string)((name_ == null) ? string.Empty : name_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(name_))
				) {
					name_ = value;
					haschanges_ = true;
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
			get { return (name_ == null); }
			set {
				//if (value) name_ = null;

				if ((value) && (name_ != null)) {
					name_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Description { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object description_;// = string.Empty;
		
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
			0, 
			""
		)]
		public string Description {
			get {
				return (string)((description_ == null) ? string.Empty : description_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(description_))
				) {
					description_ = value;
					haschanges_ = true;
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
			get { return (description_ == null); }
			set {
				//if (value) description_ = null;

				if ((value) && (description_ != null)) {
					description_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string FileName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object filename_;// = string.Empty;
		
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
		public string FileName {
			get {
				return (string)((filename_ == null) ? string.Empty : filename_);
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
		#region public bool FileName_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Attachment's FileName.
		/// </summary>
		[XmlElement("FileName_isNull")]
		[SoapElement("FileName_isNull")]
		public bool FileName_isNull {
			get { return (filename_ == null); }
			set {
				//if (value) filename_ = null;

				if ((value) && (filename_ != null)) {
					filename_ = null;
					haschanges_ = true;
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
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idattachment_ = 0L;
			idlanguage_ = 0;
			ifcontent_ = 0L;
			guid_ = string.Empty;
			ordernum_ = 0L;
			isimage_ = false;
			name_ = string.Empty;
			description_ = string.Empty;
			filename_ = string.Empty;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDAttachment", idattachment_);
			info_in.AddValue("IDLanguage", idlanguage_);
			info_in.AddValue("IFContent", ifcontent_);
			info_in.AddValue("IFContent_isNull", IFContent_isNull);
			info_in.AddValue("GUID", guid_);
			info_in.AddValue("GUID_isNull", GUID_isNull);
			info_in.AddValue("OrderNum", ordernum_);
			info_in.AddValue("OrderNum_isNull", OrderNum_isNull);
			info_in.AddValue("isImage", isimage_);
			info_in.AddValue("isImage_isNull", isImage_isNull);
			info_in.AddValue("Name", name_);
			info_in.AddValue("Name_isNull", Name_isNull);
			info_in.AddValue("Description", description_);
			info_in.AddValue("Description_isNull", Description_isNull);
			info_in.AddValue("FileName", filename_);
			info_in.AddValue("FileName_isNull", FileName_isNull);
		}
		#endregion
		#endregion
	}
}