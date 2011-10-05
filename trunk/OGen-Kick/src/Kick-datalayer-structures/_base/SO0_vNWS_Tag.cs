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
	/// vNWS_Tag SerializableObject which provides fields access at vNWS_Tag view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vNWS_Tag : 
		SO__ListItem<long, string> 
	{
		#region public SO_vNWS_Tag();
		public SO_vNWS_Tag(
		) {
			Clear();
		}
		public SO_vNWS_Tag(
			long IDTag_in, 
			int IDLanguage_in, 
			long IFTag__parent_in, 
			long IFUser__Approved_in, 
			DateTime Approved_date_in, 
			string Name_in, 
			int IFApplication_in, 
			string ManagerName_in, 
			string ShortName_in
		) {
			haschanges_ = false;

			idtag_ = IDTag_in;
			idlanguage_ = IDLanguage_in;
			iftag__parent_ = IFTag__parent_in;
			ifuser__approved_ = IFUser__Approved_in;
			approved_date_ = Approved_date_in;
			name_ = Name_in;
			ifapplication_ = IFApplication_in;
			managername_ = ManagerName_in;
			shortname_ = ShortName_in;
		}
		public SO_vNWS_Tag(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idtag_ = (long)info_in.GetValue("IDTag", typeof(long));
			idlanguage_ = (int)info_in.GetValue("IDLanguage", typeof(int));
			iftag__parent_ 
				= (info_in.GetValue("IFTag__parent", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFTag__parent", typeof(long));
			IFTag__parent_isNull = (bool)info_in.GetValue("IFTag__parent_isNull", typeof(bool));
			ifuser__approved_ 
				= (info_in.GetValue("IFUser__Approved", typeof(long)) == null)
					? 0L
					: (long)info_in.GetValue("IFUser__Approved", typeof(long));
			IFUser__Approved_isNull = (bool)info_in.GetValue("IFUser__Approved_isNull", typeof(bool));
			approved_date_ 
				= (info_in.GetValue("Approved_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Approved_date", typeof(DateTime));
			Approved_date_isNull = (bool)info_in.GetValue("Approved_date_isNull", typeof(bool));
			name_ 
				= (info_in.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Name", typeof(string));
			Name_isNull = (bool)info_in.GetValue("Name_isNull", typeof(bool));
			ifapplication_ 
				= (info_in.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IFApplication", typeof(int));
			IFApplication_isNull = (bool)info_in.GetValue("IFApplication_isNull", typeof(bool));
			managername_ 
				= (info_in.GetValue("ManagerName", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("ManagerName", typeof(string));
			ManagerName_isNull = (bool)info_in.GetValue("ManagerName_isNull", typeof(bool));
			shortname_ 
				= (info_in.GetValue("ShortName", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("ShortName", typeof(string));
			ShortName_isNull = (bool)info_in.GetValue("ShortName_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vNWS_Tag properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public override long ListItem_Value { get; }
		public override long ListItem_Value {
			get {
				return idtag_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return Name;
			}
		} 
		#endregion

		#region public long IDTag { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idtag_;// = 0L;
		
		/// <summary>
		/// vNWS_Tag's IDTag.
		/// </summary>
		[XmlElement("IDTag")]
		[SoapElement("IDTag")]
		[DOPropertyAttribute(
			"IDTag", 
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
			true, 
			false, 
			0, 
			""
		)]
		public long IDTag {
			get {
				return idtag_;
			}
			set {
				if (
					(!value.Equals(idtag_))
				) {
					idtag_ = value;
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
		/// vNWS_Tag's IDLanguage.
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
		#region public long IFTag__parent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object iftag__parent_;// = 0L;
		
		/// <summary>
		/// vNWS_Tag's IFTag__parent.
		/// </summary>
		[XmlElement("IFTag__parent")]
		[SoapElement("IFTag__parent")]
		[DOPropertyAttribute(
			"IFTag__parent", 
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
		public long IFTag__parent {
			get {
				return (long)((iftag__parent_ == null) ? 0L : iftag__parent_);
			}
			set {
				if (
					(!value.Equals(iftag__parent_))
				) {
					iftag__parent_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFTag__parent_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Tag's IFTag__parent.
		/// </summary>
		[XmlElement("IFTag__parent_isNull")]
		[SoapElement("IFTag__parent_isNull")]
		public bool IFTag__parent_isNull {
			get { return (iftag__parent_ == null); }
			set {
				//if (value) iftag__parent_ = null;

				if ((value) && (iftag__parent_ != null)) {
					iftag__parent_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser__Approved { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifuser__approved_;// = 0L;
		
		/// <summary>
		/// vNWS_Tag's IFUser__Approved.
		/// </summary>
		[XmlElement("IFUser__Approved")]
		[SoapElement("IFUser__Approved")]
		[DOPropertyAttribute(
			"IFUser__Approved", 
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
		public long IFUser__Approved {
			get {
				return (long)((ifuser__approved_ == null) ? 0L : ifuser__approved_);
			}
			set {
				if (
					(!value.Equals(ifuser__approved_))
				) {
					ifuser__approved_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFUser__Approved_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Tag's IFUser__Approved.
		/// </summary>
		[XmlElement("IFUser__Approved_isNull")]
		[SoapElement("IFUser__Approved_isNull")]
		public bool IFUser__Approved_isNull {
			get { return (ifuser__approved_ == null); }
			set {
				//if (value) ifuser__approved_ = null;

				if ((value) && (ifuser__approved_ != null)) {
					ifuser__approved_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Approved_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object approved_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// vNWS_Tag's Approved_date.
		/// </summary>
		[XmlElement("Approved_date")]
		[SoapElement("Approved_date")]
		[DOPropertyAttribute(
			"Approved_date", 
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
		public DateTime Approved_date {
			get {
				return (DateTime)((approved_date_ == null) ? new DateTime(1900, 1, 1) : approved_date_);
			}
			set {
				if (
					(!value.Equals(approved_date_))
				) {
					approved_date_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Approved_date_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Tag's Approved_date.
		/// </summary>
		[XmlElement("Approved_date_isNull")]
		[SoapElement("Approved_date_isNull")]
		public bool Approved_date_isNull {
			get { return (approved_date_ == null); }
			set {
				//if (value) approved_date_ = null;

				if ((value) && (approved_date_ != null)) {
					approved_date_ = null;
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
		/// vNWS_Tag's Name.
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
			true, 
			8000, 
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
		/// Allows assignement of null and check if null at vNWS_Tag's Name.
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
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifapplication_;// = 0;
		
		/// <summary>
		/// vNWS_Tag's IFApplication.
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
		/// Allows assignement of null and check if null at vNWS_Tag's IFApplication.
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
		#region public string ManagerName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object managername_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Tag's ManagerName.
		/// </summary>
		[XmlElement("ManagerName")]
		[SoapElement("ManagerName")]
		[DOPropertyAttribute(
			"ManagerName", 
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
		public string ManagerName {
			get {
				return (string)((managername_ == null) ? string.Empty : managername_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(managername_))
				) {
					managername_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool ManagerName_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Tag's ManagerName.
		/// </summary>
		[XmlElement("ManagerName_isNull")]
		[SoapElement("ManagerName_isNull")]
		public bool ManagerName_isNull {
			get { return (managername_ == null); }
			set {
				//if (value) managername_ = null;

				if ((value) && (managername_ != null)) {
					managername_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string ShortName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object shortname_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Tag's ShortName.
		/// </summary>
		[XmlElement("ShortName")]
		[SoapElement("ShortName")]
		[DOPropertyAttribute(
			"ShortName", 
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
		public string ShortName {
			get {
				return (string)((shortname_ == null) ? string.Empty : shortname_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(shortname_))
				) {
					shortname_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool ShortName_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Tag's ShortName.
		/// </summary>
		[XmlElement("ShortName_isNull")]
		[SoapElement("ShortName_isNull")]
		public bool ShortName_isNull {
			get { return (shortname_ == null); }
			set {
				//if (value) shortname_ = null;

				if ((value) && (shortname_ != null)) {
					shortname_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vNWS_Tag[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idtag = new DataColumn("IDTag", typeof(long));
			_output.Columns.Add(_dc_idtag);
			DataColumn _dc_idlanguage = new DataColumn("IDLanguage", typeof(int));
			_output.Columns.Add(_dc_idlanguage);
			DataColumn _dc_iftag__parent = new DataColumn("IFTag__parent", typeof(long));
			_output.Columns.Add(_dc_iftag__parent);
			DataColumn _dc_ifuser__approved = new DataColumn("IFUser__Approved", typeof(long));
			_output.Columns.Add(_dc_ifuser__approved);
			DataColumn _dc_approved_date = new DataColumn("Approved_date", typeof(DateTime));
			_output.Columns.Add(_dc_approved_date);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_managername = new DataColumn("ManagerName", typeof(string));
			_output.Columns.Add(_dc_managername);
			DataColumn _dc_shortname = new DataColumn("ShortName", typeof(string));
			_output.Columns.Add(_dc_shortname);

			foreach (SO_vNWS_Tag _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idtag] = _serializableobject.IDTag;
				_dr[_dc_idlanguage] = _serializableobject.IDLanguage;
				_dr[_dc_iftag__parent] = _serializableobject.IFTag__parent;
				_dr[_dc_ifuser__approved] = _serializableobject.IFUser__Approved;
				_dr[_dc_approved_date] = _serializableobject.Approved_date;
				_dr[_dc_name] = _serializableobject.Name;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;
				_dr[_dc_managername] = _serializableobject.ManagerName;
				_dr[_dc_shortname] = _serializableobject.ShortName;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idtag_ = 0L;
			idlanguage_ = 0;
			iftag__parent_ = 0L;
			ifuser__approved_ = 0L;
			approved_date_ = new DateTime(1900, 1, 1);
			name_ = string.Empty;
			ifapplication_ = 0;
			managername_ = string.Empty;
			shortname_ = string.Empty;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDTag", idtag_);
			info_in.AddValue("IDLanguage", idlanguage_);
			info_in.AddValue("IFTag__parent", iftag__parent_);
			info_in.AddValue("IFTag__parent_isNull", IFTag__parent_isNull);
			info_in.AddValue("IFUser__Approved", ifuser__approved_);
			info_in.AddValue("IFUser__Approved_isNull", IFUser__Approved_isNull);
			info_in.AddValue("Approved_date", approved_date_);
			info_in.AddValue("Approved_date_isNull", Approved_date_isNull);
			info_in.AddValue("Name", name_);
			info_in.AddValue("Name_isNull", Name_isNull);
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IFApplication_isNull", IFApplication_isNull);
			info_in.AddValue("ManagerName", managername_);
			info_in.AddValue("ManagerName_isNull", ManagerName_isNull);
			info_in.AddValue("ShortName", shortname_);
			info_in.AddValue("ShortName_isNull", ShortName_isNull);
		}
		#endregion
		#endregion
	}
}