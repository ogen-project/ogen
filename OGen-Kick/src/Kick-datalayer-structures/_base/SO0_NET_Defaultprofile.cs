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
	/// NET_Defaultprofile SerializableObject which provides fields access at NET_Defaultprofile table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NET_Defaultprofile : 
		SO__base 
	{
		#region public SO_NET_Defaultprofile();
		public SO_NET_Defaultprofile(
		) {
			Clear();
		}
		public SO_NET_Defaultprofile(
			long IDDefaultprofile_in, 
			long IFProfile_in
		) {
			haschanges_ = false;

			iddefaultprofile_ = IDDefaultprofile_in;
			ifprofile_ = IFProfile_in;
		}
		public SO_NET_Defaultprofile(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			iddefaultprofile_ = (long)info_in.GetValue("IDDefaultprofile", typeof(long));
			ifprofile_ = (long)info_in.GetValue("IFProfile", typeof(long));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_NET_Defaultprofile properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IDDefaultprofile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long iddefaultprofile_;// = 0L;
		
		/// <summary>
		/// NET_Defaultprofile's IDDefaultprofile.
		/// </summary>
		[XmlElement("IDDefaultprofile")]
		[SoapElement("IDDefaultprofile")]
		[DOPropertyAttribute(
			"IDDefaultprofile", 
			"", 
			"", 
			true, 
			true, 
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
		public long IDDefaultprofile {
			get {
				return iddefaultprofile_;
			}
			set {
				if (
					(!value.Equals(iddefaultprofile_))
				) {
					iddefaultprofile_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifprofile_;// = 0L;
		
		/// <summary>
		/// NET_Defaultprofile's IFProfile.
		/// </summary>
		[XmlElement("IFProfile")]
		[SoapElement("IFProfile")]
		[DOPropertyAttribute(
			"IFProfile", 
			"", 
			"", 
			false, 
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
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NET_Defaultprofile[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_iddefaultprofile = new DataColumn("IDDefaultprofile", typeof(long));
			_output.Columns.Add(_dc_iddefaultprofile);
			DataColumn _dc_ifprofile = new DataColumn("IFProfile", typeof(long));
			_output.Columns.Add(_dc_ifprofile);

			foreach (SO_NET_Defaultprofile _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_iddefaultprofile] = _serializableobject.IDDefaultprofile;
				_dr[_dc_ifprofile] = _serializableobject.IFProfile;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			iddefaultprofile_ = 0L;
			ifprofile_ = 0L;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDDefaultprofile", iddefaultprofile_);
			info_in.AddValue("IFProfile", ifprofile_);
		}
		#endregion
		#endregion
	}
}