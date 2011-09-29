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
	/// CRD_ProfileProfile SerializableObject which provides fields access at CRD_ProfileProfile table at Database.
	/// </summary>
	[Serializable()]
	public class SO_CRD_ProfileProfile : 
		SO__base 
	{
		#region public SO_CRD_ProfileProfile();
		public SO_CRD_ProfileProfile(
		) {
			Clear();
		}
		public SO_CRD_ProfileProfile(
			long IFProfile_in, 
			long IFProfile_parent_in
		) {
			haschanges_ = false;

			ifprofile_ = IFProfile_in;
			ifprofile_parent_ = IFProfile_parent_in;
		}
		public SO_CRD_ProfileProfile(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			ifprofile_ = (long)info_in.GetValue("IFProfile", typeof(long));
			ifprofile_parent_ = (long)info_in.GetValue("IFProfile_parent", typeof(long));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_CRD_ProfileProfile properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IFProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifprofile_;// = 0L;
		
		/// <summary>
		/// CRD_ProfileProfile's IFProfile.
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
				return ifprofile_;
			}
			set {
				if (
					(!value.Equals(ifprofile_))
				) {
					ifprofile_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFProfile_parent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifprofile_parent_;// = 0L;
		
		/// <summary>
		/// CRD_ProfileProfile's IFProfile_parent.
		/// </summary>
		[XmlElement("IFProfile_parent")]
		[SoapElement("IFProfile_parent")]
		[DOPropertyAttribute(
			"IFProfile_parent", 
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
		public long IFProfile_parent {
			get {
				return ifprofile_parent_;
			}
			set {
				if (
					(!value.Equals(ifprofile_parent_))
				) {
					ifprofile_parent_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_CRD_ProfileProfile[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_ifprofile = new DataColumn("IFProfile", typeof(long));
			_output.Columns.Add(_dc_ifprofile);
			DataColumn _dc_ifprofile_parent = new DataColumn("IFProfile_parent", typeof(long));
			_output.Columns.Add(_dc_ifprofile_parent);

			foreach (SO_CRD_ProfileProfile _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifprofile] = _serializableobject.IFProfile;
				_dr[_dc_ifprofile_parent] = _serializableobject.IFProfile_parent;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			ifprofile_ = 0L;
			ifprofile_parent_ = 0L;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IFProfile", ifprofile_);
			info_in.AddValue("IFProfile_parent", ifprofile_parent_);
		}
		#endregion
		#endregion
	}
}