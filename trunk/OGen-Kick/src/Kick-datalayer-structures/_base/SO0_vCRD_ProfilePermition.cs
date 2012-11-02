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
	/// vCRD_ProfilePermition SerializableObject which provides fields access at vCRD_ProfilePermition view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vCRD_ProfilePermition : 
		SO__ListItem<long, string>, ISerializable
	{
		#region public SO_vCRD_ProfilePermition();
		public SO_vCRD_ProfilePermition(
		) {
			this.Clear();
		}
		public SO_vCRD_ProfilePermition(
			long IDPermition_in, 
			string PermitionName_in, 
			long IDProfile_in, 
			bool hasPermition_in
		) {
			this.idpermition_ = IDPermition_in;
			this.permitionname_ = PermitionName_in;
			this.idprofile_ = IDProfile_in;
			this.haspermition_ = hasPermition_in;

			this.haschanges_ = false;
		}
		protected SO_vCRD_ProfilePermition(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idpermition_ = (long)info.GetValue("IDPermition", typeof(long));
			this.permitionname_ = (string)info.GetValue("PermitionName", typeof(string));
			this.idprofile_ = (long)info.GetValue("IDProfile", typeof(long));
			this.haspermition_ 
				= (info.GetValue("hasPermition", typeof(bool)) == null)
					? false
					: (bool)info.GetValue("hasPermition", typeof(bool));
			this.hasPermition_isNull = (bool)info.GetValue("hasPermition_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_vCRD_ProfilePermition properties since last time getObject method was run.
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
				return this.idpermition_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return this.permitionname_;
			}
		} 
		#endregion

		#region public long IDPermition { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idpermition_;// = 0L;
		
		/// <summary>
		/// vCRD_ProfilePermition's IDPermition.
		/// </summary>
		[XmlElement("IDPermition")]
		[SoapElement("IDPermition")]
		[DOPropertyAttribute(
			"IDPermition", 
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
		public long IDPermition {
			get {
				return this.idpermition_;
			}
			set {
				if (
					(!value.Equals(this.idpermition_))
				) {
					this.idpermition_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string PermitionName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string permitionname_;// = string.Empty;
		
		/// <summary>
		/// vCRD_ProfilePermition's PermitionName.
		/// </summary>
		[XmlElement("PermitionName")]
		[SoapElement("PermitionName")]
		[DOPropertyAttribute(
			"PermitionName", 
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
		public string PermitionName {
			get {
				return this.permitionname_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.permitionname_))
				) {
					this.permitionname_ = value;
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
		/// vCRD_ProfilePermition's IDProfile.
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
		#region public bool hasPermition { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object haspermition_;// = false;
		
		/// <summary>
		/// vCRD_ProfilePermition's hasPermition.
		/// </summary>
		[XmlElement("hasPermition")]
		[SoapElement("hasPermition")]
		[DOPropertyAttribute(
			"hasPermition", 
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
		public bool hasPermition {
			get {
				return (bool)((this.haspermition_ == null) ? false : this.haspermition_);
			}
			set {
				if (
					(!value.Equals(this.haspermition_))
				) {
					this.haspermition_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool hasPermition_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vCRD_ProfilePermition's hasPermition.
		/// </summary>
		[XmlElement("hasPermition_isNull")]
		[SoapElement("hasPermition_isNull")]
		public bool hasPermition_isNull {
			get { return (this.haspermition_ == null); }
			set {
				//if (value) this.haspermition_ = null;

				if ((value) && (this.haspermition_ != null)) {
					this.haspermition_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vCRD_ProfilePermition[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idpermition = new DataColumn("IDPermition", typeof(long));
			_output.Columns.Add(_dc_idpermition);
			DataColumn _dc_permitionname = new DataColumn("PermitionName", typeof(string));
			_output.Columns.Add(_dc_permitionname);
			DataColumn _dc_idprofile = new DataColumn("IDProfile", typeof(long));
			_output.Columns.Add(_dc_idprofile);
			DataColumn _dc_haspermition = new DataColumn("hasPermition", typeof(bool));
			_output.Columns.Add(_dc_haspermition);

			foreach (SO_vCRD_ProfilePermition _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idpermition] = _serializableobject.IDPermition;
				_dr[_dc_permitionname] = _serializableobject.PermitionName;
				_dr[_dc_idprofile] = _serializableobject.IDProfile;
				_dr[_dc_haspermition] = _serializableobject.hasPermition;

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
			this.idpermition_ = 0L;
			this.permitionname_ = string.Empty;
			this.idprofile_ = 0L;
			this.haspermition_ = false;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDPermition", this.idpermition_);
			info.AddValue("PermitionName", this.permitionname_);
			info.AddValue("IDProfile", this.idprofile_);
			info.AddValue("hasPermition", this.haspermition_);
			info.AddValue("hasPermition_isNull", this.hasPermition_isNull);
		}
		#endregion
		#endregion
	}
}