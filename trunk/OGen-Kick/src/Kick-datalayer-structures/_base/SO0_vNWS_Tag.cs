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
	/// vNWS_Tag SerializableObject which provides fields access at vNWS_Tag view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vNWS_Tag : 
		SO__ListItem<long, string>, ISerializable
	{
		#region public SO_vNWS_Tag();
		public SO_vNWS_Tag(
		) {
			this.Clear();
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
			this.idtag_ = IDTag_in;
			this.idlanguage_ = IDLanguage_in;
			this.iftag__parent_ = IFTag__parent_in;
			this.ifuser__approved_ = IFUser__Approved_in;
			this.approved_date_ = Approved_date_in;
			this.name_ = Name_in;
			this.ifapplication_ = IFApplication_in;
			this.managername_ = ManagerName_in;
			this.shortname_ = ShortName_in;

			this.haschanges_ = false;
		}
		protected SO_vNWS_Tag(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idtag_ = (long)info.GetValue("IDTag", typeof(long));
			this.idlanguage_ = (int)info.GetValue("IDLanguage", typeof(int));
			this.iftag__parent_ 
				= (info.GetValue("IFTag__parent", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFTag__parent", typeof(long));
			this.IFTag__parent_isNull = (bool)info.GetValue("IFTag__parent_isNull", typeof(bool));
			this.ifuser__approved_ 
				= (info.GetValue("IFUser__Approved", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFUser__Approved", typeof(long));
			this.IFUser__Approved_isNull = (bool)info.GetValue("IFUser__Approved_isNull", typeof(bool));
			this.approved_date_ 
				= (info.GetValue("Approved_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info.GetValue("Approved_date", typeof(DateTime));
			this.Approved_date_isNull = (bool)info.GetValue("Approved_date_isNull", typeof(bool));
			this.name_ 
				= (info.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Name", typeof(string));
			this.Name_isNull = (bool)info.GetValue("Name_isNull", typeof(bool));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));
			this.managername_ 
				= (info.GetValue("ManagerName", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("ManagerName", typeof(string));
			this.ManagerName_isNull = (bool)info.GetValue("ManagerName_isNull", typeof(bool));
			this.shortname_ 
				= (info.GetValue("ShortName", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("ShortName", typeof(string));
			this.ShortName_isNull = (bool)info.GetValue("ShortName_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_vNWS_Tag properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public override long ListItem_Value { get; }
		public override long ListItem_Value {
			get {
				return this.idtag_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return this.Name;
			}
		} 
		#endregion

		#region public long IDTag { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idtag_;// = 0L;
		
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
				return this.idtag_;
			}
			set {
				if (
					(!value.Equals(this.idtag_))
				) {
					this.idtag_ = value;
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
		#region public long IFTag__parent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object iftag__parent_;// = 0L;
		
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
				return (long)((this.iftag__parent_ == null) ? 0L : this.iftag__parent_);
			}
			set {
				if (
					(!value.Equals(this.iftag__parent_))
				) {
					this.iftag__parent_ = value;
					this.haschanges_ = true;
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
			get { return (this.iftag__parent_ == null); }
			set {
				//if (value) this.iftag__parent_ = null;

				if ((value) && (this.iftag__parent_ != null)) {
					this.iftag__parent_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser__Approved { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifuser__approved_;// = 0L;
		
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
				return (long)((this.ifuser__approved_ == null) ? 0L : this.ifuser__approved_);
			}
			set {
				if (
					(!value.Equals(this.ifuser__approved_))
				) {
					this.ifuser__approved_ = value;
					this.haschanges_ = true;
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
			get { return (this.ifuser__approved_ == null); }
			set {
				//if (value) this.ifuser__approved_ = null;

				if ((value) && (this.ifuser__approved_ != null)) {
					this.ifuser__approved_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Approved_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object approved_date_;// = new DateTime(1900, 1, 1);
		
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
				return (DateTime)((this.approved_date_ == null) ? new DateTime(1900, 1, 1) : this.approved_date_);
			}
			set {
				if (
					(!value.Equals(this.approved_date_))
				) {
					this.approved_date_ = value;
					this.haschanges_ = true;
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
			get { return (this.approved_date_ == null); }
			set {
				//if (value) this.approved_date_ = null;

				if ((value) && (this.approved_date_ != null)) {
					this.approved_date_ = null;
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
		/// Allows assignement of null and check if null at vNWS_Tag's Name.
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
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifapplication_;// = 0;
		
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
				return (int)((this.ifapplication_ == null) ? 0 : this.ifapplication_);
			}
			set {
				if (
					(!value.Equals(this.ifapplication_))
				) {
					this.ifapplication_ = value;
					this.haschanges_ = true;
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
			get { return (this.ifapplication_ == null); }
			set {
				//if (value) this.ifapplication_ = null;

				if ((value) && (this.ifapplication_ != null)) {
					this.ifapplication_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string ManagerName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object managername_;// = string.Empty;
		
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
				return (string)((this.managername_ == null) ? string.Empty : this.managername_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.managername_))
				) {
					this.managername_ = value;
					this.haschanges_ = true;
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
			get { return (this.managername_ == null); }
			set {
				//if (value) this.managername_ = null;

				if ((value) && (this.managername_ != null)) {
					this.managername_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string ShortName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object shortname_;// = string.Empty;
		
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
				return (string)((this.shortname_ == null) ? string.Empty : this.shortname_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.shortname_))
				) {
					this.shortname_ = value;
					this.haschanges_ = true;
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
			get { return (this.shortname_ == null); }
			set {
				//if (value) this.shortname_ = null;

				if ((value) && (this.shortname_ != null)) {
					this.shortname_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vNWS_Tag[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
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

			foreach (SO_vNWS_Tag _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idtag] = _serializableObject.IDTag;
				_dr[_dc_idlanguage] = _serializableObject.IDLanguage;
				_dr[_dc_iftag__parent] = _serializableObject.IFTag__parent;
				_dr[_dc_ifuser__approved] = _serializableObject.IFUser__Approved;
				_dr[_dc_approved_date] = _serializableObject.Approved_date;
				_dr[_dc_name] = _serializableObject.Name;
				_dr[_dc_ifapplication] = _serializableObject.IFApplication;
				_dr[_dc_managername] = _serializableObject.ManagerName;
				_dr[_dc_shortname] = _serializableObject.ShortName;

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
			this.idtag_ = 0L;
			this.idlanguage_ = 0;
			this.iftag__parent_ = 0L;
			this.ifuser__approved_ = 0L;
			this.approved_date_ = new DateTime(1900, 1, 1);
			this.name_ = string.Empty;
			this.ifapplication_ = 0;
			this.managername_ = string.Empty;
			this.shortname_ = string.Empty;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDTag", this.idtag_);
			info.AddValue("IDLanguage", this.idlanguage_);
			info.AddValue("IFTag__parent", this.iftag__parent_);
			info.AddValue("IFTag__parent_isNull", this.IFTag__parent_isNull);
			info.AddValue("IFUser__Approved", this.ifuser__approved_);
			info.AddValue("IFUser__Approved_isNull", this.IFUser__Approved_isNull);
			info.AddValue("Approved_date", this.approved_date_);
			info.AddValue("Approved_date_isNull", this.Approved_date_isNull);
			info.AddValue("Name", this.name_);
			info.AddValue("Name_isNull", this.Name_isNull);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("ManagerName", this.managername_);
			info.AddValue("ManagerName_isNull", this.ManagerName_isNull);
			info.AddValue("ShortName", this.shortname_);
			info.AddValue("ShortName_isNull", this.ShortName_isNull);
		}
		#endregion
		#endregion
	}
}