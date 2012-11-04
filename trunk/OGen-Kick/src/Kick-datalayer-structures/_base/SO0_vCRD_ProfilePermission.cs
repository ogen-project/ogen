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
	/// vCRD_ProfilePermission SerializableObject which provides fields access at vCRD_ProfilePermission view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vCRD_ProfilePermission : 
		SO__ListItem<long, string>, ISerializable
	{
		#region public SO_vCRD_ProfilePermission();
		public SO_vCRD_ProfilePermission(
		) {
			this.Clear();
		}
		public SO_vCRD_ProfilePermission(
			long IDPermission_in, 
			string PermissionName_in, 
			long IDProfile_in, 
			bool hasPermission_in
		) {
			this.idpermission_ = IDPermission_in;
			this.permissionname_ = PermissionName_in;
			this.idprofile_ = IDProfile_in;
			this.haspermission_ = hasPermission_in;

			this.haschanges_ = false;
		}
		protected SO_vCRD_ProfilePermission(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idpermission_ = (long)info.GetValue("IDPermission", typeof(long));
			this.permissionname_ = (string)info.GetValue("PermissionName", typeof(string));
			this.idprofile_ = (long)info.GetValue("IDProfile", typeof(long));
			this.haspermission_ 
				= (info.GetValue("hasPermission", typeof(bool)) == null)
					? false
					: (bool)info.GetValue("hasPermission", typeof(bool));
			this.hasPermission_isNull = (bool)info.GetValue("hasPermission_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_vCRD_ProfilePermission properties since last time getObject method was run.
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
				return this.idpermission_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return this.permissionname_;
			}
		} 
		#endregion

		#region public long IDPermission { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idpermission_;// = 0L;
		
		/// <summary>
		/// vCRD_ProfilePermission's IDPermission.
		/// </summary>
		[XmlElement("IDPermission")]
		[SoapElement("IDPermission")]
		[DOPropertyAttribute(
			"IDPermission", 
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
		public long IDPermission {
			get {
				return this.idpermission_;
			}
			set {
				if (
					(!value.Equals(this.idpermission_))
				) {
					this.idpermission_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string PermissionName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string permissionname_;// = string.Empty;
		
		/// <summary>
		/// vCRD_ProfilePermission's PermissionName.
		/// </summary>
		[XmlElement("PermissionName")]
		[SoapElement("PermissionName")]
		[DOPropertyAttribute(
			"PermissionName", 
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
		public string PermissionName {
			get {
				return this.permissionname_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.permissionname_))
				) {
					this.permissionname_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idprofile_;// = 0L;
		
		/// <summary>
		/// vCRD_ProfilePermission's IDProfile.
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
			false, 
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
		#region public bool hasPermission { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object haspermission_;// = false;
		
		/// <summary>
		/// vCRD_ProfilePermission's hasPermission.
		/// </summary>
		[XmlElement("hasPermission")]
		[SoapElement("hasPermission")]
		[DOPropertyAttribute(
			"hasPermission", 
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
		public bool hasPermission {
			get {
				return (bool)((this.haspermission_ == null) ? false : this.haspermission_);
			}
			set {
				if (
					(!value.Equals(this.haspermission_))
				) {
					this.haspermission_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool hasPermission_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vCRD_ProfilePermission's hasPermission.
		/// </summary>
		[XmlElement("hasPermission_isNull")]
		[SoapElement("hasPermission_isNull")]
		public bool hasPermission_isNull {
			get { return (this.haspermission_ == null); }
			set {
				//if (value) this.haspermission_ = null;

				if ((value) && (this.haspermission_ != null)) {
					this.haspermission_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vCRD_ProfilePermission[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idpermission = new DataColumn("IDPermission", typeof(long));
			_output.Columns.Add(_dc_idpermission);
			DataColumn _dc_permissionname = new DataColumn("PermissionName", typeof(string));
			_output.Columns.Add(_dc_permissionname);
			DataColumn _dc_idprofile = new DataColumn("IDProfile", typeof(long));
			_output.Columns.Add(_dc_idprofile);
			DataColumn _dc_haspermission = new DataColumn("hasPermission", typeof(bool));
			_output.Columns.Add(_dc_haspermission);

			foreach (SO_vCRD_ProfilePermission _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idpermission] = _serializableObject.IDPermission;
				_dr[_dc_permissionname] = _serializableObject.PermissionName;
				_dr[_dc_idprofile] = _serializableObject.IDProfile;
				_dr[_dc_haspermission] = _serializableObject.hasPermission;

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
			this.idpermission_ = 0L;
			this.permissionname_ = string.Empty;
			this.idprofile_ = 0L;
			this.haspermission_ = false;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDPermission", this.idpermission_);
			info.AddValue("PermissionName", this.permissionname_);
			info.AddValue("IDProfile", this.idprofile_);
			info.AddValue("hasPermission", this.haspermission_);
			info.AddValue("hasPermission_isNull", this.hasPermission_isNull);
		}
		#endregion
		#endregion
	}
}