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
	/// vCRD_UserProfile SerializableObject which provides fields access at vCRD_UserProfile view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vCRD_UserProfile : 
		SO__ListItem<long, string>, ISerializable
	{
		#region public SO_vCRD_UserProfile();
		public SO_vCRD_UserProfile(
		) {
			this.Clear();
		}
		public SO_vCRD_UserProfile(
			long IDProfile_in, 
			string ProfileName_in, 
			long IDUser_in, 
			bool hasProfile_in
		) {
			this.idprofile_ = IDProfile_in;
			this.profilename_ = ProfileName_in;
			this.iduser_ = IDUser_in;
			this.hasprofile_ = hasProfile_in;

			this.haschanges_ = false;
		}
		protected SO_vCRD_UserProfile(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idprofile_ = (long)info.GetValue("IDProfile", typeof(long));
			this.profilename_ = (string)info.GetValue("ProfileName", typeof(string));
			this.iduser_ = (long)info.GetValue("IDUser", typeof(long));
			this.hasprofile_ 
				= (info.GetValue("hasProfile", typeof(bool)) == null)
					? false
					: (bool)info.GetValue("hasProfile", typeof(bool));
			this.hasProfile_isNull = (bool)info.GetValue("hasProfile_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_vCRD_UserProfile properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public override long ListItem_Value { get; }
		public override long ListItem_Value {
			get {
				return this.idprofile_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return this.profilename_;
			}
		} 
		#endregion

		#region public long IDProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idprofile_;// = 0L;
		
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
		public long IDProfile {
			get {
				return this.idprofile_;
			}
			set {
				if (
					(!value.Equals(this.idprofile_))
				) {
					this.idprofile_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string ProfileName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string profilename_;// = string.Empty;
		
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
			true, 
			255, 
			""
		)]
		public string ProfileName {
			get {
				return this.profilename_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.profilename_))
				) {
					this.profilename_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long iduser_;// = 0L;
		
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
		public long IDUser {
			get {
				return this.iduser_;
			}
			set {
				if (
					(!value.Equals(this.iduser_))
				) {
					this.iduser_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool hasProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object hasprofile_;// = false;
		
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
				return (bool)((this.hasprofile_ == null) ? false : this.hasprofile_);
			}
			set {
				if (
					(!value.Equals(this.hasprofile_))
				) {
					this.hasprofile_ = value;
					this.haschanges_ = true;
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
			get { return (this.hasprofile_ == null); }
			set {
				//if (value) this.hasprofile_ = null;

				if ((value) && (this.hasprofile_ != null)) {
					this.hasprofile_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vCRD_UserProfile[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idprofile = new DataColumn("IDProfile", typeof(long));
			_output.Columns.Add(_dc_idprofile);
			DataColumn _dc_profilename = new DataColumn("ProfileName", typeof(string));
			_output.Columns.Add(_dc_profilename);
			DataColumn _dc_iduser = new DataColumn("IDUser", typeof(long));
			_output.Columns.Add(_dc_iduser);
			DataColumn _dc_hasprofile = new DataColumn("hasProfile", typeof(bool));
			_output.Columns.Add(_dc_hasprofile);

			foreach (SO_vCRD_UserProfile _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idprofile] = _serializableObject.IDProfile;
				_dr[_dc_profilename] = _serializableObject.ProfileName;
				_dr[_dc_iduser] = _serializableObject.IDUser;
				_dr[_dc_hasprofile] = _serializableObject.hasProfile;

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
			this.idprofile_ = 0L;
			this.profilename_ = string.Empty;
			this.iduser_ = 0L;
			this.hasprofile_ = false;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDProfile", this.idprofile_);
			info.AddValue("ProfileName", this.profilename_);
			info.AddValue("IDUser", this.iduser_);
			info.AddValue("hasProfile", this.hasprofile_);
			info.AddValue("hasProfile_isNull", this.hasProfile_isNull);
		}
		#endregion
		#endregion
	}
}