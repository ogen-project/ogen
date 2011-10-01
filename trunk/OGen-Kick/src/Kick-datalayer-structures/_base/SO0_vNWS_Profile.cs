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
	/// vNWS_Profile SerializableObject which provides fields access at vNWS_Profile view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vNWS_Profile : 
		SO__ListItem<long, string> 
	{
		#region public SO_vNWS_Profile();
		public SO_vNWS_Profile(
		) {
			Clear();
		}
		public SO_vNWS_Profile(
			long IDProfile_in, 
			string Name_in, 
			int IDApplication_in, 
			long IFUser__Approved_in, 
			DateTime Approved_date_in, 
			string ManagerName_in
		) {
			haschanges_ = false;

			idprofile_ = IDProfile_in;
			name_ = Name_in;
			idapplication_ = IDApplication_in;
			ifuser__approved_ = IFUser__Approved_in;
			approved_date_ = Approved_date_in;
			managername_ = ManagerName_in;
		}
		public SO_vNWS_Profile(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idprofile_ = (long)info_in.GetValue("IDProfile", typeof(long));
			name_ 
				= (info_in.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Name", typeof(string));
			Name_isNull = (bool)info_in.GetValue("Name_isNull", typeof(bool));
			idapplication_ 
				= (info_in.GetValue("IDApplication", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IDApplication", typeof(int));
			IDApplication_isNull = (bool)info_in.GetValue("IDApplication_isNull", typeof(bool));
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
			managername_ 
				= (info_in.GetValue("ManagerName", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("ManagerName", typeof(string));
			ManagerName_isNull = (bool)info_in.GetValue("ManagerName_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vNWS_Profile properties since last time getObject method was run.
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
				return idprofile_;
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

		#region public long IDProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idprofile_;// = 0L;
		
		/// <summary>
		/// vNWS_Profile's IDProfile.
		/// </summary>
		[XmlElement("IDProfile")]
		[SoapElement("IDProfile")]
		[DOPropertyAttribute(
			"IDProfile", 
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
			true, 
			false, 
			0, 
			""
		)]
		public long IDProfile {
			get {
				return idprofile_;
			}
			set {
				if (
					(!value.Equals(idprofile_))
				) {
					idprofile_ = value;
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
		/// vNWS_Profile's Name.
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
			255, 
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
		/// Allows assignement of null and check if null at vNWS_Profile's Name.
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
		#region public int IDApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object idapplication_;// = 0;
		
		/// <summary>
		/// vNWS_Profile's IDApplication.
		/// </summary>
		[XmlElement("IDApplication")]
		[SoapElement("IDApplication")]
		[DOPropertyAttribute(
			"IDApplication", 
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
		public int IDApplication {
			get {
				return (int)((idapplication_ == null) ? 0 : idapplication_);
			}
			set {
				if (
					(!value.Equals(idapplication_))
				) {
					idapplication_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IDApplication_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Profile's IDApplication.
		/// </summary>
		[XmlElement("IDApplication_isNull")]
		[SoapElement("IDApplication_isNull")]
		public bool IDApplication_isNull {
			get { return (idapplication_ == null); }
			set {
				//if (value) idapplication_ = null;

				if ((value) && (idapplication_ != null)) {
					idapplication_ = null;
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
		/// vNWS_Profile's IFUser__Approved.
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
		/// Allows assignement of null and check if null at vNWS_Profile's IFUser__Approved.
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
		/// vNWS_Profile's Approved_date.
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
		/// Allows assignement of null and check if null at vNWS_Profile's Approved_date.
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
		#region public string ManagerName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object managername_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Profile's ManagerName.
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
		/// Allows assignement of null and check if null at vNWS_Profile's ManagerName.
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
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vNWS_Profile[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idprofile = new DataColumn("IDProfile", typeof(long));
			_output.Columns.Add(_dc_idprofile);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_idapplication = new DataColumn("IDApplication", typeof(int));
			_output.Columns.Add(_dc_idapplication);
			DataColumn _dc_ifuser__approved = new DataColumn("IFUser__Approved", typeof(long));
			_output.Columns.Add(_dc_ifuser__approved);
			DataColumn _dc_approved_date = new DataColumn("Approved_date", typeof(DateTime));
			_output.Columns.Add(_dc_approved_date);
			DataColumn _dc_managername = new DataColumn("ManagerName", typeof(string));
			_output.Columns.Add(_dc_managername);

			foreach (SO_vNWS_Profile _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idprofile] = _serializableobject.IDProfile;
				_dr[_dc_name] = _serializableobject.Name;
				_dr[_dc_idapplication] = _serializableobject.IDApplication;
				_dr[_dc_ifuser__approved] = _serializableobject.IFUser__Approved;
				_dr[_dc_approved_date] = _serializableobject.Approved_date;
				_dr[_dc_managername] = _serializableobject.ManagerName;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idprofile_ = 0L;
			name_ = string.Empty;
			idapplication_ = 0;
			ifuser__approved_ = 0L;
			approved_date_ = new DateTime(1900, 1, 1);
			managername_ = string.Empty;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDProfile", idprofile_);
			info_in.AddValue("Name", name_);
			info_in.AddValue("Name_isNull", Name_isNull);
			info_in.AddValue("IDApplication", idapplication_);
			info_in.AddValue("IDApplication_isNull", IDApplication_isNull);
			info_in.AddValue("IFUser__Approved", ifuser__approved_);
			info_in.AddValue("IFUser__Approved_isNull", IFUser__Approved_isNull);
			info_in.AddValue("Approved_date", approved_date_);
			info_in.AddValue("Approved_date_isNull", Approved_date_isNull);
			info_in.AddValue("ManagerName", managername_);
			info_in.AddValue("ManagerName_isNull", ManagerName_isNull);
		}
		#endregion
		#endregion
	}
}