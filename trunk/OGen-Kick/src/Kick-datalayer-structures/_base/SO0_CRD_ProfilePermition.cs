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
	/// CRD_ProfilePermition SerializableObject which provides fields access at CRD_ProfilePermition table at Database.
	/// </summary>
	[Serializable()]
	public class SO_CRD_ProfilePermition : 
		ISerializable
	{
		#region public SO_CRD_ProfilePermition();
		public SO_CRD_ProfilePermition(
		) {
			this.Clear();
		}
		public SO_CRD_ProfilePermition(
			long IFProfile_in, 
			long IFPermition_in
		) {
			this.ifprofile_ = IFProfile_in;
			this.ifpermition_ = IFPermition_in;

			this.haschanges_ = false;
		}
		protected SO_CRD_ProfilePermition(
			SerializationInfo info,
			StreamingContext context
		) {
			this.ifprofile_ = (long)info.GetValue("IFProfile", typeof(long));
			this.ifpermition_ = (long)info.GetValue("IFPermition", typeof(long));

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
		/// Indicates if changes have been made to FO0_CRD_ProfilePermition properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IFProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifprofile_;// = 0L;
		
		/// <summary>
		/// CRD_ProfilePermition's IFProfile.
		/// </summary>
		[XmlElement("IFProfile")]
		[SoapElement("IFProfile")]
		[DOPropertyAttribute(
			"IFProfile", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"CRD_Profile", 
			"IDProfile", 
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
		public long IFProfile {
			get {
				return this.ifprofile_;
			}
			set {
				if (
					(!value.Equals(this.ifprofile_))
				) {
					this.ifprofile_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFPermition { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifpermition_;// = 0L;
		
		/// <summary>
		/// CRD_ProfilePermition's IFPermition.
		/// </summary>
		[XmlElement("IFPermition")]
		[SoapElement("IFPermition")]
		[DOPropertyAttribute(
			"IFPermition", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"CRD_Permition", 
			"IDPermition", 
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
		public long IFPermition {
			get {
				return this.ifpermition_;
			}
			set {
				if (
					(!value.Equals(this.ifpermition_))
				) {
					this.ifpermition_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_CRD_ProfilePermition[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_ifprofile = new DataColumn("IFProfile", typeof(long));
			_output.Columns.Add(_dc_ifprofile);
			DataColumn _dc_ifpermition = new DataColumn("IFPermition", typeof(long));
			_output.Columns.Add(_dc_ifpermition);

			foreach (SO_CRD_ProfilePermition _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifprofile] = _serializableobject.IFProfile;
				_dr[_dc_ifpermition] = _serializableobject.IFPermition;

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
			this.ifprofile_ = 0L;
			this.ifpermition_ = 0L;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IFProfile", this.ifprofile_);
			info.AddValue("IFPermition", this.ifpermition_);
		}
		#endregion
		#endregion
	}
}