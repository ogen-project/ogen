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
	/// vCRD_UserProfile SerializableObject which provides fields access at vCRD_UserProfile view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vCRD_UserProfile : 
		SO__ListItem<long, string> 
	{
		#region public SO_vCRD_UserProfile();
		public SO_vCRD_UserProfile(
		) {
			Clear();
		}
		public SO_vCRD_UserProfile(
			long IDProfile_in, 
			string ProfileName_in, 
			long IDUser_in, 
			bool hasProfile_in
		) {
			haschanges_ = false;

			idprofile_ = IDProfile_in;
			profilename_ = ProfileName_in;
			iduser_ = IDUser_in;
			hasprofile_ = hasProfile_in;
		}
		public SO_vCRD_UserProfile(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idprofile_ = (long)info_in.GetValue("IDProfile", typeof(long));
			profilename_ 
				= (info_in.GetValue("ProfileName", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("ProfileName", typeof(string));
			ProfileName_isNull = (bool)info_in.GetValue("ProfileName_isNull", typeof(bool));
			iduser_ = (long)info_in.GetValue("IDUser", typeof(long));
			hasprofile_ 
				= (info_in.GetValue("hasProfile", typeof(bool)) == null)
					? false
					: (bool)info_in.GetValue("hasProfile", typeof(bool));
			hasProfile_isNull = (bool)info_in.GetValue("hasProfile_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vCRD_UserProfile properties since last time getObject method was run.
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
				return ProfileName;
			}
		} 
		#endregion

		#region public long IDProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idprofile_;// = 0L;
		
		/// <summary>
		/// vCRD_UserProfile's IDProfile.
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
		#region public string ProfileName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object profilename_;// = string.Empty;
		
		/// <summary>
		/// vCRD_UserProfile's ProfileName.
		/// </summary>
		[XmlElement("ProfileName")]
		[SoapElement("ProfileName")]
		[DOPropertyAttribute(
			"ProfileName", 
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
		public string ProfileName {
			get {
				return (string)((profilename_ == null) ? string.Empty : profilename_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(profilename_))
				) {
					profilename_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool ProfileName_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vCRD_UserProfile's ProfileName.
		/// </summary>
		[XmlElement("ProfileName_isNull")]
		[SoapElement("ProfileName_isNull")]
		public bool ProfileName_isNull {
			get { return (profilename_ == null); }
			set {
				//if (value) profilename_ = null;

				if ((value) && (profilename_ != null)) {
					profilename_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long iduser_;// = 0L;
		
		/// <summary>
		/// vCRD_UserProfile's IDUser.
		/// </summary>
		[XmlElement("IDUser")]
		[SoapElement("IDUser")]
		[DOPropertyAttribute(
			"IDUser", 
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
		public long IDUser {
			get {
				return iduser_;
			}
			set {
				if (
					(!value.Equals(iduser_))
				) {
					iduser_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool hasProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object hasprofile_;// = false;
		
		/// <summary>
		/// vCRD_UserProfile's hasProfile.
		/// </summary>
		[XmlElement("hasProfile")]
		[SoapElement("hasProfile")]
		[DOPropertyAttribute(
			"hasProfile", 
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
		public bool hasProfile {
			get {
				return (bool)((hasprofile_ == null) ? false : hasprofile_);
			}
			set {
				if (
					(!value.Equals(hasprofile_))
				) {
					hasprofile_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool hasProfile_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vCRD_UserProfile's hasProfile.
		/// </summary>
		[XmlElement("hasProfile_isNull")]
		[SoapElement("hasProfile_isNull")]
		public bool hasProfile_isNull {
			get { return (hasprofile_ == null); }
			set {
				//if (value) hasprofile_ = null;

				if ((value) && (hasprofile_ != null)) {
					hasprofile_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vCRD_UserProfile[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idprofile = new DataColumn("IDProfile", typeof(long));
			_output.Columns.Add(_dc_idprofile);
			DataColumn _dc_profilename = new DataColumn("ProfileName", typeof(string));
			_output.Columns.Add(_dc_profilename);
			DataColumn _dc_iduser = new DataColumn("IDUser", typeof(long));
			_output.Columns.Add(_dc_iduser);
			DataColumn _dc_hasprofile = new DataColumn("hasProfile", typeof(bool));
			_output.Columns.Add(_dc_hasprofile);

			foreach (SO_vCRD_UserProfile _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idprofile] = _serializableobject.IDProfile;
				_dr[_dc_profilename] = _serializableobject.ProfileName;
				_dr[_dc_iduser] = _serializableobject.IDUser;
				_dr[_dc_hasprofile] = _serializableobject.hasProfile;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idprofile_ = 0L;
			profilename_ = string.Empty;
			iduser_ = 0L;
			hasprofile_ = false;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDProfile", idprofile_);
			info_in.AddValue("ProfileName", profilename_);
			info_in.AddValue("ProfileName_isNull", ProfileName_isNull);
			info_in.AddValue("IDUser", iduser_);
			info_in.AddValue("hasProfile", hasprofile_);
			info_in.AddValue("hasProfile_isNull", hasProfile_isNull);
		}
		#endregion
		#endregion
	}
}