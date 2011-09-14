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
	/// vCRD_ProfilePermition SerializableObject which provides fields access at vCRD_ProfilePermition view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vCRD_ProfilePermition : 
		SO__ListItem<long, string> 
	{
		#region public SO_vCRD_ProfilePermition();
		public SO_vCRD_ProfilePermition(
		) {
			Clear();
		}
		public SO_vCRD_ProfilePermition(
			long IDPermition_in, 
			string PermitionName_in, 
			long IDProfile_in, 
			bool hasPermition_in
		) {
			haschanges_ = false;

			idpermition_ = IDPermition_in;
			permitionname_ = PermitionName_in;
			idprofile_ = IDProfile_in;
			haspermition_ = hasPermition_in;
		}
		public SO_vCRD_ProfilePermition(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idpermition_ = (long)info_in.GetValue("IDPermition", typeof(long));
			permitionname_ 
				= (info_in.GetValue("PermitionName", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("PermitionName", typeof(string));
			PermitionName_isNull = (bool)info_in.GetValue("PermitionName_isNull", typeof(bool));
			idprofile_ = (long)info_in.GetValue("IDProfile", typeof(long));
			haspermition_ 
				= (info_in.GetValue("hasPermition", typeof(bool)) == null)
					? false
					: (bool)info_in.GetValue("hasPermition", typeof(bool));
			hasPermition_isNull = (bool)info_in.GetValue("hasPermition_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vCRD_ProfilePermition properties since last time getObject method was run.
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
				return idpermition_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return PermitionName;
			}
		} 
		#endregion

		#region public long IDPermition { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idpermition_;// = 0L;
		
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
		public long IDPermition {
			get {
				return idpermition_;
			}
			set {
				if (
					(!value.Equals(idpermition_))
				) {
					idpermition_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string PermitionName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object permitionname_;// = string.Empty;
		
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
		public string PermitionName {
			get {
				return (string)((permitionname_ == null) ? string.Empty : permitionname_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(permitionname_))
				) {
					permitionname_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool PermitionName_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vCRD_ProfilePermition's PermitionName.
		/// </summary>
		[XmlElement("PermitionName_isNull")]
		[SoapElement("PermitionName_isNull")]
		public bool PermitionName_isNull {
			get { return (permitionname_ == null); }
			set {
				//if (value) permitionname_ = null;

				if ((value) && (permitionname_ != null)) {
					permitionname_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idprofile_;// = 0L;
		
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
		#region public bool hasPermition { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object haspermition_;// = false;
		
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
				return (bool)((haspermition_ == null) ? false : haspermition_);
			}
			set {
				if (
					(!value.Equals(haspermition_))
				) {
					haspermition_ = value;
					haschanges_ = true;
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
			get { return (haspermition_ == null); }
			set {
				//if (value) haspermition_ = null;

				if ((value) && (haspermition_ != null)) {
					haspermition_ = null;
					haschanges_ = true;
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
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idpermition_ = 0L;
			permitionname_ = string.Empty;
			idprofile_ = 0L;
			haspermition_ = false;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDPermition", idpermition_);
			info_in.AddValue("PermitionName", permitionname_);
			info_in.AddValue("PermitionName_isNull", PermitionName_isNull);
			info_in.AddValue("IDProfile", idprofile_);
			info_in.AddValue("hasPermition", haspermition_);
			info_in.AddValue("hasPermition_isNull", hasPermition_isNull);
		}
		#endregion
		#endregion
	}
}